$ErrorActionPreference = "Stop"

git subtree split -P angular/libs/JobsManagement -b angular/libs/JobsManagement

git push origin angular/libs/JobsManagement:angular/libs/JobsManagement

