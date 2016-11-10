using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace O2OTest
{
    public abstract class SqlHelper
    {
        //private static readonly ILog _log = LogManager.GetLogger(typeof(SqlHelper));
        public static readonly string ConnectionStringLocal = ConfigurationManager.ConnectionStrings["Conn_O2O2"].ToString();


        /// <summary>
        /// 修改默认 SqlCommand Timeout 的值，默认为30s，目前设置为120s
        /// </summary>
        public static readonly int Default_Timeout_Value = 120;

        public static object ExecuteScalar(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;
            return ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(string connectstring, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;
            return ExecuteScalar(connectstring, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(string cmdText, SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;

            if (paras != null && paras.Length > 0)
            {
                SqlParameter[] temp = new SqlParameter[paras.Length];
                for (int i = 0; i < paras.Length; i++)
                {
                    temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                }
                cmd.Parameters.AddRange(temp);
            }

            return ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(string connectstring, string cmdText, SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;

            if (paras != null && paras.Length > 0)
            {
                SqlParameter[] temp = new SqlParameter[paras.Length];
                for (int i = 0; i < paras.Length; i++)
                {
                    temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                }
                cmd.Parameters.AddRange(temp);
            }

            return ExecuteScalar(connectstring, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(SqlCommand cmd)
        {
            return ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(string connectstring, SqlCommand cmd)
        {
            return ExecuteScalar(connectstring, CommandType.Text, cmd);
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = Default_Timeout_Value;

                return cmd.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;
            return ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static int ExecuteNonQuery(string connectString, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;
            return ExecuteNonQuery(connectString, CommandType.Text, cmd);
        }

        public static int ExecuteNonQuery(string cmdText, SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;

            if (paras != null && paras.Length > 0)
            {
                SqlParameter[] temp = new SqlParameter[paras.Length];
                for (int i = 0; i < paras.Length; i++)
                {
                    temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                }
                cmd.Parameters.AddRange(temp);
            }

            return ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static int ExecuteNonQuery(string connectionString, string cmdText, SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;

            if (paras != null && paras.Length > 0)
            {
                SqlParameter[] temp = new SqlParameter[paras.Length];
                for (int i = 0; i < paras.Length; i++)
                {
                    temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                }
                cmd.Parameters.AddRange(temp);
            }

            return ExecuteNonQuery(connectionString, cmd);
        }
        public static int ExecuteNonQuery(string connectionString, string cmdText, SqlParameterCollection paras)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = Default_Timeout_Value;
            if (paras != null && paras.Count > 0)
            {
                SqlParameter[] temp = new SqlParameter[paras.Count];
                for (int i = 0; i < paras.Count; i++)
                {
                    temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                }
                cmd.Parameters.AddRange(temp);
            }

            return ExecuteNonQuery(connectionString, cmd);
        }

        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            return ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd);
        }

        public static int ExecuteNonQuery(string connectionString, SqlCommand cmd)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmd);
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = Default_Timeout_Value;

                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rowsAffected;
            }
        }

        public static int ExecuteNonQuery(SqlCommand cmd, out int sysno)
        {
            return ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, cmd, out sysno);
        }

        public static int ExecuteNonQuery(string connectionString, SqlCommand cmd, out int sysno)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmd, out sysno);
        }

        public static int ExecuteNonQuery(SqlCommand cmd, CommandType cmdType)
        {
            return ExecuteNonQuery(SqlHelper.ConnectionStringLocal, cmdType, cmd);
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, SqlCommand cmd, out int sysno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = Default_Timeout_Value;

                int rowsAffected = cmd.ExecuteNonQuery();

                //必须符合下面的条件
                if (cmd.Parameters.Contains("@SysNo") && cmd.Parameters["@SysNo"].Direction == ParameterDirection.Output)
                    sysno = (int)cmd.Parameters["@SysNo"].Value;
                else if (cmd.Parameters.Contains("@TransactionNumber") && cmd.Parameters["@TransactionNumber"].Direction == ParameterDirection.Output)
                    sysno = (int)cmd.Parameters["@TransactionNumber"].Value;
                else
                    throw new Exception("SqlHelper: Does not contain SysNo or ParameterDirection is Not Output");

                cmd.Parameters.Clear();
                return rowsAffected;
            }
        }

        public static DataSet ExecuteDataSet(string cmdText)
        {
            SqlParameter[] sp1 = { };
            return ExecuteDataSet(SqlHelper.ConnectionStringLocal, cmdText, sp1);
        }

        public static DataSet ExecuteDataSet(string connectionString, string cmdText)
        {
            SqlParameter[] sp1 = { };
            return ExecuteDataSet(connectionString, cmdText, sp1);
        }

        public static DataSet ExecuteDataSet(string cmdText, SqlParameter[] paras)
        {
            return ExecuteDataSet(SqlHelper.ConnectionStringLocal, cmdText, paras);
        }

        public static DataSet ExecuteDataSet(string connectionString, string cmdText, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Default_Timeout_Value;



                if (paras != null && paras.Length > 0)
                {
                    SqlParameter[] temp = new SqlParameter[paras.Length];
                    for (int i = 0; i < paras.Length; i++)
                    {
                        temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                    }
                    cmd.Parameters.AddRange(temp);
                }

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = cmd;
                DataSet dataSet = new DataSet("mySet");
                sqlDA.Fill(dataSet, "Anonymous");

                return dataSet;
            }
        }
        public static DataSet ExecuteDataSet(string connectionString, string cmdText, SqlParameterCollection paras)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = Default_Timeout_Value;



                if (paras != null && paras.Count > 0)
                {
                    SqlParameter[] temp = new SqlParameter[paras.Count];
                    for (int i = 0; i < paras.Count; i++)
                    {
                        temp[i] = (SqlParameter)((ICloneable)paras[i]).Clone();
                    }
                    cmd.Parameters.AddRange(temp);
                }

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = cmd;
                DataSet dataSet = new DataSet("mySet");
                sqlDA.Fill(dataSet, "Anonymous");

                return dataSet;
            }
        }

        public static DataSet ExecuteDataSet(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocal))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandTimeout = Default_Timeout_Value;

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = cmd;
                DataSet dataSet = new DataSet("mySet");
                sqlDA.Fill(dataSet, "Anonymous");

                return dataSet;
            }
        }

        public static DataSet ExecuteDataSet(string ConnectString, SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.Connection = conn;
                cmd.CommandTimeout = Default_Timeout_Value;

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = cmd;
                DataSet dataSet = new DataSet("mySet");
                sqlDA.Fill(dataSet, "Anonymous");

                return dataSet;
            }
        }

        public static DataSet ExecuteDataSet(string cmdText, string type, SqlParameter[] paras, ref string output)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocal))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if (type == "StoredProcedure")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                cmd.CommandTimeout = Default_Timeout_Value;

                if (paras != null && paras.Length > 0)
                    cmd.Parameters.AddRange(paras);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = cmd;
                DataSet dataSet = new DataSet("mySet");
                sqlDA.Fill(dataSet, "Anonymous");
                output = dataSet.Tables[1].Rows[0][0].ToString();
                return dataSet;
            }
        }
    }
}