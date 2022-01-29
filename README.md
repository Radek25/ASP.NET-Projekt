# CarApp - system do zarządzania wypożyczalnią samochodów

CarApp to aplikacja, która powstała aby ułatwić zarządzanie wypożyczalnią samochodów.<br> Obecnie aplikacja posiada dwa konta: Admin i User.<br>
Konto Administratora pozwala na dodanie pojadu do floty, edycję pojazdu oraz wyświetlenie aktualnej floty.
Konto User umożliwia sprawdzenie płatności oraz danych osobowych. 
Przyszłościowo aplikacja zostanie rozbudowana o nowe finkcjonalnoścvi zarówno dla użytkownika jak i administratora.

###Konfiguracja

Konfiguracja: Połączenie z bazą danych Konfiguracje rozpoczynamy od zmiany ConnectionString w pliku appsetings.json. Odpowiednie formuły zmieniamy na potrzeby naszego systemu<br>

DATA SOURCE={Nazwa maszyny};Integrated Security=true;DATABASE={Nazwa bazy};Trusted_Connection=True;MultipleActiveResultSets=True<br>

Stworzenie bazy danych W konsoli menedżera pakietów wpisać odpowiednie komendy: add-migration {nazwa migracji} następnie update-database -verbose Po tych komendach powinnam nam się utworzyć baza danych, która powinna być widziana na naszym lokalnym serwerze MSSQL (Na przykład w programie Microsoft SQL Server Managment Studio).<br>

!Przed uruchomieniem należy sprawdzić, czy w pakietach NuGet znajdują się odpowiednie biblioteki! Microsoft.AspNetCore.Identity.EntityFrameworkCore w wersji 5.0.10 Microsoft.EntityFrameworkCore w wersji 5.0.10 Microsoft.EntityFrameworkCore.SqlServer w wersji 5.0.10 Microsoft.EntityFrameworkCore.Tools w wersji 5.0.10 Microsoft.VisualStudio.Web.BrowserLink w wersji 2.2.0 PagedList.Mvc w wersji 4.5.0<br>

| Login  | Hasło  |
| :------------: | :------------: |
| admin2  | Admin1!  |
|  user2 | User1!  |

###Autor
Wykonał: Radosław Kot <br>
Numer albumu: 12319 <br>
