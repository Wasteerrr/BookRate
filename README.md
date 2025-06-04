
## CI/CD - GitHub Actions

Projekt wykorzystuje GitHub Actions do automatycznego budowania i testowania aplikacji .NET Web API.

### Jak działa workflow?

- Automatycznie uruchamia się po każdym `push` na gałąź `main`.
- Etapy:
  1. Przygotowanie środowiska
  2. Budowanie aplikacji
  3. Testowanie

Workflow znajduje się w `.github/workflows/main_bookrate.yml`.


  ## 