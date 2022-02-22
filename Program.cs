using System;
using System.Threading;
using Encontro_Remoto;

namespace Encontro_Remoto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@$"
==========================================
|    Bem vindo ao sistema de cadastro    |
|    de pessoa física e jurídica.        |
==========================================");
           Console.WriteLine($"\n\n");
           BarraCarregamento("iniciando",500);
        
        
            string? opçao;
            do{
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(@$"
======================================
|    Escolha uma das opções abaixo:  |
|       1 - Pessoa Física            |
|       2 - Pessoa Jurídica          |
|                                    |
|       0 - Sair                     |
======================================
");

            
                    opçao = Console.ReadLine();
                    Console.Clear();
                    switch(opçao)
                    {
                        case "1":
                            Console.Clear();
                            Endereco endPf = new Endereco();
                            endPf.logradouro = "Rua x";
                            endPf.numero = 18;
                            endPf.complemento = "Proximo ao Senai";
                            endPf.enderecoComercial = false;

                            PessoaFisica novapf = new PessoaFisica();

                            novapf.endereco = endPf;
                            novapf.cpf = "000000000";
                            novapf.dataNascimento = new DateTime(2002/09/23);
                            novapf.nome = "Caian";

                            PessoaFisica pf = new PessoaFisica();
                            pf.validarDataNascimento(pf.dataNascimento);

                            bool idadeValida = pf.validarDataNascimento(novapf.dataNascimento);

                            if(idadeValida == true)
                            {
                                Console.WriteLine("Cadastro aprovado.");
                            }else{
                                Console.WriteLine("Cadastro não aprovado.");
                            }
                            BarraCarregamento("\n\nCarregando",200);
                            break;
                        
                        case "2":
                            Console.Clear();
                            PessoaJuridica pj = new PessoaJuridica();
                            PessoaJuridica novapj = new PessoaJuridica();
                            Endereco endPj = new Endereco();
                            endPj.logradouro = "Rua x";
                            endPj.numero = 18;
                            endPj.complemento = "Proximo ao Senai";
                            endPj.enderecoComercial = false;
                            novapj.cnpj = "12345678900001";
                            novapj.razaoSocial = "Pessoa Jurídica";
                            novapj.endereco = endPj;
                            if (pj.validarCNPJ(novapj.cnpj))
                            {
                                Console.WriteLine("CNPJ válido.");
                            }
                            else
                            {
                                Console.WriteLine("CNPJ inválido");
                            }
                            BarraCarregamento("\n\nCarregando",200);
                            break;

                        case "0":
                            Console.Clear();
                            Console.WriteLine($"Obrigado por utilizar nosso sistema!\n\n");
                            BarraCarregamento("Finalizando", 500);
                            break;
                            
                        default:
                            Console.Clear();
                            Console.WriteLine($"Opção Inválida, Digite uma opção válida.");
                            BarraCarregamento("\n\nCarregando",200);
                            break;

                    }
                }while (opçao != "0");


            
            ;
        }
    
    
    static void BarraCarregamento(string textoCarregamento, int tempo){
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(textoCarregamento);
        Thread.Sleep(500);

        for (var contador = 0; contador < 10; contador++)
        {
            Console.Write($".");
            Thread.Sleep(tempo);
        }
        Console.ResetColor();

    }
    }
}
