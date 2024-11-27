using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Auxiliares
{
    public class SesionDocente
    {
        private static SesionDocente _instance;

        private static readonly object _lock = new object();

        public int DocenteID { get; private set; }
        public string NumeroPersonal { get; private set; }
        public int UsuarioID { get; private set; }
        public string Nombre { get; private set; }
        public string Apellidos { get; private set; }
        public string Sede { get; private set; }

        private SesionDocente() { }

        public static SesionDocente Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SesionDocente();
                    }
                    return _instance;
                }
            }
        }

        public void SetSesionDocente(int docenteID, string numeroPersonal, int usuarioID, string nombre, string apellidos, string sede)
        {
            DocenteID = docenteID;
            NumeroPersonal = numeroPersonal;
            UsuarioID = usuarioID;
            Nombre = nombre;
            Apellidos = apellidos;
            Sede = sede;
        }

    }

}
