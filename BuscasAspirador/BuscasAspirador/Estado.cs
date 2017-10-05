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

        //Atributos para o algoritmo A*
        public int g { get; set; }
        public int h { get; set; }
        public int f { get; set; }

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

        public Estado(bool esquerdo, bool direito, int posicao, Estado pai,acoes acaoAnterior)
        {
            this.EsquerdoSujo = esquerdo;
            this.DireitoSujo = direito;
            this.Posicao = posicao;
            this.Pai = pai;
            this.acaoAnterior = acaoAnterior;
            this.h = this.CalculaH();
        }

        public int CalculaH()
        {
            int result = 0;
            if (!this.EsquerdoSujo)
                result++;
            if (!this.DireitoSujo)
                result++;

            return result;
        }

        public Estado Acao(acoes acao)
        {
            switch (acao)
            {
                case acoes.MovDireita:
                    return new Estado(this.EsquerdoSujo, this.DireitoSujo, 1, this, acao);
                    break;
                case acoes.MovEsquerda:
                    return new Estado(this.EsquerdoSujo, this.DireitoSujo, 0, this, acao);
                    break;
                case acoes.Aspira:
                    if (this.Posicao == 0)
                        return new Estado(false, this.DireitoSujo, this.Posicao, this, acao);
                    else
                        return new Estado(this.EsquerdoSujo, false, this.Posicao, this, acao);
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

        public bool ExisteNoIgualMenorF(List<Estado> estados)
        {
            foreach (Estado a in estados)
            {
                if (this.Igual(a)&&this.f>=a.f)
                    return true;
            }
            return false;
        }
    }
}

