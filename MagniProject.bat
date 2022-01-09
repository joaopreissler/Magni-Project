echo off
cd %~dp0\BackEnd\MagniFinance\MagniFinance\bin\Debug\net5.0
start MagniFinance.exe
cd ..
cd .. 
cd ..
cd ..
cd ..
cd ..
cd frontend\client
call npm run electron - build
