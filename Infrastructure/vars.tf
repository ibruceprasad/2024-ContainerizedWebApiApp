variable "subscriptionid" {
  type        = string
  description = "The Azure subscription id"
  default     = "96a13dc7-6d34-4771-81e6-16939d91185c"
}




variable "src" {
  type        = string
  description = "infrastructure source"
  default     = "terraform"
}

variable "env" {
  type        = string
  description = "environment"
  default     = "dev"
}
