# Zadanie 9
**Wszystkie zadania realizujemy z pomocą projektu z poprzednich ćwiczeń (ćwiczenia 8).**

Do przygotowanego wcześniej projektu dodajemy uwierzytelnienie z pomocą tokena JWT.

1. Zabezpiecz wszystkie końcówki tak, aby były dostępne tylko dla zalogowanych
użytkowników (czyli użytkowników przesyłających poprawny token).
2. Dodaj kontroler o nazwie AccountsController z metodą umożliwiającą logowanie
(przesłanie loginu i hasła). Jako odpowiedź metoda powinna zwrócić nowy token wraz z refresh token’em. Dodatkowo dodaj nową migrację, która pozwoli na zapisanie użytkownika w bazie danych. Postaraj się przechowywać wrażliwe dane w bazie danych w odpowiedni sposób (SALT, PBKDF2).
3. Przygotuj końcówkę, która pozwoli na uzyskanie nowego access token’a na podstawie refresh token’a.
4. Dodaj własny middleware służący do logowania wszystkich błędów do pliku tekstowego onazwie logs.txt.