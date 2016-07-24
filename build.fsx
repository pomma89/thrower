// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

RestorePackages()

// Properties
let buildMode    = getBuildParamOrDefault "buildMode" "Debug"
let artifactsDir = "./Artifacts"
let testDir      = "./Platform Specific/Thrower.UnitTests.*/bin/" + buildMode + "/"
let testDll      = "PommaLabs.Thrower.UnitTests.dll"

// Targets
Target "Clean" (fun _ ->
    trace "Cleaning..."
    
    CleanDirs [artifactsDir]

    let setParams defaults = 
      { defaults with
          Verbosity = Some(Quiet)
          Targets = ["Clean"]
      }
    build setParams "./Thrower.sln" |> DoNothing
)

Target "Build" (fun _ ->
    trace "Building..."
    let setParams defaults = 
      { defaults with
          Verbosity = Some(Quiet)
          Targets = ["Build"]
          Properties = 
            [
              "Configuration", buildMode
            ]
      }
    build setParams "./Thrower.sln" |> DoNothing
)

Target "Test" (fun _ ->
    trace "Testing..."
    !! (testDir + testDll)
      |> NUnit (fun p -> 
        { p with
            DisableShadowCopy = true;
            OutputFile = "./Artifacts/test-results.xml" 
        })
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Default"

// Start build
RunTargetOrDefault "Default"