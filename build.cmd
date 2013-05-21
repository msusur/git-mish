@echo off
pushd %~dp0

SET MsBuildPath=C:\Windows\Microsoft.NET\Framework64\v4.0.30319


if exist bin goto build
mkdir bin

:Build
if "%1" == "" goto BuildDefaults

%MsBuildPath%\msbuild.exe git-mish.msbuild /m /nr:false /t:%* /p:Platform="Any CPU" /v:M /fl /flp:LogFile=bin\msbuild.log;Verbosity=Normal
if errorlevel 1 goto BuildFail
goto BuildSuccess

:BuildSuccess
echo.
echo **** BUILD SUCCESSFUL ***
goto End

:BuildFail
echo.
echo *** BUILD FAILED ***
goto End

:BuildDefaults
%MsBuildPath%\msbuild.exe git-mish.msbuild /m /nr:false /p:Platform="Any CPU" /v:M /fl /flp:LogFile=bin\msbuild.log;Verbosity=Normal
if errorlevel 1 goto BuildFail
goto BuildSuccess


:End
popd