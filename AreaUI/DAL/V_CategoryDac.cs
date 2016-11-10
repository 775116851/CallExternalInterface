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
    /// 数据访问类V_Category。
    /// </summary>
    public class V_CategoryDac
    {
        public V_CategoryDac() { }
        private static V_CategoryDac _instance;
        public V_CategoryDac GetInstance()
        {
            if (_instance == null)
            { _instance = new V_CategoryDac(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(V_CategoryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.V_Category(");
            strSql.Append("SysNo,CategoryID,C1SysNo,C2SysNo,C1Name,C2Name,C3Name,Status,SortNo,LastUpdateUser,LastUpdateTime,OuterNo,Category_360_SysNo,Category_360_APIName,Category_360_APINameEnd,CategoryType)");
            strSql.Append(" values (");
            strSql.Append("@SysNo,@CategoryID,@C1SysNo,@C2SysNo,@C1Name,@C2Name,@C3Name,@Status,@SortNo,@LastUpdateUser,@LastUpdateTime,@OuterNo,@Category_360_SysNo,@Category_360_APIName,@Category_360_APINameEnd,@CategoryType)");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@SysNo",SqlDbType.Int,4),
                 new SqlParameter("@CategoryID",SqlDbType.VarChar,5),
                 new SqlParameter("@C1SysNo",SqlDbType.Int,4),
                 new SqlParameter("@C2SysNo",SqlDbType.Int,4),
                 new SqlParameter("@C1Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@C2Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@C3Name",SqlDbType.NVarChar,20),
                 new SqlParameter("@Status",SqlDbType.SmallInt,2),
                 new SqlParameter("@SortNo",SqlDbType.Int,4),
                 new SqlParameter("@LastUpdateUser",SqlDbType.Int,4),
                 new SqlParameter("@LastUpdateTime",SqlDbType.DateTime),
                 new SqlParameter("@OuterNo",SqlDbType.VarChar,10),
                 new SqlParameter("@Category_360_SysNo",SqlDbType.Int,4),
                 new SqlParameter("@Category_360_APIName",SqlDbType.NVarChar,20),
                 new SqlParameter("@Category_360_APINameEnd",SqlDbType.NVarChar,20),
                 new SqlParameter("@CategoryType",SqlDbType.SmallInt,2)
             };
            if (model.SysNo != AppConst.IntNull)
                parameters[0].Value = model.SysNo;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.CategoryID != AppConst.StringNull)
                parameters[1].Value = model.CategoryID;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.C1SysNo != AppConst.IntNull)
                parameters[2].Value = model.C1SysNo;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.C2SysNo != AppConst.IntNull)
                parameters[3].Value = model.C2SysNo;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.C1Name != AppConst.StringNull)
                parameters[4].Value = model.C1Name;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.C2Name != AppConst.StringNull)
                parameters[5].Value = model.C2Name;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.C3Name != AppConst.StringNull)
                parameters[6].Value = model.C3Name;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.Status != AppConst.IntNull)
                parameters[7].Value = model.Status;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.SortNo != AppConst.IntNull)
                parameters[8].Value = model.SortNo;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.LastUpdateUser != AppConst.IntNull)
                parameters[9].Value = model.LastUpdateUser;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.LastUpdateTime != AppConst.DateTimeNull)
                parameters[10].Value = model.LastUpdateTime;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.OuterNo != AppConst.StringNull)
                parameters[11].Value = model.OuterNo;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.Category_360_SysNo != AppConst.IntNull)
                parameters[12].Value = model.Category_360_SysNo;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.Category_360_APIName != AppConst.StringNull)
                parameters[13].Value = model.Category_360_APIName;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.Category_360_APINameEnd != AppConst.StringNull)
                parameters[14].Value = model.Category_360_APINameEnd;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.CategoryType != AppConst.IntNull)
                parameters[15].Value = model.CategoryType;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            SqlHelper.ExecuteNonQuery(AppConfig.Conn_O2O2, cmd);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(V_CategoryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.V_Category set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                strSql.Append("SysNo=@SysNo,");
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.CategoryID != AppConst.StringNull)
            {
                strSql.Append("CategoryID=@CategoryID,");
                SqlParameter param = new SqlParameter("@CategoryID", SqlDbType.VarChar, 5);
                param.Value = model.CategoryID;
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
            if (model.Status != AppConst.IntNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.SmallInt, 2);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.SortNo != AppConst.IntNull)
            {
                strSql.Append("SortNo=@SortNo,");
                SqlParameter param = new SqlParameter("@SortNo", SqlDbType.Int, 4);
                param.Value = model.SortNo;
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
            if (model.OuterNo != AppConst.StringNull)
            {
                strSql.Append("OuterNo=@OuterNo,");
                SqlParameter param = new SqlParameter("@OuterNo", SqlDbType.VarChar, 10);
                param.Value = model.OuterNo;
                cmd.Parameters.Add(param);
            }
            if (model.Category_360_SysNo != AppConst.IntNull)
            {
                strSql.Append("Category_360_SysNo=@Category_360_SysNo,");
                SqlParameter param = new SqlParameter("@Category_360_SysNo", SqlDbType.Int, 4);
                param.Value = model.Category_360_SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.Category_360_APIName != AppConst.StringNull)
            {
                strSql.Append("Category_360_APIName=@Category_360_APIName,");
                SqlParameter param = new SqlParameter("@Category_360_APIName", SqlDbType.NVarChar, 20);
                param.Value = model.Category_360_APIName;
                cmd.Parameters.Add(param);
            }
            if (model.Category_360_APINameEnd != AppConst.StringNull)
            {
                strSql.Append("Category_360_APINameEnd=@Category_360_APINameEnd,");
                SqlParameter param = new SqlParameter("@Category_360_APINameEnd", SqlDbType.NVarChar, 20);
                param.Value = model.Category_360_APINameEnd;
                cmd.Parameters.Add(param);
            }
            if (model.CategoryType != AppConst.IntNull)
            {
                strSql.Append("CategoryType=@CategoryType,");
                SqlParameter param = new SqlParameter("@CategoryType", SqlDbType.SmallInt, 2);
                param.Value = model.CategoryType;
                cmd.Parameters.Add(param);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" where SysNo=@SysNo and CategoryID=@CategoryID and C1SysNo=@C1SysNo and C2SysNo=@C2SysNo and C1Name=@C1Name and C2Name=@C2Name and C3Name=@C3Name and Status=@Status and SortNo=@SortNo and LastUpdateUser=@LastUpdateUser and LastUpdateTime=@LastUpdateTime and OuterNo=@OuterNo and Category_360_SysNo=@Category_360_SysNo and Category_360_APIName=@Category_360_APIName and Category_360_APINameEnd=@Category_360_APINameEnd and CategoryType=@CategoryType ");
            cmd.CommandText = strSql.ToString();
            return SqlHelper.ExecuteNonQuery(AppConfig.Conn_O2O2,cmd);
        }
        /// <summary>
        /// 将DataRow赋值到实体
        /// </summary>
        private V_CategoryEntity SetDsToEntity(DataSet ds, V_CategoryEntity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            model.CategoryID = ds.Tables[0].Rows[0]["CategoryID"].ToString();
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
            if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["SortNo"].ToString() != "")
            {
                model.SortNo = int.Parse(ds.Tables[0].Rows[0]["SortNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["LastUpdateUser"].ToString() != "")
            {
                model.LastUpdateUser = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUser"].ToString());
            }
            if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
            {
                model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
            }
            model.OuterNo = ds.Tables[0].Rows[0]["OuterNo"].ToString();
            if (ds.Tables[0].Rows[0]["Category_360_SysNo"].ToString() != "")
            {
                model.Category_360_SysNo = int.Parse(ds.Tables[0].Rows[0]["Category_360_SysNo"].ToString());
            }
            model.Category_360_APIName = ds.Tables[0].Rows[0]["Category_360_APIName"].ToString();
            model.Category_360_APINameEnd = ds.Tables[0].Rows[0]["Category_360_APINameEnd"].ToString();
            if (ds.Tables[0].Rows[0]["CategoryType"].ToString() != "")
            {
                model.CategoryType = int.Parse(ds.Tables[0].Rows[0]["CategoryType"].ToString());
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public V_CategoryEntity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from V_Category ");
            strSql.Append("where SysNo=@SysNo ");
            SqlParameter[] parameters = {
		        new SqlParameter("@SysNo",SqlDbType.Int,4),
             };
            parameters[0].Value = SysNo;
            
            V_CategoryEntity model = new V_CategoryEntity();
            DataSet ds = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
                {
                    model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
                }
                model.CategoryID = ds.Tables[0].Rows[0]["CategoryID"].ToString();
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
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortNo"].ToString() != "")
                {
                    model.SortNo = int.Parse(ds.Tables[0].Rows[0]["SortNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateUser"].ToString() != "")
                {
                    model.LastUpdateUser = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
                {
                    model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
                }
                model.OuterNo = ds.Tables[0].Rows[0]["OuterNo"].ToString();
                if (ds.Tables[0].Rows[0]["Category_360_SysNo"].ToString() != "")
                {
                    model.Category_360_SysNo = int.Parse(ds.Tables[0].Rows[0]["Category_360_SysNo"].ToString());
                }
                model.Category_360_APIName = ds.Tables[0].Rows[0]["Category_360_APIName"].ToString();
                model.Category_360_APINameEnd = ds.Tables[0].Rows[0]["Category_360_APINameEnd"].ToString();
                if (ds.Tables[0].Rows[0]["CategoryType"].ToString() != "")
                {
                    model.CategoryType = int.Parse(ds.Tables[0].Rows[0]["CategoryType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  SysNo, CategoryID, C1SysNo, C2SysNo, C1Name, C2Name, C3Name, Status, SortNo, LastUpdateUser, LastUpdateTime, OuterNo, Category_360_SysNo, Category_360_APIName, Category_360_APINameEnd, CategoryType");
            strSql.Append(" FROM V_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, strSql.ToString());
        }
        #endregion  成员方法

        public Dictionary<int, V_CategoryEntity> GetC1List(int categoryType)
        {
            string sSql = " SELECT * FROM dbo.V_Category WHERE CategoryType = '" + categoryType + "' AND C2Name IS NULL ORDER BY SysNo ";
            DataTable categoryDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sSql).Tables[0];
            DataRow[] c1Rows;
            c1Rows = categoryDT.Select(" C1SysNo IS NULL ");
            Dictionary<int, V_CategoryEntity> c1Dic = new Dictionary<int, V_CategoryEntity>();
            foreach (DataRow dr in c1Rows)
            {
                V_CategoryEntity item = new V_CategoryEntity();
                Map(item, dr);
                c1Dic.Add(item.SysNo, item);
            }
            return c1Dic;
        }

        /// <summary>
        /// luzh 20130206 根据一级大类获取二级大类
        /// </summary>
        /// <param name="c1SysNo"></param>
        /// <returns></returns>
        public Dictionary<int, V_CategoryEntity> GetC2ListByC1SysNo(int c1SysNo)
        {
            string sSql = "SELECT * FROM dbo.V_Category WHERE C1SysNo=" + c1SysNo + " AND C2SysNo IS NULL ORDER BY SysNo ";
            DataTable categoryDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sSql).Tables[0];
            DataRow[] c2Rows;
            c2Rows = categoryDT.Select(" C1SysNo=" + c1SysNo + " AND C2SysNo IS NULL ");
            Dictionary<int, V_CategoryEntity> c2Dic = new Dictionary<int, V_CategoryEntity>();
            foreach (DataRow dr in c2Rows)
            {
                V_CategoryEntity item = new V_CategoryEntity();
                Map(item, dr);
                c2Dic.Add(item.SysNo, item);
            }
            return c2Dic;
        }
        /// <summary>
        /// luzh 20130206 根据二级大类获取三级大类
        /// </summary>
        /// <param name="c2SysNo"></param>
        /// <returns></returns>
        public Dictionary<int, V_CategoryEntity> GetC3ListByC2SysNo(int c2SysNo)
        {
            string sSql = "SELECT * FROM dbo.V_Category WHERE C2SysNo=" + c2SysNo + " ORDER BY SysNo ";
            DataTable categoryDT = SqlHelper.ExecuteDataSet(AppConfig.Conn_O2O2, sSql).Tables[0];
            DataRow[] c3Rows;
            c3Rows = categoryDT.Select(" C2SysNo=" + c2SysNo);
            Dictionary<int, V_CategoryEntity> c3Dic = new Dictionary<int, V_CategoryEntity>();
            foreach (DataRow dr in c3Rows)
            {
                V_CategoryEntity item = new V_CategoryEntity();
                Map(item, dr);
                c3Dic.Add(item.SysNo, item);
            }
            return c3Dic;
        }


        private void Map(V_CategoryEntity oParam, DataRow tempdr)
        {
            oParam.SysNo = Util.TrimIntNull(tempdr["SysNo"]);
            oParam.CategoryID = Util.TrimNull(tempdr["CategoryID"]);
            oParam.C1SysNo = Util.TrimIntNull(tempdr["C1SysNo"]);
            oParam.C2SysNo = Util.TrimIntNull(tempdr["C2SysNo"]);
            oParam.C1Name = Util.TrimNull(tempdr["C1Name"]);
            oParam.C2Name = Util.TrimNull(tempdr["C2Name"]);
            oParam.C3Name = Util.TrimNull(tempdr["C3Name"]);
            oParam.SortNo = Util.TrimIntNull(tempdr["SortNo"]);
            oParam.Status = Util.TrimIntNull(tempdr["Status"]);
            oParam.LastUpdateUser = Util.TrimIntNull(tempdr["LastUpdateUser"]);
            oParam.LastUpdateTime = Util.TrimDateNull(tempdr["LastUpdateTime"]);
            oParam.OuterNo = Util.TrimNull(tempdr["OuterNo"]);
            oParam.Category_360_SysNo = Util.TrimIntNull(tempdr["Category_360_SysNo"]);
            oParam.Category_360_APIName = Util.TrimNull(tempdr["Category_360_APIName"]);
            oParam.Category_360_APINameEnd = Util.TrimNull(tempdr["Category_360_APINameEnd"]);
            oParam.CategoryType = Util.TrimIntNull(tempdr["CategoryType"]);
        }
    }
}