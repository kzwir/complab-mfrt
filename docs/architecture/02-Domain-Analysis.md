# 02 - Analiza Domeny (DDD)

# CompLab MFR/T

## Analiza Domenowa Systemu

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Powiązanie:** Dokument rozwija założenia przedstawione w dokumencie `01-Architecture-Overview.md`.

---

# 1. Cel dokumentu

Celem niniejszego dokumentu jest identyfikacja i opis modelu domenowego systemu CompLab MFR/T zgodnie z podejściem Domain-Driven Design (DDD).

Dokument definiuje:

- granice domeny,
- bounded contexts,
- encje domenowe,
- agregaty,
- obiekty wartości,
- zdarzenia domenowe,
- reguły biznesowe,
- relacje pomiędzy obiektami domeny,
- model odpowiedzialności biznesowej.

Model domenowy stanowi podstawę implementacji warstwy Domain oraz Application.

---

# 2. Opis domeny biznesowej

System CompLab MFR/T wspiera laboratorium badawczo-rozwojowe prowadzące badania kompozytów polimerowo-kwarcytowych wykorzystywanych do produkcji elementów budowlanych.

Proces badawczy obejmuje:

1. przygotowanie mieszaniny,
2. wykonanie próbki,
3. przypisanie próbki do serii badawczej,
4. przeprowadzenie badań laboratoryjnych,
5. analizę wyników,
6. ocenę zgodności z normami,
7. wygenerowanie raportu,
8. archiwizację wyników.

System nie steruje urządzeniami laboratoryjnymi i nie realizuje automatycznego pobierania danych pomiarowych.

---

# 3. Podział domeny na Bounded Contexts

W celu zachowania wysokiej spójności modelu domenowego wyróżniono następujące obszary biznesowe.

---

## 3.1 Sample Management

Odpowiada za:

- zarządzanie próbkami,
- identyfikowalność próbek,
- archiwizację,
- historię zmian.

### Główne encje

- Sample
- SampleStatus
- SampleArchive

---

## 3.2 Mixture Management

Odpowiada za:

- rejestrację mieszanin,
- skład receptur,
- parametry technologiczne.

### Główne encje

- Mixture
- MixtureComponent

---

## 3.3 Laboratory Testing

Odpowiada za:

- rejestrację badań,
- analizę wyników,
- statystykę.

### Główne encje

- TestSeries
- MfrTest
- StrengthTest
- MeasurementResult

---

## 3.4 Quality Compliance

Odpowiada za:

- kontrolę zgodności,
- ocenę jakości,
- interpretację norm.

### Główne encje

- Standard
- ComplianceRule
- ComplianceResult

---

## 3.5 Reporting

Odpowiada za:

- raportowanie,
- eksport danych,
- przechowywanie dokumentacji.

### Główne encje

- Report
- ExportFile

---

## 3.6 User Management

Odpowiada za:

- użytkowników,
- role,
- uprawnienia.

### Główne encje

- User
- Role
- Permission

---

# 4. Ujednolicony język domenowy (Ubiquitous Language)

| Termin biznesowy | Znaczenie |
|------------------|------------|
| Próbka | Fizyczny element poddawany badaniom |
| Mieszanina | Receptura kompozytu polimerowo-kwarcytowego |
| Seria badawcza | Grupa badań wykonywana dla określonych próbek |
| Badanie MFR | Badanie wskaźnika płynięcia polimerów |
| Badanie wytrzymałościowe | Badanie rozciągania przy rozłupywaniu |
| Norma | Zbiór wymagań jakościowych |
| Wynik | Zarejestrowany rezultat pomiaru |
| Raport | Dokument zbiorczy zawierający wyniki badań |
| Zgodność | Ocena spełnienia wymagań normowych |
| Operator | Osoba wykonująca badanie |

---

# 5. Główne encje domenowe

## 5.1 Sample (Próbka)

Reprezentuje fizyczną próbkę laboratoryjną.

### Odpowiedzialność

- identyfikacja próbki,
- śledzenie historii,
- powiązanie z mieszaniną,
- powiązanie z badaniami.

### Atrybuty

```text
SampleId
SampleNumber
MixtureId
ProductionDate
Status
CreatedAt
CreatedBy
```

### Przykład

```text
S-2026-001
```

---

## 5.2 Mixture (Mieszanina)

Opisuje skład badanego materiału.

### Atrybuty

```text
MixtureId
MixtureCode
PolymerPercentage
QuartzitePercentage
Moisture
Pigment
Description
```

### Przykład

```text
Polimer: 25%
Kwarcyt: 75%
Wilgotność: 1,5%
Pigment: Czarny
```

---

## 5.3 TestSeries (Seria Badawcza)

Grupuje badania wykonane dla określonych próbek.

### Atrybuty

```text
TestSeriesId
SeriesNumber
Description
CreatedDate
CreatedBy
Status
```

---

## 5.4 MfrTest

Opisuje badanie wskaźnika płynięcia polimeru.

### Rejestrowane parametry

```text
Temperatura
Obciążenie
Czas odcinania
Masa wytłoczki
MFR
```

### Jednostki

```text
°C
kg
s
g
g/10 min
```

---

## 5.5 StrengthTest

Opisuje badanie wytrzymałości na rozciąganie przy rozłupywaniu.

### Rejestrowane parametry

```text
Oznaczenie próbki
Siła niszcząca P
Wytrzymałość T
```

### Jednostki

```text
N
MPa
```

---

## 5.6 Standard

Reprezentuje normę jakościową.

### Przykłady

```text
PN-EN 1338
PN-EN 1339
```

### Przechowywane informacje

