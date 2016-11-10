using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using allinpay.O2O.Cmn;
using AreaUI.Common;
using AreaUI.Model;
using System.Text;

namespace AreaUI.DAL
{
    /// <summary>
    /// 数据访问类Area。
    /// </summary>
    public class AreaDac
    {
        public AreaDac() { }
        private static AreaDac _instance;
        public AreaDac GetInstance()
        {
            if (_instance == null)
            { _instance = new AreaDac(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(AreaEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.Area(");
            strSql.Append("SysNo,AreaID,ProvinceSysNo,CitySysNo,DistrictSysNo,ProvinceName,CityName,DistrictName,ZoneName,SortNo,Status,IsMaster,IsOnlineShow,LastUpdateUser,LastUpdateTime,POSAreaCode,CustomerSort,OldSysNo,OldProvinceSysNo,OldCitySysNo,OldDistrictSysNo,Area_360_SysNo,Area_360_CityName,Area_360_ZoneName,Area_RWY_SysNo,AreaLevel)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@AreaID,@ProvinceSysNo,@CitySysNo,@DistrictSysNo,@ProvinceName,@CityName,@DistrictName,@ZoneName,@SortNo,@Status,@IsMaster,@IsOnlineShow,@LastUpdateUser,@LastUpdateTime,@POSAreaCode,@CustomerSort,@OldSysNo,@OldProvinceSysNo,@OldCitySysNo,@OldDistrictSysNo,@Area_360_SysNo,@Area_360_CityName,@Area_360_ZoneName,@Area_RWY_SysNo,@AreaLevel)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@AreaID",SqlDbType.VarChar,5),
                 new SqlParameter("@ProvinceSysNo",SqlDbType.Int,4),
                 new SqlParameter("@CitySysNo",SqlDbType.Int,4),
                 new SqlParameter("@DistrictSysNo",SqlDbType.Int,4),
                 new SqlParameter("@ProvinceName",SqlDbType.NVarChar,20),
                 new SqlParameter("@CityName",SqlDbType.NVarChar,30),
                 new SqlParameter("@DistrictName",SqlDbType.NVarChar,30),
                 new SqlParameter("@ZoneName",SqlDbType.NVarChar,20),
                 new SqlParameter("@SortNo",SqlDbType.Int,4),
                 new SqlParameter("@Status",SqlDbType.SmallInt,2),
                 new SqlParameter("@IsMaster",SqlDbType.Int,4),
                 new SqlParameter("@IsOnlineShow",SqlDbType.SmallInt,2),
                 new SqlParameter("@LastUpdateUser",SqlDbType.Int,4),
                 new SqlParameter("@LastUpdateTime",SqlDbType.DateTime),
                 new SqlParameter("@POSAreaCode",SqlDbType.Char,4),
                 new SqlParameter("@CustomerSort",SqlDbType.VarChar,50),
                 new SqlParameter("@OldSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OldProvinceSysNo",SqlDbType.Int,4),
                 new SqlParameter("@OldCitySysNo",SqlDbType.Int,4),
                 new SqlParameter("@OldDistrictSysNo",SqlDbType.Int,4),
                 new SqlParameter("@Area_360_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Area_360_CityName",SqlDbType.NVarChar,30),
                 new SqlParameter("@Area_360_ZoneName",SqlDbType.NVarChar,20),
                 new SqlParameter("@Area_RWY_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@AreaLevel",SqlDbType.Int,4)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.AreaID != AppConst.StringNull)
                parameters[1].Value = model.AreaID;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.ProvinceSysNo != AppConst.IntNull)
                parameters[2].Value = model.ProvinceSysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.CitySysNo != AppConst.IntNull)
                parameters[3].Value = model.CitySysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.DistrictSysNo != AppConst.IntNull)
                parameters[4].Value = model.DistrictSysNo;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.ProvinceName != AppConst.StringNull)
                parameters[5].Value = model.ProvinceName;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.CityName != AppConst.StringNull)
                parameters[6].Value = model.CityName;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.DistrictName != AppConst.StringNull)
                parameters[7].Value = model.DistrictName;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.ZoneName != AppConst.StringNull)
                parameters[8].Value = model.ZoneName;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.SortNo != AppConst.IntNull)
                parameters[9].Value = model.SortNo;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.Status != AppConst.IntNull)
                parameters[10].Value = model.Status;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.IsMaster != AppConst.IntNull)
                parameters[11].Value = model.IsMaster;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.IsOnlineShow != AppConst.IntNull)
                parameters[12].Value = model.IsOnlineShow;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.LastUpdateUser != AppConst.IntNull)
                parameters[13].Value = model.LastUpdateUser;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.LastUpdateTime != AppConst.DateTimeNull)
                parameters[14].Value = model.LastUpdateTime;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.POSAreaCode != AppConst.StringNull)
                parameters[15].Value = model.POSAreaCode;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.CustomerSort != AppConst.StringNull)
                parameters[16].Value = model.CustomerSort;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.OldSysNo != AppConst.IntNull)
                parameters[17].Value = model.OldSysNo;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.OldProvinceSysNo != AppConst.IntNull)
                parameters[18].Value = model.OldProvinceSysNo;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.OldCitySysNo != AppConst.IntNull)
                parameters[19].Value = model.OldCitySysNo;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            if (model.OldDistrictSysNo != AppConst.IntNull)
                parameters[20].Value = model.OldDistrictSysNo;
            else
                parameters[20].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[20]);
            if (model.Area_360_SysNo != AppConst.IntNull)
                parameters[21].Value = model.Area_360_SysNo;
            else
                parameters[21].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[21]);
            if (model.Area_360_CityName != AppConst.StringNull)
                parameters[22].Value = model.Area_360_CityName;
            else
                parameters[22].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[22]);
            if (model.Area_360_ZoneName != AppConst.StringNull)
                parameters[23].Value = model.Area_360_ZoneName;
            else
                parameters[23].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[23]);
            if (model.Area_RWY_SysNo != AppConst.IntNull)
                parameters[24].Value = model.Area_RWY_SysNo;
            else
                parameters[24].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[24]);
            if (model.AreaLevel != AppConst.IntNull)
                parameters[25].Value = model.AreaLevel;
            else
                parameters[25].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[25]);
            SqlHelper.ExecuteNonQuery(AppConfig.Conn_IPP, cmd);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(AreaEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.Area set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                strSql.Append("SysNo=@SysNo,");
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.AreaID != AppConst.StringNull)
            {
                strSql.Append("AreaID=@AreaID,");
                SqlParameter param = new SqlParameter("@AreaID", SqlDbType.VarChar, 5);
                param.Value = model.AreaID;
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
            if (model.DistrictSysNo != AppConst.IntNull)
            {
                strSql.Append("DistrictSysNo=@DistrictSysNo,");
                SqlParameter param = new SqlParameter("@DistrictSysNo", SqlDbType.Int, 4);
                param.Value = model.DistrictSysNo;
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
            if (model.SortNo != AppConst.IntNull)
            {
                strSql.Append("SortNo=@SortNo,");
                SqlParameter param = new SqlParameter("@SortNo", SqlDbType.Int, 4);
                param.Value = model.SortNo;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.SmallInt, 2);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.IsMaster != AppConst.IntNull)
            {
                strSql.Append("IsMaster=@IsMaster,");
                SqlParameter param = new SqlParameter("@IsMaster", SqlDbType.Int, 4);
                param.Value = model.IsMaster;
                cmd.Parameters.Add(param);
            }
            if (model.IsOnlineShow != AppConst.IntNull)
            {
                strSql.Append("IsOnlineShow=@IsOnlineShow,");
                SqlParameter param = new SqlParameter("@IsOnlineShow", SqlDbType.SmallInt, 2);
                param.Value = model.IsOnlineShow;
                cmd.Parameters.Add(param);
            }
            if (model.LastUpdateUser != AppConst.IntNull)
            {
                strSql.Append("LastUpdateUser=@LastUpdateUser,");
                SqlParameter param = new SqlParameter("@LastUpdateUser", SqlDbType.Int, 4);
                param.Value = model.LastUpdateUser;
                cmd.Parameters.Add(param);
            }
            if (model.LastUpdateTime != AppConst.DateTimeNull)
            {
                strSql.Append("LastUpdateTime=@LastUpdateTime,");
                SqlParameter param = new SqlParameter("@LastUpdateTime", SqlDbType.DateTime);
                param.Value = model.LastUpdateTime;
                cmd.Parameters.Add(param);
            }
            if (model.POSAreaCode != AppConst.StringNull)
            {
                strSql.Append("POSAreaCode=@POSAreaCode,");
                SqlParameter param = new SqlParameter("@POSAreaCode", SqlDbType.Char, 4);
                param.Value = model.POSAreaCode;
                cmd.Parameters.Add(param);
            }
            if (model.CustomerSort != AppConst.StringNull)
            {
                strSql.Append("CustomerSort=@CustomerSort,");
                SqlParameter param = new SqlParameter("@CustomerSort", SqlDbType.VarChar, 50);
                param.Value = model.CustomerSort;
                cmd.Parameters.Add(param);
            }
            if (model.OldSysNo != AppConst.IntNull)
            {
                strSql.Append("OldSysNo=@OldSysNo,");
                SqlParameter param = new SqlParameter("@OldSysNo", SqlDbType.Int, 4);
                param.Value = model.OldSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.OldProvinceSysNo != AppConst.IntNull)
            {
                strSql.Append("OldProvinceSysNo=@OldProvinceSysNo,");
                SqlParameter param = new SqlParameter("@OldProvinceSysNo", SqlDbType.Int, 4);
                param.Value = model.OldProvinceSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.OldCitySysNo != AppConst.IntNull)
            {
                strSql.Append("OldCitySysNo=@OldCitySysNo,");
                SqlParameter param = new SqlParameter("@OldCitySysNo", SqlDbType.Int, 4);
                param.Value = model.OldCitySysNo;
                cmd.Parameters.Add(param);
            }
            if (model.OldDistrictSysNo != AppConst.IntNull)
            {
                strSql.Append("OldDistrictSysNo=@OldDistrictSysNo,");
                SqlParameter param = new SqlParameter("@OldDistrictSysNo", SqlDbType.Int, 4);
                param.Value = model.OldDistrictSysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Area_360_SysNo != AppConst.IntNull)
            {
                strSql.Append("Area_360_SysNo=@Area_360_SysNo,");
                SqlParameter param = new SqlParameter("@Area_360_SysNo", SqlDbType.Int, 4);
                param.Value = model.Area_360_SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Area_360_CityName != AppConst.StringNull)
            {
                strSql.Append("Area_360_CityName=@Area_360_CityName,");
                SqlParameter param = new SqlParameter("@Area_360_CityName", SqlDbType.NVarChar, 30);
                param.Value = model.Area_360_CityName;
                cmd.Parameters.Add(param);
            }
            if (model.Area_360_ZoneName != AppConst.StringNull)
            {
                strSql.Append("Area_360_ZoneName=@Area_360_ZoneName,");
                SqlParameter param = new SqlParameter("@Area_360_ZoneName", SqlDbType.NVarChar, 20);
                param.Value = model.Area_360_ZoneName;
                cmd.Parameters.Add(param);
            }
            if (model.Area_RWY_SysNo != AppConst.IntNull)
            {
                strSql.Append("Area_RWY_SysNo=@Area_RWY_SysNo,");
                SqlParameter param = new SqlParameter("@Area_RWY_SysNo", SqlDbType.Int, 4);
                param.Value = model.Area_RWY_SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.AreaLevel != AppConst.IntNull)
            {
                strSql.Append("AreaLevel=@AreaLevel,");
                SqlParameter param = new SqlParameter("@AreaLevel", SqlDbType.Int, 4);
                param.Value = model.AreaLevel;
                cmd.Parameters.Add(param);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where SysNo=@SysNo and AreaID=@AreaID and ProvinceSysNo=@ProvinceSysNo and CitySysNo=@CitySysNo and DistrictSysNo=@DistrictSysNo and ProvinceName=@ProvinceName and CityName=@CityName and DistrictName=@DistrictName and ZoneName=@ZoneName and SortNo=@SortNo and Status=@Status and IsMaster=@IsMaster and IsOnlineShow=@IsOnlineShow and LastUpdateUser=@LastUpdateUser and LastUpdateTime=@LastUpdateTime and POSAreaCode=@POSAreaCode and CustomerSort=@CustomerSort and OldSysNo=@OldSysNo and OldProvinceSysNo=@OldProvinceSysNo and OldCitySysNo=@OldCitySysNo and OldDistrictSysNo=@OldDistrictSysNo and Area_360_SysNo=@Area_360_SysNo and Area_360_CityName=@Area_360_CityName and Area_360_ZoneName=@Area_360_ZoneName and Area_RWY_SysNo=@Area_RWY_SysNo and AreaLevel=@AreaLevel ");
            cmd.CommandText = strSql.ToString();
            return SqlHelper.ExecuteNonQuery(AppConfig.Conn_IPP, cmd);
        }
        /// <summary>
        /// 将DataRow赋值到实体
        /// </summary>
        private AreaEntity SetDsToEntity(DataSet ds, AreaEntity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            model.AreaID = ds.Tables[0].Rows[0]["AreaID"].ToString();
            if (ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString() != "")
            {
                model.ProvinceSysNo = int.Parse(ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["CitySysNo"].ToString() != "")
            {
                model.CitySysNo = int.Parse(ds.Tables[0].Rows[0]["CitySysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["DistrictSysNo"].ToString() != "")
            {
                model.DistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["DistrictSysNo"].ToString());
            }
            model.ProvinceName = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
            model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
            model.DistrictName = ds.Tables[0].Rows[0]["DistrictName"].ToString();
            model.ZoneName = ds.Tables[0].Rows[0]["ZoneName"].ToString();
            if (ds.Tables[0].Rows[0]["SortNo"].ToString() != "")
            {
                model.SortNo = int.Parse(ds.Tables[0].Rows[0]["SortNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["IsMaster"].ToString() != "")
            {
                model.IsMaster = int.Parse(ds.Tables[0].Rows[0]["IsMaster"].ToString());
            }
            if (ds.Tables[0].Rows[0]["IsOnlineShow"].ToString() != "")
            {
                model.IsOnlineShow = int.Parse(ds.Tables[0].Rows[0]["IsOnlineShow"].ToString());
            }
            if (ds.Tables[0].Rows[0]["LastUpdateUser"].ToString() != "")
            {
                model.LastUpdateUser = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUser"].ToString());
            }
            if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
            {
                model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
            }
            model.POSAreaCode = ds.Tables[0].Rows[0]["POSAreaCode"].ToString();
            model.CustomerSort = ds.Tables[0].Rows[0]["CustomerSort"].ToString();
            if (ds.Tables[0].Rows[0]["OldSysNo"].ToString() != "")
            {
                model.OldSysNo = int.Parse(ds.Tables[0].Rows[0]["OldSysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["OldProvinceSysNo"].ToString() != "")
            {
                model.OldProvinceSysNo = int.Parse(ds.Tables[0].Rows[0]["OldProvinceSysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["OldCitySysNo"].ToString() != "")
            {
                model.OldCitySysNo = int.Parse(ds.Tables[0].Rows[0]["OldCitySysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["OldDistrictSysNo"].ToString() != "")
            {
                model.OldDistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["OldDistrictSysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Area_360_SysNo"].ToString() != "")
            {
                model.Area_360_SysNo = int.Parse(ds.Tables[0].Rows[0]["Area_360_SysNo"].ToString());
            }
            model.Area_360_CityName = ds.Tables[0].Rows[0]["Area_360_CityName"].ToString();
            model.Area_360_ZoneName = ds.Tables[0].Rows[0]["Area_360_ZoneName"].ToString();
            if (ds.Tables[0].Rows[0]["Area_RWY_SysNo"].ToString() != "")
            {
                model.Area_RWY_SysNo = int.Parse(ds.Tables[0].Rows[0]["Area_RWY_SysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["AreaLevel"].ToString() != "")
            {
                model.AreaLevel = int.Parse(ds.Tables[0].Rows[0]["AreaLevel"].ToString());
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AreaEntity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from area ");
            strSql.Append("where SysNo=@SysNo ");
            SqlParameter[] parameters = {
		        new SqlParameter("@SysNo",SqlDbType.Int,4),
             };
            parameters[0].Value = SysNo;
            
            AreaEntity model = new AreaEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.AreaID = ds.Tables[0].Rows[0]["AreaID"].ToString();
                if (ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString() != "")
                {
                    model.ProvinceSysNo = int.Parse(ds.Tables[0].Rows[0]["ProvinceSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CitySysNo"].ToString() != "")
                {
                    model.CitySysNo = int.Parse(ds.Tables[0].Rows[0]["CitySysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DistrictSysNo"].ToString() != "")
                {
                    model.DistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["DistrictSysNo"].ToString());
                }
                model.ProvinceName = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
                model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
                model.DistrictName = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                model.ZoneName = ds.Tables[0].Rows[0]["ZoneName"].ToString();
                if (ds.Tables[0].Rows[0]["SortNo"].ToString() != "")
                {
                    model.SortNo = int.Parse(ds.Tables[0].Rows[0]["SortNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMaster"].ToString() != "")
                {
                    model.IsMaster = int.Parse(ds.Tables[0].Rows[0]["IsMaster"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnlineShow"].ToString() != "")
                {
                    model.IsOnlineShow = int.Parse(ds.Tables[0].Rows[0]["IsOnlineShow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateUser"].ToString() != "")
                {
                    model.LastUpdateUser = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
                {
                    model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
                }
                model.POSAreaCode = ds.Tables[0].Rows[0]["POSAreaCode"].ToString();
                model.CustomerSort = ds.Tables[0].Rows[0]["CustomerSort"].ToString();
                if (ds.Tables[0].Rows[0]["OldSysNo"].ToString() != "")
                {
                    model.OldSysNo = int.Parse(ds.Tables[0].Rows[0]["OldSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OldProvinceSysNo"].ToString() != "")
                {
                    model.OldProvinceSysNo = int.Parse(ds.Tables[0].Rows[0]["OldProvinceSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OldCitySysNo"].ToString() != "")
                {
                    model.OldCitySysNo = int.Parse(ds.Tables[0].Rows[0]["OldCitySysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OldDistrictSysNo"].ToString() != "")
                {
                    model.OldDistrictSysNo = int.Parse(ds.Tables[0].Rows[0]["OldDistrictSysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Area_360_SysNo"].ToString() != "")
                {
                    model.Area_360_SysNo = int.Parse(ds.Tables[0].Rows[0]["Area_360_SysNo"].ToString());
                }
                model.Area_360_CityName = ds.Tables[0].Rows[0]["Area_360_CityName"].ToString();
                model.Area_360_ZoneName = ds.Tables[0].Rows[0]["Area_360_ZoneName"].ToString();
                if (ds.Tables[0].Rows[0]["Area_RWY_SysNo"].ToString() != "")
                {
                    model.Area_RWY_SysNo = int.Parse(ds.Tables[0].Rows[0]["Area_RWY_SysNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaLevel"].ToString() != "")
                {
                    model.AreaLevel = int.Parse(ds.Tables[0].Rows[0]["AreaLevel"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public Dictionary<int, AreaEntity> GetProvinces()
        {
            string sSql = " SELECT * FROM dbo.Area WHERE ProvinceSysNo IS NULL AND Status='0' ORDER BY SysNo ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP,sSql).Tables[0];
            DataRow[] provinceRows = areaDT.Select(" ProvinceSysNo IS NULL AND Status=" + (int)AppEnum.BiStatus.Valid);
            Dictionary<int, AreaEntity> provinceDic = new Dictionary<int, AreaEntity>();
            foreach (DataRow dr in provinceRows)
            {
                AreaEntity item = new AreaEntity();
                Map(item, dr);
                provinceDic.Add(item.SysNo, item);
            }
            return provinceDic;
        }

        public Dictionary<int, AreaEntity> GetCitiesByProvinceSysNo(int provinceSysNo)
        {
            string sSql = " SELECT * FROM dbo.Area WHERE ProvinceSysNo=" + provinceSysNo + " AND CitySysNo IS NULL ORDER BY SysNo ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sSql).Tables[0];
            DataRow[] cityRows = areaDT.Select(" ProvinceSysNo=" + provinceSysNo + " AND CitySysNo IS NULL");
            Dictionary<int, AreaEntity> cityDic = new Dictionary<int, AreaEntity>();
            foreach (DataRow dr in cityRows)
            {
                AreaEntity item = new AreaEntity();
                Map(item, dr);
                cityDic.Add(item.SysNo, item);
            }
            return cityDic;
        }

        public Dictionary<int, AreaEntity> GetDistrictsByCitySysNo(int citySysNo)
        {
            string sSql = " SELECT * FROM dbo.Area WHERE CitySysNo=" + citySysNo + " AND DistrictSysNo IS NULL AND Status='0' ORDER BY SysNo ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sSql).Tables[0];
            DataRow[] disctrictRows = areaDT.Select(" CitySysNo=" + citySysNo + " AND DistrictSysNo IS NULL AND Status=" + (int)AppEnum.BiStatus.Valid);
            Dictionary<int, AreaEntity> disctrictDic = new Dictionary<int, AreaEntity>();
            foreach (DataRow dr in disctrictRows)
            {
                AreaEntity item = new AreaEntity();
                Map(item, dr);
                disctrictDic.Add(item.SysNo, item);
            }
            return disctrictDic;
        }

        public Dictionary<int, AreaEntity> GetZonesByDistrictSysNo(int disctrictSysNo)
        {
            string sSql = " SELECT * FROM dbo.Area WHERE DistrictSysNo=" + disctrictSysNo + " AND Status='0' ORDER BY SysNo ";
            DataTable areaDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_IPP, sSql).Tables[0];
            DataRow[] zoneRows = areaDT.Select(" DistrictSysNo=" + disctrictSysNo + " AND Status=" + (int)AppEnum.BiStatus.Valid);
            Dictionary<int, AreaEntity> zoneDic = new Dictionary<int, AreaEntity>();
            foreach (DataRow dr in zoneRows)
            {
                AreaEntity item = new AreaEntity();
                Map(item, dr);
                zoneDic.Add(item.SysNo, item);
            }
            return zoneDic;
        }

        private void Map(AreaEntity oParam, DataRow tempdr)
        {
            oParam.SysNo = Util.TrimIntNull(tempdr["SysNo"]);
            oParam.AreaID = Util.TrimNull(tempdr["AreaID"]);
            oParam.ProvinceSysNo = Util.TrimIntNull(tempdr["ProvinceSysNo"]);
            oParam.CitySysNo = Util.TrimIntNull(tempdr["CitySysNo"]);
            oParam.ProvinceName = Util.TrimNull(tempdr["ProvinceName"]);
            oParam.CityName = Util.TrimNull(tempdr["CityName"]);
            oParam.DistrictSysNo = Util.TrimIntNull(tempdr["DistrictSysNo"]);
            oParam.DistrictName = Util.TrimNull(tempdr["DistrictName"]);
            oParam.ZoneName = Util.TrimNull(tempdr["ZoneName"]);
            oParam.SortNo = Util.TrimIntNull(tempdr["SortNo"]);
            oParam.Status = Util.TrimIntNull(tempdr["Status"]);
            oParam.IsMaster = Util.TrimIntNull(tempdr["IsMaster"]);
            oParam.LastUpdateUser = Util.TrimIntNull(tempdr["LastUpdateUser"]);
            oParam.LastUpdateTime = Util.TrimDateNull(tempdr["LastUpdateTime"]);
            oParam.POSAreaCode = Util.TrimNull(tempdr["POSAreaCode"]);
            oParam.IsOnlineShow = Util.TrimIntNull(tempdr["IsOnlineShow"]);
            oParam.Area_360_SysNo = Util.TrimIntNull(tempdr["Area_360_SysNo"]);
            oParam.Area_360_CityName = Util.TrimNull(tempdr["Area_360_CityName"]);
            oParam.Area_360_ZoneName = Util.TrimNull(tempdr["Area_360_ZoneName"]);
            oParam.Area_RWY_SysNo = Util.TrimIntNull(tempdr["Area_RWY_SysNo"]);
            oParam.AreaLevel = Util.TrimIntNull(tempdr["AreaLevel"]);
        }
        #endregion  成员方法
    }

}