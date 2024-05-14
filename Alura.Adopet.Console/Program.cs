using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;

var httpClintPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(httpClintPet)},
    {"list",new List(httpClintPet) },
    {"show",new Show() },
};

Console.ForegroundColor = ConsoleColor.Green;
try
{    
    string comando = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comando))
    {
        IComando? cmd = comandosDoSistema[comando];
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    } 
        
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
