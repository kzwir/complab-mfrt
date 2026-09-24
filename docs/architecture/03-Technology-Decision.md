# 03 - Decyzje Technologiczne

# CompLab MFR/T

## Analiza i Uzasadnienie Wyboru Technologii

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Powiązanie:** Dokument stanowi rozwinięcie założeń opisanych w `01-Architecture-Overview.md` oraz modelu domenowego z `02-Domain-Analysis.md`.

---

# 1. Cel dokumentu

Celem dokumentu jest przedstawienie analizy dostępnych technologii oraz udokumentowanie decyzji architektonicznych dotyczących budowy systemu CompLab MFR/T.

Dla każdej warstwy rozwiązania przeanalizowano:

- aspekty techniczne,
- aspekty biznesowe,
- koszty wdrożenia,
- koszty utrzymania,
- skalowalność,
- zgodność z wymaganiami projektu.

Efektem dokumentu jest rekomendowany stack technologiczny dla pierwszej wersji produkcyjnej systemu.

---

# 2. Kryteria oceny technologii

Podczas wyboru technologii przyjęto następujące kryteria.

## Kryteria techniczne

- zgodność z Clean Architecture,
- wsparcie dla DDD,
- łatwość implementacji CQRS,
- dojrzałość ekosystemu,
- wydajność,
- bezpieczeństwo,
- wsparcie testów automatycznych.

---

## Kryteria biznesowe

- dostępność programistów na rynku,
- koszt wdrożenia,
- koszt utrzymania,
- możliwość dalszego rozwoju,
- minimalizacja ryzyka technologicznego.

---

## Kryteria organizacyjne

- łatwość onboardingu nowych programistów,
- czytelność kodu,
- zgodność z GitFlow i DevOps,
- dostępność dokumentacji.

---

# 3. Wybór technologii Frontend

## Analizowane technologie

### React

#### Zalety

- bardzo duża popularność,
- ogromny ekosystem bibliotek,
- łatwość integracji z REST API,
- wsparcie TypeScript.

#### Wady

- wymaga samodzielnego doboru wielu komponentów architektonicznych,
- brak narzuconej struktury projektu.

---

### Next.js

#### Zalety

- oparty o React,
- gotowa struktura projektu,
- wsparcie TypeScript,
- dobra organizacja aplikacji,
- łatwa obsługa uwierzytelniania,
- przygotowany pod rozwój produktu.

#### Wady

- nieco większa złożoność niż czysty React.

---

### Vue

#### Zalety

- prosty próg wejścia,
- czytelna składnia.

#### Wady

- mniejsza dostępność specjalistów,
- mniejsza popularność w projektach korporacyjnych.

---

### Angular

#### Zalety

- pełny framework,
- silna typizacja,
- dobra organizacja kodu.

#### Wady

- większa złożoność,
- wyższy koszt utrzymania,
- dłuższy czas wdrożenia nowych programistów.

---

# Rekomendacja Frontend

## Wybrana technologia

```text
Next.js + React + TypeScript
```

### Uzasadnienie techniczne

- wsparcie dla dużych projektów,
- łatwa organizacja modułów,
- doskonała integracja z API REST,
- szerokie wsparcie bibliotek wizualizacyjnych.

### Uzasadnienie biznesowe

- łatwa dostępność programistów,
- duża społeczność,
- niższy koszt rozwoju.

### Uzasadnienie kosztowe

- brak kosztów licencyjnych,
- rozwiązanie Open Source.

---

# 4. Wybór technologii Backend

## Analizowane technologie

### .NET 8

#### Zalety

- bardzo dobra obsługa DDD,
- bardzo dobra obsługa CQRS,
- rozwinięte mechanizmy bezpieczeństwa,
- Entity Framework Core,
- MediatR,
- FluentValidation,
- wysoka wydajność.

#### Wady

- wymaga znajomości ekosystemu Microsoft.

---

