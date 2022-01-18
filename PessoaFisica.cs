using System;

namespace Encontro_Remoto
{
    public class PessoaFisica : Pessoa
    {
        
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }    
        public override void pagarImposto(float salario){
        }    
            public bool validarDataNascimento(DateTime dataNasc) {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataNasc).TotalDays /365;

                if(anos >= 18){
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            

    }
}