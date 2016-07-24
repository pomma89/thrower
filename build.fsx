// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

RestorePackages()

// Properties
let buildMode    = getBuildParamOrDefault "buildMode" "Debug"
let artifactsDir = "./.artifacts/"
let testDir      = "./Platform Specific/Thrower.UnitTests.*/bin/{0}/"
let testDll      = "PommaLabs.Thrower.UnitTests.dll"
let perfDir      = "./Thrower.Benchmarks/bin/Release/"
let perfExe      = "PommaLabs.Thrower.Benchmarks.exe"

// Common - Build
let myBuild target buildMode =
    let setParams defaults = 
      { defaults with
          Verbosity = Some(Quiet)
          Targets = [target]
          Properties = 
            [
              "Configuration", buildMode
            ]
      }
    build setParams "./Thrower.sln" |> DoNothing

// Common - Test
let myTest (buildMode: string) =
    !! (System.String.Format(testDir, buildMode) + testDll)
      |> NUnit (fun p -> 
        { p with
            DisableShadowCopy = true;
            OutputFile = artifactsDir + "test-results.xml" 
        })

// Targets
Target "Clean" (fun _ ->
    trace "Cleaning..."
    
    CleanDirs [artifactsDir]

    myBuild "Clean" "Debug"
    myBuild "Clean" "Release"
    myBuild "Clean" "Publish"
)

Target "BuildDebug" (fun _ ->
    trace "Building for DEBUG..."
    myBuild "Build" "Debug"
)

Target "BuildRelease" (fun _ ->
    trace "Building for RELEASE..."
    myBuild "Build" "Release"
)

Target "BuildPublish" (fun _ ->
    trace "Building for PUBLISH..."
    myBuild "Build" "Publish"
)

Target "TestDebug" (fun _ ->
    trace "Testing for DEBUG..."
    myTest "Debug"
)

Target "TestRelease" (fun _ ->
    trace "Testing for RELEASE..."
    myTest "Release"
)

Target "PerfRelease" (fun _ ->
    trace "Testing performance..."
    directExec (fun info ->
      info.FileName <- perfDir + perfExe
      info.WorkingDirectory <- perfDir) |> ignore
)

Target "Default" (fun _ ->
    trace "Building and publishing Thrower..."
)

// Dependencies
"Clean"
  ==> "BuildDebug"
  ==> "TestDebug"
  ==> "BuildRelease"
  ==> "TestRelease"
  ==> "PerfRelease"
  ==> "BuildPublish"
  ==> "Default"

// Start build
RunTargetOrDefault "Default"