# 03 - Decyzje Technologiczne

# CompLab MFR/T

## Analiza i Uzasadnienie Wyboru Technologii MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition  
**Powiązanie:** Dokument rozwija założenia przedstawione w:

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest przedstawienie uproszczonego stosu technologicznego dla wersji MVP systemu CompLab MFR/T.

Priorytetami projektu są:

- szybka implementacja,
- niski koszt utrzymania,
- prostota architektury,
- łatwość rozwoju,
- możliwość dostarczenia MVP przez zespół 2–5 programistów w czasie 4–8 tygodni.

---

# 2. Kryteria wyboru technologii

## Kryteria biznesowe

- szybkie wdrożenie,
- niski koszt utrzymania,
- łatwa rekrutacja programistów,
- brak kosztów licencyjnych.

---

## Kryteria techniczne

- prostota rozwiązania,
- wysoka stabilność,
- dobra dokumentacja,
- łatwe testowanie,
- możliwość dalszej rozbudowy.

---

## Kryteria organizacyjne

- łatwy onboarding nowych członków zespołu,
- czytelna struktura projektu,
- minimalna liczba technologii.

---

# 3. Architektura rozwiązania

## Wybrany styl architektoniczny

```text
Modular Monolith
```

---

## Architektura logiczna

```text
Frontend (Angular)

        │

        REST API

        │

Backend (.NET 8)

        │

Entity Framework Core

        │

PostgreSQL
```

---

## Uzasadnienie

Dla projektu tej wielkości zastosowanie:

```text
Mikroserwisów
CQRS
Event Sourcing
Service Bus
```

nie przynosi korzyści biznesowych i znacząco zwiększa koszt implementacji.

---

# 4. Frontend

## Analizowane technologie

### Angular

Zalety:

- pełny framework,
- gotowa struktura projektu,
- silna typizacja,
- dobre wsparcie dla dużych formularzy,
- łatwy rozwój aplikacji biznesowych.

---

### React

Zalety:

- popularność,
- elastyczność.

Wady:

- konieczność składania wielu bibliotek.

---

## Rekomendacja

```text
Angular
```

---

## Wersja

```text
Aktualna stabilna wersja LTS
```

---

# 5. Biblioteki frontendowe

## ngx-admin

Przeznaczenie:

- gotowy panel administracyjny,
- dashboard,
- nawigacja,
- layout.

---

## Nebular

Przeznaczenie:

- formularze,
- tabele,
- okna dialogowe,
- komponenty UI.

---

## RxJS

Przeznaczenie:

- komunikacja z API,
- obsługa asynchroniczna.

---

# 6. Backend

## Wybrana technologia

```text
ASP.NET Core 8
```

---

## Uzasadnienie

- wysoka wydajność,
- dobra integracja z PostgreSQL,
- łatwe wdrożenia,
- długoterminowe wsparcie,
- szeroka dostępność programistów.

---

# 7. ORM

## Wybrana technologia

```text
Entity Framework Core
```

---

## Podejście

```text
Code First
```

---

## Uzasadnienie

- szybkie tworzenie modelu danych,
- migracje bazy danych,
- łatwe utrzymanie projektu.

---

# 8. Baza danych

## Analizowane rozwiązania

### PostgreSQL

Zalety:

- Open Source,
- stabilność,
- wysoka wydajność,
- brak ograniczeń licencyjnych.

---

### SQL Server Express

Zalety:

- integracja z .NET.

Wady:

- ograniczenia wersji Express.

---

# Rekomendacja

```text
PostgreSQL
```

---

# 9. Model aplikacyjny

## MVP

Nie stosujemy:

```text
CQRS
MediatR
Event Sourcing
Domain Events
```

---

## Podejście

```text
Controller
↓
Application Service
↓
Repository
↓
Database
```

---

## Uzasadnienie

MVP wymaga prostoty oraz szybkiej implementacji.

---

# 10. Walidacja danych

## Wybrana technologia

```text
DataAnnotations
```

---

## Przykład

```csharp
[Required]
[StringLength(50)]
public string SampleNumber { get; set; }
```

---

## Uzasadnienie

Na etapie MVP nie ma potrzeby wdrażania dodatkowych bibliotek walidacyjnych.

---

# 11. Uwierzytelnianie

## Wybrana technologia

```text
JWT Bearer Authentication
```

---

## Role

```text
Administrator
Operator
```

---

## Zakres MVP

Nie obejmuje:

```text
MFA
Refresh Tokens
SSO
Active Directory
```

---

# 12. Logowanie aplikacyjne

## Wybrane rozwiązanie

```text
ILogger
```

---

## Zakres

- błędy aplikacji,
- błędy API,
- zdarzenia krytyczne.

---

## Funkcjonalności odłożone

```text
Serilog
Centralizacja logów
SIEM
```

---

# 13. Testowanie

## Testy jednostkowe

Technologia:

```text
xUnit
FluentAssertions
```

---

## Testy API

Technologia:

```text
Swagger
Postman
```

---

## Testy E2E

Technologia:

```text
Playwright
```

---

# 14. Konteneryzacja

## Wybrane rozwiązanie

```text
Docker Compose
```

---

## Usługi

```text
Frontend
Backend
PostgreSQL
```

---

## Uzasadnienie

Najprostszy sposób uruchamiania środowiska lokalnego i produkcyjnego.

---

# 15. CI/CD

## MVP

Możliwe ręczne wdrożenia.

---

## Opcjonalnie

```text
GitHub Actions
```

Zakres:

```text
Build
Test
```

---

# 16. Technologie odłożone do kolejnych wersji

## Wersja 2

```text
QuestPDF
ClosedXML
Serilog
FluentValidation
```

---

## Wersja 3

```text
CQRS
MediatR
Dashboard KPI
Integracja urządzeń laboratoryjnych
```

---

# 17. Ostateczny stack technologiczny MVP

## Frontend

```text
Angular
ngx-admin
Nebular
RxJS
```

---

## Backend

```text
ASP.NET Core 8
```

---

## ORM

```text
Entity Framework Core
```

---

## Baza danych

```text
PostgreSQL
```

---

## Autoryzacja

```text
JWT
```

---

## Testy

```text
xUnit
Swagger
Postman
Playwright
```

---

## Konteneryzacja

```text
Docker Compose
```

---

# Podsumowanie decyzji

| Obszar | Technologia MVP |
|----------|----------|
| Frontend | Angular |
| UI | ngx-admin + Nebular |
| Backend | ASP.NET Core 8 |
| ORM | Entity Framework Core |
| Baza danych | PostgreSQL |
| Autoryzacja | JWT |
| Testy jednostkowe | xUnit |
| Testy API | Postman |
| Testy E2E | Playwright |
| Konteneryzacja | Docker Compose |

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pełna architektura docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie stosu technologicznego do MVP |
