using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioPrestamo : RepositorioBase<Prestamos>
    {
        public override Prestamos Buscar(int id)
        {
            Prestamos prestamo = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamosId == id)
                                 .FirstOrDefault();
            return prestamo; 
        }

        public override bool Eliminar(int id)
        {
            Prestamos prestamo = Buscar(id);
            CuentasBancarias cuenta = _contexto.Cuenta.Find(prestamo.CuentaId);
            cuenta.Balance -= prestamo.Total;
            _contexto.Entry(cuenta).State = EntityState.Modified;
            return base.Eliminar(id);
        }

        public override bool Guardar(Prestamos prestamo)
        {
            CuentasBancarias cuenta = _contexto.Cuenta.Find(prestamo.CuentaId);
            cuenta.Balance += prestamo.Total;
            _contexto.Entry(cuenta).State = EntityState.Modified;

            return base.Guardar(prestamo);
        }

        public override bool Modificar(Prestamos entity)
        {
            Prestamos prestamo1 = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamosId == entity.PrestamosId)
                                 .AsNoTracking()
                                 .FirstOrDefault();

            var prestamoAnt = prestamo1;
            var cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            cuenta.Balance -= prestamoAnt.Total;
            _contexto.Entry(cuenta).State = EntityState.Modified;

            foreach (var item in prestamoAnt.Detalle)
                _contexto.Entry(item).State = EntityState.Deleted;


            foreach (var item in entity.Detalle)
                _contexto.Entry(item).State = (item.PrestamoDetalleId == 0) ? EntityState.Added : EntityState.Modified;

            cuenta.Balance += entity.Total;
            _contexto.Entry(cuenta).State = EntityState.Modified;

            return base.Modificar(entity);
        }

        public override List<Prestamos> GetList(Expression<Func<Prestamos, bool>> expression)
        {
            var lista = _contexto.Prestamo.Include(x => x.Detalle).Where(expression).ToList();
            return lista;
        }
    }
}
