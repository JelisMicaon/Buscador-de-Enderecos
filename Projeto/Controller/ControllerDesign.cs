using Caliburn.Micro;
using RegrasNegocio;
using RegrasNegocio.Entidades;

namespace Controller
{
    public class ControllerDesign : PropertyChangedBase
    {
        #region Propriedade Privadas
        private Negocio _negocio = new Negocio();
        private string _textoCepPadrao;
        private string _cep;
        private string _logradouro;
        private string _complemento;
        private string _bairro;
        private string _localidade;
        private string _uf;
        private string _ibge;
        private string _gia;
        private string _ddd;
        private string _siafi;
        #endregion Propriedade Privadas

        #region Contrustores
        public ControllerDesign()
        {
            _textoCepPadrao = _negocio.RetornarTextoCepPadrao();
            Cep = _textoCepPadrao;
        }
        #endregion Construtores

        #region Métodos Publicos - Propriedades Privadas
        public string Cep
        {
            get => _cep;
            set { _cep = value; NotifyOfPropertyChange(() => Cep); }
        }

        public string Logradouro
        {
            get => _logradouro;
            set { _logradouro = value; NotifyOfPropertyChange(() => Logradouro); }
        }

        public string Complemento
        {
            get => _complemento;
            set { _complemento = value; NotifyOfPropertyChange(() => Complemento); }
        }

        public string Bairro
        {
            get => _bairro;
            set { _bairro = value; NotifyOfPropertyChange(() => Bairro); }
        }

        public string Localidade
        {
            get => _localidade;
            set { _localidade = value; NotifyOfPropertyChange(() => Localidade); }
        }

        public string Uf
        {
            get => _uf;
            set { _uf = value; NotifyOfPropertyChange(() => Uf); }
        }

        public string Ibge
        {
            get => _ibge;
            set { _ibge = value; NotifyOfPropertyChange(() => Ibge); }
        }

        public string Gia
        {
            get => _gia;
            set { _gia = value; NotifyOfPropertyChange(() => Gia); }
        }

        public string DDD
        {
            get => _ddd;
            set { _ddd = value; NotifyOfPropertyChange(() => DDD); }
        }

        public string Siafi
        {
            get => _siafi;
            set { _siafi = value; NotifyOfPropertyChange(() => Siafi); }
        }
        #endregion Métodos Publicos - Propriedades Privadas

        #region Métodos Publicos
        public void ConsultarCep(string numeroCep)
        {
            RetornoApiViaCep DadosEndereco = _negocio.ConsultarCep(numeroCep);

            Logradouro = DadosEndereco.Logradouro;
            Complemento = DadosEndereco.Complemento;
            Bairro = DadosEndereco.Bairro;
            Localidade = DadosEndereco.Localidade;
            Uf = DadosEndereco.Uf;
            Ibge = DadosEndereco.Ibge;
            Gia = DadosEndereco.Gia;
            DDD = DadosEndereco.DDD;
            Siafi = DadosEndereco.Siafi;
        }

        public void FormatarCep(string numeroCep)
        {
            Cep = _negocio.FormatarCep(numeroCep);
        }

        public void LimparBoxTexto()
        {
            Cep = _cep.Contains(_textoCepPadrao) ? "" : _cep;
        }
        #endregion Métodos Publicos
    }
}
