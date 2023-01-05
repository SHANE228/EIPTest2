<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="EIPTest.WebAdmin.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>編輯類別</h1>
    <p>上層類別代碼</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>類別代碼</p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBox2" runat="server" ErrorMessage="類別代碼不得為空"></asp:RequiredFieldValidator>
    <p>類別名稱</p>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox3" runat="server" ErrorMessage="類別名稱不得為空"></asp:RequiredFieldValidator>
    <p>類別說明</p>
    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Height="122px" Width="273px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox4" runat="server" ErrorMessage="類別說明不得為空"></asp:RequiredFieldValidator><br />
    <asp:Button ID="Button1" runat="server" Text="編輯完成" OnClick="Button1_Click" />
</asp:Content>
