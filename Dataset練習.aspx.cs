using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Dataset練習 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        searchInfo(TextBox1.Text.ToString());
    }

    //搜尋一筆Book資料
    private void searchInfo(string bookID)
    {

        DL book = new DL();
        DataRowCollection drc = book.CbookInfo(bookID).Rows;

        if(drc.Count > 0)
        {
            display(drc[0]);
        }
        else
        {
            cleardata();
            Response.Write("查無資料");
        }
    }

    //展示資料
    private void display(DataRow dr)
    {
        TextBox2.Text = dr["bookTitle"].ToString();
        TextBox3.Text = dr["bookISBN"].ToString();
        TextBox4.Text = dr["bookPrice"].ToString();
        TextBox5.Text = dr["bookPublisher"].ToString();
        TextBox6.Text = dr["bookAuthor"].ToString();
        TextBox7.Text = dr["bookDate"].ToString();
    }
    private void cleardata()
    {
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
    }

}