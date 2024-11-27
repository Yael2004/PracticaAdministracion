using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGC.Auxiliares;

namespace PruebasSGC
{
    [TestClass]
    public class SesionDocentePruebas
    {
        [TestMethod]
        public void Instance_DeberiaRetornarMismaInstancia()
        {
            var instancia1 = SesionDocente.Instance;
            var instancia2 = SesionDocente.Instance;

            Assert.AreSame(instancia1, instancia2, "Instance no retorna la misma instancia");
        }

        [TestMethod]
        public void SetSesionDocente_DeberiaActualizarPropiedades()
        {
            int docenteID = 1;
            string numeroPersonal = "12345";
            int usuarioID = 2;
            string nombre = "Juan";
            string apellidos = "Pérez";
            string sede = "Xalapa";

            SesionDocente.Instance.SetSesionDocente(docenteID, numeroPersonal, usuarioID, nombre, apellidos, sede);

            Assert.AreEqual(docenteID, SesionDocente.Instance.DocenteID);
            Assert.AreEqual(numeroPersonal, SesionDocente.Instance.NumeroPersonal);
            Assert.AreEqual(usuarioID, SesionDocente.Instance.UsuarioID);
            Assert.AreEqual(nombre, SesionDocente.Instance.Nombre);
            Assert.AreEqual(apellidos, SesionDocente.Instance.Apellidos);
            Assert.AreEqual(sede, SesionDocente.Instance.Sede);
        }

        [TestMethod]
        public void SetSesionDocente_DeberiaSobreescribirPropiedades()
        {
            int docenteID1 = 1;
            string numeroPersonal1 = "12345";
            int usuarioID1 = 2;
            string nombre1 = "Juan";
            string apellidos1 = "Pérez";
            string sede1 = "Xalapa";

            int docenteID2 = 3;
            string numeroPersonal2 = "67890";
            int usuarioID2 = 4;
            string nombre2 = "María";
            string apellidos2 = "González";
            string sede2 = "Veracruz";

            SesionDocente.Instance.SetSesionDocente(docenteID1, numeroPersonal1, usuarioID1, nombre1, apellidos1, sede1);
            SesionDocente.Instance.SetSesionDocente(docenteID2, numeroPersonal2, usuarioID2, nombre2, apellidos2, sede2);

            Assert.AreEqual(docenteID2, SesionDocente.Instance.DocenteID);
            Assert.AreEqual(numeroPersonal2, SesionDocente.Instance.NumeroPersonal);
            Assert.AreEqual(usuarioID2, SesionDocente.Instance.UsuarioID);
            Assert.AreEqual(nombre2, SesionDocente.Instance.Nombre);
            Assert.AreEqual(apellidos2, SesionDocente.Instance.Apellidos);
            Assert.AreEqual(sede2, SesionDocente.Instance.Sede);
        }
    }
}
