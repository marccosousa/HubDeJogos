﻿using HubDeJogos.Controllers;
using HubDeJogos.Exceptions;
using HubDeJogos.Models;
using HubDeJogos.JogoDaVelha;
using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.JogoDaVelha.Views;

namespace HubDeJogos.Views
{
    class Tela
    {
        //Menu inicial
        public static void ImprimeMenu(Hub hub)
        {
            Console.WriteLine("[1] - Logar no Hub de Jogos.");
            Console.WriteLine("[2] - Cadastrar novo jogador.");
            Console.WriteLine("[3] - Mostrar jogadores.");
            Console.Write("Digite a sua opção: ");
            string opcao = Console.ReadLine();
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
                        ImprimeJogadores(hub);
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
            string login = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
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
            string login = Console.ReadLine();
            Console.WriteLine("Digite a senha que deseja: ");
            string senha = Console.ReadLine();
            Console.WriteLine("Agora digite o seu nome: ");
            string nome = Console.ReadLine();
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

        public static void ImprimeJogadores(Hub hub)
        {
            Console.Clear();
            Console.WriteLine("Jogadores cadastrados: ");
            Console.WriteLine();
            foreach (Jogador j in hub.Jogadores)
            {
                Console.WriteLine(j);
                Console.WriteLine();
            }
            Console.WriteLine("Pressione qualquer tecla para o menu anterior.");
            Console.ReadKey();
        }

        // Menu de jogos

        public static string ImprimeMenuJogos(Hub hub)
        {
            Console.WriteLine("===== HUB DE JOGOS =====");
            Console.WriteLine();
            Console.WriteLine($"Olá {hub.JogadorLogado1.Nome} e {hub.JogadorLogado2.Nome}! Bem-vindos!");
            Console.WriteLine("Qual jogo vocês querem jogar hoje? ");
            Console.WriteLine("[1] - Jogo da Velha: ");
            Console.WriteLine("[2] - Batalha Naval: ");
            Console.Write("Digite a sua opção: ");
            string opcao = Console.ReadLine();
            return opcao; 
        }
    }
}
