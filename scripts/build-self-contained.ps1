$outputPath = Join-Path $PSScriptRoot ../build/self-contained/
$csprojPath = Join-Path $PSScriptRoot ../src/SlstGen/SlstGen.csproj

dotnet publish `
    --self-contained `
    -o $outputPath `
    -r win-x64 `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:EnableCompressionInSingleFile=true `
    -p:PublishReadyToRun=true `
    $csprojPath