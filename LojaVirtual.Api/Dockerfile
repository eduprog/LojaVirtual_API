#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LojaVirtual.Api/LojaVirtual.Api.csproj", "LojaVirtual.Api/"]
COPY ["LojaVirtual.Infra/LojaVirtual.Infra.csproj", "LojaVirtual.Infra/"]
COPY ["LojaVirtual.Domain/LojaVirtual.Domain.csproj", "LojaVirtual.Domain/"]
RUN dotnet restore "LojaVirtual.Api/LojaVirtual.Api.csproj"
COPY . .
WORKDIR "/src/LojaVirtual.Api"
RUN dotnet build "LojaVirtual.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaVirtual.Api.csproj" -c Release -o /app/publish

RUN dotnet ef database update

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaVirtual.Api.dll"]