<p align="center">
<img src="https://github.com/TanmayArya-1p/blob/blob/main/tastetailor/segfaulticon.png?raw=true" width=80></img>
</p>

# TasteTailor — Backend

Backend for **TasteTailor**, a recipe recommendation mobile app built by team `Segmentation Fault` at [hack8all 2024](https://hack8all.in) in 36 hours.

The app recommends recipes based on ingredients you have on hand, dietary preferences, and cuisine type — powered by an ASP.NET Core REST API backed by MongoDB.

## Tech Stack

- **Runtime**: .NET 8 / ASP.NET Core
- **Database**: MongoDB
- **API Docs**: Swagger / OpenAPI

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- A MongoDB instance (local or Atlas)

### Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/gqvz/SegFault.Backend
   cd SegFault.Backend
   ```

2. Set your MongoDB connection string as an environment variable:
   ```sh
   # Linux / macOS
   export MONGODB_CONNECTION_URI="your-mongodb-connection-string"

   # Windows
   set MONGODB_CONNECTION_URI="your-mongodb-connection-string"
   ```

3. Build and run:
   ```sh
   dotnet run --project SegFault.Backend
   ```

### API Documentation

Import [`swagger.json`](./SegFault.Backend/swagger.json) into [Swagger Editor](https://editor-next.swagger.io/) to explore all endpoints and schemas.

## Notes

Built under hackathon conditions (36 hours). Some security checks are intentionally skipped to meet the deadline — not production-ready.

## Team

Built by team **Segmentation Fault** — Garvit Sharma, Tanmay Arya, and teammates.
