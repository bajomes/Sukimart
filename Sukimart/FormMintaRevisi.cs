using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormMintaRevisi : Form
    {
        public class ItemRevisiPilihan
        {
            public string KodeBarang { get; set; } = "";
            public string NamaBarang { get; set; } = "";
            public string AlasanRevisi { get; set; } = "";
        }

        public List<ItemRevisiPilihan> HasilRevisi { get; private set; } = new List<ItemRevisiPilihan>();

        public FormMintaRevisi(SesiOpname sesi)
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);

            lblJudul.Text = $"Permintaan Revisi Opname • {sesi.Id}";

            UIHelper.RatakanTengah(colStokSistem, colStokFisik, colSelisih);

            MuatItem(sesi.Items);

            btnBatal.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            btnKirim.Click += (s, e) => KirimRevisi();
        }

        private void MuatItem(List<ItemOpname> items)
        {
            gridRevisi.Rows.Clear();
            foreach (var item in items)
            {
                int rowIndex = gridRevisi.Rows.Add(
                    item.PerluRevisi,
                    item.KodeBarang,
                    item.NamaBarang,
                    item.StokSistem,
                    item.StokFisik.HasValue ? item.StokFisik.Value.ToString() : "-",
                    (item.Selisih > 0 ? "+" : "") + item.Selisih.ToString(),
                    item.AlasanRevisi
                );

                if (item.Selisih != 0)
                {
                    gridRevisi.Rows[rowIndex].Cells[colSelisih.Index].Style.ForeColor = item.Selisih > 0
                        ? UIHelper.WarnaStatusAman
                        : UIHelper.WarnaStatusHabis;
                }
            }
        }

        private void KirimRevisi()
        {
            gridRevisi.EndEdit();

            List<ItemRevisiPilihan> pilihan = new List<ItemRevisiPilihan>();

            for (int i = 0; i < gridRevisi.Rows.Count; i++)
            {
                DataGridViewRow row = gridRevisi.Rows[i];
                bool isChecked = Convert.ToBoolean(row.Cells[colPilih.Index].Value ?? false);

                if (isChecked)
                {
                    string kode = row.Cells[colKode.Index].Value?.ToString() ?? "";
                    string nama = row.Cells[colNama.Index].Value?.ToString() ?? "";
                    string alasan = row.Cells[colAlasan.Index].Value?.ToString()?.Trim() ?? "";

                    if (string.IsNullOrWhiteSpace(alasan))
                    {
                        MessageBox.Show(
                            $"Produk '{nama}' ({kode}) telah dicentang, tetapi alasan revisi belum diisi.\nSetiap produk yang diminta revisi wajib menyertakan alasan.",
                            "Alasan Revisi Wajib Diisi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        gridRevisi.CurrentCell = row.Cells[colAlasan.Index];
                        gridRevisi.BeginEdit(true);
                        return;
                    }

                    pilihan.Add(new ItemRevisiPilihan
                    {
                        KodeBarang = kode,
                        NamaBarang = nama,
                        AlasanRevisi = alasan
                    });
                }
            }

            if (pilihan.Count == 0)
            {
                MessageBox.Show(
                    "Pilih minimal 1 produk yang perlu direvisi oleh Gudang.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                $"Kirim permintaan revisi untuk {pilihan.Count} produk ke Petugas Gudang?\nStatus sesi opname akan berubah menjadi 'Perlu Revisi'.",
                "Konfirmasi Permintaan Revisi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                HasilRevisi = pilihan;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}