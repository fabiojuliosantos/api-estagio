using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IEstudanteService
{
    IEnumerable<EstudanteDTO> ListarEstudantes();
    EstudanteDTO BuscarEstudantePorMatricula(string matricula);
    EstudanteDTO AdicionarEstudante(EstudanteDTO estudanteDTO);
    bool AtualizarMatricula(string matriculaAntiga, string matriculaNova);
    bool RemoverEstudante(string matricula);
}
