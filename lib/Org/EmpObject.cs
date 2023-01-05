using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using EIPTest.lib.AES;
using EIPTest.lib.Connect;


namespace EIPTest.lib.Org
{
    public class EmpObject
    {
        public string NationalId;
        public string empId;
        public string empName;
        public string empPassword;
        public string empEmail;
        public string empSex;
        public string empPhone;
        public string empPlace;

        private DataBase Db;

        public EmpObject(string EmpId)
        {
            this.empId = EmpId;
            Hashtable ht = this.GetEmpBasic();
            if(ht.Count > 0 )
            {
                NationalId= (string)ht["NATIONAL_ID"];
                empId = (string)ht["EMP_ID"];
                empName = (string)ht["EMP_NAME"];
                empPassword = (string)ht["EMP_PASSWORD"];
                empEmail= (string)ht["EMP_EMAIL"];
                //empSex = (string)ht["EMP_SEX"];
                empPhone= (string)ht["EMP_PHONE"];
                empPlace=(string)ht["EMP_PLACE"];
            }
        }

        public Hashtable GetEmpBasic()
        {

            Hashtable _hm = new Hashtable();
            Db = new DataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_PASSWORD, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE FROM SJ0007_LOGIN ");


            ArrayList resultList = Db.QueryDB(sb.ToString());
            if (resultList.Count > 0)
            {
                _hm = (Hashtable)resultList[0];
            }
            return _hm;

        }
    }
}