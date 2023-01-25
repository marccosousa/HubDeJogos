using HubDeJogos.Controllers;
using HubDeJogos.Models;
namespace HubDeJogos.JogoDaVelha.Models
{
    class PartidaVelha
    {
        public Tabuleiro Tab { get; set; }
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public string Simbolo { get; set; }
        public bool Terminada { get; set; }
        public string[,] Mat { get; set; }

        public PartidaVelha(Hub hub)
        {
            Tab = new Tabuleiro(3, 3);
            Mat = new string[Tab.Linhas, Tab.Colunas];
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            Simbolo = "X"; 
            Terminada = false;
            OrganizaVelha(); 
        }

        public void RealizaJogada(string posicao)
        {
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    if (Mat[L, C] == posicao)
                    {
                        Mat[L, C] = Simbolo;
                    }
                }
            }
            MudarJogador(); 
        }

        private void MudarJogador()
        {
            if (Simbolo == "X")
            {
                Simbolo = "O";
            }
            else
            {
                Simbolo = "X";
            }
        }

        private void OrganizaVelha()
        {
            int cont = 1;
            for (int L = 0; L < Tab.Linhas; L++) // Colocando posições de 1 a 9 no jogo; 
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    Mat[L, C] = cont.ToString();
                    cont++;
                }
            }
        }
    }    
}
