# 🎓 Student Management Microservice

A .NET 8 microservice with full CRUD REST API (in-memory database) + a standalone HTML/JS frontend.

---

## 📁 Project Structure

```
StudentMS/
├── StudentAPI/             ← .NET 8 Web API (Microservice)
│   ├── Controllers/
│   │   └── StudentsController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Models/
│   │   └── Student.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── StudentAPI.csproj
├── frontend/
│   └── index.html          ← Standalone HTML frontend
└── README.md
```

---

## ✅ Prerequisites

Make sure the following are installed on your machine:

1. **.NET 8 SDK** — Download from https://dotnet.microsoft.com/download/dotnet/8.0
   - Verify: `dotnet --version` (should show 8.x.x)

2. **A modern web browser** (Chrome, Firefox, Edge)

---

## 🚀 Step-by-Step Instructions

### Step 1 — Extract the ZIP

Unzip the file to any folder on your machine, e.g.:
```
C:\Projects\StudentMS\    (Windows)
~/Projects/StudentMS/     (Mac/Linux)
```

---

### Step 2 — Run the .NET API

Open a terminal / command prompt and navigate to the `StudentAPI` folder:

**Windows:**
```cmd
cd C:\Projects\StudentMS\StudentAPI
dotnet run
```

**Mac / Linux:**
```bash
cd ~/Projects/StudentMS/StudentAPI
dotnet run
```

You should see output like:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
```

> ⚠️ The first run may take a minute while NuGet packages are downloaded.

> ✅ The API is now running on **http://localhost:5000**

---

### Step 3 — Open the Frontend

Open your file explorer and navigate to the `frontend/` folder.

**Double-click `index.html`** to open it in your browser.

OR drag and drop the file into your browser window.

> ✅ The frontend will load and automatically connect to the API on port 5000.

---

### Step 4 — Use the Application

- **View Students** — All students are listed in the table (3 pre-seeded students)
- **Add Student** — Click "+ Add Student" button
- **Edit Student** — Click the ✏️ Edit button on any row
- **Delete Student** — Click the 🗑️ Delete button on any row

---

## 📋 API Endpoints

Base URL: `http://localhost:5000`

| Method | Endpoint              | Description           |
|--------|-----------------------|-----------------------|
| GET    | /api/students         | Get all students      |
| GET    | /api/students/{id}    | Get student by ID     |
| POST   | /api/students         | Create new student    |
| PUT    | /api/students/{id}    | Update student        |
| DELETE | /api/students/{id}    | Delete student        |

### Swagger UI (Interactive API Docs)

Open: **http://localhost:5000/swagger**

This gives you an interactive UI to test all API endpoints directly in the browser.

---

## 📦 Sample Request Body (POST / PUT)

```json
{
  "id": 0,
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "age": 21,
  "course": "Computer Science"
}
```

---

## ❓ Troubleshooting

| Problem | Solution |
|---------|----------|
| `dotnet: command not found` | Install .NET 8 SDK from microsoft.com/dotnet |
| Port 5000 already in use | Change `"Urls": "http://localhost:5001"` in `appsettings.json` and update the `API` variable in `frontend/index.html` |
| Frontend shows "API offline" | Make sure `dotnet run` is still running in the terminal |
| CORS error in browser | The API already has CORS enabled for all origins — try refreshing |

---

## 🗒️ Notes

- The database is **in-memory** — all data is reset when the API restarts.
- 3 sample students are pre-seeded on startup.
- No Docker or additional services required.
