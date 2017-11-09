using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] inicial = new string[3,3];
            Jogo jogo = new Jogo(inicial, "o", "x");

            //MiniMax.Jogo.ExibeMatriz(matriz); //Se for usar mudar para string.
            System.Console.ReadLine();
        }
        
    }
}
