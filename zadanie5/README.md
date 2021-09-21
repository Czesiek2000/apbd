# Zadanie 5
W trakcie niniejszych ćwiczeń ponownie skorzystamy z klas `SqlConnection` i `SqlCommand`. Tym razem logika związana z interakcją z naszą bazą danych będzie jednak nieco bardziej złożona.

Tworzymy aplikację dla firmy zajmującej się zarządzaniem stanem magazynu i produktami, które się w nim znajdują. Baza, którą wykorzystujemy zaprezentowana jest poniżej. 

Ponadto w pliku `sql/create.sql` znajduje sie skrypt, który tworzy tabele i wypełnia je danymi.


1. Stwórz nową aplikacje typu REST API
2. Dodaj kontroler o nazwie WarehousesController
3. Wewnątrz kontrolera dodaj końcówkę, które będzie odpowiadać na następujące żądanie:

    1. Końcówka odpowiada na żądanie HTTP POST na adres /api/warehouses
    2. Końcówka otrzymuje dane następującej postaci:
    ```json
    "IdProduct": 1,
    "IdWarehouse": 2,
    "Amount": 20,
    "CreatedAt": "2012-04-23T18:25:43.511Z"
    ```

    3. Wszystkie pola są wymagane. Amount musi być większe niż 0.
    4. Końcówka powinna zrealizować następujący scenariusz działania.

<table>
<thead>
<tr>
<td>Nazwa</td>
<td>Rejestracja produktu w hurtowni</td>
</tr>
<tr>
<td colspan="2" align="center">SCENARIUSZ GLÓWNY</td>
</tr>
</thead>
<tbody>
<tr>
<td>
1.
</td>
<td>
Sprawdzamy czy produkt o podanym id istnieje. Następnie sprawdzamy czy
hurtownia o podanym id istnieje. Ponadto upewniamy się, że wartość Amount jest
większa od 0.
</td>
</tr>
<tr>
<td>
2.
</td>
<td>
Produkt możemy dodać do hurtowni tylko jeśli w tabeli Order istnieje zlecenie
zakupu produktu. Sprawdzamy zatem czy w tabeli Order istnieje rekord z:
IdProduct i Amount zgodnym z naszym żądaniem. CreatedAt zamówienia powinno
być mniejsze niż CreatedAt pochodzące z naszego żądania (zamówienie/order
powinno pojawić się w bazie danych wcześniej niż nasze żądanie).
</td>
</tr>
<tr>
<td>
3.
</td>
<td>
Sprawdzamy czy przypadkiem to zlecenie nie zostało już zrealizowane.
Sprawdzamy czy w tabeli Product_Warehouse nie ma już wiersza z danym IdOrder.
</td>
</tr>
<tr>
<td>
4.
</td>
<td>
Aktualizujemy kolumnę FullfilledAt zlecenia w wierszu oznaczającym zlecenie
zgodnie z aktualną datą i czasem. (UPDATE)
</td>
</tr>
<tr>
<td>
5.
</td>
<td>
Wstawiamy rekord do tabeli Product_Warehouse. Kolumna Price powinna
zawierać pomnożoną cenę pojedynczego produktu z wartością Amount z naszego
żądania. Ponadto wstawiamy wartość CreatedAt zgodną z aktualnym czasem.
(INSERT)
</td>
</tr>
<tr>
<td>
6.
</td>
<td>
Jako wynik operacji zwracamy wartość klucza głównego wygenerowanego dla
rekordu wstawionego do tabeli Product_Warehouse.
</td>
</tr>
<tr>
<td>

</td>
<td align="center">
SCENARIUSZ ALTERNATYWNY
</td>
</tr>
<tr>
<td>
1a.
</td>
<td>
Produkt/Hurtownia o danym id nie istnieje. Zwracamy błąd 404 z odpowiednią
wiadomością.
</td>
</tr>
<tr>
<td>
2a.
</td>
<td>
Nie ma odpowiedniego zlecenia. Zwracamy błąd 404 z odpowiednią wiadomością.
</td>
</tr>
</tr>
<tr>
<td>
3a.
</td>
<td>
Zlecenie zostało już zrealizowane. Zwracamy odpowiedni kod błędu z
wiadomością.
</td>
</tr>
</tbody>
</table>

<br />
<br />

4. Następnie dodaj drugi kontroler **Warehouses2Controller** z końcówką odpowiadająca na żądania wysłane na adres HTTP POST `/api/warehouses2`
    
    1. Końcówka realizuje tą samą logikę, ale w tym wypadku uruchamiana jest
procedura składowana (załączona w pliku `sql/proc.sql`).
5. Pamiętaj o wstrzykiwanie zależności, odpowiednich nazwach, kodach zwrotnych http
6. Spróbuj wykorzystać metody wykorzystujące programowanie asynchroniczne i
async/await.