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
            no = new No();
            this.no.SetEstado(estadoInicial);
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

        public  GetUtilidade(No no)
        {
            if (EstadoTerminal(no.GetEstado))
            {
                return -1, 0, ou 1;
            }


            return GetUtilidade(No no)
        }
    }
}
