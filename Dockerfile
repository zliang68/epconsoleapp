# Restore .NET Core SDK 2.2
FROM mcr.microsoft.com/dotnet/core/sdk:2.2

# Copy publish folder with its files to a docker container folder
COPY ConsoleEPTest/ConsoleEPTest/bin/Release/netcoreapp2.2/publish/ epapp/

# Copy SampleFiles folder with its files to a docker container folder
COPY SampleFiles/ epapp/SampleFiles/

# Entrypoint binding
ENTRYPOINT ["dotnet", "epapp/ConsoleEPTest.dll"]