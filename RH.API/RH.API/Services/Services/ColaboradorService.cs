using System.Text.RegularExpressions;
using Azure;
using Microsoft.EntityFrameworkCore;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }
    #region atualizar colaborador
    public async Task<RespostaDTO> AtualizarColaborador(AtualizarColaboradorDto colaboradorDto)
    {
        try
        {
            
            if (colaboradorDto.Id <= 0)
                return new RespostaDTO(false, "ID do colaborador é obrigatório");

           
            var colaboradorExistente = await _repository.BuscarColaboradorId(colaboradorDto.Id);
            if (colaboradorExistente == null)
                return new RespostaDTO(false, "Colaborador não encontrado");

            
            if (string.IsNullOrWhiteSpace(colaboradorDto.Nome))
                return new RespostaDTO(false, "Nome do colaborador é obrigatório");

            if (!string.IsNullOrWhiteSpace(colaboradorDto.Cpf) && !ValidarCpf(colaboradorDto.Cpf))
                return new RespostaDTO(false, "CPF inválido");

            if (colaboradorDto.Matricula <= 0)
                return new RespostaDTO(false, "A matrícula deve ser um número positivo");

            var matriculaExistente = await _repository.BuscarMatricula(colaboradorDto.Matricula);
            if (matriculaExistente != null)
                return new RespostaDTO(false, "Já existe um colaborador com essa matrícula");



            colaboradorExistente.Nome = colaboradorDto.Nome;
            colaboradorExistente.Cpf = colaboradorDto.Cpf ?? colaboradorExistente.Cpf; 
            colaboradorExistente.Matricula = colaboradorDto.Matricula;
            colaboradorExistente.EmpresaID = colaboradorDto.EmpresaId;

            
            bool resultado = await _repository.AtualizarColaborador(colaboradorExistente);

            if (!resultado)
                return new RespostaDTO(false, "Erro ao atualizar colaborador");

            return new RespostaDTO(true, "Colaborador atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }

    #endregion

    #region Buscar Todos os colaboradores
    public async Task<List<Colaborador>> BuscarTodosColaborador()
    {
        try
        {
            var colaborador = await _repository.BuscarTodosColaborador();

            return colaborador;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region Excluir Colaborador
    public async Task<RespostaDTO> ExcluirColaborador(int id)
    {
        try
        {
            
            if (id <= 0)
                return new RespostaDTO(false, "ID do colaborador é obrigatório");

            
            var colaboradorExistente = await _repository.BuscarColaboradorId(id);
            if (colaboradorExistente == null)
                return new RespostaDTO(false, "Colaborador não encontrado");

            
            bool resultado = await _repository.ExcluirColaborador(id);

            if (!resultado)
                return new RespostaDTO(false, "Erro ao excluir colaborador");

            return new RespostaDTO(true, "Colaborador excluído com sucesso!");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }
    #endregion 

    #region Buscar Colaborador
    public async Task<Colaborador> BuscarColaboradorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorId(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region validar CPF
    private bool ValidarCpf(string cpf)
    {
        try
        {

            int[] multiplicadorPrimerioDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2, };
            int[] multiplicadorSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, };
            String noveDigitosCpf;
            String digito;
            int resto = 0;
            int soma = 0;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Distinct().Count() == 1)
            {

                throw new Exception("Insira apenas CPF válidos");
            }




            noveDigitosCpf = cpf.Substring(0, 9);


            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                Console.WriteLine("Insira um CPF válido!!");
            }



            for (int i = 0; i < 9; i++)
            {

                soma += (int.Parse(noveDigitosCpf[i].ToString())) * multiplicadorPrimerioDigito[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            noveDigitosCpf = noveDigitosCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {

                soma += int.Parse(noveDigitosCpf[i].ToString()) * multiplicadorSegundoDigito[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            noveDigitosCpf = noveDigitosCpf + resto;


            return cpf == noveDigitosCpf;
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    #region Inserir Colaborador
    public async Task<RespostaDTO> InserirColaborador(InserirColaboradorDto colaboradorDto)
    {
        try
        {
          
            if (string.IsNullOrWhiteSpace(colaboradorDto.Nome))
                return new RespostaDTO(false, "Nome do colaborador é obrigatório");

            if (string.IsNullOrWhiteSpace(colaboradorDto.Cpf) || !ValidarCpf(colaboradorDto.Cpf))
                return new RespostaDTO(false, "CPF inválido");

                var cpfExistente = await _repository.BuscarCpf(colaboradorDto.Cpf);
            if (cpfExistente != null)
               return new RespostaDTO(false, "Já existe um colaborador com esse cpf");

            if (colaboradorDto.Matricula <= 0)
                return new RespostaDTO(false, "A matrícula deve ser um número positivo");

            var matriculaExistente = await _repository.BuscarMatricula(colaboradorDto.Matricula);
            if (matriculaExistente != null)
                return new RespostaDTO(false, "Já existe um colaborador com essa matrícula");

        
            var colaborador = new Colaborador
            {
                Nome = colaboradorDto.Nome,
                Cpf = colaboradorDto.Cpf,
                Matricula = colaboradorDto.Matricula,
                EmpresaID = colaboradorDto.EmpresaId
            };


            


            bool resultado = await _repository.InserirColaborador(colaborador);

            if (!resultado)
                return new RespostaDTO(false, "Erro ao inserir colaborador");

            return new RespostaDTO(true, "Colaborador cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }
  


}

    

#endregion
