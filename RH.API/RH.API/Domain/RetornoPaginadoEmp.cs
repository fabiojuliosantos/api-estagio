namespace RH.API.Domain;

public class RetornoPaginadoEmp<Empresa>
{
    public int TotalRegistros { get; set; }
    public int Pagina { get; set; }
    public int QtdPagina { get; set; }
    public List<Empresa> Empresas { get; set; }
}
