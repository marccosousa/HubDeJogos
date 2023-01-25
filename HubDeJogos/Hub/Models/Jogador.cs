namespace HubDeJogos.Models
{
    class Jogador
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }

        public Jogador(string login, string senha, string nome)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Login: {Login}"; 
        }
    }
}
