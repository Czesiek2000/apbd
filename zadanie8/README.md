# Zadanie 8
Przygotuj nowy projekt aplikacji API i razem z EF i podejściem CodeFirst wygeneruj kilka migracji, która pozwolą nam stworzyć bazę danych przedstawioną na poniższym rysunku.

![Diagram](diagram.png)

Następnie:
1. Dodaj metodę seed’ującą bazę danych przykładowymi danymi.
2. Końcówkę, która pozwoli nam pobierać dane lekarze, dodawać nowego lekarza, modyfikować dane lekarza i usuwać lekarza (4 końcówki).
3. Dodaj końcówkę, która pozwoli nam pobrać konkretną receptę uwzględniając dane
osobowe pacjenta, doktora i listę leków na recepcie.
4. Pamiętaj o poprawnych nazwach zmiennych/metod/klas
5. Wykorzystaj dodatkowe modele dla danych zwracanych i przyjmowanych przez
końcówki – DTO (ang. Data Transfer Object)
6. Pamiętaj o SOLID, DI