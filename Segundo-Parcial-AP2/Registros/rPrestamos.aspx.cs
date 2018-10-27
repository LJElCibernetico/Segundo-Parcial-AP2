using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Segundo_Parcial_AP2.Registros
{
    public partial class rPrestamos : System.Web.UI.Page
    {
        public bool active { get; set; }
        List<PrestamoDetalle> detalle = new List<PrestamoDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListCuentas();
                ViewState.Add("Detalle", detalle);
                ViewState.Add("Active", active);
            }
            else
            {
                detalle = (List<PrestamoDetalle>)ViewState["Detalle"];
                active = (bool)ViewState["Active"];
            }


            TextBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            detalle.Clear();
            int tiempo = int.Parse(TextBoxTiempoMeses.Text);
            decimal tasa = (Decimal.Parse(TextBoxInteresAnual.Text) / 100);
            decimal cuota = Decimal.Parse(TextBoxCapital.Text) * (tasa / 12) / (decimal)(1 - Math.Pow((double)(1 + (tasa / 12)), -tiempo));
            decimal capital = Decimal.Parse(TextBoxCapital.Text);
            decimal totalC = 0, totalI = 0;

            for (int i = 1; i <= int.Parse(TextBoxTiempoMeses.Text); ++i)
            {
                PrestamoDetalle pd = new PrestamoDetalle();
                pd.PrestamoId = int.Parse(TextBoxPrestamoID.Text);
                pd.numCuota = i;
                pd.Valor = Math.Round(cuota, 2);
                pd.Interes = decimal.Round(capital * (tasa / 12), 2);
                pd.Capital = decimal.Round(cuota - pd.Interes, 2);
                pd.Balance = decimal.Round(capital - pd.Capital, 2);
                capital = pd.Balance;

                totalC += pd.Capital;
                totalI += pd.Interes;

                detalle.Add(pd);
            }
            CuotasGridView.DataSource = detalle.ToList();
            CuotasGridView.DataBind();
            ViewState["Detalle"] = detalle;
            TextBoxCapitalTotal.Text = Decimal.Floor(totalC).ToString();
            TextBoxInteresTotal.Text = totalI.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Cuotas calculadas')", true);
            _Visible();
        }

        private void ListCuentas()
        {
            RepositorioBase<CuentasBancarias> rep = new RepositorioBase<CuentasBancarias>();
            CuentasDropDownList.DataSource = rep.GetList(x => true);
            CuentasDropDownList.DataValueField = "CuentaId";
            CuentasDropDownList.DataTextField = "Nombre";
            CuentasDropDownList.DataBind();
            CuentasDropDownList.Items.Insert(0, new ListItem("", ""));
        }


        private void _Visible()
        {
            TextBoxCapitalTotal.Visible = true;
            TextBoxInteresTotal.Visible = true;
            ButtonNuevo.Visible = true;
            ButtonGuardar.Visible = true;
            ButtonEliminar.Visible = true;
            ButtonImprimir.Visible = true;
        }

        private void Invisible()
        {
            TextBoxCapitalTotal.Visible = false;
            TextBoxInteresTotal.Visible = false;
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
            TextBoxCapitalTotal.Text = String.Empty;
            TextBoxInteresTotal.Text = String.Empty;
            CuentasDropDownList.DataTextField = String.Empty;
            CuotasGridView.DataSource = null;
            CuotasGridView.DataBind();
            active = false;
            ViewState["Active"] = active;
            Invisible();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();

            if (int.Parse(TextBoxPrestamoID.Text) == 0)
            {
                if (rep.Guardar(LlenarClase()))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo Guardado')", true);
                    ClearAll();
                }
            }
            else
            {
                if (rep.Modificar(LlenarClase()))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo Modificado')", true);
                    ClearAll();
                }
            }

        }


        private Prestamos LlenarClase()
        {
            var Entidad = new Prestamos();

            Entidad.PrestamosId = int.Parse(TextBoxPrestamoID.Text);
            Entidad.Fecha = Convert.ToDateTime(TextBoxFecha.Text);
            Entidad.CuentaId = int.Parse(CuentasDropDownList.SelectedItem.Value);
            Entidad.Capital = decimal.Parse(TextBoxCapital.Text);
            Entidad.InteresAnual = decimal.Parse(TextBoxInteresAnual.Text);
            Entidad.TiempoMeses = int.Parse(TextBoxTiempoMeses.Text);
            Entidad.CapitaTotal = decimal.Parse(TextBoxCapitalTotal.Text);
            Entidad.InteresTotal = decimal.Parse(TextBoxInteresTotal.Text);
            Entidad.Total = decimal.Parse(TextBoxCapitalTotal.Text) + decimal.Parse(TextBoxInteresTotal.Text);
            Entidad.Detalle = detalle;

            return Entidad;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();
            Prestamos prestamo = rep.Buscar(int.Parse(TextBoxPrestamoID.Text));

            if (prestamo != null)
            {
                LlenarCampos(prestamo);
                active = true;
                ViewState["Active"] = active;
                _Visible();
            }
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo no Encontrado')", true);
        }

        private void LlenarCampos(Prestamos prestamo1)
        {
            TextBoxPrestamoID.Text = prestamo1.PrestamosId.ToString();
            TextBoxFecha.Text = prestamo1.Fecha.ToString("yyyy-MM-dd");
            CuentasDropDownList.SelectedValue = prestamo1.CuentaId.ToString();
            TextBoxCapital.Text = prestamo1.Capital.ToString();
            TextBoxInteresAnual.Text = prestamo1.InteresAnual.ToString();
            TextBoxTiempoMeses.Text = prestamo1.TiempoMeses.ToString();
            TextBoxCapitalTotal.Text = prestamo1.CapitaTotal.ToString();
            TextBoxInteresTotal.Text = prestamo1.InteresTotal.ToString();
            CuotasGridView.DataSource = prestamo1.Detalle.ToList();
            CuotasGridView.DataBind();
            ViewState["Detalle"] = prestamo1.Detalle;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo rep = new RepositorioPrestamo();
            Prestamos prestamos = rep.Buscar(int.Parse(TextBoxPrestamoID.Text));

            if (prestamos != null)
            {
                if (rep.Eliminar(int.Parse(TextBoxPrestamoID.Text)))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Prestamo eliminado')", true);
                    ClearAll();
                    Invisible();
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo eliminar el prestamo')", true);
            }
        }
    }
}