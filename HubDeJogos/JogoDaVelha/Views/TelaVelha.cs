using HubDeJogos.JogoDaVelha.Models;

namespace HubDeJogos.JogoDaVelha.Views
{
    class TelaVelha
    {
        public static void ImprimeVelha(PartidaVelha p)
        {
            ImprimeLegendaVelha(); 
            Console.WriteLine("+---+---+---+");
            for (int L = 0; L < p.Tab.Linhas; L++)
            {
                for (int C = 0; C < p.Tab.Colunas; C++)
                {
                    Console.Write("|  ");
                    ImprimeSimbolo(p, L, C); 
                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("+---+---+---+");
            }

            Console.WriteLine();
            Console.WriteLine("Turno: " + p.Turno);
            Console.WriteLine();
            Console.WriteLine($"{p.Jogador1.Nome} - X vs O - {p.Jogador2.Nome}");
            if (!p.Finalizada)
            {
                Console.WriteLine("Aguardando vez do " + p.JogadorAtual.Nome + " - " + p.Simbolo);
                Console.WriteLine();
            }
            else
            {
                if(!p.Velha)
                {
                    Console.WriteLine("Vitória: " + p.JogadorAtual.Nome + " - " + p.Simbolo);
                }
                else
                {
                    Console.WriteLine("Deu velha :("); 
                }
            }
        }

        public static void ImprimeJogada(PartidaVelha p)
        {
            Console.Write($"Vai jogar {p.Simbolo} em qual posicão? ");
            string posicao = Console.ReadLine();
            p.RealizaJogada(posicao);
        }

        public static void ImprimeSimbolo(PartidaVelha p, int l, int c)
        {
            if (p.Mat[l, c] == "X")
            {
                ConsoleColor atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(p.Mat[l, c]);
                Console.ForegroundColor = atual;
            }
            else if (p.Mat[l, c] == "O")
            {
                ConsoleColor atual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(p.Mat[l, c]);
                Console.ForegroundColor = atual;
            }
            else
            {
                Console.Write(p.Mat[l, c]);
            }
        }

        public static void ImprimeLegendaVelha()
        {
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============ H U B  DE  J O G O S ==============");
            Console.WriteLine("========== J O G O  DA  V E L H A ==============");
            Console.ForegroundColor = atual;
            Console.WriteLine();
        }
    }
}
