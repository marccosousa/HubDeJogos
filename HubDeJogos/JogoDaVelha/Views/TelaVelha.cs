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
                    Console.Write("|  " + p.Mat[L, C]);
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
                Console.WriteLine("Vitória: " + p.JogadorAtual.Nome + " - " + p.Simbolo);
            }
        }

        public static void ImprimeJogada(PartidaVelha p)
        {
            Console.WriteLine($"Vai jogar {p.Simbolo} em qual posicão? ");
            string posicao = Console.ReadLine();
            p.RealizaJogada(posicao);
        }
    }
}
