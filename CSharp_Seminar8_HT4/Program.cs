// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// ввод числовых данных с консоли
int ConsoleInputInt (string message)
{
    Console.Write(message);
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
}
 
// создание нового массива и его заполнение
// произвольными двузначными (от 10 до 99) неповторяющимися целыми числами 
int [,,] FillArrayInt (int a1, int a2, int a3)
{
    int [] TwoDigitNumber = new int [100]; // массив для определения уникальности элементов создаваемого массива
    int [,,] arrayNumb = new int [a1, a2, a3];
    for (int i = 0; i < arrayNumb.GetLength(0); i++)
    {
        for (int j = 0; j < arrayNumb.GetLength(1); j++)
        {
            for (int k = 0; k < arrayNumb.GetLength(2); k++)
            {    
                 // определение случайным образом двузначного (от 10 до 99) целого числа 
                 arrayNumb[i,j,k] = new Random().Next(10, 100); 
                 // проверка на уникальность
                 if (TwoDigitNumber [arrayNumb[i,j,k]] == 1)
                 {
                 // если элемент проверочного массива с индексом равным выбранному числу равен 1, 
                 // то такое число в создаваемом массиве уже есть                {
                     for (int m = 10; m < 100; m++) 
                     {
                        if (TwoDigitNumber [m] == 0)
                        {
                            arrayNumb[i,j,k] = m; 
                            // присваиваем элементу создаваемого массива значения индекса первого нулевого элемента проверочного массива
                            TwoDigitNumber [m] = 1;
                            break;
                        }  

                     }    
                 }
                 else
                 {
                    TwoDigitNumber [arrayNumb[i,j,k]] = 1;
                 }
            }
               
        }
    } 
    return arrayNumb;
}

// печать массива построчно с форматированием
void PrintArray (int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($" {array[i,j,k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        } 
        Console.WriteLine();
    }
}

// проверка на корректный ввод данных
bool CheckCorrectInput (int a1, int a2, int a3)
{
    if (a1 <= 0 || a2 <= 0 || a3 <= 0 || a1 * a2 * a3 > 90) 
       return false;
    else
       return true;
}

int m = ConsoleInputInt ("Введите размерность массива: 1 индекс = ");
int n = ConsoleInputInt ("2 индекс = ");
int l = ConsoleInputInt ("3 индекс = ");


if (CheckCorrectInput(m, n, l))
{
    PrintArray (FillArrayInt(m, n, l));
}
else
{
    Console.WriteLine("Параметры массива введены неверно"); 
}               