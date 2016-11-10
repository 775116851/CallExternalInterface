<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Area360.ascx.cs" Inherits="AreaUI.UI.Area360" %>
<script src="../Scripts/jquery-1.7.1.min.js"></script>
<script src="../Scripts/share.js"></script>
<script src="../Scripts/jquery.autocomplete.js"></script>
<script type="text/javascript">
    $(function () {
        $('#<%=txtCity.ClientID  %>').autocomplete(<%=hidArray.Value %>,
        {
            minChars: <%=MinChars %>, 
            width: "<%=txtCity.Width %>",
            matchContains: true,
            autoFill: false,
            mustMatch: false,
            matchCase: false,
            caption: "<%=Caption %>",
            scroll: "<%=Scroll %>",
            formatItem: function(row, i, max) {
                return row.value;
            },
            formatMatch: function(row, i, max) {
                return row.value;
            },
            formatResult: function(row) {
                return row.value;
            }
        }).result(function (event, data, formatted) {
            //alert(data.value);
            CityChange<%=txtCity.ClientID %>();
        });;
    });
    function CityChange<%=txtCity.ClientID %>() {
        ClearDistrict<%=ddlADistrict.ClientID %>();
        ClearZone<%=ddlAZone.ClientID %>();
        var cityName = $("#<%=txtCity.ClientID%>").val();
        if(cityName.length==0)
        {
            $('#<%=hidACityCode.ClientID %>').val(<%=allinpay.O2O.Cmn.AppConst.IntNull%>);
            $('#<%=hidADistrictSysNo.ClientID %>').val(<%=allinpay.O2O.Cmn.AppConst.IntNull%>);
            $('#<%=hidAZoneSysNo.ClientID %>').val(<%=allinpay.O2O.Cmn.AppConst.IntNull%>);
            $('#<%=hidAAreaSysNo.ClientID %>').val(<%=allinpay.O2O.Cmn.AppConst.IntNull%>);
            $('#<%=txtCity.ClientID %>').val("");
            return false;
        }
        AjaxWebService("GetAutoCityList", "{cityName:'" + cityName + "'}", CityChange_CallbackA<%=txtCity.ClientID%>);
        if ("<%=onCityChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onCityChange%>()");
        }
    }
    function CityChange_CallbackA<%=txtCity.ClientID%>(result) {
        var fCount = 0;
        fCount = result.length;
        if(fCount <= 0){
            return false;
        }
        var citySysNo = result[0][0];
        $('#<%=hidACityCode.ClientID %>').val(citySysNo);
        $('#<%=hidAAreaSysNo.ClientID %>').val(citySysNo);
        if (citySysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            AjaxWebService("GetADistrictsByCitySysNo", "{citySysNo:'" + citySysNo + "'}", CityChange_Callback<%=txtCity.ClientID%>);
        }
    }
    function CityChange_Callback<%=txtCity.ClientID%>(result) {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlADistrict.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlADistrict.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
            if ($("#<%=hidADistrictSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                if ($("#<%=hidADistrictSysNo.ClientID%>").val() == result[i][0]) {
                    $("#<%=hidAAreaSysNo.ClientID%>").val($("#<%=hidADistrictSysNo.ClientID%>").val());
                    DistrictChange<%=ddlADistrict.ClientID%>($("#<%=hidADistrictSysNo.ClientID%>").val());
                }
            }
        }
        if ($("#<%=hidADistrictSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlADistrict.ClientID%>").val($("#<%=hidADistrictSysNo.ClientID%>").val());
        }
    }

    function DistrictChange<%=ddlADistrict.ClientID%>(districtSysNo) {
        ClearZone<%=ddlAZone.ClientID %>();
        $("#<%=hidADistrictSysNo.ClientID%>").val(districtSysNo);
        if (districtSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidAAreaSysNo.ClientID%>").val(districtSysNo);
        }
        else {
            $("#<%=hidAAreaSysNo.ClientID%>").val($("#<%=hidACityCode.ClientID%>").val());
        }
        if (districtSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            AjaxWebService("GetAZonesByDistrictSysNo", "{disctrictSysNo:'" + districtSysNo + "'}", DistrictChange_Callback<%=ddlADistrict.ClientID%>);
        }
        if ("<%=onDistrictChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onDistrictChange%>()");
        }
    }

    function DistrictChange_Callback<%=ddlADistrict.ClientID%>(result) {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlAZone.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlAZone.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
            if ($("#<%=hidAZoneSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                if ($("#<%=hidAZoneSysNo.ClientID%>").val() == result[i][0]) {
                    $("#<%=hidAAreaSysNo.ClientID%>").val($("#<%=hidAZoneSysNo.ClientID%>").val());
                }
            }
        }
        if ($("#<%=hidAZoneSysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlAZone.ClientID%>").val($("#<%=hidAZoneSysNo.ClientID%>").val());
        }
    }

    function ZoneChange<%=ddlAZone.ClientID %>(zoneSysNo) {
        $("#<%=hidAZoneSysNo.ClientID%>").val(zoneSysNo);
        if (zoneSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidAAreaSysNo.ClientID%>").val(zoneSysNo);
        }
        else {
            $("#<%=hidAAreaSysNo.ClientID%>").val($("#<%=ddlADistrict.ClientID%>").val());
        }
        if ("<%=onZoneChange%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onZoneChange%>()");
        }
    }

    function ClearDistrict<%=ddlADistrict.ClientID %>() {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlADistrict.ClientID%>").attr("disabled", true);
        }
        $("#<%=ddlADistrict.ClientID%>").empty();
        $("#<%=ddlADistrict.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    function ClearZone<%=ddlAZone.ClientID %>() {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlAZone.ClientID%>").attr("disabled", true);
        }
        $("#<%=ddlAZone.ClientID%>").empty();
        $("#<%=ddlAZone.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }
</script>
<div style='position: absolute; display: none; left: 0px; top: 0px; background-color: #FFF1A8; width: 150px; font-weight: bold; font-size: 12px; padding: 5px;'
    id='LoadingPanel'>
</div>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlADistrict" runat="server" AutoPostBack="false" Enabled="false" Width="130px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlAZone" runat="server" AutoPostBack="false" Enabled="false" Width="130px">
            </asp:DropDownList>
            
            <asp:HiddenField ID="hidACityCode" runat="server" />
            <asp:HiddenField ID="hidADistrictSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidAZoneSysNo" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidAAreaSysNo" runat="server" />
            <asp:HiddenField ID="hidArray" runat="server" />
        </td>
    </tr>
</table>