# Aplikacja do zarządzania kontaktami

### Spis treści

1. [Wstęp](#1)
2. [Założenia i zastosowanie aplikacji](#2)
3. [Użyte Technologie](#3)
4. [Sposób instalacji i uruchomienia](#4)
5. [Obsługa aplikacji oraz jej funkcje](#5)

### <a id="1"> 1. Wstęp

Przedmiotem niniejszej dokumentacji technicznej jest aplikacja, zapewnijąca możliwość zarzadzania kontaktami użytkowników, mogą oni dodawać, odczytywać, edytować i usuwanć kontakty indywidualne, jak i biznesowe.
Dostęp do osobistej listy kontaktów zapewnia system rejestracji i logowania.

### <a id="2">2. Założenia i zastosowanie aplikacji

Program w swym założeniu ma pomóc we wprowadzaniu i zapisywaniu nowych kontaktów, a także w ich wygodnym odczycie i modyfikacji. 
Bardzo dobrze sprawdza się w sytuacji, gdy np. przedstawiciel handlowy dużej firmy chce mieć w jednym miejscu wszystkie kontakty ze swoimi klientami i wygodnie nimi zarządzać.

### <a id="3">3. Użyte Technologie
  C# MVC, ASP.NET CORE, B.Crypt, EntityFrameworkCore, Pomelo.EntityFrameworkCore.MySQL
  MySQL

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

Dostępne poprzez wyłączenie karty w przeglądarce

