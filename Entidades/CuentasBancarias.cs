using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentasBancarias
    {
        [Key]
        public int CuentaId { get; set; }

        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public double Balance { get; set; }

        public CuentasBancarias(int cuentaId, DateTime fecha, string nombre)
        {
            CuentaId = cuentaId;
            Fecha = fecha;
            Nombre = nombre;
        }

        public CuentasBancarias()
        {
            CuentaId = 0;
            Fecha = DateTime.Now;
            Nombre = String.Empty;
            Balance = 0;
        }
    }
}
