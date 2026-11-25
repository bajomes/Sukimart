using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormDetailOpname : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private SesiOpname sesi;
        private bool isDataDiubah = false;

        public FormDetailOpname(string idSesi, string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;

            var daftar = PenyimpananData.BacaSesiOpname();
            var ditemukan = daftar.FirstOrDefault(s => s.Id.Equals(idSesi, StringComparison.OrdinalIgnoreCase));
            if (ditemukan == null)
            {
                throw new InvalidOperationException($"Sesi opname {idSesi} tidak ditemukan.");
            }
            this.sesi = ditemukan;

            gridDetail.AllowUserToResizeRows = false;
            UIHelper.RatakanTengah(colKode, colStokSistem, colStokFisik, colSelisih);

            PasangEventHandlers();
            PerbaruiTampilanHeader();
            MuatTabelDetail();
            SesuaikanHakAksesDanStatus();
        }

        private void PasangEventHandlers()
        {
            txtCari.TextChanged += (s, e) => TerapkanFilterTabel();
            chkHanyaSelisih.CheckedChanged += (s, e) => TerapkanFilterTabel();

            gridDetail.CellEndEdit += GridDetail_CellEndEdit;
            gridDetail.CellValidating += GridDetail_CellValidating;

            btnSimpanDraft.Click += BtnSimpanDraft_Click;
            btnAjukan.Click += BtnAjukan_Click;
            btnSetujui.Click += BtnSetujui_Click;
            btnMintaRevisi.Click += BtnMintaRevisi_Click;
            btnBatalkan.Click += BtnBatalkan_Click;
            btnRiwayatRevisi.Click += (s, e) =>
            {
                using FormRiwayatRevisiOpname formRiwayat = new FormRiwayatRevisiOpname(sesi);
                formRiwayat.ShowDialog(this);
            };

            btnKembali.Click += (s, e) =>
            {
                if (isDataDiubah && (sesi.Status == "Draft" || sesi.Status == "Perlu Revisi"))
                {
                    DialogResult simpan = MessageBox.Show(
                        "Terdapat perubahan penghitungan fisik yang belum disimpan ke file. Apakah ingin menyimpan draft sebelum keluar?",
                        "Simpan Draft",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);

                    if (simpan == DialogResult.Yes)
                    {
                        SimpanPerubahanKeSesi();
                        PenyimpananData.SimpanAtauPerbaruiSesiOpname(sesi);
                    }
                    else if (simpan == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        private void PerbaruiTampilanHeader()
        {
            lblJudul.Text = $"Sesi Stok Opname • {sesi.Id}";
            lblNomorOpname.Text = $"Nomor: {sesi.Id}";
            lblTanggal.Text = $"Dibuat: {sesi.TanggalDibuat:dd/MM/yyyy HH:mm}";
            lblPembuat.Text = $"Oleh: {sesi.DibuatOleh}";
            lblStatusBadge.Text = sesi.Status.ToUpper();

            switch (sesi.Status)
            {
                case "Draft":
                    lblStatusBadge.BackColor = Color.FromArgb(243, 244, 246);
                    lblStatusBadge.ForeColor = Color.FromArgb(75, 85, 99);
                    lblBannerText.Text = "Status Draft: Gudang mengisi hasil penghitungan fisik. Setelah semua produk dihitung, klik 'Ajukan Opname' untuk mengirim ke Admin.";
                    break;
                case "Menunggu Persetujuan":
                    lblStatusBadge.BackColor = Color.FromArgb(254, 243, 199);
                    lblStatusBadge.ForeColor = Color.FromArgb(180, 83, 9);
                    lblBannerText.Text = peran == "admin"
                        ? "Status Menunggu Persetujuan: Periksa hasil penghitungan gudang. Admin dapat menyetujui seluruh sesi atau meminta revisi produk tertentu."
                        : "Status Menunggu Persetujuan: Sesi telah diajukan ke Admin. Data terkunci dan menunggu keputusan Admin.";
                    break;
                case "Perlu Revisi":
                    lblStatusBadge.BackColor = Color.FromArgb(254, 215, 170);
                    lblStatusBadge.ForeColor = Color.FromArgb(194, 65, 12);
                    lblBannerText.Text = "Status Perlu Revisi: Admin meminta pemeriksaan ulang pada produk yang ditandai oranye. Perbaiki stok fisik lalu ajukan ulang.";
                    break;
                case "Disetujui":
                    lblStatusBadge.BackColor = Color.FromArgb(209, 250, 229);
                    lblStatusBadge.ForeColor = Color.FromArgb(6, 95, 70);
                    lblBannerText.Text = $"Status Disetujui: Disetujui oleh {sesi.DisetujuiOleh} pada {sesi.TanggalDisetujui:dd/MM/yyyy HH:mm}. Seluruh penyesuaian stok telah diterapkan ke inventaris.";
                    break;
                case "Dibatalkan":
                    lblStatusBadge.BackColor = Color.FromArgb(254, 202, 202);
                    lblStatusBadge.ForeColor = Color.FromArgb(153, 27, 27);
                    lblBannerText.Text = $"Status Dibatalkan: Dibatalkan oleh {sesi.DibatalkanOleh} pada {sesi.TanggalDibatalkan:dd/MM/yyyy HH:mm}. Alasan: {sesi.AlasanPembatalan}";
                    break;
            }
        }

        private void SesuaikanHakAksesDanStatus()
        {
            bool isDraft = sesi.Status == "Draft";
            bool isMenunggu = sesi.Status == "Menunggu Persetujuan";
            bool isPerluRevisi = sesi.Status == "Perlu Revisi";
            bool isDisetujui = sesi.Status == "Disetujui";
            bool isDibatalkan = sesi.Status == "Dibatalkan";

            bool isAdmin = peran == "admin";
            bool isGudang = peran == "gudang";

            // Tombol Simpan Draft & Ajukan (untuk Gudang atau Admin yang mengisi draft)
            btnSimpanDraft.Visible = isDraft || isPerluRevisi;
            btnAjukan.Visible = isDraft || isPerluRevisi;
            btnAjukan.Text = isPerluRevisi ? "Ajukan Ulang Opname" : "Ajukan Opname";

            // Tombol Setujui & Minta Revisi (HANYA untuk Admin saat Menunggu Persetujuan)
            btnSetujui.Visible = isAdmin && isMenunggu;
            btnMintaRevisi.Visible = isAdmin && isMenunggu;

            // Tombol Batalkan (bisa untuk Admin atau pembuat sesi jika belum disetujui / dibatalkan)
            bool bolehBatal = (!isDisetujui && !isDibatalkan) &&
                              (isAdmin || (isGudang && sesi.DibuatOleh.Equals(Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase)));
            btnBatalkan.Visible = bolehBatal;

            // Riwayat revisi selalu dapat dilihat jika ada riwayat
            btnRiwayatRevisi.Visible = (sesi.RiwayatRevisi != null && sesi.RiwayatRevisi.Count > 0) || (sesi.RiwayatStatus != null && sesi.RiwayatStatus.Count > 0);

            // Pengaturan ReadOnly kolom pada tabel
            if (isDraft)
            {
                colStokFisik.ReadOnly = false;
                colKeterangan.ReadOnly = false;
            }
            else if (isPerluRevisi && isGudang)
            {
                // Kolom diatur per-baris di GridDetail_RowPrePaint atau saat pemuatan
                colStokFisik.ReadOnly = false;
                colKeterangan.ReadOnly = false;
            }
            else
            {
                colStokFisik.ReadOnly = true;
                colKeterangan.ReadOnly = true;
            }
        }

        private void MuatTabelDetail()
        {
            TerapkanFilterTabel();
            PerbaruiRingkasanBawah();
        }

        private void TerapkanFilterTabel()
        {
            string keyword = txtCari.Text.Trim().ToLower();
            bool hanyaSelisih = chkHanyaSelisih.Checked;

            gridDetail.Rows.Clear();

            foreach (var item in sesi.Items)
            {
                if (hanyaSelisih && item.Selisih == 0 && item.StokFisik.HasValue)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(keyword))
                {
                    bool cocok = item.KodeBarang.ToLower().Contains(keyword) ||
                                 item.NamaBarang.ToLower().Contains(keyword) ||
                                 item.Keterangan.ToLower().Contains(keyword);
                    if (!cocok) continue;
                }

                string stokFisikTampil = item.StokFisik.HasValue ? item.StokFisik.Value.ToString() : "";
                string selisihTampil = item.StokFisik.HasValue
                    ? ((item.Selisih > 0 ? "+" : "") + item.Selisih.ToString())
                    : "-";

                int rowIndex = gridDetail.Rows.Add(
                    item.KodeBarang,
                    item.NamaBarang,
                    item.StokSistem,
                    stokFisikTampil,
                    selisihTampil,
                    item.Keterangan,
                    item.AlasanRevisi
                );

                DataGridViewRow row = gridDetail.Rows[rowIndex];
                row.Tag = item;

                // Format warna selisih
                if (item.StokFisik.HasValue)
                {
                    if (item.Selisih > 0)
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(16, 149, 102);
                        row.Cells[colSelisih.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                    }
                    else if (item.Selisih < 0)
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(220, 38, 38);
                        row.Cells[colSelisih.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(107, 114, 128);
                    }
                }
                else
                {
                    row.Cells[colStokFisik.Index].Style.ForeColor = Color.FromArgb(156, 163, 175);
                }

                // Format baris yang perlu revisi
                if (item.PerluRevisi)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 237);
                    row.Cells[colNama.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                    row.Cells[colAlasanRevisi.Index].Style.ForeColor = Color.FromArgb(194, 65, 12);
                    row.Cells[colAlasanRevisi.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                }
                else if (sesi.Status == "Perlu Revisi")
                {
                    // Produk yang tidak diminta revisi dikunci tidak boleh diedit
                    row.Cells[colStokFisik.Index].ReadOnly = true;
                    row.Cells[colKeterangan.Index].ReadOnly = true;
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
                }
            }
        }

        private void GridDetail_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == colStokFisik.Index && gridDetail.Rows[e.RowIndex].Tag is ItemOpname item)
            {
                if (sesi.Status == "Perlu Revisi" && !item.PerluRevisi)
                {
                    e.Cancel = true;
                    return;
                }

                string stringVal = e.FormattedValue?.ToString()?.Trim() ?? "";
                if (string.IsNullOrEmpty(stringVal))
                {
                    // Izinkan kosong untuk draft
                    return;
                }

                if (!int.TryParse(stringVal, out int nilai) || nilai < 0)
                {
                    MessageBox.Show("Stok fisik harus berupa angka bulat positif (>= 0).", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void GridDetail_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridDetail.Rows.Count) return;

            DataGridViewRow row = gridDetail.Rows[e.RowIndex];
            if (row.Tag is not ItemOpname item) return;

            if (e.ColumnIndex == colStokFisik.Index)
            {
                string text = row.Cells[colStokFisik.Index].Value?.ToString()?.Trim() ?? "";
                if (int.TryParse(text, out int stokFisik) && stokFisik >= 0)
                {
                    item.StokFisik = stokFisik;
                    item.SudahDihitung = true;
                    item.Selisih = stokFisik - item.StokSistem;

                    row.Cells[colSelisih.Index].Value = (item.Selisih > 0 ? "+" : "") + item.Selisih.ToString();
                    if (item.Selisih > 0)
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(16, 149, 102);
                        row.Cells[colSelisih.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                    }
                    else if (item.Selisih < 0)
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(220, 38, 38);
                        row.Cells[colSelisih.Index].Style.Font = FontInter.Buat(9F, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(107, 114, 128);
                    }
                }
                else
                {
                    item.StokFisik = null;
                    item.SudahDihitung = false;
                    item.Selisih = 0;
                    row.Cells[colSelisih.Index].Value = "-";
                    row.Cells[colSelisih.Index].Style.ForeColor = Color.FromArgb(107, 114, 128);
                }

                isDataDiubah = true;
                PerbaruiRingkasanBawah();
            }
            else if (e.ColumnIndex == colKeterangan.Index)
            {
                item.Keterangan = row.Cells[colKeterangan.Index].Value?.ToString()?.Trim() ?? "";
                isDataDiubah = true;
            }
        }

        private void PerbaruiRingkasanBawah()
        {
            int total = sesi.Items.Count;
            int sudahDihitung = sesi.Items.Count(i => i.StokFisik.HasValue);
            int produkSelisih = sesi.Items.Count(i => i.StokFisik.HasValue && i.Selisih != 0);
            int selisihPlus = sesi.Items.Where(i => i.StokFisik.HasValue && i.Selisih > 0).Sum(i => i.Selisih);
            int selisihMinus = sesi.Items.Where(i => i.StokFisik.HasValue && i.Selisih < 0).Sum(i => Math.Abs(i.Selisih));

            int persen = total > 0 ? (int)Math.Round((double)sudahDihitung / total * 100) : 0;
            lblProgresHitung.Text = $"Progres Penghitungan: {sudahDihitung} / {total} Produk ({persen}%)";

            lblTotalProduk.Text = $"Total Produk: {total}";
            lblProdukSelisih.Text = $"Produk Selisih: {produkSelisih}";
            lblTotalPlus.Text = $"Selisih Lebih (+): +{selisihPlus:N0}";
            lblTotalMinus.Text = $"Selisih Kurang (-): -{selisihMinus:N0}";
        }

        private void SimpanPerubahanKeSesi()
        {
            gridDetail.EndEdit();
            // Data sudah tersimpan di objek ItemOpname karena row.Tag mengacu pada instance yang sama di sesi.Items
        }

        private void BtnSimpanDraft_Click(object? sender, EventArgs e)
        {
            try
            {
                SimpanPerubahanKeSesi();
                PenyimpananData.SimpanAtauPerbaruiSesiOpname(sesi);
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Stok Opname", $"Menyimpan draft penghitungan sesi opname {sesi.Id}.");
                isDataDiubah = false;
                MessageBox.Show("Draft penghitungan stok opname berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan draft opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAjukan_Click(object? sender, EventArgs e)
        {
            SimpanPerubahanKeSesi();

            // 1. Validasi bahwa seluruh produk telah dihitung fisiknya
            var belumDihitung = sesi.Items.Where(i => !i.StokFisik.HasValue).ToList();
            if (belumDihitung.Count > 0)
            {
                MessageBox.Show(
                    $"Pengajuan gagal: Masih terdapat {belumDihitung.Count} produk aktif yang belum diisi stok fisiknya.\n" +
                    "Seluruh produk harus memiliki nilai stok fisik yang valid sebelum dapat diajukan kepada Admin.",
                    "Pemeriksaan Belum Lengkap",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Jika status adalah Perlu Revisi, pastikan produk yang direvisi sudah diperbaiki
            bool isRevisiUlang = sesi.Status == "Perlu Revisi";
            if (isRevisiUlang)
            {
                var produkRevisi = sesi.Items.Where(i => i.PerluRevisi).ToList();
                foreach (var p in produkRevisi)
                {
                    if (sesi.RiwayatRevisi != null)
                    {
                        var entry = sesi.RiwayatRevisi.LastOrDefault(r => r.KodeBarang == p.KodeBarang);
                        if (entry != null)
                        {
                            entry.StokFisikBaru = p.StokFisik;
                            entry.TanggalDiperbaiki = DateTime.Now;
                            entry.DiperbaikiOleh = Navigasi.PenggunaAktif;
                        }
                    }
                    // Reset tanda perlu revisi setelah perbaikan diajukan
                    p.PerluRevisi = false;
                }
            }

            string teksKonfirmasi = isRevisiUlang
                ? $"Apakah Anda yakin ingin mengajukan ulang seluruh sesi opname {sesi.Id} kepada Admin setelah perbaikan?"
                : $"Apakah Anda yakin ingin mengajukan hasil penghitungan fisik sesi opname {sesi.Id} kepada Admin?\nSetelah diajukan, data penghitungan akan dikunci.";

            DialogResult konfirmasi = MessageBox.Show(teksKonfirmasi, "Konfirmasi Pengajuan Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DateTime waktuAjukan = DateTime.Now;
                sesi.Status = "Menunggu Persetujuan";
                sesi.TanggalDiajukan = waktuAjukan;
                sesi.RiwayatStatus.Add(new RiwayatStatusOpname
                {
                    Waktu = waktuAjukan,
                    Status = "Menunggu Persetujuan",
                    Oleh = Navigasi.PenggunaAktif,
                    Catatan = isRevisiUlang ? "Petugas Gudang mengajukan ulang sesi setelah revisi perbaikan." : "Petugas Gudang mengajukan hasil penghitungan opname untuk diperiksa Admin."
                });

                PenyimpananData.SimpanAtauPerbaruiSesiOpname(sesi);
                string aksiLog = isRevisiUlang
                    ? $"Mengajukan ulang sesi opname {sesi.Id} setelah perbaikan."
                    : $"Mengajukan sesi opname {sesi.Id} ({sesi.Items.Count} produk) ke Admin.";
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Stok Opname", aksiLog);

                isDataDiubah = false;
                PerbaruiTampilanHeader();
                SesuaikanHakAksesDanStatus();
                MuatTabelDetail();

                MessageBox.Show(
                    $"Sesi opname {sesi.Id} berhasil diajukan kepada Admin.\nStatus sekarang: Menunggu Persetujuan.",
                    "Pengajuan Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengajukan sesi opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSetujui_Click(object? sender, EventArgs e)
        {
            if (peran != "admin")
            {
                MessageBox.Show("Hanya Admin yang berwenang menyetujui sesi opname.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int produkSelisih = sesi.Items.Count(i => i.Selisih != 0);

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menyetujui seluruh sesi Stok Opname {sesi.Id}?\n\n" +
                $"• Total Produk Diperiksa: {sesi.Items.Count}\n" +
                $"• Produk yang Mengalami Penyesuaian Stok: {produkSelisih}\n\n" +
                "PENTING: Seluruh penyesuaian stok akan diterapkan secara permanen ke inventaris dan dicatat pada Kartu Stok masing-masing produk.",
                "Konfirmasi Persetujuan Seluruh Sesi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes)
            {
                return;
            }

            try
            {
                PenyimpananData.TerapkanPersetujuanOpname(sesi.Id, Navigasi.PenggunaAktif);

                // Muat ulang sesi yang sudah disetujui
                var daftar = PenyimpananData.BacaSesiOpname();
                sesi = daftar.First(s => s.Id.Equals(sesi.Id, StringComparison.OrdinalIgnoreCase));

                isDataDiubah = false;
                PerbaruiTampilanHeader();
                SesuaikanHakAksesDanStatus();
                MuatTabelDetail();

                MessageBox.Show(
                    $"Sesi opname {sesi.Id} berhasil disetujui!\nPenyesuaian stok telah sukses diterapkan ke sistem dan dicatat pada Kartu Stok.",
                    "Opname Berhasil Diterapkan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyetujui sesi opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMintaRevisi_Click(object? sender, EventArgs e)
        {
            if (peran != "admin")
            {
                MessageBox.Show("Hanya Admin yang berwenang meminta revisi opname.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using FormMintaRevisi formRevisi = new FormMintaRevisi(sesi);
            if (formRevisi.ShowDialog(this) == DialogResult.OK && formRevisi.HasilRevisi.Count > 0)
            {
                try
                {
                    DateTime waktuRevisi = DateTime.Now;

                    foreach (var item in sesi.Items)
                    {
                        var rev = formRevisi.HasilRevisi.FirstOrDefault(r => r.KodeBarang == item.KodeBarang);
                        if (rev != null)
                        {
                            item.PerluRevisi = true;
                            item.AlasanRevisi = rev.AlasanRevisi;
                            item.StokFisikSebelumRevisi = item.StokFisik;

                            sesi.RiwayatRevisi.Add(new RiwayatRevisiOpname
                            {
                                Tanggal = waktuRevisi,
                                DimintaOleh = Navigasi.PenggunaAktif,
                                KodeBarang = item.KodeBarang,
                                NamaBarang = item.NamaBarang,
                                StokSistem = item.StokSistem,
                                StokFisikLama = item.StokFisik ?? 0,
                                SelisihLama = item.Selisih,
                                AlasanRevisi = rev.AlasanRevisi
                            });
                        }
                        else
                        {
                            item.PerluRevisi = false;
                        }
                    }

                    sesi.Status = "Perlu Revisi";
                    sesi.RiwayatStatus.Add(new RiwayatStatusOpname
                    {
                        Waktu = waktuRevisi,
                        Status = "Perlu Revisi",
                        Oleh = Navigasi.PenggunaAktif,
                        Catatan = $"Admin meminta revisi pada {formRevisi.HasilRevisi.Count} produk."
                    });

                    PenyimpananData.SimpanAtauPerbaruiSesiOpname(sesi);
                    PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Stok Opname", $"Meminta revisi sesi opname {sesi.Id} untuk {formRevisi.HasilRevisi.Count} produk.");

                    isDataDiubah = false;
                    PerbaruiTampilanHeader();
                    SesuaikanHakAksesDanStatus();
                    MuatTabelDetail();

                    MessageBox.Show(
                        $"Permintaan revisi berhasil dikirim kepada Petugas Gudang untuk {formRevisi.HasilRevisi.Count} produk.",
                        "Revisi Dikirim",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memproses permintaan revisi: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBatalkan_Click(object? sender, EventArgs e)
        {
            using FormBatalkanOpname formBatal = new FormBatalkanOpname(sesi.Id);
            if (formBatal.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    PenyimpananData.BatalkanSesiOpname(sesi.Id, Navigasi.PenggunaAktif, formBatal.AlasanPembatalan);

                    var daftar = PenyimpananData.BacaSesiOpname();
                    sesi = daftar.First(s => s.Id.Equals(sesi.Id, StringComparison.OrdinalIgnoreCase));

                    isDataDiubah = false;
                    PerbaruiTampilanHeader();
                    SesuaikanHakAksesDanStatus();
                    MuatTabelDetail();

                    MessageBox.Show(
                        $"Sesi opname {sesi.Id} telah dibatalkan.\nStok sistem tidak mengalami perubahan dan penguncian stok telah dilepas.",
                        "Sesi Dibatalkan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membatalkan sesi opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnKembali.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}