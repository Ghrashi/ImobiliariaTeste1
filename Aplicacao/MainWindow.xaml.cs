using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Aplicacao.Inicio;

namespace Aplicacao {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            txtUsuario.Focus();
            EventManager.RegisterClassHandler(typeof(TextBox), KeyDownEvent, new KeyEventHandler(TextBox_KeyDown));
        }

        private void ButtonSair_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape){
                Close();
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Down){
                MoverProximo(e);
            }
            else if (e.Key == Key.Up){
                MoverAnterior(e);
            }
        }

        private void MoverProximo(KeyEventArgs e){
            var requisicao = new TraversalRequest(FocusNavigationDirection.Next);
            var controle = (Keyboard.FocusedElement as UIElement);
            if (controle != null && controle.MoveFocus(requisicao)){
                e.Handled = true;
            }
        }

        private void MoverAnterior(KeyEventArgs e){
            var requisicao = new TraversalRequest(FocusNavigationDirection.Previous);
            var controle = (Keyboard.FocusedElement as UIElement);
            if (controle != null && controle.MoveFocus(requisicao)){
                e.Handled = true;
            }
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Inicio ini = new Inicio();
        }
    }
}
