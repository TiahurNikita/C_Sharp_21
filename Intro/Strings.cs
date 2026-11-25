using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_21.Intro
{
    /// <summary>
    /// Рядки, робота з рядками
    /// </summary>
    internal class Strings
    {
        public void Run()
        {
            String str = "";
            Random rnd = new();
            const int N = 10;
            //for(int i=0; i<N; i++)
            //{
            //    str += (char)rnd.Next(32,127); // неефективний алгоритм
            //}
            //Console.WriteLine(str);

            StringBuilder sb = new();
            for (int i = 0; i < N; i++)                // StringBuilder - схожий на зв'язаний список
            {                                          // він накопичує елементи і потім поєднує їх
                sb.Append( (char)rnd.Next(32, 127) );  // в рядок за 1 раз (формуючи 1 об'єкт)
            }
            str = sb.ToString();
            Console.WriteLine(str);

            char[] chars = new char[N];
            for(int i = 0; i< N; i++)
            {
                chars[i] = (char)rnd.Next(32, 127);
            }
            str = new String(chars);
            Console.WriteLine(str);
            Console.WriteLine(chars.ToString());

            str = "Hello, world!";
            Console.WriteLine(str[1]);
            Console.WriteLine(str[1..10]); //slice - від індекса 1 включно до 10 не включно
            Console.WriteLine(str[..10]); // скорочена форма - від початку до 10
            Console.WriteLine(str[1..]); // скорочена форма - від 1 до кінця
            Console.WriteLine(str[..^1]); // відлік від кінця ^ - перший від кінця (-1)
            //interpolation - включення до рядка значень змінних
            Console.WriteLine($"Випадкове значення {rnd.Next()}");
            Console.WriteLine($"{str[..10]}{str[11..]}");
            Console.WriteLine($"{str[..10]}**{str[10..]}");
        }
    }
}
/* Рядки у C# належать до незмінюваних типів (Immutable).
 * Це означає, що змінити об'єкт не можна, можна лише збудувати інший об'єкт,
 * беручи інший за джерело даних.
 * -- всі операції з рядками призводять до створення нових рядків (як об'єктів)
 * Зокрема це робить неефективним циклічне додавання символів до рядка
 * str += ""
 * str += "1" - попереднє значення "" стає "сміттям"
 * str += "2" - у смітті вже 2 об'єкти: "" та "1"
 * str += "3" - "", "1", "12"
 * ...
 * str += "10" - "", "1", "12", .... "123456789" - 10 кинутих рядків загальним
 *                            розміром 45 символів (N*(N-1)/2) ~ N^2
 * якщо так формувати 100 символів, то "сміттям" стане ~5000 символів
 */