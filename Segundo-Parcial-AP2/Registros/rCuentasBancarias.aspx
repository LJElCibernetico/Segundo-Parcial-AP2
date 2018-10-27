<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentasBancarias.aspx.cs" Inherits="Segundo_Parcial_AP2.Registros.rCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <label for="TextBoxCuentaID">ID</label>
    <div class="form-row">
        <div class="form-group col-md-1">
            <asp:TextBox ValidationGroup="search" TextMode="Number" class="form-control" ID="TextBoxCuentaID" runat="server" placeholder="ID"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="search" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="TextBoxCuentaID" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar un id"></asp:RequiredFieldValidator>
        </div>
        <div class="btn-group-col-md-1">
            <asp:Button ValidationGroup="search" class="btn btn-primary" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
        </div>
    </div>
    <div class="row">
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxFecha">Fecha</label>
            <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha"></asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator" ControlToValidate="TextBoxFecha" runat="server" Display="Dynamic" ErrorMessage="Debe seleccionar una fecha"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxNombre">Nombre</label>
            <asp:TextBox class="form-control" ID="TextBoxNombre" runat="server" placeholder="Nombre" autocomplete="off" ControlToValidate="TextBoxNombre"> </asp:TextBox>
            <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="TextBoxNombre" runat="server" Display="Dynamic" ErrorMessage="Introduzca un Nombre"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-7 col-md-offset-3">
            <label for="TextBoxBalance">Balance</label>
            <asp:TextBox class="form-control" ID="TextBoxBalance" runat="server" placeholder="Balance" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <div class="btn-block">
        <asp:Button class="btn btn-primary" CausesValidation="false" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
        <asp:Button class="btn btn-success" ValidationGroup="save" CausesValidation="true" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
        <asp:Button class="btn btn-danger" CausesValidation="false" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" />
    </div>
</asp:Content>
