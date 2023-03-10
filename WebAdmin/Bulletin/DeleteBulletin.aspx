<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteBulletin.aspx.cs" Inherits="EIPTest.WebAdmin.Bulletin.DeleteBulletin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <%
        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>公告ID &nbsp;</th>
            <th>公告標題 &nbsp;</th>
            <th>公告內容 &nbsp;</th>
            <th>上架日期 &nbsp;</th>
            <th>下架日期 &nbsp;</th>
            <th>公告狀態 &nbsp; </th>
            <th>加入日期 &nbsp;</th>
            <th>修改日期 &nbsp;</th>
        </tr>
        <%
            foreach (Hashtable ht in _arrayList)
            {

        %>
            <%string msg = ht["NOTICE_STATUS"].ToString(); %>
            <%string str=ht["NOTICE_OPEN"].ToString();
                DateTime open =DateTime.ParseExact(str,"yyyyMMdd",null);  %>
            <%string str1=ht["NOTICE_CLOSE"].ToString();
                DateTime close =DateTime.ParseExact(str1,"yyyyMMdd",null);  %>
            <%DateTime ct = DateTime.Parse(ht["CREATE_TIME"].ToString()); %>
            <%DateTime mt = DateTime.Parse(ht["MODIFY_TIME"].ToString()); %>
        <tr>
            <td><%=ht["NOTICE_ID"].ToString() %></td>
            <td><%=ht["NOTICE_TOPIC"].ToString() %></td>
            <td><%=ht["NOTICE_CONTENT"].ToString() %></td>
            <td><%=open.ToString("yyyy/MM/dd")%></td>
            <td><%=close.ToString("yyyy/MM/dd")%></td>
            <td><% if (msg == "Y") 
                   {%><span>上架</span> <%}
                   else
                   {%><span>下架</span> <%}
            %></td>
            <td><%=ct.ToString("yyyy/MM/dd") %></td>
            <td><%=mt.ToString("yyyy/MM/dd") %></td>
        </tr>
        <%}%>
    </table>
    <%} %>
    <asp:Button ID="Button1" runat="server" Text="刪除" OnClick="Button1_Click" />
</asp:Content>
