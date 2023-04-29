<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_CursoEstudiante.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_CursoEstudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style="background-color:dimgray; color:white">
    <div>
         <h4 style="color:#0B4C89">
            <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE CURSOS DE ESTUDIANTES"></asp:Label><br/><br/><h4 />
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="Asignar curso a estudiante"></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="Estudiantes"></asp:Label>
                 <asp:DropDownList id="ddl_Estudiantes" runat="server" AutoPostBack="true" ></asp:DropDownList>
                <br/>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="Cursos"></asp:Label>
                 <asp:DropDownList id="ddl_Cursos" runat="server" AutoPostBack="true" ></asp:DropDownList>
                
                <br/>
                <br/>
                <asp:Button ID="btnInsertarCursoEstudiante" runat="server" Text="Insertar curso a estudiante" OnClick="btnInsertarCursoEstudiante_Click" /> ||
                <asp:Button ID="btnInsertarCursoEstudiante_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarCursoEstudiante_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label6" runat="server" Text="Cédula del estudiante: "></asp:Label>
                 <asp:TextBox ID="TxtEditarCedula_Curso" runat="server"></asp:TextBox> ||
                 <asp:Button ID="btnBuscarCedula" runat="server" Text="Buscar" OnClick="btnBuscarCedula_Click" />

                 <br/>
                 <br/>
                 <asp:Label ID="Label9" runat="server" Text="Editar curso a estudiante"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="Estudiante"></asp:Label>
                 <asp:DropDownList id="ddl_Editar_Estudiante" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Editar_Estudiante_SelectedIndexChanged"></asp:DropDownList>
                 <br/><br/>
                <asp:Label ID="Label7" runat="server" Text="Cursos actuales:"></asp:Label>
                 <asp:DropDownList id="ddl_EditarCursosActuales" runat="server" AutoPostBack="true"></asp:DropDownList>
                 <br/><br/>
                 <asp:Label ID="Label4" runat="server" Text="Cursos"></asp:Label>
                 <asp:DropDownList id="ddl_Editar_Curso" runat="server" AutoPostBack="true"></asp:DropDownList>
                 <br/>
                   <br/>
                <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar curso a estudiante" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEdittar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEdittar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                <asp:Label ID="Label11" runat="server" Text="Cédula del estudiante: "></asp:Label>
                 <asp:TextBox ID="TxtEliminar_Curso" runat="server"></asp:TextBox> ||
                 <asp:Button ID="btnBuscarEliminarCurso" runat="server" Text="Buscar" OnClick="btnBuscarEliminarCurso_Click" />

                 <asp:Label ID="Label17" runat="server" Text="Eliminar curso a estudiante"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="ID estudiante:"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarEstudiante" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/><br /><br />
                <asp:Label ID="Label5" runat="server" Text="ID Curso:"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarCurso" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/><br /><br />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar curso a estudiante" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="CONSULTAR Estudiantes con sus cursos"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVCurEstu" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>

</asp:Content>

