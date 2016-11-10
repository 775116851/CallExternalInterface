<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VCategory.ascx.cs" Inherits="AreaUI.UI.VCategory" %>
<script src="<%=ResolveUrl("~/scripts/share.js")%>" type="text/javascript"></script>
<script type="text/javascript">
    function CategoryTypeChange<%=ddlCategoryType.ClientID %>(areaLevelSysNo) {
        if (areaLevelSysNo != '-9999') {
            $("#<%=hidCategorySysNo.ClientID %>").val(areaLevelSysNo);
            $("#<%=ddlCategoryType.ClientID%>").val(areaLevelSysNo);
            ClearC1();
            ClearC2();
            ClearC3();
            $("#<%=ddlC1.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidCategorySysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidC1SysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidC2SysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            $("#<%=hidC3SysNo.ClientID%>").val("<%=allinpay.O2O.Cmn.AppConst.IntNull%>");
            if (areaLevelSysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
                AjaxWebService("GetC1List", "{categoryType:'" + areaLevelSysNo + "'}", CChange_Callback);
            }
        }
    }

    function CChange_Callback(result) {
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlC1.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
        }
        if ($("#<%=hidC1SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlC1.ClientID%>").val($("#<%=hidC1SysNo.ClientID%>").val());
        }
    }
    function C1Change(c1SysNo) {
        ClearC2();
        ClearC3();
        $("#<%=hidCategorySysNo.ClientID%>").val(c1SysNo);
        $("#<%=hidC1SysNo.ClientID%>").val(c1SysNo);
        if (c1SysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            AjaxWebService("GetC2List", "{c1SysNo:'" + c1SysNo + "'}", C1Change_Callback);
        }
        if ("<%=onC1Change%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onC1Change%>()");
        }
    }

    function C1Change_Callback(result) {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlC2.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlC2.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
        }
        if ($("#<%=hidC2SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlC2.ClientID%>").val($("#<%=hidC2SysNo.ClientID%>").val());
        }
    }

    function C2Change(c2SysNo) {
        ClearC3();
        $("#<%=hidC2SysNo.ClientID%>").val(c2SysNo);
        if (c2SysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidCategorySysNo.ClientID%>").val(c2SysNo);
        }
        else {
            $("#<%=hidCategorySysNo.ClientID%>").val($("#<%=ddlC1.ClientID%>").val());
        }
        if (c2SysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            AjaxWebService("GetC3List", "{c2SysNo:'" + c2SysNo + "'}", C2Change_Callback);
        }
        if ("<%=onC2Change%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onC2Change%>()");
        }
    }

    function C2Change_Callback(result) {
        if ("<%=Enable%>" != "False") {
            $("#<%=ddlC3.ClientID%>").attr("disabled", false);
        }
        for (var i = 0; i < result.length; i++) {
            $("#<%=ddlC3.ClientID%>").append(("<option value='" + result[i][0] + "'>" + result[i][1] + "</option>"));
        }
        if ($("#<%=hidC3SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=ddlC3.ClientID%>").val($("#<%=hidC3SysNo.ClientID%>").val());
        }
    }

    function C3Change(c3SysNo) {
        $("#<%=hidC3SysNo.ClientID%>").val(c3SysNo);
        if (c3SysNo != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            $("#<%=hidCategorySysNo.ClientID%>").val(c3SysNo);
        }
        else {
            $("#<%=hidCategorySysNo.ClientID%>").val($("#<%=ddlC3.ClientID%>").val());
        }
        if ("<%=onC3Change%>" != "<%=allinpay.O2O.Cmn.AppConst.StringNull%>") {
            eval("<%=onC3Change%>()");
        }
    }

    function ClearC1() {
        //$("#<%=ddlC1.ClientID%>").attr("disabled", true);
        $("#<%=ddlC1.ClientID%>").empty();
        $("#<%=ddlC1.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    function ClearC2() {
        $("#<%=ddlC2.ClientID%>").attr("disabled", true);
        $("#<%=ddlC2.ClientID%>").empty();
        $("#<%=ddlC2.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    function ClearC3() {
        $("#<%=ddlC3.ClientID%>").attr("disabled", true);
        $("#<%=ddlC3.ClientID%>").empty();
        $("#<%=ddlC3.ClientID%>").append(("<option value='" +<%=allinpay.O2O.Cmn.AppConst.IntNull%> +"'>--- 全部 ---</option>"));
    }

    $(document).ready(function () {
        if ($("#<%=hidC1SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            C1Change($("#<%=hidC1SysNo.ClientID%>").val());
        }
        if ($("#<%=hidC2SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            C2Change($("#<%=hidC2SysNo.ClientID%>").val());
        }
        if ($("#<%=hidC3SysNo.ClientID%>").val() != "<%=allinpay.O2O.Cmn.AppConst.IntNull%>") {
            C3Change($("#<%=hidC3SysNo.ClientID%>").val());
        }
    })
</script>

<div style='position: absolute; display: none; left: 0px; top: 0px; background-color: #FFF1A8; width: 150px; font-weight: bold; font-size: 12px; padding: 5px;'
    id='LoadingPanel'>
</div>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td nowrap style=" border:none;padding-left:0 ">
            <asp:DropDownList ID="ddlCategoryType" runat="server" AutoPostBack="false" Width="100px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlC1" runat="server" AutoPostBack="false" onchange="C1Change(this.value)" Width="130px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlC2" runat="server" AutoPostBack="false" onchange="C2Change(this.value)" Enabled="false" Width="130px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlC3" runat="server" AutoPostBack="false" onchange="C3Change(this.value)" Enabled="false" Width="130px">
            </asp:DropDownList>
            <asp:HiddenField ID="hidCategoryType" runat="server" Value="-9999" />
            <asp:HiddenField ID="hidC1SysNo" runat="server" Value="-9999"/>
            <asp:HiddenField ID="hidC2SysNo" runat="server" Value="-9999"/>
            <asp:HiddenField ID="hidC3SysNo" runat="server" Value="-9999"/>
            <asp:HiddenField ID="hidCategorySysNo" runat="server" />
        </td>
    </tr>
</table>