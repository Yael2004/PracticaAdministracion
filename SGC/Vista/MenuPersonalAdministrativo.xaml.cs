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
    /// Lógica de interacción para MenuPersonalAdministrativo.xaml
    /// </summary>
    public partial class MenuPersonalAdministrativo : Window
    {
        public MenuPersonalAdministrativo()
        {
            InitializeComponent();
        }

        private void ConsultarConstanciaButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaConsultarConstancia = new ConsultarConstancia();
            ventanaConsultarConstancia.Show();
            this.Close();
        }

        private void RegistrarConstanciaButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaRegistrarConstancia = new RegistrarConstanciaEE();
            ventanaRegistrarConstancia.Show();
            this.Close();
        }

        private void RegistrarDocenteButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaRegistroDocente = new RegistroDocente();
            ventanaRegistroDocente.Show();
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
