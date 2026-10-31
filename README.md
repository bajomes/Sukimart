# Sukimart

Sukimart is a desktop Point of Sale (POS) and warehouse inventory management application built with C# and Windows Forms on .NET 10. The application manages sales checkout, stock level monitoring, inventory restocking, role-based access control, transaction auditing, and business performance reporting. Operational data is stored locally in persistent JSON format without external database dependencies.

## Quick start

### Prerequisites
- Windows 10 or 11
- Visual Studio 2022 / 2026 (with .NET desktop development workload) or [.NET 10 SDK](https://dotnet.microsoft.com/)

### Running from Visual Studio
1. Clone the repository:
   ```bash
   git clone https://github.com/bajomes/Sukimart.git
   ```
2. Open `Sukimart.sln` or `Sukimart.slnx` in Visual Studio.
3. Build the solution via **Build > Rebuild Solution** (`Ctrl + Shift + B`) and verify `0 Errors`.
4. Press `F5` to start debugging.

### Running from .NET CLI
```bash
git clone https://github.com/bajomes/Sukimart.git
cd Sukimart
dotnet build
dotnet run --project Sukimart/Sukimart.csproj
```

## Current capabilities

- **Role-based Authentication**: Secure dual-role login distinguishing administrative privileges from cashier operations.
- **Point of Sale (POS) Cashier**: Product selection with instant stock availability checks, dynamic cart quantity management, automated subtotal and total calculations, cash payment handling with change computation, automatic inventory reduction, and printed receipt generation.
- **Product Catalog Management**: Complete CRUD operations (Create, Read, Update, Delete) for store merchandise with category grouping, formatted price display, unique SKU code enforcement, and instant keyword search.
- **Warehouse & Stock Management**: Inventory tracking with real-time stock thresholds, low-stock alerts, and fast inbound restock replenishment.
- **Transaction History & Ledger**: Complete sales audit log with custom date-range filters, invoice/cashier search, revenue summary metrics, and itemized invoice details.
- **Sales Analytics & Reporting**: Business reports categorized by period (Today, This Month, All Time) calculating total revenue, transaction counts, sold items, and average ticket size.
- **Modern Borderless Interface**: Frameless window aesthetic with smooth native window dragging (`WM_NCLBUTTONDOWN`) and unified brand-aligned DataGridView selection themes.

## Demo accounts

The system includes pre-configured demo credentials:

| Role | Username | Password | Access Scope |
|---|---|---|---|
| **Administrator** | `admin` | `admin123` | Dashboard Admin, POS / Kasir, Katalog Produk, Riwayat Transaksi, Gudang, Laporan |
| **Kasir** | `kasir` | `kasir123` | Dashboard Kasir, POS / Kasir, Katalog Produk (Read-Only), Riwayat Transaksi |

## Architecture and data storage

Data persistence is handled through `System.Text.Json` using an atomic write pattern:

- **Storage Location**: `%LOCALAPPDATA%\Sukimart\Data\` (automatically seeded from `Sukimart/Data/` on first execution).
- **Data Collections**:
  - `barang.json`: Merchandise registry containing SKU, name, category, unit price, current stock, and safety stock threshold.
  - `transaksi.json`: Master transaction ledger tracking invoice numbers, timestamps, cashier usernames, total amounts, cash tendered, and change returned.
  - `detail_transaksi.json`: Normalized itemized transaction records mapped to their corresponding invoice ID.
- **Atomic File Operations**: Data is serialized to a temporary file (`.tmp`) before replacing the target file, ensuring zero data corruption during power interruptions or unexpected process terminations.
- **Designer Stability**: Form lifecycle and UI enhancements use modular static helper functions (`UIHelper`) rather than complex form inheritance, ensuring complete compatibility with the Visual Studio out-of-process WinForms Designer.

## Project structure

```text
Bajomart/
├── Sukimart.sln               # Solution file
├── Sukimart.slnx              # Modern solution descriptor
└── Sukimart/
    ├── Data/                  # Seed JSON datasets
    ├── Properties/            # Assembly resources
    ├── Resources/             # Application logos and icons
    ├── Models.cs              # Domain entities (Barang, Transaksi, DetailTransaksi)
    ├── PenyimpananData.cs     # Persistence engine & JSON serializer
    ├── Navigasi.cs            # Session controller & navigation router
    ├── UIHelper.cs            # Borderless drag and table styling helper
    ├── login.cs               # Authentication form
    ├── dashboardadmin.cs      # Administrative dashboard
    ├── dashboardkasir.cs      # Cashier overview dashboard
    ├── kasir.cs               # Point of Sale (POS) cashier form
    ├── katalog.cs             # Product catalog CRUD form
    ├── gudang.cs              # Warehouse & stock replenishment form
    ├── laporan.cs             # Sales performance reporting form
    └── riwayattransaksi.cs    # Transaction history & ledger form
```

## License

Distributed under the MIT License. See `LICENSE` for more information.
