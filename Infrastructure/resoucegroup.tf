resource "azurerm_resource_group" "garden-management-rg" {
  name     = "gardenmanagement-rg"
  location = "Australia Central"

  tags = {
    environment = var.env
    src         = var.src
  }

}
