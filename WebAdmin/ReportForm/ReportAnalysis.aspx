<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ReportAnalysis.aspx.cs" Inherits="EIPTest.WebAdmin.ReportForm.ReportAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>會員資料分析</h1>
    <h3>最受會員歡迎商品TOP3</h3>
    <%
        if (_arrayList.Count > 0)
        {
    %>
    <span>名稱&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span>瀏覽數&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span>名稱&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span>瀏覽數&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span>名稱&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span>瀏覽數&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><br />
    <%
        foreach (Hashtable ht in _arrayList)
        {
    %>

    <span><%=ht["ITEM_TITLE"].ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;</span>
    <span><%=ht["ITEM_VIEW_COUNT"].ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;</span>

    <%}%>

    <%}%>

    <h3>30天內每日新增會員數</h3>
    <table>
        <tr>
            <th>日期 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
            <th>男 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
            <th>女 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
        </tr>
        <%      string strDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(-1).ToString();
            DateTime dateDt = DateTime.Parse(strDate);
            for (DateTime dt = dateDt; dt <= DateTime.Now; dt = dt.AddDays(1))
            {
                string msgnd = dt.ToString("yyyy-MM-dd");
                //每日新增男性
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("SELECT COUNT(EMP_SEX) AS AGE FROM SJ0007_LOGIN WHERE TRUNC (CREATE_TIME) = TO_DATE('" + msgnd + "' ,'yyyy-MM-DD') AND EMP_SEX=1");
                string boy = db.GetOneColumnData(sb1.ToString());

                //每日新增女性
                StringBuilder sb2 = new StringBuilder();
                sb2.Append("SELECT COUNT(EMP_SEX) AS AGE FROM SJ0007_LOGIN WHERE TRUNC (CREATE_TIME) = TO_DATE('" + msgnd + "' ,'yyyy-MM-DD') AND EMP_SEX=2");
                string girl = db.GetOneColumnData(sb2.ToString());
        %>
        <tr>
            <td><%=msgnd %>&nbsp;&nbsp;&nbsp;</td>
            <td><%=boy %>人&nbsp;&nbsp;&nbsp;</td>
            <td><%=girl %>人&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <%} %>
    </table>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
