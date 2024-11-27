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

namespace SGC.Vista
{
    /// <summary>
    /// Lógica de interacción para MenuDocente.xaml
    /// </summary>
    public partial class MenuDocente : Window
    {
        public MenuDocente()
        {
            InitializeComponent();
        }

        private void ConsultarConstanciaButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaConsulta = new Vista.ConsultarConstancia();
            ventanaConsulta.Show();
            this.Close();
        }

        private void CerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaInicio = new MainWindow();
            ventanaInicio.Show();
            this.Close();
        }
    }
}
