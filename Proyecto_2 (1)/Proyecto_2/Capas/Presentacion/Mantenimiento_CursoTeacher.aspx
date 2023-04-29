<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_CursoTeacher.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_CursoTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style="background-color:dimgray; color:white">
    <div>
         <h4 style="color:#0B4C89">
            <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE CURSOS DE PROFESORES"></asp:Label><br/><br/><h4 />
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="Asignar curso a Profesor"></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="ID del Profesor:"></asp:Label>
                <asp:TextBox ID="TxtIdProfesor" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="ID Curso:"></asp:Label>
                <asp:TextBox ID="TxtIdCurso" runat="server"></asp:TextBox>
                
                <br/>
                <br/>
                <asp:Button ID="btnInsertarCursoProfesor" runat="server" Text="Insertar curso a Profesor" OnClick="btnInsertarCursoProfesor_Click" /> ||
                <asp:Button ID="btnInsertarCursoProfesor_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarCursoProfesor_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label9" runat="server" Text="Editar curso a profesor"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="profesor"></asp:Label>
                 <asp:DropDownList id="ddl_Profesor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Profesor_SelectedIndexChanged"></asp:DropDownList>
                             <br/>
                             <br/>
                             <br/>
                <asp:Label ID="Label4" runat="server" Text="ID Curso:"></asp:Label>
                <asp:TextBox ID="EditarTxtIdCurso" runat="server"></asp:TextBox>
                 <br/>
                   <br/>
                <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar curso a profesor" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEdittar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEdittar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                 <asp:Label ID="Label17" runat="server" Text="Eliminar curso a Profesor"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="ID Profesor:"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarProfesor" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/><br /><br />
                <asp:Label ID="Label5" runat="server" Text="ID Curso:"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarCurso" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/><br /><br />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar curso a profesor" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="Consultar los profesor con sus cursos"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVCurProfesor" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>
</asp:Content>
