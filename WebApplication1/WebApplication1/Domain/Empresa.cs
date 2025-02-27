namespace RH.API.Domain;

public class Empresa
{
    public int EmpresaID { get; set; }
    public string Nome { get; set; }

    public virtual Colaborador Colaborador { get; set; }

}
