using RH.API.Domain;
using RH.API.Dto;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class ColaboradoresService : IColaboradorService
    {
        private readonly IColaboradoresRepository _colaboradoresRepository;

        public ColaboradoresService(IColaboradoresRepository colaboradoresRepository)
        {
            _colaboradoresRepository = colaboradoresRepository;
        }

        public async Task<bool> InserirColaborador(CreateColaboradorDto colaboradorDto)
        {
            ValidarColaborador(colaboradorDto);
            ValidaCpf(colaboradorDto.CPF);

            var colaborador = new Colaborador
            {
                Nome = colaboradorDto.Nome,
                CPF = colaboradorDto.CPF,
                Matricula = colaboradorDto.Matricula,
                EmpresaId = colaboradorDto.EmpresaId
            };

            return await _colaboradoresRepository.InserirColaborador(colaborador);
        }

        public async Task<bool> AtualizarColaborador(int id, UpdateColaboradorDto colaboradorDto)
        {
            ValidarColaborador(colaboradorDto);
            ValidaCpf(colaboradorDto.CPF);

            var colaborador = new Colaborador
            {
                ColaboradorId = id,
                Nome = colaboradorDto.Nome,
                CPF = colaboradorDto.CPF,
                Matricula = colaboradorDto.Matricula,
                EmpresaId = colaboradorDto.EmpresaId
            };

            return await _colaboradoresRepository.AtualizarColaborador(colaborador);
        }

        public async Task<Colaborador> BuscarColaboradoresPorId(int id)
        {
            return await _colaboradoresRepository.BuscarColaboradoresPorId(id);
        }

        public async Task<List<Colaborador>> BuscarTodosColaboradores()
        {
            return await _colaboradoresRepository.BuscarTodosColaboradores();
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            return await _colaboradoresRepository.ExcluirColaborador(id);
        }

        #region metodos de validações

        #region validação de nulidade
        private void ValidarColaborador(IColaboradorDto colaborador)
        {
            if (string.IsNullOrWhiteSpace(colaborador.Nome))
                throw new Exception("O nome do colaborador é obrigatório.");

            if (string.IsNullOrWhiteSpace(colaborador.CPF))
                throw new Exception("O CPF do colaborador é obrigatório.");

            if (colaborador.Matricula <= 0)
                throw new Exception("A matrícula do colaborador deve ser um número positivo.");

            if (colaborador.EmpresaId <= 0)
                throw new Exception("O ID da empresa deve ser um número positivo.");
        }

        #endregion

        #region validação de cpf
        private void ValidaCpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new Exception("O CPF deve conter 11 dígitos.");
            }

            // Primeiro dígito
            int soma = 0;
            for (int i = 0; i < 9; i++) // Passa pelos 9 primeiros dígitos
            {
                int digito = int.Parse(cpf[i].ToString()); // Pega o dígito
                int peso = 10 - i; // Peso 10 e vai diminuindo até 2
                soma += digito * peso; // Dígito vezes peso e adição com soma
            }

            int resto = soma % 11;
            int digito1;

            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            // Segundo dígito
            soma = 0;
            for (int i = 0; i < 10; i++) // Passa pelos 10 primeiros dígitos
            {
                int digito = int.Parse(cpf[i].ToString());
                int peso = 11 - i; // Peso descendo de 11 e diminui até 2
                soma += digito * peso; // Peso x dígito e adiciona à soma
            }

            resto = soma % 11;
            int digito2;

            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            // Verifica se os dígitos verificadores calculados são iguais aos do CPF
            if (int.Parse(cpf[9].ToString()) != digito1 || int.Parse(cpf[10].ToString()) != digito2)
            {
                throw new Exception("O CPF é inválido.");
            }
        }

        #endregion

        #endregion
    }
}
