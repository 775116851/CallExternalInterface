using allinpay.O2O.Cmn;
using DataSyncRWY.Common;
using DataSyncRWY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DataSyncRWY.DAL
{
    /// <summary>
    /// 数据访问类SCENIC_RWY。
    /// </summary>
    public class SCENIC_RWYDac
    {
        public SCENIC_RWYDac() { }
        private static SCENIC_RWYDac _instance;
        public SCENIC_RWYDac GetInstance()
        {
            if (_instance == null)
            { _instance = new SCENIC_RWYDac(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SCENIC_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.SCENIC_RWY(");
            strSql.Append("ScenicId,Name,ShortName,TicketType,Star,OpenTime,BestTravelTime,Notice,Description,ImgUrl,Status,Contact,Addr,Latitude,Longitude,ProvinceName,CityName,Transportation,IsRealName,StartDateFlag,IdCardNeeded,ScenicDesc)");
            strSql.Append(" values (");
            strSql.Append("@ScenicId,@Name,@ShortName,@TicketType,@Star,@OpenTime,@BestTravelTime,@Notice,@Description,@ImgUrl,@Status,@Contact,@Addr,@Latitude,@Longitude,@ProvinceName,@CityName,@Transportation,@IsRealName,@StartDateFlag,@IdCardNeeded,@ScenicDesc)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@ScenicId",SqlDbType.NVarChar,64),
                 new SqlParameter("@Name",SqlDbType.NVarChar,64),
                 new SqlParameter("@ShortName",SqlDbType.NVarChar,64),
                 new SqlParameter("@TicketType",SqlDbType.NVarChar,64),
                 new SqlParameter("@Star",SqlDbType.NVarChar,64),
                 new SqlParameter("@OpenTime",SqlDbType.NVarChar,100),
                 new SqlParameter("@BestTravelTime",SqlDbType.NVarChar,100),
                 new SqlParameter("@Notice",SqlDbType.NText,2147483646),
                 new SqlParameter("@Description",SqlDbType.NText,2147483646),
                 new SqlParameter("@ImgUrl",SqlDbType.NVarChar,200),
                 new SqlParameter("@Status",SqlDbType.NVarChar,64),
                 new SqlParameter("@Contact",SqlDbType.NText,2147483646),
                 new SqlParameter("@Addr",SqlDbType.NVarChar,64),
                 new SqlParameter("@Latitude",SqlDbType.NVarChar,64),
                 new SqlParameter("@Longitude",SqlDbType.NVarChar,64),
                 new SqlParameter("@ProvinceName",SqlDbType.NVarChar,64),
                 new SqlParameter("@CityName",SqlDbType.NVarChar,64),
                 new SqlParameter("@Transportation",SqlDbType.NText,2147483646),
                 new SqlParameter("@IsRealName",SqlDbType.NVarChar,64),
                 new SqlParameter("@StartDateFlag",SqlDbType.NVarChar,64),
                 new SqlParameter("@IdCardNeeded",SqlDbType.NVarChar,64),
                 new SqlParameter("@ScenicDesc",SqlDbType.NText,2147483646)
             };
            if (model.ScenicId != AppConst.StringNull)
                parameters[0].Value = model.ScenicId;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.ShortName != AppConst.StringNull)
                parameters[2].Value = model.ShortName;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.TicketType != AppConst.StringNull)
                parameters[3].Value = model.TicketType;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Star != AppConst.StringNull)
                parameters[4].Value = model.Star;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.OpenTime != AppConst.StringNull)
                parameters[5].Value = model.OpenTime;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.BestTravelTime != AppConst.StringNull)
                parameters[6].Value = model.BestTravelTime;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Notice != AppConst.StringNull)
                parameters[7].Value = model.Notice;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.Description != AppConst.StringNull)
                parameters[8].Value = model.Description;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.ImgUrl != AppConst.StringNull)
                parameters[9].Value = model.ImgUrl;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.Status != AppConst.StringNull)
                parameters[10].Value = model.Status;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Contact != AppConst.StringNull)
                parameters[11].Value = model.Contact;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Addr != AppConst.StringNull)
                parameters[12].Value = model.Addr;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.Latitude != AppConst.StringNull)
                parameters[13].Value = model.Latitude;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.Longitude != AppConst.StringNull)
                parameters[14].Value = model.Longitude;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.ProvinceName != AppConst.StringNull)
                parameters[15].Value = model.ProvinceName;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.CityName != AppConst.StringNull)
                parameters[16].Value = model.CityName;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.Transportation != AppConst.StringNull)
                parameters[17].Value = model.Transportation;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.IsRealName != AppConst.StringNull)
                parameters[18].Value = model.IsRealName;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.StartDateFlag != AppConst.StringNull)
                parameters[19].Value = model.StartDateFlag;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            if (model.IdCardNeeded != AppConst.StringNull)
                parameters[20].Value = model.IdCardNeeded;
            else
                parameters[20].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[20]);
            if (model.ScenicDesc != AppConst.StringNull)
                parameters[21].Value = model.ScenicDesc;
            else
                parameters[21].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[21]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(AppConfig.Conn_IPP, cmd));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(SCENIC_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.SCENIC_RWY set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.ScenicId != AppConst.StringNull)
            {
                strSql.Append("ScenicId=@ScenicId,");
                SqlParameter param = new SqlParameter("@ScenicId", SqlDbType.NVarChar, 64);
                param.Value = model.ScenicId;
                cmd.Parameters.Add(param);
            }
            if (model.Name != AppConst.StringNull)
            {
                strSql.Append("Name=@Name,");
                SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 64);
                param.Value = model.Name;
                cmd.Parameters.Add(param);
            }
            if (model.ShortName != AppConst.StringNull)
            {
                strSql.Append("ShortName=@ShortName,");
                SqlParameter param = new SqlParameter("@ShortName", SqlDbType.NVarChar, 64);
                param.Value = model.ShortName;
                cmd.Parameters.Add(param);
            }
            if (model.TicketType != AppConst.StringNull)
            {
                strSql.Append("TicketType=@TicketType,");
                SqlParameter param = new SqlParameter("@TicketType", SqlDbType.NVarChar, 64);
                param.Value = model.TicketType;
                cmd.Parameters.Add(param);
            }
            if (model.Star != AppConst.StringNull)
            {
                strSql.Append("Star=@Star,");
                SqlParameter param = new SqlParameter("@Star", SqlDbType.NVarChar, 64);
                param.Value = model.Star;
                cmd.Parameters.Add(param);
            }
            if (model.OpenTime != AppConst.StringNull)
            {
                strSql.Append("OpenTime=@OpenTime,");
                SqlParameter param = new SqlParameter("@OpenTime", SqlDbType.NVarChar, 100);
                param.Value = model.OpenTime;
                cmd.Parameters.Add(param);
            }
            if (model.BestTravelTime != AppConst.StringNull)
            {
                strSql.Append("BestTravelTime=@BestTravelTime,");
                SqlParameter param = new SqlParameter("@BestTravelTime", SqlDbType.NVarChar, 100);
                param.Value = model.BestTravelTime;
                cmd.Parameters.Add(param);
            }
            if (model.Notice != AppConst.StringNull)
            {
                strSql.Append("Notice=@Notice,");
                SqlParameter param = new SqlParameter("@Notice", SqlDbType.NText, 2147483646);
                param.Value = model.Notice;
                cmd.Parameters.Add(param);
            }
            if (model.Description != AppConst.StringNull)
            {
                strSql.Append("Description=@Description,");
                SqlParameter param = new SqlParameter("@Description", SqlDbType.NText, 2147483646);
                param.Value = model.Description;
                cmd.Parameters.Add(param);
            }
            if (model.ImgUrl != AppConst.StringNull)
            {
                strSql.Append("ImgUrl=@ImgUrl,");
                SqlParameter param = new SqlParameter("@ImgUrl", SqlDbType.NVarChar, 200);
                param.Value = model.ImgUrl;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.StringNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.NVarChar, 64);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.Contact != AppConst.StringNull)
            {
                strSql.Append("Contact=@Contact,");
                SqlParameter param = new SqlParameter("@Contact", SqlDbType.NText, 2147483646);
                param.Value = model.Contact;
                cmd.Parameters.Add(param);
            }
            if (model.Addr != AppConst.StringNull)
            {
                strSql.Append("Addr=@Addr,");
                SqlParameter param = new SqlParameter("@Addr", SqlDbType.NVarChar, 64);
                param.Value = model.Addr;
                cmd.Parameters.Add(param);
            }
            if (model.Latitude != AppConst.StringNull)
            {
                strSql.Append("Latitude=@Latitude,");
                SqlParameter param = new SqlParameter("@Latitude", SqlDbType.NVarChar, 64);
                param.Value = model.Latitude;
                cmd.Parameters.Add(param);
            }
            if (model.Longitude != AppConst.StringNull)
            {
                strSql.Append("Longitude=@Longitude,");
                SqlParameter param = new SqlParameter("@Longitude", SqlDbType.NVarChar, 64);
                param.Value = model.Longitude;
                cmd.Parameters.Add(param);
            }
            if (model.ProvinceName != AppConst.StringNull)
            {
                strSql.Append("ProvinceName=@ProvinceName,");
                SqlParameter param = new SqlParameter("@ProvinceName", SqlDbType.NVarChar, 64);
                param.Value = model.ProvinceName;
                cmd.Parameters.Add(param);
            }
            if (model.CityName != AppConst.StringNull)
            {
                strSql.Append("CityName=@CityName,");
                SqlParameter param = new SqlParameter("@CityName", SqlDbType.NVarChar, 64);
                param.Value = model.CityName;
                cmd.Parameters.Add(param);
            }
            if (model.Transportation != AppConst.StringNull)
            {
                strSql.Append("Transportation=@Transportation,");
                SqlParameter param = new SqlParameter("@Transportation", SqlDbType.NText, 2147483646);
                param.Value = model.Transportation;
                cmd.Parameters.Add(param);
            }
            if (model.IsRealName != AppConst.StringNull)
            {
                strSql.Append("IsRealName=@IsRealName,");
                SqlParameter param = new SqlParameter("@IsRealName", SqlDbType.NVarChar, 64);
                param.Value = model.IsRealName;
                cmd.Parameters.Add(param);
            }
            if (model.StartDateFlag != AppConst.StringNull)
            {
                strSql.Append("StartDateFlag=@StartDateFlag,");
                SqlParameter param = new SqlParameter("@StartDateFlag", SqlDbType.NVarChar, 64);
                param.Value = model.StartDateFlag;
                cmd.Parameters.Add(param);
            }
            if (model.IdCardNeeded != AppConst.StringNull)
            {
                strSql.Append("IdCardNeeded=@IdCardNeeded,");
                SqlParameter param = new SqlParameter("@IdCardNeeded", SqlDbType.NVarChar, 64);
                param.Value = model.IdCardNeeded;
                cmd.Parameters.Add(param);
            }
            if (model.ScenicDesc != AppConst.StringNull)
            {
                strSql.Append("ScenicDesc=@ScenicDesc,");
                SqlParameter param = new SqlParameter("@ScenicDesc", SqlDbType.NText, 2147483646);
                param.Value = model.ScenicDesc;
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
        private SCENIC_RWYEntity SetDsToEntity(DataSet ds, SCENIC_RWYEntity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            model.ScenicId = ds.Tables[0].Rows[0]["ScenicId"].ToString();
            model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
            model.ShortName = ds.Tables[0].Rows[0]["ShortName"].ToString();
            model.TicketType = ds.Tables[0].Rows[0]["TicketType"].ToString();
            model.Star = ds.Tables[0].Rows[0]["Star"].ToString();
            model.OpenTime = ds.Tables[0].Rows[0]["OpenTime"].ToString();
            model.BestTravelTime = ds.Tables[0].Rows[0]["BestTravelTime"].ToString();
            model.Notice = ds.Tables[0].Rows[0]["Notice"].ToString();
            model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
            model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
            model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
            model.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
            model.Addr = ds.Tables[0].Rows[0]["Addr"].ToString();
            model.Latitude = ds.Tables[0].Rows[0]["Latitude"].ToString();
            model.Longitude = ds.Tables[0].Rows[0]["Longitude"].ToString();
            model.ProvinceName = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
            model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
            model.Transportation = ds.Tables[0].Rows[0]["Transportation"].ToString();
            model.IsRealName = ds.Tables[0].Rows[0]["IsRealName"].ToString();
            model.StartDateFlag = ds.Tables[0].Rows[0]["StartDateFlag"].ToString();
            model.IdCardNeeded = ds.Tables[0].Rows[0]["IdCardNeeded"].ToString();
            model.ScenicDesc = ds.Tables[0].Rows[0]["ScenicDesc"].ToString();
            return model;
        }

        private SCENIC_RWYEntity SetDrToEntity(DataRow dr, SCENIC_RWYEntity model)
        {
            if (dr["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(dr["SysNo"].ToString());
            }
            model.ScenicId = dr["ScenicId"].ToString();
            model.Name = dr["Name"].ToString();
            model.ShortName = dr["ShortName"].ToString();
            model.TicketType = dr["TicketType"].ToString();
            model.Star = dr["Star"].ToString();
            model.OpenTime = dr["OpenTime"].ToString();
            model.BestTravelTime = dr["BestTravelTime"].ToString();
            model.Notice = dr["Notice"].ToString();
            model.Description = dr["Description"].ToString();
            model.ImgUrl = dr["ImgUrl"].ToString();
            model.Status = dr["Status"].ToString();
            model.Contact = dr["Contact"].ToString();
            model.Addr = dr["Addr"].ToString();
            model.Latitude = dr["Latitude"].ToString();
            model.Longitude = dr["Longitude"].ToString();
            model.ProvinceName = dr["ProvinceName"].ToString();
            model.CityName = dr["CityName"].ToString();
            model.Transportation = dr["Transportation"].ToString();
            model.IsRealName = dr["IsRealName"].ToString();
            model.StartDateFlag = dr["StartDateFlag"].ToString();
            model.IdCardNeeded = dr["IdCardNeeded"].ToString();
            model.ScenicDesc = dr["ScenicDesc"].ToString();
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SCENIC_RWYEntity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  dbo.SCENIC_RWY");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            SCENIC_RWYEntity model = new SCENIC_RWYEntity();
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

        public SCENIC_RWYEntity GetModelByScenicID(string scenicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.SCENIC_RWY ");
            strSql.Append(" WHERE ScenicId = @scenicId ");
            SqlParameter[] parameters = { 
		        new SqlParameter("@scenicId",SqlDbType.NVarChar,64 )
 		    };
            parameters[0].Value = scenicID;
            SCENIC_RWYEntity model = new SCENIC_RWYEntity();
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

        public List<SCENIC_RWYEntity> GetList()
        {
            List<SCENIC_RWYEntity> list = new List<SCENIC_RWYEntity>();
            string sql = "SELECT * FROM dbo.SCENIC_RWY";
            DataSet ds = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sql);
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    SCENIC_RWYEntity sc = new SCENIC_RWYEntity();
                    SetDrToEntity(dr, sc);
                    list.Add(sc);
                    sc.ScenicDesc = ReturnDetail(sc.Description);
                    Update(sc);
                }
            }
            return list;
        }

        public string ReturnDetail(string strDE)
        {
            string str = strDE.Trim();
            string str2 = HttpUtility.HtmlDecode(str);
            string regStr = "<[^>]*>";
            string str3 = Regex.Replace(str2, regStr, "");
            string str4 = Regex.Replace(str3, "\\s*", "");
            return str4;
        }
        #endregion  成员方法
    }
}
