<%@ Page Title="Bill Retrieval" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="BillRetreival.aspx.cs" Inherits="Electricity_Project.BillRetreival" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
            color: #2E8B57;
            font-family: Calibri;
        }
        body {
            font-family: Calibri;
            font-size:20px;
        }
        label, input, button {
            margin-top: 10px;
            display: block;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Last N Electricity Bills</h2>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" /><br />

    Enter Number of Bills to Retrieve from last: &nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txtCount" runat="server" /><br />

    <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Bills" OnClick="btnRetrieve_Click" /><br /><br />

    <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
</asp:Content>
