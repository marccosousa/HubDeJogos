using HubDeJogos.Controllers;
using HubDeJogos.Models.Enums; 

namespace HubDeJogos.Models
{
    class Jogador
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public Hub Hub { get; private set; }
        public int Pontuacao { get; private set; }

        public Jogador(string login, string senha, string nome, Hub hub)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Pontuacao = 0;
            Hub = hub;
        }

        public void AdicionarPontuacao(Jogador atual)
        {
            foreach (Jogador x in Hub.Jogadores)
            {
                if (x.Equals(atual))
                {
                    if (Hub.JogoAtual == Jogo.JogoDaVelha)
                    {
                        x.Pontuacao += 3;
                    }
                    else
                    {
                        x.Pontuacao += 5;
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Nome: {Nome} | Login: {Login} | Pontuação: {Pontuacao}"; 
        }
    }
}
