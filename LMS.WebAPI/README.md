# 🚀 Detailed Steps to Setup LMS Web API using GitHub Copilot Agent (Simplified)

## 1️⃣ Create New LMS Web API Project

**Prompt to Copilot Agent:**

```plaintext
Set up a boilerplate .NET 8 Web API project for a Learning Management System (LMS) with:
Include folders:
- Entities
- Data (DbContext)
- Repositories
- Services
- Controllers
- Middleware
Setup Swagger UI.
Enable Nullable Reference Types.
Make sure to configure Program.cs file properly with all dependencies.

```

---

## 2️⃣ Install Required NuGet Packages

Install the following NuGet packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore
- Serilog.AspNetCore (for logging)

Important Instructions for Packages:
-Only install packages from the public NuGet.org feed (https://api.nuget.org/v3/index.json).
-Prefer dotnet add package commands targeting only nuget.org explicitly.
-Ensure that all dependencies are installed from NuGet public feed.
-Create a NuGet.config file at the solution root
```
```
---

## 3️⃣ Setup Database Connection (Let Copilot Decide)

**Prompt:**

```plaintext
Setup default MS SQL Server database connection string for Entity Framework Core.
- Database name: LMSDb
- Server: Localhost
- User Id: sa
- Password: 123
- Trusted Connection: True
- Trust Server Certificate: True
Configure it in appsettings.json and register DbContext in Program.cs.
```

---

## 4️⃣ Create DbContext and Entities

**Prompt:**

```plaintext
Create LMSDbContext class:
- Inherit from DbContext
- Add DbSets for Course, Quiz, User

Create entities:
- Course (Id, Name, Description)
- Quiz (Id, Title, CourseId)
- User (Id, Username, PasswordHash, Role)
Use DataAnnotations like [Required] and [MaxLength].
Change DB context to new LMSDbContext in program file
---
```
## 5️⃣ Create Initial Migration & SQL Script

**Prompt:**

```plaintext
Create first EF Core migration "InitialCreate".
Update the database locally.
Generate SQL Script and save it inside /DatabaseScripts folder.
- Include: Database creation, Table creation, Initial dummy data insertions (sample courses, quizzes, users).
```

✅ Commands Copilot will suggest:
- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`
- `dotnet ef migrations script -o ./DatabaseScripts/InitialDatabaseSetup.sql`

---

## 6️⃣ Create Repositories, Services, and Controllers

**Prompt:**

```plaintext
For each Entity (Course, Quiz, User):
- Create Repository Interface and Implementation.
- Create Service Interface and Implementation.
- Create REST Controller with basic CRUD endpoints.
Protect POST/PUT/DELETE endpoints using [Authorize] attribute.
Register Repositories and Services with Dependency Injection.
```

---

## 7️⃣ Setup Global Exception Handling Middleware

**Prompt:**

```plaintext
Create a GlobalExceptionMiddleware class.
- Catch unhandled exceptions
- Log error details using Serilog
- Return HTTP 500 with generic error message
Register middleware in Program.cs.
```

---

## 8️⃣ Setup JWT Authentication

**Prompt:**

```plaintext
Setup JWT Authentication:
- Add JWT settings in appsettings.json
- Configure JWT Bearer authentication in Program.cs
- Protect secured APIs with [Authorize] attribute
Optionally, create a simple authentication service for token generation
Ensure all required JWT packages are installed from NuGet
Apply authorization to all API routes
```

---

## 9️⃣ Configure Swagger UI for JWT Bearer

**Prompt:**

```plaintext
Configure Swagger to support JWT Bearer authentication.
- Add security definition and requirement in Swagger configuration.
Allow users to input Bearer tokens for protected APIs.
Add a UserController with a login endpoint that returns a JWT token upon successful user authentication.
```

---

## 🔥 Common Issues & How Copilot Can Fix

**Prompt:**

```plaintext
If any package or dependency not found:
- Run 'dotnet restore'
- Install missing NuGet packages manually
- Clean solution and rebuild
```

✅ Copilot can even guide you to fix if build fails!

---

# 📈 Final LMS Web API Flow:

```plaintext
Create Project ➔ Setup Database ➔ Create Entities ➔ Add Migrations ➔ Repositories ➔ Services ➔ Controllers ➔ Exception Handling ➔ JWT Authentication ➔ Swagger Setup
```

