git-mish
========

A basic git hook handler for creating tasks when git sends a hook request.

setup
========

## Get it on NuGet!

    PM> Install-Package git-mish

## Compile the code

Basicly run the build.cmd to build and run the tests.

## Using the git-mish

if you are using asp.net application you simply write the following lines,

```csharp

   protected void Application_Start(object sender, EventArgs e)
   {
       GitHook.SetupForRepository("testing").BranchOf("master")
                .Then<StandardBuildOperation>()
                .Save(RouteTable.Routes, "Github/ci");
   }

```

