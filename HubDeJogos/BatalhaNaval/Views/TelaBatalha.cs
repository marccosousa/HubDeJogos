using HubDeJogos.BatalhaNaval.Models;
using HubDeJogos.Models;
using HubDeJogos.Views;

namespace HubDeJogos.BatalhaNaval.Views
{
    class TelaBatalha
    {
        public static void ImprimeTabuleiro(PartidaBatalha pb)
        {
            ImprimeLegendaBatalha(); 
            for (int i = 0; i < pb.Tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < pb.Tab.Colunas; j++)
                {
                    ImprimePosicoesMar(pb, i, j); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
            Console.WriteLine();
            ImprimeAbatidas(pb); 
            Console.WriteLine();
            if (!pb.Finalizada)
            {
                Console.WriteLine("Aguardando vez de " + pb.JogadorAtual.Nome);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Partida finalizada! Vitória de: " + pb.JogadorAtual.Nome);
                Console.WriteLine();
            }
        }

        public static void ImprimeJogada(PartidaBatalha pb)
        {
            Console.Write("Digite o destino da jogada: ");
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            pb.RealizaJogada(coluna, linha);
        }

        public static void ImprimeAbatidas(PartidaBatalha pb)
        {
            Console.WriteLine("Pontuação de navios abatidos: ");
            Console.WriteLine(pb.Jogador1.Nome + ": \t[" + pb.PontuacaoJ1 + "]");
            Console.WriteLine(pb.Jogador2.Nome + ": \t[" + pb.PontuacaoJ2 + "]");
        }

        public static void ImprimePosicoesMar(PartidaBatalha pb, int i, int j)
        {
            if (pb.Mat[i, j] == null || pb.Mat[i, j] == "N")
            {
                ConsoleColor atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" ~ ");
                Console.ForegroundColor = atual;
            }
            else if (pb.Mat[i, j] == "-")
            {
                ConsoleColor atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" " + pb.Mat[i, j] + " ");
                Console.ForegroundColor = atual;

            }
            else
            {
                ConsoleColor atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" " + pb.Mat[i, j] + " ");
                Console.ForegroundColor = atual;
            }
        }

        public static void ImprimeInformacoesBatalha()
        {
            Console.Clear();
            Console.WriteLine("Antes de começarmos, algumas informações: ");
            Console.WriteLine();
            Console.WriteLine("[1] Esse jogo é uma releitura do clássico jogo batalha naval.");
            Console.WriteLine("[2] Nessa versão, ambos os jogadores estarão no mesmo mar. \n[3] No mar, há 11 navios(1x1).");
            Console.WriteLine("[4] Ganha o jogador que conseguir afundar mais navios.");
            Console.WriteLine();
            Console.Write("[X] Digite qualquer tecla para ir ao jogo! ");
            Console.ReadKey();
        }

        private static void ImprimeLegendaBatalha()
        {
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============ H U B  DE  J O G O S ==============");
            Console.WriteLine("========== B A T A L H A  N A V A L ============");
            Console.ForegroundColor = atual;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~ ");
            Console.ForegroundColor = atual;
            Console.WriteLine(" (POSIÇÃO AINDA NÃO FOI ATACADA)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("- ");
            Console.ForegroundColor = atual;
            Console.WriteLine(" (POSIÇÃO ATACADA MAS NÃO ANTINGIU NAVIO)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X ");
            Console.ForegroundColor = atual;
            Console.WriteLine(" (POSIÇÃO ATACADA E NAVIO ATINGIDO)");
            Console.WriteLine();
        }
    }
}
