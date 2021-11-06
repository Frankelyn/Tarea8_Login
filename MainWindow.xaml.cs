using RegistroUsuariosWPF.UI.Consultas;
using RegistroUsuariosWPF.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroUsuariosWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void UsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();
        }

        private void ConsultaUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuario cUsuario = new cUsuario();
            cUsuario.Show();
        }
    }
}
