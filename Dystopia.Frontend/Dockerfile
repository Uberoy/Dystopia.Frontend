# Stage 1: Build the Blazor WebAssembly app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY Dystopia.Frontend.csproj ./
RUN dotnet restore

# Copy the rest of the app and build the project
COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Serve the app using nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Install tzdata to configure the timezone
RUN apk add --no-cache tzdata

# Set the timezone
ENV TZ=Etc/UTC

# Copy the app from the build stage
COPY --from=build /app/publish/wwwroot ./

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
