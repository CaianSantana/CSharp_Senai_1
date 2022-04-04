using System;
using System.Text;

namespace Encontro_Remoto
{
    public abstract class Pessoa
    {
        public string? nome { get; set; }
        public Endereco? endereco { get; set; }
        public float rendimento {get; set; }
        public abstract double pagarImposto(float rendimento);
    
    }
}