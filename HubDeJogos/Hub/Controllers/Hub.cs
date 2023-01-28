using HubDeJogos.Models;
using HubDeJogos.Exceptions;
using HubDeJogos.JogoDaVelha.Models;
using HubDeJogos.Models.Enums;
using System.Text.Json;
using HubDeJogos.Repositories;
using System.Text.Json.Serialization;
using HubDeJogos.BatalhaNaval.Models;

namespace HubDeJogos.Controllers
{
    class Hub
    {
        public List<Jogador> Jogadores { get; private set; }
        public Jogador JogadorLogado1 { get; private set; }
        public Jogador JogadorLogado2 { get; private set; }
        public Jogo JogoAtual { get; set; }
        public bool Logado { get; private set; }

        public Hub()
        {
            Jogadores = JogadoresHub.DeserializarJogadores();
            Logado = false;
            JogoAtual = new Jogo();
        }

        //Menu inicial(Cadastro e login); 
        public void RealizaCadastro(string? login, string? senha, string? nome)
        {
            ValidaCadastro(login);
            Jogador jogador = new Jogador(login, senha, nome);
            Jogadores.Add(jogador);
            JogadoresHub.SerializarJogadores(Jogadores);
            Console.WriteLine("Cadastro realizado com sucesso! \nDigite qualquer tecla para o menu anterior.");
            Console.ReadKey();
        }

        public void RealizaLogin(string? login, string? senha)
        {
            ValidaLogin(login, senha);
            if (JogadorLogado1 == null)
            {
                JogadorLogado1 = Jogadores.Find(x => x.Login == login && x.Senha == senha);
            }
            else
            {
                JogadorLogado2 = Jogadores.Find(x => x.Login == login && x.Senha == senha);
                Logado = true;
            }
            Console.WriteLine("Login realizado com sucesso! \nDigite qualquer tecla para a próxima tela");
            Console.WriteLine();
            Console.ReadKey();
        }

        private void ValidaLogin(string? login, string? senha)
        {
            bool logarConta = Jogadores.Exists(x => x.Login == login && x.Senha == senha);
            if (!logarConta)
            {
                throw new HubExceptions("Usuário ou senha inválidos");
            }

            if (Jogadores.Find(x => x.Login == login && x.Senha == senha) == JogadorLogado1)
            {
                throw new HubExceptions("Esse usuário já está logado");
            }
        }

        public void ChecarNumeroJogadores()
        {
            if (Jogadores.Count < 2)
            {
                throw new HubExceptions("Você precisa cadastrar no mínimo dois usuários para logar no Hub"); ;
            }
        }

        private void ValidaCadastro(string? login)
        {
            if (Jogadores.Exists(x => x.Login == login))
            {
                throw new HubExceptions("Esse login não está disponível, tente outro.");
            }
        }

        public void DeslogarHub()
        {
            JogadorLogado1 = null;
            JogadorLogado2 = null;
            Logado = false;
        }

        public void Ranking()
        {
            List <Jogador> rank = Jogadores.OrderByDescending(x => x.Pontuacao).ToList();  
            foreach(Jogador j in rank)
            {
                Console.WriteLine(j);
            }
        }

    }
}
