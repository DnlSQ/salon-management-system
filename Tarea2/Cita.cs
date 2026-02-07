using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2
{
    public class Cita
    {
        #region Propiedades 
        public int IDCita { get; set; }

        public int ClienteId { get; set; }

        public string NombreCliente { get; set; }

        public int EmpleadoId { get; set; }

        public string NombreEmpleado { get; set; }

        public int ServicioId { get; set; }

        public string NombreServicio { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public string Notas { get; set; }

        #endregion

        #region Constructor
        public Cita()
        {
            IDCita = 0;
            ClienteId = 0;
            NombreCliente = string.Empty;
            EmpleadoId = 0;
            NombreEmpleado = string.Empty;
            ServicioId = 0;
            NombreServicio = string.Empty;
            Fecha = new DateTime(1, 1, 1);
            Hora = new TimeSpan(0, 0, 0);
            Notas = string.Empty;





        }
        #endregion




    }
}
