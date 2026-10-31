# SUKIMART - Aplikasi POS, Pergudangan & Kasir (Visual Studio 2026 C# WinForms)

Proyek ini telah direvisi secara menyeluruh sesuai dengan seluruh catatan dan kebutuhan pembelajaran Anda:

---

## 1. Perubahan & Revisi yang Telah Diterapkan

1. **Formulir "Riwayat Transaksi" Utuh (`riwayattransaksi.cs`)**:
   - Seluruh fitur riwayat transaksi kini berada dalam **satu formulir utuh** (`riwayattransaksi.cs` / `riwayattransaksi.Designer.cs`).
   - Tidak ada lagi pemisahan menu "riwayat" dan "transaksi".
   - Di dalamnya langsung tersedia: filter pencarian nomor faktur / nama kasir, filter rentang tanggal, kartu ringkasan omzet & total transaksi, tabel daftar transaksi kasir, serta tabel rincian item barang per faktur yang dipilih.

2. **Panel Kanan Tampil Penuh di Visual Studio Designer**:
   - Sebelumnya panel kanan (`pnlKanan`) tampil kosong di tab `[Design]` karena kontrol-kontrol dibuat secara dinamis di runtime C#.
   - Sekarang, **seluruh kontrol UI** (tombol, label, tabel `DataGridView`, kotak pencarian, panel kartu) telah didefinisikan dan ditata langsung di dalam metode `InitializeComponent()` pada masing-masing file `*.Designer.cs`.
   - Hasilnya, saat Anda membuka `katalog.cs [Design]`, `kasir.cs [Design]`, `riwayattransaksi.cs [Design]`, `gudang.cs [Design]`, maupun `laporan.cs [Design]` di Visual Studio 2026, tampilannya langsung muncul lengkap dan seragam dengan `dashboardadmin` dan `dashboardkasir`.

3. **Standarisasi Penamaan File C# (Huruf Kecil & Tanpa Awalan "Form")**:
   - Semua file C# telah disesuaikan agar konsisten dengan gaya awal buatan Anda (`dashboardadmin.cs`):
     - `login.cs` & `login.Designer.cs` (Class `FormLogin`)
     - `dashboardadmin.cs` & `dashboardadmin.Designer.cs` (Class `FormDashboardAdmin`)
     - `dashboardkasir.cs` & `dashboardkasir.Designer.cs` (Class `FormDashboardKasir`)
     - `katalog.cs` & `katalog.Designer.cs` (Class `FormKatalog`)
     - `kasir.cs` & `kasir.Designer.cs` (Class `FormKasir`, dilengkapi alias kompatibilitas `FormTransaksi`)
     - `riwayattransaksi.cs` & `riwayattransaksi.Designer.cs` (Class `FormRiwayatTransaksi`, dilengkapi alias kompatibilitas `FormRiwayat`)
     - `gudang.cs` & `gudang.Designer.cs` (Class `FormGudang`)
     - `laporan.cs` & `laporan.Designer.cs` (Class `FormLaporan`)
   - Semua file lama berawalan `Form*.cs` telah dihapus sehingga tidak ada duplikasi atau kebingungan namespace (Error CS0246 tuntas 100%).

4. **Penyimpanan Data Berbasis JSON Sesuai Arahan Guru**:
   - Semua transaksi, data produk, dan detail item disimpan dan dibaca secara persisten dalam format JSON:
     - `Sukimart/Data/barang.json`
     - `Sukimart/Data/transaksi.json`
     - `Sukimart/Data/detail_transaksi.json`
   - Dikelola dengan aman melalui `PenyimpananData.cs` menggunakan library resmi `System.Text.Json`.

---

## 2. Cara Membuka & Menjalankan di Visual Studio 2026

1. Ekstrak file zip ini ke folder komputer Anda (misalnya `C:\Users\bajomes\source\repos\Sukimart`).
2. Buka folder dan klik dua kali file **`Sukimart.slnx`** atau **`Sukimart.sln`**.
3. Di Visual Studio 2026:
   - Klik menu **Build** > **Rebuild Solution** (Ctrl + Shift + B).
   - Pastikan status pada Error List: **0 Errors**.
4. Tekan **F5** atau klik tombol hijau **Start (Debug)** untuk menjalankan aplikasi.

---

## 3. Akun Login Demo

- **Admin**:
  - Username: `admin`
  - Password: `admin123`
  - Akses: Dashboard Admin, Kasir / POS, Katalog Produk, Riwayat Transaksi, Gudang, Laporan.
- **Kasir**:
  - Username: `kasir`
  - Password: `kasir123`
  - Akses: Dashboard Kasir, Kasir / POS, Katalog Produk, Riwayat Transaksi.
