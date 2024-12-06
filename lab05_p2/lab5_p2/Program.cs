using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private T[] array;
    private int count;

    public MyList()
    {
        array = new T[4];
        count = 0;
    }

    public MyList(params T[] items)
    {
        array = new T[items.Length];
        items.CopyTo(array, 0);
        count = items.Length;
    }

    public void Add(T item)
    {
        if (count == array.Length)
        {
            T[] newArray = new T[array.Length * 2];
            array.CopyTo(newArray, 0);
            array = newArray;
        }

        array[count] = item;
        count += 1;
    }


    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            return array[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            array[index] = value;
        }
    }

    public int Count
    {
        get { return count; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {

        MyList<int> list1 = new MyList<int>();
        list1.Add(1);
        list1.Add(2);
        list1.Add(3);
        Console.WriteLine($"Count: {list1.Count}");
        Console.WriteLine(list1[1]);


        MyList<string> list2 = new MyList<string> { "one", "two", "three" };
        Console.WriteLine($"Count: {list2.Count}");
        Console.WriteLine(list2[1]);

    }
}