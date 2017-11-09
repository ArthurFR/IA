using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    class Jogo
    {
        No no;
        string[,] matriz;

        public Jogo(string[,] estadoInicial)
        {
            no = new No();
            this.no.setEstado(estadoInicial);
        }

        public string[,] Sucessor(string[,] estado, Tuple<int, int, string> acao)
        {
            string[,] sucessor = (string[,])estado.Clone();
            sucessor[acao.Item1, acao.Item2] = acao.Item3;
            return sucessor;
        }

        
        public static bool VerificaVencedor(string[,] matriz, string vencedor)
        {
            bool Vencedor = false;
            int contX = 0;
            int contO = 0;
            
            //verifica linha
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                contX = 0;
                contO = 0;
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j].Equals("X"))
                        contX++;

                    if (matriz[i, j].Equals("O"))
                        contO++;

                    if (contX == 3)
                    {
                        vencedor = "X";
                        return true;
                    }

                    if (contO == 3)
                    {
                        vencedor = "O";
                        return true;
                    }
                        
                }
            }

            //verifica coluna

            for (int i = 0; i < matriz.GetLength(1); i++)
            {

                contX = 0;
                contO = 0;
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    if (matriz[j, i].Equals("X"))
                        contX++;

                    if (matriz[j, i].Equals("O"))
                        contO++;

                    if (contX == 3)
                    {
                        vencedor = "X";
                        return true;
                    }

                    if (contO == 3)
                    {
                        vencedor = "O";
                        return true;
                    }

                }
            }
            //verifica diagonal
            if (matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
            {
                vencedor = matriz[0, 0];
                return true;
            }

            else if (matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 1])
            {
                vencedor = matriz[0, 2];
                return true;
            }

            return false;
        }

        public static void ExibeMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(1); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    Console.Write(matriz[j, i]);
                }
                Console.WriteLine();
            }
        }

    }
}

