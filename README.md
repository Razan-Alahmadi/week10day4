# ProductApi Project

## Overview
Build a Product API with a simple frontend. Dockerize it, push to Docker Hub, and deploy with Kubernetes.

## Backend - ProductApi
- **Endpoints:**
  - GET /api/products
  - GET /api/products/{id}
  - POST /api/products
- **Features:**
  - In-memory product list
  - Service layer with Dependency Injection
  - Read AppName and DefaultCurrency from config

## Frontend
- Simple app to consume the API

## Deployment Steps
1. Run API locally:
   ```bash
   dotnet run --project ProductApi
   ```
2. Build and push Docker image:
   ```bash
   docker build -t username/productapi .
   docker push username/productapi
   ```
3. Deploy with Kubernetes:
   ```bash
   kubectl apply -f deployment.yaml
   kubectl apply -f service.yaml
   minikube service productapi-service
