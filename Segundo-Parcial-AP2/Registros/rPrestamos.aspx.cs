using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Segundo_Parcial_AP2.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        private RepositorioBase<Prestamos> prestamo = new RepositorioBase<Prestamos>();
        private RepositorioBase<CuentasBancarias> cuenta = new RepositorioBase<CuentasBancarias>();
        private RepositorioBase<PrestamoDetalle> cuotas = new RepositorioBase<PrestamoDetalle>();
        private RepositorioPrestamo bllDetalle = new RepositorioPrestamo();
        List<PrestamoDetalle> detalle = new List<PrestamoDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["visits"] == null)
                {
                    ListItem empty = new ListItem();
                    CuentasDropDownList.Items.Add(empty);

                    Expression<Func<CuentasBancarias, bool>> filter = x => true;
                    var itemCount = cuenta.GetList(filter).Count;

                    if (itemCount > 0)
                    {
                        foreach (var i in cuenta.GetList(filter))
                        {
                            ListItem list = new ListItem(i.Nombre, Convert.ToString(i.CuentaId), true);
                            CuentasDropDownList.Items.Add(list);
                        }
                        CuentasDropDownList.DataBind();
                    }
                }
            }
        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            int acu = 1;
            double Capital = double.Parse(TextBoxCapital.Text);
            double Interes = double.Parse(TextBoxInteresAnual.Text) / 1200;
            double Tiempo = double.Parse(TextBoxTiempoMeses.Text);

            double Cuota = Capital * (Interes / (double)(1 - Math.Pow(1 + (double)Interes, -Tiempo)));
            double InteresMensual = 0, AmTotal = 0, Am = 0;
            Expression<Func<Prestamos, bool>> filtro = x => true;

            for (int i = 0; i < Tiempo; ++i)
            {
                PrestamoDetalle prestamoD = new PrestamoDetalle();
                InteresMensual = Math.Round((Interes * Capital), 2);
                Capital = Math.Round(Capital - Cuota + InteresMensual, 2);

                AmTotal += Math.Round(Cuota - InteresMensual, 2);
                Am = Cuota - InteresMensual;

                prestamoD.numCuota = acu;
                prestamoD.PrestamoId = prestamo.GetList(filtro).Count + 1;
                prestamoD.Valor = Math.Round((decimal)Cuota, 2);
                prestamoD.Capital = Math.Round((decimal)Am, 2);
                prestamoD.Interes = Math.Round((decimal)InteresMensual, 2);
                if (i == Tiempo - 1)
                {
                    decimal Aux = Math.Round((decimal)Capital, MidpointRounding.AwayFromZero);
                    if (Aux == 0)
                        prestamoD.Balance = (decimal)0.00;
                }
                else
                    prestamoD.Balance = Math.Round((decimal)Capital, 2);
                cuotas.Guardar(prestamoD);
                detalle.Add(prestamoD);
                ++acu;
            }
            CuotasGridView.DataSource = detalle;
            CuotasGridView.DataBind();
            visible();
        }

        private void visible()
        {
            ButtonNuevo.Visible = true;
            ButtonGuardar.Visible = true;
            ButtonEliminar.Visible = true;
            ButtonImprimir.Visible = true;
        }

        private void invisible()
        {
            ButtonNuevo.Visible = false;
            ButtonGuardar.Visible = false;
            ButtonEliminar.Visible = false;
            ButtonImprimir.Visible = false;
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TextBoxCapital.Text = String.Empty;
            TextBoxFecha.Text = String.Empty;
            TextBoxInteresAnual.Text = String.Empty;
            TextBoxPrestamoID.Text = String.Empty;
            TextBoxTiempoMeses.Text = String.Empty;
            CuentasDropDownList.DataTextField = string.Empty;
            CuotasGridView.Visible = true;
            CuotasGridView.DataBind();
            invisible();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxPrestamoID.Text))
            {
                bllDetalle.Guardar(LlenarClase());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Se guardo el Prestamo.')", true);
            }
            else
            {
                Prestamos prestamo1 = prestamo.Buscar(int.Parse(TextBoxPrestamoID.Text));

                prestamo1.Fecha = DateTime.Parse(TextBoxFecha.Text);
                prestamo1.CuentaId = int.Parse(CuentasDropDownList.SelectedItem.Value);
                prestamo1.Capital = double.Parse(TextBoxCapital.Text);
                prestamo1.InteresAnual = double.Parse(TextBoxInteresAnual.Text);
                prestamo1.TiempoMeses = int.Parse(TextBoxTiempoMeses.Text);
                prestamo1.Detalle = detalle;

                prestamo.Modificar(prestamo1);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Se modifico el prestamo.')", true);
            }
            ClearAll();
        }

        private Prestamos LlenarClase()
        {
            var Entidad = new Prestamos();

            Entidad.Fecha = Convert.ToDateTime(TextBoxFecha.Text);
            Entidad.CuentaId = int.Parse(CuentasDropDownList.SelectedItem.Value);
            Entidad.Capital = double.Parse(TextBoxCapital.Text);
            Entidad.InteresAnual = double.Parse(TextBoxInteresAnual.Text);
            Entidad.TiempoMeses = int.Parse(TextBoxTiempoMeses.Text);
            Entidad.Detalle = detalle;

            return Entidad;
        }
    }
}