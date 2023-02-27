// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

// проверка на корректный ввод данных
bool CheckCorrectInput (int rows, int columns, int dp1, int dp2)
{
    if (rows <= 0 || columns <= 0 || dp2 <= dp1) 
       return false;
    else
       return true;
}

// произведение матриц А и В
void MatrixMult (int [,] arrayA, int [,] arrayB)
{
    int l = arrayA.GetLength(0);
    int n = arrayB.GetLength(1);
    int [,] resultarry = new int [l, n];
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int r = 0; r < arrayA.GetLength(1); r++)
                 resultarry [i, j] += arrayA [i, r] * arrayB[r, j];
            Console.Write($"{resultarry[i, j],4}  ");
        }
        Console.WriteLine();
    }
}

int m1 = ConsoleInputInt ("Введите количество строк в матрице А: ");
int n1 = ConsoleInputInt ("Введите количество столбцов в матрице А: ");
int d11 = ConsoleInputInt ("Введите начало диапазона чисел в матрице А: ");
int d12 = ConsoleInputInt ("Введите конец диапазона в матрице А: ");
int m2 = ConsoleInputInt ("Введите количество строк в матрице В: ");
int n2 = ConsoleInputInt ("Введите количество столбцов в матрице В: ");
int d21 = ConsoleInputInt ("Введите начало диапазона чисел в матрице В: ");
int d22 = ConsoleInputInt ("Введите конец диапазона в матрице В: ");
if (CheckCorrectInput(m1, n1, d11, d12) && CheckCorrectInput(m2, n2, d21, d22))
{
   if (n1 == m2) 
   {
       int [,] matrixA = FillArrayInt (m1, n1, d11, d12); 
       Console.WriteLine("Матрица А: ");
       PrintArray (matrixA);
       Console.WriteLine();
       int [,] matrixB =FillArrayInt (m2, n2, d21, d22); 
       Console.WriteLine("Матрица B: ");
       PrintArray (matrixB);
       Console.WriteLine();
       Console.WriteLine("Призведение матриц A x B равно: ");
       MatrixMult (matrixA, matrixB);
   }
   else
   {
       Console.WriteLine("Произведение матриц А и В неопределено, так как эти матрицы несогласованны."); 
       Console.WriteLine("Количество столбцов матрицы А должно совпадать с количеством строк матрицы В."); 
   }    
}  
else
{
    Console.WriteLine("Параметры матриц введены неверно"); 
}               
