# 07 - DevOps

# CompLab MFR/T

## DevOps MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition

Powiązane dokumenty:

```text
01-Architecture-Overview.md
03-Technology-Decision.md
06-Security.md
09-Deployment.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest określenie minimalnego procesu DevOps dla realizacji MVP systemu CompLab MFR/T.

Zakres obejmuje:

- repozytorium Git,
- zarządzanie kodem,
- proces Pull Request,
- budowanie aplikacji,
- testowanie,
- Docker Compose,
- wdrożenia.

Priorytetem MVP jest:

- prostota,
- szybkość wdrażania,
- mały koszt utrzymania.

---

# 2. Założenia

## Cele

- centralne repozytorium kodu,
- prosty proces wdrożeniowy,
- powtarzalne środowisko uruchomieniowe,
- podstawowa automatyzacja budowania.

---

## Zakres MVP

Obowiązkowe:

```text
GitHub
Pull Requests
Docker Compose
Build
Test
```

---

## Poza zakresem MVP

```text
Kubernetes
SonarQube
Canary Deployment
Blue-Green Deployment
Observability Platform
DevSecOps Enterprise
```

---

# 3. Repozytorium

## Platforma

```text
GitHub
```

---

## Struktura głównych gałęzi

```text
main
develop
feature/*
```

---

## Przeznaczenie

### main

Stabilna wersja aplikacji.

---

### develop

Bieżące prace integracyjne.

---

### feature/*

Implementacja funkcjonalności.

Przykłady:

```text
feature/auth

feature/mixtures

feature/samples

feature/tests

feature/dashboard
```

---

# 4. Konwencja commitów

Projekt wykorzystuje:

```text
Conventional Commits
```

---

## Przykłady

### Nowa funkcjonalność

```text
feat: dodano rejestrację próbek
```

---

### Poprawka błędu

```text
fix: poprawiono walidację mieszaniny
```

---

### Refaktoryzacja

```text
refactor: uproszczono serwis badań
```

---

### Dokumentacja

```text
docs: aktualizacja modelu danych
```

---

# 5. Pull Requests

Każda zmiana powinna przechodzić przez Pull Request.

---

## Minimalne wymagania

- brak konfliktów,
- aplikacja buduje się poprawnie,
- podstawowe testy przechodzą,
- przegląd wykonany przez minimum jedną osobę.

---

# 6. Środowiska

W MVP wykorzystywane są jedynie dwa środowiska.

---

## DEV

Środowisko programistyczne.

Przeznaczenie:

```text
Programowanie
Testy lokalne
```

---

## PROD

Środowisko produkcyjne.

Przeznaczenie:

```text
Użytkownicy końcowi
```

---

# 7. Wersjonowanie

Format:

```text
MAJOR.MINOR.PATCH
```

Przykłady:

```text
0.1.0
0.5.0
1.0.0
```

---

## Zasady

### MAJOR

Istotna zmiana architektury.

---

### MINOR

Nowa funkcjonalność.

---

### PATCH

Poprawka błędu.

---

# 8. Build

## Backend

```bash
dotnet restore

dotnet build
```

---

## Testy

```bash
dotnet test
```

---

## Frontend

```bash
npm install

npm run build
```

---

# 9. GitHub Actions

W MVP wykorzystujemy prosty workflow.

---

## Zakres

Uruchamiany dla:

```text
Pull Request

develop

main
```

---

## Kroki

```text
Checkout

↓

Restore

↓

Build

↓

Tests
```

---

# 10. Docker

## Cel

Zapewnienie identycznych środowisk uruchomieniowych.

---

## Komponenty

```text
Frontend

Backend

PostgreSQL
```

---

# 11. Docker Compose

## Usługi

```yaml
web:
api:
postgres:
```

---

## Uruchomienie

```bash
docker compose up -d
```

---

## Zatrzymanie

```bash
docker compose down
```

---

# 12. Zarządzanie konfiguracją

## Konfiguracja środowiskowa

Backend:

```text
appsettings.Development.json

appsettings.Production.json
```

---

Frontend:

```text
environment.ts

environment.prod.ts
```

---

## Sekrety

Nie przechowujemy:

```text
haseł

tokenów

connection stringów
```

w repozytorium.

---

# 13. Migracje bazy danych

Mechanizm:

```text
Entity Framework Core Migrations
```

---

## Tworzenie migracji

```bash
dotnet ef migrations add InitialCreate
```

---

## Aktualizacja bazy

```bash
dotnet ef database update
```

---

# 14. Kopie zapasowe

## PostgreSQL

Minimalna strategia MVP:

```text
1 backup dziennie
```

---

## Retencja

```text
30 dni
```

---

# 15. Wdrożenie MVP

## Platforma

```text
Linux Ubuntu Server LTS
```

---

## Stos wdrożeniowy

```text
Angular

ASP.NET Core

PostgreSQL

Docker Compose
```

---

## Diagram

```text
Przeglądarka

     |

Angular

     |

ASP.NET Core API

     |

PostgreSQL
```

---

# 16. Kryteria gotowości do wdrożenia

## Kod

- projekt kompiluje się,
- brak błędów krytycznych,
- Pull Request zaakceptowany.

---

## Testy

- testy jednostkowe zakończone sukcesem,
- testy API zakończone sukcesem.

---

## Infrastruktura

- baza danych działa,
- backup skonfigurowany,
- HTTPS aktywny.

---

# 17. Rozwój po MVP

## Wersja 2

Planowane wdrożenie:

```text
GitHub Actions CI/CD

Automatyczne wdrożenia

Serilog

Monitoring aplikacji
```

---

## Wersja 3

Planowane wdrożenie:

```text
Kubernetes

Observability

Dashboard operacyjny

Automatyczny provisioning środowisk
```

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
03-Technology-Decision.md
06-Security.md
08-Testing-Strategy.md
09-Deployment.md
```

---

# Lista kontrolna MVP

## Repozytorium

- [ ] GitHub skonfigurowany
- [ ] Branch main utworzony
- [ ] Branch develop utworzony
- [ ] Pull Request wymagany

---

## Build

- [ ] Backend buduje się poprawnie
- [ ] Frontend buduje się poprawnie

---

## Testy

- [ ] Testy jednostkowe działają
- [ ] Testy API działają

---

## Wdrożenie

- [ ] Docker Compose działa
- [ ] PostgreSQL działa
- [ ] HTTPS aktywny

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie procesu DevOps dla MVP |
