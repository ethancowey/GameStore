# GameStore

A .NET project for managing a video game store API.

This was created in Visual Studio as an experiment using the built in Copilot Chat (Agent GPT-4.1) using a copilot-instructions markdown file.

## Getting Started

1. **Restore dependencies:**
   ```sh
   dotnet restore
   ```
2. **Build the solution:**
   ```sh
   dotnet build
   ```
3. **Run the application:**
   ```sh
   dotnet run --project GameStore/GameStore.csproj
   ```
4. **Run tests:**
   ```sh
   dotnet test --collect:"XPlat Code Coverage"
   ```

## Code Coverage

![Coverage](./coverage-badge.svg)

After running tests, a coverage report will be generated in the `TestResults` directory. To update the badge, use a tool like [Codecov](https://about.codecov.io/) or [coverlet](https://github.com/coverlet-coverage/coverlet).

## GitHub Actions

This project uses GitHub Actions for CI/CD. See `.github/workflows/dotnet.yml` for details.
