using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Segundo_Parcial_AP2.Consultas
{
    public partial class cCuentasBancarias : System.Web.UI.Page
    {
        BLL.RepositorioBase<CuentasBancarias> repositorio = new BLL.RepositorioBase<CuentasBancarias>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CuentasReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CuentasReportViewer.Reset();

                CuentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReporteCuentas.rdlc");

                CuentasReportViewer.LocalReport.DataSources.Clear();

                CuentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Cuentas", repositorio.GetList(x => true)));
                CuentasReportViewer.LocalReport.Refresh();
            }
        }

        Expression<Func<CuentasBancarias, bool>> filtro = x => true;
        protected void CuentaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<CuentasBancarias> rb = new RepositorioBase<CuentasBancarias>();
            CuentaGridView.DataSource = rb.GetList(filtro);
            CuentaGridView.PageIndex = e.NewPageIndex;
            CuentaGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> rep = new RepositorioBase<CuentasBancarias>();
            int dato = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://CuentaId
                    dato = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.CuentaId == dato);
                    break;

                case 2://Fecha
                    filtro = (x => x.Fecha.Equals(TextBoxBuscar.Text));
                    break;

                case 3://Nombre
                    filtro = (x => x.Nombre.Contains(TextBoxBuscar.Text));
                    break;

                case 4://Balance
                    decimal balance = decimal.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Balance == balance);
                    break;
            }
            CuentaGridView.DataSource = rep.GetList(filtro);
            CuentaGridView.DataBind();
        }
    }
}