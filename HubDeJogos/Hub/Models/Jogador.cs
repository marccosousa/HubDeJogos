using HubDeJogos.Controllers;
using HubDeJogos.Models.Enums;
using System.Text.Json.Serialization;

namespace HubDeJogos.Models
{
    class Jogador
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public int Pontuacao { get; set; }

        public Jogador(string login, string senha, string nome)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
        }
        
        public void PontuarJogador()
        {
            Pontuacao += 3;
        }
        public void PontuarEmpate()
        {
            Pontuacao += 1;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Login: {Login} | Pontuação: {Pontuacao}"; 
        }
    }
}
