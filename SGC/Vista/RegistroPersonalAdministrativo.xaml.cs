using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using SGC.Modelo;

namespace SGC.Vista
{
    /// <summary>
    /// Lógica de interacción para RegistroPersonalAdministrativo.xaml
    /// </summary>
    public partial class RegistroPersonalAdministrativo : Window
    {
        private string _contrasenaHash;
        public RegistroPersonalAdministrativo()
        {
            InitializeComponent();
        }

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                {
                    return;
                }

                _contrasenaHash = contrasenaHash(ContrasenaPasswordBox.Password);
                using (var context = new SistemaGeneracionConstanciasEntities())
                {
                    var nuevoPersonalAdministrativo = new PersonalAdministrativo
                    {
                        RFC = RfcTextBox.Text,
                        Usuario = new Usuario
                        {
                            Nombre = NombreTextBox.Text,
                            Apellidos = ApellidosTextBox.Text,
                            Correo = CorreoTextBox.Text,
                            NombreUsuario = NombreUsuarioTextBox.Text,
                            Contraseña = _contrasenaHash,
                            Sede = SedeTextBox.Text,
                            NumeroPersonal = NumeroPersonalTextBox.Text
                        }
                    };

                    context.PersonalAdministrativo.Add(nuevoPersonalAdministrativo);
                    context.SaveChanges();

                    MessageBox.Show("El personal administrativo se ha registrado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaInicio = new MainWindow();
            ventanaInicio.Show();
            this.Close();
        }

        private void LimpiarFormulario()
        {
            NombreTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContrasenaPasswordBox.Password = string.Empty;
            RfcTextBox.Text = string.Empty;
            SedeTextBox.Text = string.Empty;
            NumeroPersonalTextBox.Text = string.Empty;
        }


        private string contrasenaHash(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] contrasenaBytes = Encoding.UTF8.GetBytes(contrasena);

                byte[] hashBytes = sha256.ComputeHash(contrasenaBytes);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(ApellidosTextBox.Text) ||
                string.IsNullOrWhiteSpace(CorreoTextBox.Text) ||
                string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContrasenaPasswordBox.Password) ||
                string.IsNullOrWhiteSpace(RfcTextBox.Text) ||
                string.IsNullOrWhiteSpace(SedeTextBox.Text) ||
                string.IsNullOrWhiteSpace(NumeroPersonalTextBox.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!CorreoTextBox.Text.Contains("@"))
            {
                MessageBox.Show("El correo ingresado no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
