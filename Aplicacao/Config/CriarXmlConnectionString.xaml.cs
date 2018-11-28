using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace Aplicacao.Config {

    public partial class CriarXmlConnectionString : Window {
        public CriarXmlConnectionString() {
            InitializeComponent();

            txtInstancia.Focus();
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.KeyDownEvent, new KeyEventHandler(TextBox_KeyDown));
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e) {
            try {
                ConectionString cn = new ConectionString();
                cn.Instancia = txtInstancia.Text;
                cn.Bd = txtBancoDados.Text;
                cn.Usuario = txtUsuario.Text;
                cn.Senha = txtSenha.Text;
                cn.CriarConnectioString();
                MessageBox.Show("ConnectionString criado com sucesso!!");
                Close();
            }
            catch (XmlException ex) {
                MessageBox.Show(ex.Message + "  Erro ao tentar criar ConnectionString");
            }
        }

        private void ButtonSair_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape) {
                Close();
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Down) {
                MoverProximo(e);
            }
            else if (e.Key == Key.Up) {
                MoverAnterior(e);
            }
        }

        private void MoverProximo(KeyEventArgs e) {
            var requisicao = new TraversalRequest(FocusNavigationDirection.Next);
            var controle = (Keyboard.FocusedElement as UIElement);
            if(controle != null && controle.MoveFocus(requisicao)) {
                e.Handled = true;
            }
        }

        private void MoverAnterior(KeyEventArgs e) {
            var requisicao = new TraversalRequest(FocusNavigationDirection.Previous);
            var controle = (Keyboard.FocusedElement as UIElement);
            if (controle != null && controle.MoveFocus(requisicao)) {
                e.Handled = true;
            }
        }
    }
}
