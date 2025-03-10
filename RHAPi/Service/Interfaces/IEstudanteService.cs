using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;

public interface IEstudanteService
{
    // adicionar um estudante, listar todos os estudantes cadastrados e atualizar a matrícula de um estudante.
    Estudante AdicionarEstudante(CreateEstudanteDto estudanteDto);
    List<Estudante> ListarEstudante();
    Estudante AtualizarMatriculaEstudante(UpdateEstudanteDto estudanteDto);
}