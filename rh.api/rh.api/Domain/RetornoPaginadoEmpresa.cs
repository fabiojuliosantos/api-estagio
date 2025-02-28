namespace rh.api.Domain
{
    public class RetornoPaginadoEmpresa<Empresa>
    {
        public int TotalRegistros { get; set; }    
        public int Pagina { get; set; }
        public int QtdPagina {  get; set; }
        public List<Empresa> Empresas { get; set; } 
    }
}
