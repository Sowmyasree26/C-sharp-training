<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Electricity_Project.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
            color: rgb(192, 11, 133);
            font-family: Candara;
        }
        body {
            font-family: Candara;
            font-size: 20px;
        }
        .error {
            color: red;
        }
        label, input {
            margin-top: 8px;
            display: block;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login</h2>

    <asp:Label ID="lblError" runat="server" CssClass="error" /><br />

    <label>Username:</label>
    <asp:TextBox ID="txtUsername" runat="server" />
    <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
        ControlToValidate="txtUsername"
        ErrorMessage="Username is required."
        ForeColor="Red"
        Display="Dynamic" /><br /><br />

    <label>Password:</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
        ControlToValidate="txtPassword"
        ErrorMessage="Password is required."
        ForeColor="Red"
        Display="Dynamic" /><br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>
