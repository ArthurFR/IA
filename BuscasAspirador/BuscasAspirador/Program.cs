using System;

namespace BuscasAspirador
{

	class MainClass
	{
		public static void Main(string[] args)
		{
            Estado objetivo;
            string opcao;
            Agente agente = new Agente(1);
                
            try
            {
                do
                {
                    Menu();

                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1"://BuscaLargura
                            objetivo = agente.BuscaLargura();
                            Console.WriteLine(MostraCaminho(objetivo, 0));
                            break;
                        case "2"://BuscaProfunda
                            //objetivo = agente.BuscaProfunda();
                            //Console.WriteLine(MostraCaminho(objetivo));
                            break;
                        case "3"://BuscaEstrela
                                 objetivo = agente.BuscaEstrela();
                                 Console.WriteLine(MostraCaminho(objetivo,0));
                            break;

                    } //Fim switch
                } while (opcao != "0");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("**MENU**");
            Console.WriteLine("1. BuscaLargura");
            Console.WriteLine("2. BuscaProfunda");
            Console.WriteLine("3. Altera BuscaEstrela");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Opcao: ");
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