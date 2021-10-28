using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace HamacoAPI
{
    public static class p
    {
        public static string constring = @"server=datacenter.nextsoft.vn;Database=nhathuoc.danhdao;UID=ns;PWD=fzqJ@32X]@aynp{s-9:u;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";



        public static string Right(string value, int length)
        {
            if (value.Length >= length)
                return value.Substring(value.Length - length, length);
            else
                return "";
        }

        public static string Left(string value, int length)
        {
            if (value.Length >= length)
                return value.Substring(0, length);
            else
                return "";
        }

        public static string Mid(string str, int index, int len)
        {
            return str.Substring(index, len);
        }
        public static SqlCommandBuilder cb;




        public static DateTime GetDate(SqlConnection conn)
        {
            DateTime dt = DateTime.MinValue;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            //Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT GETDATE()";
            //DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() != "") dt = Convert.ToDateTime(reader[0]);
            }

            //Huy doi tuong
            cmd.Dispose(); cmd = null;
            reader.Dispose(); reader = null;
            conn.Close();

            return dt;
        }


 

     

    

        public static Task<int> _ExecuteSync(string sSQL)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new SqlConnection(constring))
                using (var newCommand = new SqlCommand(sSQL, newConnection))
                {
                    newCommand.CommandType = CommandType.Text;
                    newConnection.Open();
                    return newCommand.ExecuteNonQuery();
                }
            });
        }

        public static int _ExecuteSQL(string sSQL)
        {

            using (var newConnection = new SqlConnection(constring))
            using (var newCommand = new SqlCommand(sSQL, newConnection))
            {
                newCommand.CommandType = CommandType.Text;
                newConnection.Open();
                return newCommand.ExecuteNonQuery();
            }

        }


        public static Task<DataTable> _SelectSync(string sSQL)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new SqlConnection(constring))
                using (var mySQLAdapter = new SqlDataAdapter(sSQL, newConnection))
                {
                    mySQLAdapter.SelectCommand.CommandType = CommandType.Text;
                    DataTable myDt = new DataTable();
                    mySQLAdapter.Fill(myDt);
                    return myDt;
                }
            });
        }
        public static Task<DataTable> _SelectSyncWithConnString(string sSQL, string constring)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new SqlConnection(constring))
                using (var mySQLAdapter = new SqlDataAdapter(sSQL, newConnection))
                {
                    mySQLAdapter.SelectCommand.CommandType = CommandType.Text;
                    DataTable myDt = new DataTable();
                    mySQLAdapter.Fill(myDt);
                    return myDt;
                }
            });
        }
        public static Task<int> _ExecuteSyncWithConnString(string sSQL, string constring)
        {
            return Task.Run(() =>
            {
                using (var newConnection = new SqlConnection(constring))
                using (var newCommand = new SqlCommand(sSQL, newConnection))
                {
                    newCommand.CommandType = CommandType.Text;
                    newConnection.Open();
                    return newCommand.ExecuteNonQuery();
                }
            });
        }


        public static DateTime getStartCurMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }
        public static DataTable _SQLTraveDatatable(string sSQL)
        {
            using (var newConnection = new SqlConnection(constring))
            using (var da = new SqlDataAdapter(sSQL, newConnection))
            {
                da.SelectCommand.CommandTimeout = 0;
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt.Tables[0];
            }
        }

        public static DataTable _SQLTraveDatatableWithConnstring(string sSQL, string constring)
        {
            using (var newConnection = new SqlConnection(constring))
            using (var da = new SqlDataAdapter(sSQL, newConnection))
            {
                da.SelectCommand.CommandTimeout = 0;
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt.Tables[0];
            }
        }

        public static DataTable _SQLTraveDatatable(string SQL, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
            da.SelectCommand.CommandTimeout = 0;
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt.Tables[0];
        }


        public static DateTime getEndCurMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

    }




}
