<#
.SYNOPSIS
  Builds and publishes Qevra directly to D: drive in a standalone, portable directory
  with all saving, settings, caches, and engines self-contained on D:.
#>
[CmdletBinding()]
param(
    [string]$TargetDir = (Join-Path $PSScriptRoot 'dist'),
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Release'
)

$ErrorActionPreference = 'Stop'
$root = $PSScriptRoot

Write-Host "Publishing Qevra to $TargetDir ($Configuration)..." -ForegroundColor Cyan

# 1. Publish Qevra App
& "C:\Users\ASUS\AppData\Local\Microsoft\dotnet\dotnet.exe" publish (Join-Path $root 'src\Qevra.App\Qevra.App.csproj') `
    -c $Configuration -r win-x64 --self-contained -p:PublishReadyToRun=true -o $TargetDir

# 2. Publish Qevra CLI
& "C:\Users\ASUS\AppData\Local\Microsoft\dotnet\dotnet.exe" publish (Join-Path $root 'src\Qevra.Cli\Qevra.Cli.csproj') `
    -c $Configuration -r win-x64 --self-contained -p:PublishReadyToRun=true -o $TargetDir

# 3. Mark as portable and ensure data directory is local on D:
New-Item -ItemType File -Path (Join-Path $TargetDir '.portable') -Force | Out-Null
New-Item -ItemType Directory -Path (Join-Path $TargetDir 'data') -Force | Out-Null

# 4. Copy bundled engines if present in root
if (Test-Path (Join-Path $root 'engines')) {
    Copy-Item -Path (Join-Path $root 'engines') -Destination $TargetDir -Recurse -Force
}

Write-Host "Build complete! Qevra is ready on D: drive at: $TargetDir" -ForegroundColor Green
Write-Host "All settings, user data, and engines will be stored inside: $(Join-Path $TargetDir 'data')" -ForegroundColor Green

