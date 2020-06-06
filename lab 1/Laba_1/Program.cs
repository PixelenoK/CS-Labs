using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1;
            int[,] matrix2;
            int[,] matrix3 = new int[0, 0];
            string oper = "1";
            ReadFromFile(out matrix1, out matrix2);
            while (oper != "0")
            {
                Console.WriteLine("Press the number whose number contains the operation you want to carry out.");
                Console.WriteLine("Press 0 if you want to end the program.");
                Console.WriteLine("1. Sum\n2. Difference\n3. Determinant of the first matrix\n" +
                    "4. Determinant of the second matrix\n5. Multiplication\n6. Inverse first matrix\n" +
                    "7. Inverse second matrix\n8. Transpose the first matrix\n9. Transpose the second matrix\n" +
                    "10. Matrix values ");
                oper = Console.ReadLine();
                oper = oper.Replace(" ", string.Empty);
                Console.Clear();
                Console.WriteLine("First matrix:");
                Output(matrix1);
                Console.WriteLine("Second matrix:");
                Output(matrix2);
                if (oper == "1")
                {
                    Sum(matrix1, matrix2, matrix3);
                }
                else if (oper == "2")
                {
                    Difference(matrix1, matrix2, matrix3);
                }
                else if (oper == "3")
                {
                    if (CheckSquare(matrix1))
                    {
                        int det = Determinant(matrix1);
                        Console.WriteLine($"Determinant of the 1st matrix is {det}");
                        Console.ReadKey();
                    }
                }
                else if (oper == "4")
                {
                    if (CheckSquare(matrix2))
                    {
                        int det = Determinant(matrix2);
                        Console.WriteLine($"Determinant of the 2st matrix is {det}");
                        Console.ReadKey();
                    }
                }
                else if (oper == "5")
                {
                    Multiplication(matrix1, matrix2, matrix3);
                }
                else if (oper == "6")
                {
                    Inverse(matrix1, matrix3);
                }
                else if (oper == "7")
                {
                    Inverse(matrix2, matrix3);
                }
                else if (oper == "8")
                {
                    Transpose(matrix1, out matrix3);
                    Console.WriteLine("Transposed matrix:");
                    Output(matrix3);
                    Console.ReadKey();
                }
                else if (oper == "9")
                {
                    Transpose(matrix2, out matrix3);
                    Console.WriteLine("Transposed matrix:");
                    Output(matrix3);
                    Console.ReadKey();
                }
                else if (oper == "10")
                {
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        // Обратная матрица
        static void Inverse(int[,] matrix, int[,] trMatrix)
        {
            if (!CheckSquare(matrix))
            {
                return;
            }
            // Транспонированная матрица
            Transpose(matrix, out trMatrix);
            // Матрица миноров данного элемента
            int[,] addMatrix;
            // Искомая обратная матрица
            double[,] invMatrix = new double[trMatrix.GetLength(0), trMatrix.GetLength(1)];
            double det = Determinant(trMatrix);
            if (det == 0)
            {
                Console.WriteLine("Determinant is 0");
                Console.ReadKey();
                return;
            }
            int sign = 1;
            for (int i = 0; i < trMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < trMatrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        sign = -1;
                    }
                    else
                    {
                        sign = 1;
                    }
                    addMatrix = MinorMatrix(trMatrix, j, i);
                    // Элемент присоединенной матрицы
                    int addDet = Determinant(addMatrix);
                    // Элемент искомой матрицы
                    invMatrix[i, j] = (sign * addDet) / det;
                }
            }
            Console.WriteLine("Inversed matrix:");
            for (int i = 0; i < invMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < invMatrix.GetLength(1); j++)
                {
                    Console.Write("{0:0.00} \t", invMatrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        // Транспонирование
        static void Transpose(int[,] matrix, out int[,] trMatrix)
        {
            trMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    trMatrix[i, j] = matrix[j, i];
                }
            }
        }

        // Определитель
        static int Determinant(int[,] matrix)
        {
            int det = 0;
            if (matrix.Length == 4)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else if (matrix.Length == 1)
            {
                det = matrix[0, 0];
            }
            else
            {
                int sign = 1;
                // По минорам 1-го столбца
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int[,] minor = MinorMatrix(matrix, i, 0);
                    // Рекурсивно дойти до минора 2*2
                    det += sign * matrix[0, i] * Determinant(minor);
                    sign *= -1;
                }
            }
            return det;
        }
        // Умножение
        static void Multiplication(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {
            if (CheckConsistent(matrix1, matrix2) == 1)
            {
                matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            else if (CheckConsistent(matrix2, matrix1) == 1)
            {
                matrix3 = new int[matrix2.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        for (int k = 0; k < matrix2.GetLength(1); k++)
                        {
                            matrix3[i, j] += matrix2[i, k] * matrix1[k, j];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Matrices are not consistent.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Third matrix:");
            Output(matrix3);
            Console.ReadKey();
        }
        // Нахождение матрицы минора элемента
        static int[,] MinorMatrix(int[,] matrix, int column, int line)
        {
            int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0, a = 0; a < matrix.GetLength(0) - 1; i++)
            {
                if (i == line)
                {
                    continue;
                }
                for (int j = 0, b = 0; j < matrix.GetLength(0); j++)
                {
                    if (j == column)
                        continue;
                    result[a, b] = matrix[i, j];
                    b++;
                }
                a++;
            }
            return result;
        }
        // Вычитание
        static void Difference(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {
            if (CheckOrder(matrix1, matrix2))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                Console.WriteLine("Third matrix:");
                Output(matrix3);
                Console.ReadKey();
            }
        }
        // Сумма
        static void Sum(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {
            if (CheckOrder(matrix1, matrix2))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                Console.WriteLine("Third matrix:");
                Output(matrix3);
                Console.ReadKey();
            }
        }
        // Чтение из файла
        static void ReadFromFile(out int[,] matrix1, out int[,] matrix2)
        {
            string fileName1 = "/Users/Maks/source/repos/laba_1_#/first.txt";
            string fileName2 = "/Users/Maks/source/repos/laba_1_#/second.txt";
            if (!System.IO.File.Exists(fileName1) || !System.IO.File.Exists(fileName2))
            {
                Console.WriteLine("File doesn't exist.");
                Environment.Exit(0);
            }
            // Чтение всех строк файла в массив строк
            string[] lines1 = File.ReadAllLines(fileName1);
            string[] lines2 = File.ReadAllLines(fileName2);
            if (lines1.Length == 0 || lines2.Length == 0)
            {
                Console.WriteLine("File is empty.");
                Environment.Exit(0);
            }
            // Запись матриц в целочисленный массив
            matrix1 = new int[lines1.Length, lines1[0].Split(' ').Length];
            matrix2 = new int[lines2.Length, lines2[0].Split(' ').Length];
            for (int i = 0; i < lines1.Length; i++)
            {
                string[] temp = lines1[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    try
                    {
                        matrix1[i, j] = Convert.ToInt32(temp[j]);
                    }
                    catch
                    {
                        Console.WriteLine("Only integers should be in the file.");
                        Environment.Exit(0);
                    }
            }
            for (int i = 0; i < lines2.Length; i++)
            {
                string[] temp = lines2[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    try
                    {
                        matrix2[i, j] = Convert.ToInt32(temp[j]);
                    }
                    catch
                    {
                        Console.WriteLine("Only integers should be in the file.");
                        Environment.Exit(0);
                    }
            }
        }
        // Вывод на консоль матриц
        static void Output(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // Проверка на один порядок
        static bool CheckOrder(int[,] matrix1, int[,] matrix2)
        {
            if ((matrix1.GetLength(0) != matrix2.GetLength(0)) || (matrix1.GetLength(1) != matrix2.GetLength(1)))
            {
                Console.WriteLine("Matrices have a different order.");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        // Проверка на квадратность
        static bool CheckSquare(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("The matrix is not square.");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        // Проверка на согласованность
        static int CheckConsistent(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}