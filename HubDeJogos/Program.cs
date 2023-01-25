using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Views;
using HubDeJogos.JogoDaVelha.Views;
using HubDeJogos.JogoDaVelha.Models;

namespace HubDeJogos
{
    class Program
    {
        static void Main(string[] args)
        {
            Hub hub = new Hub();
            while (!hub.Logado)
            {
                Console.Clear();
                Tela.ImprimeMenu(hub);
            }
            Console.Clear();
            switch (Tela.ImprimeMenuJogos(hub))
            {
                case "1":
                    PartidaVelha p = new PartidaVelha(hub);
                    Console.Clear();
                    TelaVelha.ImprimeVelha(p);
                    TelaVelha.ImprimeJogada(p);
                    Console.Clear();
                    TelaVelha.ImprimeVelha(p);
                    break;
                case "2":
                    Console.WriteLine("Batalha naval aqui");
                    break;
                default:
                    Console.WriteLine("Opcao inválida");
                    break;
            }

        }
    }
}