using System;
using System.Diagnostics;

class HelloWorld
{
    static public int InvCount = 0;

    static void Main()
    {
        int N = 0;
        var Timer = Stopwatch.StartNew();
        Console.WriteLine("[Program] Введите количество элементов массива");
        Console.Write(">>> "); N = int.Parse(Console.ReadLine());

        // Создание и заполнение массива
        int[] int_array = new int[N];
        InvCount = 0;
        Random rnd = new Random();
        for (int i = 0; i < N; i++) int_array[i] = rnd.Next(0, 30);

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < N; i++) Console.WriteLine($"[{i}] {int_array[i]}");

        // Сортировки слиянием
        MergeSort(int_array, 0, N - 1);

        // Вывод отсортированного массива
        if (N <= 20)
        {
            Console.WriteLine("\n[Program] Отсортированный массив:");
            for (int i = 0; i < N; i++) Console.WriteLine($"[{i}] {int_array[i]}");
        }

        Console.WriteLine($"\n[Program] Количество инверсий: {InvCount}");
        Console.WriteLine($"[Program] Время выполнения программы: {Timer.Elapsed}");
        Timer.Stop();
        Console.ReadKey();
    }

    static void MergeSort(int[] Arr, int L, int R)
    {
        if (L < R)
        {
            int m = L + (R - L) / 2;

            // Рекурсивно сортируем две половины
            MergeSort(Arr, L, m);
            MergeSort(Arr, m + 1, R);

            // Объединяем отсортированные половины и подсчитываем инверсии
            Merge(Arr, L, m, R);
        }
    }

    static void Merge(int[] Arr, int L, int M, int R)
    {
        int n1 = M - L + 1;
        int n2 = R - M;

        int[] temp1 = new int[n1];
        int[] temp2 = new int[n2];

        for (int a = 0; a < n1; ++a)
            temp1[a] = Arr[L + a];
        for (int b = 0; b < n2; ++b)
            temp2[b] = Arr[M + 1 + b];

        int i = 0, j = 0;

        // Подсчёт инверсий
        int k = L;
        while (i < n1 && j < n2)
        {
            if (temp1[i] <= temp2[j])
            {
                Arr[k] = temp1[i];
                i++;
            }
            else
            {
                Arr[k] = temp2[j];
                InvCount += (n1 - i);
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            Arr[k] = temp1[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            Arr[k] = temp2[j];
            j++;
            k++;
        }
    }
}