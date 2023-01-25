using HubDeJogos.Controllers;
using HubDeJogos.Models;
namespace HubDeJogos.JogoDaVelha.Models
{
    class PartidaVelha
    {
        public Tabuleiro Tab { get; set; }
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public Jogador JogadorAtual {get; set;}
        public string Simbolo { get; set; }
        public bool Finalizada { get; set; }
        public string[,] Mat { get; set; }

        public PartidaVelha(Hub hub)
        {
            Tab = new Tabuleiro(3, 3);
            Mat = new string[Tab.Linhas, Tab.Colunas];
            Jogador1 = hub.JogadorLogado1;
            Jogador2 = hub.JogadorLogado2;
            JogadorAtual = Jogador1; 
            Simbolo = "X"; 
            Finalizada = false;
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
            MudarJogador(); 
        }

        public void ValidaJogada(string posicao)
        {
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
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

        public void FimDeJogo()
        {
            // Se o jogo terminar em alguma linha: 
            for (int L = 0; L < 3; L++)
            {
                if (Mat[L, 0] == Mat[L, 1] && Mat[L, 1] == Mat[L, 2])
                {
                    Finalizada = true;
                }
            }
            // Se o jogo terminar em alguma coluna: 
            for (int C = 0; C < 3; C++)
            {
                if (Mat[0, C] == Mat[1, C] && Mat[1, C] == Mat[2, C])
                {
                    Finalizada = true;
                }
            }

            // Se o jogo terminar em alguma diagonal: Diagonal principal
            if (Mat[0, 0] == Mat[1, 1] && Mat[1, 1] == Mat[2, 2])
            {
                Finalizada = true;
            }
            // diagonal secundária
            if (Mat[0, 2] == Mat[1, 1] && Mat[1, 1] == Mat[2, 0])
            {
                Finalizada = true;
            }
            
            // Quando o jogo termina na última rodada, ele contabiliza a vitória e a velha. Quando termina em velha, é velha mesmo.
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
                Finalizada = true;
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
