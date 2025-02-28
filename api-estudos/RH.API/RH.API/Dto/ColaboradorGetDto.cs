namespace RH.API.Dto
{
    public class ColaboradorGetDto
    {
        public int ColaboradorID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Matricula { get; set; }
        public EmpresaDto Empresa { get; set; }
    }
}
