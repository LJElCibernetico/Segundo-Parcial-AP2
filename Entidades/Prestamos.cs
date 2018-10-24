using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamosId { get; set; }

        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public double Capital { get; set; }
        public double InteresAnual { get; set; }
        public int TiempoMeses { get; set; }

        public virtual List<PrestamoDetalle> Detalle { get; set; }

        public Prestamos(int prestamosId, DateTime fecha, int cuentaId, double capital, double interesAnual, int tiempoMeses, List<PrestamoDetalle> detalle)
        {
            this.PrestamosId = prestamosId;
            this.Fecha = fecha;
            this.CuentaId = cuentaId;
            this.Capital = capital;
            this.InteresAnual = interesAnual;
            this.TiempoMeses = tiempoMeses;
            this.Detalle = detalle;
        }

        public Prestamos()
        {
            this.PrestamosId = 0;
            this.Fecha = DateTime.Now;
            this.CuentaId = 0;
            this.Capital = 0;
            this.InteresAnual = 0;
            this.TiempoMeses = 0;
            Detalle = new List<PrestamoDetalle>();
        }
    }
}
