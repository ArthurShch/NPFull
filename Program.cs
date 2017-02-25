using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPFull
{
    class Program
    {
        static void Main(string[] args)
        {
            Full obj = new Full();

            // ограничение на 1000 итераций
            obj.countIter = 1000;

            //создадим массив элементов
            int[] arrEl = new int[10];

            for (int i = 0; i < 10; i++)
            {
                arrEl[i] = i;
            }

            //создадим массив позиций 
            // у которого специально мест больше чем элементов
            int[] arrPlace = new int[12];
            int[] result = new int[12];

            for (int i = 0; i < 12; i++)
            {
                arrPlace[i] = i;
                result[i] = -1;
            }

            obj.Recursion(arrEl, arrPlace, result);

            for (int i = 0; i < obj.besArray.Length; i++)
            {
                Console.Write(obj.besArray[i]);
                Console.Write(' ');
            }
            Console.ReadKey();

        }
    }
}
