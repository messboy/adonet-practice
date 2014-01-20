using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// DL 的摘要描述
/// </summary>
public class DL
{
	public DL()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}



	//查詢CBook資料
	public DataTable CbookInfo(string bookID)
	{
		SqlConnection conn = 
			new SqlConnection(WebConfigurationManager.ConnectionStrings["CBooks"].ConnectionString);
		DataTable dt = null;

		using (conn)
		{
			//SQL語法
			string connstring = "select * from Books where bookID=@bookID";
			//命令物件
			SqlCommand cmd = new SqlCommand(connstring, conn);
			//因為有回傳變數，要設定參數
			SqlParameter parameters = new SqlParameter("@bookID", SqlDbType.NChar) { Value = bookID };
			cmd.Parameters.Add(parameters);
			//建立連接器
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet dss = new DataSet();
			adapter.Fill(dss);
			dt = dss.Tables["Table"];
		}

		return dt;
	}

    //連接
    public DataSet bindgridview()
    {
        SqlConnection conn =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["CBooks"].ConnectionString);
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter("select * from books", conn);
        using (conn)
        {
            
            adapter.Fill(ds);

            //設定P.K
            DataColumn[] dc = new DataColumn[1];
            dc[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = dc;
        }
        return ds;

    }
}