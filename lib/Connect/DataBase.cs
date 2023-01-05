using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using System.IO;
using System.Configuration;
using System.Collections;
using EIPTest.lib.Util;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EIPTest.lib.Connect
{
    public class DataBase
    {
        private OracleConnection Conn;
        private OracleCommand cmd;
        public DataBase()
        {

        }

        //public DataTable GetTable(string sql)
        //{
        //    try
        //    {
        //        int status = 0;
        //        DataTable dt = new DataTable();

        //        if (!String.IsNullOrEmpty(sql))
        //        {
        //            open();
        //            OracleDataAdapter sda = new OracleDataAdapter(sql, Conn);
        //            DataSet ds = new DataSet();
        //            sda.Fill(ds);
        //            if (ds.Tables.Count > 0)
        //            {
        //                dt = ds.Tables[0];
        //                status = 1;
        //            }
        //            close();
        //        }
        //        if (status == 1)
        //            return dt;
        //        else
        //            return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        ///**
        // * 新增/刪除/修改
        // */

        public int UpdateDB(string sql)
        {


            open();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {

                close();
            }

        }

        public int ExecuteStoreProcedure(string cmdTxt, OracleParameter[] parms)
        {


            open();
            foreach (OracleParameter parm in parms)
                cmd.Parameters.Add(parm);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = cmdTxt;
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {

                close();
            }

        }

        public int ExecuteStoreProcedure(string cmdTxt)
        {

            open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = cmdTxt;

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }
            finally
            {

                close();
            }

        }

        /**
          * query CLOB 物件
         */

        //public int ExeDBClob(string sql, string ParameterName, object Value)
        //{
        //    open();
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = sql;
        //    OracleParameter op = new OracleParameter(ParameterName, OracleDbType.Clob);
        //    op.Value = Value;
        //    cmd.Parameters.Add(op);
        //    try
        //    {
        //        return cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    finally
        //    {
        //        close();
        //    }

        //}
        ///**
        //  * Query DB 
        //  */

        public ArrayList QueryDB(string sql)
        {

            open();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            OracleDataReader dr = cmd.ExecuteReader();
            ArrayList alst = new ArrayList();

            try
            {

                while (dr.Read())
                {
                    int drAcount = dr.FieldCount;

                    Hashtable ht = new Hashtable();
                    for (int a = 0; a < drAcount; a++)
                    {
                        string nowValue = "";
                        try
                        {
                            nowValue = Convert.ToString(dr.GetValue(a));
                        }
                        catch
                        {
                            nowValue = Convert.ToString(dr.GetDouble(a));
                        }

                        nowValue = EuString.DisplayNull(nowValue);
                        ht.Add(dr.GetName(a), nowValue.ToString());

                    }

                    alst.Add(ht);

                }

            }
            catch
            {

            }
            finally
            {

                close();
            }

            return alst;



        }

        /**
         * Query DB 僅query一筆資料
         */

        public Hashtable QueryOneRowDB(string sql)
        {

            open();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            OracleDataReader dr = cmd.ExecuteReader();
            Hashtable ht = null;



            try
            {

                if (dr.Read())
                {
                    int drAcount = dr.FieldCount;

                    ht = new Hashtable();
                    for (int a = 0; a < drAcount; a++)
                    {

                        ht.Add(dr.GetName(a), dr.GetValue(a));

                    }

                }

            }
            catch
            {

            }
            finally
            {
                close();
            }

            return ht;



        }

        public string GetOneColumnData(string Sql)
        {

            string DateValue = "";
            open();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Sql;

            OracleDataReader dr = cmd.ExecuteReader();


            try
            {
                if (dr.Read())
                {
                    DateValue = Convert.ToString(dr.GetValue(0));
                }

            }
            catch
            {

            }
            finally
            {
                close();
            }

            return DateValue;
        }

        /**
         * Query DB 僅query一筆資料
         */

        public string GetSequence(string seq_name)
        {

            string return_seq = "";
            open();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select " + seq_name + ".nextval as SEQ from dual";

            OracleDataReader dr = cmd.ExecuteReader();
            Hashtable ht = null;




            try
            {
                if (dr.Read())
                {
                    int drAcount = dr.FieldCount;

                    ht = new Hashtable();
                    for (int a = 0; a < drAcount; a++)
                    {

                        ht.Add(dr.GetName(a), dr.GetValue(a));

                    }

                }
                return_seq = Convert.ToString(ht["SEQ"]);
            }
            catch
            {

            }
            finally
            {
                close();
            }


            return return_seq;
        }

        //取得欄位名稱
        //public string GetColnumList(string Sql)
        //{

        //    open();
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = Sql;

        //    OracleDataReader dr = cmd.ExecuteReader();
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        int drAcount = dr.FieldCount;

        //        for (int a = 0; a < drAcount; a++)
        //        {
        //            sb.Append(dr.GetName(a) + ",");
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        close();
        //    }

        //    return sb.ToString().Substring(0, sb.ToString().Length - 1);
        //}

        //取得資料型別
        //public string GetDataType(string Sql)
        //{

        //    open();
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = Sql;

        //    OracleDataReader dr = cmd.ExecuteReader();
        //    StringBuilder sb = new StringBuilder();
        //    try
        //    {
        //        int drAcount = dr.FieldCount;

        //        for (int a = 0; a < drAcount; a++)
        //        {
        //            sb.Append(dr.GetDataTypeName(a) + ",");
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        close();
        //    }

        //    return sb.ToString().Substring(0, sb.ToString().Length - 1);
        //}



        /// <summary>
        /// 取得最新PK ID
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="PKName"></param>
        /// <returns></returns>
        public string GetNewPkId(string TableName, string PKName)
        {
            string MaxValue = GetOneColumnData("select max(" + PKName + ") from " + TableName + "");

            return (string.IsNullOrEmpty(MaxValue)) ? "1" : (int.Parse(MaxValue) + 1).ToString();
        }


        private void open()
        {
            Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            Conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = Conn;


        }


        private void close()
        {
            if (Conn.State != ConnectionState.Closed)
            {
                cmd.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}