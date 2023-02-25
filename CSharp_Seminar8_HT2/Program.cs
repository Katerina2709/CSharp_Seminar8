// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
// наименьшей суммой элементов: 1 строка

// ввод числовых данных с консоли
int ConsoleInputInt (string message)
{
    Console.Write(message);
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
}
 
// создание нового массива и его заполнение
// произвольными целыми числами в диапазоне от dStart до dEnd 
int [,] FillArrayInt (int str, int stolb, int dStart, int dEnd)
{
    int [,] arrayNumb = new int [str, stolb];
    for (int i = 0; i < arrayNumb.GetLength(0); i++)
    {
        for (int j = 0; j < arrayNumb.GetLength(1); j++)
        {
            arrayNumb[i,j] = new Random().Next(dStart, dEnd + 1); 
            // определение случайным образом целого числа в диапазонне [dStart, dEnd]
        }
    } 
    return arrayNumb;
}

// печать массива построчно с форматированием
void PrintArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],4}  ");
        }
        Console.WriteLine();
    }
}

//  печать номера строки с наименьшей суммой элементов 
void MinSumArrayRows (int [,] array)
{
    int min = 0;
    int rowmin = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0; 
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
        }
        if (i == 0) min = sum;
        else 
        {
            if (sum < min)
            {
               min = sum;
              rowmin = i;
            }
        }   
    }
    Console.WriteLine ($"Номер строки с наименьшей суммой элементов ({min}) -> {rowmin + 1} строка");
    // так как номер  строки не совпадает с ее индексом  (больше на 1), к найденнму индексу прибавляем 1 
}
 
int m = ConsoleInputInt ("Введите количество строк в массиве: ");
int n = ConsoleInputInt ("Введите количество столбцов в массиве: ");
int d1 = ConsoleInputInt ("Введите начало диапазона чисел в массиве: ");
int d2 = ConsoleInputInt ("Введите конец диапазона: ");
if (m <= 0 || n <= 0 || d2 <= d1)
{
   Console.WriteLine("Параметры массива введены неверно"); 
}
else
{
  // задаём массив (m x n) элементов в диапазоне от d1 до d2
  int [,] matrix = FillArrayInt (m, n, d1, d2); 
  PrintArray (matrix);
  Console.WriteLine();
  MinSumArrayRows (matrix);
}
