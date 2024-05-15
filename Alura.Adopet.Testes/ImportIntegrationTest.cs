using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes
{
    public class ImportIntegrationTest
    {
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arange
            var listaDePet = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),"Lima", TipoPet.Cachorro); 
            
            listaDePet.Add(pet);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);

            var httpClintPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
            var import = new Import(httpClintPet, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync(args);

            //Assert
            var listaPet = await httpClintPet.ListPetsAsync();
            Assert.NotNull(listaPet);
        }
    }
}
