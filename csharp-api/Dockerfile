# Usar una imagen base con .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos
COPY . .
COPY appsettings.json /app/appsettings.json


# Publicar la aplicación
RUN dotnet publish -c Release -o out

# Usar una imagen base con .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto 5000
EXPOSE 5000

# Comando para ejecutar la aplicación
CMD ["dotnet", "csharp-api.dll"]