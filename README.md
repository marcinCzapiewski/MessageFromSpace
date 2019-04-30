# MessageFromSpace

MessageFromSpace is a final project for uiversity "Programming Basics" classes. The task was to decrypt files using given rules.
There are versions for grades from 3.0 to 5.0, where the highest version needs to fulfill previous rules.
Task author is Marcin Wieśniak, Phd and it can be found here: https://inf.ug.edu.pl/~mwiesniak/Students/WLabF.html

## Here's an exact task in polish:

16 listopada 1974 z radioteleskopu w Arecibo (Portoryko) wysłano wiadomość opracowaną przez F. Drake'a w kierunku gromady kulistej M13 (kiepski wybór). Był to ciąg 1679 bitów składający się na obraz o wymiarach 23*73 pikseli. Właśnie przyszła odpowiedź, która ze względów bezpieczeństwa jest zakodowana, i Twoim zadaniem (o ile się go podejmiesz) jest jej rozkodowanie.
 ## 3.0
Wczytaj dane z pliku z nazwą zaczynającą się od 30... (nazwa pliku ma być wczytana z klawiatury). Zera reprezentowane są przez znaki aBcDeF..., a jedynki przez AbCdEf.... Program ma wyświetlić gwiazdki dla jedynek i spacje dla zer. Tak, jak oryginał, wiadomość jest tablicą o wymiarach p*q, gdzie p>q to liczby pierwsze. Program ma je rozpoznać.
 
 ## 3.5
Jak wyżej, oprócz tego jest jeszcze szum-cyfry, które należy zignorować. Obraz ma wymiar iloczynu dwóch liczb pierwszych, z których większa to liczba kolumn. Program ma wyświetlić otrzymaną wiadomość. Nazwa otwieranych plików zaczyna się od 35 (i tak dalej...). Podaj jaki ułamek całych danych stanowi szum.
 
 ## 4.0
Jak wyżej, ale obce cywilizacje nie są aż tak inteligentne i obraz składa się liczby pikseli będącej iloczynem trzech liczb całkowitych. Program ma dawać wybór, co do rozmiaru wyświetlanej treści (bez potwierdzania enterem). Na przykład, jeżeli program wykrył, że wiadomość ma 70=7*2*5 bitów, powinien zapytać
Wybierz wymiar:
1) 2*35
2) 5*14
3) 7*10
4) 10*7
5) 14*5
6) 35*2

## 4.5
Jak wyżej, ale wiadomość rozłożona jest na 5 kolejnych bloków i bit wiadomości jest dany przez x0=x1 XOR x2 XOR x3 XOR x4 XOR x5. Bloki danych są od siebie oddzielone ciągiem pięciu losowych cyfr.

## 5.0
Jak wyżej, ale początek wiadomości następuje po pierwszym ciągu 5 cyfr występującym po sobie, a jej koniec został oznaczony przez szósty taki ciąg. Reszta pliku to śmieci.Każdy z pięciu bloków danych ma być zapisany w pamięci w osobnej tablicy. Program może też zawierać jajko wielkanocne.

