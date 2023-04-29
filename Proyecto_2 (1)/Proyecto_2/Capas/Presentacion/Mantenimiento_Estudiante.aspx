<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_Estudiante.aspx.cs" Inherits="Proyecto_2.Capas.Presentacion.Mantenimiento_Estudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style="background-color:dimgray; color:white">
    <div>
         <h4 style="color:#0B4C89">
            <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DE ESTUDIANTES"></asp:Label><br/><br/><h4 />
            <!--PANEL PRINCIPAL DE LOS BOTONES-->
            <asp:Panel ID="PanelPrincipaL" runat="server" Visible="true">
                <asp:Button ID="btn_PanelPrincipal_Agregar" CssClass="button" runat="server" Text="Agregar" OnClick="btn_PanelPrincipal_Agregar_Click" />  ||
                <asp:Button ID="btn_PanelPrincipal_Editar" CssClass="button" runat="server" Text="Editar" OnClick="btn_PanelPrincipal_Editar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Eliminar" CssClass="button" runat="server" Text="Eliminar" OnClick="btn_PanelPrincipal_Eliminar_Click" />||
                <asp:Button ID="btn_PanelPrincipal_Consultar" CssClass="button" runat="server" Text="Consultar" OnClick="btn_PanelPrincipal_Consultar_Click" />
            </asp:Panel>

            <!--PANEL PARA AGREGAR-->
            <asp:Panel ID="PanelAgregar" runat="server" Visible="false">
                <asp:Label ID="Label8" runat="server" Text="Agregar estudiantes"></asp:Label>
                <br/><br/>
                <asp:Label ID="Label2" runat="server" Text="ID de la Clase:"></asp:Label>               
               <asp:DropDownList id="ddl_IdClase" runat="server" AutoPostBack="true" ></asp:DropDownList>
                <br/>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="Nombre del estudiante:"></asp:Label>
                <asp:TextBox ID="TxtNombreEstudiante" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="Numero de estudiante:"></asp:Label>
                <asp:TextBox ID="TxtNumeroEstudiante" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label5" runat="server" Text="Calificación total:"></asp:Label>
                <asp:TextBox ID="TxtCalificacion" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label6" runat="server" Text="Dirección:"></asp:Label>
                <asp:TextBox ID="TxtDirreccion" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label7" runat="server" Text="Teléfono:"></asp:Label>
                <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label20" runat="server" Text="Correo:"></asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Button ID="btnInsertarEstudiante" runat="server" Text="Insertar Estudiante" OnClick="btnInsertarEstudiante_Click" /> ||
                <asp:Button ID="btnInsertarEstudiante_Cancelar" runat="server" Text="Cancelar" OnClick="btnInsertarEstudiante_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA EDITAR-->
            <asp:Panel ID="PanelEditar" runat="server" Visible="false">
                 <asp:Label ID="Label9" runat="server" Text="Editar Estudiante"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label10" runat="server" Text="Estudiantes"></asp:Label>
                 <asp:DropDownList id="ddl_Estudiantes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Estudiantes_SelectedIndexChanged"></asp:DropDownList>
                             <br/>                    
                     <asp:Label ID="Label12" runat="server" Text="ID de la Clase:"></asp:Label>               
               <asp:DropDownList id="ddl_Editar_IdClase" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    <br/>
                    <br/>
                    <asp:Label ID="Label13" runat="server" Text="Nombre del estudiante:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_NombreEstudiante" runat="server"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:Label ID="Label14" runat="server" Text="Numero estudiante:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_NumeroEstudiante" runat="server"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:Label ID="Label15" runat="server" Text="Calificacion total:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Calificacion" runat="server"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:Label ID="Label16" runat="server" Text="Dirección:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Direccion" runat="server"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:Label ID="Label21" runat="server" Text="Telefono:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Telefono" runat="server"></asp:TextBox>
                     <br/>
                     <br/>
                    <asp:Label ID="Label22" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="TxtEditar_Email" runat="server"></asp:TextBox>

                <br/>
                <asp:Button ID="btnEditar" runat="server" Text="Editar Estudiante" OnClick="btnEditar_Click" /> ||
                <asp:Button ID="btnEdittar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEdittar_Cancelar_Click" />
    
        <br/>
        <br/>
            </asp:Panel>
            <!--PANEL PARA ELIMINAR-->
            <asp:Panel ID="PanelEliminar"  runat="server" Visible="false">
                 <asp:Label ID="Label17" runat="server" Text="ELIMINAR Estudiante"></asp:Label>
                 <br/><br/>
                 <asp:Label ID="Label18" runat="server" Text="Estudiante"></asp:Label>
                 <asp:DropDownList id="ddl_EliminarEstudiante" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br/>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Estudiante" OnClick="btnEliminar_Click" /> ||
                <asp:Button ID="btnEliminar_Cancelar" runat="server" Text="Cancelar" OnClick="btnEliminar_Cancelar_Click" />
            </asp:Panel>
            <!--PANEL PARA CONSULTAR-->
            <asp:Panel ID="PanelConsultar" runat="server" Visible="false">
                 <asp:Label ID="Label19" runat="server" Text="CONSULTAR Estudiante"></asp:Label>
                 <br/><br/>
                 <asp:GridView ID="GVEstudiantes" runat="server" style="width:100%;" HeaderStyle-BackColor="#F7990D" Font-Size="Medium" HeaderStyle-ForeColor="White" >
                 </asp:GridView>
                 <br/>
                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
            </asp:Panel>
        </div>
        </body>
</asp:Content>

