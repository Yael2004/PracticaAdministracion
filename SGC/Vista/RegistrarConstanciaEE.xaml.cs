using System;
using System.Linq;
using System.Windows;
using SGC.Modelo;

namespace SGC.Vista
{
    public partial class RegistrarConstanciaEE : Window
    {
        public RegistrarConstanciaEE()
        {
            InitializeComponent();
        }

        private int? _docenteIdSeleccionado = null;

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new SistemaGeneracionConstanciasEntities())
                {
                    string numeroPersonal = NumeroPersonalTextBox.Text;

                    var docente = context.Usuario
                        .Where(u => u.NumeroPersonal == numeroPersonal)
                        .Select(u => new
                        {
                            DocenteID = u.Docente.DocenteID,
                            Nombre = u.Nombre + " " + u.Apellidos
                        })
                        .FirstOrDefault();

                    if (docente != null)
                    {
                        MessageBox.Show($"Docente encontrado: {docente.Nombre}",
                                        "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                        _docenteIdSeleccionado = docente.DocenteID;

                        CamposEEPanel.Visibility = Visibility.Visible;

                        CamposEEPanel.Visibility = Visibility.Visible;
                        BotonesBuscarPanel.Visibility = Visibility.Collapsed;
                        BotonesDespuesBuscarPanel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un docente con el número de personal proporcionado.",
                                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el docente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegistrarEEButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (_docenteIdSeleccionado == null)
            {
                MessageBox.Show("Debe buscar un docente antes de registrar la experiencia educativa.",
                                "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ValidarCampos())
            {
                try
                {
                    using (var context = new SistemaGeneracionConstanciasEntities())
                    {
                        var programaEducativo = new ProgramaEducativo
                        {
                            Nombre = NombreEETextBox.Text
                        };

                        context.ProgramaEducativo.Add(programaEducativo);
                        context.SaveChanges();

                        var nuevaEE = new ExperienciaEducativa
                        {
                            Bloque = BloqueTextBox.Text,
                            Seccion = SeccionTextBox.Text,
                            CreditosEe = int.Parse(CreditosEETextBox.Text),
                            ProgramaEducativoID = programaEducativo.ProgramaEducativoID,
                            HSM = int.Parse(HSMTextBox.Text)
                        };

                        context.ExperienciaEducativa.Add(nuevaEE);
                        context.SaveChanges();

                        var relacion = new DocenteExperienciaEducativa
                        {
                            DocenteID = _docenteIdSeleccionado.Value,
                            ExperienciaEducativaID = nuevaEE.ExperienciaEducativaID,
                            Periodo = "2024-2025"
                        };

                        context.DocenteExperienciaEducativa.Add(relacion);
                        context.SaveChanges();

                        MessageBox.Show("Experiencia educativa registrada y asociada al docente con éxito.",
                                        "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar la experiencia educativa: {ex.Message}",
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaMenuPersonalAdministrativo = new MenuPersonalAdministrativo();
            ventanaMenuPersonalAdministrativo.Show();
            this.Close();
        }

        private void LimpiarFormulario()
        {
            NumeroPersonalTextBox.Text = string.Empty;
            NombreEETextBox.Text = string.Empty;
            BloqueTextBox.Text = string.Empty;
            SeccionTextBox.Text = string.Empty;
            CreditosEETextBox.Text = string.Empty;
            HSMTextBox.Text = string.Empty;

            CamposEEPanel.Visibility = Visibility.Collapsed;
            _docenteIdSeleccionado = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(NumeroPersonalTextBox.Text) ||
                string.IsNullOrWhiteSpace(NombreEETextBox.Text) ||
                string.IsNullOrWhiteSpace(BloqueTextBox.Text) ||
                string.IsNullOrWhiteSpace(SeccionTextBox.Text) ||
                string.IsNullOrWhiteSpace(CreditosEETextBox.Text) ||
                string.IsNullOrWhiteSpace(HSMTextBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
