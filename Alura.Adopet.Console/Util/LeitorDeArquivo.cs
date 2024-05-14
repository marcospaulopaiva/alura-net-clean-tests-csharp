﻿using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {

        private string _caminhoDoArquivoASerLido;

        public LeitorDeArquivo(string caminhoDoArquivoASerLido)
        {
            _caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public List<Pet>? RealizaLeitura()
        {
            if (String.IsNullOrEmpty(_caminhoDoArquivoASerLido)) return null;

            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(_caminhoDoArquivoASerLido))
            {
                System.Console.WriteLine("----- Dados a serem importados -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[]? propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
