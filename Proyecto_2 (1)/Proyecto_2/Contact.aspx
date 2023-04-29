<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Proyecto_2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
	
    <main aria-labelledby="title" >
    <body  style="background-color:dimgray" >
        <h2 style="color:#0B4C89; font-family:Helvetica" id="title"><%: Title %>.</h2>
        <h3 style="font-family:Helvetica; color:white" >Para contactarnos está la siguiente información:</h3>
      
        <address>
            <strong  style="font-family:Helvetica; color:white"> Soporte:</strong>   <a href="mailto:grupo03@ejemplo.com"><span style="color:white">grupo03@ejemplo.com</span></a><br />
            <strong style="font-family:Helvetica; color:white"> Mercadeo:</strong> <a href="mailto:mercadeo@ejemplo.com"><span style="color:white">mercadeo@ejemplo.com</span></a>
        </address>
        </body>
    </main>
</asp:Content>
