using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
          //getInfo();
      }
        
    }

    //利用商業層存取資料
    private void getInfo()
    {
          Bl data = new Bl();
        System.Data.DataSet ds = data.testInfo();
        GridView1.DataSource = ds;
        GridView1.DataBind();

        //連線測試 ok!
        //SqlConnection conn =
        //    new SqlConnection(WebConfigurationManager.ConnectionStrings["default"].ConnectionString);
        //SqlCommand cmd = new SqlCommand("select * from test", conn);

        //SqlDataReader dr = null;

       
        //using (conn)
        //{
        //    conn.Open();
        //    dr = cmd.ExecuteReader();
        //    GridView1.DataSource = dr;
        //    GridView1.DataBind();
        //}
    }
}