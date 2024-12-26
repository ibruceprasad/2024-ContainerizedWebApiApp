# Dockerized Web API and database <span>#</span>


This project demonstrates how to containerize a .NET Web API application and its backend database, then deploy it to a containerized platform, Azure Container Apps (ACA), using a GitHub Actions CI/CD pipeline

The project includes:
1) A basic `Web API` application using Entity Framework Core as the ORM, configured for an `MS SQL` database.<br>
2) A `Dockerfile` scaffolded directly from Visual Studio to build a Docker image.<br>
3) A `Docker Compose` file configured with both the .NET app image and the database image.<br>
4) `Terraform` IaC scripts to provision the required Azure resources, including an Azure Resource Group, `Azure Container Registry (ACR)`, and `Azure Container Apps (ACA)`.<br>
5) `GitHub Action` workflows scripts for:
   a) building and pushing the image to ACR,<br>
   b) deploying the image to ACA.<br>
 
<br>
Project structure:
<br>


![image](https://github.com/user-attachments/assets/d4d7aecb-93b1-4f30-9133-6d38d06d5560)
<br>

Github Action workflow: <br>

![image](https://github.com/user-attachments/assets/0431ec7f-0599-4ee7-8d0e-111cea732313)

