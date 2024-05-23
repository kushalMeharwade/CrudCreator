using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    SqlConnection conObjERP;
    string ServerName = "";
	public DataLayer(string serverName)
	{
        this.ServerName = serverName;
        string connectionText = String.Format("Data Source={0}; Initial Catalog=master; Connect Timeout=20000; pooling='true'; integrated security=true; Max Pool Size=10000;", this.ServerName);
        conObjERP = new SqlConnection(connectionText);
	}
    public DataLayer()
    {
        
    }

    //SqlConnection conObjERP = new SqlConnection(ConfigurationManager.ConnectionStrings["app"].ConnectionString.ToString());


    public void setServer(string server)
    {
        this.ServerName = server;
        string connectionText = String.Format("Data Source={0}; Initial Catalog=master; Connect Timeout=20000; pooling='true'; integrated security=true; Max Pool Size=10000;",this.ServerName);
        //string connectionText = String.Format("Data Source=BHASKAR\\SQLEXPRESS; Initial Catalog=master; Connect Timeout=20000; pooling='true'; integrated security=true; Max Pool Size=10000;");
        conObjERP = new SqlConnection(connectionText);

    }
    public void setDatabase(string databaseName)
    {
        string connectionText = String.Format("Data Source={0}; Initial Catalog={1}; Connect Timeout=20000; pooling='true'; integrated security=true; Max Pool Size=10000;", this.ServerName,databaseName);
     //   string connectionText = String.Format("Data Source=BHASKAR\\SQLEXPRESS; Initial Catalog=master; Connect Timeout=20000; pooling='true'; integrated security=true; Max Pool Size=10000;");

        conObjERP = new SqlConnection(connectionText);
    }

    public void IntializeConnection()
    {
        if (conObjERP.State == ConnectionState.Open)
        {
            conObjERP.Close();
        }
        conObjERP.Open();
    }

    public void ExecuteCMD(SqlCommand cmd)
    {
        IntializeConnection();
        SqlTransaction sqlTrans = conObjERP.BeginTransaction();
        cmd.Connection = conObjERP;
        cmd.Transaction = sqlTrans;
        cmd.ExecuteNonQuery();
        sqlTrans.Commit();

    }
    public DataTable GetDataTable(SqlCommand cmd)
    {
        IntializeConnection();
        cmd.Connection = conObjERP;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt != null)
        {
            return dt;
        }
        else
        {
            return null;
        }

    }

    public DataTable GetDataTable(string qry)
    {
        conObjERP.Close();

        conObjERP.Open();
        SqlCommand cmd = new SqlCommand(qry, conObjERP);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt != null)
        {
            return dt;
        }
        else
        {
            return null;
        }
        conObjERP.Close();
    }


    public DataSet ReturnDataSet(SqlCommand cmd)
    {
        IntializeConnection();
        cmd.Connection = conObjERP;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        if (dt != null)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }
    public SqlDataReader GetReader(SqlCommand cmd)
    {
        IntializeConnection();
        cmd.Connection = conObjERP;
        SqlDataReader read = cmd.ExecuteReader();
        return read;

    }

    public void ExecuteQuery(string strQrystr)
    {
        IntializeConnection();
        SqlTransaction sqlTrans = conObjERP.BeginTransaction();

        SqlCommand cmd = new SqlCommand(strQrystr, conObjERP);
        cmd.Transaction = sqlTrans;
        cmd.ExecuteNonQuery();
        sqlTrans.Commit();

    }
}