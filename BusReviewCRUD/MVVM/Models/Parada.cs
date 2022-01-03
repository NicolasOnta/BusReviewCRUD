using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD.MVVM.Models
{
    class Parada
    {
        public int ParadaId { get; set; }
        public string Nombres { get; set; }
        public string Sector { get; set; }
        public decimal? Costo { get; set; }
        public string IdBus { get; set; }
    }
}
