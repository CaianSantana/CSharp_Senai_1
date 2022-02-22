namespace Encontro_Remoto
{
    public class PessoaJuridica : Pessoa
    {
        
        public string? cnpj { get; set; }
        public string? razaoSocial { get; set; }
        public override void pagarImposto(float salario){
        }
        
            public bool validarCNPJ(string cnpj) {
                 ;
                if (cnpj.Length >= 14 && cnpj.Substring(cnpj.Length - 4)=="0001"){
                    return true;
                }else{
                    return false;
                }
            }
    }
}