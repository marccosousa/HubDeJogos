using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Models.Enums;
using HubDeJogos.Repositories;
using System.Xml.Linq;

namespace HubDeJogos.JogoDaVelha.Models
{
    class PartidaVelha
    {
        public Tabuleiro Tab { get; private set; }
        public Jogador Jogador1 { get; private set; }
        public Jogador Jogador2 { get; private set; }
        public Jogador JogadorAtual { get; private set; }
        public Jogo Jogo { get; private set; }
        public Hub Hub { get; private set; }
        public string Simbolo { get; private set; }
        public bool Finalizada { get; private set; }
        public bool Velha { get; private set; }
        public string[,] Mat { get; private set; }
        public int Turno { get; private set; }

        public PartidaVelha(Hub hub)
        {
            Tab = new Tabuleiro(3, 3);
            Mat = new string[Tab.Linhas, Tab.Colunas];
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            Hub = hub; 
            JogadorAtual = Jogador1;
            Jogo = Jogo.JogoDaVelha; 
            Simbolo = "X";
            Finalizada = false;
            Turno = 1;
            OrganizaVelha();
        }

        public void RealizaJogada(string posicao)
        {
            ValidaJogada(posicao);
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
            if (FimDeJogo())
            {
                ComunicarVitoria();
                return;
            }
            MudarJogador();
            Turno++;
        }

        private void ValidaJogada(string posicao)
        {
            int aux;
            int.TryParse(posicao, out aux);
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    if (aux < 1 || aux > 9)
                    {
                        throw new PartidaVelhaException("Posicao inválida! Tente novamente");
                    }
                    if (Mat[L, C] == posicao)
                    {
                        return;
                    }                    
                }
            }
            throw new PartidaVelhaException("Já existe um símbolo nessa posição!");

        }

        private void MudarJogador()
        {
            if (Simbolo == "X")
            {
                Simbolo = "O";
                JogadorAtual = Jogador2;
            }
            else
            {
                Simbolo = "X";
                JogadorAtual = Jogador1;
            }
        }

        private bool FimDeJogo()
        {
            // Se o jogo terminar em alguma linha:
            for (int L = 0; L < 3; L++)
            {
                if (Mat[L, 0] == Mat[L, 1] && Mat[L, 1] == Mat[L, 2])
                {
                    Finalizada = true;
                    return true;
                }
            }
            // Se o jogo terminar em alguma coluna: 
            for (int C = 0; C < 3; C++)
            {
                if (Mat[0, C] == Mat[1, C] && Mat[1, C] == Mat[2, C])
                {
                    Finalizada = true;
                    return true;
                }
            }

            // Se o jogo terminar em alguma diagonal: Diagonal principal
            if (Mat[0, 0] == Mat[1, 1] && Mat[1, 1] == Mat[2, 2])
            {
                Finalizada = true;
                return true;
            }
            // diagonal secundária
            if (Mat[0, 2] == Mat[1, 1] && Mat[1, 1] == Mat[2, 0])
            {
                Finalizada = true;
                return true;
            }
            int contVelha = 0;
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    if (Mat[L, C] != "X" && Mat[L, C] != "O")
                    {
                        contVelha++;
                    }
                }
            }

            if (contVelha == 0)
            {
                Velha = true; 
                Finalizada = true;
                return true;
            }
            return false;
        }

        private void ComunicarVitoria()
        {
            foreach (Jogador j in Hub.Jogadores)
            {
                if (j.Equals(JogadorAtual))
                {
                    j.PontuarJogador();
                    JogadoresHub.SerializarJogadores(Hub.Jogadores);
                }
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
