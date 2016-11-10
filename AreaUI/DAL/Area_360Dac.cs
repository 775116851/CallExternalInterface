using allinpay.O2O.Cmn;
using AreaUI.Common;
using AreaUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace AreaUI.DAL
{
    /// <summary>
    /// 数据访问类Area_360。
    /// </summary>
    public class Area_360Dac
    {
        public Area_360Dac() { }
        private static Area_360Dac _instance;
        public Area_360Dac GetInstance()
        {
            if (_instance == null)
            { _instance = new Area_360Dac(); }
            return _instance;
        }
        #region  成员方法
        public int AddNew(Area_360Entity model)
        {
            string sql = "";
            if (model.Classid != AppConst.IntNull)
            {
                sql = "SELECT DISTINCT SysNo FROM dbo.Area_360 WHERE Code = " + Util.ToSqlString(model.Code) + " AND Classid = " + Util.ToSqlString(Convert.ToString(model.Classid));
            }
            else
            {
                sql = "SELECT DISTINCT SysNo FROM dbo.Area_360 WHERE Code = " + Util.ToSqlString(model.Code) + " AND (Classid IS NULL OR ISNULL(Classid,'') = '')";
            }

            string sysNo = Convert.ToString(SqlHelper.ExecuteScalar(AppConfig.Conn_O2O2, sql));
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
        public int Add(Area_360Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.Area_360(");
            strSql.Append("CitySysNo,DistrictSysNo,Code,CityName,DistrictName,ZoneName,Classid,Hatrank,Status,LastUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@CitySysNo,@DistrictSysNo,@Code,@CityName,@DistrictName,@ZoneName,@Classid,@Hatrank,@Status,@LastUpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@CitySysNo",SqlDbType.Int,4),
                 new SqlParameter("@DistrictSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Code",SqlDbType.NVarChar,64),
                 new SqlParameter("@CityName",SqlDbType.NVarChar,30),
                 new SqlParameter("@DistrictName",SqlDbType.NVarChar,30),
                 new SqlParameter("@ZoneName",SqlDbType.NVarChar,20),
                 new SqlParameter("@Classid",SqlDbType.Int,4),
                 new SqlParameter("@Hatrank",SqlDbType.Int,4),
                 new SqlParameter("@Status",SqlDbType.SmallInt,2),
                 new SqlParameter("@LastUpdateTime",SqlDbType.DateTime),
             };
            if (model.CitySysNo != AppConst.IntNull)
                parameters[0].Value = model.CitySysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.DistrictSysNo != AppConst.IntNull)
                parameters[1].Value = model.DistrictSysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.Code != AppConst.StringNull)
                parameters[2].Value = model.Code;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.CityName != AppConst.StringNull)
                parameters[3].Value = model.CityName;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DistrictName != AppConst.StringNull)
                parameters[4].Value = model.DistrictName;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.ZoneName != AppConst.StringNull)
                parameters[5].Value = model.ZoneName;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Classid != AppConst.IntNull)
                parameters[6].Value = model.Classid;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Hatrank != AppConst.IntNull)
                parameters[7].Value = model.Hatrank;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Status != AppConst.IntNull)
                parameters[8].Value = model.Status;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.LastUpdateTime != AppConst.DateTimeNull)
                parameters[9].Value = model.LastUpdateTime;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(AppConfig.Conn_O2O2, cmd));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Area_360Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.Area_360 set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CitySysNo != AppConst.IntNull)
            {
                strSql.Append("CitySysNo=@CitySysNo,");
                SqlParameter param = new SqlParameter("@CitySysNo", SqlDbType.Int, 4);
                param.Value = model.CitySysNo;
                cmd.Parameters.Add(param);
            }
            if (model.DistrictSysNo != AppConst.IntNull)
            {
                strSql.Append("DistrictSysNo=@DistrictSysNo,");
                SqlParameter param = new SqlParameter("@DistrictSysNo", SqlDbType.Int, 4);
                param.Value = model.DistrictSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Code != AppConst.StringNull)
            {
                strSql.Append("Code=@Code,");
                SqlParameter param = new SqlParameter("@Code", SqlDbType.NVarChar, 64);
                param.Value = model.Code;
                cmd.Parameters.Add(param);
            }
            if (model.CityName != AppConst.StringNull)
            {
                strSql.Append("CityName=@CityName,");
                SqlParameter param = new SqlParameter("@CityName", SqlDbType.NVarChar, 30);
                param.Value = model.CityName;
                cmd.Parameters.Add(param);
            }
            if (model.DistrictName != AppConst.StringNull)
            {
                strSql.Append("DistrictName=@DistrictName,");
                SqlParameter param = new SqlParameter("@DistrictName", SqlDbType.NVarChar, 30);
                param.Value = model.DistrictName;
                cmd.Parameters.Add(param);
            }
            if (model.ZoneName != AppConst.StringNull)
            {
                strSql.Append("ZoneName=@ZoneName,");
                SqlParameter param = new SqlParameter("@ZoneName", SqlDbType.NVarChar, 20);
                param.Value = model.ZoneName;
                cmd.Parameters.Add(param);
            }
            if (model.Classid != AppConst.IntNull)
            {
                strSql.Append("Classid=@Classid,");
                SqlParameter param = new SqlParameter("@Classid", SqlDbType.Int, 4);
                param.Value = model.Classid;
                cmd.Parameters.Add(param);
            }
            if (model.Hatrank != AppConst.IntNull)
            {
                strSql.Append("Hatrank=@Hatrank,");
                SqlParameter param = new SqlParameter("@Hatrank", SqlDbType.Int, 4);
                param.Value = model.Hatrank;
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
            return SqlHelper.ExecuteNonQuery(AppConfig.Conn_O2O2, cmd);
        }
        /// <summary>
        /// 将DataRow赋值到实体
        /// </summary>
        private Area_360Entity SetDsToEntity(DataSet ds, Area_360Entity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["CitySysNo"].ToString() != "")
            {
                model.CitySysNo = int.Parse(ds.Tables[0].Rows[0]["CitySysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["DistrictSysNo"].ToString() != "")
            {
                model.DistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["DistrictSysNo"].ToString());
            }
            model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
            model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
            model.DistrictName = ds.Tables[0].Rows[0]["DistrictName"].ToString();
            model.ZoneName = ds.Tables[0].Rows[0]["ZoneName"].ToString();
            if (ds.Tables[0].Rows[0]["Classid"].ToString() != "")
            {
                model.Classid = int.Parse(ds.Tables[0].Rows[0]["Classid"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Hatrank"].ToString() != "")
            {
                model.Hatrank = int.Parse(ds.Tables[0].Rows[0]["Hatrank"].ToString());
            }
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
        public Area_360Entity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  dbo.Area_360");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            Area_360Entity model = new Area_360Entity();
            DataSet ds = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, strSql.ToString(), parameters);
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

        public Dictionary<int, Area_360Entity> GetAutoCityList(string cityName)
        {
            //MemcacheDictionary<DataTable> CachedAutoCityList = new MemcacheDictionary<DataTable>();
            //DataTable areaDT;
            //areaDT = CachedAutoCityList.Get("CachedAutoCityList");
            //if (areaDT == null)
            //{
            //    string sSql = "SELECT * FROM dbo.Area_360 WHERE CitySysNo IS NULL ORDER BY Code ASC";
            //    areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sSql).Tables[0];
            //    CachedAutoCityList.Set("CachedAutoCityList", areaDT, TimeSpan.FromMinutes(120));
            //}
            //DataRow[] provinceRows = areaDT.Select(" ProvinceSysNo IS NULL AND Status=" + (int)AppEnum.BiStatus.Valid);
            string sql = "SELECT * FROM dbo.Area_360 WHERE CitySysNo IS NULL ";
            if (!string.IsNullOrEmpty(cityName))
            {
                sql += " AND CityName =  " + Util.ToSqlString(cityName);
            }
            sql += " ORDER BY Code ASC ";
            DataTable cityDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sql).Tables[0];
            Dictionary<int, Area_360Entity> cityDic = new Dictionary<int, Area_360Entity>();
            for (int i = 0; i < cityDT.Rows.Count; i++)
            {
                DataRow dr = cityDT.Rows[i];
                Area_360Entity item = new Area_360Entity();
                Map(item, dr);
                cityDic.Add(item.SysNo, item);
            }
            return cityDic;
        }

        public Dictionary<int, Area_360Entity> GetADistrictsByCitySysNo(int citySysNo)
        {
            string sql = " SELECT * FROM dbo.Area_360 WHERE DistrictSysNo IS NULL AND CitySysNo = '" + citySysNo + "' AND Status = '0' ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sql).Tables[0];
            Dictionary<int, Area_360Entity> disctrictDic = new Dictionary<int, Area_360Entity>();
            for (int i = 0; i < areaDT.Rows.Count; i++)
            {
                DataRow dr = areaDT.Rows[i];
                Area_360Entity item = new Area_360Entity();
                Map(item, dr);
                disctrictDic.Add(item.SysNo, item);
            }
            return disctrictDic;
        }

        public Dictionary<int, Area_360Entity> GetAZonesByDistrictSysNo(int citySysNo)
        {
            string sql = " SELECT * FROM dbo.Area_360 WHERE DistrictSysNo = '" + citySysNo + "' AND Status = '0' ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sql).Tables[0];
            Dictionary<int, Area_360Entity> disctrictDic = new Dictionary<int, Area_360Entity>();
            for (int i = 0; i < areaDT.Rows.Count; i++)
            {
                DataRow dr = areaDT.Rows[i];
                Area_360Entity item = new Area_360Entity();
                Map(item, dr);
                disctrictDic.Add(item.SysNo, item);
            }
            return disctrictDic;
        }

        public Area_360Entity GetAAreaBySysNo(int sysNo)
        {
            return new Area_360Dac().GetModel(sysNo);
        }

        private void Map(Area_360Entity oParam, DataRow tempdr)
        {
            oParam.SysNo = Util.TrimIntNull(tempdr["SysNo"]);
            oParam.CitySysNo = Util.TrimIntNull(tempdr["CitySysNo"]);
            oParam.DistrictSysNo = Util.TrimIntNull(tempdr["DistrictSysNo"]);
            oParam.Code = Util.TrimNull(tempdr["Code"]);
            oParam.CityName = Util.TrimNull(tempdr["CityName"]);
            oParam.DistrictName = Util.TrimNull(tempdr["DistrictName"]);
            oParam.ZoneName = Util.TrimNull(tempdr["ZoneName"]);
            oParam.Classid = Util.TrimIntNull(tempdr["Classid"]);
            oParam.Hatrank = Util.TrimIntNull(tempdr["Hatrank"]);
            oParam.Status = Util.TrimIntNull(tempdr["Status"]);
            oParam.LastUpdateTime = Util.TrimDateNull(tempdr["LastUpdateTime"]);
        }
        #endregion  成员方法
    }
}