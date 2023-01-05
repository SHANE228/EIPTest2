<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="EIPTest.WebAdmin.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>後台登入系統</h1>
    <p>帳號</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>密碼</p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" />
</asp:Content>
