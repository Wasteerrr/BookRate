
## CI/CD - GitHub Actions

Projekt wykorzystuje GitHub Actions do automatycznego budowania i testowania aplikacji .NET Web API.

### Jak działa workflow?

- Automatycznie uruchamia się po każdym `push` na gałąź `main`.
- Etapy:
  1. Przygotowanie środowiska
  2. Budowanie aplikacji
  3. Publikowanie aplikacji (release)

Workflow znajduje się w `.github/workflows/main_bookrate.yml`.



## Wdrożenie API w Azure

Aplikacja została wdrożona do chmury Microsoft Azure przy użyciu Azure App Service oraz Azure SQL Database.

### Publiczny adres aplikacji

API jest publicznie dostępne pod adresem: https://bookrate-caedf8aeeyd2fgd2.canadacentral-01.azurewebsites.net/swagger/index.html

### Wykorzystane usługi Azure

- Azure App Service – hostuje aplikację ASP.NET Core Web API (BookRate)
- Azure SQL Database – relacyjna baza danych dostępna z poziomu chmury
- Azure Active Directory (AAD) – wykorzystane do bezpiecznego logowania GitHub Actions przy wdrożeniu (przez `azure/login`)
