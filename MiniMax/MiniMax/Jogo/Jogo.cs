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
    }
}
