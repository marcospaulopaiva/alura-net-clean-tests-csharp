﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    public static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivo> CriaMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}
