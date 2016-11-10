<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadScrollImg.aspx.cs"
    Inherits="HighWeb.uploadScrollImg" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>图片批量上传</title>
    <style type="text/css">
        <!--
        body {
            margin: 0;
            padding: 0;
            width: 100%;
        }
        #upload_filelist {
            width: 600px;
            list-style-type:decimal-leading-zero;
        }
        #upload_filelist li {
            clear:both;
            margin:0;
            padding:0;
            width:100%;
        }
        .img_upload_view {
            float: right;
            width: 300px;
            height:260px;
            border:1px dashed red;
            display:none;
        }
        .img_upload_view dt,.img_upload_view dd{
            margin:0;
            padding:0;
            width:100%;
            border:1px solid #CCCCCC;
        }
        #resut_msg{
            color:Green;
        }
        -->
    </style>
</head>
<body>
    <fieldset>
        <legend>图片上传</legend>
        <form action="uploadScrollImg.aspx" method="post" enctype="multipart/form-data">
        <ol id="upload_filelist">
            <li>
                <input type="file" name="file_upload_01" value="请选择一张图片" /><dl id="img_view_01" class="img_upload_view">
                    <dt>
                        <img id="img_upload_01" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_01" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_02" value="请选择一张图片" /><dl id="img_view_02" class="img_upload_view">
                    <dt>
                        <img id="img_upload_02" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_02" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_03" value="请选择一张图片" /><dl id="img_view_03" class="img_upload_view">
                    <dt>
                        <img id="img_upload_03" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_03" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_04" value="请选择一张图片" /><dl id="img_view_04" class="img_upload_view">
                    <dt>
                        <img id="img_upload_04" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_04" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_05" value="请选择一张图片" /><dl id="img_view_05" class="img_upload_view">
                    <dt>
                        <img id="img_upload_05" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_05" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_06" value="请选择一张图片" /><dl id="img_view_06" class="img_upload_view">
                    <dt>
                        <img id="img_upload_06" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_06" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_07" value="请选择一张图片" /><dl id="img_view_07" class="img_upload_view">
                    <dt>
                        <img id="img_upload_07" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_07" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_08" value="请选择一张图片" /><dl id="img_view_08" class="img_upload_view">
                    <dt>
                        <img id="img_upload_08" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_08" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_09" value="请选择一张图片" /><dl id="img_view_09" class="img_upload_view">
                    <dt>
                        <img id="img_upload_09" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_09" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li>
                <input type="file" name="file_upload_10" value="请选择一张图片" /><dl id="img_view_10" class="img_upload_view">
                    <dt>
                        <img id="img_upload_10" src="" width="160" height="160" alt="图片加载中...." /></dt>
                    <dd>
                        <input id="input_upoad_10" value="请输入图片的描述" />
                    </dd>
                </dl>
            </li>
            <li style="list-style-type: none">
                <input type="submit" value="开始上传" /><input type="reset" value="全部取消" /><span id="resut_msg"><%=UploadMsg%></span></li>
        </ol>
        <input type="hidden" value="<%=loadSucces %>" />
        </form>
    </fieldset>
    <script type="text/javascript">
    <!--
    var loadSucess = <%=loadSucces %>;
        window.onload=function(){
            if (loadSucess) {
                for(var f in loadSucess){
                    if(loadSucess[f]!=undefined)
                    {
                        var num= loadSucess[f].fn.replace ("file_upload_","");
                        document.getElementById("img_view_"+num).style.display="block";
                        document.getElementById("img_view_"+num).style.width="300px";
                        document.getElementById("img_view_"+num).style.height="260px";
                        document.getElementById("img_upload_"+num).setAttribute("src",loadSucess[f].ph);
                    }
                }
            }
        }
        -->
    </script>
</body>
</html>