resource "azurerm_resource_group" "garden-management-rg" {
  name     = "gardenmanagement-rg-v2"
  location = "Australia Central"

  tags = {
    environment = var.env
    src         = var.src
  }

}
