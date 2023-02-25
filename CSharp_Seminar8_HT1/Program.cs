// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

// Сортировка строк двумерного массива по убыванию
int [,] SortArrayRows (int [,] array)
{
   for (int k = 0; k < array.GetLength(0); k++)
   {
      for (int i = 1; i < array.GetLength(1); i++)
      {   
          for (int j = i; j > 0; j--)
          {
              if (array [k,j] > array [k,j-1])
              {
                  int temp = array[k,j-1];
                  array [k,j-1] = array [k,j]; 
                  array [k,j] = temp;
              }
          }
       }
   }   
   return array;
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
  PrintArray (SortArrayRows (matrix));
}
