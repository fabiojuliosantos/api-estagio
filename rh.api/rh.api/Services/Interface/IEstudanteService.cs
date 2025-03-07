using rh.api.Domain;

namespace rh.api.Services.Interface
{
    public interface IEstudanteService
    {
        List<Estudante> ListarEstudantes();
        Estudante AdicionarEstudante(EstudanteDto estudanteDto);
        Estudante AtualizarEstudante(int id, EstudanteDto estudanteAtualizado);
    }
}
