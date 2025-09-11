# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["src/DndNear.API/DndNear.API.csproj", "src/DndNear.API/"]
COPY ["src/DndNear.Shared/DndNear.Shared.csproj", "src/DndNear.Shared/"]

# Restore dependencies
RUN dotnet restore "src/DndNear.API/DndNear.API.csproj"

# Copy all source code
COPY . .

# Build the application
WORKDIR "/src/src/DndNear.API"
RUN dotnet build "DndNear.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "DndNear.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official .NET 8 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Install curl for health checks (optional)
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copy the published application
COPY --from=publish /app/publish .

# Expose the port
EXPOSE 5000

# Create a non-root user
RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

# Set the entry point
ENTRYPOINT ["dotnet", "DndNear.API.dll"]
