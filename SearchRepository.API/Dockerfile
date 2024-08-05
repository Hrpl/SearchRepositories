﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SearchRepository.API/SearchRepository.API.csproj", "SearchRepository.API/"]
COPY ["SearchRepository.Application/SearchRepository.Application.csproj", "SearchRepository.Application/"]
COPY ["SearchRepository.Domen/SearchRepository.Domen.csproj", "SearchRepository.Domen/"]
COPY ["SearchRepository.Infrastructure/SearchRepository.Infrastructure.csproj", "SearchRepository.Infrastructure/"]
RUN dotnet restore "SearchRepository.API/SearchRepository.API.csproj"
COPY . .
WORKDIR "/src/SearchRepository.API"
RUN dotnet build "SearchRepository.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SearchRepository.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "ProjectStore.API.dll"]