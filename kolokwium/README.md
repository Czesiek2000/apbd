# Kolokwium
Poniżej zaprezentowany jest diagram bazy danych wykorzystywanej w poniższych zadaniach.

Kolokwium powinno zostać zrealizowane na bazie uczelnianej przy pomocy SqlConnection/SqlCommand lub Entity Framework w wersji Core. Należy zadbać o dodanie przykładowych danych do odpowiednich tabel.

1. Przygotuj końcówkę, która zwróci listę akcji, w których dany strażak brał udział. Końcówka powinna przyjmować ID strażaka jako parametr. Obiekt w liście powinien zawierać id akcji, czas rozpoczęcia i zakończenia akcji. Zwracane dane powinny być posortowane malejąco według czasu zakończenia akcji. Należy pamiętać o odpowiednich statusach błędów.

2. Przygotuj końcówkę, która pozwoli na przypisanie wozu strażackiego do określonej akcji. Do akcji można przypisać tylko wóz strażacki, który aktualnie nie jest wykorzystywany w innej trwającej akcji. Dodatkowo jeżeli akcja wymaga specjalistycznego sprzętu należy wybrać wóz, który taki sprzęt posiada. Jeżeli któreś z podanych wymagań nie zostaną spełnione należy przerwać żądanie. Pamiętaj o odpowiednich statusach błędów.

![diagram](diagram.png)

1. Pamiętaj o:
    1. Utworzeniu Web API zgodnie z podejściem REST.
    2. Poprawnym nazywaniu zmiennych, kontrolerów itp.
    3. Utrzymaniu odpowiedniej struktury kodu.
    4. Wstrzykiwaniu zależności w odpowiednich miejscach.
    5. Obsłudze błędów.
    6.  Korzystaniu z DTO.