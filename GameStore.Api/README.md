# GameStore.Api

##Starting SQL Server 
``` powershell
$sa_password = "Password123!"
$sqlcmd = "C:\Program Files\Microsoft SQL Server\150\Tools\Binn\sqlcmd.exe"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$sa_password" -p 1433:1433 -v ${pwd}:c:/data/db -d mcr.microsoft.com/mssql/server:2022-latest
```
##Setting the connection string to secret manager
``` powershell
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost;Database=GameStore;User Id=sa;Password=Password123!"