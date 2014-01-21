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

	//更新回資料庫
	public void updateDB(DataSet ds,string delcmdstring , string updcmdstring, string insertcmdstring)
	{
		//建立連線物件
		SqlConnection conn =
			new SqlConnection(WebConfigurationManager.ConnectionStrings["CBooks"].ConnectionString);
		//建立橋接器物件
		SqlDataAdapter adapter = new SqlDataAdapter("select * from books", conn);
		//設定指令物件 
		SqlCommand cmd = new SqlCommand(delcmdstring, conn);
		//設定參數 ， 第四個引數表示指定其所要對應的欄位
		cmd.Parameters.Add("@bookID", SqlDbType.NChar,10,"bookID");
		//把指令物件加到橋接器
		adapter.DeleteCommand = cmd;


		//建立更新指令物件
		cmd = new SqlCommand(updcmdstring, conn);
		cmd.Parameters.Add("@bookID", SqlDbType.NChar, 10, "bookID");
		cmd.Parameters.Add("@bookTitle", SqlDbType.NChar, 50, "bookTitle");
		cmd.Parameters.Add("@bookISBN", SqlDbType.NChar, 20, "bookISBN");
		cmd.Parameters.Add("@bookPrice", SqlDbType.Int, 10, "bookPrice");
		cmd.Parameters.Add("@bookPublisher", SqlDbType.NChar, 10, "bookPublisher");
		cmd.Parameters.Add("@bookAuthor", SqlDbType.NChar, 10, "bookAuthor");
		cmd.Parameters.Add("@bookCoverUrl", SqlDbType.NChar, 50, "bookCoverUrl");
		cmd.Parameters.Add("@bookDate", SqlDbType.DateTime,8, "bookDate");
		adapter.UpdateCommand = cmd;

		//建立新增指令物件
		cmd = new SqlCommand(insertcmdstring, conn);
		cmd.Parameters.Add("@bookID", SqlDbType.NChar, 10, "bookID");
		cmd.Parameters.Add("@bookTitle", SqlDbType.NChar, 50, "bookTitle");
		cmd.Parameters.Add("@bookISBN", SqlDbType.NChar, 20, "bookISBN");
		cmd.Parameters.Add("@bookPrice", SqlDbType.Int, 10, "bookPrice");
		cmd.Parameters.Add("@bookPublisher", SqlDbType.NChar, 10, "bookPublisher");
		cmd.Parameters.Add("@bookAuthor", SqlDbType.NChar, 10, "bookAuthor");
		cmd.Parameters.Add("@bookCoverUrl", SqlDbType.NChar, 50, "bookCoverUrl");
		cmd.Parameters.Add("@bookDate", SqlDbType.DateTime, 8, "bookDate");
		adapter.InsertCommand = cmd;

		//橋接器上傳
		adapter.Update(ds);
	}
}