using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите кол-во строк матрицы");
        int stroka = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите кол-во столбцов матрицы");
        int stolbec = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите нижнюю границу диапазона значений");
        int minValue = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите верхнюю границу диапазона значений");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix first_matrix = new MyMatrix(stroka, stolbec, minValue, maxValue);
        MyMatrix second_matrix = new MyMatrix(stroka, stolbec, minValue, maxValue);


        Console.WriteLine("Матрица 1");
        Console.WriteLine(first_matrix);
        Console.WriteLine("Матрица 2");
        Console.WriteLine(second_matrix);

        //перегрузка +
        MyMatrix Sum = first_matrix + second_matrix;
        Console.WriteLine("Сумма матриц (1)+(2)");
        Console.WriteLine(Sum);

        //перегрузка -
        MyMatrix Raznost = first_matrix - second_matrix;
        Console.WriteLine("Разность матриц (1)-(2)");
        Console.WriteLine(Raznost);

        //перегрузка * для матриц
        MyMatrix multiply = first_matrix * second_matrix;
        Console.WriteLine("Произведение матриц (1)*(2)");
        Console.WriteLine(multiply);

        //перегрузка * для числа
        Console.WriteLine("Умножение матриц на числа");
        MyMatrix chislo_multiply_1 = first_matrix * 2;
        Console.WriteLine("Первая матрица умноженная на 2");
        Console.WriteLine(chislo_multiply_1);
        MyMatrix chislo_multiply_2 = second_matrix * 3;
        Console.WriteLine("Вторая матрица умноженная на 3");
        Console.WriteLine(chislo_multiply_2);

        //перегрузка / на число
        Console.WriteLine("Деление матриц на числа (значения округлены)");
        MyMatrix divide_1 = first_matrix / 2;
        Console.WriteLine("Первая матрица поделенная на 2");
        Console.WriteLine(divide_1);
        MyMatrix divide_2 = second_matrix / 2;
        Console.WriteLine("Вторая матрица поделенная на 2");
        Console.WriteLine(divide_2);
    }
}


class MyMatrix
{
    public int[,] mx;
    public int Stolbec, Stroka;
    public Random rnd;

    public MyMatrix(int stolbec, int stroka, int minValue, int maxValue)
    {
        Stolbec = stolbec;
        Stroka = stroka;
        mx = new int[Stolbec, Stroka];
        rnd = new Random();

        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                mx[i, j] = rnd.Next(minValue, maxValue + 1);
            }
        }
    }


    //индекс
    public int this[int i, int j]
    {
        get { return mx[i, j]; }
        set { mx[i, j] = value; }
    }

    //перегрузка +
    public static MyMatrix operator +(MyMatrix one, MyMatrix two)
    {
        if ((one.Stroka != two.Stroka) || (one.Stolbec != two.Stolbec))
        {
            throw new ArgumentException("Размеры матриц должны быть одинаковыми");
        }

        MyMatrix rez = new MyMatrix(one.Stroka, one.Stolbec, 0, 0);
        for (int i = 0; i < one.Stroka; i++)
        {
            for (int j = 0; j < two.Stolbec; j++)
            {
                rez[i, j] = one[i, j] + two[i, j];
            }
        }
        return rez;
    }
    //перегрузка -
    public static MyMatrix operator -(MyMatrix one, MyMatrix two)
    {
        if ((one.Stroka != two.Stroka) || (one.Stolbec != two.Stolbec))
        {
            throw new ArgumentException("Размеры матриц должны быть одинаковыми");
        }

        MyMatrix rez = new MyMatrix(one.Stroka, one.Stolbec, 0, 0);
        for (int i = 0; i < one.Stroka; i++)
        {
            for (int j = 0; j < two.Stolbec; j++)
            {
                rez[i, j] = one[i, j] - two[i, j];
            }
        }
        return rez;
    }
    //перегрузка * для матриц
    public static MyMatrix operator *(MyMatrix one, MyMatrix two)
    {
        if (one.Stolbec != two.Stroka)
        {
            throw new ArgumentException("Кол-во столбцов первой матрицы должно быть равно кол-ву строк второй матрицы");
        }

        MyMatrix rez = new MyMatrix(one.Stroka, two.Stolbec, 0, 0);
        for (int i = 0; i < one.Stroka; i++)
        {
            for (int j = 0; j < two.Stolbec; j++)
            {
                for (int k = 0; k < one.Stolbec; k++)
                {
                    rez[i, j] += one[i, k] * two[k, j];
                }
            }
        }
        return rez;
    }

    //перегрузка * для числа
    public static MyMatrix operator *(MyMatrix one, int multiply)
    {
        MyMatrix rez = new MyMatrix(one.Stroka, one.Stolbec, 0, 0);

        for (int i = 0; i < one.Stroka; i++)
        {
            for (int j = 0; j < one.Stolbec; j++)
            {
                rez[i, j] = one[i, j] * multiply;
            }
        }
        return rez;
    }

    //перегрузка деления /
    public static MyMatrix operator /(MyMatrix one, int multiply)
    {
        if (multiply == 0)
        {
            throw new DivideByZeroException("Деление на ноль");
        }

        MyMatrix rez = new MyMatrix(one.Stroka, one.Stolbec, 0, 0);
        for (int i = 0; i < one.Stroka; i++)
        {
            for (int j = 0; j < one.Stolbec; j++)
            {
                rez[i, j] = one[i, j] / multiply;
            }
        }
        return rez;
    }

    //перегрузка ToString() для вывода матрицы в консоль
    public override string ToString()
    {
        string rez = "";
        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                rez += mx[i, j] + " ";
            }
            rez += "\n";
        }
        return rez;
    }
}

