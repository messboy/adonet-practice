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

	//建立存取test資料層
	public DataSet gettestInfo()
	{
		SqlConnection conn =
			new SqlConnection(WebConfigurationManager.ConnectionStrings["default"].ConnectionString);
		
		DataSet ds = new DataSet(); 
		
		using(conn)
		{
			string connstring = "select id,class,summary from test";
			SqlDataAdapter adapter = new SqlDataAdapter(connstring, conn);
			adapter.Fill(ds);
		}	
		return ds;
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
}