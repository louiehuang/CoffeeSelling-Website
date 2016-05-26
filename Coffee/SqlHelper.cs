using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Coffee
{
    public class SqlHelper
    {
        string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public DataTable ReadTable(String strSql)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlDataAdapter Cmd = new SqlDataAdapter(strSql, Conn);
            Cmd.Fill(dt);
            Conn.Close();
            return dt;
        }

        public DataSet ReadDataSet(String strSql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlDataAdapter Cmd = new SqlDataAdapter(strSql, Conn);
            Cmd.Fill(ds);
            Conn.Close();
            return ds;
        }

        public DataSet GetDataSet(String strSql, String tableName)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection(strConn);
            Conn.Open();
            SqlDataAdapter Cmd = new SqlDataAdapter(strSql, Conn);
            //根据虚表tableName填充DataSet
            Cmd.Fill(ds, tableName);
            Conn.Close();
            return ds;
        }

    }
}