using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudCreator.Code
{
    class BusinessLayer
    {
        DataLayer DL = new DataLayer();

        public void GetDatabases(ComboBox list)
        {
            try
            {
                string query = "select NAME from sys.databases where database_id > 4 ORDER BY NAME";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                SqlDataReader sdr = DL.GetReader(cmd);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        list.Items.Add(sdr["NAME"].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                list.Items.Add(ex.Message);
            }
           
            

        }
        public void setServer(string serverName)
        {
            DL.setServer(serverName);
        }
        public void setDatabase(string database)
        {
            DL.setDatabase(database);
        }

        public void GetTables(ComboBox list)
        {
            try
            {
                string query = "SELECT DISTINCT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS ORDER BY TABLE_NAME";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;

                SqlDataReader sdr = DL.GetReader(cmd);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        list.Items.Add(sdr["TABLE_NAME"].ToString());
                    }

                }
            }
            catch (Exception ex)
            {

            }
      
        }

        public SqlDataReader GetColumns(string tableName)
        {
            string query = "SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =@tableName ORDER BY ORDINAL_POSITION";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            return DL.GetReader(cmd);
        }



        public void listColumns(CheckedListBox columnToBeSelected, CheckedListBox primaryKey, CheckedListBox requiredFields, CheckedListBox rptList, CheckedListBox fileUpload, CheckedListBox ddl,string tableName)
        {
            string tableDetailsQuery =
            "select COLUMN_NAME AS tableColumnName,DATA_TYPE  as tableDataType,CHARACTER_MAXIMUM_LENGTH as length from INFORMATION_SCHEMA.COLUMNS  where TABLE_NAME=@tableName ORDER BY ORDINAL_POSITION";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@tableName", tableName);
            cmd.CommandText = tableDetailsQuery;
            SqlDataReader sdr = DL.GetReader(cmd);


            if (sdr.HasRows)
            {
                while (sdr.Read())
                {


                    columnToBeSelected.Items.Add(sdr["tableColumnName"].ToString());
                    rptList.Items.Add(sdr["tableColumnName"].ToString());
                    primaryKey.Items.Add(sdr["tableColumnName"].ToString());
                    requiredFields.Items.Add(sdr["tableColumnName"].ToString());
                    fileUpload.Items.Add(sdr["tableColumnName"].ToString());
                    ddl.Items.Add(sdr["tableColumnName"].ToString());

                }

            }

        }
        public DataTable GetDataTable(SqlCommand cmd)
        {
            return DL.GetDataTable(cmd);

        }

        public void GetServers(ComboBox list)
        {
            DataTable table = SmoApplication.EnumAvailableSqlServers(true);
            list.ValueMember = "Name";
            list.DataSource = table;
        }

       public String WriteTextFile(string contentToSave)
        {
            string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in
            string saveFilePath = Path.Combine(applicationPath, "server.txt");
            StreamWriter w = new StreamWriter(saveFilePath, true);
            w.WriteLine(contentToSave);
            w.Close();
            return saveFilePath;
        }

        public String  readServerName()
        {
            string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in
            string serverName;
            string fileName = Path.Combine(applicationPath, "server.txt");
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                serverName = File.ReadAllText(fileName);


            }
            else
            {
                serverName = "";
            }


            return serverName;


        }


    }
}
