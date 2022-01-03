using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD.MVVM.Models
{
    class Bus
    {
        public string Placa { get; set; }
        public string Nombres_Chofer { get; set; }
        public string Nombres_Asistente { get; set; }
        public string Correo_Chofer { get; set; }
        public string Correo_Asistente { get; set; }
        public string Cedula_Chofer { get; set; }
        public string Cedula_Asistente { get; set; }
        public string Marca { get; set; }
        public string Cooperativa { get; set; }
        public bool Wifi { get; set; }
        public bool TV { get; set; }
        public bool Baño { get; set; }
        public bool Asientos_discapacitados { get; set; }
    }
}
