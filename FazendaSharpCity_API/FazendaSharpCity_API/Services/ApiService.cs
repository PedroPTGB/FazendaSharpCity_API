using FazendaSharpCity_API.Data.Contexts;
using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Services
{
    public class ApiService
    {
        private ApiContext _context;

        public ApiService(ApiContext context)
        {
            _context = context;
        }

        public async Task<bool>? VerificaUnicoCliente(Cliente cliente)
        {
            Cliente clienteAux = null;
            if (cliente.CPF == "")
            {
                clienteAux = await _context.Clientes.FirstOrDefaultAsync(clienteAux => clienteAux.CNPJ == cliente.CNPJ);

                if (clienteAux == null)
                {
                    return true;
                }
                return false;
            }
            clienteAux = await _context.Clientes.FirstOrDefaultAsync(clienteAux => clienteAux.CPF == cliente.CPF);

            if (clienteAux == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool>? VerificaUnicoFornecedor(Fornecedor forn)
        {
            Fornecedor fornAux = null;

            fornAux = await _context.Fornecedores.FirstOrDefaultAsync(fornAux => fornAux.Cnpj == forn.Cnpj);

            if (fornAux == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool>? VerificaUnicoFuncionario(Funcionario funci)
        {
            Funcionario funciAux = null;

            funciAux = await _context.Funcionarios.FirstOrDefaultAsync(funciAux => funciAux.CPF == funci.CPF);

            if (funciAux == null)
            {
                return true;
            }
            return false;
        }
    }
}
