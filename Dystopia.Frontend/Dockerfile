# Stage 1: Build all dependencies
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file
COPY ["Dystopia.Frontend.csproj", "./"]

# Restore dependencies
RUN dotnet restore "Dystopia.Frontend.csproj"

# Copy the rest of the solution
COPY . .

# Build the project
RUN dotnet build "Dystopia.Frontend.csproj" -c Release

# Stage 2: Publish Dystopia
FROM build AS publish
WORKDIR /src
RUN dotnet publish "Dystopia.Frontend.csproj" -c Release -o /app/publish /p:UseAppHost=false && ls -la /app/publish

# List the contents of the publish directory
RUN ls -la /app/publish

# Stage 3: Final runtime image for Dystopia
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# List contents before copying
RUN ls -la /app

# Copy from publish stage
COPY --from=publish /app/publish .

# List contents after copying
RUN ls -la /app

ENTRYPOINT ["dotnet", "Dystopia.Frontend.dll"]
