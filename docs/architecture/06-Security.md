# 06 - Bezpieczeństwo

# CompLab MFR/T

## Architektura Bezpieczeństwa

**Wersja dokumentu:** 1.0  
**Status:** Ready for Development  
**Powiązanie:** Dokument rozszerza założenia przedstawione w dokumentach `01-Architecture-Overview.md`, `04-Data-Model.md` oraz `05-API-Design.md`.

---

# 1. Cel dokumentu

Celem dokumentu jest określenie wymagań bezpieczeństwa dla systemu CompLab MFR/T oraz sposobu ich realizacji na poziomie:

- aplikacji,
- API,
- bazy danych,
- infrastruktury,
- procesu wytwarzania oprogramowania,
- archiwizacji danych laboratoryjnych.

Dokument stanowi podstawę do realizacji wymagań:

- OWASP ASVS Level 2,
- ISO 9001,
- dobrych praktyk LIMS,
- DevSecOps.

---

# 2. Założenia bezpieczeństwa

System przechowuje dane laboratoryjne mające znaczenie badawcze i jakościowe.

Chociaż nie przetwarza danych niejawnych ani medycznych, musi zapewniać:

- integralność danych,
- poufność danych użytkowników,
- identyfikowalność zmian,
- odporność na błędy użytkowników,
- możliwość odtworzenia historii badań.

---

# 3. Cele bezpieczeństwa

## C-01 Poufność

Dostęp do danych mają wyłącznie uprawnieni użytkownicy.

---

## C-02 Integralność

Wyniki badań nie mogą zostać zmodyfikowane bez pozostawienia śladu audytowego.

---

## C-03 Dostępność

System powinien być dostępny dla personelu laboratoryjnego zgodnie z założonym poziomem SLA.

---

## C-04 Rozliczalność

Każda operacja musi być możliwa do przypisania do konkretnego użytkownika.

---

## C-05 Odtwarzalność

Dane muszą być możliwe do odzyskania po awarii.

---

# 4. Model uwierzytelniania

## Mechanizm

System wykorzystuje:

```text
JWT (JSON Web Token)
+
Refresh Token
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
JWT Access Token
      │
      ▼
Autoryzacja API
```

---

## Parametry tokenów

### Access Token

```text
Ważność: 60 minut
```

---

### Refresh Token

```text
Ważność: 7 dni
```

---

## Claims JWT

Przykład:

```json
{
  "sub": "user-id",
  "email": "user@complab.pl",
  "role": "Operator",
  "name": "Jan Kowalski"
}
```

---

# 5. Autoryzacja (RBAC)

System wykorzystuje model:

```text
Role Based Access Control
```

---

# 5.1 Administrator

Pełny dostęp do systemu.

Uprawnienia:

- zarządzanie użytkownikami,
- konfiguracja systemu,
- słowniki,
- raporty,
- audyt,
- dostęp administracyjny.

---

# 5.2 Kierownik Laboratorium

Uprawnienia:

- zatwierdzanie wyników,
- zatwierdzanie raportów,
- walidacja zgodności,
- przegląd danych historycznych,
- zarządzanie seriami badawczymi.

---

# 5.3 Laborant

Uprawnienia:

- rejestracja próbek,
- rejestracja mieszanin,
- wprowadzanie wyników,
- generowanie raportów roboczych.

Ograniczenia:

- brak możliwości zatwierdzania wyników.

---

# 5.4 Audytor

Uprawnienia:

- tylko odczyt danych,
- dostęp do raportów,
- dostęp do dziennika audytowego.

Brak możliwości edycji.

---

# 6. Polityka haseł

## Minimalne wymagania

Hasło musi zawierać:

```text
Minimum 12 znaków
```

oraz przynajmniej:

```text
1 małą literę
1 dużą literę
1 cyfrę
1 znak specjalny
```

---

## Przykład

```text
CompLab#2026!
```

---

## Zakazane

- login jako hasło,
- nazwa firmy jako hasło,
- słownikowe hasła.

---

# 7. Zarządzanie sesją

## Limit aktywności

Brak aktywności:

```text
30 minut
```

powoduje automatyczne wylogowanie użytkownika.

---

## Jednoczesne sesje

Rekomendacja:

```text
maksymalnie 5 sesji
na użytkownika
```

---

# 8. Ochrona API

## Wymagania

Każde wywołanie API musi:

```http
Authorization: Bearer <token>
```

---

## Dostęp niezalogowany

Dopuszczalne wyłącznie dla:

```text
/api/auth/login
/api/auth/refresh
```

---

# 9. Walidacja danych wejściowych

## Zasada

Każde dane wejściowe są walidowane po stronie:

### Frontend

- wymagane pola,
- długości danych,
- zakresy wartości.

---

### Backend

- FluentValidation,
- walidacja biznesowa,
- walidacja domenowa.

---

## Przykład

Dla badania MFR:

```text
MFR > 0
```

---

Dla wilgotności:

```text
0 ≤ Moisture ≤ 100
```

---

# 10. Ochrona przed najczęstszymi zagrożeniami OWASP

## SQL Injection

Ochrona:

- Entity Framework Core,
- parametryzowane zapytania.

---

## Cross Site Scripting (XSS)

Ochrona:

- kodowanie danych wyświetlanych,
- walidacja wejścia,
- React DOM sanitization.

---

## Cross Site Request Forgery (CSRF)

Ochrona:

- JWT,
- SameSite Cookies,
- tokeny CSRF dla funkcji administracyjnych.

---

## Broken Access Control

Ochrona:

- RBAC,
- autoryzacja endpointów,
- walidacja uprawnień na poziomie aplikacji.

