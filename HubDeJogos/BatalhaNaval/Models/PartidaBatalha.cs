using HubDeJogos.Controllers;
using HubDeJogos.Models;
using HubDeJogos.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubDeJogos.BatalhaNaval.Models
{
    class PartidaBatalha
    {
        public Tabuleiro Tab { get; private set; }
        public Jogador Jogador1 { get; private set; }
        public Jogador Jogador2 { get; private set; }
        public int PontuacaoJ1 { get; private set; }
        public int PontuacaoJ2 { get; private set; }
        public Jogador JogadorAtual { get; private set; }
        public bool Finalizada { get; private set; }
        public string[,] Mat { get; private set; }
        public Hub Hub { get; set; }

        public PartidaBatalha(Hub hub)
        {
            Tab = new Tabuleiro(8, 8);
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            Hub = hub;
            JogadorAtual = Jogador1;
            PontuacaoJ1 = 0;
            PontuacaoJ2 = 0;
            Finalizada = false;
            Mat = new string[Tab.Linhas, Tab.Colunas];
            ColocarNavios();
        }

        public void RealizaJogada(char coluna, int linha)
        {
            ValidarJogada(coluna, linha); 
            if (VerificarNavioAbatido(coluna, linha))
            {
                Mat[8 - linha, coluna - 'a'] = "X";
                PontuarAbateJogador();
            }
            else
            {
                Mat[8 - linha, coluna - 'a'] = "-";
            }
            if (FimDeJogo())
            {
                ComunicarVitoria();
                return;
            }
            MudarJogador();
        }

        public void ColocarNavios()
        {
            Mat[0, 0] = "N";
            Mat[1, 1] = "N";
            Mat[2, 2] = "N";
            Mat[3, 3] = "N";
            Mat[4, 4] = "N";
            Mat[5, 5] = "N";
            Mat[6, 6] = "N";
            Mat[7, 7] = "N";
            Mat[0, 1] = "N";
            Mat[1, 2] = "N";
            Mat[2, 3] = "N";
        }

        public void ValidarJogada(char coluna, int linha)
        {
            if (coluna - 'a' > 7 || 8 - linha > 7 || coluna - 'a' < 0 || 8 - linha < 0)
            {
                throw new BatalhaException("Posição inválida");
            }
            if (Mat[8 - linha, coluna - 'a'] == "X")
            {
                throw new BatalhaException("O navio dessa posição já foi atingido.");
            }
            if (Mat[8 - linha, coluna - 'a'] == "-")
            {
                throw new BatalhaException("Essa posição já foi atacada e não há navio");
            }
        }
        public bool VerificarNavioAbatido(char coluna, int linha)
        {
            if (Mat[8 - linha, coluna - 'a'] == "N")
            {
                return true;
            }
            return false;
        }

        public void MudarJogador()
        {
            if (JogadorAtual == Jogador1)
            {
                JogadorAtual = Jogador2;
            }
            else
            {
                JogadorAtual = Jogador1;
            }
        }

        public void PontuarAbateJogador()
        {
            if (JogadorAtual.Equals(Jogador1))
            {
                PontuacaoJ1++;
            }
            else
            {
                PontuacaoJ2++;
            }
        }

        public bool FimDeJogo()
        {
            if (PontuacaoJ1 == 6 || PontuacaoJ2 == 6)
            {
                if (PontuacaoJ1 == 6)
                {
                    JogadorAtual = Jogador1;
                }
                else
                {
                    JogadorAtual = Jogador2;
                }
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
    }
}
