<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPassUpdate.aspx.cs" Inherits="EIPTest.Login.LoginPassUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    帳號 :<asp:Label ID="Label1" runat="server"></asp:Label>
    <p>修改密碼</p>
    <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox><br />
    <p>確認修改密碼</p>
    <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" />
</asp:Content>
