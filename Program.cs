using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriz = new int[3,3] {{0,0,0}, {0,0,0}, {0,0,0}}; // estado inicial State(0)
            ExibeMatriz(matriz);
            System.Console.ReadKey();

        }



        public static void Round(int round, int[,] matriz)
        {
            if (round == 1)
            {

            }

        }



        public static void ExibeMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
