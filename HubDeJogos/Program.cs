using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Views;
using HubDeJogos.JogoDaVelha.Views;
using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.JogoDaVelha;
using HubDeJogos.BatalhaNaval.Views;
using HubDeJogos.BatalhaNaval.Models;
using HubDeJogos.BatalhaNaval;

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
                while (hub.Logado)
                {
                    Console.Clear();
                    Tela.ImprimeMenuJogos(hub);
                }
            }            
        }
    }
}