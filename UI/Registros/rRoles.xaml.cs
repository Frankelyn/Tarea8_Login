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
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
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
        private Roles Rol = new(); 
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = Rol;
        }

        void Limpiar()
        {
            this.Rol = new Roles();
            this.DataContext = Rol;
        }

        private bool validar()
        {
            bool esValido = true;
            if(DescripcionTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la descripcion", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var rol = RolesBLL.Buscar(Utilidades.Toint(RolIdTextbox.Text));

            if(rol != null)
            {
                this.Rol = rol;
            }
            else
            {
                this.Rol = new Roles();
            }

            this.DataContext = this.Rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validar())
                return;

            var paso = RolesBLL.Guardar(Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.Toint(RolIdTextbox.Text)))
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
