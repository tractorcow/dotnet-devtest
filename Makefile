# Makefile for dotnet-devtest
# Run 'make help' for available targets.

CONFIG ?= Debug
SOLUTION = dotnet-devtest.sln
LIBRARY_PROJECT = src/dotnet-devtest/dotnet-devtest.csproj
ARTIFACTS_DIR = artifacts

.PHONY: all build build-release restore clean test pack help

# Default target: build
all: build

# Restore NuGet packages
restore:
	dotnet restore $(SOLUTION)

# Build solution (Debug by default)
build: restore
	dotnet build $(SOLUTION) -c $(CONFIG) --no-restore

# Build in Release configuration
build-release:
	$(MAKE) build CONFIG=Release

# Remove build outputs
clean:
	dotnet clean $(SOLUTION) -c $(CONFIG)
	rm -rf src/dotnet-devtest/bin src/dotnet-devtest/obj
	rm -rf $(ARTIFACTS_DIR)

# Run tests
test: build
	dotnet test $(SOLUTION) -c $(CONFIG) --no-build

# Create NuGet package(s)
pack: restore
	dotnet pack $(LIBRARY_PROJECT) -c Release -o $(ARTIFACTS_DIR) --no-restore

# Show available targets
help:
	@echo "Targets:"
	@echo "  all (default)  - restore and build (Debug)"
	@echo "  build         - restore and build (CONFIG=Debug|Release)"
	@echo "  build-release - build in Release"
	@echo "  restore       - restore NuGet packages"
	@echo "  clean         - remove bin/obj and artifacts"
	@echo "  test          - build and run tests"
	@echo "  pack          - create NuGet package(s) in $(ARTIFACTS_DIR)"
	@echo "  help          - show this message"
	@echo ""
	@echo "Override config: make build CONFIG=Release"
