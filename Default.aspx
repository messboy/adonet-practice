<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1.0" /> 
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .red{ background-color:#f00;}
        .green{ background-color:#0ff; }
        .blue { background-color:#00ff21; }

        div {height:10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contain">
        <div class="row">
            <div class="col-md-12 red "></div>
        </div>
    </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ajax-loader.gif" />
        <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="gettestInfo" TypeName="DL">
        </asp:ObjectDataSource>
    </form>
        
</body>
</html>
