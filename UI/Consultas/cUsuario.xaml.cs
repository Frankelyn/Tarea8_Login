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

namespace RegistroUsuariosWPF.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuario.xaml
    /// </summary>
    public partial class cUsuario : Window
    {
        public cUsuario()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriterioTextbox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                                listado = UsuariosBLL.GetList(
                                    c => c.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                    c.FechaIngreso.Date <= HastaDatePicker.SelectedDate &&
                                    c.Nombres.ToLower().Contains(CriterioTextbox.Text.ToLower())
                                );
                            else
                                listado = UsuariosBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            break;
                        }
                    case 1:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                                listado = UsuariosBLL.GetList(
                                    c => c.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                    c.FechaIngreso.Date <= HastaDatePicker.SelectedDate &&
                                    c.apellidos.ToLower().Contains(CriterioTextbox.Text.ToLower())
                                );
                            else
                                listado = UsuariosBLL.GetList(e => e.apellidos.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            break;
                        }
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(e => true);
            }


            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count();

            ConteoTextBox.Text = conteo.ToString();
        }
            
    }
}
