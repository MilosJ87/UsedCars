#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UsedCars.API/UsedCars.API.csproj", "UsedCars.API/"]
COPY ["UsedCars.Commons/UsedCars.Common.csproj", "UsedCars.Commons/"]
COPY ["UsedCars.Repository/UsedCars.Repository.csproj", "UsedCars.Repository/"]
COPY ["UsedCars.Data/UsedCars.Data.csproj", "UsedCars.Data/"]
COPY ["UsedCars.Services/UsedCars.Services.csproj", "UsedCars.Services/"]
COPY ["UsedCars.Models/UsedCars.Models.csproj", "UsedCars.Models/"]
RUN dotnet restore "UsedCars.API/UsedCars.API.csproj"
COPY . .
WORKDIR "/src/UsedCars.API"
RUN dotnet build "UsedCars.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsedCars.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsedCars.API.dll"]