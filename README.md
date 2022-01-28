CarApp - Serwis do zarządzania wypożyczalną samochodów
Projekt zaliczeniowy z przedmiotu "Programowanie w środowisku ASP.NET"
Stworzone przez: Radosław Kot
Numer indeku: 12319

Konfiguracja:
Połączenie z bazą danych
Konfiguracje rozpoczynamy od zmiany ConnectionString w pliku appsetings.json.
Odpowiednie formuły zmieniamy na potrzeby naszego systemu

DATA SOURCE={Nazwa maszyny};Integrated Security=true;DATABASE={Nazwa bazy};Trusted_Connection=True;MultipleActiveResultSets=True

Stworzenie bazy danych
W konsoli menedżera pakietów wpisać odpowiednie komendy:
add-migration {nazwa migracji}
następnie
update-database -verbose
Po tych komendach powinnam nam się utworzyć baza danych, która powinna być widziana na naszym lokalnym serwerze MSSQL (Na przykład w programie Microsoft SQL Server Managment Studio).

!Przed uruchomieniem należy sprawdzić, czy w pakietach NuGet znajdują się odpowiednie biblioteki!
Microsoft.AspNetCore.Identity.EntityFrameworkCore w wersji 5.0.10
Microsoft.EntityFrameworkCore w wersji 5.0.10
Microsoft.EntityFrameworkCore.SqlServer w wersji 5.0.10
Microsoft.EntityFrameworkCore.Tools w wersji 5.0.10
Microsoft.VisualStudio.Web.BrowserLink w wersji 2.2.0
PagedList.Mvc w wersji 4.5.0

Aplikacja posiada dwa konta:
- administaratora (login: admin2 hasło: Admin1!),
- jednego użytkownika (login: user2 hasło: User1!),
