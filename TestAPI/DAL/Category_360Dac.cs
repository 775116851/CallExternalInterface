using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestAPI.Model;
using allinpay.O2O.Cmn;
using TestAPI.Common;

namespace TestAPI.DAL
{
    /// <summary>
    /// 数据访问类Category_360。
    /// </summary>
    public class Category_360Dac
    {
        public Category_360Dac() { }
        private static Category_360Dac _instance;
        public Category_360Dac GetInstance()
        {
            if (_instance == null)
            { _instance = new Category_360Dac(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Category_360Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.Category_360(");
            strSql.Append("Cateid,C1SysNo,C2SysNo,C1Name,C2Name,C3Name,Alias,APIName,APINameEnd,Isred,Isnew,Minihot,Minired,Status,LastUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@Cateid,@C1SysNo,@C2SysNo,@C1Name,@C2Name,@C3Name,@Alias,@APIName,@APINameEnd,@Isred,@Isnew,@Minihot,@Minired,@Status,@LastUpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@Cateid",SqlDbType.Int,4),
                 new SqlParameter("@C1SysNo",SqlDbType.Int,4),
                 new SqlParameter("@C2SysNo",SqlDbType.Int,4),
                 new SqlParameter("@C1Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@C2Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@C3Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@Alias",SqlDbType.NVarChar,20),
                 new SqlParameter("@APIName",SqlDbType.NVarChar,20),
                 new SqlParameter("@APINameEnd",SqlDbType.NVarChar,20),
                 new SqlParameter("@Isred",SqlDbType.SmallInt,2),
                 new SqlParameter("@Isnew",SqlDbType.SmallInt,2),
                 new SqlParameter("@Minihot",SqlDbType.SmallInt,2),
                 new SqlParameter("@Minired",SqlDbType.SmallInt,2),
                 new SqlParameter("@Status",SqlDbType.SmallInt,2),
                 new SqlParameter("@LastUpdateTime",SqlDbType.DateTime),
             };
            if (model.Cateid != AppConst.IntNull)
                parameters[0].Value = model.Cateid;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.C1SysNo != AppConst.IntNull)
                parameters[1].Value = model.C1SysNo;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.C2SysNo != AppConst.IntNull)
                parameters[2].Value = model.C2SysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.C1Name != AppConst.StringNull)
                parameters[3].Value = model.C1Name;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.C2Name != AppConst.StringNull)
                parameters[4].Value = model.C2Name;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.C3Name != AppConst.StringNull)
                parameters[5].Value = model.C3Name;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Alias != AppConst.StringNull)
                parameters[6].Value = model.Alias;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.APIName != AppConst.StringNull)
                parameters[7].Value = model.APIName;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.APINameEnd != AppConst.StringNull)
                parameters[8].Value = model.APINameEnd;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.Isred != AppConst.IntNull)
                parameters[9].Value = model.Isred;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.Isnew != AppConst.IntNull)
                parameters[10].Value = model.Isnew;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.Minihot != AppConst.IntNull)
                parameters[11].Value = model.Minihot;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Minired != AppConst.IntNull)
                parameters[12].Value = model.Minired;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.Status != AppConst.IntNull)
                parameters[13].Value = model.Status;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.LastUpdateTime != AppConst.DateTimeNull)
                parameters[14].Value = model.LastUpdateTime;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(AppConfig.Conn_O2O2, cmd));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Category_360Entity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.Category_360 set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Cateid != AppConst.IntNull)
            {
                strSql.Append("Cateid=@Cateid,");
                SqlParameter param = new SqlParameter("@Cateid", SqlDbType.Int, 4);
                param.Value = model.Cateid;
                cmd.Parameters.Add(param);
            }
            if (model.C1SysNo != AppConst.IntNull)
            {
                strSql.Append("C1SysNo=@C1SysNo,");
                SqlParameter param = new SqlParameter("@C1SysNo", SqlDbType.Int, 4);
                param.Value = model.C1SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.C2SysNo != AppConst.IntNull)
            {
                strSql.Append("C2SysNo=@C2SysNo,");
                SqlParameter param = new SqlParameter("@C2SysNo", SqlDbType.Int, 4);
                param.Value = model.C2SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.C1Name != AppConst.StringNull)
            {
                strSql.Append("C1Name=@C1Name,");
                SqlParameter param = new SqlParameter("@C1Name", SqlDbType.NVarChar, 20);
                param.Value = model.C1Name;
                cmd.Parameters.Add(param);
            }
            if (model.C2Name != AppConst.StringNull)
            {
                strSql.Append("C2Name=@C2Name,");
                SqlParameter param = new SqlParameter("@C2Name", SqlDbType.NVarChar, 20);
                param.Value = model.C2Name;
                cmd.Parameters.Add(param);
            }
            if (model.C3Name != AppConst.StringNull)
            {
                strSql.Append("C3Name=@C3Name,");
                SqlParameter param = new SqlParameter("@C3Name", SqlDbType.NVarChar, 20);
                param.Value = model.C3Name;
                cmd.Parameters.Add(param);
            }
            if (model.Alias != AppConst.StringNull)
            {
                strSql.Append("Alias=@Alias,");
                SqlParameter param = new SqlParameter("@Alias", SqlDbType.NVarChar, 20);
                param.Value = model.Alias;
                cmd.Parameters.Add(param);
            }
            if (model.APIName != AppConst.StringNull)
            {
                strSql.Append("APIName=@APIName,");
                SqlParameter param = new SqlParameter("@APIName", SqlDbType.NVarChar, 20);
                param.Value = model.APIName;
                cmd.Parameters.Add(param);
            }
            if (model.APINameEnd != AppConst.StringNull)
            {
                strSql.Append("APINameEnd=@APINameEnd,");
                SqlParameter param = new SqlParameter("@APINameEnd", SqlDbType.NVarChar, 20);
                param.Value = model.APINameEnd;
                cmd.Parameters.Add(param);
            }
            if (model.Isred != AppConst.IntNull)
            {
                strSql.Append("Isred=@Isred,");
                SqlParameter param = new SqlParameter("@Isred", SqlDbType.SmallInt, 2);
                param.Value = model.Isred;
                cmd.Parameters.Add(param);
            }
            if (model.Isnew != AppConst.IntNull)
            {
                strSql.Append("Isnew=@Isnew,");
                SqlParameter param = new SqlParameter("@Isnew", SqlDbType.SmallInt, 2);
                param.Value = model.Isnew;
                cmd.Parameters.Add(param);
            }
            if (model.Minihot != AppConst.IntNull)
            {
                strSql.Append("Minihot=@Minihot,");
                SqlParameter param = new SqlParameter("@Minihot", SqlDbType.SmallInt, 2);
                param.Value = model.Minihot;
                cmd.Parameters.Add(param);
            }
            if (model.Minired != AppConst.IntNull)
            {
                strSql.Append("Minired=@Minired,");
                SqlParameter param = new SqlParameter("@Minired", SqlDbType.SmallInt, 2);
                param.Value = model.Minired;
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
        private Category_360Entity SetDsToEntity(DataSet ds, Category_360Entity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Cateid"].ToString() != "")
            {
                model.Cateid = int.Parse(ds.Tables[0].Rows[0]["Cateid"].ToString());
            }
            if (ds.Tables[0].Rows[0]["C1SysNo"].ToString() != "")
            {
                model.C1SysNo = int.Parse(ds.Tables[0].Rows[0]["C1SysNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["C2SysNo"].ToString() != "")
            {
                model.C2SysNo = int.Parse(ds.Tables[0].Rows[0]["C2SysNo"].ToString());
            }
            model.C1Name = ds.Tables[0].Rows[0]["C1Name"].ToString();
            model.C2Name = ds.Tables[0].Rows[0]["C2Name"].ToString();
            model.C3Name = ds.Tables[0].Rows[0]["C3Name"].ToString();
            model.Alias = ds.Tables[0].Rows[0]["Alias"].ToString();
            model.APIName = ds.Tables[0].Rows[0]["APIName"].ToString();
            model.APINameEnd = ds.Tables[0].Rows[0]["APINameEnd"].ToString();
            if (ds.Tables[0].Rows[0]["Isred"].ToString() != "")
            {
                model.Isred = int.Parse(ds.Tables[0].Rows[0]["Isred"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Isnew"].ToString() != "")
            {
                model.Isnew = int.Parse(ds.Tables[0].Rows[0]["Isnew"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Minihot"].ToString() != "")
            {
                model.Minihot = int.Parse(ds.Tables[0].Rows[0]["Minihot"].ToString());
            }
            if (ds.Tables[0].Rows[0]["Minired"].ToString() != "")
            {
                model.Minired = int.Parse(ds.Tables[0].Rows[0]["Minired"].ToString());
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
        public Category_360Entity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  dbo.Category_360");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            Category_360Entity model = new Category_360Entity();
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
        #endregion  成员方法
    }

}