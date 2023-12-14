# Uitvoeren van de applicatie
1. Open de map TDD in Visual Studio Code.
2. Kies bovenaan voor `Terminal`.
3. Kies voor `New Terminal`.
4. Typ de volgende instructies uit:

```bash
docker build -t tddserver .
docker run -p 80:8080 tddserver
```

Ga hierna naar: [WeatherForecast](http://localhost/WeatherForecast)

## Potentiele fouten
### Error
```
docker: Error response from daemon: driver failed programming external connectivity on endpoint great_haibt (cef2eea5a787d480d3d7782d91386c2f4db667964d67aaf27603e35933b6ffb7): Bind for 0.0.0.0:80 failed: port is already allocated.
```
### Oplossing
Je applicatie draait al, bezoek het. Je kan ook de containers uit je docker verwijderen om de fout te omzijlen.

# Git commands
## Lokale main up to date maken met remote main
```bash
git checkout main
git pull
```

## Lokale branch up to date maken met lokale main
```bash
git pull origin main
git push
```

## Lokale branch naar de remote yeeten
```bash
git add .
git commit -m "My amazing commit-message"
git push
```

## Nieuwe branch maken
```bash
git branch myamazingbranch
```

OF

```bash
git checkout -b myamazingbranch
```
