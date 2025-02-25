# Usa una imagen base de .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usa una imagen de SDK para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["api_psp.csproj", "./"]
RUN dotnet restore "./api_psp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api_psp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_psp.csproj" -c Release -o /app/publish

# Configura la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_psp.dll"]