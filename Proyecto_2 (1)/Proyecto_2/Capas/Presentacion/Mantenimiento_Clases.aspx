<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_Clases.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_Clases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE CLASES"></asp:Label><br/><br/>
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="AGREGAR CLASE"></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="ID de la escuela:"></asp:Label>
               
                
               <asp:DropDownList id="ddl_IdEscuela" runat="server" AutoPostBack="true" ></asp:DropDownList>
               
                <br/>
                <asp:Label ID="Label3" runat="server" Text="Nombre de la clase:"></asp:Label>
                <asp:TextBox ID="TxtNombreClase" runat="server"></asp:TextBox>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Button ID="btnInsertarClase" runat="server" Text="Insertar Clase" OnClick="btnInsertarClase_Click" /> ||
                <asp:Button ID="btnInsertarClase_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarClases_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label9" runat="server" Text="EDITAR CLASE"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="Clases"></asp:Label>
                 <asp:DropDownList id="ddl_Clases" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddl_Clases_SelectedIndexChanged" ></asp:DropDownList>
                 
                             <br/>
                    <br/>
                    <asp:Label ID="Label5" runat="server" Text="Escuela: "></asp:Label>
                    <asp:DropDownList id="ddl_Editar_Escuela" runat="server" AutoPostBack="true"  ></asp:DropDownList>
                    <br/>
                    <asp:Label ID="Label13" runat="server" Text="Nombre de Clase:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_NombreClase" runat="server"></asp:TextBox>
                    <br/> 
                    <asp:Label ID="Label14" runat="server" Text="Descripcion:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Descripcion" runat="server"></asp:TextBox>
                    <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar escuela" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEditar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEditar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                 <asp:Label ID="Label17" runat="server" Text="ELIMINAR Clase"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="Clases"></asp:Label>
                <asp:DropDownList id="ddl_EliminarCLases" runat="server" AutoPostBack="True" ></asp:DropDownList>
                <br/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar clases" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="CONSULTAR Clases"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVClases" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>
</asp:Content>
