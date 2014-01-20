using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class find_select : System.Web.UI.Page
{
    //共用的dataset
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

            bindgridview();
        
    }

    //連GV1
    public void bindgridview()
    {
        SqlConnection conn = 
            new SqlConnection(WebConfigurationManager.ConnectionStrings["CBooks"].ConnectionString);

        SqlDataAdapter adapter = new SqlDataAdapter("select * from books", conn);
        
        adapter.Fill(ds);

        //設定P.K
        DataColumn[] dc = new DataColumn[1];
        dc[0] = ds.Tables[0].Columns[0];
        ds.Tables[0].PrimaryKey = dc;

        GridView1.DataSource = ds;
        GridView1.DataBind();

    }

    //使用datarowcollection  find方法,找PK
    protected void find_Button_Click(object sender, EventArgs e)
    {
        DataRowCollection drc = ds.Tables[0].Rows;
        if (TextBox2.Text.Length > 0)
        {
            //如果沒有設定PK 會失敗，因為find方法是找主鍵值
            DataRow dr = drc.Find(TextBox2.Text);
            try
            {
                Label1.Text = dr["bookTitle"].ToString();
            }
            catch (System.Exception ex)
            {
                Response.Write("找不到該值");
            }
            
        }
    }

    //使用datable的select()方法，可搜尋出多筆，請用datarow[]
    protected void select_Button_Click(object sender, EventArgs e)
    {
        DataTable tb = ds.Tables[0];
        DataRow[] drs = null;
        if (TextBox1.Text.Length > 0)
        {
            try
            {
                  drs = tb.Select(TextBox1.Text);
                  ListBox1.Items.Clear();
                  foreach (DataRow dr in drs)
                   {
                       ListBox1.Items.Add(dr[1].ToString());
                   }
            }
            catch (System.Exception ex)
            {
                Response.Write("找不到");
            }
        }
    }
}