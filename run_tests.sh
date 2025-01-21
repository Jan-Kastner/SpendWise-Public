#!/bin/bash

# Default settings
DOCKER_COMPOSE_FILE="docker-compose.yml"
DEFAULT_RESULTS_FILE="TestResults.trx"  # Change to .trx extension
DEFAULT_VERBOSITY_LEVEL="detailed"
SPENDWISE_DIR="SpendWise" # Directory to run `dotnet test`

# Function to check if Docker Compose is running
is_docker_compose_running() {
  docker-compose ps | grep "Up" > /dev/null 2>&1
  return $?
}

# Function to display help
show_help() {
  echo "Usage: $0 [--filter FILTER] [--output FILE] [--mode VERBOSITY]"
  echo ""
  echo "Description:"
  echo "  This script runs dotnet tests in the SpendWise directory and manages Docker Compose."
  echo ""
  echo "Arguments:"
  echo "  --filter FILTER   Optional. A filter to run specific tests (e.g., 'Category=CategoryServiceTests')."
  echo "  --output FILE     Optional. File name to save test results (default: TestResults.trx)."
  echo "  --mode VERBOSITY  Optional. Verbosity level for test output (quiet, minimal, normal, detailed; default: detailed)."
  echo ""
  echo "Flags:"
  echo "  -h, --help        Show this help message and exit."
  echo ""
  echo "Examples:"
  echo "  Run all tests with default settings:"
  echo "    $0"
  echo ""
  echo "  Run tests with a specific filter:"
  echo "    $0 --filter 'Category=CategoryServiceTests'"
  echo ""
  echo "  Run tests with a filter and save results to a custom file:"
  echo "    $0 --filter 'Category=CategoryServiceTests' --output CustomResults.trx"
  echo ""
  echo "  Run tests with a custom verbosity level:"
  echo "    $0 --mode minimal"
}

# Default values
FILTER=""
RESULTS_FILE="$DEFAULT_RESULTS_FILE"
VERBOSITY_LEVEL="$DEFAULT_VERBOSITY_LEVEL"

# Parse arguments
while [[ "$#" -gt 0 ]]; do
  case $1 in
    --filter) FILTER="--filter \"$2\""; shift ;;
    --output) RESULTS_FILE="$2"; shift ;;
    --mode) VERBOSITY_LEVEL="$2"; shift ;;
    -h|--help) show_help; exit 0 ;;
    *) echo "Unknown parameter passed: $1"; show_help; exit 1 ;;
  esac
  shift
done

# Start Docker Compose if not running
if ! is_docker_compose_running; then
  echo "Starting Docker Compose..."
  docker-compose up -d
else
  echo "Docker Compose is already running."
fi

# Change to the SpendWise directory
if [ -d "$SPENDWISE_DIR" ]; then
  cd "$SPENDWISE_DIR"
  echo "Changed directory to $(pwd)"
else
  echo "Error: Directory '$SPENDWISE_DIR' does not exist."
  exit 1
fi

# Inform about the settings
if [ -z "$FILTER" ]; then
  echo "No filter provided. Running all tests."
else
  echo "Using filter: $FILTER"
fi
echo "Saving test results to: $RESULTS_FILE"
echo "Using verbosity level: $VERBOSITY_LEVEL"

# Run dotnet test with provided options
echo "Running dotnet test..."

dotnet test $FILTER -v $VERBOSITY_LEVEL --logger:"trx;LogFileName=$RESULTS_FILE"

# Check if tests passed
if [ $? -eq 0 ]; then
  echo "Tests completed successfully. Results are saved in: $RESULTS_FILE"
else
  echo "Tests failed. Check the results file: $RESULTS_FILE"
fi
