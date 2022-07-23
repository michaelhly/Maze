vscode:
	curl -sSfL https://www.nuget.org/api/v2/package/Microsoft.Unity.Analyzers/1.14.0 -o microsoft.unity.analyzers.1.14.0.nupkg
	ditto -x -k microsoft.unity.analyzers.1.14.0.nupkg microsoft.unity.analyzers.1.14.0
	rm -rf microsoft.unity.analyzers.1.14.0.nupkg
