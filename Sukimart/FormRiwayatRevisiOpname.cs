using System;
using System.Globalization;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormRiwayatRevisiOpname : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormRiwayatRevisiOpname(SesiOpname sesi)
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);

            lblJudul.Text = $"Riwayat Revisi & Status • {sesi.Id}";
            lblSubJudul.Text = $"Pembuat: {sesi.DibuatOleh} · Dibuat: {sesi.TanggalDibuat:dd/MM/yyyy HH:mm} · Status: {sesi.Status}";

            UIHelper.RatakanTengah(colRevFisikLama, colRevFisikBaru, colTimeStatus);

            MuatData(sesi);

            btnTutup.Click += (s, e) => Close();
        }

        private void MuatData(SesiOpname sesi)
        {
            // 1. Tab Revisi Produk
            gridRevisi.Rows.Clear();
            if (sesi.RiwayatRevisi != null)
            {
                foreach (var r in sesi.RiwayatRevisi)
                {
                    gridRevisi.Rows.Add(
                        r.Tanggal.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia),
                        r.DimintaOleh,
                        $"{r.KodeBarang} - {r.NamaBarang}",
                        r.StokFisikLama,
                        r.AlasanRevisi,
                        r.StokFisikBaru.HasValue ? r.StokFisikBaru.Value.ToString() : "(Belum diperbaiki)",
                        r.TanggalDiperbaiki.HasValue ? $"{r.TanggalDiperbaiki.Value:dd/MM/yyyy HH:mm} ({r.DiperbaikiOleh})" : "-"
                    );
                }
            }

            // 2. Tab Timeline Status
            gridTimeline.Rows.Clear();
            if (sesi.RiwayatStatus != null)
            {
                foreach (var t in sesi.RiwayatStatus)
                {
                    gridTimeline.Rows.Add(
                        t.Waktu.ToString("dd/MM/yyyy HH:mm:ss", BudayaIndonesia),
                        t.Status,
                        t.Oleh,
                        t.Catatan
                    );
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}