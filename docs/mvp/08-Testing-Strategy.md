# 08 - Strategia Testowania

# CompLab MFR/T

## Strategia Testowania MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition

Powiązane dokumenty:

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
04-Data-Model.md
05-API-Design.md
07-DevOps.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest określenie minimalnej strategii testowania dla wersji MVP systemu CompLab MFR/T.

Strategia koncentruje się na:

- poprawności działania,
- stabilności aplikacji,
- ograniczeniu liczby błędów regresyjnych,
- automatyzacji najważniejszych scenariuszy.

Priorytetem jest szybkie dostarczenie działającego produktu.

---

# 2. Cele jakościowe

## J-01 Poprawność danych

System poprawnie zapisuje:

- mieszaniny,
- próbki,
- wyniki badań.

---

## J-02 Integralność danych

Relacje pomiędzy:

```text
Mixture
→ Sample
→ Test
```

muszą pozostać spójne.

---

## J-03 Stabilność API

REST API powinno poprawnie obsługiwać wszystkie operacje CRUD.

---

## J-04 Bezpieczeństwo podstawowe

Endpointy chronione wymagają poprawnego tokenu JWT.

---

# 3. Model testowania

W MVP stosujemy uproszczony model:

```text
E2E

 ▲

API Tests

 ▲

Unit Tests
```

---

# 4. Zakres testów

## Testy jednostkowe

Weryfikacja:

- encji domenowych,
- logiki biznesowej,
- serwisów aplikacyjnych.

---

## Testy API

Weryfikacja:

- endpointów REST,
- walidacji danych,
- autoryzacji JWT.

---

## Testy E2E

Weryfikacja najważniejszych procesów biznesowych.

---

# 5. Testy jednostkowe

## Cel

Sprawdzenie poprawności działania pojedynczych elementów systemu.

---

## Zakres

### Domain

Testowane:

```text
User
Mixture
Sample
Test
```

---

### Application

Testowane:

```text
Application Services

Walidacje

Reguły biznesowe
```

---

## Przykłady

### Sample

```text
Tworzenie próbki

Walidacja numeru próbki
```

---

### Test

```text
Walidacja MeasurementValue > 0
```

---

### Mixture

```text
Walidacja składu mieszaniny
```

---

## Narzędzia

```text
xUnit

FluentAssertions
```

---

## Pokrycie kodu

Minimalne:

```text
70%
```

---

# 6. Testy API

## Cel

Sprawdzenie działania REST API.

---

## Zakres

### Authentication

```text
POST /api/v1/auth/login
```

---

### Dashboard

```text
GET /api/v1/dashboard
```

---

### Mixtures

```text
GET
POST
PUT
DELETE
```

---

### Samples

```text
GET
POST
PUT
DELETE
```

---

### Tests

```text
GET
POST
PUT
DELETE
```

---

## Weryfikacja

### Poprawne dane

```http
200
201
```

---

### Błędne dane

```http
400
```

---

### Brak tokenu

```http
401
```

---

## Narzędzia

```text
Swagger

Postman
```

---

# 7. Testy End-to-End

## Cel

Weryfikacja pełnego procesu biznesowego.

---

## Scenariusz E2E-01

### Rejestracja nowej próbki

```text
Logowanie
↓
Dodanie mieszaniny
↓
Dodanie próbki
↓
Wyświetlenie próbki
```

---

## Scenariusz E2E-02

### Rejestracja badania

```text
Logowanie
↓
Wybór próbki
↓
Dodanie wyniku badania
↓
Wyświetlenie wyniku
```

---

## Scenariusz E2E-03

### Dashboard

```text
Logowanie
↓
Wyświetlenie dashboardu
↓
Weryfikacja KPI
```

---

## Narzędzia

```text
Playwright
```

---

# 8. Testy akceptacyjne

## Cel

Potwierdzenie spełnienia wymagań biznesowych MVP.

---

## Odpowiedzialność

```text
Product Owner

Kierownik Projektu

Kluczowy użytkownik
```

---

## Scenariusze

### UAT-01

Dodanie mieszaniny.

---

### UAT-02

Dodanie próbki.

---

### UAT-03

Dodanie badania.

---

### UAT-04

Przegląd wyników.

---

### UAT-05

Dashboard.

---

# 9. Testy regresyjne

Przed każdym wydaniem wykonywane są:

```text
Unit Tests

API Tests

E2E Tests
```

---

# 10. Odpowiedzialność

## Programista

Odpowiada za:

```text
Unit Tests

Naprawę błędów
```

---

## Zespół

Odpowiada za:

```text
API Tests

E2E Tests
```

---

## Product Owner

Odpowiada za:

```text
Akceptację MVP
```

---

# 11. Kryteria rozpoczęcia testów

Wymagane:

```text
Build zakończony sukcesem

Code Review zakończony
```

---

# 12. Kryteria zakończenia testów

## Testy jednostkowe

```text
>= 70%
```

---

## Endpointy API

Najważniejsze endpointy działają poprawnie.

---

## E2E

Wszystkie scenariusze MVP zakończone sukcesem.

---

## Błędy krytyczne

```text
0
```

---

# 13. Integracja z CI

Przy każdym Pull Request wykonywane są:

```text
Build

↓

Unit Tests

↓

API Tests
```

---

# 14. Docelowe wskaźniki jakości MVP

## Pokrycie kodu

```text
>= 70%
```

---

## Funkcjonalności krytyczne

Pokrycie:

```text
100%
```

Dotyczy:

```text
Logowanie

Mieszaniny

Próbki

Badania
```

---

# 15. Funkcjonalności odłożone do V2

Planowane testy:

```text
Performance Tests

Security Tests

Raporty PDF

Eksport XLSX
```

---

# 16. Funkcjonalności odłożone do V3

Planowane testy:

```text
Integracja urządzeń laboratoryjnych

Testy obciążeniowe

Testy odpornościowe
```

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
05-API-Design.md
07-DevOps.md
09-Deployment.md
```

---

# Lista kontrolna przed wydaniem MVP

## Funkcjonalność

- [ ] Logowanie działa
- [ ] Mieszaniny działają
- [ ] Próbki działają
- [ ] Badania działają
- [ ] Dashboard działa

---

## Testy

- [ ] Unit Tests zakończone sukcesem
- [ ] API Tests zakończone sukcesem
- [ ] E2E Tests zakończone sukcesem

---

## Jakość

- [ ] Brak błędów krytycznych
- [ ] Dokumentacja aktualna
- [ ] Akceptacja Product Ownera

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie strategii testowania dla MVP |
