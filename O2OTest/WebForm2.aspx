<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="O2OTest.WebForm2" %>

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
        var CurrentPageIndex = 1;
        var PreJson; //记录之前的查询值，用于翻页
        var show = { per: 10, index: { n: "首页", m: "first" }, pre: { n: "上一页", m: "prev" }, next: { n: "下一页", m: "next" }, last: { n: "尾页", m: "last" } };
        PageClick = function (pageclickednumber) {
            CurrentPageIndex = pageclickednumber;
            goFilterPager();
        }

        function Search() {
            CurrentPageIndex = 1
            LoadList($("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject());
            PreJson = $("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject();
        }

        function LoadList(JsonObj) {
            $.post('WebForm2.aspx',{'Pmethod':'ABB','CNum':CurrentPageIndex},function (data, b, c) {
            })
        }

        function goFilterPager() {
            if (PreJson == null) {
                PreJson = $("[sname='forminput'],#ddlStatus_ddlEnum,#ddlIsMaster_ddlEnum,#ddlIsOnlineShow_ddlEnum,#ucArea_hidAreaSysNo").serializeObject();
            }
            LoadList(PreJson);
        }

        $(function () {
            $("#pager").pager({ pagenumber: <%=PageIndex %>, pagecount: <%=MaxPages %>, buttonClickCallback: PageClick, show: show });
            $("#datatable tr").mouseover(function() {
                $(this).addClass("over");
            }).mouseout(function() {
                $(this).removeClass("over");
            });
            $("#datatable tr").click(function() {
                $.each($("#datatable tr"), function(i, n) {
                    $(n).removeClass("selected");
                });
                $(this).addClass("selected");
            });
        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="Button2" type="button" value="查 询" runat="server" onclick="Search()" />
        <div>
        <asp:GridView ID="Grv_SPLBMB" runat="server" AutoGenerateColumns="False" OnRowEditing="Grv_SPLBMB_RowEditing" OnRowCancelingEdit="Grv_SPLBMB_RowCancelingEdit" OnRowCommand="Grv_SPLBMB_RowCommand" OnRowDataBound="Grv_SPLBMB_RowDataBound" OnRowUpdating="Grv_SPLBMB_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="已有属性">
                                    <ItemTemplate>
                                        <%#Eval("PropertyName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="所属组" >
                                    <ItemTemplate>
                                        <%#Eval("GroupDesc") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <input id="ipt_CtrlDisplaySSZ" runat="server" style="width: 32px" type="hidden" value='<%# Eval("GroupSysNo") %>' />
                                        <asp:DropDownList ID="cblSSZ" runat="server" DataSource='<%#BindSSZ() %>' DataTextField="GroupDesc" DataValueField="SysNo">
                                            <%--<asp:ListItem Value="1">属性值</asp:ListItem>
                                            <asp:ListItem Value="2">属性名+属性值</asp:ListItem>
                                            <asp:ListItem Value="3">属性值+属性名</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否搜索" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSS1" Enabled="False" runat="server" Checked='<%# Eval("IsInAdvSearch").ToString().Trim()=="0"?false:true %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="cbSS2" runat="server" Checked='<%# Eval("IsInAdvSearch").ToString().Trim()=="0"?false:true %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="前台显示" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblSXZ" runat="server" Text='<%#GetDisplayType(Eval("WebDisplayStyle").ToString().Trim()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <input id="ipt_CtrlDisplayType" runat="server" style="width: 32px" type="hidden" value='<%# Eval("WebDisplayStyle") %>' />
                                        <asp:DropDownList ID="cblSXZ" runat="server">
                                            <asp:ListItem Value="1">属性值</asp:ListItem>
                                            <asp:ListItem Value="2">属性名+属性值</asp:ListItem>
                                            <asp:ListItem Value="3">属性值+属性名</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="必须设值" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSZ1" Enabled="False" runat="server" Checked='<%# Eval("IsMustInput").ToString().Trim()=="0"?false:true %>'/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="cbSZ2" runat="server" Checked='<%# Eval("IsMustInput").ToString().Trim()=="0"?false:true %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="排序" >
                                    <ItemTemplate>
                                        <%#Eval("SortNo") %>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSort2" runat="server" Width="33px" Text='<%#Eval("SortNo") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="修改" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEdit"  runat="server" CommandName="Edit" CommandArgument='<%#Eval("SysNo") %>'>修改</asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbUpdate"  runat="server" CommandName="Update" CommandArgument='<%#Eval("SysNo") %>'>更新</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="Btn_cancel" runat="server" CommandName="Cancel" Text="取消" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lkbut_del" CommandName="del" Text="删除" CommandArgument='<%#Eval("SysNo") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        <div id="pager" class="pager">
        </div>
    </form>
</body>
</html>
