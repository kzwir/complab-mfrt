# 08 - Strategia Testowania

# CompLab MFR/T

## Strategia Testowania Systemu

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Powiązanie:** Dokument uzupełnia założenia opisane w:

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
04-Data-Model.md
05-API-Design.md
06-Security.md
07-DevOps.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest określenie strategii testowania systemu CompLab MFR/T na wszystkich poziomach architektury.

Dokument definiuje:

- cele jakościowe,
- poziomy testów,
- narzędzia testowe,
- odpowiedzialności zespołu,
- wymagane pokrycie testami,
- zasady automatyzacji,
- kryteria akceptacji.

Strategia została opracowana zgodnie z podejściem:

```text
Test Pyramid
Shift Left Testing
Continuous Testing
DevSecOps
```

---

# 2. Cele jakościowe

System powinien spełniać następujące wymagania jakościowe:

## J-01 Poprawność danych

Wyniki badań laboratoryjnych muszą być rejestrowane bez utraty i zniekształcenia danych.

---

## J-02 Powtarzalność

Ten sam zestaw danych powinien zawsze prowadzić do identycznego wyniku raportu.

---

## J-03 Integralność

Relacje pomiędzy próbkami, mieszaninami i badaniami muszą pozostawać spójne.

---

## J-04 Bezpieczeństwo

System musi poprawnie egzekwować mechanizmy:

- JWT,
- RBAC,
- walidacji danych,
- audytu zmian.

---

## J-05 Wydajność

System musi zachowywać wymaganą wydajność przy zakładanym obciążeniu.

---

# 3. Model testowania

Projekt wykorzystuje klasyczną piramidę testów.

```text
                 UAT
                  ▲
                  │
          End-to-End Tests
                  ▲
                  │
          Integration Tests
                  ▲
                  │
             Unit Tests
```

---

# 4. Zakres testów

System będzie testowany na następujących poziomach:

## Testy jednostkowe

Sprawdzenie pojedynczych klas i komponentów.

---

## Testy integracyjne

Weryfikacja współpracy pomiędzy modułami.

---

## Testy API

Weryfikacja kontraktów REST API.

---

## Testy wydajnościowe

Ocena zachowania systemu pod obciążeniem.

---

## Testy bezpieczeństwa

Weryfikacja odporności na zagrożenia.

---

## Testy akceptacyjne

Potwierdzenie zgodności z wymaganiami biznesowymi.

---

## Testy regresyjne

Weryfikacja, że nowe zmiany nie psują istniejących funkcjonalności.

---

# 5. Testy jednostkowe

## Cel

Weryfikacja poprawności działania pojedynczych elementów systemu.

---

## Zakres

### Warstwa Domain

Testowane będą:

- encje,
- agregaty,
- value objects,
- zdarzenia domenowe,
- reguły biznesowe.

---

### Warstwa Application

Testowane będą:

- Command Handlers,
- Query Handlers,
- walidatory,
- serwisy aplikacyjne.

---

## Przykłady

### Sample

```text
Utworzenie próbki
Zmiana statusu próbki
Archiwizacja próbki
```

---

### MfrTest

```text
Obliczenie MFR
Walidacja parametrów wejściowych
```

---

### StrengthTest

```text
Walidacja siły niszczącej
Walidacja wytrzymałości
```

---

## Narzędzia

```text
xUnit
FluentAssertions
Moq
```

---

## Pokrycie kodu

Minimalne:

```text
80%
```

Rekomendowane:

```text
90%
```

dla warstwy domenowej.

---

# 6. Testy integracyjne

## Cel

Sprawdzenie współpracy komponentów systemu.

---

## Zakres

### API ↔ Application

Weryfikacja poprawnej obsługi żądań.

---

### Application ↔ Database

Weryfikacja:

- zapisu danych,
- odczytu danych,
- migracji.

---

### API ↔ PostgreSQL

Sprawdzenie poprawnego mapowania danych.

---

## Testowane procesy

### Rejestracja próbki

