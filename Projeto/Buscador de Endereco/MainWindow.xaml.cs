using Controller;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Buscador_de_Endereco
{
    public partial class MainWindow : Window
    {
        #region Propriedades
        protected readonly ControllerDesign _controller = new ControllerDesign();
        #endregion Propriedades

        #region Construtores
        public MainWindow()
        {
            InitializeComponent();
            _controller.PropertyChanged += PropertyChangedForm;
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.KeyDownEvent, new KeyEventHandler(Formulario_KeyDown));
        }
        #endregion Construtores

        #region Métodos Formulario
        private void PropertyChangedForm(object sender, PropertyChangedEventArgs e)
        {
            txtCep.Text = ((ControllerDesign)sender).Cep;
            txtLogradouro.Text = ((ControllerDesign)sender).Logradouro;
            txtComplemento.Text = ((ControllerDesign)sender).Complemento;
            txtBairro.Text = ((ControllerDesign)sender).Bairro;
            txtLocalidade.Text = ((ControllerDesign)sender).Localidade;
            txtUf.Text = ((ControllerDesign)sender).Uf;
            txtIbge.Text = ((ControllerDesign)sender).Ibge;
            txtGia.Text = ((ControllerDesign)sender).Gia;
            txtDDD.Text = ((ControllerDesign)sender).DDD;
            txtSiafi.Text = ((ControllerDesign)sender).Siafi;
        }

        private void txtCep_GotFocus(object sender, RoutedEventArgs e)
        {
            _controller.LimparBoxTexto();
        }

        private void txtCep_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.FormatarCep(txtCep.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao validar CEP! \n" + exception.Message);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.ConsultarCep(txtCep.Text);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("400"))
                    MessageBox.Show($"Erro ao consultar CEP! \n CEP informado: { txtCep.Text }", "CEP incorreto!", MessageBoxButton.OK, MessageBoxImage.Error);
                else MessageBox.Show("Ocorreu algum erro. \n" + exception.Message);
            }
        }

        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                var controle = (Keyboard.FocusedElement as UIElement);
                if (controle != null && controle.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next)))
                    e.Handled = true;
            }
        }
        #endregion Métodos Formulario

        #region Métodos Copiar
        private void Copiar_Click(object sender, RoutedEventArgs e)
        {
            string copiarText = "";
            string botaoCopia = ((FrameworkElement)sender).Name;
            TextBox textBox = new TextBox();

            switch (botaoCopia)
            {
                case "CopiarLogradouro":
                    textBox = txtLogradouro;
                    copiarText = textBox.Text;
                    break;
                case "CopiarComplemento":
                    textBox = txtComplemento;
                    copiarText = textBox.Text;
                    break;
                case "CopiarBairro":
                    textBox = txtBairro;
                    copiarText = textBox.Text;
                    break;
                case "CopiarLocalidade":
                    textBox = txtLocalidade;
                    copiarText = textBox.Text;
                    break;
                case "CopiarUf":
                    textBox = txtUf;
                    copiarText = textBox.Text;
                    break;
                case "CopiarIbge":
                    textBox = txtIbge;
                    copiarText = textBox.Text;
                    break;
                case "CopiarGia":
                    textBox = txtGia;
                    copiarText = textBox.Text;
                    break;
                case "CopiarDDD":
                    textBox = txtDDD;
                    copiarText = textBox.Text;
                    break;
                case "CopiarSiafi":
                    textBox = txtSiafi;
                    copiarText = textBox.Text;
                    break;
            }

            AlterarCorTextBoxBorder(textBox);
            Clipboard.SetText(copiarText);
        }

        private void AlterarCorTextBoxBorder(TextBox textBox)
        {
            textBox.BorderBrush = textBox.BorderBrush == Brushes.Chartreuse ? Brushes.Silver : Brushes.Chartreuse;
        }
        #endregion Métodos Copiar
    }
}
