namespace RH.API.Domain
{
    public class RetornoColaborador<Colaborador>
    {
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }
}
