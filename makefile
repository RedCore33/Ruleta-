PROJECT = PPS_Ruleta/PPS_Ruleta.csproj
TEST = PPS_Ruleta.Tests/PPS_Ruleta.Tests.csproj

build:
	dotnet build $(PROJECT)

run:
	dotnet run --project $(PROJECT)

test:
	dotnet test $(TEST)

clean:
	dotnet clean $(PROJECT)
	dotnet clean $(TEST)