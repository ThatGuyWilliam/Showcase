# Showcase App (.NET 8 + AngularJS)

This is a simple CRUD-style web application built with .NET 8 and AngularJS 1.8.2. It allows users to:

- Create new showcases
- View all showcases
- Hide showcases (mark as hidden)

---

## 🛠 Technology Stack

- **Backend**: ASP.NET 8 (MVC)
- **Frontend**: AngularJS 1.8.2 & Razor
- **Database**: SQL Server (configured in `appsettings.json`)
- **ORM**: Entity Framework Core (with code-first migrations)

---

## ⚙️ Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-repo/showcase-app.git
   cd showcase-app
   ```

2. **Configure Database**
   - Open `appsettings.json`
   - Update the connection string in the `ConnectionStrings` section with your SQL Server details:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=IP/PC;Database=SkillShowcase;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
     }
     ```

3. **Apply EF Migrations**
   Ensure you have the .NET 8 SDK installed, then run:
   ```bash
   update-database
   ```

---

## 🧪 Features

- ✅ Create new showcase entries via AngularJS/Razor form
- ✅ Loads all existing showcases in a table
- ✅ Ability to hide a showcase with a single click (without deletion)
- ✅ Hidden items are marked and cannot be hidden again

---

## 📝 Notes

- All data interactions happen via AngularJS/Ajax calling ASP.NET controller methods.
- Hiding a showcase updates its `IsHidden` flag in the database.
- Migrations must be applied before running for the first time.

---

## 📁 Project Structure

```
/Controllers
    HomeController.cs
/BLL
    ShowcaseManager.cs
?DAL
    ShowcaseRepo.cs
/Data
    ApplicationDbContext.cs
/Models
    Showcase.cs
    Teams.cs
/Views
    /Home
        Index.cshtml
        Angular.cshtml
```
---

## 📌 Requirements

- .NET 8 SDK
- SQL Server (LocalDB or full instance)