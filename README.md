# dotnet-devtest

A cross-platform .NET class library written in C#, targeting .NET 10.

This repository includes an intentional debugging exercise: there is a non-obvious bug somewhere in the codebase, and the existing unit tests pass without exposing it.

## Prerequisites

- **.NET 10 SDK** (or later). The library targets `net10.0`, so the SDK is required to build and run.

  - **Install on macOS (Homebrew):**
    ```bash
    brew install dotnet@10
    ```
  - **Install on Linux:** See [.NET install for Linux](https://learn.microsoft.com/en-us/dotnet/core/install/linux).
  - **Install on Windows:** Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download) or use the Windows package manager.

  Check that the SDK is installed:
  ```bash
  dotnet --version
  ```
  You should see `10.x.x` or higher.

## Project structure

```
dotnet-devtest/
├── dotnet-devtest.sln          # Solution file
├── src/
│   └── dotnet-devtest/         # Class library project
│       ├── dotnet-devtest.csproj
│       ├── Library.cs
│       ├── Models/
│       ├── Pipeline/
│       └── Services/
├── tests/
│   └── dotnet-devtest.Tests/   # Unit tests
├── .editorconfig               # Editor and style settings
├── .gitignore
└── README.md
```

## Setup

1. **Clone or open the repository**
   ```bash
   cd /path/to/dotnet-devtest
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the library**
   ```bash
   dotnet build
   ```
   Or build the solution from the repo root:
   ```bash
   dotnet build dotnet-devtest.sln
   ```

4. **Run tests**
   ```bash
   dotnet test
   ```

## Common commands

| Command | Description |
|--------|-------------|
| `dotnet restore` | Restore NuGet packages |
| `dotnet build` | Build the solution (Debug) |
| `dotnet build -c Release` | Build in Release configuration |
| `dotnet pack` | Create a NuGet package from the library project |

To pack the library from the repo root:

```bash
dotnet pack src/dotnet-devtest/dotnet-devtest.csproj -c Release -o ./artifacts
```

## Cross-platform notes

- The project uses the SDK-style format and targets **.NET 10**, which is supported on Windows, macOS, and Linux.
- Paths in the solution file use backslashes for Visual Studio compatibility; the .NET CLI works on all platforms.
- Use only cross-platform APIs in the library (e.g. avoid Windows-specific namespaces or P/Invoke unless abstracted).

## Development

- **IDE:** Use Visual Studio 2022, Rider, or VS Code with the C# extension. Opening the folder or `dotnet-devtest.sln` is enough.
- **Code style:** The repo includes an `.editorconfig` for consistent formatting and naming. Use “Format Document” in your editor to apply it.

## License

See the repository license file.
