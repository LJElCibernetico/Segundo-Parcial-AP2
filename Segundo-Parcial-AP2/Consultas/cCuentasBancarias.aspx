<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cCuentasBancarias.aspx.cs" Inherits="Segundo_Parcial_AP2.Consultas.cCuentasBancarias" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="form-group">
            <div class="row justify-content-center">
                <div class="col-md-2">
                    <label for="DropDownListFiltro">Filtro:</label>
                    <asp:DropDownList ID="DropDownListFiltro" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Balance</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-4">
                    <label for="TextBoxBuscar">Buscar:</label>
                    <asp:TextBox ID="TextBoxBuscar" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary mt-4" runat="server" OnClick="BuscarLinkButton_Click" OnPageIndexChanging="CuentaGridView_PageIndexChanging">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                </div>
            </div>

            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:GridView ID="CuentaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!-- Large modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Reporte</button>

            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Reporte de Cuentas Bancarias</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div id="div1">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <rsweb:ReportViewer ID="CuentasReportViewer" Width="100%" runat="server"></rsweb:ReportViewer>
                            </div>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
