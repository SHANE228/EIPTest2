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
        <td>出生日期：</td>
        <span>
            <select name="year" id="year">
                <option value="">年</option>
            </select>
        </span>
        <span>
            <select name="month" id="month">
                <option value="">月</option>
            </select>
        </span>
        <span>
            <select name="day" id="day">
                <option value="">日</option>
            </select>
        </span>
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
            <th>信箱&nbsp;</th>
            <th>性別&nbsp;</th>
            <th>手機&nbsp;</th>
            <th>居住地&nbsp;</th>
            <th>生日&nbsp;</th>
            <th>加入日期&nbsp;</th>
            <th>修改日期&nbsp;</th>
        </tr>

        <%
            foreach (Hashtable ht in _arrayList)
            {
        %>
        <%
            string myKey = "1234567812345678";
            string myIV = "1234567812345678";
            string NID = ht["NATIONAL_ID"].ToString();

        %>
        <%Int32 intSex = Int32.Parse((ht["EMP_SEX"].ToString())); %>
        <%        string str=ht["EMP_BIRTHDAY"].ToString();
                DateTime birthday =DateTime.ParseExact(str,"yyyyMMdd",null);  %>
        <%DateTime ct = DateTime.Parse(ht["CREATE_TIME"].ToString()); %>
        <%DateTime mt = DateTime.Parse(ht["MODIFY_TIME"].ToString()); %>
        <tr>
            <td><%=MyAesCryptography.Decrypt(myKey, myIV, NID) %>&nbsp;</td>
            <td><%=ht["EMP_ID"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_NAME"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_EMAIL"].ToString() %>&nbsp;</td>
            <td><%=(intSex==1)?"男":"女" %>&nbsp;</td>
            <td><%=ht["EMP_PHONE"].ToString() %>&nbsp;</td>
            <td><%=ht["EMP_PLACE"].ToString() %>&nbsp;</td>
            <td><%=birthday.ToString("yyyy/MM/dd") %>&nbsp;</td>
            <td><%=ct.ToString("yyyy/MM/dd") %>&nbsp;</td>
            <td><%=mt.ToString("yyyy/MM/dd") %>&nbsp;</td>
        </tr>
        <%}%>
    </table>
    <%} %>

    <script type="text/javascript" src="Scripts/jquery-1.5.1.js"></script>
    <script type="text/javascript">
        var yearSelect = document.getElementById("year");
        var monthSelect = document.getElementById("month");
        var daySelect = document.getElementById("day");

        var months = ['01', '02', '03', '04',
            '05', '06', '07', '08', '09', '10',
            '11', '12'];

        //Months are always the same
        (function populateMonths() {
            for (var i = 0; i < months.length; i++) {
                var option = document.createElement('option');
                option.textContent = months[i];
                monthSelect.appendChild(option);
            }

        })();

        var previousDay;

        function populateDays(month) {

            //Holds the number of days in the month
            var dayNum;
            //Get the current year
            var year = yearSelect.value;

            if (month === '01' || month === '03' ||
                month === '05' || month === '07' || month === '08'
                || month === '10' || month === '12') {
                dayNum = 31;
            } else if (month === '4' || month === '6'
                || month === '9' || month === '11') {
                dayNum = 30;
            } else {
                //Check for a leap year
                if (new Date(year, 1, 29).getMonth() === 1) {
                    dayNum = 29;
                } else {
                    dayNum = 28;
                }
            }
            //Insert the correct days into the day <select>
            for (let i = 1; i <= dayNum; i++) {
                const option = document.createElement("option");
                option.textContent = i;
                daySelect.appendChild(option);
            }
            if (previousDay) {
                daySelect.value = previousDay;
                if (daySelect.value === "") {
                    daySelect.value = previousDay - 1;
                }
                if (daySelect.value === "") {
                    daySelect.value = previousDay - 2;
                }
                if (daySelect.value === "") {
                    daySelect.value = previousDay - 3;
                }
            }
        }

        function populateYears() {
            //Get the current year as a number
            var year = new Date().getFullYear();
            //Make the previous 100 years be an option
            for (let i = 0; i < 101; i++) {
                const option = document.createElement("option");
                option.textContent = year - i;
                yearSelect.appendChild(option);
            }
        }

        populateDays(monthSelect.value);
        populateYears();

        yearSelect.onchange = function () {
            populateDays(monthSelect.value);
        }
        monthSelect.onchange = function () {
            populateDays(monthSelect.value);
        }
        daySelect.onchange = function () {
            previousDay = daySelect.value;
        }
    </script>
</asp:Content>
