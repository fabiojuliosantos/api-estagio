using System.Collections.Generic;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Services.Interface
{
    public interface IAlunoService
    {
        (bool Sucesso, string Mensagem) AdicionarAluno(Aluno aluno);
        List<Aluno> ListarAlunos();
        (bool Sucesso, string Mensagem) AtualizarMatricula(int matricula, UpdateAlunoDto alunoDto);
    }
}
