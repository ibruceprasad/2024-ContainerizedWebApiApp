resource "azurerm_container_registry" "garden-management-container-registry" {
  #Container Registry needs to be globally unique and alpha numeric characters only are allowed in "name"
  name                          = "gmanagementcontainerregistry${var.env}"
  resource_group_name           = azurerm_resource_group.garden-management-rg.name
  location                      = azurerm_resource_group.garden-management-rg.location
  sku                           = "Basic"
  admin_enabled                 = true
  public_network_access_enabled = true
  tags = {
    environment = var.env
    src         = var.src
  }
}


resource "azurerm_log_analytics_workspace" "garden-management-log-analytics" {
  name                = "g-loganalytics-${var.env}"
  location            = azurerm_resource_group.garden-management-rg.location
  resource_group_name = azurerm_resource_group.garden-management-rg.name
  sku                 = "PerGB2018" # default value 
  retention_in_days   = 30
}

resource "azurerm_container_app_environment" "garden-management-container-app-env" {
  name                       = "g-containerappenv-${var.env}"
  location                   = "Australia East"
  resource_group_name        = azurerm_resource_group.garden-management-rg.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.garden-management-log-analytics.id
  tags = {
    environment = var.env
    src         = var.src
  }
}


resource "azurerm_container_app" "garden-management-container-app" {
  name                         = "g-containerapp-${var.env}"
  container_app_environment_id = azurerm_container_app_environment.garden-management-container-app-env.id
  resource_group_name          = azurerm_resource_group.garden-management-rg.name
  revision_mode                = "Multiple"

  # container configuration
  template {
    min_replicas = 1
    max_replicas = 2

    container {
      name   = "g-containerapp-${var.env}"
      image  = "mcr.microsoft.com/k8se/quickstart:latest"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }

  #network configurations for Kubernaties 
  ingress {
    allow_insecure_connections = false
    external_enabled           = true
    target_port                = 8082
    traffic_weight {
      percentage      = 100
      latest_revision = true
    }
  }

  tags = {
    environment = var.env
    src         = var.src
  }
}

#changed region and unique name is reqd
resource "azurerm_mssql_server" "garden-management-mssql-server" {
  name                         = "g-management-mssqlserver-${var.env}"
  resource_group_name          = azurerm_resource_group.garden-management-rg.name
  location                     = "Australia East"
  version                      = "12.0"
  administrator_login          = "missadministrator"
  administrator_login_password = "thisIsKat11"
  tags = {
    environment = var.env
    src         = var.src
  }
}

resource "azurerm_mssql_database" "garden-management-mssql-database" {
  name           = "g-management-mssqldatabase-${var.env}"
  server_id      = azurerm_mssql_server.garden-management-mssql-server.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  sku_name       = "S0"
  zone_redundant = false

  tags = {
    environment = var.env
    src         = var.src
  }
  # prevent the possibility of accidental data loss
  lifecycle {
    prevent_destroy = false
  }
}

# IP range to allow acccess to database
resource "azurerm_mssql_firewall_rule" "garden-management-mssql-firewallrule" {
  name             = "FirewallRule1"
  server_id        = azurerm_mssql_server.garden-management-mssql-server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}
