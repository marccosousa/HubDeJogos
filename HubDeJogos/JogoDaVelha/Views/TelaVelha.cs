using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.Models;

namespace HubDeJogos.JogoDaVelha.Views
{
    class TelaVelha
    {
        public static void ImprimeVelha(PartidaVelha p)
        {
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
            Console.WriteLine($"Vai jogar {p.Simbolo} em qual posicão? ");
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
                Console.Write( p.Mat[l, c]);
                Console.ForegroundColor = atual;
            }
            else
            {
                Console.Write(p.Mat[l, c]);
            }
        }
    }
}
