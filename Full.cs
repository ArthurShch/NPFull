using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPFull
{
    class Full
    {
        public bool exitEnable = false;//выход в случае если итерации закончились
        public int counter = 0;//счетчик количество итераций для рекурсивного алгоритма
        public int countIter; //где хранится заданное количество итераций
        public double bestRes = 0; //лучший результат 
        public int[] besArray; // лучший массив на основании функции FunctionCheckResult

        //просто пример функции оценки результата
        // сумма первого и последнего элемента 
        public int FunctionCheckResult(int[] arr)
        {
            return arr.First() + arr.Last();
        }

        //функция для уделения ранее размещённых элементов
        public int[] Remove(int[] array, int index)
        {
            int[] arrayDelEl = new int[array.Length - 1];

            //с начало
            Array.Copy(array, 0, arrayDelEl, 0, index);

            //после
            //зделать проверки на последний
            Array.Copy(array, index + 1, arrayDelEl, index, array.Length - index - 1);

            return arrayDelEl;
        }

        //arrel - свободные элементы, arrplace - своб ячейки, result - текущая схема 
        public void Recursion(int[] arrEl, int[] arrPlace, int[] result) 
        {
            int placeEl = -1;
            for (int i = 0; i < arrEl.Length; i++)
            {
                placeEl = arrEl[i];
                //новый массив элементов без одного, который был размещён
                int[] nArrEl = Remove(arrEl, i);
                int place = -1;
                for (int j = 0; j < arrPlace.Length; j++)
                {
                    place = arrPlace[j];
                    int[] nArrPlace = Remove(arrPlace, j);

                    //полное копирование результа
                    int[] nResult = new int[result.Length];
                    Array.Copy(result, nResult, result.Length);                                        
                    nResult[place] = placeEl;

                    if (nArrEl.Length == 0)
                    {
                        //сдесь оценка резульата и его сохранение                         
                        int nBestRes = FunctionCheckResult(nResult);
                        if (bestRes < nBestRes)
                        {
                            bestRes = nBestRes;
                            besArray = new int[nResult.Length];
                            Array.Copy(nResult, besArray, nResult.Length);
                        }

                        //счётчик
                        if (counter == countIter)
                        {
                            exitEnable = true;
                            return;
                        }
                        counter++;
                    }
                    else
                    {
                        Recursion(nArrEl, nArrPlace, nResult);
                        if (exitEnable)
                        {
                            return;
                        }
                    }

                }// фор мест
            }//фор елементов 
        }

    }
}
