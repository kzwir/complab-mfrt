# 01 - Przegląd Architektury

# CompLab MFR/T

## Przegląd Architektury Systemu

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Typ systemu:** Laboratory Information Management System (LIMS)  
**Styl architektoniczny:** Clean Architecture + Domain-Driven Design (DDD) + SOLID + CQRS (w wybranych obszarach)  
**Docelowe środowisko:** Sieć wewnętrzna (Intranet) / On-Premise  
**Odbiorcy dokumentu:** Product Owner, Architekt Rozwiązania, Kierownik Projektu, Programiści, Testerzy, DevOps

---

# 1. Cel dokumentu

Dokument przedstawia ogólny przegląd architektury systemu CompLab MFR/T i stanowi punkt odniesienia dla zespołu projektowego podczas implementacji, testowania oraz wdrażania rozwiązania.

Dokument opisuje:

- kontekst biznesowy projektu,
- cele systemu,
- zakres funkcjonalny,
- założenia architektoniczne,
- architekturę logiczną,
- architekturę fizyczną,
- architekturę wdrożeniową,
- główne decyzje technologiczne,
- wymagania jakościowe,
- założenia bezpieczeństwa.

Szczegółowe informacje znajdują się w dedykowanych dokumentach architektonicznych.

---

# 2. Opis projektu

CompLab MFR/T jest aplikacją laboratoryjną wspierającą proces badań materiałów kompozytowych polimerowo-kwarcytowych wykorzystywanych do produkcji elementów budowlanych, takich jak:

- kostka brukowa,
- płyty brukowe,
- krawężniki,
- płyty ażurowe,
- elementy typu Geo Krata.

System umożliwia rejestrację, analizę i archiwizację wyników badań laboratoryjnych wykonywanych w procesie opracowywania oraz kontroli jakości wyrobów.

Oprogramowanie wspiera przede wszystkim:

- badania wskaźnika płynięcia polimerów MFR/MFI,
- badania wytrzymałościowe,
- analizę składu mieszanin,
- ocenę zgodności z normami,
- generowanie raportów laboratoryjnych.

---

# 3. Cele biznesowe

## CB-01 Cyfryzacja laboratorium

Eliminacja rozproszonych arkuszy Excel oraz papierowych protokołów.

## CB-02 Identyfikowalność wyników

Zapewnienie pełnej historii próbek, mieszanin i wyników pomiarowych.

## CB-03 Wsparcie jakości

Ułatwienie prowadzenia badań zgodnie z wymaganiami jakościowymi oraz procedurami laboratoryjnymi.

## CB-04 Automatyzacja raportowania

Skrócenie czasu potrzebnego na przygotowanie raportów i analiz.

## CB-05 Budowa bazy wiedzy

Gromadzenie historycznych wyników badań umożliwiających analizę procesów technologicznych.

---

# 4. Zakres systemu

## Funkcjonalności objęte zakresem

### Zarządzanie próbkami

- rejestracja próbek,
- identyfikacja próbek,
- archiwizacja próbek,
- historia zmian.

### Zarządzanie mieszaninami

- skład mieszaniny,
- udział polimeru,
- udział kwarcytu,
- informacje o wilgotności,
- informacje o barwnikach.

### Zarządzanie seriami badawczymi

- numeracja serii,
- grupowanie badań,
- przypisywanie próbek.

### Badania MFR/MFI

Rejestracja:

- temperatury badania,
- obciążenia,
- czasu odcinania,
- masy wytłoczki,
- wskaźnika MFR.

### Badania wytrzymałościowe

Rejestracja:

- siły niszczącej P [N],
- wytrzymałości na rozciąganie przy rozłupywaniu T [MPa].

### Analiza statystyczna

- średnia,
- mediana,
- minimum,
- maksimum,
- odchylenie standardowe,
- analiza trendów.

### Ocena zgodności

Porównanie wyników z:

- PN-EN 1338,
- PN-EN 1339,
- konfiguracją laboratoryjną.

### Raportowanie

