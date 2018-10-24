<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="Segundo_Parcial_AP2.Registros.rPrestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <label for="TextBoxCuentaID">ID</label>
    <div class="form-row">
        <div class="form-group col-md-1">
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxPrestamoID" runat="server" placeholder="ID"></asp:TextBox>
        </div>
        <div class="btn-group-col-md-1">
            <asp:Button class="btn btn-primary" ID="ButtonBuscar" runat="server" Text="Buscar" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxFecha">Fecha</label>
            <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha"></asp:TextBox>
        </div>

        <div class="form-group col-md-7 col-md-offset-3">
            <label for="CuentasDropDownList">Cuenta</label>
            <asp:DropDownList ID="CuentasDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxCapital">Capital</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCapital" runat="server" placeholder="Capital"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxInteresAnual">Interes Anual</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxInteresAnual" runat="server" placeholder="Interes Anual"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxTiempoMeses">Tiempo en Meses</label>
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxTiempoMeses" runat="server" placeholder="Tiempo en Meses"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <asp:Button class="btn btn-success" ID="ButtonCalcular" runat="server" Text="Calcular" OnClick="ButtonCalcular_Click" />
        </div>
    </div>
    <div class="row justify-content-lg-start mt-3">
        <div class="col-lg-11">
            <asp:GridView ID="CuotasGridView" runat="server" AllowPaging="true" PageSize="12" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="numCuota" HeaderText="#Cuota" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
                    <asp:BoundField DataField="Interes" HeaderText="Interes" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="btn-block">
        <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" Visible="false" OnClick="ButtonNuevo_Click" />
        <asp:Button class="btn btn-success" ID="ButtonGuardar" runat="server" Text="Guardar" Visible="false" OnClick="ButtonGuardar_Click" />
        <asp:Button class="btn btn-danger" ID="ButtonEliminar" runat="server" Text="Eliminar" Visible="false" />
        <asp:Button class="btn btn-warning" ID="ButtonImprimir" runat="server" Text="Imprimir" Visible="false" />
    </div>
</asp:Content>
