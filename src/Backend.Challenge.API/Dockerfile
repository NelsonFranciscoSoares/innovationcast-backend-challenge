#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Backend.Challenge.API/Backend.Challenge.API.csproj", "Backend.Challenge.API/"]
COPY ["./Backend.Challenge.Infrastructure.Persistence/Backend.Challenge.Infrastructure.Persistence.csproj", "Backend.Challenge.Infrastructure.Persistence/"]
COPY ["./Backend.Challenge.Kernel.Infrastructure.Persistence/Backend.Challenge.Kernel.Infrastructure.Persistence.csproj", "Backend.Challenge.Kernel.Infrastructure.Persistence/"]
COPY ["./Backend.Challenge.Kernel.Domain/Backend.Challenge.Kernel.Domain.csproj", "Backend.Challenge.Kernel.Domain/"]
COPY ["./Backend.Challenge.Domain/Backend.Challenge.Domain.csproj", "Backend.Challenge.Domain/"]
COPY ["./Backend.Challenge.Kernel.Application/Backend.Challenge.Kernel.Application.csproj", "Backend.Challenge.Kernel.Application/"]
COPY ["./Backend.Challenge.Application/Backend.Challenge.Application.csproj", "Backend.Challenge.Application/"]
RUN dotnet restore "Backend.Challenge.API/Backend.Challenge.API.csproj"
COPY . .
WORKDIR /src/Backend.Challenge.API
RUN dotnet build "Backend.Challenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Challenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Challenge.API.dll"]