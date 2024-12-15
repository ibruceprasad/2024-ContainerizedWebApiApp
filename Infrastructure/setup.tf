terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.11.0" # Use version 3.x.x but not 4.0.0 or higher
    }
  }
  required_version = ">= 1.1.0" # Ensures Terraform CLI version compatibility
}

provider "azurerm" {
  features {
  }
  subscription_id = var.subscriptionid
}