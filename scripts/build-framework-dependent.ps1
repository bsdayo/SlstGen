$outputPath = Join-Path $PSScriptRoot ../build/framework-dependent/
$csprojPath = Join-Path $PSScriptRoot ../src/SlstGen/SlstGen.csproj

dotnet publish `
    --no-self-contained `
    -o $outputPath `
    -r win-x64 `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:PublishReadyToRun=true `
    $csprojPath