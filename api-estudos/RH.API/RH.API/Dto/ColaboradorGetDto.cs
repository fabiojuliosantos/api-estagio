namespace RH.API.Dto
{
    public class ColaboradorGetDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Matricula { get; set; }
        public int EmpresaID { get; set; }
        public EmpresaDto Empresa { get; set; }
    }
}
