#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Backend.Challenge.API/Backend.Challenge.API.csproj", "src/Backend.Challenge.API/"]
COPY ["src/Backend.Challenge.Infrastructure.Persistence/Backend.Challenge.Infrastructure.Persistence.csproj", "src/Backend.Challenge.Infrastructure.Persistence/"]
COPY ["src/Backend.Challenge.Kernel.Infrastructure.Persistence/Backend.Challenge.Kernel.Infrastructure.Persistence.csproj", "src/Backend.Challenge.Kernel.Infrastructure.Persistence/"]
COPY ["src/Backend.Challenge.Kernel.Domain/Backend.Challenge.Kernel.Domain.csproj", "src/Backend.Challenge.Kernel.Domain/"]
COPY ["src/Backend.Challenge.Domain/Backend.Challenge.Domain.csproj", "src/Backend.Challenge.Domain/"]
RUN dotnet restore "src/Backend.Challenge.API/Backend.Challenge.API.csproj"
COPY . .
WORKDIR "/src/src/Backend.Challenge.API"
RUN dotnet build "Backend.Challenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Challenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Challenge.API.dll"]