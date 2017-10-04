using System;

namespace BuscasAspirador
{

	class MainClass
	{
		public static void Main(string[] args)
		{
            Estado objetivo;
            Agente agente = new Agente(0);
            objetivo = agente.BuscaLargura();
            Console.WriteLine(MostraCaminho(objetivo));
            Console.ReadLine();
        }


        public static string MostraCaminho(Estado objetivo)
        {
            if (objetivo == null)
                return "Caminho para o estado objetivo não encontrado.";

            if (objetivo.Pai == null)
                return "Caminho: ";

            return MostraCaminho(objetivo.Pai) + objetivo.acaoAnterior + " ,";
        }
        
	}
}
