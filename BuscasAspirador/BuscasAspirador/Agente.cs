using System;
using System.Collections.Generic;
using System.Linq;

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

        List<acoes> acoes;


        public Agente(int posicao) {
            this.estadoInicial = new Estado(posicao);
            objetivos = new List<Estado>();
            objetivos.Add(new Estado(false,false, 0));
            objetivos.Add(new Estado(false, false, 1));

            acoes = new List<BuscasAspirador.acoes>();
            this.acoes.Add(BuscasAspirador.acoes.Aspira);
            this.acoes.Add(BuscasAspirador.acoes.MovEsquerda);
            this.acoes.Add(BuscasAspirador.acoes.MovDireita);
        }

        public Agente(bool esquerdo, bool direito,int posicao)
        {
            this.estadoInicial = new Estado(esquerdo,direito,posicao);
            objetivos = new List<Estado>();
            objetivos.Add(new Estado(false, false, 0));
            objetivos.Add(new Estado(false, false, 1));

            acoes = new List<BuscasAspirador.acoes>();
            this.acoes.Add(BuscasAspirador.acoes.Aspira);
            this.acoes.Add(BuscasAspirador.acoes.MovEsquerda);
            this.acoes.Add(BuscasAspirador.acoes.MovDireita);
        }

        public Estado BuscaLargura()
        {
            int nosVisitados = 0;
            Estado estado = this.estadoInicial;
            Estado filho;
            Queue<Estado> borda = new Queue<Estado>();
            List<Estado> explorados = new List<Estado>();

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

        public Estado BuscaProfundidade()
        {
            int nosVisitados = 0;

            Estado no = this.estadoInicial;
            Estado filho;

            Stack<Estado> borda = new Stack<Estado>();
            List<Estado> explorados = new List<Estado>();

            if (this.estadoInicial.Pertence(objetivos))
            {
                Console.WriteLine("Estado inicial é objetivo");
                return no;
            }

            borda.Push(no);

            while (borda.Count() > 0)
            {
                no = borda.Pop();
                
                if (no.Pertence(explorados))
                    continue;

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
                    if (!filho.Pertence(explorados))
                        borda.Push(filho);

                }
            }
            return null;

        }

        public Estado BuscaEstrela()
        {
            int nosVisitados = 0;

            Estado no = this.estadoInicial;
            Estado filho;

            List<Estado> borda = new List<Estado>();
            List<Estado> explorados = new List<Estado>();

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

                    if (filho.ExisteNoIgualMenorF(borda))
                        continue;
                    if (filho.ExisteNoIgualMenorF(explorados))
                        continue;
                    borda.Add(filho);
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
