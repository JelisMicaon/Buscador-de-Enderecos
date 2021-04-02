using RegrasNegocio.ApiRefit;
using RegrasNegocio.Entidades;
using System.Text.RegularExpressions;

namespace RegrasNegocio
{
    public class Negocio
    {
        #region Propriedades
        protected string textoCepPadrao = "00000-000";
        protected RefitBase _refitBase = new RefitBase();
        #endregion Propriedades

        #region Construtores
        static void Main() { }
        #endregion Construtores

        #region Métodos Privados
        private string RetornarApenasNumeros<T>(T dado)
            => new Regex(@"[^\d]").Replace(dado.ToString(), "");

        private bool ValidacoesCep(string numeroCep)
        {
            bool sucesso = true;
            numeroCep = RetornarApenasNumeros<string>(numeroCep);

            if (numeroCep.Length != 8) sucesso = false;

            return sucesso;
        }

        private string FormatarCepPadrao(string numeroCep)
            => $"{numeroCep.Substring(0, 5)}-{numeroCep.Substring(5, 3)}";

        private RetornoApiViaCep BuscarCepApi(string numeroCep)
            => _refitBase.BuscarEnderecosApiAsync(RetornarApenasNumeros(numeroCep));
        #endregion Métodos Privados

        #region Métodos Publicos
        public string RetornarTextoCepPadrao()
            => textoCepPadrao;

        public string FormatarCep(string numeroCep)
        {
            if (ValidacoesCep(numeroCep))
                numeroCep = FormatarCepPadrao(RetornarApenasNumeros<string>(numeroCep));
            return numeroCep;
        }

        public RetornoApiViaCep ConsultarCep(string numeroCep)
            => BuscarCepApi(numeroCep);
        #endregion Métodos Publicos
    }
}
