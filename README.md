# SpendWise-Public
SpendWise is financial management tool designed to help users track their expenses, manage budgets, and analyze spending patterns. This public repository contains the core features and is open for contributions and collaboration.
## Features

- **Data Access Layer (DAL)**: Handles the interaction with the database, providing a structured way to manage data entities.
- **Unit Tests**: Ensures the reliability and correctness of the DAL functionalities.

## Getting Started

These instructions will help you set up and run the project on your local machine.

### Prerequisites

- Docker: Used to run the PostgreSQL database.
- .NET SDK: Required for building and running the project.

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/spendwise-public.git
   cd spendwise-public
   ```

2. **Set Up Docker**

   Run the PostgreSQL database using Docker:

   ```bash
   docker-compose up -d
   ```

3. **Configure the Project**

   Ensure your `.env` file (if needed) is correctly configured with the database connection settings.

4. **Change Directory to Project Folder**

   ```bash
   cd SpendWise
   ```

5. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

6. **Run Migrations**

   Apply database migrations to set up the initial schema:

   ```bash
   dotnet ef database update --project SpendWise.DAL
   ```

7. **Build and Run the Project**

   ```bash
   dotnet build
   dotnet run
   ```

### Running Tests

To run the unit tests, use the following command:

```bash
dotnet test
```

## Project Structure

- **SpendWise.DAL**: Contains the Data Access Layer for interacting with the PostgreSQL database.
- **SpendWise.DAL.Tests**: Contains unit tests for the DAL to ensure functionality and reliability.

## Contributing

If you'd like to contribute to this project, please follow these guidelines:

1. Fork the repository.
2. Create a new branch:

   ```bash
   git checkout -b feature/YourFeature
   ```

3. Commit your changes:

   ```bash
   git commit -am 'Add new feature'
   ```

4. Push to the branch:

   ```bash
   git push origin feature/YourFeature
   ```

5. Open a Pull Request.

## License

This project is licensed under the MIT License.

## Acknowledgments

- PostgreSQL for the database.
- Docker for containerization.
