using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Views;
using HubDeJogos.JogoDaVelha.Views;
using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.JogoDaVelha;
using HubDeJogos.BatalhaNaval.Views;
using HubDeJogos.BatalhaNaval.Models;

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
                    do
                    {
                        try
                        {
                            Console.Clear();
                            TelaVelha.ImprimeVelha(p);
                            TelaVelha.ImprimeJogada(p);
                        }
                        catch (PartidaVelhaException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Digite qualquer tecla para tentar novamente");
                            Console.ReadKey();
                        }
                    }
                    while (!p.Finalizada);
                    Console.Clear();
                    TelaVelha.ImprimeVelha(p);
                    break;
                case "2":
                    PartidaBatalha pb = new PartidaBatalha(hub);
                    do
                    {
                        Console.Clear();
                        TelaBatalha.ImprimeTabuleiro(pb);
                        TelaBatalha.ImprimeJogada(pb);
                    }
                    while (!pb.Finalizada); 
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opcao inválida");
                    break;
            }

        }
    }
}