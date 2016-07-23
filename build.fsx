// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

RestorePackages()

// Properties
let testNet45Dir  = "./Platform Specific/Thrower.UnitTests.NET45/bin/Debug/"
let testDll = "PommaLabs.Thrower.UnitTests.dll"

// Targets
Target "Clean" (fun _ ->
    trace "Cleaning..."
)

Target "Build" (fun _ ->
    trace "Building..."
    let setParams defaults = defaults
    build setParams "./Thrower.sln" |> DoNothing
)

Target "Test" (fun _ ->
    trace "Testing..."
    !! (testNet45Dir + testDll)
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = testNet45Dir + "TestResults.xml" })
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