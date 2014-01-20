<%@ Page Language="C#" AutoEventWireup="true" CodeFile="find_select.aspx.cs" Inherits="find_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="caption">
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <div class="contain">
            <div class="row">
                <div class="col-md-1">find :</div>
                <div class="col-md-9">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Button ID="find_Button" runat="server" Text="Button" OnClick="find_Button_Click" />

                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-9"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
            </div>
            <div class="row">
                <div class="col-md-1">select :</div>
                <div class="col-md-9">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="select_Button" runat="server" Text="Button" OnClick="select_Button_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-9"><asp:ListBox ID="ListBox1" runat="server" Height="138px" Width="451px"></asp:ListBox></div>
            </div>
        </div>
    </div>
    </form>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
