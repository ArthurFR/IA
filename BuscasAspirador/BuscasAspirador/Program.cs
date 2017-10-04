using System;

namespace BuscasAspirador
{

	class MainClass
	{
		public static void Main(string[] args)
		{
            Agente agente = new Agente(0);
            agente.BuscaLargura();
            Console.ReadLine();
        }
        
	}
}
