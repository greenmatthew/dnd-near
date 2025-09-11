# Use the official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["src/DndNear.Web/DndNear.Web.csproj", "src/DndNear.Web/"]
COPY ["src/DndNear.Shared/DndNear.Shared.csproj", "src/DndNear.Shared/"]

# Restore dependencies
RUN dotnet restore "src/DndNear.Web/DndNear.Web.csproj"

# Copy all source code
COPY . .

# Build and publish the Blazor WebAssembly application
WORKDIR "/src/src/DndNear.Web"
RUN dotnet publish "DndNear.Web.csproj" -c Release -o /app/publish

# Use nginx to serve the static files
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Remove default nginx files
RUN rm -rf /usr/share/nginx/html/*

# Copy the published Blazor WebAssembly files
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Copy custom nginx configuration
COPY src/DndNear.Web/nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
