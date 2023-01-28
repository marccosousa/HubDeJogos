using HubDeJogos.Models;
using System.Text.Json;


namespace HubDeJogos.Repositories
{
    class JogadoresHub
    {
        public static string _myFile = "jogadoreslist.json"; // Criado localmente, normalmente na pasta bin do projeto.

        public static List<Jogador> DeserializarJogadores()
        {
            try
            {
                string desJson = File.ReadAllText(_myFile);
                return JsonSerializer.Deserialize<List<Jogador>>(desJson)!;
            }
            catch (FileNotFoundException)
            {
                File.Create(_myFile);
                return new List<Jogador>();
            }  
            catch (JsonException)
            {
                return new List<Jogador>();
            }
        }

        public static void SerializarJogadores(List<Jogador> jogadores)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(jogadores, options);
            File.WriteAllText(_myFile, json);
        }
    }
}
