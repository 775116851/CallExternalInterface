using allinpay.O2O.Cmn;
using DataSyncRWY.Common;
using DataSyncRWY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataSyncRWY.DAL
{
    /// <summary>
    /// 数据访问类Area_RWY。
    /// </summary>
    public class Area_RWYDac
    {
        public Area_RWYDac() { }
        private static Area_RWYDac _instance;
        public Area_RWYDac GetInstance()
        {
            if (_instance == null)
            { _instance = new Area_RWYDac(); }
            return _instance;
        }
        #region  成员方法
        public int AddNew(Area_RWYEntity model)
        {
            string sql = "";
            if (model.RWYCode != AppConst.StringNull)
            {
                sql = "SELECT DISTINCT SysNo FROM Area_RWY WHERE RWYCode = " + Util.ToSqlString(model.RWYCode) + " AND [Status] = '0'";
            }

            string sysNo = Convert.ToString(SqlHelper.ExecuteScalar(AppConfig.Conn_IPP, sql));
            if (!string.IsNullOrEmpty(sysNo))
            {
                return Convert.ToInt32(sysNo);
            }
            else
            {
                return Add(model);
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Area_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.Area_RWY(");
            strSql.Append("ProvinceSysNo,CitySysNo,RWYCode,ProvinceName,CityName,ZoneName,Status,LastUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@ProvinceSysNo,@CitySysNo,@RWYCode,@ProvinceName,@CityName,@ZoneName,@Status,@LastUpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ProvinceSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CitySysNo",SqlDbType.Int,4),
                 new SqlParameter("@RWYCode",SqlDbType.NVarChar,64),
                 new SqlParameter("@ProvinceName",SqlDbType.NVarChar,20),
                 new SqlParameter("@CityName",SqlDbType.NVarChar,30),
                 new SqlParameter("@ZoneName",SqlDbType.NVarChar,20),
                 new SqlParameter("@Status",SqlDbType.SmallInt,2),
                 new SqlParameter("@LastUpdateTime",SqlDbType.DateTime),
             };
            if (model.ProvinceSysNo != AppConst.IntNull)
                parameters[0].Value = model.ProvinceSysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CitySysNo != AppConst.IntNull)
                parameters[1].Value = model.CitySysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.RWYCode != AppConst.StringNull)
                parameters[2].Value = model.RWYCode;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.ProvinceName != AppConst.StringNull)
                parameters[3].Value = model.ProvinceName;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.CityName != AppConst.StringNull)
                parameters[4].Value = model.CityName;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.ZoneName != AppConst.StringNull)
                parameters[5].Value = model.ZoneName;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Status != AppConst.IntNull)
                parameters[6].Value = model.Status;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.LastUpdateTime != AppConst.DateTimeNull)
                parameters[7].Value = model.LastUpdateTime;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(AppConfig.Conn_IPP, cmd));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Area_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.Area_RWY set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.ProvinceSysNo != AppConst.IntNull)
            {
                strSql.Append("ProvinceSysNo=@ProvinceSysNo,");
                SqlParameter param = new SqlParameter("@ProvinceSysNo", SqlDbType.Int, 4);
                param.Value = model.ProvinceSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CitySysNo != AppConst.IntNull)
            {
                strSql.Append("CitySysNo=@CitySysNo,");
                SqlParameter param = new SqlParameter("@CitySysNo", SqlDbType.Int, 4);
                param.Value = model.CitySysNo;
                cmd.Parameters.Add(param);
            }
            if (model.RWYCode != AppConst.StringNull)
            {
                strSql.Append("RWYCode=@RWYCode,");
                SqlParameter param = new SqlParameter("@RWYCode", SqlDbType.NVarChar, 64);
                param.Value = model.RWYCode;
                cmd.Parameters.Add(param);
            }
            if (model.ProvinceName != AppConst.StringNull)
            {
                strSql.Append("ProvinceName=@ProvinceName,");
                SqlParameter param = new SqlParameter("@ProvinceName", SqlDbType.NVarChar, 20);
                param.Value = model.ProvinceName;
                cmd.Parameters.Add(param);
            }
            if (model.CityName != AppConst.StringNull)
            {
                strSql.Append("CityName=@CityName,");
                SqlParameter param = new SqlParameter("@CityName", SqlDbType.NVarChar, 30);
                param.Value = model.CityName;
                cmd.Parameters.Add(param);
            }
            if (model.ZoneName != AppConst.StringNull)
            {
                strSql.Append("ZoneName=@ZoneName,");
                SqlParameter param = new SqlParameter("@ZoneName", SqlDbType.NVarChar, 20);
                param.Value = model.ZoneName;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.SmallInt, 2);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.LastUpdateTime != AppConst.DateTimeNull)
            {
                strSql.Append("LastUpdateTime=@LastUpdateTime,");
                SqlParameter param = new SqlParameter("@LastUpdateTime", SqlDbType.DateTime);
                param.Value = model.LastUpdateTime;
                cmd.Parameters.Add(param);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where SysNo=@SysNo ");
            cmd.CommandText = strSql.ToString();
            return SqlHelper.ExecuteNonQuery(AppConfig.Conn_IPP, cmd);
        }
        /// <summary>
        /// 将DataRow赋值到实体
        /// </summary>
        private Area_RWYEntity SetDsToEntity(DataSet ds, Area_RWYEntity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString() != "")
            {
                model.ProvinceSysNo = int.Parse(ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["CitySysNo"].ToString() != "")
            {
                model.CitySysNo = int.Parse(ds.Tables[0].Rows[0]["CitySysNo"].ToString());
            }
            model.RWYCode = ds.Tables[0].Rows[0]["RWYCode"].ToString();
            model.ProvinceName = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
            model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
            model.ZoneName = ds.Tables[0].Rows[0]["ZoneName"].ToString();
            if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
            {
                model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Area_RWYEntity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  dbo.Area_RWY");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            Area_RWYEntity model = new Area_RWYEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                SetDsToEntity(ds, model);
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法
    }
}
