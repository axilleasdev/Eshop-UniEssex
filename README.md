# EShop - Blazor E-commerce Application

## Setup Instructions

### Database Configuration

1. Create PostgreSQL database:
```bash
createdb eshop_db
```

2. Set database password:
```bash
psql -d eshop_db -c "ALTER USER your_username WITH PASSWORD 'your_password';"
```

3. Update `appsettings.Development.json` with your credentials:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=eshop_db;Username=your_username;Password=your_password"
  }
}
```

### Run Migrations

```bash
dotnet ef database update
```

### Run Application

```bash
dotnet run
```

### Default Admin Credentials

- Username: `admin`
- Password: `admin123`

## Features

- Admin authentication
- Product CRUD operations
- Customer product catalog
- Shopping cart functionality
