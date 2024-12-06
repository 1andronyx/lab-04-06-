using System;
using System.Collections.Generic;

public class MyMatrix
{
    private Random random;
    private int[,] matrix;
    private int rows;
    private int cols;
    private int minValue;
    private int maxValue;

    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        this.rows = rows;
        this.cols = cols;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.matrix = new int[rows, cols];
        this.random = new Random();
        FillMatrix();
    }

    private void FillMatrix()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    public void Fill()
    {
        FillMatrix();
    }

    public void ChangeSize(int newRows, int newCols)
    {
        int[,] newMatrix = new int[newRows, newCols];


        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(cols, newCols); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }


        for (int i = rows; i < newRows; i++)
        {
            for (int j = cols; j < newCols; j++)
            {
                newMatrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }

        matrix = newMatrix;
        rows = newRows;
        cols = newCols;
    }

    public void ShowPartially(int startRow, int startCol, int endRow, int endCol)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        ShowPartially(0, 0, rows - 1, cols - 1);
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите минимальное значение: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение: ");
        int maxValue = int.Parse(Console.ReadLine());

        Console.Write("Введите число строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите число столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);

        Console.WriteLine("Матрица:");
        matrix.Show();

        Console.WriteLine("\nИзменение размера матрицы:");
        matrix.ChangeSize(4, 6);
        matrix.Show();

        Console.WriteLine("\nЧасть матрицы:");
        matrix.ShowPartially(1, 2, 3, 4);

        Console.WriteLine("\nДоступ к элементам:");
        Console.WriteLine(matrix[0, 0]);
        matrix[0, 0] = 100;
        Console.WriteLine(matrix[0, 0]);

    }
}