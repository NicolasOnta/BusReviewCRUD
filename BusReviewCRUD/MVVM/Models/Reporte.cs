using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD.MVVM.Models
{
    class Reporte
    {
        public int ReporteId { get; set; }
        public bool Mala_Conduccion { get; set; }
        public bool Acoso { get; set; }
        public string Nota { get; set; }
        public string IdBus { get; set; }
        public int IdUsuario { get; set; }
    }
}
