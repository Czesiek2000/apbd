# Zadanie 12
W dzisiejszych ćwiczeniach w folderze MovieApp znajdzie projekt częściowo ukończonej aplikacji Blazor – WebAssembly.

Solucja zawiera 3 projekty:
- Client – aplikacja kliencka wykorzystująca WebAssembly
- Server – aplikacja serwerowa typu REST API
- Shared – kod współdzielony

Projekt serwerowy zawiera migracje. Za pomocą odpowiedniej komendy uruchom migracje – w pliku appsettings możesz podmienić connectrion string na swoją bazę danych. Możesz również pozostawić connection string i nie zmieniać go – wtedy migracja zostania uruchomiona na bazie lokalnej w pliku.

Aplikacja zawiera kilka tabel związanych z danymi na temat filmów. Ponadto zawiera zaimplementowany mechanizm logowania i rejestracji.

Odnajdz komponent Movies i dodaj brakujące funkcjonalności:
- Dodaj możliwość dodawania nowego filmu
- Dodaj możliwość wyświetlenia szczegółów filmu/edycji
- Dodaj możliwość usuwania filmu
- Możesz modyfikować istniejący kod – szczególnie, jeśli widzisz, że gdzieś nie jest zachowana dobra praktyka pod kątem organizacji kodu (jest kilka takich miejsc).
- Dodając film możesz skupić się tylko na danych filmu – z pominięciem kategorii i aktorów. Chętne osoby mogą spróbować stworzyć komponent, który podczas tworzenia filmu pozwoli nam wygodnie przypisać kategorie i aktorów.