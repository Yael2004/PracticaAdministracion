using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SGC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //AbrirVentanaEE();
        }

        private void IniciarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            MostrarMensaje("");

            string usuario = UsuarioTextBox.Text.Trim();
            string contrasena = ContrasenaPasswordBox.Password.Trim();

            if (!EsEntradaValida(usuario, contrasena))
                return;

            ProcesarInicioSesion(usuario, contrasena);
        }

        private bool EsEntradaValida(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MostrarMensaje("Por favor, ingrese usuario y contraseña.");
                return false;
            }

            return true;
        }

        private void ProcesarInicioSesion(string usuario, string contrasena)
        {
            string contrasenaHash = HashContrasena(contrasena);

            try
            {
                if (AutenticarUsuario(usuario, contrasenaHash, out var usuarioEncontrado))
                {
                    if (usuarioEncontrado.Correo == ObtenerCorreoAdmin())
                    {
                        MostrarMensaje($"Bienvenido, {usuarioEncontrado.Nombre} (Administrador).");
                        AbrirVentanaAdmin();
                        return;
                    }

                    if (EsDocente(usuarioEncontrado.UsuarioID))
                    {
                        if (IniciarSesionComoDocente(usuarioEncontrado.UsuarioID))
                        {
                            MostrarMensaje($"Bienvenido, {usuarioEncontrado.Nombre} {usuarioEncontrado.Apellidos} (Docente).");
                            AbrirVentanaDocente();
                        }
                        else
                        {
                            MostrarMensaje("Error al cargar los datos del docente.");
                        }
                    }
                    else if (EsPersonalAdministrativo(usuarioEncontrado.UsuarioID))
                    {
                        MostrarMensaje($"Bienvenido, {usuarioEncontrado.Nombre} {usuarioEncontrado.Apellidos} (Personal Administrativo).");
                        AbrirVentanaAdministrativo();
                    }

                    this.Close();
                    MostrarMensajeBienvenida();
                }
                else
                {
                    MostrarMensaje("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Ocurrió un error: {ex.Message}");
            }
        }

        private string HashContrasena(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] contrasenaBytes = Encoding.UTF8.GetBytes(contrasena);
                byte[] hashBytes = sha256.ComputeHash(contrasenaBytes);

                return ConvertirBytesAHexadecimal(hashBytes);
            }
        }

        private string ConvertirBytesAHexadecimal(byte[] bytes)
        {
            StringBuilder hashString = new StringBuilder();
            foreach (byte b in bytes)
            {
                hashString.Append(b.ToString("x2"));
            }

            return hashString.ToString();
        }

        private bool AutenticarUsuario(string nombreUsuario, string contrasenaHash, out Modelo.Usuario usuarioEncontrado)
        {
            using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
            {
                usuarioEncontrado = context.Usuario
                    .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contrasenaHash);

                return usuarioEncontrado != null;
            }
        }

        private bool EsDocente(int usuarioID)
        {
            using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
            {
                return context.Docente.Any(d => d.DocenteID == usuarioID);
            }
        }

        private bool EsPersonalAdministrativo(int usuarioID)
        {
            using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
            {
                return context.PersonalAdministrativo.Any(pa => pa.PersonalAdministrativoID == usuarioID);
            }
        }

        private void AbrirVentanaDocente()
        {
            var ventanaDocentes= new Vista.MenuDocente();
            ventanaDocentes.Show();
            this.Close();
        }

        private void AbrirVentanaAdministrativo()
        {
            var ventanaAdmin = new Vista.MenuPersonalAdministrativo();
            ventanaAdmin.Show();
            this.Close();
        }

        private void AbrirVentanaAdmin()
        {
            var ventanaAdmin = new Vista.RegistroPersonalAdministrativo();
            ventanaAdmin.Show();
            this.Close();
        }

        private void MostrarMensaje(string mensaje)
        {
            MensajeError_Label.Content = mensaje;
        }

        private void MostrarMensajeBienvenida()
        {
            MessageBox.Show("Bienvenido " + UsuarioTextBox.Text);
        }

        private void MostrarContrasenaButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ContrasenaTextBox.Text = ContrasenaPasswordBox.Password;

            ContrasenaPasswordBox.Visibility = Visibility.Hidden;
            ContrasenaTextBox.Visibility = Visibility.Visible;
        }

        private void MostrarContrasenaButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ContrasenaPasswordBox.Visibility = Visibility.Visible;
            ContrasenaTextBox.Visibility = Visibility.Hidden;
        }

        private bool IniciarSesionComoDocente(int usuarioID)
        {
            try
            {
                using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
                {
                    var usuario = context.Usuario.FirstOrDefault(u => u.UsuarioID == usuarioID);
                    if (usuario == null) return false;

                    var docente = context.Docente.FirstOrDefault(d => d.DocenteID == usuarioID);
                    if (docente == null) return false;

                    SGC.Auxiliares.SesionDocente.Instance.SetSesionDocente(
                        docenteID: docente.DocenteID,                
                        numeroPersonal: usuario.NumeroPersonal,      
                        usuarioID: usuario.UsuarioID,
                        nombre: usuario.Nombre,
                        apellidos: usuario.Apellidos,
                        sede: usuario.Sede
                    );

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión como docente: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private string ObtenerCorreoAdmin()
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["AdminEmail"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el correo del administrador: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }
}
