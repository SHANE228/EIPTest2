<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ReportContent.aspx.cs" Inherits="EIPTest.WebAdmin.ReportForm.ReportContentaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>報表: 商品內頁</h1>
        <%
        if (_arrayList.Count > 0)
        {

    %>
    <table>
        <tr>
            <th>商品代碼 &nbsp;</th>
            <th>商品類別 &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>瀏覽次數 &nbsp; </th>

        </tr>
        <%

            foreach (Hashtable ht in _arrayList)
            {
        %>
        <%string str = ht["ITEM_OPEN"].ToString();
            DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);  %>
        <%string str1 = ht["ITEM_CLOSE"].ToString();
            DateTime close = DateTime.ParseExact(str1, "yyyyMMdd", null);  %>
        

        <tr>
            <td><%=ht["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=ht["TYPE_NAME"].ToString() %>&nbsp;</td>
            <td><%=open.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=close.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=ht["ITEM_VIEW_COUNT"].ToString() %>&nbsp;</td>


        </tr>
        <%}%>
    </table><br />
    <%} %>

        被那些會員加入喜好清單 :<span>           
    <%
        if (_arrayList1.Count > 0)
        {
            foreach (Hashtable htt in _arrayList1)
            {
        %>
            <%=htt["EMP_ID"].ToString() %>
        <%}%>

    <%} %></span><br />
    <asp:Label ID="Label1" runat="server" ></asp:Label><br />
    <asp:Label ID="Label2" runat="server" ></asp:Label><br />
    <asp:Label ID="Label3" runat="server" ></asp:Label><br />
</asp:Content>
