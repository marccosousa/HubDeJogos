using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Views;
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
            Tela.ImprimeMenuJogos(hub);

        }
    }
}