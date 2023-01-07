<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditBulletin.aspx.cs" Inherits="EIPTest.WebAdmin.Bulletin.EditBulletin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>編輯公告</h1>
    <p>公告標題</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox1" runat="server" ErrorMessage="公告標題不得為空"></asp:RegularExpressionValidator>
    <p>公告內容</p>
    <asp:TextBox ID="TextBox2" TextMode="MultiLine" Height="122px" Width="273px" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="公告內容不得為空"></asp:RegularExpressionValidator>
    <p>上架日期</p>
    <asp:TextBox ID="TextBox3" TextMode="Date" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TextBox3" runat="server" ErrorMessage="上架日期不得為空"></asp:RegularExpressionValidator>
    <p>下架日期</p>
    <asp:TextBox ID="TextBox4" TextMode="Date" runat="server"></asp:TextBox><br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TextBox4" runat="server" ErrorMessage="下架日期不得為空"></asp:RegularExpressionValidator>
    <asp:Button ID="Button1" runat="server" Text="編輯" OnClick="Button1_Click" />
</asp:Content>
