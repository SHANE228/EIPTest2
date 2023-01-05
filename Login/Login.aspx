<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EIPTest.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>登入</h1>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">註冊</asp:LinkButton><br />
    <p>
        帳號<asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
    </p>
    <p>
        密碼<asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox><br />
    </p>
    <asp:Label ID="Label1" runat="server"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="登出" OnClick="Button2_Click" /><br />
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">忘記密碼</asp:LinkButton>
</asp:Content>
