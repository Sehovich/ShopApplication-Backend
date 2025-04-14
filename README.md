# 🧠 Perfume Store Backend (.NET)

This is the ASP.NET Core backend for the **Perfume Store** e-commerce application. It powers all core features including product management, user authentication, basket handling, and favorites.

---

## 🚀 Getting Started

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (LocalDB, Express, or full version)
- [EF Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (optional for manual migrations)

### 📦 Installation & Run

1. Clone the repository:

```bash
git clone https://github.com/your-username/perfume-store-backend.git
cd perfume-store-backend

✅ Features Implemented
🛒 Basket API
Add to basket

Remove from basket

Update quantity

Get basket items with product details

Auto-merge quantities for the same product

❤️ Favorites API
Add/remove favorite products per user

Fetch all favorite product IDs

Fetch detailed favorite product list

📦 Products API
Paginated product list (/api/products?page=1&pageSize=8)

Total count returned in response

Get product by ID

Server-side sorting (can be extended easily)

👤 Authentication
Token-based auth using JWT

Login/Register endpoints

User identity stored in JWT claims

Middleware verifies and injects authenticated user

🔧 Architecture
Clean Architecture principles

Projects: Application, Infrastructure, Domain, Api

Business logic inside Application layer

Controllers are thin – only handle HTTP/DTO mapping

Uses MediatR for CQRS-based request handling

🛠 Tech Stack
ASP.NET Core 8

Entity Framework Core 8

MediatR

SQL Server

JWT Authentication

Clean Architecture
