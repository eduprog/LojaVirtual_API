#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LojaVirtual.WorkerApp/LojaVirtual.WorkerApp.csproj", "LojaVirtual.WorkerApp/"]
COPY ["LojaVirtual.Infra/LojaVirtual.Infra.csproj", "LojaVirtual.Infra/"]
COPY ["LojaVirtual.Domain/LojaVirtual.Domain.csproj", "LojaVirtual.Domain/"]
RUN dotnet restore "LojaVirtual.WorkerApp/LojaVirtual.WorkerApp.csproj"
COPY . .
WORKDIR "/src/LojaVirtual.WorkerApp"
RUN dotnet build "LojaVirtual.WorkerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaVirtual.WorkerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaVirtual.WorkerApp.dll"]