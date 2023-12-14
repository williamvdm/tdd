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
Open een git-bash in de tdd-map.

```bash
git checkout main
git pull
```

## Lokale branch up to date maken met lokale main
Open een git-bash in de tdd-map.

```bash
git pull origin main
git push
```

## Lokale branch naar de remote yeeten
Open een git-bash in de tdd-map.

```bash
git add .
git commit -m "My amazing commit-message"
git push
```

## Nieuwe branch maken
Open een git-bash in de tdd-map.

```bash
git branch myamazingbranch
```

OF

Open een git-bash in de tdd-map.

```bash
git checkout -b myamazingbranch
```

# Pagina toevoegen
In de pages folder voeg je de pagina's toe.

## Components folder
### Nav.jsx
Daar zit de navigatie in. De bar aan de bovenkant zeg maar.

## Assets folder
Daar zitten assets in, zoals fonts, afbeeldingen en dergelijken.

## Node modules
Daar zitten de node-modules in.

## Pages folder
Daarin zitten de pagina's, hier moet je ook een nieuwe pagina toevoegen als je die nodig hebt.

# Kleur toevoegen
In `tailwind.config.js` kan je kleuren toevoegen met naam. Dan kan je die ook gebruiken in CSS etc.

# Om de applicatie de bouwen
```bash
npm run build
```

# On een pagina te beveiligen tegen oningelogde gebruikers
Check of de gebruiker is ingelogd, zo niet, redirect naar de login pagina.

# Q & A
## Wat is het verschil tussen een component en een pagina?
Een component is een deel van een pagina, en kan op meerder pagina's worden gebruikt.