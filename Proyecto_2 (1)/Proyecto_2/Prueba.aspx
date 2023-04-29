<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="Proyecto_2.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Nombre de la escuela:"></asp:Label>
        <asp:TextBox ID="TxtNombreEscuela" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="TxtDescripcion" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="Dirección:"></asp:Label>
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label4" runat="server" Text="Teléfono:"></asp:Label>
        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label5" runat="server" Text="Código postal:"></asp:Label>
        <asp:TextBox ID="TxtCodigoPostal" runat="server" OnTextChanged="TxtCodigoPostal_TextChanged"></asp:TextBox>
        <br/>
        <asp:Label ID="Label6" runat="server" Text="Dirección postal:"></asp:Label>
        <asp:TextBox ID="TxtDireccionPostal" runat="server"></asp:TextBox>
    
        <br/>
        <br/>
        <asp:Button ID="btnInsertarEscuela" runat="server" Text="Insertar escuela" OnClick="btnInsertarEscuela_Click" />
        <div>
            
        <br/>
        <br/>
         <br/>
        <br/>
        </div>
    </form>
</body>
</html>
