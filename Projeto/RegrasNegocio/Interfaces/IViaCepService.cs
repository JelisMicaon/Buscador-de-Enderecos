using Refit;
using RegrasNegocio.Entidades;
using System.Threading.Tasks;

namespace RegrasNegocio.Interfaces
{
    public interface IViaCepService
    {
        [Get("/ws/{numeroCep}/json")]
        Task<RetornoApiViaCep> BuscarEnderecoAsync(string numeroCep);
    }
}
