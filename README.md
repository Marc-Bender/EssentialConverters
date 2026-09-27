publish to github packages with 

dotnet nuget push "<full path here -- no wildcards>" --source "https://nuget.pkg.github.com/Marc-Bender/index.json" --api-key <REDACTED>


must not use a project scope feed as eg ...github.com/Marc-Bender/EssentialConverters/index.json would fail

must not use a relative path with wildcards as windows would fail to resolve that in that case.
