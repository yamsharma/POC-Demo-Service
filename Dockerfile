FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src

COPY ["POCDemoApp.API/POCDemoApp.API.csproj", "POCDemoApp.API/"]
COPY ["POCDemoApp.Core/POCDemoApp.Core.csproj", "POCDemoApp.Core/"]
COPY ["POCDemoApp.Domain/POCDemoApp.Domain.csproj", "POCDemoApp.Domain/"]
COPY ["POCDemoApp.Infrastructure.DataAccess/POCDemoApp.Infrastructure.DataAccess.csproj", "POCDemoApp.Infrastructure.DataAccess/"]
COPY ["POCDemoApp.Infrastructure.IoC/POCDemoApp.Infrastructure.IoC.csproj", "POCDemoApp.Infrastructure.IoC/"]

RUN dotnet restore "POCDemoApp.API/POCDemoApp.API.csproj"
COPY . .

WORKDIR "/src/POCDemoApp.API"
RUN dotnet build "POCDemoApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POCDemoApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "POCDemoApp.API.dll"]