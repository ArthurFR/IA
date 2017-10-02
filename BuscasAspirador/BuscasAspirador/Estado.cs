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
        public int Posicao { get; set; }

        public Estado(int posicao)
        {
            EsquerdoSujo = true;
            DireitoSujo = true;
            this.Posicao = posicao;
        }


        public bool Acao(acoes acao)
        {
            switch (acao)
            {
                case acoes.MovDireita:
                    this.Posicao = 1;
                    break;
                case acoes.MovEsquerda:
                    this.Posicao = 0;
                    break;
                case acoes.Aspira:
                    if (this.Posicao == 0)
                    {
                        EsquerdoSujo = false;
                    }else
                    {
                        DireitoSujo = false;
                    }
                    break;

                default:
                    return false;
            }

            return true;
        }
    }
}
