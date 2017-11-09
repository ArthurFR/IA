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
        string min, max;
        List<Tuple<int, int, string>> movimentos;

        public Jogo(string[,] estadoInicial, string min, string max)
        {
            no = new No(estadoInicial);
            this.min = min;
            this.max = max;

            movimentos.Add(new Tuple<int, int, string>(0, 0, "x"));
            movimentos.Add(new Tuple<int, int, string>(0, 1, "x"));
            movimentos.Add(new Tuple<int, int, string>(0, 2, "x"));
            movimentos.Add(new Tuple<int, int, string>(1, 0, "x"));
            movimentos.Add(new Tuple<int, int, string>(1, 1, "x"));
            movimentos.Add(new Tuple<int, int, string>(1, 2, "x"));
            movimentos.Add(new Tuple<int, int, string>(2, 0, "x"));
            movimentos.Add(new Tuple<int, int, string>(2, 1, "x"));
            movimentos.Add(new Tuple<int, int, string>(2, 2, "x"));

            movimentos.Add(new Tuple<int, int, string>(0, 0, "o"));
            movimentos.Add(new Tuple<int, int, string>(0, 1, "o"));
            movimentos.Add(new Tuple<int, int, string>(0, 2, "o"));
            movimentos.Add(new Tuple<int, int, string>(1, 0, "o"));
            movimentos.Add(new Tuple<int, int, string>(1, 1, "o"));
            movimentos.Add(new Tuple<int, int, string>(1, 2, "o"));
            movimentos.Add(new Tuple<int, int, string>(2, 0, "o"));
            movimentos.Add(new Tuple<int, int, string>(2, 1, "o"));
            movimentos.Add(new Tuple<int, int, string>(2, 2, "o"));
        }

        public List<No> GeraNosSucessores(No no, List<Tuple<int, int, string>> sucessores)
        {
            List < No > nosSucessores = new List<No>();

            foreach(Tuple<int, int, string> m in sucessores)
            {
                No sucessor = new No(no, Movimenta(no.GetEstado(), m),!no.getMax());
                nosSucessores.Add(sucessor);
            }
            return nosSucessores;
        }

        public List<Tuple<int,int,string>> Sucessores(string[,] estado)
        {
            List<Tuple<int, int, string>> sucessores = new List<Tuple<int, int, string>>();
            foreach(Tuple<int, int, string> t in movimentos)
            {
                if (MovimentoValido(t, estado))
                {
                    sucessores.Add(t);
                }
            }
            return sucessores;
        }

        public string[,] Movimenta(string[,] estado, Tuple<int, int, string> acao)
        {
            string[,] novoEstado = (string[,])estado.Clone();
            novoEstado[acao.Item1, acao.Item2] = acao.Item3;
            return novoEstado;
        }

        public bool MovimentoValido(Tuple<int,int, string> movimento, string[,] estado)
        {
            if (estado[movimento.Item1, movimento.Item2] == null)
                return true;
            return false;
        }


        public int MinMax(No no)
        {
            string vencedor = null;
            List<Tuple<int, int, string>> movimentosValidos;
            List<No> nosSucessores;

            //Se for terminal retorna utilidade
            if (eTerminal(no, vencedor))
            {
                if (vencedor.Equals("X"))
                    return 1;
                if (vencedor.Equals("O"))
                    return -1;
                return 0;
            }

            movimentosValidos = Sucessores(no.GetEstado());
            nosSucessores = GeraNosSucessores(no,movimentosValidos);
            foreach (No n in nosSucessores)
            {
                n.setUtilidade(MinMax(n));
            }
            if (no.getMax())
            {
                int maximo = nosSucessores.First<No>().GetUtilidade();
                foreach (No n in nosSucessores)
                {
                    if (n.GetUtilidade() > maximo)
                        maximo = n.GetUtilidade();
                }
                return maximo;
            }
            else
            {
                int minimo = nosSucessores.First<No>().GetUtilidade();
                foreach (No n in nosSucessores)
                {
                    if (n.GetUtilidade() < minimo)
                        minimo = n.GetUtilidade();
                }
                return minimo;
            }
        }

        public bool eTerminal(No no,string vencedor)
        {
            if (VerificaTabuleiroCheio(no.GetEstado()))
            {
                VerificaVencedor(no.GetEstado(), vencedor);
                return true;
            }
            if (VerificaVencedor(no.GetEstado(), vencedor))
            {
                return true;
            }
            return false;
        }

        public bool VerificaTabuleiroCheio(string[,] estado)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (estado[i, j] == null)
                        return false;
                }
            }
            return true;
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

