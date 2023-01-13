<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoticeContent.aspx.cs" Inherits="EIPTest.NoticeContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <%
        if (_arrayList.Count > 0)
        {
    %>
        <%
            foreach (Hashtable ht in _arrayList)
            {

        %>
        <%string str = ht["NOTICE_OPEN"].ToString();
            DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);  %>        
            <div class="sub"><b>公告標題</b></div>
            <p style="text-align:center;"><%=ht["NOTICE_TOPIC"].ToString() %></p><br />
            <div class="sub"><b>公告內容</b></div>
            <p style="text-align:center;"><%=ht["NOTICE_CONTENT"].ToString() %></p><br />
            <div class="sub"><b>公告發布日期</b></div>
            <p style="text-align:center;"><%=open.ToString("yyyy-MM-dd") %></p><br />
        <%}%>

    <%} %>
</asp:Content>
