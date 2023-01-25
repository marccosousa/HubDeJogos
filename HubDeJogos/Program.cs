using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Views;
using HubDeJogos.JogoDaVelha.Views;
using HubDeJogos.JogoDaVelha.Models;
using System.Linq.Expressions;
using HubDeJogos.JogoDaVelha;

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
                    while (!p.Finalizada)
                    {
                        try
                        {
                            Console.Clear();
                            TelaVelha.ImprimeVelha(p);
                            TelaVelha.ImprimeJogada(p);
                            p.FimDeJogo();
                        }
                        catch(PartidaVelhaException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Digite qualquer tecla para tentar novamente");
                            Console.ReadKey();
                        }
                    }
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