### Spring Boot

#### Zalety

- bardzo dojrzały framework,
- duże możliwości integracyjne.

#### Wady

- większa ilość kodu konfiguracyjnego,
- wyższy koszt utrzymania.

---

### FastAPI

#### Zalety

- szybkie tworzenie API,
- prostota.

#### Wady

- słabsza kontrola typów,
- mniejsza standaryzacja dla dużych projektów.

---

### NestJS

#### Zalety

- nowoczesna architektura,
- dobra obsługa TypeScript.

#### Wady

- mniejsza wydajność obliczeniowa,
- mniej dojrzałe biblioteki raportowe.

---

# Rekomendacja Backend

## Wybrana technologia

```text
.NET 8
```

### Uzasadnienie techniczne

- najlepsze dopasowanie do Clean Architecture,
- dobra obsługa DDD,
- silna typizacja,
- bardzo dobre biblioteki raportujące.

### Uzasadnienie biznesowe

- szeroka dostępność specjalistów,
- długoterminowe wsparcie.

### Uzasadnienie kosztowe

- brak kosztów licencyjnych dla środowiska Linux.

---

# 5. Wybór bazy danych

## Analizowane technologie

### PostgreSQL

#### Zalety

- Open Source,
- bardzo wysoka stabilność,
- wsparcie JSON,
- zaawansowane indeksowanie,
- możliwość dalszego rozwoju.

#### Wady

- wymaga podstawowej administracji.

---

### SQL Server Express

#### Zalety

- dobra integracja z .NET.

#### Wady

- ograniczenia wielkości bazy,
- ograniczenia wydajnościowe.

---

### MariaDB

#### Zalety

- prostota wdrożenia.

#### Wady

- mniej możliwości analitycznych niż PostgreSQL.

---

# Rekomendacja Bazy Danych

## Wybrana technologia

```text
PostgreSQL 16
```

### Uzasadnienie

- brak ograniczeń licencyjnych,
- wysoka wydajność,
- bardzo dobra współpraca z Entity Framework Core.

---

# 6. Mapowanie ORM

## Analiza

### Dapper

#### Zalety

- bardzo szybki.

#### Wady

- większa ilość kodu.

---

### Entity Framework Core

#### Zalety

- migracje,
- wsparcie DDD,
- obsługa Repository Pattern,
- łatwość utrzymania.

#### Wady

- nieco niższa wydajność dla bardzo dużych zapytań.

---

# Rekomendacja

```text
Entity Framework Core
```

---

# 7. Mechanizm CQRS

## Analiza

### Bez CQRS

#### Zalety

- prostsza implementacja.

#### Wady

- trudniejszy rozwój raportowania.

---

### CQRS

#### Zalety

- separacja odczytu od zapisu,
- łatwiejsze dashboardy,
- łatwiejsza rozbudowa.

#### Wady

- większa liczba klas.

---

# Rekomendacja

```text
CQRS tylko dla warstwy aplikacyjnej
```

Technologia:

```text
MediatR
```

---

# 8. Walidacja danych

## Analiza

### DataAnnotations

#### Zalety

- prostota.

#### Wady

- ograniczone możliwości.

---

### FluentValidation

#### Zalety

- czytelne reguły,
- łatwe testowanie,
- zgodność z DDD.

#### Wady

- dodatkowa biblioteka.

---

# Rekomendacja

```text
FluentValidation
```

---

# 9. Generowanie raportów

## Analizowane technologie

### QuestPDF

#### Zalety

- nowoczesne API,
- bardzo dobra integracja z .NET,
- łatwość utrzymania.

#### Wady

- wymaga programistycznego budowania raportów.

---

### FastReport

#### Zalety

- edytor wizualny.

#### Wady

- dodatkowe koszty przy rozwoju.

---

### RDLC

#### Zalety

- znane rozwiązanie Microsoft.

#### Wady

- technologia rozwijana w ograniczonym zakresie.

