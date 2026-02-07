using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2
{
    public class ConsultaSxI
    {
        #region Propiedades 
        public int IDServicioInventario { get; set; }

        public int IDServicio { get; set; }

        public string NomServicio { get; set; }

        public int IDInventario { get; set; }

        public string NomInventario { get; set; }

        public int CantidadUsada { get; set; }

        public string UnidadXmedida { get; set; }


        #endregion

        #region Constructor
        public ConsultaSxI()
        {
            IDServicioInventario = 0;
            IDServicio = 0;
            NomServicio = string.Empty;
            IDInventario = 0;
            NomInventario = string.Empty;
            CantidadUsada = 0;
            UnidadXmedida = string.Empty;

        }
        #endregion

    }
}
