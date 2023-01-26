using HubDeJogos.Controllers;
using HubDeJogos.Models;

namespace HubDeJogos.BatalhaNaval.Models
{
    class PartidaBatalha
    {
        public Tabuleiro Tab { get; set; }
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public bool Finalizada { get; private set; }
        public string[,] Mat { get; private set; }

        public PartidaBatalha(Hub hub)
        {
            Tab = new Tabuleiro(8,8);
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            Finalizada = false;
            Mat = new string[Tab.Linhas, Tab.Colunas];
        }

        public void RealizaJogada(char coluna, int linha)
        {
            Mat[8 - linha, coluna - 'a'] = "X";
        }

    }
}
