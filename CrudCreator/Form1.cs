using CrudCreator.Code;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudCreator
{
    public partial class Form1 : Form
    {
        // Primary Count 
        int primaryCount = 0;
       public static string serverName;

       public string aspxFilePath = "";
       public string codeFilePath = "";
       public string BLFilePath = "";
       public string GCFilePath = "";
        

        // Arrays and Lists
        ArrayList tableColumnList = new ArrayList();
        ArrayList RepeaterColumnList = new ArrayList();
        ArrayList widgetCodeList = new ArrayList();
        ArrayList ModalCodeList = new ArrayList();
        // TEMP VARIABLES

        string PrimaryKey = "";
        string tableName = "";
        //  fileWriter 

        FileWriter fileWriter = new FileWriter();



        // Additional Files
        BusinessLayer BL = new BusinessLayer();
        DataLayer DL = new DataLayer();
        public Form1()
        {
            InitializeComponent();
            columnList.Visible = false ;
            requiredList.Visible = false;
            repeaterList.Visible = false;
            primaryList.Visible = false;


            
            
            

            
          
            string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in

            FileInfo fileProperty = new FileInfo(Path.Combine(applicationPath, "server.txt"));
            if (fileProperty.Exists)
               {
                string serverName=BL.readServerName().Trim();
                BL.setServer(serverName);
                txtServer.Text = serverName;
                BL.GetDatabases(ddlDatabse);
                

                System.Windows.Forms.MessageBox.Show("" + serverName + " was set as Default Database");
            }
            
        
 

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
                  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serverName = txtServer.Text.ToString();
            BL.setServer(serverName);
            BL.WriteTextFile(serverName);
           // ddlDatabse.ValueMember = "name";
           // ddlDatabse.DataSource = BL.GetDatabases();
            BL.GetDatabases(ddlDatabse);
            System.Windows.Forms.MessageBox.Show("Database Set Successfully");

        }

        private void ddlServer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlDatabse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL.setDatabase(ddlDatabse.SelectedItem.ToString());
            ddlTable.Items.Clear();
             BL.GetTables(ddlTable);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            requiredList.Visible = true;
            columnList.Visible = true;
            repeaterList.Visible = true;
            primaryList.Visible = true;
           
            
            BL.listColumns(columnList, primaryList, requiredList, repeaterList,fileUploadList,ddlList, ddlTable.SelectedItem.ToString());
        }

        private void primaryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HandleSumbitClick()
        {

            this.tableName = ddlTable.SelectedItem.ToString();



            string query = "select COLUMN_NAME AS tableColumnName,DATA_TYPE as tableDataType,CHARACTER_MAXIMUM_LENGTH as length from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @tableName";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tableName", tableName);
            DataTable table = BL.GetDataTable(cmd);

            foreach(int i in columnList.CheckedIndices){
               
                ColumnRow col = new ColumnRow();
                col.columnName = columnList.Items[i].ToString();
                col.columnLength = table.Rows[i]["length"].ToString();
                col.DataType = table.Rows[i]["tableDataType"].ToString();
                if (requiredList.CheckedIndices.Contains(i))
                {
                    col.isRequired = true;
                }
                else
                {
                    col.isRequired = false;
                }
                if (primaryList.CheckedIndices.Contains(i))
                {
                    col.isPrimaryKey = true;
                }
                else
                {
                    col.isPrimaryKey = false;
                }
                if (ddlList.CheckedIndices.Contains(i))
                {
                    col.isDropdownList = true;
                    col.isFileUpload = false;

                }else if (fileUploadList.CheckedIndices.Contains(i))
                {
                    col.isDropdownList = false;
                    col.isFileUpload = true;
                }
               
                if (col.isPrimaryKey)
                {
                    this.PrimaryKey = col.columnName.Trim();
                    primaryCount++;
                }
                if (col.isDropdownList)
                {
                    col.widgetId = "ddl_" + col.columnName.Trim();

                }
                else if (col.isFileUpload)
                {
                    col.widgetId = "file_" + col.columnName.Trim();

                }
                else
                {
                    col.widgetId = "txt_" + col.columnName.Trim();

                }
                tableColumnList.Add(col);

            }
            if (primaryCount >= 2)
            {
                System.Windows.Forms.MessageBox.Show("Please select only one Primary Key");
                return;

            }


            //for (int i = 0; i < columnList.Items.Count; i++)
            //{
            //    if (columnList.Items[i].Selected)
            //    {
            //        ColumnRow col = new ColumnRow();
            //        col.columnName = columnList.Items[i].ToString();
            //        col.columnLength = table.Rows[i]["length"].ToString();
            //        col.DataType = table.Rows[i]["tableDataType"].ToString();
            //        col.isRequired = requiredList.Items[i].Selected;
            //        col.isPrimaryKey = primaryList.Items[i].Selected;
            //        if (col.isPrimaryKey)
            //        {
            //            this.PrimaryKey = col.columnName.Trim();
            //            primaryCount++;
            //        }
            //        col.widgetId = "txt_" + col.columnName.Trim();
            //        tableColumnList.Add(col);
            //    }
            //}

            foreach (int i in repeaterList.CheckedIndices)
            {
                RepeaterColumnList.Add(repeaterList.Items[i].ToString());
            }
            //for (int i = 0; i < repeaterList.Items.Count; i++)
            //{
            //    if (repeaterList.Items[i].Selected)
            //    {
            //        RepeaterColumnList.Add(repeaterList.Items[i].Text);
            //    }
            //}



            // File Path Setup

            //aspxFilePath += this.tableName + ".aspx";
            //modalFilePath += "GC" + this.tableName + ".cs";
            //codeFilePath += this.tableName + ".aspx.cs";
            //blFilePath += "BL" + this.tableName + ".cs";


            // insert Statement


            string insertStatement = String.Format(@"DELETE FROM [{0}] where [{2}]=@{2};INSERT INTO [{1}] (", tableName, tableName, PrimaryKey);
            foreach (var rows in tableColumnList)
            {
                var Colrow = rows as ColumnRow;
                insertStatement += String.Format("[{0}],", Colrow.columnName);
            }

            if (insertStatement.EndsWith(","))
            {
                insertStatement = insertStatement.Substring(0, insertStatement.LastIndexOf(","));
                insertStatement += " )";
            }
            insertStatement += "VALUES (";
            foreach (var rows in tableColumnList)
            {
                var Colrow = rows as ColumnRow;
                insertStatement += String.Format("@{0},", Colrow.columnName);
            }
            if (insertStatement.EndsWith(","))
            {
                insertStatement = insertStatement.Substring(0, insertStatement.LastIndexOf(","));
                insertStatement += " )";
            }

            string FolderPathAspx = saveFolderPath("Select Aspx Folder Path");
            string FolderPathBL = saveFolderPath("Select BL Folder Path",FolderPathAspx);

            try
            {
                if (radioFloating.Checked)
                {
                    fileWriter.CheckDataAndCreateWidget(tableColumnList, widgetCodeList, ModalCodeList, this.tableName);

                }
                else if(radioListItem.Checked)
                {
                    fileWriter.CheckDataAndCreateWidgetListItemForm(tableColumnList, widgetCodeList, ModalCodeList, this.tableName);
                }
                else if (radioGroup.Checked)
                {
                    fileWriter.CheckDataAndCreateWidgetInputGroup(tableColumnList, widgetCodeList, ModalCodeList, this.tableName);

                }
                else
                {
                    fileWriter.CheckDataAndCreateWidgetOutline(tableColumnList, widgetCodeList, ModalCodeList, this.tableName);

                }
                aspxFilePath = FolderPathAspx + "/" + tableName + ".aspx";
                codeFilePath = aspxFilePath +".cs";
                BLFilePath = FolderPathBL + "/BL" + tableName + ".cs";
                GCFilePath = FolderPathBL + "/GC" + tableName + ".cs";

                fileWriter.writeAspxPage(aspxFilePath, widgetCodeList,10, RepeaterColumnList, tableName, PrimaryKey);
                fileWriter.writeModalFile(GCFilePath, ModalCodeList, tableName);
                fileWriter.writeCodePage(codeFilePath, ModalCodeList, tableName, tableColumnList, PrimaryKey);
                fileWriter.WriteBLPage(BLFilePath, tableName, PrimaryKey, insertStatement, tableColumnList);
                fileUploadList.Controls.Clear();
                ddlList.Controls.Clear();
                System.Windows.Forms.MessageBox.Show("Files Generated");
                System.Diagnostics.Process.Start("explorer.exe", FolderPathAspx);
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }


        }
        private void Save() {      
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();      
                
            saveFileDialog1.Title = "Save BL And Modal Files";      
              
            saveFileDialog1.DefaultExt = "cs";      
            saveFileDialog1.Filter = "CS files (*.cs)|*.cs";      
            saveFileDialog1.FilterIndex = 2;      
            saveFileDialog1.RestoreDirectory = true;      
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                BLFilePath = saveFileDialog1.FileName;
                GCFilePath = BLFilePath.Substring(0, BLFilePath.LastIndexOf("/"))+"GC" + tableName + ".cs";
                System.Windows.Forms.MessageBox.Show(GCFilePath);

             }      
}

        public String saveFolderPath(string title)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string FolderPath = "";
            dialog.Description = title.ToString();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FolderPath = dialog.SelectedPath;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Operation Canceled");
            }

            return  FolderPath;
            
        }
        public String saveFolderPath(string title,string rootFolder)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string FolderPath = "";
            dialog.Description = title.ToString();
            dialog.SelectedPath = rootFolder;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FolderPath = dialog.SelectedPath;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Operation Canceled");
            }

            return FolderPath;

        }
        private void SaveAspx()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Save Aspx Files";

            saveFileDialog1.DefaultExt = "aspx";
            saveFileDialog1.Filter = "All files (*.aspx)|*.";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                aspxFilePath = saveFileDialog1.FileName;
                codeFilePath = aspxFilePath.Substring(0, aspxFilePath.LastIndexOf(".")) +".cs";
                System.Windows.Forms.MessageBox.Show(codeFilePath);
                
            }
        } 


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            HandleSumbitClick();
            columnList.Items.Clear();
            primaryList.Items.Clear();
            requiredList.Items.Clear();
            repeaterList.Items.Clear();
            fileUploadList.Items.Clear();
            ddlList.Items.Clear();
            tableColumnList.Clear();
            widgetCodeList.Clear();
            RepeaterColumnList.Clear();
            primaryCount = 0;
            ModalCodeList.Clear();
            //Save();
           
          
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i <columnList.Items.Count; i++)
            {
               
                bool item=columnList.GetItemChecked(i);
                if (item)
                {
                    columnList.SetItemChecked(i, false);
                }
                else
                {
                    columnList.SetItemChecked(i, true);

                }
               
               

            }
        }

        private void chkRptItems_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < repeaterList.Items.Count; i++)
            {

                bool item = repeaterList.GetItemChecked(i);
                if (item)
                {
                    repeaterList.SetItemChecked(i, false);
                }
                else
                {
                    repeaterList.SetItemChecked(i, true);

                }



            }
        }
    }
}
