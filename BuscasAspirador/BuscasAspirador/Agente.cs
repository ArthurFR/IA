using System;
using System.Collections;
using System.Text;


/*
 idéia, vetor de state..
1-(sujo)/sujo
2-(limpo)/sujo
3-limpo/(sujo)
4-limpo/(limpo)
*/


namespace BuscasAspirador
{
    class Agente
    {
        bool limpo;

        int[] local = new int[1]; // 0 = esquerda, 1 direita;
        ArrayList log = new ArrayList();
        bool ativo;
        
        //contrutor
        public Agente()
        {
            this.limpo = false;
            local[0] = 1;
            local[1] = 0;
            ativo = true;
            return;
        }


        public void Ativa()
        {
            this.ativo = true;
            return;
        }

        public void Desativa()
        {
            this.ativo = false;
            return;
        }



        public void MoverEsquerda()
        {
            if (this.local[0] == 0)
            {
                this.local[0] = 1;
                this.local[1] = 0;
            }
            return;
        }

        public void MoverDireita()
        {
            if (this.local[1] == 0)
            {
                this.local[1] = 1;
                this.local[0] = 0;
            }
            return;
        }

        public void Limpar()
        {
            this.limpo = true;
            return;
        }
        public bool Verificar()
        {
            return this.limpo;
        }

    }
}
