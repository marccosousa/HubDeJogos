using HubDeJogos.Controllers;
using HubDeJogos.Models.Enums;
using System.Text.Json.Serialization;

namespace HubDeJogos.Models
{
    class Jogador
    {
        public string? Login { get; private set; }
        public string? Senha { get; private set; }
        public string? Nome { get; private set; }
        public int Pontuacao { get; set; }
        public int VitoriaVelha { get; set; }
        public int VitoriaBatalha { get; set; }

        [JsonConstructor]
        public Jogador(string? login, string? senha, string? nome)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
        }

        public void PontuarJogadorVelha()
        {
            Pontuacao += 3;
            VitoriaVelha++;
        }

        public void PontuarJogadorBatalha()
        {
            VitoriaBatalha++;
            Pontuacao += 2;
        }
        public void PontuarEmpate()
        {
            Pontuacao += 1;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} \nVitórias Jogo da Velha: {VitoriaVelha} | Vitórias Batalha naval: {VitoriaBatalha} | Pontuação: ";
        }
    }
}