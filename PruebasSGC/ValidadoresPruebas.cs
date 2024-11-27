using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGC.Auxiliares;

namespace Pruebas
{
    [TestClass]
    public class ValidadoresPruebas
    {
        private readonly Validadores _validador;

        public ValidadoresPruebas()
        {
            _validador = new Validadores();
        }

        [TestMethod]
        public void ValidarCampoVacio_ValorVacio_DebeRetornarFalse()
        {
            string valor = "";
            string mensajeError = "";

            bool resultado = _validador.ValidarCampoVacio(valor, ref mensajeError, "Campo vacío");

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarCampoVacio_ValorLleno_DebeRetornarTrue()
        {
            string valor = "Texto";
            string mensajeError = "";

            bool resultado = _validador.ValidarCampoVacio(valor, ref mensajeError, "Campo vacío");

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarNumeroPersonal_NumeroValido_DebeRetornarTrue()
        {
            string numero = "12345";
            string mensajeError = "";

            bool resultado = _validador.ValidarNumeroPersonal(numero, ref mensajeError);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarNumeroPersonal_NumeroInvalido_DebeRetornarFalse()
        {
            string numero = "12A45";
            string mensajeError = "";

            bool resultado = _validador.ValidarNumeroPersonal(numero, ref mensajeError);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarCorreo_CorreoValido_DebeRetornarTrue()
        {
            string correo = "test@correo.com";
            string mensajeError = "";

            bool resultado = _validador.ValidarCorreo(correo, ref mensajeError);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarCorreo_CorreoInvalido_DebeRetornarFalse()
        {
            string correo = "correo_invalido";
            string mensajeError = "";

            bool resultado = _validador.ValidarCorreo(correo, ref mensajeError);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarPassword_PasswordValida_DebeRetornarTrue()
        {
            string password = "123456";
            string mensajeError = "";

            bool resultado = _validador.ValidarPassword(password, ref mensajeError);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarPassword_PasswordInvalida_DebeRetornarFalse()
        {
            string password = "123";
            string mensajeError = "";

            bool resultado = _validador.ValidarPassword(password, ref mensajeError);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarComboBox_OpcionSeleccionada_DebeRetornarTrue()
        {
            string comboBoxTexto = "Opción válida";
            string mensajeError = "";

            bool resultado = _validador.ValidarComboBox(comboBoxTexto, ref mensajeError, "Seleccione una opción válida");

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarComboBox_OpcionNoSeleccionada_DebeRetornarFalse()
        {
            string comboBoxTexto = "";
            string mensajeError = "";

            bool resultado = _validador.ValidarComboBox(comboBoxTexto, ref mensajeError, "Seleccione una opción válida");

            Assert.IsFalse(resultado);
        }
    }
}
