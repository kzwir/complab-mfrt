# 06 - Bezpieczeństwo

# CompLab MFR/T

## Bezpieczeństwo MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition

---

# 1. Cel dokumentu

Celem dokumentu jest określenie minimalnych wymagań bezpieczeństwa dla wersji MVP systemu CompLab MFR/T.

Zakres obejmuje:

- uwierzytelnianie użytkowników,
- autoryzację,
- ochronę API,
- ochronę danych,
- kopie zapasowe,
- bezpieczną konfigurację aplikacji.

---

# 2. Założenia bezpieczeństwa

System przechowuje dane laboratoryjne oraz dane użytkowników.

W MVP należy zapewnić:

- uwierzytelnianie użytkowników,
- kontrolę dostępu,
- ochronę API,
- bezpieczne przechowywanie haseł,
- możliwość wykonania kopii zapasowej bazy danych.

---

# 3. Cele bezpieczeństwa

## Poufność

Dane dostępne są wyłącznie dla zalogowanych użytkowników.

---

## Integralność

Dane nie mogą zostać zmodyfikowane bez odpowiednich uprawnień.

---

## Dostępność

System powinien być dostępny dla użytkowników laboratorium w godzinach pracy.

---

# 4. Uwierzytelnianie

## Mechanizm

```text
JWT Bearer Authentication
```

---

## Proces logowania

```text
Użytkownik
      │
      ▼
Logowanie
      │
      ▼
Walidacja danych
      │
      ▼
JWT Token
      │
      ▼
Dostęp do API
```

---

## Ważność tokenu

```text
60 minut
```

---

## Przykład JWT Claims

```json
{
  "sub": "user-id",
  "email": "admin@complab.pl",
  "role": "Administrator"
}
```

---

# 5. Autoryzacja

W MVP stosowany jest uproszczony model RBAC.

---

## Administrator

Pełny dostęp do systemu.

Może:

- zarządzać użytkownikami,
- zarządzać danymi laboratoryjnymi,
- wykonywać operacje administracyjne.

---

## Operator

Może:

- tworzyć mieszaniny,
- tworzyć próbki,
- rejestrować wyniki badań,
- przeglądać dane.

---

# 6. Polityka haseł

Minimalne wymagania:

```text
Minimum 8 znaków

1 duża litera

1 cyfra
```

---

## Przykład

```text
CompLab2026
```

---

# 7. Ochrona API

Każde zabezpieczone wywołanie API wymaga:

```http
Authorization: Bearer <token>
```

---

## Endpoint publiczny

```http
POST /api/v1/auth/login
```

---

## Endpointy chronione

```text
/api/v1/dashboard

/api/v1/mixtures

/api/v1/samples

/api/v1/tests
```

---

# 8. Walidacja danych

Walidacja wykonywana jest na dwóch poziomach.

---

## Frontend

Angular:

- wymagane pola,
- długości danych,
- zakresy wartości.

---

## Backend

ASP.NET Core:

- DataAnnotations,
- walidacja biznesowa.

---

## Przykłady

```text
SampleNumber wymagane
```

```text
MeasurementValue > 0
```

```text
Mixture Code wymagany
```

---

# 9. Ochrona przed podstawowymi zagrożeniami

## SQL Injection

Ochrona:

```text
Entity Framework Core
Parametryzowane zapytania
```

---

## XSS

Ochrona:

```text
Walidacja danych wejściowych
Domyślne zabezpieczenia Angular
```

---

## Broken Access Control

Ochrona:

```text
JWT
Role użytkowników
Autoryzacja endpointów
```

---

# 10. Przechowywanie haseł

Hasła są przechowywane wyłącznie jako hash.

Mechanizm:

```text
ASP.NET Identity

PBKDF2
```

---

# 11. Szyfrowanie transmisji

Wszystkie połączenia produkcyjne powinny korzystać z:

```text
HTTPS
```

---

# 12. Backup

## Baza danych

Kopia zapasowa:

```text
1 raz dziennie
```

---

## Retencja

```text
30 dni
```

---

# 13. Logowanie aplikacyjne

## Zakres

Rejestrowane są:

- błędy aplikacji,
- błędy API,
- błędy logowania.

---

## Mechanizm

```text
ILogger
```

---

# 14. Bezpieczeństwo infrastruktury

## Serwer

Rekomendacja:

```text
Ubuntu Server LTS
```

---

## Aktualizacje

Regularne aktualizacje:

```text
System operacyjny

.NET Runtime

PostgreSQL
```

---

## Firewall

Otwarte porty:

```text
80

443
```

---

# 15. Bezpieczeństwo Docker

Usługi:

```text
Frontend

Backend

PostgreSQL
```

---

## Zalecenia

- nie używać kont root,
- używać oficjalnych obrazów,
- aktualizować obrazy kontenerów.

---

# 16. Wymagania obowiązkowe MVP

## Musi zostać wdrożone

- JWT Authentication,
- Role użytkowników,
- HTTPS,
- Hashowanie haseł,
- Walidacja danych,
- Backup bazy danych,
- Ochrona przed SQL Injection.

---

# 17. Funkcjonalności odłożone do V2

Planowane rozszerzenia:

```text
Refresh Token

Audyt zmian

Serilog

Raporty bezpieczeństwa
```

---

# 18. Funkcjonalności odłożone do V3

Planowane rozszerzenia:

```text
MFA

SSO

Microsoft Entra ID

SIEM

SOC

Centralne zarządzanie tożsamością
```

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md

04-Data-Model.md

05-API-Design.md

07-DevOps.md

09-Deployment.md
```

---

# Lista kontrolna MVP

## Aplikacja

- [ ] JWT skonfigurowane
- [ ] Role skonfigurowane
- [ ] Walidacja danych wdrożona
- [ ] Hashowanie haseł wdrożone

---

## Infrastruktura

- [ ] HTTPS aktywny
- [ ] Backup działa poprawnie
- [ ] Firewall skonfigurowany

---

## Baza danych

- [ ] Migracje wykonane
- [ ] Konto administratora utworzone
- [ ] Backup zweryfikowany

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Wersja docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie wymagań bezpieczeństwa do MVP |
