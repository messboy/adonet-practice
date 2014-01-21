<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD dataset.aspx.cs" Inherits="CRUD_dataset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
    <p>
        remove書籍編號(直接刪掉了) :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="remove_Button" runat="server" Text="移除" Height="20px" Width="144px" OnClick="remove_Button_Click" />
        <br />
        delete書籍編號(可復原) :
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="delete_Button" runat="server" Text="刪除" Height="21px" Width="188px" OnClick="delete_Button_Click" />
         &nbsp;
         &nbsp;
         <asp:Button ID="rej_del_Button" runat="server" Text="復原" OnClick="rej_del_Button_Click" />
    &nbsp;<asp:Button ID="acc_del_Button" runat="server" Text="確認" OnClick="acc_del_Button_Click" />
    </p>

        

       
            <asp:Panel ID="Panel1" runat="server">
                    異動書籍編號 :
            <asp:TextBox ID="bookID" runat="server"></asp:TextBox>
            <asp:Button ID="add_Button" runat="server" Text="新增" OnClick="add_Button_Click" ValidationGroup="a" />
         <asp:Button ID="update_Button" runat="server" Text="更新" ValidationGroup="a" OnClick="update_Button_Click" />
            <div class="row">
                <div class="col-md-1">booktitle</div>
                <div class="col-md-3"><asp:TextBox ID="bookTitle" runat="server"></asp:TextBox><br/></div>
            </div>
            <div class="row">
                <div class="col-md-1">bookISBN</div>
                <div class="col-md-3"> <asp:TextBox ID="bookISBN" runat="server"></asp:TextBox> <br/></div>
            </div>
            <div class="row">
                <div class="col-md-1">bookPrice</div>
                <div class="col-md-3"> <asp:TextBox ID="bookPrice" runat="server"></asp:TextBox><br /></div>
                            </div>
            <div class="row">

                <div class="col-md-1">bookPublisher</div>
                <div class="col-md-3"><asp:TextBox ID="bookPublisher" runat="server"></asp:TextBox><br /></div>
                            </div>
            <div class="row">

                <div class="col-md-1">bookAuthr</div>
                <div class="col-md-3"><asp:TextBox ID="bookAuthor" runat="server"></asp:TextBox> <br /></div>
                            </div>
            <div class="row">

                <div class="col-md-1">bookCoverUrl</div>
                <div class="col-md-3"><asp:TextBox ID="bookCoverUrl" runat="server"></asp:TextBox><br /></div>
                            </div>
            <div class="row">

                <div class="col-md-1">bookDate</div>
                <div class="col-md-3"> <asp:TextBox ID="bookDate" runat="server"></asp:TextBox> &nbsp;<br />&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上船資料庫" />
&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        
        </asp:Panel>
           
           
    </div>
    </form>
</body>
</html>
