<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditBulletin.aspx.cs" Inherits="EIPTest.WebAdmin.Bulletin.EditBulletin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>編輯公告</h1>
    <p>公告標題</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>公告內容</p>
    <asp:TextBox ID="TextBox2" TextMode="MultiLine" Height="122px" Width="273px" runat="server"></asp:TextBox>
    <p>上架日期</p>
    <asp:TextBox ID="TextBox3" TextMode="Date" runat="server"></asp:TextBox>
    <p>下架日期</p>
    <asp:TextBox ID="TextBox4" TextMode="Date" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="編輯" OnClick="Button1_Click" />
</asp:Content>
