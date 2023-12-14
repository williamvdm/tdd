@echo off

docker build -t tddserver .
docker run -p 80:8080 tddserver

if %errorlevel% == 125 (
    echo De poort is in gebruik, sluit wat de poort gebruikt of kies een andere poort.
) else if %errorlevel% == 0 (
    echo Successvol
) else (
    echo Een onbekende fout is opgetreden. Tijd om te debuggen, hoera. ERROR %errorlevel%
)
pause
