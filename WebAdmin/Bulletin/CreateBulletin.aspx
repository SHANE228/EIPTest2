<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateBulletin.aspx.cs" Inherits="EIPTest.WebAdmin.Bulletin.CreateBulletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>新增公告</h1>
    <p>公告標題</p>
    <asp:TextBox ID="NO_TOPIC" runat="server"></asp:TextBox>
    <p>公告內容</p>
    <asp:TextBox ID="NO_CONTENT" TextMode="MultiLine"  Height="122px" Width="273px"  runat="server"></asp:TextBox>
    <p>上架日期</p>
    <asp:TextBox ID="NO_OPEN" TextMode="Date" runat="server"></asp:TextBox>
    <p>下架日期</p>
    <asp:TextBox ID="NO_CLOSE" TextMode="Date" runat="server"></asp:TextBox>
    <p>公告狀態</p>
    <asp:DropDownList ID="NO_STATUS" runat="server">
        <asp:ListItem Value="Y">上架</asp:ListItem>
        <asp:ListItem Value="N">下架</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
