# 05 - Projekt API

# CompLab MFR/T

## Specyfikacja REST API

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Architektura:** REST API + JWT + RBAC  
**Format danych:** JSON  
**Protokół:** HTTPS  
**Kodowanie:** UTF-8

---

# 1. Cel dokumentu

Celem dokumentu jest przedstawienie interfejsów REST API dla systemu CompLab MFR/T.

API odpowiada za:

- zarządzanie użytkownikami,
- uwierzytelnianie,
- zarządzanie próbkami,
- zarządzanie mieszaninami,
- zarządzanie seriami badawczymi,
- rejestrację badań MFR,
- rejestrację badań wytrzymałościowych,
- ocenę zgodności,
- raportowanie,
- eksport danych.

---

# 2. Standardy API

## Styl architektoniczny

```text
REST
```

---

## Format danych

```http
Content-Type: application/json
```

---

## Format dat

```text
ISO 8601 UTC
```

Przykład:

```json
{
  "createdAt": "2026-09-24T12:30:00Z"
}
```

---

## Wersjonowanie API

Wersja API umieszczana jest w adresie URL.

Przykład:

```http
/api/v1/samples
```

---

## Statusy HTTP

| Kod | Znaczenie |
|------|------|
| 200 | OK |
| 201 | Utworzono |
| 204 | Brak zawartości |
| 400 | Błędne dane |
| 401 | Brak autoryzacji |
| 403 | Brak uprawnień |
| 404 | Nie znaleziono |
| 409 | Konflikt |
| 422 | Błąd walidacji |
| 500 | Błąd serwera |

---

# 3. Uwierzytelnianie

## Endpoint logowania

### POST

```http
POST /api/v1/auth/login
```

---

### Request

```json
{
  "email": "laborant@complab.pl",
  "password": "Haslo123!"
}
```

---

### Response

```json
{
  "accessToken": "jwt-token",
  "refreshToken": "refresh-token",
  "expiresIn": 3600
}
```

---

## Odświeżenie tokenu

### POST

```http
POST /api/v1/auth/refresh
```

---

### Request

```json
{
  "refreshToken": "refresh-token"
}
```

---

### Response

```json
{
  "accessToken": "new-jwt-token",
  "refreshToken": "new-refresh-token"
}
```

---

## Wylogowanie

### POST

```http
POST /api/v1/auth/logout
```

---

### Response

```json
{
  "message": "Wylogowano pomyślnie."
}
```

---

# 4. API Użytkowników

## Pobranie użytkowników

### GET

```http
GET /api/v1/users
```

---

### Response

```json
[
  {
    "userId": "uuid",
    "firstName": "Jan",
    "lastName": "Kowalski",
    "role": "Operator"
  }
]
```

---

## Pobranie użytkownika

### GET

```http
GET /api/v1/users/{userId}
```

---

## Utworzenie użytkownika

### POST

```http
POST /api/v1/users
```

---

### Request

```json
{
  "firstName": "Jan",
  "lastName": "Kowalski",
  "email": "jan.kowalski@complab.pl",
  "role": "Operator"
}
```

---

### Response

```json
{
  "userId": "uuid"
}
```

---

## Aktualizacja użytkownika

### PUT

```http
PUT /api/v1/users/{userId}
```

---

## Usunięcie użytkownika

### DELETE

```http
DELETE /api/v1/users/{userId}
```

---

# 5. API Mieszanin

## Pobranie wszystkich mieszanin

### GET

```http
GET /api/v1/mixtures
```

---

### Response

```json
[
  {
    "mixtureId": "uuid",
    "mixtureCode": "MIX-001",
    "polymerPercent": 25,
    "quartzitePercent": 75,
    "moisture": 1.5
  }
]
```

---

## Utworzenie mieszaniny

### POST

```http
POST /api/v1/mixtures
```

---

### Request

```json
{
  "mixtureCode": "MIX-001",
  "polymerPercent": 25,
  "quartzitePercent": 75,
  "moisture": 1.5,
  "pigment": "Grafit"
}
```

---

### Response

```json
{
  "mixtureId": "uuid"
}
```

---

## Aktualizacja mieszaniny

### PUT

```http
PUT /api/v1/mixtures/{mixtureId}
```

---

## Usunięcie mieszaniny

