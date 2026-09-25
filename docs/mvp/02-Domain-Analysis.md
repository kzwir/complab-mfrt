# 02 - Analiza Domeny

# CompLab MFR/T

## Analiza Domenowa MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition  
**Powiązanie:** Dokument rozwija założenia przedstawione w dokumencie `01-Architecture-Overview.md`.

---

# 1. Cel dokumentu

Celem dokumentu jest przedstawienie uproszczonego modelu domenowego systemu CompLab MFR/T dla wersji MVP.

Model domenowy koncentruje się wyłącznie na najważniejszych procesach biznesowych:

- rejestracji mieszanin,
- rejestracji próbek,
- rejestracji wyników badań,
- przeglądaniu danych laboratoryjnych.

Dokument stanowi podstawę implementacji warstw:

```text
Domain
Application
```

---

# 2. Opis domeny biznesowej

System CompLab MFR/T wspiera laboratorium prowadzące badania materiałów kompozytowych.

W wersji MVP proces biznesowy obejmuje:

1. utworzenie mieszaniny,
2. rejestrację próbki,
3. wykonanie badania,
4. zapis wyniku,
5. przegląd danych historycznych.

System nie realizuje:

- komunikacji z urządzeniami laboratoryjnymi,
- automatycznego pobierania danych,
- oceny zgodności z normami,
- generowania raportów PDF,
- workflow zatwierdzania wyników.

---

# 3. Bounded Context

W MVP zastosowano jeden kontekst biznesowy.

## Laboratory Management

Odpowiada za:

- użytkowników,
- mieszaniny,
- próbki,
- badania.

---

# 4. Ujednolicony język domenowy (Ubiquitous Language)

| Termin | Znaczenie |
|----------|----------|
| Mieszanina | Receptura materiału kompozytowego |
| Próbka | Materiał poddawany badaniom |
| Badanie | Wynik pomiaru przypisany do próbki |
| Wynik | Wartość pomiarowa badania |
| Operator | Użytkownik wprowadzający dane |
| MFR | Badanie wskaźnika płynięcia |
| Strength | Badanie wytrzymałościowe |

---

# 5. Główne encje domenowe

## User

Reprezentuje użytkownika systemu.

### Odpowiedzialność

- logowanie,
- dostęp do systemu,
- wykonywanie operacji laboratoryjnych.

### Atrybuty

```text
UserId
Email
PasswordHash
Role
```

---

## Mixture

Reprezentuje mieszaninę materiałową.

### Odpowiedzialność

- przechowywanie parametrów mieszaniny,
- identyfikacja receptury.

### Atrybuty

```text
MixtureId
Code
PolymerPercent
QuartzitePercent
```

### Przykład

```text
MIX-001
Polimer 25%
Kwarcyt 75%
```

---

## Sample

Reprezentuje próbkę laboratoryjną.

### Odpowiedzialność

- identyfikacja próbki,
- przypisanie do mieszaniny,
- przechowywanie historii badań.

### Atrybuty

```text
SampleId
SampleNumber
MixtureId
ProductionDate
```

### Przykład

```text
S-2026-001
```

---

## Test

Reprezentuje pojedynczy wynik badania.

### Odpowiedzialność

- zapis wyniku pomiaru,
- przypisanie wyniku do próbki.

### Atrybuty

```text
TestId
SampleId
TestType
MeasurementValue
CreatedAt
```

### Typy badań

```text
MFR
STRENGTH
```

---

# 6. Agregaty

W MVP zastosowano jeden główny agregat.

## Sample Aggregate

### Aggregate Root

```text
Sample
```

### Struktura

```text
Sample
 ├─ Mixture
 └─ Test
```

### Uzasadnienie

Próbka stanowi centralny obiekt domenowy, wokół którego organizowane są wszystkie badania.

---

# 7. Value Objects

## SampleNumber

Numer identyfikacyjny próbki.

Przykład:

```text
S-2026-001
```

---

## TestType

Typ badania.

Dopuszczalne wartości:

```text
MFR
STRENGTH
```

---

## MeasurementValue

Wartość pomiaru.

Przykłady:

```text
8.9
4.3
```

---

# 8. Zdarzenia domenowe

W MVP nie stosuje się Domain Events.

Ewentualne zdarzenia domenowe zostaną wprowadzone w kolejnych wersjach systemu.

---

# 9. Reguły biznesowe

## BR-001

Numer próbki musi być unikalny.

---

## BR-002

Próbka musi być przypisana do mieszaniny.

---

## BR-003

Badanie musi być przypisane do próbki.

---

## BR-004

Wartość badania musi być większa od zera.

```text
MeasurementValue > 0
```

---

## BR-005

Kod mieszaniny musi być unikalny.

---

## BR-006

Użytkownik musi być zalogowany.

---

# 10. Role biznesowe

## Administrator

Odpowiada za:

- zarządzanie użytkownikami,
- konfigurację systemu.

---

## Operator

Odpowiada za:

- rejestrację mieszanin,
- rejestrację próbek,
- rejestrację badań,
- przegląd danych.

---

# 11. Relacje pomiędzy encjami

```text
Mixture
   │
   └──< Sample
            │
            └──< Test
```

---

# 12. Model odpowiedzialności biznesowej

| Obszar | Odpowiedzialność |
|---------|---------|
| User Management | Logowanie użytkowników |
| Mixture Management | Zarządzanie mieszaninami |
| Sample Management | Zarządzanie próbkami |
| Laboratory Testing | Rejestracja wyników badań |

---

# 13. Zakres rozwoju po MVP

## Wersja 2

- ocena zgodności,
- raporty PDF,
- eksport XLSX,
- audyt zmian.

## Wersja 3

- integracja urządzeń laboratoryjnych,
- automatyczny import wyników,
- dashboardy analityczne,
- statystyka procesowa.

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
03-Technology-Decision.md
04-Data-Model.md
05-API-Design.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja pełna |
| 2.0 MVP | 2026-09-25 | Uproszczenie modelu domenowego do MVP |
