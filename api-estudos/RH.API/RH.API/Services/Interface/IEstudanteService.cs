using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IEstudanteService
    {
        (bool Sucesso, string Mensagem) AdicionarEstudante(Estudante estudante);
        (bool Sucesso, string Mensagem, IEnumerable<Estudante> Estudantes) ListarEstudantes();
        (bool Sucesso, string Mensagem) AtualizarEstudante(int matricula, EstudantePutDto estudante);
    }
}
