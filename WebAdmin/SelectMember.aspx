<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="SelectMember.aspx.cs" Inherits="EIPTest.WebAdmin.SelectMember" %>

<%@ Import Namespace="EIPTest.lib.Connect" %>
<%@ Import Namespace="EIPTest.lib.Org" %>
<%@ Import Namespace="EIPTest.lib.AES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>查詢會員資料</h1>
    <form method="get">
    姓名 :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" />
    身分證字號 :<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="查詢" OnClick="Button2_Click" />
    <tr>
        <td>出生日期：</td>
        <td>
            <select id="birth_year" name="year" onchange="setDays(this,birth_month,birth_day);">
                <option value="">年</option>

            </select>
            <select id="birth_month" name="month" onchange="setDays(birth_year,this,birth_day);">
                <option value="">月</option>

            </select>
            <select id="birth_day" name="day">
                <option value="">日</option>

            </select></td>
    </tr>
    <asp:Button ID="Button3" runat="server" Text="查詢" OnClick="Button3_Click" /><br />
</form>
    <%  

        if (_arrayList.Count > 0)
        {
    %>
    <table>
        <tr>
            <th>身分證字號&nbsp;</th>
            <th>帳號&nbsp;</th>
            <th>姓名&nbsp;</th>
            <th>電子郵件&nbsp;</th>
            <th>性別&nbsp;</th>
            <th>電話&nbsp;</th>
            <th>居住地&nbsp;</th>
            <th>生日&nbsp;</th>
        </tr>

        <%
            foreach (Hashtable ht in _arrayList)
            {
        %>
        <%
            string myKey = "1234567812345678";
            string myIV = "1234567812345678";
            string NID= ht["NATIONAL_ID"].ToString();
            
            %>
        <%Int32 intSex = Int32.Parse((ht["EMP_SEX"].ToString())); %>
        <%DateTime dt = DateTime.Parse(ht["EMP_BIRTHDAY"].ToString()); %>
        <tr>
            <td><%=MyAesCryptography.Decrypt(myKey, myIV, NID) %>&nbsp;</td>
            <td><%=ht["EMP_ID"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_NAME"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_EMAIL"].ToString() %>&nbsp;</td>
            <td><%=(intSex==1)?"男":"女" %>&nbsp;</td>
            <td><%=ht["EMP_PHONE"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_PLACE"].ToString() %>&nbsp;</td>
            <td><%=dt.ToString("yyyy/MM/dd") %>&nbsp;</td>
        </tr>
        <%}%>
    </table>
    <%} %>

    <script type="text/javascript" src="Scripts/jquery-1.5.1.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var i = -1;
            // 新增年份，從1910年開始
            for (i = 1910; i <= new Date().getFullYear(); i++) {
                addOption(birth_year, i, i - 1909);
                /*// 預設選中1988年
                if (i == 1988) {
                    birth_year.options[i-1910].selected = true;
                }*/
            }
            // 新增月份
            for (i = 1; i <= 12; i++) {
                addOption(birth_month, i, i);
            }
            // 新增天份，先預設31天
            for (i = 1; i <= 31; i++) {
                addOption(birth_day, i, i);
            }



            //$("#birth_month"). birth_year  birth_day
        });


        // 設定每個月份的天數
        function setDays(year, month, day) {
            var monthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            var yea = year.options[year.selectedIndex].text;
            var mon = month.options[month.selectedIndex].text;
            var num = monthDays[mon - 1];
            if (mon == 2 && isLeapYear(yea)) {
                num++;
            }
            for (var j = day.options.length - 1; j >= num; j--) {
                day.remove(j);
            }
            for (var i = day.options.length; i <= num; i++) {
                addOption(birth_day, i, i);
            }
        }

        // 判斷是否閏年
        function isLeapYear(year) {
            return (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0));
        }

        // 向select尾部新增option
        function addOption(selectbox, text, value) {
            var option = document.createElement("option");
            option.text = text;
            option.value = value;
            selectbox.options.add(option);
        }
    </script>
</asp:Content>
