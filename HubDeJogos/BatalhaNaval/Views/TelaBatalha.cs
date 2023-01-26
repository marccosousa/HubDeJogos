using HubDeJogos.BatalhaNaval.Models;
using HubDeJogos.Models;

namespace HubDeJogos.BatalhaNaval.Views
{
    class TelaBatalha
    {
        public static void ImprimeTabuleiro(PartidaBatalha pb)
        {
            for (int i = 0; i < pb.Tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < pb.Tab.Colunas; j++)
                {
                    if (pb.Mat[i, j] == null)
                    {
                        Console.Write(" ~ ");
                    }
                    else
                    {
                        Console.Write(" " + pb.Mat[i, j] + " ");

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        public static void ImprimeJogada(PartidaBatalha pb)
        {
            Console.WriteLine("Digite o destino da jogada: ");
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            pb.RealizaJogada(coluna, linha);
        }
    }
}
