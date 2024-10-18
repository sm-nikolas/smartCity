# Use uma imagem oficial do .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use outra imagem do SDK para buildar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

# Restaura as dependências e faz o build
RUN dotnet restore "SmartCityApi.csproj"
RUN dotnet build "SmartCityApi.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "SmartCityApi.csproj" -c Release -o /app/publish

# Usa a imagem base para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCityApi.dll"]
