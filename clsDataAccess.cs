using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataAccess
/// </summary>
public class clsDataAccess
{
	public clsDataAccess()
	{
		//
		// TODO: Add constructor logic here
		//
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
	}
    private SqlConnection conn;
    private SqlCommand cmd;
    public SqlConnection getconnection()
    {
        return conn;
    }

    public void OpenConnection()
    {
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
    }

    public void CloseConnection()
    {
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();

        }
    }
    public DataSet Get_LoginDetails(string UserName,string Password)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sqladp = new SqlDataAdapter();
        try
        {
            OpenConnection();
            cmd = new SqlCommand("SP_Login_Select", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            cmd.Parameters.AddWithValue("@fPassword", Password);
            sqladp.SelectCommand = cmd;
            sqladp.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return ds;
    }

    public DataSet Get_PublisherDetails()
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sqladp = new SqlDataAdapter();
        try
        {
            OpenConnection();
            cmd = new SqlCommand("SP_Publisher_Select", conn);
            cmd.CommandType = CommandType.StoredProcedure; 
            sqladp.SelectCommand = cmd;
            sqladp.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return ds;
    }

    public int insert_Publisher(string PublisherName, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Publisher_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fPublisherName", PublisherName);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Update_Publisher(string PublisherName,string PublisherID, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Publisher_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fPublisherName", PublisherName);
            cmd.Parameters.AddWithValue("@fPublisherID", PublisherID);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Delete_Publisher(string PublisherID)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Publisher_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@fPublisherID", PublisherID); 
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    //Author Details


    public DataSet Get_AuthorDetails()
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sqladp = new SqlDataAdapter();
        try
        {
            OpenConnection();
            cmd = new SqlCommand("SP_Author_Select", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            sqladp.SelectCommand = cmd;
            sqladp.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return ds;
    }

    public int insert_Author(string AuthorName, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Author_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fAuthorName", AuthorName);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Update_Author(string AuthorName, string AuthorID, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Author_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fAuthorName", AuthorName);
            cmd.Parameters.AddWithValue("@fAuthorID", AuthorID);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Delete_Author(string AuthorID)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Author_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fAuthorID", AuthorID);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
     
    //Book Details
    public DataSet Get_BookDetails()
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sqladp = new SqlDataAdapter();
        try
        {
            OpenConnection();
            cmd = new SqlCommand("SP_Book_Select", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            sqladp.SelectCommand = cmd;
            sqladp.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return ds;
    }

    public int insert_Book(string BookName,string fBookCategoryID,int fBookCount ,string fPublisherID,string fAuthorID, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Book_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fBookName", BookName);
            cmd.Parameters.AddWithValue("@fBookCategoryID", fBookCategoryID);
            cmd.Parameters.AddWithValue("@fBookCount", fBookCount);
            cmd.Parameters.AddWithValue("@fPublisherID", fPublisherID);
            cmd.Parameters.AddWithValue("@fAuthorID", fAuthorID);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Update_Book(string BookName,string fBookCategoryID,int fBookCount ,string fPublisherID,string fAuthorID, string UserName, string BookID)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Book_Update", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fBookName", BookName);
            cmd.Parameters.AddWithValue("@fBookCategoryID", fBookCategoryID);
            cmd.Parameters.AddWithValue("@fBookCount", fBookCount);
            cmd.Parameters.AddWithValue("@fPublisherID", fPublisherID);
            cmd.Parameters.AddWithValue("@fAuthorID", fAuthorID);
            cmd.Parameters.AddWithValue("@fBookID", BookID);
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Delete_Book(string BookID)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_Book_Delete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fBookID", BookID);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
    public int Insert_BookLend(string BookID, string UserName)
    {
        int rowsaffected = 0;


        try
        {
            //do function
            OpenConnection();
            SqlCommand cmd = new SqlCommand("SP_BookLend_Insert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fBookID", BookID); 
            cmd.Parameters.AddWithValue("@fUserID", UserName);
            rowsaffected = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return rowsaffected;
    }
}