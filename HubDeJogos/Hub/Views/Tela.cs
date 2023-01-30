using HubDeJogos.Controllers;
using HubDeJogos.Exceptions;
using HubDeJogos.Models;
using HubDeJogos.Models.Enums;
using HubDeJogos.JogoDaVelha;
using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.JogoDaVelha.Views;
using HubDeJogos.BatalhaNaval.Models;
using HubDeJogos.BatalhaNaval.Views;
using HubDeJogos.BatalhaNaval;

namespace HubDeJogos.Views
{
    class Tela
    {
        //Menu inicial
        public static void ImprimeMenu(Hub hub)
        {
            Console.WriteLine("[1] - Logar no Hub de Jogos.");
            Console.WriteLine("[2] - Cadastrar novo jogador.");
            Console.WriteLine("[3] - Mostrar ranking de jogadores.");
            Console.WriteLine("[4] - Finalizar Hub.");
            Console.Write("Digite a sua opção: ");
            string? opcao = Console.ReadLine();
            try
            {

                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("Opção inválida.");
                        break;
                    case "1":
                        hub.ChecarNumeroJogadores();
                        do
                        {
                            ImprimeLogin(hub);
                        } while (!hub.Logado);
                        break;
                    case "2":
                        ImprimeCadastro(hub);
                        break;
                    case "3":
                        ImprimeRanking(hub);                        
                        break;
                    case "4":
                        Console.WriteLine("Obrigado por ser divertir conosco, até a próxima");
                        Environment.Exit(0);
                        break; 
                    default:
                        Console.WriteLine("Opção inválida! Digite novamente.");
                        break;
                }
            }
            catch (HubExceptions e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Digite qualquer tecla para continuar no menu");
                Console.ReadKey();
            }
        }

        public static void ImprimeLogin(Hub hub)
        {
            Console.Clear();
            Console.WriteLine("===== Login =====");
            Console.WriteLine("Digite seu login: ");
            string? login = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string? senha = Console.ReadLine();
            try
            {
                hub.RealizaLogin(login, senha);
            }
            catch (HubExceptions e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Digite qualquer tecla para tentar novamente: ");
                Console.ReadKey();
            }

        }

        public static void ImprimeCadastro(Hub hub)
        {
            Console.Clear();
            Console.WriteLine("===== CADASTRO =====");
            Console.WriteLine("Digite o login que deseja: ");
            string? login = Console.ReadLine();
            Console.WriteLine("Digite a senha que deseja: ");
            string? senha = Console.ReadLine();
            Console.WriteLine("Agora digite o seu nome: ");
            string? nome = Console.ReadLine();
            try
            {
                hub.RealizaCadastro(login, senha, nome);
            }
            catch (HubExceptions e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Digite qualquer tecla para tentar novamente.");
                Console.ReadKey();
            }
        }

        public static void ImprimeRanking(Hub hub)
        {
            Console.Clear(); 
            Console.WriteLine("===== RANKING DE JOGADORES ====");
            List<Jogador> rank = hub.Jogadores.OrderByDescending(x => x.Pontuacao).ToList();
            Console.WriteLine();
            foreach (Jogador j in rank)
            {
                Console.WriteLine(j);
                Console.WriteLine();
            }
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu.");
            Console.ReadKey(); 
        }

        // Menu de jogos

        public static void ImprimeMenuJogos(Hub hub)
        {
            Console.WriteLine("===== HUB DE JOGOS =====");
            Console.WriteLine();
            Console.WriteLine($"Olá {hub.JogadorLogado1.Nome} e {hub.JogadorLogado2.Nome}! Bem-vindos!");
            Console.WriteLine("Qual jogo vocês querem jogar hoje? ");
            Console.WriteLine("[1] - Jogo da Velha: ");
            Console.WriteLine("[2] - Batalha Naval: ");
            Console.WriteLine("[3] - Deslogar e voltar ao menu inicial.");
            Console.Write("Digite a sua opção: ");
            string? opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    int? continuar = 1;
                    hub.JogoAtual = Jogo.JogoDaVelha; 
                    do
                    {
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
                        Console.WriteLine();
                        Console.WriteLine("Deseja jogar uma nova partida? 1 - Sim / 2 - Voltar para o menu de jogos.");
                        continuar = int.Parse(Console.ReadLine()); 
                    } while (continuar == 1);
                    Console.Clear(); 
                    ImprimeMenuJogos(hub); 
                    break;
                
                case "2":
                    continuar = 1;
                    hub.JogoAtual = Jogo.BatalhaNaval;
                    do
                    {
                        PartidaBatalha pb = new PartidaBatalha(hub);
                        do
                        {
                            try
                            {
                                Console.Clear();
                                TelaBatalha.ImprimeTabuleiro(pb);
                                TelaBatalha.ImprimeJogada(pb);
                            }
                            catch (BatalhaException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Digite qualquer tecla para tentar novamente");
                                Console.ReadKey();
                            }
                        }
                        while (!pb.Finalizada);
                        Console.Clear();
                        TelaBatalha.ImprimeTabuleiro(pb);
                        Console.WriteLine();
                        Console.WriteLine("Deseja jogar uma nova partida? 1 - Sim / 2 - Voltar para o menu de jogos.");
                        continuar = int.Parse(Console.ReadLine());
                    }
                    while (continuar == 1); 
                    Console.Clear();
                    ImprimeMenuJogos(hub);
                    break;
                case "3":
                    Console.WriteLine("Vocês deslogaram do Hub! Até a próxima! \nDigite qualquer tecla para ir para o menu inicial");
                    Console.ReadKey(); 
                    Console.Clear();
                    hub.DeslogarHub();
                    ImprimeMenu(hub); 
                    break; 
                default:
                    Console.WriteLine("Opcao inválida. Digite qualquer tecla para tentar novamente!");
                    Console.ReadKey(); 
                    break;
            }
        }
    }
}
