<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Commodity.aspx.cs" Inherits="EIPTest.WebAdmin.Commodity.Commodity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>商品管理</p>
    <asp:Button ID="Button1" runat="server" Text="新增商品管理" OnClick="Button1_Click" />
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
            <th>加入日期 &nbsp;</th>
            <th>修改日期 &nbsp;</th>
        </tr>
        <%
            foreach (Hashtable ht in _arrayList)
            {

        %>
            <%string msg = ht["ITEM_STATUS"].ToString(); %>
            <%string str=ht["ITEM_OPEN"].ToString();
                DateTime open =DateTime.ParseExact(str,"yyyyMMdd",null);  %>
            <%string str1=ht["ITEM_CLOSE"].ToString();
                DateTime close =DateTime.ParseExact(str1,"yyyyMMdd",null);  %>
            <%DateTime ct = DateTime.Parse(ht["CREATE_TIME"].ToString()); %>
            <%DateTime mt = DateTime.Parse(ht["MODIFY_TIME"].ToString()); %>
        <tr>
            <td><%=ht["ITEM_ID"].ToString() %></td>
            <td><%=ht["TYPE_NAME"].ToString() %></td>
            <td><%=ht["ITEM_TITLE"].ToString() %></td>
            <td><%=ht["ITEM_PLACE"].ToString() %></td>
            <td><img src="<%=ht["ITEM_PIC"].ToString()%>" width="50" /></td>
            <td><%=ht["ITEM_DESCR"].ToString()  %></td>
            <td><%=ht["ITEM_COUNT"].ToString() %></td>
            <td><%=ht["ITEM_PRICE"].ToString() %></td>
            <td><%=open.ToString("yyyy/MM/dd")%></td>
            <td><%=close.ToString("yyyy/MM/dd")%></td>
            <td><% if (msg == "Y") 
                   {%><span>上架</span> <%}
                   else
                   {%><span>下架</span> <%}
            %></td>
            <td><%=ct.ToString("yyyy/MM/dd") %></td>
            <td><%=mt.ToString("yyyy/MM/dd") %></td>
            <td><a href="EditCommodity.aspx?id=<%=ht["ITEM_ID"].ToString()%>">編輯&nbsp;</a></td>
            <td><a href="DeleteCommodity.aspx?id=<%=ht["ITEM_ID"].ToString()%>">刪除</a></td>
        </tr>
        <%}%>
    </table>
    <%} %>
</asp:Content>
