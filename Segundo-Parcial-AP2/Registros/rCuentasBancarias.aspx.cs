using BLL;
using Entidades;
using System;
using System.Web.UI;

namespace Segundo_Parcial_AP2.Registros
{
    public partial class rCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> rb = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias c = rb.Buscar(int.Parse(TextBoxCuentaID.Text));
            if (c != null)
            {
                TextBoxFecha.Text = c.Fecha.ToString("yyyy-MM-dd");
                TextBoxNombre.Text = c.Nombre;
                TextBoxBalance.Text = c.Balance.ToString();
            }
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        private void ClearALL()
        {
            TextBoxCuentaID.Text = string.Empty;
            TextBoxFecha.Text = string.Empty;
            TextBoxNombre.Text = string.Empty;
            TextBoxBalance.Text = string.Empty;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<CuentasBancarias> rb = new RepositorioBase<CuentasBancarias>();

                int.TryParse(TextBoxCuentaID.Text, out int id);

                if (id == 0)
                {
                    if (rb.Guardar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Cuenta Bancaria Guardada')", true);
                    ClearALL();
                }
                else
                {
                    if (rb.Modificar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Cuenta Bancaria Modificada')", true);
                    ClearALL();
                }
            }
        }

        private CuentasBancarias LlenaClase()
        {
            int id;
            if (TextBoxCuentaID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxCuentaID.Text);
            return new CuentasBancarias(
                id,
                DateTime.Parse(TextBoxFecha.Text),
                TextBoxNombre.Text
                );
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> rb = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias c = rb.Buscar(int.Parse(TextBoxCuentaID.Text));

            if (c != null)
            {
                rb.Eliminar(int.Parse(TextBoxCuentaID.Text));
                ClearALL();
            }
        }
    }
}