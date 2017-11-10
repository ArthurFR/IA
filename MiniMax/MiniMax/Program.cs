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
            //filho[0, 0] = "X";
            //filho[0, 1] = "O";
            //filho[0, 2] = "X";
            //filho[1, 0] = "O";
            //filho[1, 2] = "X";
            //filho[2, 0] = "X";
            //filho[2, 1] = "O";

            jogo.ExibeMatriz(filho);
            No no = new No(new No(inicial), filho, true);
            jogo.ExibeMatriz(no.GetEstado());
            Console.WriteLine(jogo.MinMax(no));
            jogo.NumeroFilhos(no);
            jogo.ImprimeJogo(no);
            //foreach(No n in no.GetFilhos())
            //{
            //    Console.WriteLine(n.GetUtilidade());
            //   jogo.ExibeMatriz(n.GetEstado());
            //}
            //MiniMax.Jogo.ExibeMatriz(matriz); //Se for usar mudar para string.
            System.Console.ReadLine();
        }
    }
}
