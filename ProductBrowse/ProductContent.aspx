<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductContent.aspx.cs" Inherits="EIPTest.ProductBrowse.ProductContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>商品照片 &nbsp;</th>
            <th>商品標題 &nbsp;</th>
            <th>商品分類 &nbsp;</th>
            <th>商品數量 &nbsp;</th>
            <th>商品金額 &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>商品內容 &nbsp;</th>
            <th>加入喜好清單 &nbsp;</th>
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
            <td><img src="<%=ht["ITEM_PIC"].ToString()%>" width="150" /></td>
            <td><%=ht["ITEM_TITLE"].ToString() %></td>
            <td><%=ht["TYPE_NAME"].ToString() %></td>
            <td><%=ht["ITEM_COUNT"].ToString() %></td>
            <td><%=ht["ITEM_PRICE"].ToString() %></td>
            <td><%=open.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=close.ToString("yyyy/MM/dd")%>&nbsp;</td>
            <td><%=ht["ITEM_DESCR"].ToString() %></td>
            <td><asp:Button ID="Button1" runat="server" Text="加入喜好清單" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="從喜好清單移除" OnClick="Button2_Click" />
            </td>

            <%--每列導出編輯與刪除 用get傳遞商品代號編號--%>
        </tr>
        <%}%>
    </table>
    <%}%>
        商品瀏覽次數<asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
