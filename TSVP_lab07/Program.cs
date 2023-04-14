using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSVP_lab07
{
    internal class Program
    {

        static void Main()
        {
            int[] masVes = { 3, 5, 8 };
            int[] masStoim = { 8, 14, 23 };

            int maximus(int one, int two, int three)
            {
                int temp = one;
                if (temp <= two)
                {
                    if (temp <= three)
                    {
                        if (two <= three)
                        {
                            temp = three;
                        }
                        else
                        {
                            temp = two;
                        }
                    }
                    else
                    {
                        temp = two;
                    }
                }
                else if ((temp > two) && (temp <= three))
                {
                    temp = three;
                }
                return temp;
            }

            Console.Write("Введите объём рюкзака: ");
            int sizeBackpack = int.Parse(Console.ReadLine());
            sizeBackpack++;
            int weight = sizeBackpack - 1;
            int[] maxF = new int[sizeBackpack];

            for (int ptz = 0; ptz < sizeBackpack; ptz++)
            {
                maxF[ptz] = 0;
            }

            for (int M = 0; M < sizeBackpack; M++)
            {
                int[] ott = { 0, 0, 0 };
                for (int t = 0; t < 3; t++)
                {
                    if (M - masVes[t] < 0)
                    {
                        ott[t] = 0;
                    }
                    else
                    {
                        ott[t] = maxF[M - masVes[t]] + masStoim[t];
                    }
                }
                maxF[M] = maximus(ott[0], ott[1], ott[2]);
            }

            Console.WriteLine();

            int maxStoim = maxF[sizeBackpack - 1];
            Console.WriteLine($"Максимально возможная стоимость товаров при грузоподъёмности {sizeBackpack - 1}кг. = {maxStoim} у.е.");

            int[] optimus = { 0, 0, 0 };
            bool flag = false;
            int Start = maxF[sizeBackpack - 1];

            Console.WriteLine();
            while (!flag)
            {
                if (weight > 0)
                {
                    for (int mind = 0; mind < 3; mind++)
                    {
                        if (maxF[weight - masVes[mind]] + masStoim[mind] == Start)
                        {
                            optimus[mind]++;
                            Start -= masStoim[mind];
                            weight -= masVes[mind];
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = true;
                }
            }

            Console.WriteLine("Оптимальный выбор товаров будет таким:");
            for (int count = 0; count < 3; count++)
            {
                if (optimus[count] != 0)
                {
                    Console.WriteLine($"Берём {optimus[count]} ед. товара весом {masVes[count]}кг. единичной стоимостью {masStoim[count]} у.е. общим весом {optimus[count] * masVes[count]}кг. на общую сумму {optimus[count] * masStoim[count]} у.е.");
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
