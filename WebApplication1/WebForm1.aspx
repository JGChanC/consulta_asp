<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Clave&nbsp;&nbsp;
        <asp:TextBox ID="clave" runat="server" OnTextChanged="clave_TextChanged"></asp:TextBox>
        <br />
        Nombre&nbsp;&nbsp;
        <asp:TextBox ID="nombre" runat="server" OnTextChanged="nombre_TextChanged"></asp:TextBox>
        <br />
        Precio&nbsp;&nbsp;
        <asp:TextBox ID="TxPrecio" runat="server" OnTextChanged="TxPrecio_TextChanged"></asp:TextBox>
        <br />
        FechaVenta&nbsp;&nbsp;
        <asp:TextBox ID="TxVentFech" runat="server" OnTextChanged="TxVentFech_TextChanged"></asp:TextBox>
        <br />
        Cantidad&nbsp;&nbsp;
        <asp:TextBox ID="TxCant" runat="server" OnTextChanged="TxCant_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <br />
        <asp:Label ID="LblMensj" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
