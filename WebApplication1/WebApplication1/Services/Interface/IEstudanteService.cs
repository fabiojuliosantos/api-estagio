using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IEstudanteService
{
    Estudante AdicionarEstudante(Estudante estudante);
    Estudante AtualizarEstudante(Estudante estudante);
    List<Estudante> ListarEstudantes();
}
