<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentasBancarias.aspx.cs" Inherits="Segundo_Parcial_AP2.Registros.rCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <label for="TextBoxCuentaID">ID</label>
    <div class="form-row">
        <div class="form-group col-md-1">
            <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCuentaID" runat="server" placeholder="ID"></asp:TextBox>
        </div>
        <div class="btn-group-col-md-1">
            <asp:Button class="btn btn-primary" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxFecha">Fecha</label>
            <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha"></asp:TextBox>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxNombre">Nombre</label>
            <asp:TextBox class="form-control" ID="TextBoxNombre" runat="server" placeholder="Nombre" autocomplete="off" ControlToValidate="TextBoxNombre"> </asp:TextBox>

        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxBalance">Balance</label>
            <asp:TextBox class="form-control" ID="TextBoxBalance" runat="server" placeholder="Balance" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <div class="btn-block">
        <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click"/>
        <asp:Button class="btn btn-success" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click"/>
        <asp:Button class="btn btn-danger" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click"/>
    </div>
</asp:Content>
