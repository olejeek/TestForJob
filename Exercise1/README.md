Задание № 1
===========
Ответы:  

1. 
Класс [CardUtils](https://github.com/olejeek/TestForJob/blob/master/Exercise1/Exercise1/CardUtils.cs) предоставляет утилиты для работы 
с классом карточки [Card](https://github.com/olejeek/TestForJob/blob/master/Exercise1/Exercise1/Card.cs). Он содержит метод Sort,
который принимает на вход неупорядоченный список карточек и возвращает упорядоченный список согласно требованиям задачи.

2. Данный алгоритм сортировки имеет временную сложность **О(n)** и объемную сложность **O(n)**.

3. [Тесты](https://github.com/olejeek/TestForJob/blob/master/Exercise1/Exercise1Test/CardSortTest.cs) размещены в отдельном проекте. 
Так же были написаны тестовые методы на проверку разрывов, петлей и ветвления списка. Всего создано 14 тестов.

P.S. [Полное решение](https://github.com/olejeek/TestForJob/tree/master/Exercise1) включает в себя: 
[библиотеку классов](https://github.com/olejeek/TestForJob/tree/master/Exercise1/Exercise1), содержащей классы Card и CardUtils,
[консольное приложение](https://github.com/olejeek/TestForJob/tree/master/Exercise1/Exercise1Application) 
для визуализации работы библиотеки и 
[тестовый проект](https://github.com/olejeek/TestForJob/tree/master/Exercise1/Exercise1Test), содержащий unit-тесты к методу сортировки.
