#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventManager.ConsoleApp/EventManager.ConsoleApp.csproj", "EventManager.ConsoleApp/"]
COPY ["EventManager.Core/EventManager.Core.csproj", "EventManager.Core/"]
RUN dotnet restore "EventManager.ConsoleApp/EventManager.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/EventManager.ConsoleApp"
RUN dotnet build "EventManager.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventManager.ConsoleApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventManager.ConsoleApp.dll"]
