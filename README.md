# 📱 MOBILUX – Mobile Furniture Payment Tracker

MOBILUX is a cross-platform mobile application developed as an academic project for the **Mobile Application Development** course. It provides clients with a clear, structured tool to track financed furniture purchases — managing outstanding balances, payment history, and financial status, independently from the retailer.

---

## 🎯 Project Objective

Provide a mobile tool that enables users to:

- Register financed furniture purchases with realistic financial conditions
- Record installment payments and extraordinary payments
- Monitor outstanding balances and payment status in real time
- View consolidated reports of all active purchases
- Receive automatic email notifications on purchases and payments
- Manage their profile and email preferences

---

## ✅ Core Features

- **User Authentication** — Secure login and registration via Supabase Auth
- **Password Recovery** — OTP-based recovery flow via Brevo email API
- **Purchase Management** — Register furniture purchases with price, down payment, term, and interest rate
- **Payment Registration** — Record payments with automatic balance updates
- **Financial Queries** — Remaining balance, completed payments, estimated completion date
- **Reports** — Summary view of all active purchases
- **Email Notifications** — Automatic emails on purchase and payment registration via Brevo
- **Profile Management** — Edit personal info, primary and secondary email

---

## 🏗️ Architecture

MOBILUX uses a **layered architecture**:

```
┌─────────────────────────────────────┐
│         .NET MAUI (C# / XAML)       │  ← Cross-platform UI (Android / iOS / Windows)
├─────────────────────────────────────┤
│            Services Layer           │  ← SupabaseService, PurchaseService,
│                                     │     MuebleService, NotificationService,
│                                     │     CompraItemService
├─────────────────────────────────────┤
│         Supabase (Backend)          │  ← PostgreSQL + Auth + REST API
│   auth.users → tb_usuario           │
│   → cliente, correo, compra,        │
│     abono, saldo, mueble, etc.      │
├─────────────────────────────────────┤
│         Brevo (Email API)           │  ← Transactional email notifications
└─────────────────────────────────────┘
```

### Key architectural decisions

- **Registration flow** uses raw HTTP calls to Supabase REST API + a `SECURITY DEFINER` PostgreSQL function (`registrar_usuario`) to bypass RLS during multi-table inserts
- **Notifications** use Brevo's transactional email API directly from the app
- **Password recovery** generates a local OTP code, sends it via Brevo, and updates the password via Supabase Admin API — fully independent from Supabase's email system
- **RLS (Row-Level Security)** enforces data isolation so each user only sees their own data

---

## 🗄️ Database Schema

Designed in PostgreSQL (hosted on Supabase). Key tables:

| Table | Description |
|---|---|
| `auth.users` | Managed by Supabase Auth |
| `tb_usuario` | Links auth.users to app roles |
| `correo` | Email addresses |
| `usuario_correo` | User ↔ email relationship (primary/secondary) |
| `cliente` | Client profile (name, ID, phone, birthdate) |
| `mueble` | Furniture catalog |
| `mueble_proveedor` | Furniture ↔ supplier relationship |
| `mueble_precio` | Pricing history per furniture/supplier |
| `proveedor` | Supplier information |
| `compra` | Purchase records |
| `compra_item` | Line items per purchase |
| `abono` | Payment records |
| `saldo` | Outstanding balance per purchase |
| `producto_imagen` | Furniture images (Storage URLs) |
| `area` / `subarea` | Furniture categories |

---

## 🖥️ Application Screens

| # | Screen |
|---|---|
| 1 | Loading Screen |
| 2 | Login |
| 3 | Register |
| 4 | Password Recovery |
| 5 | Dashboard |
| 6 | Purchase List |
| 7 | Purchase Detail |
| 8 | New Purchase Registration |
| 9 | Payment Registration |
| 10 | Reports |
| 11 | Report Preview |
| 12 | Client Profile |
| 13 | Help / About |

---

## 🛠️ Tech Stack

| Component | Technology |
|---|---|
| Language | C# |
| Framework | .NET MAUI 10 |
| Backend / Database | Supabase (PostgreSQL + Auth + Storage) |
| Email Notifications | Brevo Transactional Email API |
| Target Platforms | Android / iOS / Windows |
| IDE | Visual Studio 2022+ |

### NuGet Packages

- `Supabase` v1.1.1
- `Microsoft.Maui.Controls` v10.0.50
- `Microsoft.Extensions.Logging.Debug` v10.0.5

---

## ⚙️ Setup & Configuration

### Prerequisites

- Visual Studio 2022 or later with .NET MAUI workload installed
- A Supabase project (free tier works)
- A Brevo account (free tier works)
- Android emulator or physical device for testing

### 1. Clone the repository

```bash
git clone https://github.com/your-username/MOBILUX.git
cd MOBILUX
```

### 2. Configure secrets

This project uses API keys that are **not included in the repository**. You need to add them manually.

Create or update the following constants in each file:

**`Services/SupabaseService.cs`**
```csharp
private const string Url     = "https://YOUR_PROJECT_ID.supabase.co";
private const string AnonKey = "YOUR_SUPABASE_ANON_KEY";
```

**`Pages/RegisterPage.xaml.cs`**
```csharp
private const string SupabaseUrl = "https://YOUR_PROJECT_ID.supabase.co";
private const string AnonKey     = "YOUR_SUPABASE_ANON_KEY";
```

**`Pages/PasswordUserRecovery.xaml.cs`**
```csharp
private const string BrevoApiKey    = "YOUR_BREVO_API_KEY";
private const string ServiceRoleKey = "YOUR_SUPABASE_SERVICE_ROLE_KEY";
```

**`Services/NotificationService.cs`**
```csharp
private const string SenderEmail = "YOUR_VERIFIED_SENDER_EMAIL";
private const string BrevoApiKey = "YOUR_BREVO_API_KEY";
```

> ⚠️ **Never commit real API keys to GitHub.** Keep them local only.

### 3. Set up the Supabase database

Run the SQL scripts in this order in your Supabase SQL Editor:

1. `Database/Script_Mobilux_Supabase.sql` — creates all tables and indexes
2. `Database/RLS_Policies.sql` — sets up Row-Level Security policies
3. `Database/Storage_Policies.sql` — sets up Storage bucket policies
4. `Database/Functions.sql` — creates the `registrar_usuario` SECURITY DEFINER function

### 4. Run the project

Open `MOBILUX.sln` in Visual Studio, select your target platform (Android recommended for testing), and press **Run**.

---

## 🔐 Security Notes

- All sensitive keys (Supabase anon key, service role key, Brevo API key) are stored as constants in the source code for this academic project. In a production app, these should be stored in environment variables or a secrets manager.
- The `service_role` key used in password recovery has admin privileges — in production this should be handled by a backend Edge Function, never exposed in a client app.
- RLS policies ensure each user can only read and modify their own data.

---

## 🎨 Visual Design

- Custom branding: logo, color palette (`Brown50`–`Brown900`), app icon, splash screen
- No default MAUI templates or plain white backgrounds
- Consistent card-based layout across all screens
- Responsive design supporting Phone, Tablet, and Desktop idioms

---

## 👥 Team

| Role | Contributor |
|---|---|
| Technical & Administrative Lead, DB Architecture, Requirements, Branding, QA | Javier Núñez |
| Final functionality, UI polish, key features | Mauricio |
| Team members | Full team |

---

## 📚 Academic Context

This project was developed as part of the **Mobile Application Development** course and is intended **exclusively for academic purposes**. Any commercial brands or products referenced are used solely for illustrative purposes to simulate realistic financing scenarios.

---

## 📄 License

This project is for academic use only. All rights reserved by the authors.
