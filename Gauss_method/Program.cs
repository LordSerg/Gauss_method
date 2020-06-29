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
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    m[i,j]=Convert.ToDouble(Console.ReadLine());
                }
            //Random r = new Random();
            //for(int i=0;i<h;i++)
            //    for(int j=0;j<w;j++)
            //    {
            //        m[i, j] = r.Next(1,10);
            //    }
            Show_matrix(m,h,w);
            double k;
            for(int i=0;i<h;i++)
            {
                for(int i1=i+1;i1<h;i1++)
                {
                    if (m[i, i] != 0)
                        k = m[i1, i] / m[i, i];
                    else
                        k = 0;
                    for(int j=0;j<w;j++)
                    {
                        m[i1, j] = m[i1, j] - m[i, j] * k;
                    }
                    Console.WriteLine("//////////");
                    Show_matrix(m, h, w);
                }
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
    }
}
