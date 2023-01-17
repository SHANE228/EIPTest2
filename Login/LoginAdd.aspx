<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginAdd.aspx.cs" Inherits="EIPTest.Login.LoginAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>註冊</h1>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label><br />
    <p>身分證</p>
    <asp:TextBox ID="National_ID" runat="server"></asp:TextBox><br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="National_ID" ValidationExpression="[a-zA-Z][12]\d{8}" ErrorMessage="身分證格式錯誤"></asp:RegularExpressionValidator><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="National_ID" runat="server" ErrorMessage="身分證必填"></asp:RequiredFieldValidator>
    <p>帳號</p>
    <asp:TextBox ID="EMP_ID" runat="server"></asp:TextBox><br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EMP_ID" runat="server" ErrorMessage="帳號必填"></asp:RequiredFieldValidator>
    <p>姓名</p>
    <asp:TextBox ID="EMP_Name" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EMP_Name" runat="server" ErrorMessage="姓名必填"></asp:RequiredFieldValidator>
    <p>密碼</p>
    <asp:TextBox ID="EMP_Password" TextMode="Password" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="EMP_Password" runat="server" ErrorMessage="姓名必填"></asp:RequiredFieldValidator>
    <p>信箱</p>
    <asp:TextBox ID="EMP_Mail" runat="server" Width="249px"></asp:TextBox><br />
    <!--正規表示法:
            \w任意大小寫英文字母 0-9數字 下劃線 +為至少出現1個以上字符
                [-+.]\w+ 任意包含 - + . 及 \w字符的組合出現0次或多次
                    \. 固定符號 必須包括一個這個 -->
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EMP_Mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="信箱格式錯誤"></asp:RegularExpressionValidator><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="EMP_Mail" runat="server" ErrorMessage="信箱必填"></asp:RequiredFieldValidator>
    <p>性別</p>
    <asp:RadioButton ID="RadioButton1" runat="server" Text="男" GroupName="sex" />
    <asp:RadioButton ID="RadioButton2" runat="server" Text="女" GroupName="sex" /><br />
    <asp:Label ID="labSex" runat="server"></asp:Label>
    <p>手機</p>
    <asp:TextBox ID="EMP_Phone" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="EMP_Phone" runat="server" ErrorMessage="手機必填"></asp:RequiredFieldValidator>
    <p>居住地</p>
    <asp:DropDownList ID="DropDownList1" runat="server">
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

    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="DropDownList1" runat="server" ErrorMessage="居住地必填"></asp:RequiredFieldValidator>--%>
    <p>生日</p>
    <asp:TextBox ID="EMP_Birthday" TextMode="Date" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="EMP_Birthday" runat="server" ErrorMessage="生日必填"></asp:RequiredFieldValidator><br />
    <asp:Button ID="btnSave" runat="server" Text="完成" OnClick="btnSave_Click" />
</asp:Content>
