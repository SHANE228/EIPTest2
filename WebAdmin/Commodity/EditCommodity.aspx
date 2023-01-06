<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditCommodity.aspx.cs" Inherits="EIPTest.WebAdmin.Commodity.EditCommodity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>編輯商品</h1>
    <p>上層類別代碼</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>類別代碼</p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <p>類別名稱</p>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <p>類別說明</p>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
