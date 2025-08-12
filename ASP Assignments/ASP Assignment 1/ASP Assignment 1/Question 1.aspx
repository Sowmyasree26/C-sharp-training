<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question 1.aspx.cs" Inherits="ASP_Assignment_1.Question_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           Name : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TName" runat="server" Height="22px" CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name should not be empty" ForeColor="Red" ControlToValidate="TName">*</asp:RequiredFieldValidator>
        <br />
        <br />
            FamilyName :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TFamilyName" runat="server" Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name must be different from family name" ForeColor="Red" ControlToValidate="TFamilyName">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Name must be different from family name" ForeColor="Red" ControlToCompare="TName" ControlToValidate="TFamilyName" Operator="NotEqual"></asp:CompareValidator>
        <br />
        <br />
            Address : &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address should contain at least 2 letters" ForeColor="Red" ControlToValidate="TAddress">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TAddress" ErrorMessage="Address should contain at least 2 letters" ForeColor="Red" ValidationExpression="^.{2,}$"></asp:RegularExpressionValidator>
        <br />
        <br />
            City : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City should contain at least 2 letters" ForeColor="Red" ControlToValidate="TCity">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TCity" ErrorMessage="City should contain at least 2 letters" ForeColor="Red" ValidationExpression="^.{2,}$"></asp:RegularExpressionValidator>
        <br />
        <br />
            Zip Code : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TZipCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Zip-code  should contain 5 digits(XXXXX)" ForeColor="Red" ControlToValidate="TZipCode">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TZipCode" ErrorMessage="Zip-code  should contain 5 digits(XXXXX)" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
        <br />
        <br />
            Phone Number : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TPhoneNumber" runat="server" Width="249px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Phone Number shoul be in the format XX-XXXXXXX or XXX-XXXXXXX" ForeColor="Red" ControlToValidate="TPhoneNumber">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TPhoneNumber" ErrorMessage="Phone Number shoul be in the format XX-XXXXXXX or XXX-XXXXXXX" ForeColor="Red" ValidationExpression="^(\d{2}-\d{8}|\d{3}-\d{7})$"></asp:RegularExpressionValidator>
        <br />
        <br />
            Email : &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="e-mail should be in the format example@example.com" ForeColor="Red" ControlToValidate="TEmail">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TEmail" ErrorMessage="e-mail should be in the format example@example.com" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="CheckButton" runat="server" OnClick="Button1_Click" Text="CHECK" />
        <br />
       <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" />
        <br />
        </div>
    </form>
</body>
</html>
