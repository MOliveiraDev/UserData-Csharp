using System;
using System.IO;

class UsersdataStorage
{
    static void Main()
    {
        while (true)
        {

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Registrar novo usuário");
            Console.WriteLine("2. Limpar todos os dados");
            Console.WriteLine("3. Sair");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    ClearUserData();
                    break;
                case "3":
                    return; // Sai do programa
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        string filePath = "user_data.txt";

        // Coleta de dados do usuário
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        
        Console.Write("Digite seu email: ");
        string email = Console.ReadLine();
        
        Console.Write("Digite sua senha: ");
        string senha = Console.ReadLine();

        // Verificar se o nome ou email já existe
        if (IsNameOrEmailTaken(nome, email, filePath))
        {
            Console.WriteLine("O nome ou email já está em uso. Por favor, escolha outro.");
        }
        else
        {
            // Salvar os dados no arquivo
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Nome: " + nome);
                    writer.WriteLine("Email: " + email);
                    writer.WriteLine("Senha: " + senha);
                    writer.WriteLine("-------------------------");
                }
                Console.WriteLine("Dados armazenados com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar os dados: " + e.Message);
            }
        }
    }

    static bool IsNameOrEmailTaken(string nome, string email, string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.Contains("Nome: " + nome) || line.Contains("Email: " + email))
                    {
                        return true; // Nome ou email já está em uso
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Ocorreu um erro ao ler os dados: " + e.Message);
        }
        return false; // Nome ou email não encontrado
    }

    static void ClearUserData()
    {
        string filePath = "user_data.txt";

        try
        {
            // Escrever uma string vazia para limpar o arquivo
            File.WriteAllText(filePath, string.Empty);
            Console.WriteLine("Todos os dados foram apagados com sucesso!");
        }
        catch (IOException e)
        {
            Console.WriteLine("Ocorreu um erro ao limpar os dados: " + e.Message);
        }
    }
}

