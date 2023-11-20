dotnet cyclonedx ../Shorty.sln --out . --json --exclude-dev

$fileContent = Get-Content ./bom.json -Raw | ConvertFrom-Json

if (Test-Path -Path "SBOM.md") {
    Remove-Item "SBOM.md"
}

Add-Content -Path "SBOM.md" -Value "# Software Bill Of Material"
Add-Content -Path "SBOM.md" -Value ""
Add-Content -Path "SBOM.md" -Value "Name | Author | Version | License"
Add-Content -Path "SBOM.md" -Value "---|---|---|---"

foreach ($component in $fileContent.components) {
    $license = $component.licenses ?? @(@{ license = @{id = "" } })
    Add-Content -Path "SBOM.md" -Value "$($component.name) | $($component.author) | $($component.version) | $($license[0].license.id)"
}
