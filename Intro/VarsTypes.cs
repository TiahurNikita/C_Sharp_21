using System;                      // using - using namespace
using System.Collections.Generic;  // не як include
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_21.Intro         // namespace може вкладатись через "."
{                                  // традиційно - за іменем директорії
    // документуючий коментар "///"
    /// <summary>
    /// Змінні та типи даних
    /// </summary>
    internal class VarsTypes // CapitalCamelCase - рекомендований стиль
    {
        public void Run() // public - повторюється з кожним методом
        {
            Console.WriteLine("Змінні типи даних");
            /* У C#, на відміну від C++, суттєво змінюється поняття типу даних
             * Тип даних - це об'єкт, що містить інформацію про склад типу.
             * Цей об'єкт можна одержувати під час роботи коду, діставати
             * інформацію про його склад. Такі дії називають "рефлексією"
             * 
             * Типи даних поділяються на 2 великі групи
             * - за значенням (Value Types)
             * - за посиланням (Reference Types)
             * Відмінність між ними схожа на статичні та динамічні об'єкти у C++
             */
            int x = 10; // псевдонім типу: int = System.Int32
            System.Int32 y = x; // ValueTypes - семантика копіювання: y - копія x
            // Value Types реалізуються структурами (struct)
            // для цих типів одразу задаються значення (x = 10)
            // змінні цих типів не можуть мати null, без значення набувають
            // спеціального значення "default"
            int w;              // ці два оголошення - суть
            int v = default;    // одне і те саме

            object obj1 = new Object(); // ReferenceTypes - семантика переносу:
            Object obj2 = obj1; // obj2 це друге (з obj1) посилання на єдиний об'єкт
            // зміни, внесені через будь-яку змінну (obj2 чи obj1), матимуть однаковий
            // ефект і відіб'ються на спільному об'єкті
            // Reference Types реалізуються класами (class)
            // для цих типів потрібне створення об'єкту (частіше за все оператором new)
            // Без об'єкта змінні цих типів мають значення null
            
            // Тим не менш, обидві групи типів походять від єдиного нащадка Object,
            // що призводять до того, що вони мають певний перелік спільних методів
            // зокрема, ToString(), який відповідає за рядкове подання об'єкту

            double d = Convert.ToDouble(x);
            string str = "Привіт ";
            byte b = 10;
            short s = 100;
            long lng;
            char c = 'a';

            Console.Write("Ім'я: ");
            String line = Console.ReadLine();
            Console.WriteLine(str + line);

            Console.Write("Вік: ");
            line = Console.ReadLine();
            b = Convert.ToByte(line);
            Console.WriteLine("Ваш вік " + b);
            if (b <= 10) Console.WriteLine("Child");
            else if (b <= 19) Console.WriteLine("Teenager");
            else Console.WriteLine("Adult");
        }
    }
}
