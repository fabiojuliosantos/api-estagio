namespace rh.api.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(string nome, string cargo, decimal salario)
        {
            try
            {
                //Para não permitir valores nulos ou vazios
                if (string.IsNullOrEmpty(nome))
                    throw new ArgumentException("O nome não pode ser vazio.");

                if (salario <= 0)
                    throw new ArgumentException("O salário deve ser um número positivo.");

                Nome = nome;
                Cargo = cargo;
                Salario = salario;
            }
            catch (Exception) 
            { throw; }
            }
    }
}