<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ReportFav.aspx.cs" Inherits="EIPTest.WebAdmin.ReportForm.ReportFav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>報表: 會員喜好查詢</h1>
    <b>上架商品</b>
    <%
        if (_arrayList.Count > 0)
        {

    %>
    <table>
        <tr>
            <th>商品代碼 &nbsp;</th>
            <th>商品類別(大) &nbsp;</th>
            <th>商品類別(小) &nbsp;</th>
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
        <%  
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID = (SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID= " + ht["TYPE_ID"].ToString()+")");
            string name = db.GetOneColumnData(sb2.ToString());
            %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=name %></td>
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
        if (_arrayList2.Count > 0)
        {

    %>
        <b>下架商品</b>
    <table>
        <tr>
            <th>商品代碼 &nbsp;</th>
            <th>商品類別(大) &nbsp;</th>
            <th>商品類別(小) &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>瀏覽次數 &nbsp; </th>
            <th>被加入喜好次數 &nbsp;</th>
            <th>內頁 &nbsp;</th>
        </tr>
        <%

            foreach (Hashtable ht in _arrayList2)
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
        <%  
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID = (SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID= " + ht["TYPE_ID"].ToString()+")");
            string name = db.GetOneColumnData(sb2.ToString());
            %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=name %></td>
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
        <b>刪除商品</b>
    <table>
        <tr>
            <th>商品代碼 &nbsp;</th>
            <th>商品類別(大) &nbsp;</th>
            <th>商品類別(小) &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>瀏覽次數 &nbsp; </th>
            <th>被加入喜好次數 &nbsp;</th>
            <th>內頁 &nbsp;</th>
        </tr>
        <%

            foreach (Hashtable ht in _arrayList1)
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
        <%  
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID = (SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID= " + ht["TYPE_ID"].ToString()+")");
            string name = db.GetOneColumnData(sb2.ToString());
            %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %>&nbsp;</td>
            <td><%=name %></td>
            <td><%=ht["TYPE_NAME"].ToString() %>&nbsp;</td>
            <td><%=open.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=close.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=ht["ITEM_VIEW_COUNT"].ToString() %>&nbsp;</td>
            <td><%=frequency %>&nbsp;</td>
            <td><a href="ReportContent.aspx?id=<%=ht["ITEM_ID"].ToString()%>">進入&nbsp;</a></td>

        </tr>
        <%}%>
            <%} %>
        </table>
</asp:Content>
