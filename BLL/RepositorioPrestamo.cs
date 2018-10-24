using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioPrestamo : RepositorioBase<Prestamos>
    {
        public override Prestamos Buscar(int id)
        {
            return base.Buscar(id);
        }

        public override bool Eliminar(int id)
        {
            return base.Eliminar(id);
        }

        public override bool Guardar(Prestamos entity)
        {
            CuentasBancarias Cuenta = new CuentasBancarias();

            Cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            Cuenta.Balance += entity.Capital;
            _contexto.Entry(Cuenta).State = EntityState.Modified;

            bool paso = base.Guardar(entity);

            return paso;
        }

        public override bool Modificar(Prestamos entity)
        {
            return base.Modificar(entity);
        }
    }
}
