using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Util;
using FluentResults;

var httpClintPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
var leitorDeArquivo = new LeitorDeArquivo(caminhoDoArquivoASerLido: args[1]);

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(httpClintPet, leitorDeArquivo)},
    {"list",new List(httpClintPet) },
    {"show",new Show() },
};

   
string comando = args[0].Trim();
if (comandosDoSistema.ContainsKey(comando))
{
    IComando? cmd = comandosDoSistema[comando];
    var resultado = await cmd.ExecutarAsync(args);

    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
} 
        
