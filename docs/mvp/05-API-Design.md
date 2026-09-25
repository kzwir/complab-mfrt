# 05 - Projekt API

# CompLab MFR/T

## Specyfikacja REST API MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition

**Architektura:**

```text
REST API
JWT Authentication
```

**Format danych:**

```text
JSON
```

**Protokół:**

```text
HTTPS
```

---

# 1. Cel dokumentu

Dokument opisuje interfejs REST API dla wersji MVP systemu CompLab MFR/T.

API umożliwia:

- logowanie użytkowników,
- zarządzanie mieszaninami,
- zarządzanie próbkami,
- rejestrację wyników badań,
- prezentację podstawowych danych dashboardowych.

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
  "createdAt": "2026-09-25T10:00:00Z"
}
```

---

## Wersjonowanie

```http
/api/v1/
```

Przykład:

```http
/api/v1/samples
```

---

## Statusy HTTP

| Kod | Znaczenie |
|-------|-------|
| 200 | OK |
| 201 | Utworzono |
| 400 | Błędne dane |
| 401 | Brak autoryzacji |
| 403 | Brak uprawnień |
| 404 | Nie znaleziono |
| 500 | Błąd serwera |

---

# 3. Uwierzytelnianie

## Logowanie

### POST

```http
POST /api/v1/auth/login
```

### Request

```json
{
  "email": "admin@complab.pl",
  "password": "Admin123!"
}
```

### Response

```json
{
  "token": "jwt-token",
  "expiresIn": 3600
}
```

---

# 4. API Dashboard

## Pobranie danych dashboardu

### GET

```http
GET /api/v1/dashboard
```

### Response

```json
{
  "mixtureCount": 15,
  "sampleCount": 120,
  "testCount": 450
}
```

---

# 5. API Mieszanin

## Pobranie wszystkich mieszanin

### GET

```http
GET /api/v1/mixtures
```

### Response

```json
[
  {
    "mixtureId": "uuid",
    "code": "MIX-001",
    "polymerPercent": 25,
    "quartzitePercent": 75
  }
]
```

---

## Pobranie mieszaniny

### GET

```http
GET /api/v1/mixtures/{mixtureId}
```

---

## Dodanie mieszaniny

### POST

```http
POST /api/v1/mixtures
```

### Request

```json
{
  "code": "MIX-001",
  "polymerPercent": 25,
  "quartzitePercent": 75
}
```

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

### Request

```json
{
  "code": "MIX-001",
  "polymerPercent": 30,
  "quartzitePercent": 70
}
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

## Pobranie szczegółów próbki

### GET

```http
GET /api/v1/samples/{sampleId}
```

### Response

```json
{
  "sampleId": "uuid",
  "sampleNumber": "S-2026-001",
  "mixtureId": "uuid",
  "productionDate": "2026-09-25"
}
```

---

## Dodanie próbki

### POST

```http
POST /api/v1/samples
```

### Request

```json
{
  "sampleNumber": "S-2026-001",
  "mixtureId": "uuid",
  "productionDate": "2026-09-25"
}
```

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

### Request

```json
{
  "sampleNumber": "S-2026-001"
}
```

---

## Usunięcie próbki

### DELETE

```http
DELETE /api/v1/samples/{sampleId}
```

---

# 7. API Badań

## Pobranie wszystkich badań

### GET

```http
GET /api/v1/tests
```

---

## Pobranie pojedynczego badania

### GET

```http
GET /api/v1/tests/{testId}
```

### Response

```json
{
  "testId": "uuid",
  "sampleId": "uuid",
  "testType": "MFR",
  "measurementValue": 8.9,
  "createdAt": "2026-09-25T10:00:00Z"
}
```

---

## Dodanie badania

### POST

```http
POST /api/v1/tests
```

### Request

```json
{
  "sampleId": "uuid",
  "testType": "MFR",
  "measurementValue": 8.9
}
```

### Przykład badania wytrzymałościowego

```json
{
  "sampleId": "uuid",
  "testType": "STRENGTH",
  "measurementValue": 4.2
}
```

### Response

```json
{
  "testId": "uuid"
}
```

---

## Aktualizacja badania

### PUT

```http
PUT /api/v1/tests/{testId}
```

### Request

```json
{
  "measurementValue": 9.1
}
```

---

## Usunięcie badania

### DELETE

```http
DELETE /api/v1/tests/{testId}
```

---

# 8. Role i uprawnienia

## Administrator

Pełny dostęp.

Dostęp do:

```text
Dashboard
Mixtures
Samples
Tests
```

---

## Operator

Dostęp do:

```text
Dashboard
Mixtures
Samples
Tests
```

Bez możliwości zarządzania użytkownikami.

---

# 9. Standard błędów

## Format odpowiedzi

```json
{
  "title": "Validation Error",
  "status": 400,
  "errors": [
    {
      "field": "sampleNumber",
      "message": "Pole jest wymagane."
    }
  ]
}
```

---

# 10. Wymagania niefunkcjonalne

## Wydajność

Docelowo:

```text
< 1 sekunda
```

dla większości zapytań.

---

## Bezpieczeństwo

Wymagane:

```text
HTTPS

JWT

Role:
- Administrator
- Operator
```

---

## Dostępność

Dla MVP:

```text
95%
```

---

# 11. Zakres rozwoju po MVP

## Wersja 2

Planowane endpointy:

```text
/api/reports
/api/compliance
```

---

## Wersja 3

Planowane endpointy:

```text
/api/devices
/api/import
/api/dashboard/analytics
```

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
02-Domain-Analysis.md
03-Technology-Decision.md
04-Data-Model.md
06-Security.md
```

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie API do zakresu MVP |