---

### JasperReports

#### Zalety

- bardzo zaawansowany.

#### Wady

- najlepiej współpracuje z Javą.

---

# Rekomendacja

```text
QuestPDF
```

---

# 10. Wizualizacja danych

## Analizowane technologie

### Chart.js

#### Zalety

- prostota.

#### Wady

- ograniczone możliwości analityczne.

---

### Recharts

#### Zalety

- dobra integracja z React.

#### Wady

- mniejsza liczba typów wykresów.

---

### Apache ECharts

#### Zalety

- bardzo bogaty zestaw wykresów,
- wysoka wydajność,
- możliwość budowy dashboardów laboratoryjnych.

#### Wady

- większa liczba opcji konfiguracji.

---

# Rekomendacja

```text
Apache ECharts
```

---

# 11. Eksport danych

## PDF

Przeznaczenie:

- raporty laboratoryjne,
- dokumentacja badań.

Technologia:

```text
QuestPDF
```

---

## CSV

Przeznaczenie:

- szybka analiza danych,
- import do Excel.

---

## XLSX

Przeznaczenie:

- raportowanie zarządcze,
- zaawansowana analiza.

Biblioteka:

```text
ClosedXML
```

---

# 12. Logowanie i monitoring

## Logowanie aplikacyjne

Technologia:

```text
Serilog
```

---

## Cele

- diagnostyka błędów,
- śledzenie problemów,
- wspomaganie audytu.

---

## Typy logów

```text
Information
Warning
Error
Critical
Audit
```

---

# 13. Testowanie

## Testy jednostkowe

Technologia:

```text
xUnit
```

---

## Testy integracyjne

Technologia:

```text
xUnit
Testcontainers
```

---

## Testy API

Technologia:

```text
Postman
Newman
```

---

## Testy wydajnościowe

Technologia:

```text
k6
```

---

# 14. Konteneryzacja

## Analizowane technologie

### Docker

#### Zalety

- prostota,
- szerokie wsparcie.

---

### Kubernetes

#### Zalety

- wysoka skalowalność.

#### Wady

- nadmiarowa złożoność dla projektu tej wielkości.

---

# Rekomendacja

## MVP

```text
Docker Compose
```

## Przyszłość

```text
Kubernetes
```

jeżeli liczba użytkowników znacząco wzrośnie.

---

# 15. CI/CD

## Rekomendacja

```text
GitHub Actions
```

Obsługiwane etapy:

```text
Build
Test
Security Scan
Code Quality
Package
Deploy
```

---

# 16. Ostateczny rekomendowany stack technologiczny

## Frontend

```text
Next.js
React
TypeScript
Tailwind CSS
```

---

## Backend

```text
.NET 8
ASP.NET Core
MediatR
FluentValidation
```

---

## Baza danych

```text
PostgreSQL 16
Entity Framework Core
```

---

## Raportowanie

```text
QuestPDF
ClosedXML
```

---

## Wizualizacja

```text
Apache ECharts
```

---

## Bezpieczeństwo

```text
JWT
RBAC
TLS 1.3
Serilog Audit Logs
```

---

## DevOps

```text
Docker
GitHub Actions
GitFlow
```

---

# Podsumowanie decyzji architektonicznych

| Obszar | Wybrana technologia |
|----------|----------|
| Frontend | Next.js + React + TypeScript |
| Backend | .NET 8 |
| ORM | Entity Framework Core |
| CQRS | MediatR |
| Baza Danych | PostgreSQL 16 |
| Raportowanie | QuestPDF |
| Eksport XLSX | ClosedXML |
| Wizualizacja | Apache ECharts |
| Logowanie | Serilog |
| Testy | xUnit |
| API Tests | Postman + Newman |
| Performance Tests | k6 |
| Konteneryzacja | Docker |
| CI/CD | GitHub Actions |

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja dokumentu decyzji technologicznych |
