dotnet publish `
    --no-self-contained `
    -o build/framework-dependent/ `
    -r win-x64 `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:PublishReadyToRun=true `
    src/SlstGen/SlstGen.csproj
