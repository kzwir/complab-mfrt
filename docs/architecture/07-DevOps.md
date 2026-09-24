# 07 - DevOps

# CompLab MFR/T

## Strategia DevOps, CI/CD i Zarządzania Wdrożeniami

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Powiązanie:** Dokument rozszerza założenia przedstawione w dokumentach:

```text
01-Architecture-Overview.md
03-Technology-Decision.md
06-Security.md
09-Deployment.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest zdefiniowanie standardów DevOps dla projektu CompLab MFR/T obejmujących:

- zarządzanie kodem źródłowym,
- GitFlow,
- CI/CD,
- konteneryzację,
- zarządzanie środowiskami,
- automatyzację wdrożeń,
- kontrolę jakości,
- DevSecOps,
- monitorowanie systemu.

Dokument stanowi podstawę organizacji pracy zespołu programistycznego oraz przygotowania środowisk wdrożeniowych.

---

# 2. Założenia DevOps

## Cele

- skrócenie czasu dostarczania zmian,
- automatyzacja procesów,
- poprawa jakości oprogramowania,
- eliminacja błędów ręcznych wdrożeń,
- zapewnienie powtarzalności środowisk,
- wdrożenie praktyk DevSecOps.

---

## Zasady

### Automatyzacja

Każda czynność możliwa do zautomatyzowania powinna zostać objęta procesem CI/CD.

---

### Infrastructure as Code

Konfiguracja środowisk powinna być przechowywana w repozytorium Git.

---

### Shift Left

Testy jakościowe, bezpieczeństwa i zgodności powinny być wykonywane jak najwcześniej w cyklu życia aplikacji.

---

### Continuous Delivery

Każda zmiana po przejściu pipeline powinna być gotowa do wdrożenia.

---

# 3. Strategia GitFlow

Projekt wykorzystuje klasyczny model GitFlow.

---

## Struktura gałęzi

```text
main
develop
feature/*
release/*
hotfix/*
```

---

## Branch main

Przeznaczenie:

```text
Kod produkcyjny
```

Zasady:

- wyłącznie stabilne wersje,
- wyłącznie pull request,
- wymagane zatwierdzenie.

---

## Branch develop

Przeznaczenie:

```text
Integracja bieżących prac
```

---

## Branch feature/*

Przeznaczenie:

```text
Rozwój nowych funkcjonalności
```

Przykłady:

```text
feature/sample-management
feature/mfr-tests
feature/reporting
feature/dashboard
```

---

## Branch release/*

Przeznaczenie:

```text
Przygotowanie wersji wydawniczej
```

Przykład:

```text
release/1.0.0
```

---

## Branch hotfix/*

Przeznaczenie:

```text
Krytyczne poprawki produkcyjne
```

Przykład:

```text
hotfix/fix-jwt-validation
```

---

# 4. Konwencja Commitów

Projekt wykorzystuje standard:

```text
Conventional Commits
```

---

## Typy commitów

### Feature

```text
feat:
```

Przykład:

```text
feat: dodano rejestrację próbek
```

---

### Bug Fix

```text
fix:
```

Przykład:

```text
fix: poprawiono walidację MFR
```

---

### Refactoring

```text
refactor:
```

---

### Testy

```text
test:
```

---

### Dokumentacja

```text
docs:
```

---

### DevOps

```text
ci:
```

```text
build:
```

---

# 5. Strategia Pull Request

Każda zmiana musi przejść przez Pull Request.

---

## Wymagania

### Minimum 1 recenzent

```text
Tech Lead
lub
Senior Developer
```

---

### Pipeline CI

Musi zakończyć się sukcesem.

---

### Brak konfliktów

Pull Request nie może zawierać konfliktów.

---

### Aktualna gałąź

Branch musi być zgodny z aktualnym stanem develop.

---

# 6. Środowiska

System posiada cztery środowiska.

---

## DEV

Przeznaczenie:

```text
Prace programistyczne
```

---

## TEST

Przeznaczenie:

```text
Testy integracyjne
Testy QA
```

---

## UAT

Przeznaczenie:

```text
Testy akceptacyjne użytkowników
```

---

## PROD

Przeznaczenie:

```text
Środowisko produkcyjne
```

---

# 7. Strategia wersjonowania

Format:

```text
MAJOR.MINOR.PATCH
```

Przykłady:

```text
1.0.0
1.1.0
1.1.1
2.0.0
```

---

## Zasady

### MAJOR

Zmiana niekompatybilna.

---

### MINOR

Nowa funkcjonalność.

---

### PATCH

Poprawka błędu.

---

# 8. CI/CD

## Główne etapy pipeline

```text
Checkout
↓
Restore
↓
Build
↓
Static Analysis
↓
Unit Tests
↓
Integration Tests
↓
Security Scan
↓
Package
↓
Publish Artifact
↓
Deploy
```

---

# 9. GitHub Actions

Repozytorium wykorzystuje:

```text
GitHub Actions
```

Lokalizacja:

```text
.github/workflows
```

---

# 10. Pipeline Continuous Integration

## Workflow CI

Uruchamiany dla:

```text
develop
feature/*
pull request
```

---

### Kroki

#### Checkout

Pobranie kodu.

---

#### Restore

Pobranie zależności.

```bash
dotnet restore
```

---

#### Build

Kompilacja aplikacji.

```bash
dotnet build --configuration Release
```

---

#### Unit Tests

```bash
dotnet test
```

---

#### Code Coverage

Raport pokrycia kodu.

Minimalne pokrycie:

```text
80%
```

---

#### Static Analysis

Analiza jakości kodu.

Narzędzia:

```text
Roslyn Analyzers
SonarQube
```

---

# 11. Pipeline Continuous Delivery

Uruchamiany po:

```text
merge do branch release/*
```

---

### Kroki

```text
Build
↓
Tests
↓
Security Scan
↓
Docker Build
↓
Push Docker Image
↓
Deploy TEST
```

---

# 12. Pipeline Continuous Deployment

Uruchamiany dla:

```text
main
```

---

### Kroki

```text
Build
↓
Tests
↓
Package
↓
Version Tag
↓
Deploy PROD
```

---

# 13. Przykładowy Workflow GitHub Actions

```yaml
name: CI

on:
  pull_request:
  push:
    branches:
      - develop
      - main

jobs:

  build:

    runs-on: ubuntu-latest

    steps:

      - name: Checkout
        uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'

      - name: Restore
        run: dotnet restore

      - name: Build
        run: dotnet build --configuration Release --no-restore

      - name: Test
        run: dotnet test --configuration Release

      - name: Publish
        run: dotnet publish -c Release
```

---

# 14. Budowanie obrazów Docker

## Proces

```text
Build
↓
Tag
↓
Push
↓
Deploy
```

---

## Konwencja tagów

```text
complab-api:1.0.0
complab-web:1.0.0
```

---

## Najnowsza wersja

```text
latest
```

wyłącznie dla środowiska DEV.

---

# 15. Struktura Docker

## Frontend

```text
complab-web
```

---

## Backend

```text
complab-api
```

---

## PostgreSQL

```text
complab-postgres
```

---

# 16. Zarządzanie konfiguracją

## Zasada

Konfiguracja nie może być przechowywana w kodzie źródłowym.

---

## Konfiguracja środowiskowa

```text
DEV
TEST
UAT
PROD
```

---

## Przechowywanie sekretów

Rekomendowane:

```text
GitHub Secrets
```

lub

```text
HashiCorp Vault
```

---

## Zakazane

```text
Hasła w appsettings.json
Hasła w kodzie
Hasła w repozytorium
```

---

# 17. DevSecOps

## SAST

Statyczna analiza kodu.

Narzędzia:

```text
CodeQL
SonarQube
```

---

## Dependency Scan

Kontrola podatności bibliotek.

Narzędzia:

```text
Dependabot
OWASP Dependency Check
```

---

## Container Scan

Analiza obrazów Docker.

Narzędzia:

```text
Trivy
```

---

## Secret Scan

Wykrywanie wycieków sekretów.

Narzędzia:

```text
GitGuardian
Gitleaks
```

---

# 18. Strategia migracji bazy danych

## Mechanizm

```text
Entity Framework Core Migrations
```

---

## Proces

```text
Create Migration
↓
Review
↓
Merge
↓
Deploy
↓
Database Update
```

---

## Komenda

```bash
dotnet ef database update
```

---

# 19. Monitorowanie

## Logowanie

```text
Serilog
```

---

## Metryki

- liczba żądań,
- czas odpowiedzi,
- błędy API,
- błędy logowania,
- wykorzystanie zasobów.

---

## Alerty

Generowane przy:

```text
HTTP 500
Awaria bazy danych
Brak miejsca na dysku
Nieudany backup
```

---

# 20. Backup w procesie DevOps

## Baza danych

Codziennie:

```text
01:00
```

---

## Raporty

Codziennie:

```text
02:00
```

---

## Backup pełny

```text
Raz w tygodniu
```

---

# 21. Strategia wdrożenia MVP

## Technologia

```text
Docker Compose
```

---

## Serwer

```text
Linux Ubuntu LTS
```

---

## Składniki

```text
Nginx
Frontend
Backend
PostgreSQL
Storage
```

---

# 22. Kryteria jakości przed wdrożeniem

## Kod

- brak błędów kompilacji,
- brak błędów krytycznych SonarQube,
- code review zakończony.

---

## Testy

- testy jednostkowe zaliczone,
- testy integracyjne zaliczone,
- testy API zaliczone.

---

## Bezpieczeństwo

- brak podatności Critical,
- brak podatności High.

---

# 23. Roadmapa DevOps

## Wersja MVP

- GitHub Actions,
- Docker,
- GitFlow,
- automatyczne testy,
- automatyczne buildy.

---

## Wersja V2

- SonarQube,
- automatyczne wdrożenia UAT,
- dashboard jakości.

---

## Wersja V3

- Kubernetes,
- Blue-Green Deployment,
- Canary Release,
- pełne obserwowanie systemu (Observability).

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

# Lista kontrolna DevOps

## Repozytorium

- [ ] GitFlow skonfigurowany
- [ ] Branch Protection aktywny
- [ ] Pull Requests wymagane

## CI/CD

- [ ] Build automatyczny
- [ ] Testy automatyczne
- [ ] Security Scan automatyczny
- [ ] Docker Build automatyczny

## Środowiska

- [ ] DEV gotowe
- [ ] TEST gotowe
- [ ] UAT gotowe
- [ ] PROD gotowe

## Bezpieczeństwo

- [ ] GitHub Secrets skonfigurowane
- [ ] TLS aktywny
- [ ] Skanowanie obrazów Docker aktywne

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja dokumentu DevOps |
