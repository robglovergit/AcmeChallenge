# AcmeCorp API

The AcmeCorp API is a RESTful web service designed to manage customer data, contact information, and orders for Acme Corp. It's built with .NET Core and utilizes Entity Framework Core for data persistence.

## Features

- CRUD operations for managing Customers, Contact Information, and Orders.
- Authentication and authorization with API keys.
- Unit and Integration tests using xUnit.
- Docker support for easy deployment and environment setup.
- Implements SOLID and Domain-Driven Design (DDD) principles for maintainable and scalable code.

## Getting Started

### Prerequisites

- .NET Core 3.1 SDK or later
- Docker Desktop (for Docker support)
- SQL Server (or any EF Core supported database, adjust the connection string accordingly)

### Running the Application

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/yourusername/acmecorp-api.git

cd acmecorp-api

docker-compose up
