<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerificadorCartaoCredito.aspx.cs" Inherits="ValidaCartao.VerificadorCartaoCredito" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Validador Cartão de Crédito</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <p>Validador Cartão de Crédito</p><br />
                <asp:TextBox ID="txtNumeroCartao" runat="server"></asp:TextBox>
                <asp:Button ID="btnValidar" runat="server" Text="VALIDAR CARTÃO" ToolTip="Realizar a validação do número do cartão" OnClick="btnValidar_Click" /><br /><br />
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
