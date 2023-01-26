﻿using HubDeJogos.Controllers;
using HubDeJogos.Models;
using System.Runtime.InteropServices;

namespace HubDeJogos.BatalhaNaval.Models
{
    class PartidaBatalha
    {
        public Tabuleiro Tab { get; set; }
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public int PontuacaoJ1 { get; set; }
        public int PontuacaoJ2 { get; set; }
        public Jogador JogadorAtual { get; set; }
        public bool Finalizada { get; private set; }
        public string[,] Mat { get; private set; }

        public PartidaBatalha(Hub hub)
        {
            Tab = new Tabuleiro(8, 8);
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            JogadorAtual = Jogador1;
            PontuacaoJ1 = 0;
            PontuacaoJ2 = 0;
            Finalizada = false;
            Mat = new string[Tab.Linhas, Tab.Colunas];
            ColocarNavios();
        }

        public void RealizaJogada(char coluna, int linha)
        {
            if (VerificarNavioAbatido(coluna, linha))
            {
                Mat[8 - linha, coluna - 'a'] = "X";
                PontuarAbatidaJogador();
            }
            else
            {
                Mat[8 - linha, coluna - 'a'] = "-";
            }
            if (FimDeJogo())
            {
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

        public void PontuarAbatidaJogador()
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
    }
}
