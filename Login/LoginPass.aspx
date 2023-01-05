<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPass.aspx.cs" Inherits="EIPTest.Login.LoginPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    姓名: <asp:Label ID="EMP_Name" runat="server"></asp:Label><br />
    信箱: <asp:Label ID="EMP_Mail" runat="server"></asp:Label><br />
    手機: <asp:Label ID="EMP_Phone" runat="server"></asp:Label><br />
    居住地: <asp:Label ID="EMP_Place" runat="server"></asp:Label><br />
    <asp:Button ID="btnUpdate" runat="server" Text="會員資料修改" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnUdatePass" runat="server" Text="密碼修改" OnClick="btnUdatePass_Click" />
</asp:Content>
