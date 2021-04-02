using Refit;
using RegrasNegocio.Entidades;
using RegrasNegocio.Interfaces;

namespace RegrasNegocio.ApiRefit
{
    public class RefitBase
    {
        #region Propriedades
        protected string urlApi = "https://viacep.com.br";
        #endregion Propriedades

        #region Métodos Privados
        private IViaCepService IniciarRefit()
            => RestService.For<IViaCepService>(urlApi);

        private RetornoApiViaCep BuscarEnderecoPorCep(IViaCepService interfaceViaCep, string numeroCep)
            => interfaceViaCep.BuscarEnderecoAsync(numeroCep).Result;
        #endregion Métodos Privados

        #region Métodos Publicos
        public RetornoApiViaCep BuscarEnderecosApiAsync(string numeroCep)
            => BuscarEnderecoPorCep(IniciarRefit(), numeroCep);
        #endregion Métodos Publicos
    }
}
