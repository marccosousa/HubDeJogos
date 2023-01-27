using HubDeJogos.BatalhaNaval.Models;
using HubDeJogos.Models;

namespace HubDeJogos.BatalhaNaval.Views
{
    class TelaBatalha
    {
        public static void ImprimeTabuleiro(PartidaBatalha pb)
        {
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
            Console.WriteLine($"{pb.Jogador1.Nome}  vs  {pb.Jogador2.Nome}");
            if (!pb.Finalizada)
            {
                Console.WriteLine("Aguardando vez do " + pb.JogadorAtual.Nome);
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
            Console.WriteLine("Digite o destino da jogada: ");
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            pb.RealizaJogada(coluna, linha);
        }

        public static void ImprimeAbatidas(PartidaBatalha pb)
        {
            Console.WriteLine("Pontuação de navios abatidos: ");
            Console.WriteLine();
            Console.WriteLine(pb.Jogador1.Nome + ": [" + pb.PontuacaoJ1 + "]");
            Console.WriteLine(pb.Jogador2.Nome + ": [" + pb.PontuacaoJ2 + "]");
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
    }
}
