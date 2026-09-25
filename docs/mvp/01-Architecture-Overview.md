# 01 - Przegląd Architektury

# CompLab MFR/T

## Przegląd Architektury Systemu MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition  
**Typ systemu:** Laboratory Information Management System (LIMS)  
**Styl architektoniczny:** Modular Monolith + Clean Architecture Lite + DDD Lite  
**Docelowe środowisko:** Intranet / On-Premise  
**Odbiorcy dokumentu:** Product Owner, Kierownik Projektu, Programiści, Testerzy

---

# 1. Cel dokumentu

Dokument opisuje uproszczoną architekturę systemu CompLab MFR/T przeznaczoną do realizacji MVP (Minimum Viable Product).

Celem MVP jest możliwie szybkie dostarczenie działającego rozwiązania umożliwiającego:

- rejestrację mieszanin,
- rejestrację próbek,
- rejestrację wyników badań,
- przegląd wyników,
- podstawową autoryzację użytkowników.

Dokument koncentruje się wyłącznie na funkcjonalnościach niezbędnych do pierwszego wdrożenia.

---

# 2. Opis projektu

CompLab MFR/T jest aplikacją laboratoryjną wspierającą badania materiałów kompozytowych wykorzystywanych do produkcji elementów budowlanych.

MVP umożliwia:

- ewidencję mieszanin materiałowych,
- ewidencję próbek,
- zapis wyników badań laboratoryjnych,
- wyszukiwanie i przegląd wyników,
- podstawową kontrolę dostępu.

Wszystkie dane pomiarowe wprowadzane są ręcznie przez użytkownika.

---

# 3. Cele biznesowe

## CB-01 Cyfryzacja laboratorium

Eliminacja arkuszy Excel i dokumentacji papierowej.

## CB-02 Centralizacja danych

Przechowywanie danych laboratoryjnych w jednej bazie danych.

## CB-03 Identyfikowalność

Powiązanie każdej próbki z mieszaniną i wynikami badań.

## CB-04 Szybkie wdrożenie

Dostarczenie działającej wersji systemu w ciągu 4–8 tygodni.

---

# 4. Zakres MVP

## Funkcjonalności objęte MVP

### Użytkownicy

- logowanie,
- wylogowanie,
- podstawowe role.

### Mieszaniny

- tworzenie mieszaniny,
- przegląd mieszanin,
- edycja danych.

### Próbki

- rejestracja próbki,
- przypisanie do mieszaniny,
- wyszukiwanie próbek.

### Badania

- rejestracja wyniku badania,
- przypisanie wyniku do próbki,
- przegląd wyników.

### Dashboard

- liczba próbek,
- liczba mieszanin,
- liczba wykonanych badań.

---

## Funkcjonalności poza MVP

- raporty PDF,
- eksport XLSX,
- eksport CSV,
- CQRS,
- workflow zatwierdzania,
- audyt zmian,
- ocena zgodności z normami,
- integracja urządzeń laboratoryjnych,
- integracja ERP,
- dashboardy analityczne,
- automatyczny import danych.

---

# 5. Założenia architektoniczne

## Założenia funkcjonalne

1. Wszystkie dane wprowadzane są ręcznie.
2. Każda próbka należy do jednej mieszaniny.
3. Każde badanie musi być przypisane do próbki.
4. Użytkownik musi być uwierzytelniony.
5. System działa w sieci wewnętrznej.

---

## Założenia niefunkcjonalne

### Liczba użytkowników

```text
20 użytkowników
```

### Czas odpowiedzi API

```text
< 1 sekunda
```

### Dostępność

```text
95%
```

w fazie MVP.

---

# 6. Architektura logiczna

System składa się z czterech uproszczonych warstw.

```text
Presentation
     │
Application
     │
Domain
     │
Infrastructure
```

---

## Presentation Layer

Odpowiedzialność:

- logowanie,
- formularze,
- dashboard,
- listy danych.

Technologie:

```text
Angular
ngx-admin
Nebular
```

---

## Application Layer

Odpowiedzialność:

- przypadki użycia,
- walidacja,
- obsługa procesów biznesowych.

Technologia:

```text
ASP.NET Core
```

---

## Domain Layer

Odpowiedzialność:

- encje biznesowe,
- podstawowe reguły domenowe.

Encje:

```text
User
Mixture
Sample
Test
```

---

## Infrastructure Layer

Odpowiedzialność:

- baza danych,
- Entity Framework Core,
- uwierzytelnianie JWT.

Technologie:

```text
Entity Framework Core
PostgreSQL
```

---

# 7. Architektura fizyczna

```text
Przeglądarka

        │

        ▼

Angular

        │

        ▼

ASP.NET Core API

        │

        ▼

PostgreSQL
```

---

# 8. Bezpieczeństwo

## Uwierzytelnianie

```text
JWT
```

---

## Role

### Administrator

Pełny dostęp.

### Operator

Obsługa danych laboratoryjnych.

---

## Transmisja

```text
HTTPS
```

---

# 9. Model domenowy MVP

Główne encje:

```text
User

Mixture

Sample

Test
```

Relacje:

```text
Mixture
   │
   └── Sample
            │
            └── Test
```

---

# 10. Stack technologiczny

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
Entity Framework Core
```

---

## Baza danych

```text
PostgreSQL
```

---

# 11. Architektura repozytorium

```text
complab-mfrt

├── docs
├── src
│   ├── frontend
│   └── backend
│       ├── CompLab.Api
│       ├── CompLab.Application
│       ├── CompLab.Domain
│       └── CompLab.Infrastructure
├── database
└── README.md
```

---

# 12. Kierunki rozwoju

## Wersja 2

- raporty PDF,
- ocena zgodności,
- audyt zmian,
- eksport XLSX.

## Wersja 3

- integracja urządzeń laboratoryjnych,
- dashboardy KPI,
- analizy trendów,
- integracja ERP/QMS.

---

# Dokumenty powiązane

```text
02-Domain-Analysis.md
03-Technology-Decision.md
04-Data-Model.md
05-API-Design.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Architektura docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie do wersji MVP |