```text
Sample
→ Database
→ Audit Log
```

---

### Rejestracja badania MFR

```text
Request
→ Validation
→ Save
→ Response
```

---

### Generowanie raportu

```text
Database
→ Report Service
→ PDF
```

---

## Narzędzia

```text
xUnit
Testcontainers
PostgreSQL Test Container
```

---

## Pokrycie

Minimalne:

```text
70%
```

kluczowych procesów biznesowych.

---

# 7. Testy API

## Cel

Weryfikacja kontraktów REST API.

---

## Zakres

### Endpointy

```text
Authentication
Users
Samples
Mixtures
TestSeries
MfrTests
StrengthTests
Reports
Compliance
Audit
```

---

## Weryfikacja

### Request

- poprawność danych,
- walidacja pól.

---

### Response

- statusy HTTP,
- format odpowiedzi,
- zgodność JSON.

---

### Autoryzacja

- poprawne role,
- poprawne uprawnienia.

---

## Narzędzia

```text
Postman
Newman
```

---

## Wymagania

Pokrycie:

```text
100% endpointów
```

---

# 8. Testy End-to-End (E2E)

## Cel

Sprawdzenie pełnego procesu biznesowego.

---

## Scenariusz E2E-01

### Rejestracja badania

```text
Logowanie
→ Utworzenie mieszaniny
→ Utworzenie próbki
→ Rejestracja badania
→ Walidacja normowa
→ Generowanie raportu PDF
```

---

## Scenariusz E2E-02

### Badanie wytrzymałościowe

```text
Logowanie
→ Utworzenie serii
→ Rejestracja wyniku
→ Ocena zgodności
→ Eksport CSV
```

---

## Narzędzia

```text
Playwright
```

---

# 9. Testy wydajnościowe

## Cel

Weryfikacja wydajności systemu przy założonym obciążeniu.

---

## Narzędzie

```text
k6
```

---

## Scenariusz P-01

### Przeglądanie listy próbek

Obciążenie:

```text
20 użytkowników
```

---

## Scenariusz P-02

### Zapis wyników badań

Obciążenie:

```text
10 równoczesnych zapisów
```

---

## Scenariusz P-03

### Generowanie raportów

Obciążenie:

```text
5 równoczesnych raportów PDF
```

---

## Wymagania

### API

```text
95 percentyl < 500 ms
```

---

### Raport PDF

```text
< 10 sekund
```

---

### Dashboard

```text
< 3 sekundy
```

---

# 10. Testy bezpieczeństwa

## Cel

Weryfikacja zgodności z wymaganiami OWASP ASVS.

---

## Zakres

### Uwierzytelnianie

Sprawdzenie:

- JWT,
- wylogowania,
- odświeżania tokenów.

---

### Autoryzacja

Sprawdzenie:

- RBAC,
- izolacji ról.

---

### Walidacja danych

Sprawdzenie:

- SQL Injection,
- XSS,
- błędów walidacji.

---

## Przykłady

### S-01

```text
Próba odczytu danych bez tokenu
```

Oczekiwany wynik:

```http
401 Unauthorized
```

---

### S-02

```text
Próba dostępu Operatora
do panelu Administratora
```

Oczekiwany wynik:

```http
403 Forbidden
```

---

## Narzędzia

```text
OWASP ZAP
Postman
```

---

# 11. Testy akceptacyjne (UAT)

## Cel

Potwierdzenie zgodności systemu z wymaganiami biznesowymi.

---

## Odpowiedzialność

```text
Product Owner
Kierownik Laboratorium
Użytkownicy Kluczowi
```

---

## Scenariusze

### UAT-01

Rejestracja mieszaniny.

---

### UAT-02

Rejestracja próbki.

---

### UAT-03

Rejestracja badania MFR.

---

### UAT-04

Rejestracja badania wytrzymałościowego.

---

### UAT-05

Generowanie raportu PDF.

---

### UAT-06

Eksport CSV.

---

### UAT-07

Ocena zgodności względem PN-EN 1338.

---

### UAT-08

