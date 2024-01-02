# Imagen base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen del SDK para construir y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GestionRecursosHumanos.API.csproj", "./"]
RUN dotnet restore "./GestionRecursosHumanos.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "GestionRecursosHumanos.API.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "GestionRecursosHumanos.API.csproj" -c Release -o /app/publish

# Generar la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestionRecursosHumanos.API.dll"]