- PDF,
- CSV,
- XLSX.

---

## Funkcjonalności poza zakresem

System nie realizuje:

- sterowania maszynami laboratoryjnymi,
- komunikacji PLC,
- funkcji SCADA,
- automatycznego pobierania danych z urządzeń,
- monitoringu czasu rzeczywistego,
- funkcji MES,
- integracji ERP.

Powyższe funkcjonalności mogą zostać uwzględnione w przyszłych wersjach systemu.

---

# 5. Założenia architektoniczne

## Założenia funkcjonalne

1. Wszystkie wyniki pomiarów wprowadzane są ręcznie przez użytkownika.
2. Każdy pomiar musi być przypisany do próbki.
3. Każda próbka należy do jednej mieszaniny.
4. Jedna próbka może występować w wielu badaniach.
5. Wyniki zatwierdzone nie mogą być edytowane bez pozostawienia śladu audytowego.
6. Każdy raport musi być możliwy do odtworzenia na podstawie danych historycznych.

---

## Założenia niefunkcjonalne

### Dostępność

Docelowa dostępność:

```text
99,5%
```

### Wydajność

Maksymalny czas odpowiedzi API:

```text
< 500 ms
```

Maksymalny czas wygenerowania raportu:

```text
< 10 s
```

### Skalowalność

System powinien obsługiwać:

```text
20 aktywnych użytkowników
```

z możliwością zwiększenia do:

```text
50 użytkowników jednocześnie
```

### Przyrost danych

Przewidywany przyrost:

```text
2–5 GB rocznie
```

---

# 6. Wymagania jakościowe

## Bezpieczeństwo

System musi zapewnić:

- uwierzytelnianie użytkowników,
- autoryzację opartą o role,
- rejestr zmian,
- szyfrowanie transmisji,
- politykę silnych haseł.

## Niezawodność

System powinien gwarantować:

- integralność danych,
- bezpieczeństwo przechowywania wyników,
- możliwość odtworzenia danych po awarii.

## Utrzymywalność

Kod źródłowy powinien być:

- modułowy,
- testowalny,
- łatwy do rozbudowy,
- zgodny z zasadami SOLID.

## Śledzenie zmian

Wszystkie zmiany dotyczące danych laboratoryjnych muszą być rejestrowane w dzienniku audytowym.

---

# 7. Zasady architektoniczne

## Clean Architecture

Logika biznesowa musi być całkowicie niezależna od:

- bazy danych,
- frameworków UI,
- technologii raportowania,
- dostawców infrastruktury.

---

## SOLID

Projekt powinien przestrzegać:

- Single Responsibility Principle,
- Open-Closed Principle,
- Liskov Substitution Principle,
- Interface Segregation Principle,
- Dependency Inversion Principle.

---

## Domain-Driven Design

Model domenowy organizowany jest wokół kluczowych pojęć biznesowych:

- Próbka,
- Mieszanina,
- Seria Badawcza,
- Badanie MFR,
- Badanie Wytrzymałościowe,
- Raport.

---

## CQRS

CQRS stosowane jest w obszarach:

### Commands

- rejestracja próbki,
- rejestracja badania,
- zatwierdzenie wyników,
- archiwizacja danych.

### Queries

- raporty,
- dashboardy,
- statystyki,
- historia badań.

---

# 8. Architektura logiczna

System składa się z czterech głównych warstw.

```text
Presentation Layer
        │
Application Layer
        │
Domain Layer
        │
Infrastructure Layer
```

---

## Presentation Layer

Odpowiedzialność:

- interfejs użytkownika,
- formularze laboratoryjne,
- dashboardy,
- raporty,
- wykresy.

Technologia:

```text
Next.js
React
TypeScript
```

---

## Application Layer

Odpowiedzialność:

- przypadki użycia,
- CQRS,
- walidacja danych,
- obsługa procesów biznesowych.

Technologie:

```text
ASP.NET Core
MediatR
FluentValidation
```

---

## Domain Layer

Odpowiedzialność:

- reguły biznesowe,
- agregaty,
- encje,
- zdarzenia domenowe,
- obliczenia jakościowe.

Warstwa domenowa nie posiada zależności technologicznych.

---

## Infrastructure Layer

Odpowiedzialność:

- baza danych,
- repozytoria,
- logowanie,
- raportowanie,
- przechowywanie plików.

Technologie:

```text
Entity Framework Core
PostgreSQL
QuestPDF
```

---

# 9. Architektura fizyczna

## Stacje robocze

Komputery użytkowników laboratoryjnych.

Dostęp do systemu realizowany przez przeglądarkę internetową.

---

## Serwer aplikacyjny

Obsługuje:

- API,
- logikę biznesową,
- generowanie raportów.

Rekomendowane środowisko:

```text
Linux
Docker
```

---

## Serwer bazy danych

Przechowuje:

- próbki,
- serie badawcze,
- wyniki badań,
- historię zmian,
- użytkowników.

Technologia:

```text
PostgreSQL 16
```

---

## Magazyn plików

Przechowuje:

- raporty PDF,
- eksporty CSV,
- eksporty XLSX.

---

## Serwer kopii zapasowych

Przechowuje:

- backup bazy danych,
- kopie raportów,
- archiwa systemu.

---

# 10. Architektura wdrożeniowa

```text
Przeglądarka
       │
       ▼
Reverse Proxy
       │
       ▼
CompLab API
       │
 ┌─────┴─────┐
 ▼           ▼
PostgreSQL  File Storage
```

---

# 11. Przegląd bezpieczeństwa

## Uwierzytelnianie

- JWT Access Token
- Refresh Token

---

## Autoryzacja

Model RBAC.

Role:

- Administrator,
- Kierownik Laboratorium,
- Laborant,
- Audytor.

---

## Audyt

Rejestrowane są:

- dodania,
- zmiany,
- usunięcia,
- generowanie raportów,
- eksport danych.

---

## Szyfrowanie

### Transmisja

```text
TLS 1.3
```

### Dane w spoczynku

```text
AES-256
```

lub szyfrowanie dysków systemowych.

---

# 12. Wysokopoziomowy stack technologiczny

## Frontend

```text
Next.js
React
TypeScript
```

## Backend

```text
.NET 8
ASP.NET Core
MediatR
FluentValidation
```

## Baza danych

```text
PostgreSQL 16
```

## Raportowanie

```text
QuestPDF
```

## Wizualizacja danych

```text
Apache ECharts
```

## Konteneryzacja

```text
Docker
Docker Compose
```

## CI/CD

```text
GitHub Actions
```

---

# 13. Główne ryzyka

## Ryzyko 1

Błędy ręcznego wprowadzania danych.

Działania ograniczające:

- walidacja formularzy,
- słowniki wartości,
- reguły biznesowe.

---

## Ryzyko 2

Nieprawidłowe wartości graniczne norm.

Działania ograniczające:

- centralny rejestr norm,
- możliwość wersjonowania progów jakościowych.

---

## Ryzyko 3

Utrata wyników badań.

Działania ograniczające:

- automatyczne backupy,
- procedury Disaster Recovery,
- audyt zmian.

---

# 14. Kierunki rozwoju

## Wersja 2

- dashboardy KPI,
- statystyczna kontrola procesu (SPC),
- analizy trendów,
- porównywanie serii produkcyjnych.

## Wersja 3

- integracja z urządzeniami laboratoryjnymi,
- automatyczny import danych,
- integracja z systemami ERP/QMS,
- raportowanie w chmurze.

---

# Dokumenty powiązane

```text
docs/architecture/02-Domain-Analysis.md
docs/architecture/03-Technology-Decision.md
docs/architecture/04-Data-Model.md
docs/architecture/05-API-Design.md
docs/architecture/06-Security.md
docs/architecture/07-DevOps.md
docs/architecture/08-Testing-Strategy.md
docs/architecture/09-Deployment.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja początkowa dokumentu architektury |
