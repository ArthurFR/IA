using System;

namespace BuscasAspirador
{

	class MainClass
	{
		public static void Main(string[] args)
		{
            Agente agente = new Agente(0);

            if (agente.Acao(acoes.MovDireita))
            {
                Console.WriteLine(agente.estado.DireitoSujo.ToString() + agente.estado.EsquerdoSujo.ToString() + agente.estado.Posicao);
                Console.ReadLine();
            }
        }
        
	}
}
