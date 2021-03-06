﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class CRUD_dataset : System.Web.UI.Page
{
    DataSet ds = null;
    //重新載入dataset 
    private void setGVdatasource()
    {
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DL data = new DL();
            ds = data.bindgridview();

            //載入dataset到控制向
            setGVdatasource();

            Session["ds"] = ds;
            //Session["adapter"] = 

        }
        else
        {
            ds = (DataSet)Session["ds"];
            setGVdatasource();
        }
        
    }



    //移除按鈕
    protected void remove_Button_Click(object sender, EventArgs e)
    {
        DataRowCollection drc = ds.Tables[0].Rows;
        DataRow dr = drc.Find(TextBox1.Text);
        if (dr == null)
            return;
        drc.Remove(dr);
        Response.Write(dr.RowState);
        setGVdatasource();     
    }

    //delete按鈕
    protected void delete_Button_Click(object sender, EventArgs e)
    {
        DataRowCollection drc = ds.Tables[0].Rows;
        DataRow dr = drc.Find(TextBox2.Text);
        if (dr == null)
            return;
        dr.Delete();
        Response.Write(dr.RowState);
        Session["dr"] = dr;
        setGVdatasource();
    }

    //確認delete按鈕
    protected void acc_del_Button_Click(object sender, EventArgs e)
    {
        //檢查狀態
        if (Session["dr"] == null) return;
        DataRow dr = (DataRow)Session["dr"];
        dr.AcceptChanges();
        Session["dr"] = null;
        setGVdatasource();
    }

    //復原按鈕
    protected void rej_del_Button_Click(object sender, EventArgs e)
    {
        //檢查狀態
        if (Session["dr"] == null) return;
        DataRow dr = (DataRow)Session["dr"];
        dr.RejectChanges();
        Session["dr"] = null;
        setGVdatasource();
    }

    //新增欄位的數值
    private void setDataField(DataRow dr)
    {
        //迴圈將控制項的值 輸入到DataRow
        foreach (Control c in Panel1.Controls)
        {
            TextBox t = c as TextBox;
            if(t != null) 
            dr[t.ID] = t.Text;
        }

    }
    //新增按鈕
    protected void add_Button_Click(object sender, EventArgs e)
    {
        //產生一個相同schema的新列
        DataRow newdr = ds.Tables[0].NewRow();
        //加入使用者輸入的值
        setDataField(newdr);
        //把dr 加到ds集合去
        ds.Tables[0].Rows.Add(newdr);

        //重新讀取
        setGVdatasource();
    }

    //更新 只是更新dataset 尚未更新資料庫
    protected void update_Button_Click(object sender, EventArgs e)
    {
        DataRow dr = ds.Tables[0].NewRow();
        dr = ds.Tables[0].Rows.Find(bookID.Text);
        if (dr == null) return;
        setDataField(dr);
        setGVdatasource();
    }

    //
    protected void Button1_Click(object sender, EventArgs e)
    {
        DL DL = new DL();
        string delcmd = "delete books where bookID=@bookID";
        string updcmd = "update books set bookTitle=@bookTitle,bookISBN=@bookISBN,bookPirce=@bookPrice," + 
        "bookPublisher=@bookPublisher,bookAuthor=@bookAuthor,bookCoverUrl=@bookCoverUrl,bookDate=@bookDate where bookID=@bookID";
        string insertcmd = "insert into books values(@bookID,@bookTitle,@bookISBN,@bookPrice,@bookPublisher,@bookAuthor,@bookCoverUrl,@bookDate)";

        DL.updateDB(ds,delcmd, updcmd, insertcmd);
        Label1.Text = "更新完成";
    }
}