---

## Security Misconfiguration

Ochrona:

- bezpieczne konfiguracje Docker,
- brak domyślnych haseł,
- konfiguracja HTTPS.

---

# 11. Audyt zmian

## Cel

Zapewnienie pełnej identyfikowalności wszystkich operacji.

---

# Rejestrowane operacje

## Użytkownicy

- logowanie,
- wylogowanie,
- utworzenie użytkownika,
- zmiana uprawnień.

---

## Dane laboratoryjne

- utworzenie próbki,
- modyfikacja próbki,
- archiwizacja próbki,
- utworzenie badania,
- modyfikacja badania.

---

## Raporty

- generowanie,
- eksport,
- pobranie.

---

# Zakres audytu

Przykładowy zapis:

```json
{
  "entity": "Sample",
  "entityId": "uuid",
  "action": "UPDATE",
  "performedBy": "user-id",
  "performedAt": "2026-09-24T12:00:00Z"
}
```

---

# 12. Szyfrowanie danych

## Dane w transmisji

Wszystkie połączenia:

```text
HTTPS
TLS 1.3
```

---

## Dane w spoczynku

Rekomendacja:

```text
AES-256
```

realizowane poprzez:

- szyfrowanie dysków,
- szyfrowanie wolumenów Docker,
- szyfrowanie macierzy.

---

# 13. Ochrona danych w bazie danych

## Hasła

Przechowywane wyłącznie jako:

```text
Hash
```

Algorytm:

```text
ASP.NET Identity
PBKDF2
```

---

## Dane laboratoryjne

Nie są przechowywane w postaci zaszyfrowanej na poziomie kolumn, jednak baza danych powinna znajdować się na szyfrowanym wolumenie.

---

# 14. Backup i Disaster Recovery

## Backup bazy danych

Codziennie:

```text
01:00
```

---

## Backup raportów

Codziennie:

```text
02:00
```

---

## Backup pełny

Raz w tygodniu.

---

## Backup archiwalny

Raz w miesiącu.

---

# Retencja backupów

## Dzienny

```text
30 dni
```

---

## Tygodniowy

```text
12 tygodni
```

---

## Miesięczny

```text
60 miesięcy
```

---

# RPO

Maksymalna utrata danych:

```text
24 godziny
```

---

# RTO

Maksymalny czas odtworzenia:

```text
4 godziny
```

---

# 15. Retencja danych laboratoryjnych

## Wyniki badań

```text
15 lat
```

---

## Raporty

```text
15 lat
```

---

## Audit Log

```text
10 lat
```

---

## Logi aplikacyjne

```text
2 lata
```

---

# 16. Logowanie i monitorowanie

## Mechanizm

```text
Serilog
```

---

## Poziomy logowania

```text
Information
Warning
Error
Critical
Audit
```

---

## Logowane zdarzenia

- błędy aplikacji,
- błędy API,
- błędy uwierzytelniania,
- problemy z bazą danych,
- operacje administracyjne.

---

# 17. Bezpieczeństwo infrastruktury

## Serwer aplikacyjny

Wymagania:

- Linux LTS,
- automatyczne aktualizacje,
- wyłączone nieużywane porty.

---

## Firewall

Otwarte wyłącznie:

```text
80
443
```

oraz port administracyjny dostępny wyłącznie z sieci wewnętrznej.

---

## Dostęp administracyjny

Wyłącznie:

```text
VPN
lub
sieć laboratoryjna
```

---

# 18. Bezpieczeństwo Docker

## Kontenery

Każdy komponent działa w oddzielnym kontenerze:

```text
Frontend
Backend
PostgreSQL
```

---

## Zasady

- uruchamianie jako użytkownik nieuprzywilejowany,
- brak dostępu root,
- minimalne obrazy kontenerów,
- skanowanie podatności.

---

# 19. DevSecOps

## Kontrola jakości kodu

Pipeline CI/CD powinien wykonywać:

```text
Build
Unit Tests
Integration Tests
```

---

## Analiza bezpieczeństwa

```text
SAST
Dependency Scan
Container Scan
```

---

## Przykładowe narzędzia

```text
GitHub Dependabot
CodeQL
Trivy
OWASP Dependency Check
```

---

# 20. Lista wymagań bezpieczeństwa MVP

## Wymagania obowiązkowe

- JWT Authentication,
- RBAC,
- TLS 1.3,
- Audit Log,
- Backup,
- Serilog,
- silna polityka haseł,
- walidacja danych wejściowych,
- ochrona przed SQL Injection,
- ochrona przed XSS,
- szyfrowanie danych w spoczynku.

---

# Wymagania wersji V2

- MFA (Multi-Factor Authentication),
- SSO (Microsoft Entra ID / Active Directory),
- centralne zarządzanie tożsamością,
- dashboard bezpieczeństwa.

---

# Wymagania wersji V3

- SIEM,
- automatyczna analiza incydentów,
- integracja SOC,
- bezpieczeństwo klasy enterprise.

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

# Lista kontrolna bezpieczeństwa przed produkcją

## Aplikacja

- [ ] JWT skonfigurowane
- [ ] Role i uprawnienia skonfigurowane
- [ ] Walidacja danych wdrożona
- [ ] Audit Log aktywny

## Infrastruktura

- [ ] HTTPS aktywny
- [ ] Firewall skonfigurowany
- [ ] Backup działa poprawnie
- [ ] Monitoring aktywny

## Baza danych

- [ ] Kopie zapasowe wykonywane
- [ ] Konta administracyjne zabezpieczone
- [ ] Szyfrowanie aktywne

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Pierwsza wersja dokumentu bezpieczeństwa |
