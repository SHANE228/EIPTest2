<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="EIPTest.WebAdmin.CreateCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>新增商品類別</h1>
    <p>類別層級</p>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>大類</asp:ListItem>
        <asp:ListItem>小類</asp:ListItem>
    </asp:DropDownList><br />
    <p>上層類別代號</p>
    <asp:TextBox ID="UpperCode" runat="server" Width="43px"></asp:TextBox><br />
    <p>類別代碼</p>
    <asp:TextBox ID="CategoryCode" runat="server" Width="44px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CategoryCode" runat="server" ErrorMessage="類別代碼為空"></asp:RequiredFieldValidator><asp:Label ID="Label1" runat="server"></asp:Label>
    <p>類別名稱</p>
    <asp:TextBox ID="CategoryName" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CategoryName" runat="server" ErrorMessage="類別名稱為空"></asp:RequiredFieldValidator>
    <p>類別說明</p>
    <asp:TextBox ID="CategoryCaption" TextMode="MultiLine" runat="server" Height="122px" Width="273px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="CategoryCaption" runat="server" ErrorMessage="類別說明為空"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" />
</asp:Content>

