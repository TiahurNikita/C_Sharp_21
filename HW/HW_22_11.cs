using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_21.HW
{
    internal class HW_22_11
    {
        public void Task1()
        {
            /*
             Оголосити одновимірний (5 елементів) масив з іменем A і двовимірний масив (3 рядки, 4 стовпці) 
            дробових чисел з іменем B. Заповнити одновимірний масив А числами, введеними з клавіатури користувачем, 
            а двовимірний масив В випадковими числами за допомогою циклів. Вивести на екран значення масивів: 
            масиву А в один рядок, масиву В — у вигляді матриці. Знайти в даних масивах загальний максимальний елемент, 
            мінімальний елемент, загальну суму всіх елементів, загальний добуток усіх елементів, суму парних 
            елементів масиву А, суму непарних стовпців масиву В.*/
            double[] a = new double[5];
            double[,] b = new double[3, 4];
            Random rnd = new();

            Console.WriteLine("Enter elements of a[]");
            for (int i = 0; i < a.Length; i++) {
                Console.Write($"{i} = ");
                a[i] = Convert.ToDouble(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b[i, j] = Math.Round(rnd.NextDouble() + rnd.Next(-100, 100), 2);
                }
            }

            foreach (double x in a){Console.Write(x + " ");}
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(b[i, j] + " ");
                }
                Console.WriteLine();
            }
            double max = a[0], min = a[0];
            double all_sum = 0, all_prod = 1;
            double even_a_sum = 0, odd_b_sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
                if (a[i] < min) min = a[i];
                all_sum += a[i];
                all_prod *= a[i];
                if(i%2==1) even_a_sum += a[i];
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (b[i, j] > max) max = b[i, j];
                    if (b[i, j] < min) min = b[i, j];

                    all_sum += b[i, j];
                    all_prod *= b[i, j];
                    if (j % 2 == 0)
                    {
                        odd_b_sum += b[i, j];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Max: {max} Min: {min}");
            Console.WriteLine($"Sum: {all_sum:F2} Product: {all_prod:F2}");
            Console.WriteLine($"Even A sum: {even_a_sum:F2}");
            Console.WriteLine($"Odd B col sum: {odd_b_sum:F2}");
        }
        public void Task2()
        {
            /*Дано двовимірний масив розмірністю 5×5, заповнений випадковими числами з діапазону від -100 до 100. 
             Визначити суму елементів масиву, розташованих між мінімальним і максимальним елементами.*/
            int[,] b = new int[5, 5];
            Random rnd = new();
            int min=101, max=-101, min_i=0, max_i=0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    b[i, j] = rnd.Next(-100, 101);
                    if (b[i, j] < min)
                    {
                        min = b[i, j];
                        min_i = i * 5 + j;
                    }
                    if (b[i, j] > max) { 
                        max = b[i, j];
                        max_i = i * 5 + j;
                    }
                }
            }
            if (min_i > max_i)
            {
                int t = min_i;
                min_i = max_i;
                max_i = t;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(i*5+j==min_i||i*5+j==max_i) Console.Write($"[{b[i, j]}] ");
                    else Console.Write(b[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int sum = 0;
            for (int i = min_i + 1; i < max_i; i++)
            {
                sum += b[i / 5, i % 5];
            }
            Console.WriteLine($"Sum ([{min_i/5}, {min_i % 5}] - [{max_i / 5}, {max_i % 5}]) = {sum}");
        }

        string cipher(string line, int move)
        {
            StringBuilder sb = new();
            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];
                if (char.IsLetter(ch))
                {
                    char start = 'a';
                    if (char.IsUpper(ch)) start = 'A';
                    ch = (char)((ch - start + move + 26) % 26 + start);
                }
                sb.Append(ch);
            }
            return sb.ToString();
        }
        public void Task3_8()
        {
            /*
             Користувач вводить рядок із клавіатури. Необхідно зашифрувати цей рядок, використовуючи шифр Цезаря.
              Крім механізму шифрування, реалізуйте механізм розшифрування.
             */
            /*Реалізуйте програму, яка приймає через командний рядок: рядок для шифрування та ключ зсуву. 
            Використовуючи шифр Цезаря, зашифруйте рядок і виведіть результат.*/
            Console.Write("Moves = ");
            int move = Convert.ToInt32(Console.ReadLine())%26;
            Console.Write("Enter text to encrypt: ");
            string line = Console.ReadLine();
            string str = cipher(line, move);
            Console.WriteLine(str);
            Console.Write("Enter text to decrypt (0-decrypt previous text): ");
            str = Console.ReadLine();
            if (str == "0") Console.WriteLine(line);
            else
            {
                str = cipher(str, -1*move);
                Console.WriteLine(str);
            }
        }

        void matrix_print(double[,] a, int ax, int ay)
        {
            for (int i = 0; i < ay; i++)
            {
                for (int j = 0; j < ax; j++)
                { 
                    Console.Write($"{a[i, j]:F2}  ");
                }
                Console.WriteLine();
            }
        }

        double[,] matrix_mult_by_num(double[,] a, int x, int y, double k)
        {
            double[,] res = new double[y, x];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    res[i, j] = a[i,j] * k;
                }
            }
            return res;
        }
        double[,] matrix_add(double[,] a, double[,] b, int x, int y)
        {
            double[,] res = new double[y, x];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    res[i, j] = a[i,j]+b[i,j];
                }
            }
            return res;
        }
        double[,] matrix_multiply(double[,] a, int ax, int ay, double[,] b, int bx, int by)
        {
            if (ax != by)
            {
                Console.WriteLine("Multiplication impossible");
                return a;
            }
            double[,] res = new double[ay, bx];
            for(int i=0; i<ay; i++)
            {
                for(int j=0; j<bx; j++)
                {
                    double el = 0;
                    for(int n = 0; n<ax; n++)
                    {
                        el += a[i, n] * b[n, j];
                    }
                    res[i, j] = el;
                }
            }
            return res;
        }
        public void Task4()
        {
            /*
                Створіть додаток, який виконує операції над матрицями:
                Множення матриці на число;
                Додавання матриць;
                Добуток матриць.
             */
            double[,] a = {
                {1, 2, 3, 4 },
                {4, 5, 6, 7 }
            };
            double[,] b = {
                {-9, -8, -7, -6 },
                {6, 7, 8, 9}
            };

            double[,] c = {
                {-1, 0, 0 },
                {2.5, 6, 1},
                {-9, 1, -1},
                {0, 1, 0}
            };
            Console.WriteLine("Enter option:\n1-Print all matrixes\n2-Multiply by a number\n3-Sum  4-Multiply  0-Exit");
            byte choice = Convert.ToByte(Console.ReadLine());
            while (choice != 0) {
                switch (choice)
                {
                    case 2:
                        Console.Write("Enter number(k): "); double k = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("A x k");
                        matrix_print(matrix_mult_by_num(a, 4, 2, k), 4, 2);
                        break;
                    case 3:
                        Console.WriteLine("A + B");
                        matrix_print(matrix_add(a, b, 4, 2), 4, 2);
                        break;
                    case 4:
                        Console.WriteLine("A x C");
                        matrix_print(matrix_multiply(a, 4, 2, c, 3, 4), 3, 2);
                        break;
                    case 1:
                        Console.WriteLine("A");
                        matrix_print(a, 4, 2);
                        Console.WriteLine("B");
                        matrix_print(b, 4, 2);
                        Console.WriteLine("C");
                        matrix_print(c, 3, 4);
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Enter option:\n1-Print all matrixes\n2-Multiply by a number\n3-Sum  4-Multiply  0-Exit");
                choice = Convert.ToByte(Console.ReadLine()); 
            }
        }

        public void Task5()
        {
            /*Користувач з клавіатури вводить у рядок арифметичний вираз. 
             * Додаток має порахувати його результат. 
             * Необхідно підтримувати тільки дві операції: + і -.*/
            Console.Write("Enter expression (only + and -): ");
            string line = Console.ReadLine();
            StringBuilder curr_sb = new();
            char sgn = '+';
            double res = 0, curr = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (!(char.IsDigit(line[i]) || line[i] == '+' || line[i] == '-' || line[i]==',')) continue;
                else if (char.IsDigit(line[i]) || line[i] == ',')
                {
                    curr_sb.Append(line[i]);
                }
                else
                {
                    if (curr_sb.Length > 0) {
                        curr = Convert.ToDouble(curr_sb.ToString());
                        if (sgn != '+') curr *= -1;
                        res += curr;
                        curr_sb.Clear();
                    }
                    sgn = line[i];
                }
            }
            if (curr_sb.Length > 0)
            {
                curr = Convert.ToDouble(curr_sb.ToString());
                if (sgn != '+') curr *= -1;
                res += curr;
            }
            Console.WriteLine($"Result: {res}");
        }

        public void Task6()
        {
            /*
             Користувач з клавіатури вводить деякий текст. 
            Додаток повинен змінювати регістр першої літери 
            кожного речення на букву у верхньому регістрі.
             */
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            StringBuilder sb = new();
            bool next = true;
            for(int i=0; i<text.Length; i ++)
            {
                if (text[i]=='.'|| text[i] == '!' || text[i] == '?')
                {
                    next = true;
                    sb.Append(text[i]);
                }
                else if (next && char.IsLetter(text[i]))
                {
                    sb.Append(char.ToUpper(text[i]));
                    next = false;
                }
                else sb.Append(text[i]);
            }
            Console.WriteLine($"Result: {sb.ToString()}");
        }

        public void Task7() { 
            string text  = @"To be, or not to be, that is the question,
Whether 'tis nobler in the mind to suffer
The slings and arrows of outrageous fortune,
Or to take arms against a sea of troubles,
And by opposing end them? To die: to sleep;
No more; and by a sleep to say we end
The heart-ache and the thousand natural shocks
That flesh is heir to, 'tis a consummation
Devoutly to be wish'd. To die, to sleep";

            Console.WriteLine("Enter unallowed word: ");
            string bad_word = Console.ReadLine();
            StringBuilder result = new();
            StringBuilder curr_word = new();
            int cnt = 0;
            for(int i = 0; i<text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    curr_word.Append(text[i]);
                }
                else
                {
                    if (curr_word.Length > 0) { 
                        string word = curr_word.ToString();
                        if(word.ToLower() == bad_word.ToLower())
                        {
                            string app_text = new string('*', word.Length);
                            result.Append(app_text);
                            cnt++;
                        }
                        else { 
                            result.Append(word);
                        }
                        curr_word.Clear();
                    }
                    result.Append(text[i]);
                }
            }
            if (curr_word.Length > 0)
            {
                string word = curr_word.ToString();
                if (word.ToLower() == bad_word.ToLower())
                {
                    string app_text = new string('*', word.Length);
                    result.Append(app_text);
                    cnt++;
                }
                else
                {
                    result.Append(word);
                }
            }
            Console.WriteLine(result.ToString());
            Console.WriteLine($"{cnt} replacements of the word \"{bad_word}\"");
        }

        public void Task9()
        {
            /*
             Напишіть програму, яка приймає розміри двовимірного масиву 
            і число для множення через параметри командного рядка (наприклад, 3 3 2). 
            Програма повинна згенерувати випадковий двовимірний масив, 
            помножити всі його елементи на задане число і вивести результат.
             */
            int x, y;
            double k;
            Console.Write("Rows: "); y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cols: "); x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number: "); k = Convert.ToDouble(Console.ReadLine());

            double[,] a = new double[y, x];
            Random rnd = new Random();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    a[i, j] = Math.Round(rnd.NextDouble() + rnd.Next(-100, 100), 2);
                }
            }
            matrix_print(a, x, y);
            Console.WriteLine();
            a = matrix_mult_by_num(a, x, y, k);
            matrix_print(a, x, y);
        }
    }
}
