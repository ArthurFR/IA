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
            string[,] filho = new string[3, 3];
            Jogo jogo = new Jogo(inicial, "o", "x");
            filho[0, 0] = "X";
            No no = new No(new No(inicial), filho, true);
            
            Console.WriteLine(jogo.MinMax(no));
            //MiniMax.Jogo.ExibeMatriz(matriz); //Se for usar mudar para string.
            System.Console.ReadLine();
        }
        
    }
}
