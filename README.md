# Task Manager - Konsolowa Lista Zadań w C#

## Krótki opis aplikacji
Aplikacja to prosty, konsolowy menedżer zadań (To-Do List) napisany w języku C#. Służy do organizacji codziennych obowiązków. Program został stworzony w oparciu o podstawowe zasady programowania obiektowego i działa w interaktywnej pętli, reagując na komendy użytkownika.

## Lista funkcji
* **Dodawanie zadań:** Możliwość wpisania nowej pozycji na listę.
* **Przeglądanie zadań:** Wyświetlanie wszystkich zadań wraz z ich unikalnym numerem ID oraz statusem ukończenia (`[ ]` - do zrobienia, `[X]` - wykonane).
* **Oznaczanie jako wykonane:** Możliwość zmiany statusu zadania po podaniu jego numeru ID.
* **Usuwanie zadań:** Trwałe kasowanie zadania z listy na podstawie ID.
* **Autozapis:** Program po każdej operacji natychmiastowo zapisuje obecny stan do pliku tekstowego, dzięki czemu nie tracimy danych po wyłączeniu konsoli.

## Instrukcja uruchomienia
1. Pobierz repozytorium z kodem na swój komputer.
2. Otwórz plik rozwiązania (z rozszerzeniem `.sln`) za pomocą środowiska Visual Studio.
3. Uruchom aplikację klikając przycisk "Start" na górnym pasku lub wciskając klawisz `F5`.
4. Sterowanie programem odbywa się poprzez wpisywanie na klawiaturze odpowiednich cyfr (od 1 do 5) widocznych w menu głównym i zatwierdzanie ich klawiszem `Enter`.

## Informacja o elementach dodatkowych
W ramach projektu zrealizowano następujące wymagania dodatkowe:
* **OOP (Programowanie Obiektowe):** Projekt wykorzystuje niestandardową klasę `TaskItem`, która posiada własne właściwości (`Id`, `Name`, `IsCompleted`) oraz konstruktor. Dane przechowywane są w generycznej liście obiektowej `List<TaskItem>`.
* **IO (Zapis/Odczyt z pliku):** Program realizuje trwały zapis danych. Do zapisu i odczytu wykorzystano przestrzeń nazw `System.IO` oraz plik tekstowy `tasks.txt`, w którym poszczególne parametry obiektów separowane są średnikiem.