Ocena zgodności względem PN-EN 1339.

---

# 12. Testy regresyjne

## Cel

Sprawdzenie wpływu nowych zmian na istniejące funkcjonalności.

---

## Zakres

Przed każdym wydaniem wykonywane są:

```text
Unit Tests
Integration Tests
API Tests
E2E Tests
```

---

## Automatyzacja

Proces wykonywany automatycznie w CI/CD.

---

# 13. Testowanie migracji bazy danych

## Cel

Weryfikacja poprawności migracji.

---

## Zakres

### Tworzenie schematu

```text
Migration Up
```

---

### Wycofanie migracji

```text
Migration Down
```

---

### Spójność danych

```text
Brak utraty danych
```

---

# 14. Testowanie raportów

## Zakres

### PDF

Weryfikacja:

- układu,
- poprawności danych,
- numeracji stron,
- zgodności z szablonem.

---

### CSV

Weryfikacja:

- separatorów,
- liczby kolumn,
- poprawności kodowania.

---

### XLSX

Weryfikacja:

- formatowania,
- typów danych,
- formuł.

---

# 15. Testowanie audytu

## Weryfikacja

Sprawdzenie czy następujące operacje tworzą wpis Audit Log:

- logowanie,
- utworzenie próbki,
- zmiana próbki,
- dodanie badania,
- archiwizacja,
- wygenerowanie raportu.

---

# 16. Matryca odpowiedzialności

## Programista

Odpowiada za:

- testy jednostkowe,
- testy komponentowe.

---

## QA

Odpowiada za:

- testy integracyjne,
- testy API,
- testy regresyjne.

---

## DevOps

Odpowiada za:

- automatyzację testów,
- raportowanie wyników.

---

## Product Owner

Odpowiada za:

- testy akceptacyjne.

---

# 17. Kryteria wejścia do testów

## Build

```text
Sukces
```

---

## Code Review

```text
Zakończony
```

---

## Unit Tests

```text
Przechodzą
```

---

## Brak błędów krytycznych

```text
Critical = 0
High = 0
```

---

# 18. Kryteria wyjścia z testów

## Warunki

### Testy jednostkowe

```text
≥ 80%
```

---

### Testy integracyjne

```text
≥ 70%
```

---

### Testy API

```text
100%
```

---

### Błędy krytyczne

```text
0
```

---

### Błędy wysokiego ryzyka

```text
0
```

---

## Akceptacja Product Ownera

Wymagana.

---

# 19. Integracja z CI/CD

Pipeline automatycznie uruchamia:

```text
Build
↓
Unit Tests
↓
Integration Tests
↓
API Tests
↓
Security Scan
↓
Package
↓
Deploy
```

---

# 20. Docelowe wskaźniki jakości

## Pokrycie kodu

```text
Cały system ≥ 80%
```

---

## Warstwa domenowa

```text
≥ 90%
```

---

## Endpointy API

```text
100%
```

---

## Reguły biznesowe

```text
100%
```

---

## Krytyczne procesy laboratoryjne

```text
100%
```

Scenariusze:

- rejestracja próbki,
- rejestracja mieszaniny,
- badanie MFR,
- badanie wytrzymałościowe,
- ocena zgodności,
- generowanie raportu.

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
05-API-Design.md
06-Security.md
07-DevOps.md
09-Deployment.md
```

---

# Lista kontrolna przed wydaniem

## Funkcjonalność

- [ ] Wszystkie funkcje MVP zaimplementowane
- [ ] Testy UAT zakończone
- [ ] Dokumentacja aktualna

## Jakość

- [ ] Pokrycie kodu >= 80%
- [ ] Wszystkie testy zakończone sukcesem
- [ ] Brak błędów krytycznych

## Bezpieczeństwo

- [ ] Security Scan zakończony sukcesem
- [ ] Brak podatności Critical
- [ ] Brak podatności High

## Wydajność

- [ ] Testy k6 zakończone sukcesem
- [ ] SLA spełnione

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja strategii testowania |
