# 1. مرحلة البناء (Build Stage)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# نسخ ملف المشروع وعمل Restore
COPY *.csproj ./
RUN dotnet restore

# نسخ كل الملفات وبناء المشروع
COPY . ./
RUN dotnet publish -c Release -o out

# 2. مرحلة التشغيل (Runtime Stage)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# تأكد من بورت التشغيل (لو مشروعك شغال على بورت مختلف غيره هنا)
EXPOSE 8080
ENTRYPOINT ["dotnet", "GameStore.Api.dll"]
#ENTRYPOINT ["dotnet", "GameStore.Api.dll"]