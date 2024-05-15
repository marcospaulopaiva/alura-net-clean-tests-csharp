﻿using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show:IComando
    {
        public Task<Result> ExecutarAsync(string[] args)
        {
            this.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]); 
            return Task.FromResult(Result.Ok());
        }
        private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo(caminhoDoArquivoASerExibido);
            var listaDepets = leitor.RealizaLeitura();
            foreach (var pet in listaDepets)
            {
                System.Console.WriteLine(pet);
            }


        }
    }
}
