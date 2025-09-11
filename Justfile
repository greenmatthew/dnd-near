# DndNear Docker Management

# Default recipe shows help
default: help

# Show available recipes
@help:
    just --list

# Build and start all services
up:
    @echo "Building and starting all services..."
    docker-compose up --build -d

# Stop all services
down:
    @echo "Stopping all services..."
    docker-compose down

# Stop all services and remove volumes
down-clean:
    @echo "Stopping all services and removing volumes..."
    docker-compose down -v

# View logs for all services
logs:
    docker-compose logs -f

# View logs for specific service
logs-api:
    docker-compose logs -f api

# Build only the API
build-api:
    @echo "Building API container..."
    docker-compose build api

# Restart API service
restart-api:
    @echo "Restarting API service..."
    docker-compose restart api

# Check service status
status:
    docker-compose ps

# Clean up Docker system (careful with this!)
clean:
    @echo "Cleaning up Docker system..."
    docker system prune -f

# Show container resource usage
stats:
    docker stats

# Full reset (removes everything)
reset: down-clean clean
    @echo "Full reset complete. Run 'just up' to start fresh."
