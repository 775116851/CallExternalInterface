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
    /// 数据访问类TICKET_RWY。
    /// </summary>
    public class TICKET_RWYDac
    {
        public TICKET_RWYDac() { }
        private static TICKET_RWYDac _instance;
        public TICKET_RWYDac GetInstance()
        {
            if (_instance == null)
            { _instance = new TICKET_RWYDac(); }
            return _instance;
        }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TICKET_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.TICKET_RWY(");
            strSql.Append("TicketId,Name,ScenicId,Status,Description,EndOfTime,Notice,OrderAdvanceHours,OrderAdvanceDays,OrderBeforeHour,OrderBeforeMin,MaxOrderAdvanceDays,RefundAdvanceHours,UseAdvanceHours,AdditionalInfo,EffectiveDate,ValidWeeks,ValidDates,InvalidDates,IsInvtLimit,MaxOrderNum,MinOrderNum,ImgUrl,SalePrice,SuggestPrice,MarketPrice)");
            strSql.Append(" values (");
            strSql.Append("@TicketId,@Name,@ScenicId,@Status,@Description,@EndOfTime,@Notice,@OrderAdvanceHours,@OrderAdvanceDays,@OrderBeforeHour,@OrderBeforeMin,@MaxOrderAdvanceDays,@RefundAdvanceHours,@UseAdvanceHours,@AdditionalInfo,@EffectiveDate,@ValidWeeks,@ValidDates,@InvalidDates,@IsInvtLimit,@MaxOrderNum,@MinOrderNum,@ImgUrl,@SalePrice,@SuggestPrice,@MarketPrice)");
            strSql.Append(";select @@IDENTITY");
            SqlCommand cmd = new SqlCommand(strSql.ToString());
            SqlParameter[] parameters = {
                 new SqlParameter("@TicketId",SqlDbType.NVarChar,64),
                 new SqlParameter("@Name",SqlDbType.NVarChar,64),
                 new SqlParameter("@ScenicId",SqlDbType.NVarChar,64),
                 new SqlParameter("@Status",SqlDbType.NVarChar,64),
                 new SqlParameter("@Description",SqlDbType.NText,2147483646),
                 new SqlParameter("@EndOfTime",SqlDbType.NVarChar,64),
                 new SqlParameter("@Notice",SqlDbType.NVarChar,64),
                 new SqlParameter("@OrderAdvanceHours",SqlDbType.NVarChar,64),
                 new SqlParameter("@OrderAdvanceDays",SqlDbType.NVarChar,64),
                 new SqlParameter("@OrderBeforeHour",SqlDbType.NVarChar,64),
                 new SqlParameter("@OrderBeforeMin",SqlDbType.NVarChar,64),
                 new SqlParameter("@MaxOrderAdvanceDays",SqlDbType.NVarChar,64),
                 new SqlParameter("@RefundAdvanceHours",SqlDbType.NVarChar,64),
                 new SqlParameter("@UseAdvanceHours",SqlDbType.NVarChar,64),
                 new SqlParameter("@AdditionalInfo",SqlDbType.NVarChar,400),
                 new SqlParameter("@EffectiveDate",SqlDbType.NVarChar,64),
                 new SqlParameter("@ValidWeeks",SqlDbType.NVarChar,64),
                 new SqlParameter("@ValidDates",SqlDbType.NVarChar,400),
                 new SqlParameter("@InvalidDates",SqlDbType.NVarChar,400),
                 new SqlParameter("@IsInvtLimit",SqlDbType.NVarChar,64),
                 new SqlParameter("@MaxOrderNum",SqlDbType.NVarChar,64),
                 new SqlParameter("@MinOrderNum",SqlDbType.NVarChar,64),
                 new SqlParameter("@ImgUrl",SqlDbType.NVarChar,200),
                 new SqlParameter("@SalePrice",SqlDbType.NVarChar,64),
                 new SqlParameter("@SuggestPrice",SqlDbType.NVarChar,64),
                 new SqlParameter("@MarketPrice",SqlDbType.NVarChar,64),
             };
            if (model.TicketId != AppConst.StringNull)
                parameters[0].Value = model.TicketId;
            else
                parameters[0].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[0]);
            if (model.Name != AppConst.StringNull)
                parameters[1].Value = model.Name;
            else
                parameters[1].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[1]);
            if (model.ScenicId != AppConst.StringNull)
                parameters[2].Value = model.ScenicId;
            else
                parameters[2].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[2]);
            if (model.Status != AppConst.StringNull)
                parameters[3].Value = model.Status;
            else
                parameters[3].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[3]);
            if (model.Description != AppConst.StringNull)
                parameters[4].Value = model.Description;
            else
                parameters[4].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[4]);
            if (model.EndOfTime != AppConst.StringNull)
                parameters[5].Value = model.EndOfTime;
            else
                parameters[5].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[5]);
            if (model.Notice != AppConst.StringNull)
                parameters[6].Value = model.Notice;
            else
                parameters[6].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[6]);
            if (model.OrderAdvanceHours != AppConst.StringNull)
                parameters[7].Value = model.OrderAdvanceHours;
            else
                parameters[7].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[7]);
            if (model.OrderAdvanceDays != AppConst.StringNull)
                parameters[8].Value = model.OrderAdvanceDays;
            else
                parameters[8].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[8]);
            if (model.OrderBeforeHour != AppConst.StringNull)
                parameters[9].Value = model.OrderBeforeHour;
            else
                parameters[9].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[9]);
            if (model.OrderBeforeMin != AppConst.StringNull)
                parameters[10].Value = model.OrderBeforeMin;
            else
                parameters[10].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[10]);
            if (model.MaxOrderAdvanceDays != AppConst.StringNull)
                parameters[11].Value = model.MaxOrderAdvanceDays;
            else
                parameters[11].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[11]);
            if (model.RefundAdvanceHours != AppConst.StringNull)
                parameters[12].Value = model.RefundAdvanceHours;
            else
                parameters[12].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[12]);
            if (model.UseAdvanceHours != AppConst.StringNull)
                parameters[13].Value = model.UseAdvanceHours;
            else
                parameters[13].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[13]);
            if (model.AdditionalInfo != AppConst.StringNull)
                parameters[14].Value = model.AdditionalInfo;
            else
                parameters[14].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[14]);
            if (model.EffectiveDate != AppConst.StringNull)
                parameters[15].Value = model.EffectiveDate;
            else
                parameters[15].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[15]);
            if (model.ValidWeeks != AppConst.StringNull)
                parameters[16].Value = model.ValidWeeks;
            else
                parameters[16].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[16]);
            if (model.ValidDates != AppConst.StringNull)
                parameters[17].Value = model.ValidDates;
            else
                parameters[17].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[17]);
            if (model.InvalidDates != AppConst.StringNull)
                parameters[18].Value = model.InvalidDates;
            else
                parameters[18].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[18]);
            if (model.IsInvtLimit != AppConst.StringNull)
                parameters[19].Value = model.IsInvtLimit;
            else
                parameters[19].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[19]);
            if (model.MaxOrderNum != AppConst.StringNull)
                parameters[20].Value = model.MaxOrderNum;
            else
                parameters[20].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[20]);
            if (model.MinOrderNum != AppConst.StringNull)
                parameters[21].Value = model.MinOrderNum;
            else
                parameters[21].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[21]);
            if (model.ImgUrl != AppConst.StringNull)
                parameters[22].Value = model.ImgUrl;
            else
                parameters[22].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[22]);
            if (model.SalePrice != AppConst.StringNull)
                parameters[23].Value = model.SalePrice;
            else
                parameters[23].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[23]);
            if (model.SuggestPrice != AppConst.StringNull)
                parameters[24].Value = model.SuggestPrice;
            else
                parameters[24].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[24]);
            if (model.MarketPrice != AppConst.StringNull)
                parameters[25].Value = model.MarketPrice;
            else
                parameters[25].Value = System.DBNull.Value;
            cmd.Parameters.Add(parameters[25]);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(AppConfig.Conn_IPP, cmd));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TICKET_RWYEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.TICKET_RWY set ");
            SqlCommand cmd = new SqlCommand();
            if (model.SysNo != AppConst.IntNull)
            {
                SqlParameter param = new SqlParameter("@SysNo", SqlDbType.Int, 4);
                param.Value = model.SysNo;
                cmd.Parameters.Add(param);
            }
            if (model.TicketId != AppConst.StringNull)
            {
                strSql.Append("TicketId=@TicketId,");
                SqlParameter param = new SqlParameter("@TicketId", SqlDbType.NVarChar, 64);
                param.Value = model.TicketId;
                cmd.Parameters.Add(param);
            }
            if (model.Name != AppConst.StringNull)
            {
                strSql.Append("Name=@Name,");
                SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 64);
                param.Value = model.Name;
                cmd.Parameters.Add(param);
            }
            if (model.ScenicId != AppConst.StringNull)
            {
                strSql.Append("ScenicId=@ScenicId,");
                SqlParameter param = new SqlParameter("@ScenicId", SqlDbType.NVarChar, 64);
                param.Value = model.ScenicId;
                cmd.Parameters.Add(param);
            }
            if (model.Status != AppConst.StringNull)
            {
                strSql.Append("Status=@Status,");
                SqlParameter param = new SqlParameter("@Status", SqlDbType.NVarChar, 64);
                param.Value = model.Status;
                cmd.Parameters.Add(param);
            }
            if (model.Description != AppConst.StringNull)
            {
                strSql.Append("Description=@Description,");
                SqlParameter param = new SqlParameter("@Description", SqlDbType.NText, 2147483646);
                param.Value = model.Description;
                cmd.Parameters.Add(param);
            }
            if (model.EndOfTime != AppConst.StringNull)
            {
                strSql.Append("EndOfTime=@EndOfTime,");
                SqlParameter param = new SqlParameter("@EndOfTime", SqlDbType.NVarChar, 64);
                param.Value = model.EndOfTime;
                cmd.Parameters.Add(param);
            }
            if (model.Notice != AppConst.StringNull)
            {
                strSql.Append("Notice=@Notice,");
                SqlParameter param = new SqlParameter("@Notice", SqlDbType.NVarChar, 64);
                param.Value = model.Notice;
                cmd.Parameters.Add(param);
            }
            if (model.OrderAdvanceHours != AppConst.StringNull)
            {
                strSql.Append("OrderAdvanceHours=@OrderAdvanceHours,");
                SqlParameter param = new SqlParameter("@OrderAdvanceHours", SqlDbType.NVarChar, 64);
                param.Value = model.OrderAdvanceHours;
                cmd.Parameters.Add(param);
            }
            if (model.OrderAdvanceDays != AppConst.StringNull)
            {
                strSql.Append("OrderAdvanceDays=@OrderAdvanceDays,");
                SqlParameter param = new SqlParameter("@OrderAdvanceDays", SqlDbType.NVarChar, 64);
                param.Value = model.OrderAdvanceDays;
                cmd.Parameters.Add(param);
            }
            if (model.OrderBeforeHour != AppConst.StringNull)
            {
                strSql.Append("OrderBeforeHour=@OrderBeforeHour,");
                SqlParameter param = new SqlParameter("@OrderBeforeHour", SqlDbType.NVarChar, 64);
                param.Value = model.OrderBeforeHour;
                cmd.Parameters.Add(param);
            }
            if (model.OrderBeforeMin != AppConst.StringNull)
            {
                strSql.Append("OrderBeforeMin=@OrderBeforeMin,");
                SqlParameter param = new SqlParameter("@OrderBeforeMin", SqlDbType.NVarChar, 64);
                param.Value = model.OrderBeforeMin;
                cmd.Parameters.Add(param);
            }
            if (model.MaxOrderAdvanceDays != AppConst.StringNull)
            {
                strSql.Append("MaxOrderAdvanceDays=@MaxOrderAdvanceDays,");
                SqlParameter param = new SqlParameter("@MaxOrderAdvanceDays", SqlDbType.NVarChar, 64);
                param.Value = model.MaxOrderAdvanceDays;
                cmd.Parameters.Add(param);
            }
            if (model.RefundAdvanceHours != AppConst.StringNull)
            {
                strSql.Append("RefundAdvanceHours=@RefundAdvanceHours,");
                SqlParameter param = new SqlParameter("@RefundAdvanceHours", SqlDbType.NVarChar, 64);
                param.Value = model.RefundAdvanceHours;
                cmd.Parameters.Add(param);
            }
            if (model.UseAdvanceHours != AppConst.StringNull)
            {
                strSql.Append("UseAdvanceHours=@UseAdvanceHours,");
                SqlParameter param = new SqlParameter("@UseAdvanceHours", SqlDbType.NVarChar, 64);
                param.Value = model.UseAdvanceHours;
                cmd.Parameters.Add(param);
            }
            if (model.AdditionalInfo != AppConst.StringNull)
            {
                strSql.Append("AdditionalInfo=@AdditionalInfo,");
                SqlParameter param = new SqlParameter("@AdditionalInfo", SqlDbType.NVarChar, 400);
                param.Value = model.AdditionalInfo;
                cmd.Parameters.Add(param);
            }
            if (model.EffectiveDate != AppConst.StringNull)
            {
                strSql.Append("EffectiveDate=@EffectiveDate,");
                SqlParameter param = new SqlParameter("@EffectiveDate", SqlDbType.NVarChar, 64);
                param.Value = model.EffectiveDate;
                cmd.Parameters.Add(param);
            }
            if (model.ValidWeeks != AppConst.StringNull)
            {
                strSql.Append("ValidWeeks=@ValidWeeks,");
                SqlParameter param = new SqlParameter("@ValidWeeks", SqlDbType.NVarChar, 64);
                param.Value = model.ValidWeeks;
                cmd.Parameters.Add(param);
            }
            if (model.ValidDates != AppConst.StringNull)
            {
                strSql.Append("ValidDates=@ValidDates,");
                SqlParameter param = new SqlParameter("@ValidDates", SqlDbType.NVarChar, 400);
                param.Value = model.ValidDates;
                cmd.Parameters.Add(param);
            }
            if (model.InvalidDates != AppConst.StringNull)
            {
                strSql.Append("InvalidDates=@InvalidDates,");
                SqlParameter param = new SqlParameter("@InvalidDates", SqlDbType.NVarChar, 400);
                param.Value = model.InvalidDates;
                cmd.Parameters.Add(param);
            }
            if (model.IsInvtLimit != AppConst.StringNull)
            {
                strSql.Append("IsInvtLimit=@IsInvtLimit,");
                SqlParameter param = new SqlParameter("@IsInvtLimit", SqlDbType.NVarChar, 64);
                param.Value = model.IsInvtLimit;
                cmd.Parameters.Add(param);
            }
            if (model.MaxOrderNum != AppConst.StringNull)
            {
                strSql.Append("MaxOrderNum=@MaxOrderNum,");
                SqlParameter param = new SqlParameter("@MaxOrderNum", SqlDbType.NVarChar, 64);
                param.Value = model.MaxOrderNum;
                cmd.Parameters.Add(param);
            }
            if (model.MinOrderNum != AppConst.StringNull)
            {
                strSql.Append("MinOrderNum=@MinOrderNum,");
                SqlParameter param = new SqlParameter("@MinOrderNum", SqlDbType.NVarChar, 64);
                param.Value = model.MinOrderNum;
                cmd.Parameters.Add(param);
            }
            if (model.ImgUrl != AppConst.StringNull)
            {
                strSql.Append("ImgUrl=@ImgUrl,");
                SqlParameter param = new SqlParameter("@ImgUrl", SqlDbType.NVarChar, 200);
                param.Value = model.ImgUrl;
                cmd.Parameters.Add(param);
            }
            if (model.SalePrice != AppConst.StringNull)
            {
                strSql.Append("SalePrice=@SalePrice,");
                SqlParameter param = new SqlParameter("@SalePrice", SqlDbType.NVarChar, 64);
                param.Value = model.SalePrice;
                cmd.Parameters.Add(param);
            }
            if (model.SuggestPrice != AppConst.StringNull)
            {
                strSql.Append("SuggestPrice=@SuggestPrice,");
                SqlParameter param = new SqlParameter("@SuggestPrice", SqlDbType.NVarChar, 64);
                param.Value = model.SuggestPrice;
                cmd.Parameters.Add(param);
            }
            if (model.MarketPrice != AppConst.StringNull)
            {
                strSql.Append("MarketPrice=@MarketPrice,");
                SqlParameter param = new SqlParameter("@MarketPrice", SqlDbType.NVarChar, 64);
                param.Value = model.MarketPrice;
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
        private TICKET_RWYEntity SetDsToEntity(DataSet ds, TICKET_RWYEntity model)
        {
            if (ds.Tables[0].Rows[0]["SysNo"].ToString() != "")
            {
                model.SysNo = int.Parse(ds.Tables[0].Rows[0]["SysNo"].ToString());
            }
            model.TicketId = ds.Tables[0].Rows[0]["TicketId"].ToString();
            model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
            model.ScenicId = ds.Tables[0].Rows[0]["ScenicId"].ToString();
            model.Status = ds.Tables[0].Rows[0]["Status"].ToString();
            model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
            model.EndOfTime = ds.Tables[0].Rows[0]["EndOfTime"].ToString();
            model.Notice = ds.Tables[0].Rows[0]["Notice"].ToString();
            model.OrderAdvanceHours = ds.Tables[0].Rows[0]["OrderAdvanceHours"].ToString();
            model.OrderAdvanceDays = ds.Tables[0].Rows[0]["OrderAdvanceDays"].ToString();
            model.OrderBeforeHour = ds.Tables[0].Rows[0]["OrderBeforeHour"].ToString();
            model.OrderBeforeMin = ds.Tables[0].Rows[0]["OrderBeforeMin"].ToString();
            model.MaxOrderAdvanceDays = ds.Tables[0].Rows[0]["MaxOrderAdvanceDays"].ToString();
            model.RefundAdvanceHours = ds.Tables[0].Rows[0]["RefundAdvanceHours"].ToString();
            model.UseAdvanceHours = ds.Tables[0].Rows[0]["UseAdvanceHours"].ToString();
            model.AdditionalInfo = ds.Tables[0].Rows[0]["AdditionalInfo"].ToString();
            model.EffectiveDate = ds.Tables[0].Rows[0]["EffectiveDate"].ToString();
            model.ValidWeeks = ds.Tables[0].Rows[0]["ValidWeeks"].ToString();
            model.ValidDates = ds.Tables[0].Rows[0]["ValidDates"].ToString();
            model.InvalidDates = ds.Tables[0].Rows[0]["InvalidDates"].ToString();
            model.IsInvtLimit = ds.Tables[0].Rows[0]["IsInvtLimit"].ToString();
            model.MaxOrderNum = ds.Tables[0].Rows[0]["MaxOrderNum"].ToString();
            model.MinOrderNum = ds.Tables[0].Rows[0]["MinOrderNum"].ToString();
            model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
            model.SalePrice = ds.Tables[0].Rows[0]["SalePrice"].ToString();
            model.SuggestPrice = ds.Tables[0].Rows[0]["SuggestPrice"].ToString();
            model.MarketPrice = ds.Tables[0].Rows[0]["MarketPrice"].ToString();
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TICKET_RWYEntity GetModel(int SysNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  dbo.TICKET_RWY");
            strSql.Append(" where SysNo=@SysNo ");
            SqlParameter[] parameters = { 
		new SqlParameter("@SysNo", SqlDbType.Int,4 )
 		};
            parameters[0].Value = SysNo;
            TICKET_RWYEntity model = new TICKET_RWYEntity();
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

        public TICKET_RWYEntity GetModelByRWYTicketID(string RWYTicketID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.TICKET_RWY ");
            strSql.Append(" WHERE TicketId = @TicketId ");
            SqlParameter[] parameters = { 
		        new SqlParameter("@TicketId",SqlDbType.NVarChar,64 )
 		    };
            parameters[0].Value = RWYTicketID;
            TICKET_RWYEntity model = new TICKET_RWYEntity();
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
