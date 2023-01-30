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
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======= H U B  DE  J O G O S ======= ");
            Console.WriteLine("====== M E N U  I N I C I A L ======");
            Console.ForegroundColor = atual;
            Console.WriteLine();
            Console.WriteLine("[1] - Logar no Hub de Jogos.");
            Console.WriteLine("[2] - Cadastrar novo jogador.");
            Console.WriteLine("[3] - Mostrar ranking de jogadores.");
            Console.WriteLine("[4] - Finalizar Hub.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write("[X] - Digite a opção desejada: ");
            string? opcao = Console.ReadLine();
            Console.ForegroundColor = atual;
            Console.WriteLine();
            try
            {

                switch (opcao)
                {
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
                        Console.WriteLine("Opção inválida! Digite novamente qualquer tecla para tentar novamente.");
                        Console.ReadKey();
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
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================ H U B  DE  J O G O S ==============");
            Console.WriteLine("================     L O G I N     =================");
            Console.ForegroundColor = atual;
            Console.WriteLine();
            Console.Write("OBS: \nPRIMEIRO LOGIN = JOGADOR 1 \nSEGUNDO  LOGIN = JOGADOR 2\n");
            Console.WriteLine();
            Console.Write("Digite seu login: ");
            Console.ForegroundColor = ConsoleColor.Yellow; 
            string? login = Console.ReadLine();
            Console.ForegroundColor = atual;
            Console.Write("Digite sua senha: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string? senha = Console.ReadLine();
            Console.ForegroundColor = atual;
            try
            {
                hub.RealizaLogin(login, senha);
                Console.WriteLine();
                Console.Write($"Login realizado com sucesso! \nDigite qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch (HubExceptions e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.Write("Digite qualquer tecla para tentar novamente: ");
                Console.ReadKey();
            }

        }

        public static void ImprimeCadastro(Hub hub)
        {
            Console.Clear();
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================ H U B  DE  J O G O S ==============");
            Console.WriteLine("====== C A D A S T R O  DE  J O G A D O R E S ======");
            Console.ForegroundColor = atual;
            Console.WriteLine();
            Console.Write("Digite o login que deseja: ");
            string? login = Console.ReadLine();
            Console.Write("Digite a senha que deseja: ");
            string? senha = Console.ReadLine();
            Console.Write("Agora digite o seu nome: ");
            string? nome = Console.ReadLine();
            try
            {
                hub.RealizaCadastro(login, senha, nome);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Bem-vindo, {nome}! ");
                Console.WriteLine("Cadastro realizado com sucesso!");
                Console.ForegroundColor = atual;
                Console.Write("\nDigite qualquer tecla para o menu anterior.");
                Console.ReadKey();
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
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t================ H U B  DE  J O G O S ================");
            Console.ForegroundColor = atual; 
            Console.WriteLine();
            ImprimeInformacoesRank(); 
            List<Jogador> rank = hub.Jogadores.OrderByDescending(x => x.Pontuacao).ToList();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t==========  R A N K I N G ========== ");
            Console.WriteLine();
            foreach (Jogador j in rank)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(j.Pontuacao);
                Console.ForegroundColor = atual;
                Console.WriteLine();
            }
            Console.ForegroundColor = atual;
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu.");
            Console.ReadKey();
        }

        private static void ImprimeInformacoesRank()
        {
            Console.WriteLine("JOGO DA VELHA: \nCada vitória equivale a +3 pontos no ranking! ");
            Console.WriteLine("Em caso de velha, ambos os jogadores ganham apenas +1 ponto no ranking.");
            Console.WriteLine();
            Console.WriteLine("BATALHA NAVAL: \nCada vitória equivale a +2 pontos no ranking!");
        }

        // Menu de jogos

        public static void ImprimeMenuJogos(Hub hub)
        {
            ConsoleColor atual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================ H U B  DE  J O G O S ==============");
            Console.WriteLine("================     J O G O S        ==============");
            Console.ForegroundColor = atual;
            Console.WriteLine();
            Console.WriteLine($"Olá, {hub.JogadorLogado1.Nome} e {hub.JogadorLogado2.Nome}! Bem-vindos!");
            Console.WriteLine();
            Console.WriteLine("Qual jogo vocês querem jogar hoje? ");
            Console.WriteLine();
            Console.WriteLine("[1] - Jogo da Velha");
            Console.WriteLine("[2] - Batalha Naval");
            Console.WriteLine("[3] - Deslogar e voltar ao menu inicial.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write("[X] - Digite a opção desejada: ");
            string? opcao = Console.ReadLine();
            Console.ForegroundColor = atual;
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
                        Console.Write("Deseja jogar uma nova partida? \n[1] - Sim \n[2] - Voltar para o menu de jogos.");
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
                        TelaBatalha.ImprimeInformacoesBatalha(); 
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
                        Console.Write("Deseja jogar uma nova partida? \n[1] - Sim \n[2] - Voltar para o menu de jogos.");
                        continuar = int.Parse(Console.ReadLine());
                    }
                    while (continuar == 1);
                    Console.Clear();
                    ImprimeMenuJogos(hub);
                    break;
                case "3":
                    Console.WriteLine();
                    Console.Write("Vocês deslogaram do Hub! Até a próxima! \nDigite qualquer tecla para ir para o menu inicial");
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
