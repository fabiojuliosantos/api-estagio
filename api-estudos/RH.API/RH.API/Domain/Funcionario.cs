using System.ComponentModel.DataAnnotations;

namespace RH.API.Domain
{
    public class Funcionario
    {
        public string Nome { get; set; }

        public string Cargo { get; set; }

        public int Salario { get; set; }
    }
}
