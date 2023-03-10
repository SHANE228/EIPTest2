<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateCommodity.aspx.cs" Inherits="EIPTest.WebAdmin.Commodity.CreateCommodity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <p>類別代號</p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"></asp:DropDownList>
        <%--<p>類別代號</p>

            大類<select id="bigClass" name="Bclass" onchange="changeCollege(this.selectedIndex)">
            <%
                if (_arrayList.Count > 0)
                {
                    foreach (Hashtable ht in _arrayList)
                    {%>
            <option value="<%=ht["TYPE_NAME"].ToString() %>"><%=ht["TYPE_NAME"].ToString()%></option>
            <%}%>

            <%}%>
        </select>--%>
<%--        小類<select id="smallClass" name="Sclass">
            <%
                if (_arrayList2.Count > 0)
                {
                    foreach (Hashtable ht in _arrayList2)
                    {%>
            <option><%=ht["TYPE_NAME"].ToString()%></option>
            <%}%>

            <%}%>
        </select><br />--%>

        <p>商品名稱</p>
        <asp:TextBox ID="ITEM_NAME" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ITEM_NAME" runat="server" ErrorMessage="商品名稱必填"></asp:RequiredFieldValidator>
        <p>販促地點</p>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="ESkyMall" GroupName="Mall" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="EdaMall" GroupName="Mall" /><br />
        <p>商品照片</p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FileUpload1" runat="server" ErrorMessage="商品照片必填"></asp:RequiredFieldValidator>
        <p>商品內容</p>
        <asp:TextBox ID="ITEM_DESCR" TextMode="MultiLine"  Height="122px" Width="273px"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ITEM_DESCR" runat="server" ErrorMessage="商品內容必填"></asp:RequiredFieldValidator>
        <p>商品數量</p>
        <asp:TextBox ID="ITEM_COUNT" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ITEM_COUNT" runat="server" ErrorMessage="商品數量必填"></asp:RequiredFieldValidator>
        <p>商品金額</p>
        <asp:TextBox ID="ITEM_PRICE" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ITEM_PRICE" runat="server" ErrorMessage="商品金額必填"></asp:RequiredFieldValidator>
        <p>上架日期</p>
        <asp:TextBox ID="ITEM_OPEN" TextMode="Date" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ITEM_OPEN" runat="server" ErrorMessage="上架日期必填"></asp:RequiredFieldValidator>
        <p>下架日期</p>
        <asp:TextBox ID="ITEM_CLOSE" TextMode="Date" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ITEM_CLOSE" runat="server" ErrorMessage="下架日期必填"></asp:RequiredFieldValidator>
        <p>商品狀態</p>
        <asp:DropDownList ID="ITEM_STATUS" runat="server">
            <asp:ListItem Value="Y">上架</asp:ListItem>
            <asp:ListItem Value="N">下架</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="Button1" runat="server" Text="完成" OnClick="Button1_Click" />
    </div>
 
    <script type="text/javascript" src="Scripts/jquery-1.5.1.js"></script>
    <script type="text/javascript">

    </script>
</asp:Content>
