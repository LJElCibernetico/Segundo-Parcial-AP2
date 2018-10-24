using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Deposito { get; set; }
        public DbSet<CuentasBancarias> Cuenta { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
