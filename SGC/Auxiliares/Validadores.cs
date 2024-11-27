using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGC.Auxiliares
{
    public class Validadores
    {
        public bool ValidarCampoVacio(string valor, ref string mensajeError, string mensajeErrorTexto)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                mensajeError = mensajeErrorTexto;
                return false;
            }
            mensajeError = string.Empty;
            return true;
        }

        public bool ValidarNumeroPersonal(string valor, ref string mensajeError)
        {
            if (!EsNumeroPersonalValido(valor))
            {
                mensajeError = "Número de personal inválido (solo números)";
                return false;
            }
            mensajeError = "";
            return true;
        }

        public bool ValidarCorreo(string valor, ref string mensajeError)
        {
            if (!EsCorreoValido(valor))
            {
                mensajeError = "Correo inválido";
                return false;
            }
            mensajeError = "";
            return true;
        }

        public bool ValidarPassword(string valor, ref string mensajeError)
        {
            if (!EsPasswordValida(valor))
            {
                mensajeError = "Contraseña inválida (mínimo 6 caracteres)";
                return false;
            }
            mensajeError = "";
            return true;
        }

        public bool EsNumeroPersonalValido(string numeroPersonal)
        {
            return Regex.IsMatch(numeroPersonal, @"^\d+$");
        }

        public bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool EsPasswordValida(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        public bool ValidarComboBox(string valor, ref string mensajeError, string mensajeErrorComboBox)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                mensajeError = mensajeErrorComboBox;
                return false;
            }
            mensajeError = "";
            return true;
        }
    }
}
