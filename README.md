# Calendar Service

A .NET-based calendar service for managing events and schedules.

## Features

- Event management
- Schedule coordination
- Calendar synchronization
- RESTful API endpoints

## Prerequisites

- .NET 6.0 or later
- SQL Server (or your preferred database)
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository

```bash
git clone https://github.com/yourusername/dotnet-calendar-service.git
```

2. Navigate to the project directory

```bash
cd dotnet-calendar-service
```

3. Restore dependencies

```bash
dotnet restore
```

4. Run the application

```bash
dotnet run
```

## API Documentation

The API documentation is available at /swagger when running the application locally.

## Project Structure

```plaintext
├── src/
│   ├── CalendarService.API/       # API layer
│   ├── CalendarService.Core/      # Business logic
│   └── CalendarService.Data/      # Data access layer
├── tests/
│   └── CalendarService.Tests/     # Unit tests
└── README.md
```
