using SGC.Auxiliares;
using SGC.Modelo;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace SGC.Vista
{
    public partial class RegistroDocente : Window
    {
        public RegistroDocente()
        {
            InitializeComponent();
        }

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    MessageBox.Show("Corrija los errores antes de continuar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string _contrasenaHash = ContrasenaHash(ContrasenaPasswordBox.Password);

                using (var context = new SistemaGeneracionConstanciasEntities())
                {
                    var nuevoDocente = new Docente
                    {
                        Usuario = new Usuario
                        {
                            Nombre = NombreTextBox.Text,
                            Apellidos = ApellidosTextBox.Text,
                            Correo = CorreoTextBox.Text,
                            NombreUsuario = NombreUsuarioTextBox.Text,
                            NumeroPersonal = NumeroPersonalTextBox.Text,
                            Sede = SedeTextBox.Text,
                            Contraseña = _contrasenaHash
                        },

                        Contratacion = ContratacionComboBox.Text,
                        Categoria = CategoriaComboBox.Text
                    };

                    context.Docente.Add(nuevoDocente);
                    context.SaveChanges();
                }

                MessageBox.Show("Docente registrado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el docente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarCampos()
        {
            var validador = new Validadores();
            bool isValid = true;

            string mensajeError = "";
            isValid &= validador.ValidarCampoVacio(NombreTextBox.Text, ref mensajeError, "Campo vacío");
            ErrorNombreTextBlock.Text = mensajeError;

            isValid &= validador.ValidarCampoVacio(ApellidosTextBox.Text, ref mensajeError, "Campo vacío");
            ErrorApellidosTextBlock.Text = mensajeError;

            isValid &= validador.ValidarNumeroPersonal(NumeroPersonalTextBox.Text, ref mensajeError);
            ErrorNumeroPersonalTextBlock.Text = mensajeError;

            isValid &= validador.ValidarCorreo(CorreoTextBox.Text, ref mensajeError);
            ErrorCorreoTextBlock.Text = mensajeError;

            isValid &= validador.ValidarCampoVacio(NombreUsuarioTextBox.Text, ref mensajeError, "Campo vacío");
            ErrorNombreUsuarioTextBlock.Text = mensajeError;

            isValid &= validador.ValidarCampoVacio(ContrasenaPasswordBox.Password, ref mensajeError, "Campo vacío");
            ErrorContrasenaTextBlock.Text = mensajeError;

            isValid &= validador.ValidarCampoVacio(SedeTextBox.Text, ref mensajeError, "Campo vacío");
            ErrorSedeTextBlock.Text = mensajeError;

            isValid &= validador.ValidarComboBox(ContratacionComboBox.Text, ref mensajeError, "Seleccione una opción válida");
            ErrorContratacionTextBlock.Text = mensajeError;

            isValid &= validador.ValidarComboBox(CategoriaComboBox.Text, ref mensajeError, "Seleccione una opción válida");
            ErrorCategoriaTextBlock.Text = mensajeError;

            return isValid;
        }

        private string ContrasenaHash(string contrasena)
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

        private void LimpiarFormulario()
        {
            NombreTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            NumeroPersonalTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContrasenaPasswordBox.Password = string.Empty;
            SedeTextBox.Text = string.Empty;
            ContratacionComboBox.SelectedIndex = -1;
            CategoriaComboBox.SelectedIndex = -1;

            ErrorNombreTextBlock.Text = string.Empty;
            ErrorApellidosTextBlock.Text = string.Empty;
            ErrorNumeroPersonalTextBlock.Text = string.Empty;
            ErrorCorreoTextBlock.Text = string.Empty;
            ErrorNombreUsuarioTextBlock.Text = string.Empty;
            ErrorContrasenaTextBlock.Text = string.Empty;
            ErrorSedeTextBlock.Text = string.Empty;
            ErrorContratacionTextBlock.Text = string.Empty;
            ErrorCategoriaTextBlock.Text = string.Empty;
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaMenuPersonalAdministrativo = new MenuPersonalAdministrativo();
            ventanaMenuPersonalAdministrativo.Show();
            this.Close();
        }
    }
}
