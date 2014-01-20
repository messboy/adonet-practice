<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dataset練習.aspx.cs" Inherits="Dataset練習" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        編號 :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        書名 : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        ISBN:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        價格:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        發行:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        作者:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        日期:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
