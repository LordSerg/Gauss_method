using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер матрицы:");
            Console.Write("Высота = ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина = ");
            int w = Convert.ToInt32(Console.ReadLine());
            double [,]m;
            m = new double[h,w];
            //for (int i = 0; i < h; i++)
            //    for (int j = 0; j < w; j++)
            //    {
            //        m[i,j]=Convert.ToDouble(Console.ReadLine());
            //    }
            Random r = new Random();
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    m[i, j] = r.Next(-2, 3);
                }
            Show_matrix(m,h,w);
            double k=0;
            int t = 0;
            int min = h;
            if (min > w)
                min = w;
            for (int i = 0; i + t < min; i++)
            {
                swap_col:
                if (i + t < min)
                {
                    if (m[i + t, i] == 0 && i + t < min)
                    {
                        //меняем столбцы местами так, чтобы 
                        //элемент m[i,i] был ненулевой
                        int j1 = -1;
                        for (int j = i + 1; j < w; j++)
                        {
                            if (m[i + t, j] != 0)
                            {
                                j1 = j;
                                break;
                            }
                        }
                        if (j1 > 0)
                        {//если в строке остались ненулевые эл. - меняем столбцы местами
                            for (int q = 0; q < h; q++)
                            {
                                m[q, i] += m[q, j1];
                                m[q, j1] = m[q, i] - m[q, j1];
                                m[q, i] -= m[q, j1];
                            }
                            //k = m[i1, i] / m[i, i];
                            Console.WriteLine("Меняем местами {0} и {1} столбцы:", i + 1, j1 + 1);
                            Show_matrix(m, h, w);
                        }
                        else
                        {
                            //иначе - игнорируем эту строку, т.к. она нулевая
                            t++;
                            goto swap_col;
                        }
                    }
                }
                else
                    break;
                for(int i1=i+1;i1<h;i1++)
                {
                    if (m[i1, i] != 0 && m[i + t, i]!=0)
                    {
                        k = m[i1, i] / m[i + t, i];
                        double a = m[i1, i], b = m[i + t, i];
                        for (int j = 0; j < w; j++)
                        {
                            m[i1, j] = (m[i1, j] - m[i + t, j] * k) * m[i + t, i];
                        }
                        Console.WriteLine("От {0}-й строки отнимаем {1}-ю, домноженую на {2}/{3} ({4}) и умнажаем всю {0}-ю строку на {3}:", i1 + 1, i + 1 + t, a, b,k);
                        Show_matrix(m, h, w);
                    }
                }
                //находим нок чисел каждой следующей строки и делим строку на него
                //это необходимо для уменьмения коефициентов домножения

            }
            Console.ReadKey();
        }
        static void Show_matrix(double[,] m, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(m[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
        //static void Swap_Columns(double[,] m, int height, int width, int i,int t)
        //{
        //    int j1 = -1;
        //    for (int j = i + 1-t; j < width; j++)
        //    {
        //        if (m[i, j] != 0)
        //        {
        //            j1 = j;
        //        }
        //    }
        //    if (j1 > 0)
        //    {//если в строке остались ненулевые эл. - меняем столбцы местами
        //        for (int q = 0; q < height; q++)
        //        {
        //            m[q, i-t] += m[q, j1];
        //            m[q, j1] = m[q, i-t] - m[q, j1];
        //            m[q, i-t] -= m[q, j1];
        //        }
        //        k = m[i1, i] / m[i, i];
        //    }
        //    else
        //    {
        //        //иначе - игнорируем эту строку и проверяем след. строку
        //        t++;
        //        Swap_Columns(m,height,width,i+1,t);
        //    }
        //}
        /*
Введите размер матрицы:
Высота = 3
Ширина = 3
0 0 2
1 0 0
2 2 0
//////////
0 0 2
0 0 0
2 2 0
//////////
0 0 2
0 0 0
0 0 0
//////////
0 0 2
0 0 0
0 0 0
         */
    }
}
