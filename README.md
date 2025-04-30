# Company Data Merger

A C#/.NET 8 console application that merges company records from three different data sources (CSV and JSON), applies deduplication, data standardization, and saves the clean dataset into a MariaDB relational database.

---

## 🧾 Assignment Overview

This solution addresses the following requirements:

- Merge 3 data sources of company records (1 CSV, 2 JSON)
- Remove duplicates based on key fields: **Domain**, LinkedIn URL, LinkedIn ID, Name
- Respect **source priority** (lower number = higher priority)
  - Source 1: Priority 10
  - Source 2: Priority 20
  - Source 3: Priority 30
- Ensure **all final records have a Domain**
- Include and standardize core fields:
  - Industry
  - Company Size
  - Country
  - Location

---

## 🏗 Project Structure

```
CompanyDataMerger/
│
├── CompanyDataMerger.ConsoleApp/     --> Startup Console project
├── CompanyDataMerger.Application/    --> Core business logic
├── CompanyDataMerger.Domain/         --> Entities and interfaces
├── CompanyDataMerger.Infrastructure/ --> EF DbContext, Repositories, Readers
```

---

## ⚙️ How to Run

> ✅ Prerequisites:
>
> - .NET 8 SDK
> - MariaDB running locally (configured in `appsettings.json`)

1. **Clone the project**

   ```bash
   git clone https://github.com/IvanVelinov/CompanyDataMerger
   ```

2. **Configure DB connection**
   Edit `appsettings.json` in `ConsoleApp`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;port=3306;user=your_user;password=your_password;database=company_merge"
     }
   }
   ```

3. **Apply migrations**

   ```bash
   dotnet ef migrations add InitialCreate -s CompanyDataMerger.ConsoleApp -p CompanyDataMerger.Infrastructure
   dotnet ef database update -s CompanyDataMerger.ConsoleApp -p CompanyDataMerger.Infrastructure
   ```

4. **Place your input files**
   Place:

   - `source1.csv`
   - `source2.json`
   - `source3.json`

   Inside a known folder and update the paths in `Program.cs` or use config-based loading.

5. **Run the project**
   ```bash
   dotnet run --project CompanyDataMerger.ConsoleApp
   ```

---

## 🧠 Key Concepts Used

| Concept               | Details                                                            |
| --------------------- | ------------------------------------------------------------------ |
| Clean Architecture    | Separation between Domain, Application, Infrastructure, and UI     |
| Entity Framework Core | Used with Pomelo provider for MariaDB                              |
| Dependency Injection  | Manual DI in Console App using ServiceCollection                   |
| Logging               | Serilog for structured logging and diagnostics                     |
| Data Standardization  | Custom logic for cleaning Industries, Company Size, Country        |
| Deduplication Logic   | Domain-based keying + source priority comparison + field merging   |
| Robust Validation     | Skips entries with missing Domain, malformed size, or invalid data |

---

## 📦 Example Features Implemented

- Skips companies without domains
- Deduplicates based on domain and source priority
- Normalizes:
  - Company sizes like `The51200`, `02-Oct`, `myself only`
  - PascalCase industries like `InformationTechnologyAndServices`
  - Country misspellings like `brasil`, `espanha`, etc.
- Logs skipped records with reasons
- Uses `AddRangeAsync` with no duplicate inserts

---

## 📁 Sample Output (MariaDB)

Final table `Companies` contains:

- 1 row per unique domain
- Highest-priority version
- Cleaned `Industry`, `CompanySize`, `Country`, `Location`
- Logged merge history for traceability

---

