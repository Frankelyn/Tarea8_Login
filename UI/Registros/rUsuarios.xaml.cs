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

namespace RegistroUsuariosWPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {

        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        Usuarios usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;

            RolCombox.ItemsSource = RolesBLL.GetRoles();
            RolCombox.SelectedValuePath = "RolId";
            RolCombox.DisplayMemberPath = "Descripcion";
        }

        private bool validar()
        {
            bool esValido = true;
            if(NombresTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo nombres no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ApellidosTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo apellidos no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo email no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ClavePasswordbox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Clave no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(ConfirmarClavePasswordbox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Confirmar Clave no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(RolCombox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Rol no puede estar vacio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ConfirmarClavePasswordbox.Password != ClavePasswordbox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Las contraseñas no coinciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClavePasswordbox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (UsuariosBLL.ExisteEmail(usuario.email))
            {
                esValido = false;
                MessageBox.Show("Este Email ya existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }

        private void Limpiar()
        {
            this.usuario = new Usuarios();
            this.DataContext = usuario;

            ClavePasswordbox.Clear();
            ConfirmarClavePasswordbox.Clear();
            NombresTextbox.Focus();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Usuario = UsuariosBLL.Buscar(Utilidades.Toint(UsuarioIdTextbox.Text));

            if(Usuario == null)
            {
                MessageBox.Show("Usuario no encontrado!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(Usuario != null)
            {
                this.usuario = Usuario;
            }
            else
            {
                this.usuario = new Usuarios();
            }

            this.DataContext = this.usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validar())
            {
                return;
            }

            var paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Trasaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.Toint(UsuarioIdTextbox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
