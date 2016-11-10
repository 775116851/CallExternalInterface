using AreaUI.DAL;
using AreaUI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AreaUI.WebServices
{
    /// <summary>
    /// GeneralSearch 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GeneralSearch : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region 360区域控件
        [WebMethod]
        public ArrayList GetAutoCityList(string cityName)
        {
            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetAutoCityList(cityName);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).CityName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }
        [WebMethod]
        public ArrayList GetADistrictsByCitySysNo(int citySysNo)
        {
            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetADistrictsByCitySysNo(citySysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).DistrictName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }
        [WebMethod]
        public ArrayList GetAZonesByDistrictSysNo(int disctrictSysNo)
        {
            Dictionary<int, Area_360Entity> dic = new Area_360Dac().GetAZonesByDistrictSysNo(disctrictSysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).ZoneName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }
        #endregion

        #region 区域控件
        [WebMethod]
        public ArrayList GetCityList(int provinceSysNo)
        {
            Dictionary<int, AreaEntity> dic = new AreaDac().GetCitiesByProvinceSysNo(provinceSysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).CityName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }

        [WebMethod]
        public ArrayList GetDistrictList(int citySysNo)
        {
            Dictionary<int, AreaEntity> dic = new AreaDac().GetDistrictsByCitySysNo(citySysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).DistrictName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }

        [WebMethod]
        public ArrayList GetZoneList(int districtSysNo)
        {
            Dictionary<int, AreaEntity> dic = new AreaDac().GetZonesByDistrictSysNo(districtSysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).ZoneName.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }
        #endregion

        #region 类别控件
        [WebMethod]
        public ArrayList GetC1List(int categoryType)
        {
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC1List(categoryType);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).C1Name.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }

        [WebMethod]
        public ArrayList GetC2List(int c1SysNo)
        {
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC2ListByC1SysNo(c1SysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).C2Name.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }

        [WebMethod]
        public ArrayList GetC3List(int c2SysNo)
        {
            Dictionary<int, V_CategoryEntity> dic = new V_CategoryDac().GetC3ListByC2SysNo(c2SysNo);
            ArrayList reAL = new ArrayList();
            if (dic != null && dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    string[] itemArr = new string[2];
                    itemArr[0] = dic.Values.ElementAt(i).SysNo.ToString();
                    itemArr[1] = dic.Values.ElementAt(i).C3Name.ToString();
                    reAL.Insert(i, itemArr);
                }
            }
            return reAL;
        }
        #endregion
    }
}