### DELETE

```http
DELETE /api/v1/mixtures/{mixtureId}
```

---

# 6. API Próbek

## Pobranie wszystkich próbek

### GET

```http
GET /api/v1/samples
```

---

### Parametry filtrowania

```http
GET /api/v1/samples?status=Approved
```

```http
GET /api/v1/samples?sampleNumber=S-2026-001
```

---

### Response

```json
[
  {
    "sampleId": "uuid",
    "sampleNumber": "S-2026-001",
    "status": "Testing"
  }
]
```

---

## Pobranie szczegółów próbki

### GET

```http
GET /api/v1/samples/{sampleId}
```

---

### Response

```json
{
  "sampleId": "uuid",
  "sampleNumber": "S-2026-001",
  "mixtureId": "uuid",
  "status": "Testing"
}
```

---

## Utworzenie próbki

### POST

```http
POST /api/v1/samples
```

---

### Request

```json
{
  "sampleNumber": "S-2026-001",
  "mixtureId": "uuid",
  "productionDate": "2026-09-24"
}
```

---

### Response

```json
{
  "sampleId": "uuid"
}
```

---

## Aktualizacja próbki

### PUT

```http
PUT /api/v1/samples/{sampleId}
```

---

### Request

```json
{
  "status": "Approved"
}
```

---

## Archiwizacja próbki

### POST

```http
POST /api/v1/samples/{sampleId}/archive
```

---

### Response

```json
{
  "message": "Próbka została zarchiwizowana."
}
```

---

# 7. API Serii Badawczych

## Pobranie serii

### GET

```http
GET /api/v1/test-series
```

---

## Szczegóły serii

### GET

```http
GET /api/v1/test-series/{testSeriesId}
```

---

### Response

```json
{
  "testSeriesId": "uuid",
  "seriesNumber": "TS-2026-001",
  "status": "InProgress"
}
```

---

## Utworzenie serii

### POST

```http
POST /api/v1/test-series
```

---

### Request

```json
{
  "sampleId": "uuid",
  "seriesNumber": "TS-2026-001"
}
```

---

### Response

```json
{
  "testSeriesId": "uuid"
}
```

---

## Zatwierdzenie serii

### POST

```http
POST /api/v1/test-series/{testSeriesId}/approve
```

---

# 8. API Badań MFR

## Pobranie badań

### GET

```http
GET /api/v1/mfr-tests
```

---

## Szczegóły badania

### GET

```http
GET /api/v1/mfr-tests/{mfrTestId}
```

---

### Response

```json
{
  "mfrTestId": "uuid",
  "temperature": 230,
  "load": 2.16,
  "extrudateMass": 4.5,
  "cuttingTime": 30,
  "mfrValue": 9.0
}
```

---

## Rejestracja badania

### POST

```http
POST /api/v1/mfr-tests
```

---

### Request

```json
{
  "testSeriesId": "uuid",
  "temperature": 230,
  "load": 2.16,
  "extrudateMass": 4.5,
  "cuttingTime": 30
}
```

---

### Response

```json
{
  "mfrTestId": "uuid",
  "mfrValue": 9.0
}
```

---

## Aktualizacja badania

### PUT

```http
PUT /api/v1/mfr-tests/{mfrTestId}
```

---

## Usunięcie badania

### DELETE

```http
DELETE /api/v1/mfr-tests/{mfrTestId}
```

---

# 9. API Badań Wytrzymałościowych

## Pobranie badań

### GET

```http
GET /api/v1/strength-tests
```

---

## Szczegóły badania

### GET

```http
GET /api/v1/strength-tests/{strengthTestId}
```

---

### Response

```json
{
  "strengthTestId": "uuid",
  "breakingForceP": 12000,
  "strengthT": 4.1
}
```

---

## Rejestracja badania

### POST

```http
POST /api/v1/strength-tests
```

---

### Request

```json
{
  "testSeriesId": "uuid",
  "breakingForceP": 12000,
  "strengthT": 4.1
}
```

---

### Response

```json
{
  "strengthTestId": "uuid"
}
```

---

## Aktualizacja badania

### PUT

```http
PUT /api/v1/strength-tests/{strengthTestId}
```

---

## Usunięcie badania

### DELETE

```http
DELETE /api/v1/strength-tests/{strengthTestId}
```

