<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FavList.aspx.cs" Inherits="EIPTest.FavList.FavList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>喜好清單</h1>
    <%
        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>商品照片 &nbsp;</th>
            <th>商品標題 &nbsp; </th>
            <th>商品分類 &nbsp;</th>
            <th>目前上下架狀況 &nbsp;</th>
            <th>販售地點 &nbsp;</th>
            <th>加入喜好日期 &nbsp;</th>
        </tr>
        <%
            foreach (Hashtable ht in _arrayList)
            {

        %>
        <%string msg = ht["ITEM_STATUS"].ToString(); %>
        <%DateTime ct = DateTime.Parse(ht["CREATE_TIME"].ToString()); %>
        <tr>
            <td><img src="<%=ht["ITEM_PIC"].ToString()%>" width="50" /></td>
            <td><%=ht["ITEM_TITLE"].ToString() %></td>
            <td><%=ht["TYPE_NAME"].ToString() %></td>
            <td><% if (msg == "Y")
                    {%><span>上架</span> <%}
                   else
                   {%><span>下架</span> <%}
            %></td>
            <td><%=ht["ITEM_PLACE"].ToString() %></td>
            <td><%=ct.ToString("yyyy/MM/dd") %></td>
            <input id="members" type="hidden" name="member" value="<%=ht["ITEM_ID"].ToString() %>" />
            <td><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">刪除喜好清單</asp:LinkButton></td>
        </tr>
        <%}%>
    </table>
    <%} %>
</asp:Content>
