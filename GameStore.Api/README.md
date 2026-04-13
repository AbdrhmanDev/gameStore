# GameStore.Api

##Starting SQL Server 
``` powershell
$sa_password = "Password123!"
$sqlcmd = "C:\Program Files\Microsoft SQL Server\150\Tools\Binn\sqlcmd.exe"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```