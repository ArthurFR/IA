using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscasAspirador
{
    class Estado
    {
        public bool EsquerdoSujo { get; set; }
        public bool DireitoSujo { get; set; }
        public int Posicao { get; set; } // 0 esquerdo, 1 direito
        public Estado Pai { get; set; }
        public acoes acaoAnterior { get; set; }
        List<Estado> lista = new List<Estado>();//armazena os filhos

        public Estado(int posicao)
        {
            EsquerdoSujo = true;
            DireitoSujo = true;
            this.Posicao = posicao;
        }

        public Estado(bool esquerdo, bool direito, int posicao)
        {
            this.EsquerdoSujo = esquerdo;
            this.DireitoSujo = direito;
            this.Posicao = posicao;
        }

        public Estado(bool esquerdo, bool direito, int posicao, acoes acaoAnterior)
        {
            this.EsquerdoSujo = esquerdo;
            this.DireitoSujo = direito;
            this.Posicao = posicao;
            this.acaoAnterior = acaoAnterior;
        }

        public Estado Acao(acoes acao)
        {
            switch (acao)
            {
                case acoes.MovDireita:
                    return new Estado(this.EsquerdoSujo, this.DireitoSujo, 1, acao);
                    break;
                case acoes.MovEsquerda:
                    return new Estado(this.EsquerdoSujo, this.DireitoSujo, 0, acao);
                    break;
                case acoes.Aspira:
                    if (this.Posicao == 0)
                    {
                        return new Estado(false, this.DireitoSujo, this.Posicao, acao);
                    }
                    else
                    {
                        return new Estado(this.EsquerdoSujo, false, this.Posicao, acao);
                    }
                    break;
            }
            return null;
        }
    
        public bool Igual(Estado estado)
        {
            if(this.EsquerdoSujo == estado.EsquerdoSujo &&
               this.DireitoSujo == estado.DireitoSujo &&
               this.Posicao == estado.Posicao)
            {
                return true;
            }
            else
                return false;

        }

        public bool Pertence(List<Estado> estados)
        {
            foreach(Estado a in estados)
            {
                if (this.Igual(a))
                    return true;
            }
            return false;
        }

        public Estado Expande(Estado estado)
        {
            //state 1  --> esquerdo [sujo], direito [sujo], Agente [Esquerdo]
            if (estado.EsquerdoSujo && estado.DireitoSujo && estado.Posicao == 0)
            {
                Estado estado0 = new Estado(false, true, 0);//esquerdo [Limpo], direito [sujo], Agente [esquerdo]
                estado.lista.Add(estado0);
                Estado estado1 = new Estado(true,true,1);//esquerdo [sujo], direito [sujo], Agente [Direito]
                estado.lista.Add(estado1);
            }

            //state 2  --> esquerdo [sujo], direito [sujo], Agente [Direito]
            if (estado.EsquerdoSujo && estado.DireitoSujo && estado.Posicao == 1)
            {
                Estado estado0 = new Estado(true, false, 1);//esquerdo [Limpo], direito [sujo], Agente [Direito]
                estado.lista.Add(estado0);
                Estado estado1 = new Estado(true, true, 0);//esquerdo [sujo], direito [sujo], Agente [esquerdo]
                estado.lista.Add(estado1);
            }

            //state 3  --> esquerdo [Limpo], direito [sujo], Agente [Esquerdo]
            if ( !estado.EsquerdoSujo && estado.DireitoSujo && estado.Posicao == 0)
            {
                Estado estado0 = new Estado(false, true, 1); //esquerdo [limpo], direito [sujo], Agente [Direito]
                estado.lista.Add(estado0);
            }

            //state 4  --> esquerdo [Limpo], direito [sujo], Agente [Direito]
            if (!estado.EsquerdoSujo && estado.DireitoSujo && estado.Posicao == 1)
            {
                Estado estado0 = new Estado(false, false, 1); //esquerdo [limpo], direito [Limpo], Agente [Direito]
                estado.lista.Add(estado0);
                Estado estado1 = new Estado(false, true, 0);//esquerdo [Limpo], direito [Sujo], Agente [esquerdo]
                estado.lista.Add(estado1);
            }

            //state 5  --> esquerdo [Limpo], direito [Limo], Agente [Direito]
            if (!estado.EsquerdoSujo && !estado.DireitoSujo && estado.Posicao == 1)
            {
                Estado estado0 = new Estado(false, false, 0); //esquerdo [limpo], direito [sujo], Agente [Esquerdo]
                estado.lista.Add(estado0);
            }

            //state 6  --> esquerdo [Sujo], direito [Limo], Agente [Direito]
            if (estado.EsquerdoSujo && !estado.DireitoSujo && estado.Posicao == 1)
            {
                Estado estado0 = new Estado(true, false, 0); //esquerdo [Sujo], direito [Limpo], Agente [Esquerdo]
                estado.lista.Add(estado0);
            }
            //state 7  --> esquerdo [Sujo], direito [Limo], Agente [Esquerdo]
            if (estado.EsquerdoSujo && !estado.DireitoSujo && estado.Posicao == 0)
            {
                Estado estado0 = new Estado(false, false, 0); //esquerdo [limpo], direito [Limpo], Agente [Esquerdo]
                estado.lista.Add(estado0);
                Estado estado1 = new Estado(true, false, 1); //esquerdo [Sujo], direito [Limpo], Agente [Direito]
                estado.lista.Add(estado1);
            }

            //state 8  --> esquerdo [Limpo], direito [Limo], Agente [Esquerdo]
            if (!estado.EsquerdoSujo && !estado.DireitoSujo && estado.Posicao == 0)
            {
                Estado estado0 = new Estado(false, false, 1); //esquerdo [limpo], direito [sujo], Agente [Direito]
                estado.lista.Add(estado0);
            }
            return estado;
        }

    }
}

