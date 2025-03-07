using System.Text.Json.Serialization;

namespace rh.api.Dto
{
    public class FuncionarioDTO
    {
        // O ID não será exibido
        [JsonIgnore]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}