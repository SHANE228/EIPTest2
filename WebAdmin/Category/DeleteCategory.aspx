<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DeleteCategory.aspx.cs" Inherits="EIPTest.WebAdmin.DeleteCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>類別代號 &nbsp;</th>
            <th>類別層級 &nbsp;</th>
            <th>上層類別代號 &nbsp;</th>
            <th>類別代碼 &nbsp;</th>
            <th>類別狀態 &nbsp; </th>
            <th>類別名稱 &nbsp;</th>
            <th>類別說明 &nbsp;</th>
        </tr>
        <%
            foreach (Hashtable ht in _arrayList)
            {
        %>
        <%Int32 intLevel = Int32.Parse((ht["TYPE_LEVEL"].ToString())); %>
        <%string msg = ht["TYPE_STATUS"].ToString(); %>
        <tr>
            <td><%=ht["TYPE_ID"].ToString() %></td>
            <td><%=(intLevel==1)?"大類":"小類" %></td>
            <td><%=ht["TYPE_UPPER"].ToString() %></td>
            <td><%=ht["TYPE_CODE"].ToString() %></td>
            <td><%=(msg == "Y")?"正常":"刪除" %></td>
            <td><%=ht["TYPE_NAME"].ToString() %></td>
            <td><%=ht["TYPE_PS"].ToString() %></td>

        </tr>
        <%}%>
    </table>
    <%} %>
    <asp:Button ID="Button1" runat="server" Text="刪除" OnClick="Button1_Click" />
</asp:Content>