```text
Kod normy
Nazwa
Data obowiązywania
Wartości graniczne
```

---

## 5.7 ComplianceResult

Wynik oceny zgodności.

### Statusy

```text
COMPLIANT
NON_COMPLIANT
WARNING
```

---

## 5.8 Report

Reprezentuje raport laboratoryjny.

### Typy

```text
PDF
CSV
XLSX
```

### Atrybuty

```text
ReportId
GeneratedAt
GeneratedBy
FileLocation
```

---

## 5.9 User

Reprezentuje użytkownika systemu.

### Role

```text
Administrator
Kierownik Laboratorium
Laborant
Audytor
```

---

# 6. Agregaty DDD

Agregaty definiują granice spójności danych.

---

## 6.1 Sample Aggregate

### Aggregate Root

```text
Sample
```

### Elementy agregatu

```text
Sample
 ├─ Mixture
 ├─ TestSeries
 └─ SampleHistory
```

### Uzasadnienie

Próbka stanowi główny obiekt biznesowy, wokół którego organizowane są badania.

---

## 6.2 TestSeries Aggregate

### Aggregate Root

```text
TestSeries
```

### Elementy agregatu

```text
TestSeries
 ├─ MfrTest
 ├─ StrengthTest
 ├─ MeasurementResult
 └─ ComplianceResult
```

### Uzasadnienie

Wszystkie wyniki badań są logicznie grupowane w ramach jednej serii.

---

## 6.3 Report Aggregate

### Aggregate Root

```text
Report
```

### Elementy agregatu

```text
Report
 ├─ ReportItems
 └─ ExportFiles
```

---

# 7. Value Objects

Value Object nie posiada własnej tożsamości i jest określany wyłącznie przez wartość.

---

## Moisture

Wilgotność materiału.

```text
0 - 100 %
```

---

## Temperature

Temperatura badania.

```text
°C
```

---

## MfrValue

Wartość wskaźnika płynięcia.

```text
g/10 min
```

---

## StrengthValue

Wytrzymałość na rozciąganie.

```text
MPa
```

---

## ForceValue

Siła niszcząca.

```text
N
```

---

## SampleNumber

Numer identyfikacyjny próbki.

Przykład:

```text
S-2026-001
```

---

# 8. Zdarzenia domenowe

System wykorzystuje zdarzenia domenowe do sygnalizowania istotnych zmian biznesowych.

---

## SampleRegistered

Nowa próbka została utworzona.

---

## MixtureCreated

Zarejestrowano nową mieszaninę.

---

## TestSeriesCreated

Utworzono nową serię badawczą.

---

## MfrTestCompleted

Zakończono badanie MFR.

---

## StrengthTestCompleted

Zakończono badanie wytrzymałościowe.

---

## ComplianceVerified

Przeprowadzono ocenę zgodności.

---

## ReportGenerated

Utworzono raport.

---

## SampleArchived

Próbka została przeniesiona do archiwum.

---

# 9. Reguły biznesowe

---

## BR-001

Numer próbki musi być unikalny.

---

## BR-002

Nie można utworzyć badania bez przypisanej próbki.

---

## BR-003

Próbka musi posiadać przypisaną mieszaninę.

---

## BR-004

MFR musi być większe od zera.

```text
MFR > 0
```

---

## BR-005

Siła niszcząca musi być większa od zera.

```text
P > 0
```

---

## BR-006

Wytrzymałość musi być większa od zera.

```text
T > 0
```

---

## BR-007

Wilgotność musi mieścić się w zakresie:

```text
0 ≤ Wilgotność ≤ 100%
```

---

## BR-008

Wynik zatwierdzony nie może zostać usunięty.

---

## BR-009

Każda zmiana wyniku musi zostać zapisana w rejestrze audytowym.

---

## BR-010

Raport może zostać wygenerowany wyłącznie dla kompletnej serii badawczej.

---

## BR-011

Próbki niespełniające wymagań norm otrzymują status:

```text
NON_COMPLIANT
```

---

# 10. Model ról biznesowych

## Administrator

Odpowiada za:

- konfigurację,
- zarządzanie użytkownikami,
- słowniki systemowe.

---

## Kierownik Laboratorium

Odpowiada za:

- zatwierdzanie wyników,
- akceptację raportów,
- ocenę zgodności.

---

## Laborant

Odpowiada za:

- rejestrację próbek,
- wprowadzanie wyników,
- generowanie raportów roboczych.

---

## Audytor

Posiada dostęp wyłącznie do odczytu danych historycznych.

---

# 11. Relacje pomiędzy głównymi encjami

```text
Mieszanina
      │
      └───< Próbka
                 │
                 └───< Seria Badawcza
                               │
              ┌────────────────┴───────────────┐
              │                                │
              ▼                                ▼
         Badanie MFR               Badanie Wytrzymałościowe
              │                                │
              └──────────────┬─────────────────┘
                             ▼
                    Ocena Zgodności
                             │
                             ▼
                         Raport
```

---

# 12. Model odpowiedzialności biznesowej

| Obszar | Odpowiedzialność |
|---------|------------------|
| Sample Management | Rejestracja i identyfikacja próbek |
| Mixture Management | Zarządzanie recepturami |
| Laboratory Testing | Rejestracja wyników badań |
| Quality Compliance | Ocena zgodności z normami |
| Reporting | Raportowanie i eksport danych |
| User Management | Uwierzytelnianie i autoryzacja |

---

# 13. Powiązane dokumenty

```text
01-Architecture-Overview.md
03-Technology-Decision.md
04-Data-Model.md
05-API-Design.md
06-Security.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja dokumentu analizy domenowej |
