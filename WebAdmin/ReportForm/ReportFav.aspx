<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ReportFav.aspx.cs" Inherits="EIPTest.WebAdmin.ReportForm.ReportFav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>報表: 會員喜好查詢</h1>
    
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
            <th>被加入喜好次數 &nbsp;</th>
            <th>內頁 &nbsp;</th>
        </tr>
        <%

            foreach (Hashtable ht in _arrayList)
            {
        %>
        <%string str = ht["ITEM_OPEN"].ToString();
            DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);  %>
        <%string str1 = ht["ITEM_CLOSE"].ToString();
            DateTime close = DateTime.ParseExact(str1, "yyyyMMdd", null);  %>
        
         <% 
             StringBuilder sb1 = new StringBuilder();
             sb1.Append("SELECT COUNT(*) FROM MEMBER_FAVORITE WHERE ITEM_ID =" +ht["ITEM_ID"].ToString());
             string frequency = db.GetOneColumnData(sb1.ToString());
            %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=ht["TYPE_NAME"].ToString() %>&nbsp;</td>
            <td><%=open.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=close.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=ht["ITEM_VIEW_COUNT"].ToString() %>&nbsp;</td>
            <td><%=frequency %>&nbsp;</td>
            <td><a href="ReportContent.aspx?id=<%=ht["ITEM_ID"].ToString()%>">進入&nbsp;</a></td>

        </tr>
        <%}%>
            <%} %>
        </table><br />
        <%
        if (_arrayList1.Count > 0)
        {

    %>
    <span>被刪除商品</span>
    <table>
        <tr>
            <th>商品代碼 &nbsp;</th>
            <th>商品類別 &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>瀏覽次數 &nbsp; </th>
            <th>被加入喜好次數 &nbsp;</th>
            <th>內頁 &nbsp;</th>
        </tr>
        <%
                    foreach (Hashtable ht1 in _arrayList1)
            {
        %>
        <%string str = ht1["ITEM_OPEN"].ToString();
            DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);  %>
        <%string str1 = ht1["ITEM_CLOSE"].ToString();
            DateTime close = DateTime.ParseExact(str1, "yyyyMMdd", null);  %>
        
         <% 
             StringBuilder sb1 = new StringBuilder();
             sb1.Append("SELECT COUNT(*) FROM MEMBER_FAVORITE WHERE ITEM_ID =" +ht1["ITEM_ID"].ToString());
             string frequency = db.GetOneColumnData(sb1.ToString());
            %>

        <tr>
            <td><%=ht1["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=ht1["TYPE_NAME"].ToString() %>&nbsp;</td>
            <td><%=open.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=close.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=ht1["ITEM_VIEW_COUNT"].ToString() %>&nbsp;</td>
            <td><%=frequency %>&nbsp;</td>
            <td><a href="ReportContent.aspx?id=<%=ht1["ITEM_ID"].ToString()%>">進入&nbsp;</a></td>

        </tr>
        <%}%>
    </table>
    <%} %>
</asp:Content>
