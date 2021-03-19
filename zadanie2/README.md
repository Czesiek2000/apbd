# Zadanie 2 
W niniejszym zadaniu Waszym celem będzie dalsze zapoznanie się z językiem C# i przygotowanie aplikacji konsolowej, która służy do obróbki danych. 

Poniżej znajdziecie wymagania na aplikację.

Okazało się, że na Uniwersytecie XYZ powstała potrzeba eksportu danych i ich odpowiedniego przygotowania do przesłania do Ministerstwa Edukacji i Szkolnictwa Wyższego. Ministerstwo przygotowały system, który pozwala na zaimportowanie pliku JSON w odpowiednim formacie określonym przez Ministerstwo.

System informatyczny stosowany na Uniwersytecie XYZ pozwala na eksport danych wyłącznie w pliku CSV.

Niestety wyeksportowane dane zawierają pewne błędy lub brakujące dane. Ponadto ich format nie odpowiada formatowi, którego oczekuje ministerstwo. Musimy stworzyć aplikację konsolową, która pozwoli na poprawne przetworzenie otrzymanego pliku CSV i otrzymanie pliku wynikowego zgodnego z
formatem oczekiwanym przez Ministerstwo.

## Parametry programu
Program powinien przyjmować trzy parametry:
* Adres pliku CSV
* Adres ścieżki docelowej
* Format danych

Poniżej mamy przykład wywołania:
```sh
.\export_xyz „C:\Users\Jan\Desktop\csvData.csv” json
```
Jeśli plik już istnieje w danej lokalizacji – powinien zostać nadpisany. Na razie jedyną dostępną wartością dla trzeciego parametru jest „json”. W przyszłości przewiduje się potrzebę implementacji innych wyjściowych formatów danych.

## Obsługa błędów
Aplikacja powinna być odporna na błędy. Wszystkie wystąpienia błędów powinny być logowane do pliku txt o nazwie `log.txt`. Pamiętajmy również o zrozumiałych dla użytkownika komunikatach o błędzie. 

### W przypadku:
* Niepoprawnej ścieżki - zgłoś błąd ArgumentException("Podana ścieżka jest niepoprawna")
* Plik nie istnieje - zgłaszamy błąd FileNotFoundException("Plik nazwa nie istnieje")

## Wejściowy format danych
Poniżej zaprezentowany jest przykładowy plik z danymi. Każdy wiersz reprezentuje pojedynczego
studenta. 

Każda kolumna jest oddzielona znakiem ",". 

Każdy student powinien być opisywany przez 9 kolumn.

Poniżej zaprezentowany jest pojedynczy wpis w pliku CSV.
```
Paweł,Nowak1,Informatyka dzienne,Dzienne,459,2000-02-12 00:00:00.000,nowak@pjwstk.edu.pl,Alina,Adam
```
Uwaga:
* Niektóre wiersze mogą zawierać błędy. Tych studentów, którzy nie są opisywani przez 9 kolumn z
danymi pomijamy. Informacje o pominiętym studencie traktujemy jako błąd i logujemy do pliku `log.txt`.

* Jeśli jeden ze studentów posiada w kolumnie pustą wartość - traktujemy taką wartość jako
brakującą. W takim wypadku studenta nie dodajemy do zbioru wynikowego i dodajemy go do pliku `log.txt`. 

W powyższych przypadkach można zdefiniować własne klasy reprezentujące błąd.

Ponadto okazało się, że dane zawierają czasem duplikaty informacji o studentach. 

Musimy zadbać o to, aby nie dodawać do wyniku dwa razy studenta o tym samym *imieniu, nazwisku i numerze indeksu*. 

**Zawsze pobieramy pierwszego studenta z danym imieniem, nazwiskiem i numerem indeksu. Każde powtórzenie danych o studencie w danych źródłowych traktujemy jako
niepoprawny duplikat.**

### Format docelowy
W celu ograniczenia przesyłania danych postanowiono wykorzystać format danych **JSON** w miejsce wykorzystywanego wcześniej formatu bazującego na **XML**.

## Przykład
```json
{
    uczelnia: {
        createdAt: "08.03.2020",
        author: "Jan Kowalski",
        studenci: [
            {
                indexNumber: "s1234",
                fname: "Jan",
                lname: "Kowalski",
                birthdate: "02.05.1980",
                email: "kowalski@wp.pl",
                mothersName: "Alina",
                fathersName: "Jan",
                studies: {
                    name: "Computer Science",
                    mode: "Dzienne"
                }
            },
            {
                indexNumber: "s2432",
                fname: "Anna",
                lname: "Malewska",
                birthdate: "07.10.1985",
                email: "malewska@wp.pl",
                mothersName: "Marta",
                fathersName: "Marcin",
                studies: {
                    name: "New Media Art",
                    mode: "Zaoczne"
                }
            }   
        ],
        
        activeStudies: [
            {
                name: "Computer Science",
                numberOfStudents: "1"
            },
            {
                name: "New Media Art",
                numberOfStudents: "2"
            }
        ]
    }
}
```