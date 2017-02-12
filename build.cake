#tool nuget:?package=NUnit.ConsoleRunner&version=3.6.0

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutionFile = "./Thrower.sln";
var projectPaths = new[] { "./src/PommaLabs.Thrower" };
var artifactsDir = "./artifacts";
var testOutputDir = artifactsDir + "/test-results";
var testPaths = new[] { "./test/PommaLabs.Thrower.UnitTests/bin/{cfg}/*/PommaLabs.Thrower.UnitTests.dll" };

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifactsDir);
    CleanDirectory(testOutputDir);
    Clean("Debug", projectPaths);
    Clean("Release", projectPaths);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionFile);
});

Task("Build-Debug")
    .IsDependentOn("Restore")
    .Does(() => 
{
    Build("Debug");
});

Task("Test-Debug")
    .IsDependentOn("Build-Debug")
    .Does(() =>
{
    Test("Debug", testPaths);
});

Task("Build-Release")
    .IsDependentOn("Test-Debug")
    .Does(() => 
{
    Build("Release");
});

Task("Test-Release")
    .IsDependentOn("Build-Release")
    .Does(() =>
{
    Test("Release", testPaths);
});

Task("Pack-Release")
    .IsDependentOn("Test-Release")
    .Does(() => 
{
    Pack("Release", projectPaths);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Pack-Release");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

//////////////////////////////////////////////////////////////////////
// HELPERS
//////////////////////////////////////////////////////////////////////

private void Clean(string cfg, string[] rootProjectPaths)
{
    foreach (var rootProjectPath in rootProjectPaths)
    {
        CleanDirectory(rootProjectPath + "/bin/" + cfg);
    }
}

private void Build(string cfg)
{
    if (IsRunningOnWindows())
    {
        // Use MSBuild
        MSBuild(solutionFile, settings =>
        {
            settings.SetConfiguration(cfg);
            settings.SetMaxCpuCount(0); // Max parallelism
        });
    }
    else
    {
        // Use XBuild
        XBuild(solutionFile, settings =>
        {
            settings.SetConfiguration(cfg);
        });
    }
}

private void Test(string cfg, string[] unitTestDllPaths)
{
    foreach (var unitTestDllPath in unitTestDllPaths)
    {
        NUnit3(unitTestDllPath.Replace("{cfg}", cfg), new NUnit3Settings 
        {
            NoResults = true,
            OutputFile = System.IO.Path.Combine(testOutputDir, cfg.ToLower() + ".xml")
        });
    }
}

private void Pack(string cfg, string[] rootProjectPaths)
{
    foreach (var rootProjectPath in rootProjectPaths)
    {
        DotNetCorePack(rootProjectPath + "/project.json", new DotNetCorePackSettings
        {
            Configuration = cfg,
            OutputDirectory = artifactsDir,
            NoBuild = true
        });
    }    
}