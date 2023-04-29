<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_Grados.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_Grados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE GRADOS"></asp:Label><br/><br/>
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="Agregar Grado"></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="ID del estudiante:"></asp:Label>               
               <asp:DropDownList id="ddl_IdEstudiantes" runat="server" AutoPostBack="true" ></asp:DropDownList>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="ID del curso:"></asp:Label>               
               <asp:DropDownList id="ddl_IdCursos" runat="server" AutoPostBack="true" ></asp:DropDownList>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="Grado:"></asp:Label>
                <asp:TextBox ID="TxtGrado" runat="server"></asp:TextBox>
                <br/>
                <asp:Label ID="Label5" runat="server" Text="Comentario:"></asp:Label>
                <asp:TextBox ID="TxtComentario" runat="server"></asp:TextBox>
                
                <br/>
                <br/>
                <asp:Button ID="btnInsertarGrado" runat="server" Text="Insertar Grado" OnClick="btnInsertarGrado_Click" /> ||
                <asp:Button ID="btnInsertarGrado_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarGrado_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label9" runat="server" Text="Editar Grado"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="Grado"></asp:Label>
                 <asp:DropDownList id="ddl_Grado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Grado_SelectedIndexChanged"></asp:DropDownList>
                             <br/>
                <asp:Label ID="Label6" runat="server" Text="Grado"></asp:Label>
                 <asp:DropDownList id="ddl_editar_Estudiantes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Grado_SelectedIndexChanged"></asp:DropDownList>
                             <br/>
                <asp:Label ID="Label7" runat="server" Text="Grado"></asp:Label>
                 <asp:DropDownList id="ddl_editar_Cursos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Grado_SelectedIndexChanged"></asp:DropDownList>                            <                             
                    <br/>
                    <asp:Label ID="Label14" runat="server" Text="Grado:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Grado" runat="server"></asp:TextBox>
                    <br/>
                    <asp:Label ID="Label15" runat="server" Text="Comentario:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Comentario" runat="server"></asp:TextBox>
                    
                <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar grado" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEditar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEditar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                 <asp:Label ID="Label17" runat="server" Text="ELIMINAR Grado"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="Grado"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarGrado" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar grado" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="Consultar Grados"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVGrados" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>
</asp:Content>
