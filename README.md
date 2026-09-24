# CompLab MFR/T

## Laboratory Information Management System (LIMS)

CompLab MFR/T jest aplikacją laboratoryjną przeznaczoną do rejestracji, analizy i raportowania wyników badań kompozytów polimerowo-kwarcytowych wykorzystywanych do produkcji elementów budowlanych, takich jak kostka brukowa, płyty, krawężniki oraz elementy ażurowe.

System wspiera procesy badawcze związane z:

- badaniami wskaźnika płynięcia polimerów MFR/MFI zgodnie z PN-EN ISO 1133,
- badaniami wytrzymałościowymi zgodnie z PN-EN 1338 oraz PN-EN 1339,
- archiwizacją próbek i serii badawczych,
- analizą statystyczną wyników,
- oceną zgodności z wymaganiami normowymi,
- generowaniem raportów laboratoryjnych,
- eksportem danych do formatów PDF, CSV oraz XLSX,
- wizualizacją danych laboratoryjnych.

---

# Cele biznesowe

Projekt ma na celu:

- cyfryzację procesu prowadzenia badań laboratoryjnych,
- eliminację rozproszonych arkuszy Excel,
- zapewnienie pełnej identyfikowalności wyników badań,
- usprawnienie archiwizacji danych laboratoryjnych,
- automatyzację tworzenia raportów,
- wsparcie audytów jakościowych i wymagań ISO 9001,
- zapewnienie zgodności z dobrymi praktykami LIMS.

---

# Zakres funkcjonalny

## Rejestracja danych

- próbki laboratoryjne,
- mieszaniny polimerowo-kwarcytowe,
- serie badawcze,
- badania MFR/MFI,
- badania wytrzymałościowe,
- parametry procesu technologicznego.

## Analiza wyników

- średnia,
- minimum,
- maksimum,
- mediana,
- odchylenie standardowe,
- analiza trendów,
- wykrywanie wyników poza zakresem.

## Raportowanie

- raporty PDF,
- eksport CSV,
- eksport XLSX,
- historia raportów.

## Wizualizacja

- wykresy MFR,
- wykresy wytrzymałości,
- porównania serii,
- analizy mieszanin.

---

# Architektura rozwiązania

Projekt został zaprojektowany zgodnie z:

- Clean Architecture,
- SOLID,
- Domain-Driven Design (DDD),
- CQRS (wybrane obszary raportowania i analiz),
- GitFlow,
- DevSecOps,
- OWASP ASVS,
- ISO 9001,
- dobrymi praktykami Laboratory Information Management System (LIMS).

---

# Stack technologiczny

## Frontend

- Next.js
- React
- TypeScript

## Backend

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MediatR
- FluentValidation

## Baza danych

- PostgreSQL 16

## Raportowanie

- QuestPDF

## Wizualizacja

- Apache ECharts

## Konteneryzacja

- Docker
- Docker Compose

## CI/CD

- GitHub Actions

---

# Dokumentacja projektu

Szczegółowa dokumentacja architektoniczna znajduje się w katalogu `docs`.

## Dokumenty architektoniczne

```text
docs/architecture/

├── 01-Architecture-Overview.md
├── 02-Domain-Analysis.md
├── 03-Technology-Decision.md
├── 04-Data-Model.md
├── 05-API-Design.md
├── 06-Security.md
├── 07-DevOps.md
├── 08-Testing-Strategy.md
├── 09-Deployment.md
└── diagrams/
```

### Zawartość dokumentacji

| Dokument | Opis |
|-----------|-------|
| 01-Architecture-Overview.md | Założenia architektoniczne, architektura logiczna i fizyczna |
| 02-Domain-Analysis.md | Analiza domeny, DDD, agregaty, encje, reguły biznesowe |
| 03-Technology-Decision.md | Uzasadnienie wyboru technologii |
| 04-Data-Model.md | Model danych i opis struktur bazy |
| 05-API-Design.md | Specyfikacja REST API |
| 06-Security.md | Bezpieczeństwo, RBAC, JWT, audyt |
| 07-DevOps.md | GitFlow, CI/CD, strategie wdrożeń |
| 08-Testing-Strategy.md | Strategia testowania |
| 09-Deployment.md | Środowiska i wdrożenie produkcyjne |

---

# Diagramy

Diagramy Mermaid są przechowywane jako osobne pliki:

```text
docs/architecture/diagrams/

├── architecture.mmd
├── erd.mmd
└── process-flow.mmd
```

Opis:

- architecture.mmd – diagram architektury systemu,
- erd.mmd – diagram modelu danych,
- process-flow.mmd – przebieg procesu laboratoryjnego.

---

# Architecture Decision Records (ADR)

Decyzje architektoniczne są dokumentowane jako ADR.

```text
docs/decisions/
```

Każdy ADR powinien zawierać:

- kontekst decyzji,
- rozważane warianty,
- uzasadnienie wyboru,
- konsekwencje techniczne,
- wpływ na rozwój systemu.

---

# Struktura repozytorium

```text
complab-mfrt/

├── docs/
│   ├── architecture/
│   └── decisions/
│
├── src/
│
├── database/
│
├── deployment/
│
├── .github/
│   └── workflows/
│
├── docker-compose.yml
└── README.md
```

---

# Uruchomienie projektu

## Wymagania

- .NET 8 SDK
- Node.js LTS
- PostgreSQL 16
- Docker Desktop

## Klonowanie repozytorium

```bash
git clone <repository-url>
```

## Uruchomienie środowiska

```bash
docker compose up -d
```

---

# Roadmapa

## MVP

- próbki,
- mieszaniny,
- serie badawcze,
- badania MFR,
- badania wytrzymałościowe,
- raporty PDF,
- eksport CSV.

## V2

- dashboardy laboratoryjne,
- zaawansowana statystyka,
- raporty porównawcze.

## V3

- integracja urządzeń laboratoryjnych,
- automatyczny import wyników,
- zaawansowane analizy jakościowe.

---

# Zespół projektowy

Projekt realizowany zgodnie z metodyką:

- Product Owner
- Solution Architect
- Tech Lead
- Backend Developers
- Frontend Developers
- QA Engineer
- DevOps Engineer

---

# Status

**Version:** 1.0

**Status:** Ready for Development

**Architecture:** Clean Architecture + DDD + CQRS + DevSecOps

**Project Type:** Laboratory Information Management System (LIMS)
