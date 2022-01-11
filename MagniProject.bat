echo off
WHERE dotnet ef
IF %ERRORLEVEL% NEQ 0 START /WAIT powershell -Command "dotnet tool install --global dotnet-ef --version 3.0.0"
START /WAIT powershell -Command "SqlLocalDb.exe create "MagniProject" -s"
START /WAIT powershell -Command "SqlLocalDB.exe start "MagniProject"" 
xcopy "%~dp0\data\MagniProject.mdf" "%HOMEDRIVE%%HOMEPATH%"  
xcopy "%~dp0\data\MagniProject_log.ldf" "%HOMEDRIVE%%HOMEPATH%" 
EXIT /B
cd  %~dp0\BackEnd\MagniFinance\MagniFinance
START /WAIT powershell -Command "dotnet ef Database update" 
cd ..
cd .. 
cd ..
cd %~dp0\frontend
if exist client-win32-x64 goto yesfile
if not exist client-win32-x64 goto nofile
goto end
:yesfile
cd client-win32-x64
start client.exe
goto end
:nofile
echo "Unzipping file..."
START /WAIT powershell -Command "Expand-Archive client-win32-x64.zip -DestinationPath %~dp0\frontend"
echo "Done!"
cd client-win32-x64
start client.exe
goto end
:end
EXIT /B
