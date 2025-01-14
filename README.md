# Aplikacja do zarządzania kontaktami

### Spis treści

1. [Wstęp](#1)
2. [Założenia i zastosowanie aplikacji](#2)
3. [Użyte Technologie](#3)
4. [Sposób instalacji i uruchomienia](#4)
5. [Obsługa aplikacji oraz jej funkcje](#5)
6. [Dlaczego OOP?](#6)
7. [Stoły i relacje](#7)
   
### <a id="1"> 1. Wstęp

Przedmiotem niniejszej dokumentacji technicznej jest aplikacja, zapewnijąca możliwość zarzadzania kontaktami użytkowników, mogą oni dodawać, odczytywać, edytować i usuwanć kontakty indywidualne, jak i biznesowe.
Dostęp do osobistej listy kontaktów zapewnia system rejestracji i logowania.

### <a id="2">2. Założenia i zastosowanie aplikacji

Program w swym założeniu ma pomóc we wprowadzaniu i zapisywaniu nowych kontaktów, a także w ich wygodnym odczycie i modyfikacji. 
Bardzo dobrze sprawdza się w sytuacji, gdy np. przedstawiciel handlowy dużej firmy chce mieć w jednym miejscu wszystkie kontakty ze swoimi klientami i wygodnie nimi zarządzać.

### <a id="3">3. Użyte Technologie  
- **C#**:  
  - ASP.NET Core (MVC Framework)  
  - Entity Framework Core (ORM)  
  - Pomelo.EntityFrameworkCore.MySQL (MySQL Provider)  
  - Bcrypt (Haszowanie haseł)  

- **MySQL**:  
  - Relacyjna baza danych wykorzystywana do przechowywania danych aplikacji  
  
Program oparty jest na architekturze ASP.NET Core, językiem programowania kodu źródłowego aplikacji jest C#. 

### <a id="4">4. Sposób instalacji i uruchomienia

4.1. Należy sklonować repozytorium:
   ```bash
   git clone https://github.com/ArthurAndCode/WebAppCRUD.git
   cd WebAppCRUD
   ```
4.2. Uzupełnić swoje dane logowania do MySQL w (`appsettings.json`)

4.3. Przeprowadzić migrację
   
   ```bash
   dotnet ef migrations add InitialMigration
   ```
   ```bash
   dotnet ef database update
   ```
  
### <a id="5">5. Obsługa aplikacji oraz jej funkcje

##### 5.1. Rejestracja

Po kliknięciu w przycik sign up zostajemy przeniesieni na stronę z formularzem do rejestracji konta używtkownika.

##### 5.2. Logowanie

Przycisk sign in przenosi do strony z formularzed do logowania, jeśli wcześniej utworzyliśmy konto i wprowadzimy prawidłowe dane logowania, zostaniemy przekierowani na strone główną

##### 5.3. Tworzenie kontaktu indywidualnego

Znajduje się na stronie głównej aplikacji i jest dostępne tylko dla zalogowanych użytkowników, przycisk create new contact przekierowuje do formularza tworzenia kontaktu

##### 5.4. Tworzenie kontaktu biznesowego

Dostępne tylko dla zalogowanych użytkowników, do formularza prowadzi przycisk create new business contact, wymaga wprowadzenia dodatkowych informacji takich jak nazwa firmy i zajmowana w niej pozycja

##### 5.5. Wyszukanie kontaktów

Przycisk search służy do wyszukania kontaktów podobnych do danych wpisanych w polu należącym do przycisku

##### 5.6. Edytowanie kontaktu

Każdy kontakt zawiera przycisk przenoszący do formularzu edycji kontaktu

##### 5.7. Usuwanie kontaktu

Każdy kontakt zawiera przycisk służący do usuwania kontaktu, po kliknięciu zostaniemy przekierowani na stronę z informacjami o kontakcie i potwierdzenie operacji usuwania kontaktu

##### 5.8. Wylogowanie

Dostępne poprzez przycisk

### <a id="6"> 6. Dlaczego OOP

Dlaczego zastosowano programowanie obiektowe (OOP)?
Programowanie obiektowe zostało zastosowane w aplikacji ze względu na jego liczne zalety w organizacji i utrzymaniu kodu.

Modularność i przejrzystość kodu
Dzięki OOP, kod został podzielony na klasy reprezentujące konkretne elementy aplikacji, takie jak użytkownicy czy kontakty. Każda klasa odpowiada za określoną funkcjonalność, co zwiększa czytelność i ułatwia rozumienie działania systemu.

Reużywalność kodu
W aplikacji wykorzystano dziedziczenie i polimorfizm. Na przykład kontakty indywidualne i biznesowe mogą dzielić wspólne właściwości i metody dzięki klasie bazowej. Pozwala to na unikanie duplikacji kodu i ułatwia jego rozwój.

Enkapsulacja
Dzięki enkapsulacji logika aplikacji oraz dane są chronione przed nieautoryzowanym dostępem, co zwiększa bezpieczeństwo. Publiczne interfejsy (metody i właściwości) umożliwiają interakcję z obiektami w kontrolowany sposób.

Łatwość testowania i utrzymania
Dzięki rozdzieleniu odpowiedzialności w różnych klasach, każda z nich może być testowana niezależnie. W przypadku zmian lub nowych wymagań można modyfikować istniejące klasy bez wpływu na całą aplikację.

Rezultaty zastosowania OOP
Elastyczność: Rozszerzanie funkcjonalności aplikacji, np. dodanie nowych typów kontaktów, stało się łatwiejsze dzięki dziedziczeniu.
Zarządzalność: Łatwiejsze zarządzanie złożonością aplikacji dzięki modularnej strukturze.
Czytelność: Kod jest bardziej intuicyjny i czytelny zarówno dla autora, jak i dla innych programistów.
Dlaczego nie zastosowano interfejsów?
Decyzja o pominięciu interfejsów wynikała z prostoty wymagań projektu. Interfejsy są użyteczne w bardziej złożonych projektach, w których różne klasy implementują wspólne kontrakty. W tym przypadku:

Brak konieczności wielokrotnej implementacji kontraktów
W aplikacji każda klasa pełni swoją specyficzną rolę i nie ma potrzeby definiowania wspólnych kontraktów, które miałyby być implementowane przez wiele klas.

Mniejsza złożoność projektu
Zastosowanie interfejsów mogłoby wprowadzić dodatkową warstwę abstrakcji, która w tym projekcie nie była konieczna. Upraszcza to strukturę kodu i pozwala skupić się na implementacji kluczowych funkcji.

Nacisk na szybkość implementacji
Ponieważ projekt miał jasno określone cele i ograniczoną skalę, priorytetem było dostarczenie funkcjonalności w jak najkrótszym czasie.

Podsumowując, programowanie obiektowe zapewniło solidne podstawy dla aplikacji, umożliwiając jej łatwą rozbudowę, testowanie i utrzymanie, natomiast decyzja o pominięciu interfejsów była uzasadniona prostotą wymagań projektu.

### 7. <a id="7"> Stoły i relacje

### Users Table
| Column Name     | Data Type   | Constraints                      |
|-----------------|-------------|----------------------------------|
| `Id`            | INT         | Primary Key, Auto Increment     |
| `Email`         | LONGTEXT    | Not Null                       |
| `PasswordHash`  | LONGTEXT    | Not Null                       |

### Contacts Table
| Column Name      | Data Type   | Constraints                     |
|------------------|-------------|---------------------------------|
| `Id`             | INT         | Primary Key, Auto Increment    |
| `ContactType`    | VARCHAR(21) | Not Null                       |
| `Email`          | LONGTEXT    | Not Null                       |
| `Name`           | LONGTEXT    | Not Null                       |
| `PhoneNumber`    | LONGTEXT    | Not Null                       |
| `UserId`         | INT         | Foreign Key, Not Null          |

### BusinessContacts Table (Subtype of Contacts)
| Column Name     | Data Type   | Constraints                     |
|-----------------|-------------|---------------------------------|
| `CompanyName`   | LONGTEXT    | Not Null                       |
| `Position`      | LONGTEXT    | Not Null                       |

Przegląd relacji
Użytkownik może mieć wiele Kontaktów.
Każdy Kontakt należy do jednego Użytkownika.
Kontakty są podzielone na ogólne kontakty i kontakty biznesowe za pomocą strategii Table-Per-Hierarchy (TPH) z wykorzystaniem kolumny ContactType.

---

## Sample MySQL Schema
```sql
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email LONGTEXT NOT NULL,
    PasswordHash LONGTEXT NOT NULL
);

CREATE TABLE Contacts (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ContactType VARCHAR(21) NOT NULL,
    Email LONGTEXT NOT NULL,
    Name LONGTEXT NOT NULL,
    PhoneNumber LONGTEXT NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE BusinessContacts (
    Id INT PRIMARY KEY, -- Inherits from Contacts
    CompanyName LONGTEXT NOT NULL,
    Position LONGTEXT NOT NULL,
    FOREIGN KEY (Id) REFERENCES Contacts(Id) ON DELETE CASCADE
);


