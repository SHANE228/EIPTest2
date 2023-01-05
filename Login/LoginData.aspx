<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginData.aspx.cs" Inherits="EIPTest.Login.LoginData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>姓名</p>
    <asp:TextBox ID="EMP_Name" runat="server"></asp:TextBox><br />
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="EMP_Name" runat="server" ErrorMessage="姓名不可為空"></asp:RequiredFieldValidator>--%>
    <p>信箱</p>
    <asp:TextBox ID="EMP_Mail" runat="server" Width="249px"></asp:TextBox><br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EMP_Mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="信箱格式錯誤"></asp:RegularExpressionValidator><br />
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ControlToValidate="EMP_Mail" runat="server" ErrorMessage="信箱不可為空"></asp:RequiredFieldValidator>--%>
    <p>手機</p>
    <asp:TextBox ID="EMP_Phone" runat="server"></asp:TextBox><br />
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EMP_Phone" runat="server" ErrorMessage="電話不可為空"></asp:RequiredFieldValidator>--%>
    <p>居住地</p>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>台北市</asp:ListItem>
        <asp:ListItem>新北市</asp:ListItem>
        <asp:ListItem>桃園市</asp:ListItem>
        <asp:ListItem>台中市</asp:ListItem>
        <asp:ListItem>台南市</asp:ListItem>
        <asp:ListItem>高雄市</asp:ListItem>
        <asp:ListItem>新竹縣</asp:ListItem>
        <asp:ListItem>苗栗縣</asp:ListItem>
        <asp:ListItem>彰化縣</asp:ListItem>
        <asp:ListItem>南投縣</asp:ListItem>
        <asp:ListItem>雲林縣</asp:ListItem>
        <asp:ListItem>嘉義縣</asp:ListItem>
        <asp:ListItem>屏東縣</asp:ListItem>
        <asp:ListItem>宜蘭縣</asp:ListItem>
        <asp:ListItem>花蓮縣</asp:ListItem>
        <asp:ListItem>台東縣</asp:ListItem>
        <asp:ListItem>澎湖縣</asp:ListItem>
        <asp:ListItem>金門縣</asp:ListItem>
        <asp:ListItem>連江縣</asp:ListItem>
        <asp:ListItem>基隆市</asp:ListItem>
        <asp:ListItem>新竹市</asp:ListItem>
        <asp:ListItem>嘉義市</asp:ListItem>
    </asp:DropDownList><br />
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="DropDownList1" runat="server" ErrorMessage="居住地不可為空"></asp:RequiredFieldValidator><br />--%>
    <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" />
</asp:Content>
