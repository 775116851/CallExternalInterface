<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="O2OTest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style/index.css" rel="stylesheet" />
    <link href="Style/reset.css" rel="stylesheet" />
    <link href="Style/pager.css" rel="stylesheet" />
    <style type="text/css">
        table {
            width: 100%;
        }

        #table1 tr th {
            width: 100px;
            min-width: 100px;
        }
    </style>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/json.js"></script>
    <script src="Scripts/Common.js"></script>
    <script src="Scripts/jquery.pager.js"></script>
    <script type="text/javascript">
        function LoadList(JsonObj) {
            //alert($.toJSON(JsonObj));
            $("#lblMsg").text("")
            $(".mask").show();
            $("#ListDiv").load("WebForm1_Ajax.aspx?PageIndex=" + CurrentPageIndex, JsonObj, function (a, b, c) {
                $("#ListDiv").fadeIn();
                $(".mask").hide();
            });

        }
        var CurrentPageIndex = 1;
        var PreJson; //记录之前的查询值，用于翻页

        function Search() {
            CurrentPageIndex = 1
            LoadList($("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject());
            PreJson = $("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject();

        }
        function goFilterPager() {
            if (PreJson == null) {
                PreJson = $("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject();
            }
            LoadList(PreJson);
        }

        function AddData() {
            //window.location.href = "AreaOpt.aspx";
            openModalDialog("AreaOpt.aspx", 800, 600);
            //window.showModalDialog("AreaOpt.aspx");
            //window.open("AreaOpt.aspx");
        }

        //默认回车搜索
        document.onkeyup = function () {
            if (event.keyCode == 13) {
                document.getElementById("btnSearch").click();
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="Button2" type="button" value="查 询" runat="server" onclick="Search()" />
        <div class="tablePanel">
                <table class="DingDanTable" id="Table2" cellspacing="1" cellpadding="2" width="80%" align="center">
                    <tr>
                        <td align="center" colspan="4" style="background-color: White; padding: 0px;">
                            <div id="ListDiv">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="text-align: center;">
                                    <tr>
                                        <td height="180px" style="text-align: center; padding-top: 40px;">&#160;                               
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
