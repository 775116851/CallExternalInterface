<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Area.ascx.cs" Inherits="AreaUI.UI.Area" %>
<script src="<%=ResolveUrl("../Scripts/share.js")%>" type="text/javascript"></script>
<script type="text/javascript">

    function AreaLevelChange<%=ddlAreaLevel.ClientID %>(areaLevelSysNo) {
        $("#<%=hidAreaLevelSysNo.ClientID %>").val(areaLevelSysNo);
        if (areaLevelSysNo != '-9999') {
            ClearCity<%=ddlCity.ClientID %>();
            ClearDistrict<%=ddlDistrict.ClientID %>();
            ClearZone<%=ddlZone.ClientID %>();
            $("#<%=ddlProvince.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidAreaSysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidProvinceSysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidCitySysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidDistrictSysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidZoneSysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
        }
    }

    function ProvinceChange<%=ddlProvince.ClientID %>(provinceSysNo) {
        ClearCity<%=ddlCity.ClientID %>();
        ClearDistrict<%=ddlDistrict.ClientID %>();
        ClearZone<%=ddlZone.ClientID %>();
        $("#<%=hidAreaSysNo.ClientID%>").val(provinceSysNo);
        $("#<%=hidProvinceSysNo.ClientID%>").val(provinceSysNo);
        if (provinceSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            AjaxWebService("GetCityList", "{provinceSysNo:'" + provinceSysNo + "'}", ProvinceChange_Callback<%=ddlProvince.ClientID %>);
        }
        if ("<%=onProvinceChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onProvinceChange%>()");
        }
    }

    function ProvinceChange_Callback<%=ddlProvince.ClientID %>(result) {
        if ($("#<%=hidAreaLevelSysNo.ClientID %>").val() <= 1 && $("#<%=hidAreaLevelSysNo.ClientID %>").val() != '-9999') {
            return false;
        }
        if ("<%=Enable%>" != "False" && "<%=DistrictEnable%>" != "False") {
            $("#<%=ddlCity.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlCity.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
            if ($("#<%=hidCitySysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                if ($("#<%=hidCitySysNo.ClientID%>").val() == result[i][0]) {
                    $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=hidCitySysNo.ClientID%>").val());
                    CityChange<%=ddlCity.ClientID %>($("#<%=hidCitySysNo.ClientID%>").val())
                }
            }
        }
        if ($("#<%=hidCitySysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlCity.ClientID%>").val($("#<%=hidCitySysNo.ClientID%>").val());
        }
    }

    function CityChange<%=ddlCity.ClientID %>(citySysNo) {
        ClearDistrict<%=ddlDistrict.ClientID %>();
        ClearZone<%=ddlZone.ClientID %>();
        $("#<%=hidCitySysNo.ClientID%>").val(citySysNo);
        if (citySysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidAreaSysNo.ClientID%>").val(citySysNo);
        }
        else {
            $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=ddlProvince.ClientID%>").val());
        }
        if ("<%=IsShowDistrict%>" == "True") {
            if (citySysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                AjaxWebService("GetDistrictList", "{citySysNo:'" + citySysNo + "'}", CityChange_Callback<%=ddlCity.ClientID %>);
            }
        }
        if ("<%=onCityChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onCityChange%>()");
        }
    }

    function CityChange_Callback<%=ddlCity.ClientID %>(result) {
        if ($("#<%=hidAreaLevelSysNo.ClientID %>").val() <= 2 && $("#<%=hidAreaLevelSysNo.ClientID %>").val() != '-9999') {
            return false;
        }
        if ("<%=Enable%>" != "False" && "<%=DistrictEnable%>" != "False") {
            $("#<%=ddlDistrict.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlDistrict.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
            if ($("#<%=hidDistrictSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                if ($("#<%=hidDistrictSysNo.ClientID%>").val() == result[i][0]) {
                    $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=hidDistrictSysNo.ClientID%>").val());
                    DistrictChange<%=ddlDistrict.ClientID %>($("#<%=hidDistrictSysNo.ClientID%>").val());
                }
            }
        }
        if ($("#<%=hidDistrictSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlDistrict.ClientID%>").val($("#<%=hidDistrictSysNo.ClientID%>").val());
        }
    }

    function DistrictChange<%=ddlDistrict.ClientID %>(districtSysNo) {
        ClearZone<%=ddlZone.ClientID %>();
        $("#<%=hidDistrictSysNo.ClientID%>").val(districtSysNo);
        if (districtSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidAreaSysNo.ClientID%>").val(districtSysNo);
        }
        else {
            $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=ddlCity.ClientID%>").val());
        }
        if ("<%=IsShowZone%>" == "True") {
            if (districtSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                AjaxWebService("GetZoneList", "{districtSysNo:'" + districtSysNo + "'}", DistrictChange_Callback<%=ddlDistrict.ClientID %>);
            }
        }
        if ("<%=onDistrictChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onDistrictChange%>()");
        }
    }

    function DistrictChange_Callback<%=ddlDistrict.ClientID %>(result) {
        if ($("#<%=hidAreaLevelSysNo.ClientID %>").val() <= 3 && $("#<%=hidAreaLevelSysNo.ClientID %>").val() != '-9999') {
            return false;
        }
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlZone.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlZone.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
            if ($("#<%=hidZoneSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                if ($("#<%=hidZoneSysNo.ClientID%>").val() == result[i][0]) {
                    $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=hidZoneSysNo.ClientID%>").val());
                }
            }
        }
        if ($("#<%=hidZoneSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlZone.ClientID%>").val($("#<%=hidZoneSysNo.ClientID%>").val());
        }
    }

    function ZoneChange<%=ddlZone.ClientID %>(zoneSysNo) {
        $("#<%=hidZoneSysNo.ClientID%>").val(zoneSysNo);
        if (zoneSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidAreaSysNo.ClientID%>").val(zoneSysNo);
        }
        else {
            $("#<%=hidAreaSysNo.ClientID%>").val($("#<%=ddlDistrict.ClientID%>").val());
        }
        if ("<%=onZoneChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onZoneChange%>()");
        }
    }

    function ClearCity<%=ddlCity.ClientID %>() {
        if ("<%=Enable%>" != "False" && "<%=DistrictEnable%>" != "False") {
            $("#<%=ddlCity.ClientID%>").attr("disabled", true);
        }
        $("#<%=ddlCity.ClientID%>").empty();
        $("#<%=ddlCity.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    function ClearDistrict<%=ddlDistrict.ClientID %>() {
        if ("<%=Enable%>" != "False" && "<%=DistrictEnable%>" != "False") {
            $("#<%=ddlDistrict.ClientID%>").attr("disabled", true);
        }
        $("#<%=ddlDistrict.ClientID%>").empty();
        $("#<%=ddlDistrict.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    function ClearZone<%=ddlZone.ClientID %>() {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlZone.ClientID%>").attr("disabled", true);
        }
        $("#<%=ddlZone.ClientID%>").empty();
        $("#<%=ddlZone.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    $(document).ready(function () {
        if ($("#<%=hidProvinceSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            ProvinceChange<%=ddlProvince.ClientID %>($("#<%=hidProvinceSysNo.ClientID%>").val());
        }
        if ($("#<%=hidCitySysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            CityChange<%=ddlCity.ClientID %>($("#<%=hidCitySysNo.ClientID%>").val());
        }
        if ($("#<%=hidDistrictSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            DistrictChange<%=ddlDistrict.ClientID %>($("#<%=hidDistrictSysNo.ClientID%>").val());
        }
    })
</script>

<div style='position: absolute; display: none; left: 0px; top: 0px; background-color: #FFF1A8; width: 150px; font-weight: bold; font-size: 12px; padding: 5px;'
    id='LoadingPanel'>
</div>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td style="text-align:left; border:none; padding-left:0;">
            <asp:DropDownList ID="ddlAreaLevel" runat="server" AutoPostBack="false" Width="70px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="false" Width="130px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="false" Width="130px" Enabled="false">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="false" Width="130px" Enabled="false">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="false" Enabled="false" Width="130px">
            </asp:DropDownList>
            <asp:HiddenField ID="hidAreaLevelSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidProvinceSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidCitySysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidDistrictSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidZoneSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidAreaSysNo" runat="server" />
        </td>
    </tr>
</table>
