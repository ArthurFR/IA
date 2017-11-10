using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    class Vencedor
    {
        String vencedor;
        
        public Vencedor()
        {
            this.vencedor = null;
        }
        public void SetVencedor(string vencedor)
        {
            this.vencedor = vencedor;
        }
        public string GetVencedor()
        {
            return this.vencedor;
        }
    }
}
