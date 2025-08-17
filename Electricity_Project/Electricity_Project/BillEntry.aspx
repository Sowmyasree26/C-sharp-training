<%@ Page Title="Bill Entry" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="Electricity_Project.Electricity_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
            color: rgb(166, 56, 248);
            font-family: Candara;
        }
        body {
            font-size: 20px;
        }
        label, input, button {
            margin-top: 10px;
            display: block;
        }
        .error {
            color: red;
        }
        .success {
            color: green;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bill Entry</h2>

    <asp:Label ID="lblError" runat="server" CssClass="error" /><br />

    <asp:Label ID="lblBillCount" runat="server" Text="Enter Number of Bills To Be Added:" />
    <asp:TextBox ID="txtBillCount" runat="server" />
    <asp:Button ID="btnStart" runat="server" Text="Start Entry" OnClick="btnStart_Click" /><br /><br />

    <asp:Panel ID="pnlBillForm" runat="server" Visible="false">
        <asp:Label ID="lblProgress" runat="server" Font-Bold="true" /><br /><br />

        Enter Consumer Number:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtConsumerNumber" runat="server" />
        <asp:RequiredFieldValidator ID="rfvConsumerNumber" runat="server"
            ControlToValidate="txtConsumerNumber"
            ErrorMessage="Consumer Number is required."
            ForeColor="Red"
            Display="Dynamic" /><br />

        Enter Consumer Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtConsumerName" runat="server" />
        <asp:RequiredFieldValidator ID="rfvConsumerName" runat="server"
            ControlToValidate="txtConsumerName"
            ErrorMessage="Consumer Name is required."
            ForeColor="Red"
            Display="Dynamic" /><br />

        Enter Units Consumed:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUnitsConsumed" runat="server" />
        <asp:RequiredFieldValidator ID="rfvUnitsConsumed" runat="server"
            ControlToValidate="txtUnitsConsumed"
            ErrorMessage="Units Consumed is required."
            ForeColor="Red"
            Display="Dynamic" /><br />

        <asp:Button ID="btnCalculate" runat="server" Text="Calculate & Save Bill" OnClick="btnCalculate_Click" /><br /><br />
    </asp:Panel>

    <asp:Label ID="lblResult" runat="server" CssClass="success" /><br /><br />

    <asp:Button ID="btnGoToRetrieval" runat="server" Text="Go to Bill Retrieval Page" OnClick="btnGoToRetrieval_Click" Visible="false" />
</asp:Content>
