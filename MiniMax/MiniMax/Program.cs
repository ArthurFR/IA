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
            filho[0, 1] = "O";
            //filho[0, 2] = "X";
            //filho[1, 0] = "O";
            //filho[1, 2] = "X";
            //filho[2, 0] = "X";
            //filho[2, 1] = "O";

            No no = new No(new No(inicial), filho, false);
            jogo.MinMax(no);
            //jogo.MinMax2(no, -1000, 1000);
            //jogo.MinMaxPoda(no, -1000, 1000);
            jogo.NumeroFilhos(no);
            jogo.ImprimeJogo(no);
            Console.WriteLine("Nós visitados: " + jogo.GetNosVisitados());
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
