<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_Escuela.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_Escuela" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<body style="background-color:dimgray; color:white">   
    <div >
		<h3 style="color:#0B4C89">
		<asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE ESCUELAS"></asp:Label><br/><br/></h3>
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="Agregar escuela "></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="Nombre de la escuela:"></asp:Label> 
                <asp:TextBox ID="TxtNombreEscuela" runat="server"></asp:TextBox>
                <br/>
				<br />
                <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label>
                <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
                <br/>
				<br />
                <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
                <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                <br/>
				<br />
                <asp:Label ID="Label5" runat="server" Text="Teléfono:"></asp:Label>
                <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                <br/>
				<br />
                <asp:Label ID="Label6" runat="server" Text="Código postal:"></asp:Label>
                <asp:TextBox ID="TxtCodigoPostal" runat="server"></asp:TextBox>
                <br/>
				<br />
                <asp:Label ID="Label7" runat="server" Text="Dirección postal:"></asp:Label>
                <asp:TextBox ID="TxtDireccionPostal" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Button ID="btnInsertarEscuela" runat="server" Text="Insertar escuela" OnClick="btnInsertarEscuela_Click" /> ||
                <asp:Button ID="btnInsertarEscuela_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarEscuela_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label9" runat="server" Text="EDITAR ESCUELA"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="Escuelas"></asp:Label>
                 <asp:DropDownList id="ddl_Escuelas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Escuelas_SelectedIndexChanged"></asp:DropDownList>
                             <br/>
                             <br/>
                             <br/>
                 <asp:Label ID="Label11" runat="server" Text="Nombre de la escuela:"></asp:Label>
                 <asp:TextBox ID="TxtEditar_NombreEscuela" runat="server"></asp:TextBox>
                 <br/>
                    <asp:Label ID="Label12" runat="server" Text="Descripción:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Descripcion" runat="server"></asp:TextBox>
                    <br/>
                    <asp:Label ID="Label13" runat="server" Text="Dirección:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Direccion" runat="server"></asp:TextBox>
                    <br/>
                    <asp:Label ID="Label14" runat="server" Text="Teléfono:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Telefono" runat="server"></asp:TextBox>
                    <br/>
                    <asp:Label ID="Label15" runat="server" Text="Código postal:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_CodigoPostal" runat="server"></asp:TextBox>
                    <br/>
                    <asp:Label ID="Label16" runat="server" Text="Dirección postal:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_DireccionPostal" runat="server"></asp:TextBox>
                <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar escuela" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEdittar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEdittar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                 <asp:Label ID="Label17" runat="server" Text="ELIMINAR ESCUELA"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="Escuelas"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarEscula" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar escuela" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="CONSULTAR ESCUELAS"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVEscuelas" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>
        </body>
 </asp:Content>
