<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditCommodity.aspx.cs" Inherits="EIPTest.WebAdmin.Commodity.EditCommodity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>編輯商品</h1>
    <p>類別代號</p>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <p>商品名稱</p>
    <asp:TextBox ID="ITEM_TITLE" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ITEM_TITLE" runat="server" ErrorMessage="商品名稱必填"></asp:RequiredFieldValidator>
    <p>販促地點</p>
         <asp:RadioButton ID="RadioButton1" runat="server" Text="ESkyMall" GroupName="Mall" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="EdaMall" GroupName="Mall" /><br />
    <p>商品照片</p>
    <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server"></asp:TextBox>
    <asp:CheckBox ID="CheckBox1" runat="server" />不更新照片<br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <p>商品內容</p>
    <asp:TextBox ID="ITEM_DESCR" TextMode="MultiLine" Height="122px" Width="273px" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ITEM_DESCR" runat="server" ErrorMessage="商品內容必填"></asp:RequiredFieldValidator>
    <p>商品數量</p>
    <asp:TextBox ID="ITEM_COUNT" runat="server"></asp:TextBox>
    <p>商品金額</p>
    <asp:TextBox ID="ITEM_PRICE" runat="server"></asp:TextBox>
    <p>上架日期</p>
    <asp:TextBox ID="ITEM_OPEN" TextMode="Date" runat="server"></asp:TextBox>
    <p>下架日期</p>
    <asp:TextBox ID="ITEM_CLOSE" TextMode="Date" runat="server"></asp:TextBox>
    <p>商品狀態</p>
    <asp:DropDownList ID="ITEM_STATUS" runat="server">
        <asp:ListItem Value="Y">上架</asp:ListItem>
        <asp:ListItem Value="N">下架</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
