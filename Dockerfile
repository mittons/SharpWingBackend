# Use the official Microsoft ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SharpWingBackend.csproj", "./"]
RUN dotnet restore "./SharpWingBackend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SharpWingBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharpWingBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharpWingBackend.dll"]
