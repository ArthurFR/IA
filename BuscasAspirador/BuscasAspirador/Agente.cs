using System;
using System.Collections.Generic;
using System.Linq;
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
            int nosVisitados = 0;
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
                explorados.Add(estado);
                nosVisitados++;
                foreach(acoes a in acoes)
                {
                    filho = estado.Acao(a);
                    if (!filho.Pertence(explorados))
                    {
                        if (filho.Pertence(objetivos))
                        {
                            Console.WriteLine("Achou");
                            Console.WriteLine("Nós visitados: " + nosVisitados);
                            return filho;
                        }
                        borda.Enqueue(filho);
                    }
                }
            }
        }

        public Estado BuscaEstrela()
        {
            int nosVisitados = 0;

            Estado no = this.estadoInicial;
            Estado filho;

            List<Estado> borda = new List<Estado>();
            List<Estado> explorados = new List<Estado>();

            List<acoes> acoes = new List<BuscasAspirador.acoes>();
            acoes.Add(BuscasAspirador.acoes.MovEsquerda);
            acoes.Add(BuscasAspirador.acoes.MovDireita);
            acoes.Add(BuscasAspirador.acoes.Aspira);

            no.g = 0;
            no.h = no.CalculaH();
            no.f = no.h + no.g;
            borda.Add(no);

            if (no.Pertence(objetivos))
            {
                return no;
            }

            while (borda.Count != 0)
            {
                no = this.MenorF(borda);
                borda.Remove(no);
                explorados.Add(no);
                nosVisitados++;

                foreach (acoes a in acoes)
                {
                    filho = no.Acao(a);
                    if (filho.Pertence(objetivos))
                    {
                        Console.WriteLine("Achou");
                        Console.WriteLine("Nós visitados: " + nosVisitados);
                        return filho;
                    }
                    
                    filho.g = no.g + 1;
                    filho.f = filho.g + filho.h;

                    if (!filho.ExisteNoIgualMenorF(borda))
                    {
                        if (!filho.ExisteNoIgualMenorF(explorados))
                            borda.Add(filho);
                    }
                }
            }
            return null;
        }


        public Estado MenorF(List<Estado> nos)
        {
            Estado menorF = nos.First();
            foreach(Estado e in nos)
            {
                if (e.f < menorF.f)
                    menorF = e;
            }
            return menorF;
        }
    }
}
