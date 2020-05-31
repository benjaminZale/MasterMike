dotnet clean -c Release
dotnet publish -c Release
del .\MasterMike.1.0.0.zip
Compress-Archive .\MasterMike\bin\Release\netcoreapp3.1\publish -DestinationPath .\MasterMike.1.0.0.zip