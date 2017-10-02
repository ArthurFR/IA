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
    enum acoes
    {
        MovDireita,
        MovEsquerda,
        Aspira
    }

    class Agente
    {

        /*bool limpo { get; set; }
        bool ativo { get; set; }
        int[] local = new int[1]; // 0 = esquerda, 1 direita;
        ArrayList log = new ArrayList();
        
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
        }*/


        //Pensei em controlar o estado usando essa classe chamada estado, 
        //a ideia era fazer tipo o padrão state mesmo, só que como ia dar trabalho resolvi fazer só um estado em vez de um genério e uma classe para cada possível estado
        //Depois da uma olhada e me fala o que você achou
        public Estado estado;

        public Agente(int posicao) {
            this.estado = new Estado(posicao);
        }

        public bool Acao(acoes acao)
        {
            return this.estado.Acao(acao);
        }

    }
}
