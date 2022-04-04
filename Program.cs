using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Encontro_Remoto;

namespace Encontro_Remoto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> ListaPF = new List<PessoaFisica>();
            List<PessoaJuridica> ListaPJ = new List<PessoaJuridica>();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@$"
==========================================
|    Bem vindo ao sistema de cadastro    |
|    de pessoa física e jurídica.        |
==========================================");
           Console.WriteLine($"\n\n");
           BarraCarregamento("iniciando",350);
        
        
            string? opçao;
            do{
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(@$"
======================================
|    Escolha uma das opções abaixo:  |
|           PESSOA FÍSICA            |
|     1 - Cadastrar Pessoa Física    |
|     2 - Listar Pessoa Física       |
|     3 - Remover Pessoa Física      |
|                                    |
|           PESSOA JURÍDICA          |
|     4 - Cadastrar Pessoa Jurídica  |
|     5 - Listar Pessoa Jurídica     |
|     6 - Remover Pessoa Jurídica    |
|                                    |
|     0 - Sair                       |
======================================
");

            
                    opçao = Console.ReadLine();
                    Console.Clear();
                    switch(opçao)
                    {
                        case "1":
                            Console.Clear();
                            
                            PessoaFisica novapf = new PessoaFisica();

                            Console.WriteLine("Digite seu CPF(Somente números): ");
                            novapf.cpf = Console.ReadLine();

                            Console.WriteLine("Digite seu nome: ");
                            novapf.nome = Console.ReadLine();

                            Console.WriteLine("Digite sua data de nascimento(dd/mm/aaaa): ");
                            novapf.dataNascimento = DateTime.Parse(Console.ReadLine());
                            
                            Endereco endPf = new Endereco();
                            
                            Console.WriteLine("Digite seu Logradouro: ");
                            endPf.logradouro = Console.ReadLine();

                            Console.WriteLine("Digite seu numero: ");
                            endPf.numero = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite complemento(aperte ENTER para vazio): ");
                            endPf.complemento = Console.ReadLine();

                            Console.WriteLine("Este endereço é comercial?(S/N) ");
                            string endcomercial = Console.ReadLine().ToUpper();

                            if (endcomercial == "S"){
                                endPf.enderecoComercial = true;
                            } else {
                                endPf.enderecoComercial = false;
                            }

                            

                            PessoaFisica pf = new PessoaFisica();
                            // pf.validarDataNascimento(pf.dataNascimento);
                            // Console.WriteLine(pf.pagarImposto(novapf.rendimento).ToString("N2"));

                            bool idadeValida = pf.validarDataNascimento(novapf.dataNascimento);

                            if(idadeValida == true)
                            {
                                Console.WriteLine("Cadastro aprovado.");
                                ListaPF.Add(novapf);
                                GuardarArquivo(novapf.nome, "Nome",novapf.nome, "CPF", novapf.cpf);
                            }else{
                                Console.WriteLine("Cadastro não aprovado.");
                            }
                            BarraCarregamento("\n\nCarregando",200);
                            break;

                        case "2":

                            foreach (var cadaItem in ListaPF)
                            {
                                Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}");
                            }
                            break;
                        case "3":

                            Console.WriteLine("Digite o CPF que deseja remover: ");
                            string? cpfProcurado = Console.ReadLine();

                            PessoaFisica pessoaEncontrada = ListaPF.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                            if (pessoaEncontrada != null)
                            {
                                ListaPF.Remove(pessoaEncontrada);
                                Console.WriteLine("Cadastro removido.");
                            }else
                            {
                                Console.WriteLine("CPF não encontrado.");
                            }
                            break;
                        case "4":
                            Console.Clear();
                            PessoaJuridica novapj = new PessoaJuridica();
                            Endereco endPj = new Endereco();
                            
                            Console.WriteLine("Digite seu CNPJ(Somente números): ");
                            novapj.cnpj = Console.ReadLine();

                            Console.WriteLine("Digite sua Razão Social: ");
                            novapj.razaoSocial = Console.ReadLine();

                            novapj.endereco = endPj;
                            
                            Console.WriteLine("Digite seu Logradouro: ");
                            endPj.logradouro = Console.ReadLine();

                            Console.WriteLine("Digite seu numero: ");
                            endPj.numero = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite complemento(aperte ENTER para vazio): ");
                            endPj.complemento = Console.ReadLine();

                            Console.WriteLine("Este endereço é comercial?(S/N) ");
                            string endcomercialpj = Console.ReadLine().ToUpper();

                            if (endcomercialpj == "S"){
                                endPj.enderecoComercial = true;
                            } else {
                                endPj.enderecoComercial = false;
                            }


                            novapj.rendimento = 8000;

                            PessoaJuridica pj = new PessoaJuridica();
                            Console.WriteLine(pj.pagarImposto(novapj.rendimento).ToString("N2"));
                            if (pj.validarCNPJ(novapj.cnpj))
                            {
                                Console.WriteLine("CNPJ válido.");
                                Console.WriteLine("Cadastro aprovado.");
                                GuardarArquivo(novapj.razaoSocial, "Razão Social", novapj.razaoSocial, "CNPJ", novapj.cnpj);
                                ListaPJ.Add(novapj);
                            }
                            else
                            {
                                Console.WriteLine("CNPJ inválido");
                            }
                            BarraCarregamento("\n\nCarregando",200);
                            break;
                        case "5":
                            foreach (var cadaItem in ListaPJ)
                            {
                                Console.WriteLine($"{cadaItem.razaoSocial}, {cadaItem.cnpj}");
                            }
                            break;
                        case "6":
                            Console.WriteLine("Digite o CNPJ que deseja remover: ");
                            string cnpjProcurado = Console.ReadLine();

                            PessoaJuridica pessoaJEncontrada = ListaPJ.Find(cadaItem => cadaItem.cnpj == cnpjProcurado);
                            if (pessoaJEncontrada != null)
                            {
                                ListaPJ.Remove(pessoaJEncontrada);
                                Console.WriteLine("Cadastro removido.");
                            }else
                            {
                                Console.WriteLine("CNPJ não encontrado.");
                            }
                            break;
                        case "0":
                            Console.Clear();
                            Console.WriteLine($"Obrigado por utilizar nosso sistema!\n\n");
                            BarraCarregamento("Finalizando", 350);
                            break;
                            
                        default:
                            Console.Clear();
                            Console.WriteLine($"Opção Inválida, Digite uma opção válida.");
                            BarraCarregamento("\n\nCarregando",200);
                            break;

                    }
            }while (opçao != "0");


            
        
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
    static void GuardarArquivo(string? nomearquivo, string? tiponome, string? nomepessoa ,string? tipodec, string? c){
            String caminhoDoArquivo = (@$"C:\\Users\\User\\Desktop\\Encontro_Remoto\\pessoas\\{nomearquivo}.txt");
            var Stream = new StreamWriter(caminhoDoArquivo);
            Stream.Write(@$"
            {tiponome}: {nomepessoa}
            {tipodec}: {c}");
            Stream.Close();
            using(var reader = new StreamReader(caminhoDoArquivo))
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
    }
}
