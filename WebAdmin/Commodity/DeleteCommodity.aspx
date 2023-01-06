<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteCommodity.aspx.cs" Inherits="EIPTest.WebAdmin.Commodity.DeleteCommodity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>商品代號 &nbsp;</th>
            <th>類別名稱 &nbsp;</th>
            <th>商品名稱 &nbsp;</th>
            <th>販促地點 &nbsp;</th>
            <th>商品照片 &nbsp;</th>
            <th>商品內容 &nbsp; </th>
            <th>商品數量 &nbsp;</th>
            <th>商品金額 &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>商品狀態 &nbsp;</th>
        </tr>
        <%
            foreach (Hashtable ht in _arrayList)
            {

        %>
        <%string msg = ht["ITEM_STATUS"].ToString(); %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %></td>
            <td><%=ht["TYPE_NAME"].ToString() %></td>
            <td><%=ht["ITEM_TITLE"].ToString() %></td>
            <td><%=ht["ITEM_PLACE"].ToString() %></td>
            <td>
            <img src="<%=ht["ITEM_PIC"].ToString()%>" width="50" /></td>
            <td><%=ht["ITEM_DESCR"].ToString()  %></td>
            <td><%=ht["ITEM_COUNT"].ToString() %></td>
            <td><%=ht["ITEM_PRICE"].ToString() %></td>
            <td><%=ht["ITEM_OPEN"].ToString() %></td>
            <td><%=ht["ITEM_CLOSE"].ToString() %></td>
            <td><% if (msg == "Y")
                  {%><span>上架</span> <%}
                  else
                  {%><span>下架</span> <%}
                   %></td>
        </tr>
        <%}%>
    </table>
    <%} %>
    <asp:Button ID="Button1" runat="server" Text="刪除" OnClick="Button1_Click" />
</asp:Content>
