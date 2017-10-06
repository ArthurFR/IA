using System;

namespace BuscasAspirador
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Estado objetivo;
            string opcao;

            string esquerdo, direito;
            int posicao;
            Console.WriteLine("**Informe a posição inicial do Agente:**");
            //Console.WriteLine("**Esquerdo limpo? true/false**");
            esquerdo = System.Console.ReadLine();
            //Console.WriteLine("**Direito limpo? true/false**");
            direito = System.Console.ReadLine();
            //Console.WriteLine("**Posição?esquerdo =1**");
            //Console.WriteLine("**Esquerdo = 0**");
            //Console.WriteLine("**Direito = 1**");
            posicao = Convert.ToInt32(Console.ReadLine());

            Agente agente = new Agente(String.Compare(esquerdo, "sujo", true) == 0 ? true : false,
                                        String.Compare(direito, "sujo", true) == 0 ? true : false,
                                        posicao);

            try
            {
                do
                {
                    Menu(agente);

                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1"://BuscaLargura
                            objetivo = agente.BuscaLargura();
                            Console.WriteLine(MostraCaminho(objetivo, 0));
                            break;
                        case "2"://BuscaProfunda
                            objetivo = agente.BuscaProfundidade();
                            Console.WriteLine(MostraCaminho(objetivo, 0));
                            break;
                        case "3"://BuscaEstrela
                            objetivo = agente.BuscaEstrela();
                            Console.WriteLine(MostraCaminho(objetivo, 0));
                            break;

                    } //Fim switch
                    Console.WriteLine("\n");
                } while (opcao != "0");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void Menu(Agente agente)
        {
            Console.WriteLine("Estado Inicial: "+ agente.ImprimeEstadoInicial() + "\n");
            Console.WriteLine("**MENU**");
            Console.WriteLine("1. BuscaLargura");
            Console.WriteLine("2. BuscaProfunda");
            Console.WriteLine("3. BuscaEstrela");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Opcao: ");
        }

        public static string MostraCaminho(Estado objetivo, int profundidade)
        {

            if (objetivo == null)
                return "Caminho para o estado objetivo não encontrado.";

            if (objetivo.Pai == null)
                return "Profundidade:  " + profundidade + "\nCaminho: ";

            profundidade++;
            return MostraCaminho(objetivo.Pai, profundidade) + objetivo.acaoAnterior + " ,";
        }

    }
}