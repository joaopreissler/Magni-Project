echo off
START /WAIT powershell -Command "SqlLocalDb.exe create "MagniProject" -s"
START /WAIT powershell -Command "SqlLocalDB.exe start "MagniProject"" 
cd  %~dp0\BackEnd\MagniFinance\MagniFinance
START /WAIT powershell -Command "dotnet ef Database update" 
START /WAIT powershell -Command "dotnet ef Database update" 
cd ..
cd .. 
cd ..
cd %~dp0\frontend
if exist client-win32-x64 goto yesfile
if not exist c:\test\file.txt goto nofile
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
