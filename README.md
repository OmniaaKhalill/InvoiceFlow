# InvoiceFlow



# InvoiceFlow-API

Backend API for the InvoiceFlow system, built with ASP.NET Core. Manages invoice logic, cashiers, items, and branches.

## Tech Stack
- ASP.NET Core
- EF Core
- SQL Server
- Clean Architecture

## Project Structure

```
InvoiceFlow.API/
InvoiceFlow.Application/
InvoiceFlow.Domain/
InvoiceFlow.Infrastructure/
```
## Getting Started

### Prerequisites
- .NET SDK
- SQL Server

### Clone and Setup
```bash
git clone https://github.com/omniaakhalill/invoiceflow-api.git
cd invoiceflow-api
```

Set Connection String
In appsettings.Development.json:


"DefaultConnection": "Server=.;Database=InvoiceFlowDb;Trusted_Connection=True;"
###Database Setup

```
dotnet ef database update
```
#### Running the API
```
dotnet run --project InvoiceFlow.API
```
#### Visit Swagger at:
```
https://localhost:5001/swagger
```
### Features

- Duplicate item merging
- Total price calculation
- Clean architecture separation

### Author
Omnia Khalil
