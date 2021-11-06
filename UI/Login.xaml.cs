using RegistroUsuariosWPF.BLL;
using RegistroUsuariosWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroUsuariosWPF.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();
        MainWindow main = new MainWindow();
        public Login()
        {
            InitializeComponent();
        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.validar(EmailTextBox.Text, ClavePasswordBox.Password);

            if (paso)
            {
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Error Email o Clave son incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailTextBox.Clear();
                ClavePasswordBox.Clear();
                EmailTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
