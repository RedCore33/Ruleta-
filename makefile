PROJECT = Calculator/Calculator.csproj
TEST = Calculator.Tests/Calculator.Tests.csproj

run:
	dotnet run --project $(PROJECT)

test:
	dotnet test $(TEST)

clean:
	dotnet clean $(PROJECT)
	dotnet clean $(TEST)