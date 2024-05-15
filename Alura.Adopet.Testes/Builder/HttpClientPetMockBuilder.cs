using Alura.Adopet.Console.Servicos;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    public class HttpClientPetMockBuilder
    {
        public static Mock<HttpClientPet> GetMock()
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
                It.IsAny<HttpClient>());

            return httpClientPet;

        }
    }
}
