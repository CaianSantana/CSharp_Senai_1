using System;
using Encontro_Remoto;

namespace Encontro_Remoto
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco end = new Endereco();
            
            end.logradouro = "Rua x";
            end.numero = 18;
            end.complemento = "Proximo ao Senai";
            end.enderecoComercial = false;

            PessoaFisica novapf = new PessoaFisica();

            novapf.endereco = end;
            novapf.cpf = "000000000";
            novapf.dataNascimento = new DateTime(2002/09/23);
            novapf.nome = "Caian";

            PessoaFisica pf = new PessoaFisica();
            pf.validarDataNascimento(pf.dataNascimento);

            bool idadeValida = pf.validarDataNascimento(novapf.dataNascimento);
            Console.WriteLine(idadeValida);

            if(idadeValida == true)
            {
                Console.WriteLine("Cadastro aprovado.");
            }else{
                Console.WriteLine("Cadastro não aprovado.");
            }

            Console.WriteLine($"Rua: {novapf.endereco.logradouro}, {novapf.endereco.numero}");
        }
    }
}
