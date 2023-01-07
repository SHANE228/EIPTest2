<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductBrowse.aspx.cs" Inherits="EIPTest.ProductBrowse.ProductBrowse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>商品瀏覽</h1>
    <form method="get">

        類別:<asp:DropDownList ID="DropDownList1" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" AutoPostBack="True" runat="server"></asp:DropDownList>
        地點<asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>ESkyMall</asp:ListItem>
            <asp:ListItem>EdaMall</asp:ListItem>
        </asp:DropDownList>
        商品名稱<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" />
        </form>
</asp:Content>
