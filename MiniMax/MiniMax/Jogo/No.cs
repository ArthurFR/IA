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
        int utilidade;

        public void SetEstado(string[,] estado)
        {
            this.estado = estado;
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
    }
}
