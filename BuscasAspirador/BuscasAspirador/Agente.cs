using System;
using System.Collections.Generic;
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
        public Estado estadoInicial;
        public List<Estado> objetivos;

        //Listas para as buscas
        //public List<Estado> explorados;
        //public List<Estado> borda;

        public Agente(int posicao) {
            this.estadoInicial = new Estado(posicao);
            objetivos = new List<Estado>();
            objetivos.Add(new Estado(false,false, 0));
            objetivos.Add(new Estado(false, false, 1));
        }

        public Agente(bool esquerdo, bool direito,int posicao)
        {
            this.estadoInicial = new Estado(esquerdo,direito,posicao);
            objetivos = new List<Estado>();
            objetivos.Add(new Estado(false, false, 0));
            objetivos.Add(new Estado(false, false, 1));
        }
        //public bool Acao(acoes acao)
        //{
        //    return this.estadoInicial.Acao(acao);
        //}

        public Estado BuscaLargura()
        {
            int custo = 0;
            Estado estado = this.estadoInicial;
            Estado filho;
            Queue<Estado> borda = new Queue<Estado>();
            List<Estado> explorados = new List<Estado>();
            List<acoes> acoes = new List<BuscasAspirador.acoes>();
            acoes.Add(BuscasAspirador.acoes.MovEsquerda);
            acoes.Add(BuscasAspirador.acoes.MovDireita);
            acoes.Add(BuscasAspirador.acoes.Aspira);


            if (this.estadoInicial.Pertence(objetivos))
            {
                Console.WriteLine("Estado inicial é objetivo");
                return estado;
            }

            borda.Enqueue(estado);

            while (1 == 1)
            {
                if (borda.Count == 0)
                {
                    Console.WriteLine("Falha");
                    return null;
                }
                estado = borda.Dequeue();
                foreach(acoes a in acoes)
                {
                    filho = estado.Acao(a);
                    if (!filho.Pertence(explorados))
                    {
                        if (filho.Pertence(objetivos))
                        {
                            Console.WriteLine("Achou");
                            return filho;
                        }
                        borda.Enqueue(filho);
                    }
                }
            }
        }

        public void BuscaEstrela()
        {

        }
    }
}
