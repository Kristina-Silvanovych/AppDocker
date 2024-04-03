FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AppDocker.csproj", "AppDocker/"]
RUN dotnet restore "./AppDocker/AppDocker.csproj"
WORKDIR "/src/AppDocker"
COPY . .
RUN dotnet build "AppDocker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AppDocker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Встановлення dotnet-ef
RUN dotnet tool install --global dotnet-ef
# Додавання шляху до інструментів dotnet до PATH, щоб можна було виконувати dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppDocker.dll"]
