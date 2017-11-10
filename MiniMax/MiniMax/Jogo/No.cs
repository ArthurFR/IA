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
        List<No> filhos;
        No filho;
        public No(string[,] estado)
        {
            this.raiz = true;
            this.estado = (string[,])estado.Clone();
            this.pai = null;
            filhos = new List<No>();
            filho = null;
        }

        public No(No pai, string[,]estado, bool max)
        {
            this.pai = pai;
            this.estado = (string[,])estado.Clone();
            this.max = max;
            this.raiz = false;
            filhos = new List<No>();
            filho = null;
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
        public void AddFilho(No no)
        {
            filhos.Add(no);
        }
        public List<No> GetFilhos()
        {
            return this.filhos;
        }
        public void SetFilho(No filho)
        {
            this.filho = filho;
        }
        public No GetFilho()
        {
            return this.filho;
        }
    }
}
