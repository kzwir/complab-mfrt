# 09 - Wdrożenie Systemu

# CompLab MFR/T

## Architektura Wdrożeniowa MVP

**Wersja dokumentu:** 2.0 MVP  
**Status:** MVP Definition

Powiązane dokumenty:

```text
01-Architecture-Overview.md
03-Technology-Decision.md
06-Security.md
07-DevOps.md
```

---

# 1. Cel dokumentu

Celem dokumentu jest opisanie architektury wdrożeniowej dla wersji MVP systemu CompLab MFR/T.

Dokument definiuje:

- środowiska systemowe,
- architekturę wdrożenia,
- wymagania sprzętowe,
- konfigurację Docker Compose,
- proces publikacji,
- backup bazy danych,
- podstawowe wymagania produkcyjne.

---

# 2. Założenia wdrożeniowe

System przeznaczony jest dla laboratorium liczącego:

```text
około 20 użytkowników
```

Wersja MVP zakłada:

```text
Pojedynczy serwer
```

oraz wdrożenie:

```text
On-Premise
```

lub

```text
Prywatna chmura
```

---

# 3. Architektura rozwiązania

## Diagram logiczny

```text
Przeglądarka

      |

Angular

      |

ASP.NET Core API

      |

PostgreSQL
```

---

# 4. Architektura fizyczna

W MVP wszystkie komponenty mogą działać na jednym serwerze.

```text
Frontend

Backend

PostgreSQL
```

---

# 5. Środowiska

W MVP wykorzystujemy dwa środowiska.

---

## DEV

Przeznaczenie:

```text
Programowanie

Testy lokalne
```

---

## PROD

Przeznaczenie:

```text
Produkcja
```

---

# 6. Wymagania dla stacji roboczych

## Minimalne

```text
CPU: 2 rdzenie

RAM: 8 GB

Przeglądarka:
Chrome
Edge
```

---

## Rekomendowane

```text
CPU: 4 rdzenie

RAM: 16 GB

SSD

Full HD
```

---

# 7. Wymagania dla serwera

## System operacyjny

Rekomendacja:

```text
Ubuntu Server LTS
```

---

## Minimalna konfiguracja

```text
4 vCPU

8 GB RAM

100 GB SSD
```

---

## Rekomendowana konfiguracja

```text
8 vCPU

16 GB RAM

250 GB SSD
```

---

# 8. Baza danych

## Silnik

```text
PostgreSQL
```

---

## Zakres danych MVP

Przechowywane są:

```text
Użytkownicy

Mieszaniny

Próbki

Badania
```

---

# 9. Architektura kontenerowa

System uruchamiany jest przy użyciu Docker Compose.

---

## Komponenty

### Frontend

```text
complab-web
```

---

### Backend

```text
complab-api
```

---

### PostgreSQL

```text
complab-postgres
```

---

# 10. Docker Compose

## Struktura

```yaml
services:

  web:
    image: complab-web

  api:
    image: complab-api

  postgres:
    image: postgres
```

---

## Uruchomienie

```bash
docker compose up -d
```

---

## Zatrzymanie

```bash
docker compose down
```

---

# 11. Sieć

## Dostęp użytkowników

Produkcja:

```text
HTTPS
```

---

## Dostęp administracyjny

Wyłącznie dla administratorów systemu.

---

# 12. Certyfikaty

## MVP

Dopuszczalne:

```text
Certyfikat wewnętrzny
```

lub

```text
Let's Encrypt
```

---

## Produkcja

Rekomendowane:

```text
HTTPS
TLS
```

---

# 13. Konfiguracja aplikacji

## Backend

Pliki:

```text
appsettings.Development.json

appsettings.Production.json
```

---

## Frontend

Pliki:

```text
environment.ts

environment.prod.ts
```

---

## Sekrety

Nie przechowujemy:

```text
Hasła

Connection Strings

JWT Keys
```

w repozytorium Git.

---

# 14. Migracje bazy danych

## Technologia

```text
Entity Framework Core Migrations
```

---

## Tworzenie migracji

```bash
dotnet ef migrations add InitialCreate
```

---

## Aktualizacja bazy

```bash
dotnet ef database update
```

---

# 15. Publikacja aplikacji

## Proces

```text
Build
↓
Test
↓
Docker Build
↓
Deploy
```

---

## Wdrożenie

Realizowane ręcznie przez administratora lub z wykorzystaniem GitHub Actions.

---

# 16. Kopie zapasowe

## PostgreSQL

Minimalna strategia MVP:

```text
1 backup dziennie
```

---

## Retencja

```text
30 dni
```

---

## Cel

Możliwość odtworzenia danych po awarii.

---

# 17. Logowanie aplikacji

## Minimalny zakres

Rejestrowane są:

```text
Błędy aplikacji

Błędy API

Błędy logowania
```

---

## Mechanizm

```text
ILogger
```

---

# 18. Wymagania produkcyjne

## Dostępność

Dla MVP:

```text
95%
```

---

## Wydajność API

Docelowo:

```text
większość odpowiedzi poniżej 1 sekundy
```

---

## Jednoczesna liczba użytkowników

```text
20 użytkowników
```

---

# 19. Rozwój po MVP

## Wersja 2

Planowane rozszerzenia:

```text
Monitoring

Serilog

GitHub Actions CI/CD

Raporty PDF
```

---

## Wersja 3

Planowane rozszerzenia:

```text
Kubernetes

High Availability

Load Balancer

Oddzielny serwer bazy danych
```

---

# Powiązane dokumenty

```text
01-Architecture-Overview.md
03-Technology-Decision.md
06-Security.md
07-DevOps.md
08-Testing-Strategy.md
```

---

# Lista kontrolna wdrożenia MVP

## Infrastruktura

- [ ] Serwer Linux przygotowany
- [ ] Docker zainstalowany
- [ ] PostgreSQL uruchomiony
- [ ] Backup skonfigurowany

---

## Aplikacja

- [ ] Frontend wdrożony
- [ ] Backend wdrożony
- [ ] Migracje wykonane

---

## Bezpieczeństwo

- [ ] HTTPS aktywny
- [ ] JWT skonfigurowane
- [ ] Role skonfigurowane

---

## Operacje

- [ ] Backup działa
- [ ] Logowanie błędów działa
- [ ] Dokumentacja aktualna

---

# Historia zmian

| Wersja | Data | Opis |
|---------|---------|---------|
| 1.0 | 2026-09-24 | Architektura docelowa |
| 2.0 MVP | 2026-09-25 | Uproszczenie architektury wdrożeniowej dla MVP |
