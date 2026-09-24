# Diagram Architektury Systemu

# CompLab MFR/T

## Architektura Logiczna i Fizyczna

**Wersja:** 1.0  
**Status:** Ready for Development

---

# Cel diagramu

Diagram przedstawia wysokopoziomową architekturę systemu CompLab MFR/T zgodną z:

- Clean Architecture,
- Domain-Driven Design (DDD),
- CQRS,
- DevSecOps,
- dobrymi praktykami LIMS.

Diagram pokazuje zależności pomiędzy użytkownikami, warstwami aplikacji, infrastrukturą oraz komponentami odpowiedzialnymi za raportowanie i archiwizację danych laboratoryjnych.

---

# Architektura systemu

```mermaid
flowchart TB

    USER1[Laborant]
    USER2[Kierownik Laboratorium]
    USER3[Administrator]
    USER4[Audytor]

    USER1 --> WEB
    USER2 --> WEB
    USER3 --> WEB
    USER4 --> WEB

    subgraph Frontend
        WEB[Next.js + React + TypeScript]
    end

    WEB --> API

    subgraph Backend [.NET 8 Web API]

        API[Controllers / REST API]

        APP[Application Layer<br/>CQRS + MediatR]

        DOMAIN[Domain Layer<br/>DDD + Business Rules]

        INFRA[Infrastructure Layer]

        API --> APP
        APP --> DOMAIN
        APP --> INFRA

    end

    INFRA --> DB
    INFRA --> FILES
    INFRA --> REPORTS

    REPORTS --> FILES

    DB --> BACKUP
    FILES --> BACKUP

    subgraph Data Storage

        DB[(PostgreSQL 16)]

        FILES[(Raporty PDF<br/>CSV<br/>XLSX)]

        BACKUP[(Backup Storage)]

    end

    subgraph Reporting

        REPORTS[QuestPDF<br/>Eksport CSV<br/>Eksport XLSX]

    end
```

---

# Architektura Clean Architecture

```mermaid
flowchart TB

UI[Presentation Layer]

APP[Application Layer]

DOMAIN[Domain Layer]

INFRA[Infrastructure Layer]

UI --> APP

APP --> DOMAIN

APP --> INFRA

INFRA --> DB[(PostgreSQL)]

INFRA --> STORAGE[(File Storage)]
```

---

# Architektura CQRS

```mermaid
flowchart LR

USER[Użytkownik]

COMMANDS[Commands]

QUERIES[Queries]

APP[Application Layer]

DOMAIN[Domain]

DB[(PostgreSQL)]

USER --> COMMANDS
USER --> QUERIES

COMMANDS --> APP
QUERIES --> APP

APP --> DOMAIN

DOMAIN --> DB

DB --> QUERIES
```

---

# Architektura wdrożeniowa

```mermaid
flowchart TB

CLIENT[Przeglądarka użytkownika]

NGINX[Nginx Reverse Proxy]

WEB[Frontend Next.js]

API[Backend .NET 8]

POSTGRES[(PostgreSQL)]

STORAGE[(File Storage)]

BACKUP[(Backup Storage)]

CLIENT --> NGINX

NGINX --> WEB

NGINX --> API

API --> POSTGRES

API --> STORAGE

POSTGRES --> BACKUP

STORAGE --> BACKUP
```

---

# Przepływ danych laboratoryjnych

```mermaid
flowchart LR

A[Utworzenie mieszaniny]

B[Rejestracja próbki]

C[Utworzenie serii badawczej]

D[Badanie MFR]

E[Badanie wytrzymałościowe]

F[Analiza statystyczna]

G[Walidacja zgodności<br/>PN-EN 1338 / PN-EN 1339]

H[Raport PDF]

I[Archiwizacja]

A --> B

B --> C

C --> D

C --> E

D --> F

E --> F

F --> G

G --> H

H --> I
```

---

# Komponenty systemu

## Frontend

Odpowiedzialność:

- formularze laboratoryjne,
- dashboardy,
- wykresy,
- raporty,
- autoryzacja użytkowników.

Technologie:

```text
Next.js
React
TypeScript
Apache ECharts
```

---

## Warstwa Aplikacyjna

Odpowiedzialność:

- CQRS,
- obsługa przypadków użycia,
- walidacja,
- autoryzacja.

Technologie:

```text
ASP.NET Core
MediatR
FluentValidation
```

---

## Warstwa Domenowa

Odpowiedzialność:

- logika biznesowa,
- agregaty,
- encje,
- reguły zgodności,
- zdarzenia domenowe.

Technologie:

```text
C#
DDD
Clean Architecture
```

---

## Warstwa Infrastruktury

Odpowiedzialność:

- komunikacja z bazą danych,
- generowanie raportów,
- obsługa plików,
- logowanie.

Technologie:

```text
Entity Framework Core
PostgreSQL
QuestPDF
Serilog
```

---

## Magazyn danych

Przechowywane informacje:

- próbki,
- mieszaniny,
- serie badawcze,
- wyniki badań,
- raporty,
- logi audytowe.

Technologia:

```text
PostgreSQL 16
```

---

# Diagram zależności warstw

```mermaid
graph BT

DOMAIN[Domain]

APPLICATION[Application]

INFRASTRUCTURE[Infrastructure]

PRESENTATION[Presentation]

PRESENTATION --> APPLICATION

APPLICATION --> DOMAIN

APPLICATION --> INFRASTRUCTURE
```

---

# Wymagania architektoniczne

## MVP

- pojedynczy serwer aplikacyjny,
- PostgreSQL,
- Docker Compose,
- magazyn plików lokalny,
- backup automatyczny.

---

## Wersja V2

- dashboard KPI,
- monitoring infrastruktury,
- centralizacja logów.

---

## Wersja V3

- High Availability,
- Kubernetes,
- replikacja PostgreSQL,
- integracja urządzeń laboratoryjnych.
