using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Зчитування три чисел з файлу input.txt
            string[] lines = File.ReadAllLines("D:/Дз/Програмування/input.txt");
            if (lines.Length < 3)
            {
                Console.WriteLine("Недостатньо даних у файлі input.txt.");
                return;
            }

            int[] sides = new int[3];
            for (int i = 0; i < 3; i++)
            {
                sides[i] = int.Parse(lines[i]);
            }

            // Перевірка, чи можна з цих чисел побудувати трикутник
            bool isTriangle = IsTriangle(sides[0], sides[1], sides[2]);

            // Запис результату перевірки в кінець файлу output.txt
            using (StreamWriter writer = new StreamWriter("D:/Дз/Програмування/output.txt", true))
            {
                writer.WriteLine($"Можна побудувати трикутник зі сторін {sides[0]}, {sides[1]} та {sides[2]}: {isTriangle}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл input.txt не знайдено.");
        }
        catch (IOException)
        {
            Console.WriteLine("Помилка читання або запису до файлу.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Файл містить некоректні дані.");
        }

        Console.ReadLine(); // Чекаємо на натискання клавіші перед завершенням програми
    }

    static bool IsTriangle(int a, int b, int c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}