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

            //int[,] matriz = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // estado inicial State(0) teste
            Jogo jogo = new Jogo(inicial);

            //MiniMax.Jogo.ExibeMatriz(matriz); //Se for usar mudar para string.
            System.Console.ReadLine();
        }
        
    }
}
