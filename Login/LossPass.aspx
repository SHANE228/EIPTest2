<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LossPass.aspx.cs" Inherits="EIPTest.Login.LossPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>忘記密碼</h1>
    <p>檢核帳號是否存在</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" />

</asp:Content>
