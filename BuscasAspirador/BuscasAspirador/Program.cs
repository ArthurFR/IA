using System;

namespace BuscasAspirador
{

	class MainClass
	{
		public static void Main(string[] args)
		{
            Estado objetivo;
            Agente agente = new Agente(1);
            objetivo = agente.BuscaEstrela();
            Console.WriteLine(MostraCaminho(objetivo,0));
            Console.ReadLine();

            agente = new Agente(1);
            objetivo = agente.BuscaLargura();
            Console.WriteLine(MostraCaminho(objetivo, 0));
            Console.ReadLine();
        }


        public static string MostraCaminho(Estado objetivo, int profundidade)
        {
            
            if (objetivo == null)
                return "Caminho para o estado objetivo não encontrado.";

            if (objetivo.Pai == null)
                return "Profundidade:  "+ profundidade + ", Caminho: ";

            profundidade++;
            return MostraCaminho(objetivo.Pai, profundidade) + objetivo.acaoAnterior + " ,";
        }
        
	}
}