---

# 10. API Oceny Zgodności

## Uruchomienie walidacji normowej

### POST

```http
POST /api/v1/compliance/validate
```

---

### Request

```json
{
  "testSeriesId": "uuid",
  "standardCode": "PN-EN-1338"
}
```

---

### Response

```json
{
  "result": "COMPLIANT",
  "remarks": "Wyniki spełniają wymagania normy."
}
```

---

## Pobranie wyniku walidacji

### GET

```http
GET /api/v1/compliance/{testSeriesId}
```

---

# 11. API Raportów

## Pobranie raportów

### GET

```http
GET /api/v1/reports
```

---

## Wygenerowanie raportu PDF

### POST

```http
POST /api/v1/reports/pdf
```

---

### Request

```json
{
  "testSeriesId": "uuid"
}
```

---

### Response

```json
{
  "reportId": "uuid",
  "downloadUrl": "/files/reports/report.pdf"
}
```

---

## Wygenerowanie raportu CSV

### POST

```http
POST /api/v1/reports/csv
```

---

## Wygenerowanie raportu XLSX

### POST

```http
POST /api/v1/reports/xlsx
```

---

## Pobranie raportu

### GET

```http
GET /api/v1/reports/{reportId}
```

---

## Pobranie pliku raportu

### GET

```http
GET /api/v1/reports/{reportId}/download
```

---

# 12. API Dashboardów

## Statystyki MFR

### GET

```http
GET /api/v1/dashboard/mfr
```

---

### Response

```json
{
  "averageMfr": 8.9,
  "minimumMfr": 7.1,
  "maximumMfr": 10.4,
  "sampleCount": 473
}
```

---

## Statystyki wytrzymałości

### GET

```http
GET /api/v1/dashboard/strength
```

---

### Response

```json
{
  "averageStrength": 4.3,
  "minimumStrength": 2.9,
  "maximumStrength": 5.2,
  "sampleCount": 473
}
```

---

## Dane wykresu MFR

### GET

```http
GET /api/v1/dashboard/charts/mfr
```

---

## Dane wykresu wytrzymałości

### GET

```http
GET /api/v1/dashboard/charts/strength
```

---

# 13. API Audytu

## Pobranie historii zmian

### GET

```http
GET /api/v1/audit
```

---

### Parametry

```http
GET /api/v1/audit?entity=Sample
```

```http
GET /api/v1/audit?userId=uuid
```

---

### Response

```json
[
  {
    "entityName": "Sample",
    "entityId": "uuid",
    "action": "UPDATE",
    "performedBy": "Jan Kowalski",
    "performedAt": "2026-09-24T12:00:00Z"
  }
]
```

---

# 14. Role i uprawnienia

## Administrator

Dostęp do wszystkich endpointów.

---

## Kierownik Laboratorium

Dostęp do:

```text
Samples
Mixtures
TestSeries
MfrTests
StrengthTests
Compliance
Reports
Dashboard
```

---

## Laborant

Dostęp do:

```text
Samples
Mixtures
TestSeries
MfrTests
StrengthTests
Reports
```

bez możliwości zatwierdzania wyników.

---

## Audytor

Dostęp wyłącznie do:

```text
GET
```

oraz:

```text
Reports
Audit
```

---

# 15. Standard błędów API

## Format odpowiedzi błędów

```json
{
  "type": "ValidationError",
  "title": "Błąd walidacji",
  "status": 422,
  "traceId": "trace-id",
  "errors": [
    {
      "field": "sampleNumber",
      "message": "Numer próbki jest wymagany."
    }
  ]
}
```

---

# 16. Niefunkcjonalne wymagania API

## Wydajność

Maksymalny czas odpowiedzi:

```text
500 ms
```

dla 95% zapytań.

---

## Bezpieczeństwo

Wymagane:

```text
HTTPS
JWT
RBAC
TLS 1.3
Audit Log
```

---

## Dostępność

Docelowa dostępność:

```text
99,5%
```

---

## Logowanie

Każde żądanie API otrzymuje:

```text
CorrelationId
TraceId
```

umożliwiające analizę logów.

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
03-Technology-Decision.md
04-Data-Model.md
06-Security.md
07-DevOps.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja specyfikacji REST API |
