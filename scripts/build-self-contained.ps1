dotnet publish `
    --self-contained `
    -o build/self-contained/ `
    -r win-x64 `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:EnableCompressionInSingleFile=true `
    -p:PublishReadyToRun=true `
    src/SlstGen/SlstGen.csproj
