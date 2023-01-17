<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteFavList.aspx.cs" Inherits="EIPTest.FavList.DeleteFavList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>刪除喜好清單</h1>
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
            <td><%=ht["ITEM_TITLE"].ToString() %>&nbsp;</td>
            <td><%=ht["TYPE_NAME"].ToString() %>&nbsp;</td>
            <td><% if (msg == "Y")
                    {%><span>上架</span> <%}
                   else
                   {%><span>下架</span> <%}
            %>&nbsp;</td>
            <td><%=ht["ITEM_PLACE"].ToString() %>&nbsp;</td>
            <td><%=ct.ToString("yyyy/MM/dd") %>&nbsp;</td>
        </tr>
        <%}%>
    </table>
    <asp:Button ID="Button1" runat="server" Text="刪除喜好清單" OnClick="Button1_Click" />
        <%} %>
</asp:Content>
