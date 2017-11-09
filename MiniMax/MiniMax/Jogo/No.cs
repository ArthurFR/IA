using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    class No
    {
        string[,] estado;
        bool max;
        bool raiz;
        int utilidade;
        No pai;

        public No(string[,] estado)
        {
            this.raiz = true;
            this.estado = (string[,])estado.Clone();
            this.pai = null;
        }

        public No(No pai, string[,]estado, bool max)
        {
            this.pai = pai;
            this.estado = (string[,])estado.Clone();
            this.max = max;
            this.raiz = false;
        }
        public bool getMax()
        {
            return this.max;
        }

        public void SetEstado(string[,] estado)
        {
            this.estado = (string[,])estado.Clone();
        }
        public string[,] GetEstado()
        {
            return this.estado;
        }

        public bool eTerminal(string[,] estado)
        {
            return true;
        }

        public void setUtilidade(int utilidade)
        {
            this.utilidade = utilidade;
        }

        public int GetUtilidade()
        {
            return this.utilidade;
        }
    }
}
