using System;

using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ColumnRow
/// </summary>
public class ColumnRow
{
	public ColumnRow()
	{
	
	}
    public string columnName { get; set; }
    public string DataType { get; set; }
    public string columnLength { get; set; }
    public string widgetId { get; set; }

    public bool isPrimaryKey { get; set; }
    public bool isRequired { get; set; }

    public bool isFileUpload { get; set; }

    public bool isDropdownList { get; set; }


    public string getColumnDataType()
    {
        if (columnLength.Equals("") || columnLength == null)
        {
            return DataType;
        }
        else
        {
            if (Convert.ToInt32(columnLength) == -1)
            {
                return DataType + " (MAX) " + "";
            }
            else
            {
                return DataType + "(" +columnLength + ")";
            }
        }
        }
    public int  GetColumnlength()
    {
        if(this.columnLength== null || this.columnLength == "")
        {
            return 5;
        }
        
           return Convert.ToInt32(this.columnLength);
        
    }
    public string getValidatorName()
    {
        return "val_" + columnName;
    }

    public bool isMax()
    {
        if (columnLength == null || columnLength.ToString()=="")
        {
            return false;
        }
        if (Convert.ToInt32(columnLength.ToString()) == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    }
