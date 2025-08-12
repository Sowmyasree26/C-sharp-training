<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="ASP_1.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt" runat="server" OnTextChanged="txt_TextChanged" ></asp:TextBox>

            <asp:Button ID="btnclick" Text="click" runat="server" OnClick="btnclick" />
        </div>
        <p>
            Name&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="216px"></asp:TextBox>
&nbsp;
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" />
        </p>
    </form>
</body>
</html>
