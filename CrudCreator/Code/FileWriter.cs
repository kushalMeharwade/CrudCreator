using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileWriter
{
    public void CheckDataAndCreateWidgetListItemForm(ArrayList list, ArrayList WidgetList, ArrayList modalCodeList, string tableName)
    {
        string widgetCode;
        string gcCode;
        string lbl_code = "<div class=\"list-group\" >" +
            "<div class=\"list-group-item\" >" +

            "<div class=\"row mb-4\">\n" +
                         "<div class=\"col-md-4\">\n" +
                         "<asp:Label ID=\"lblCode\" runat=\"server\" Text=\"\" Visible=\"False\" ></asp:Label>";
        lbl_code += String.Format("</div>\n");
        lbl_code += String.Format("</div>\n");
        lbl_code += String.Format("</div>\n");
        WidgetList.Add(lbl_code);
        foreach (var sublist in list)
        {

            ColumnRow row = sublist as ColumnRow;
            if (row.isPrimaryKey)
            {

                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                modalCodeList.Add(gcCode);

                continue;
            }
            else if (row.isDropdownList)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class=""list-group-item"">
                {1}
                <asp:DropDownList ID=""{0}"" runat=""server"" CssClass=""form-select form-select-sm border-1  border-dark-secondary text-dark"" ></asp:DropDownList>
              
                </div>


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);


            }
            else if (row.isFileUpload)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class='list-group-item'>
                {1}
                <asp:FileUpload ID=""{0}"" CssClass=""form-control form-control-sm border-1 border-dark-secondary text-dark"" runat=""server"" />
                </div>
                 


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);

            }
            else
            {

                switch (row.DataType)
                {
                    case "smallint":
                    case "bigint":
                    case "int":
                    case "money":
                    case "numeric":
                    case "bit":
                        widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                  
                                                   "{2}\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"Number\"  CssClass=\"form-control form-control-sm\" ></asp:TextBox> \n",
                            row.widgetId, row.columnName, row.columnName);

                        if (row.isRequired)
                        {
                           

                            widgetCode += String.Format(
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }
                      
                       

                        widgetCode += String.Format("</div>\n");

                        gcCode = "public int " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "char":
                    case "nchar":
                    case "ntext":
                    case "nvarchar":
                    case "varchar":
                    case "text":

                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                     
                                                       "{1}\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  CssClass=\"form-control form-control-sm\"  ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                      
                                                       "{1}\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }


                        if (row.isRequired)
                        { 

                            widgetCode += String.Format(
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                      

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "date":
                        widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                   
                                                   
                                                   "{1}\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                        " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                        "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                        " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                        row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                       

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "datetime":
                    case "datetime2":
                    case "smalldatetime":
                        widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                 
                                                   "{1}\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                       " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                       "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                       " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                        "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                       row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                    

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;
                    case "image":
                        widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                  
  								   "{1}\n" +
                                   "<asp:FileUpload ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\"/ >\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                          


                            widgetCode += String.Format(
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }
                      

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    default:
                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                   
                                                       "<label for=\"{0}\">{1}</label>\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"list-group-item\">" +
                                                      
                                                       "<label for=\"{0}\">{1}</label>\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }


                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {


                            widgetCode += "";


                        }
                       

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;

                }
            }

        }
        string btn_code = String.Format("" +
            "<div class=\"row\">\n" +
            "<div class=\"col-md-3  \"></div>\n" +
            "<div class=\"col-md-6\" >\n" +
            "" +
            "<div class=\"row\">\n" +
                          "<div class=\"col-md-6  \">" +
                          " <asp:Button ID=\"btnClear\" CssClass=\"btn btn-sm btn-outline-danger w-100 mb-2\" runat=\"server\" Text=\"Clear\" onclick=\"btnClear_Click1\"/>" +

                          "</div>\n" +
                          "<div class=\"col-md-6\">" +
                          " <asp:Button ID=\"btnSubmit\" ValidationGroup=\"{0}\" OnClick=\"btnSave_OnClick\" CausesValidation=\"True\" runat=\"server\" Text=\"submit\" CssClass=\"btn btn-sm btn-outline-primary mb-2 w-100\"  />", tableName);
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("<div class=\"col-md-3\"></div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");

        WidgetList.Add(btn_code);
    }

    public void CheckDataAndCreateWidgetInputGroup(ArrayList list, ArrayList WidgetList, ArrayList modalCodeList, string tableName)
    {
        string widgetCode;
        string gcCode;
        string lbl_code = "<div class=\"list-group\" >" +
            "<div class=\"list-group-item\" >" +

            "<div class=\"row mb-4\">\n" +
                         "<div class=\"col-md-4\">\n" +
                         "<asp:Label ID=\"lblCode\" runat=\"server\" Text=\"\" Visible=\"False\" ></asp:Label>";
        lbl_code += String.Format("</div>\n");
        lbl_code += String.Format("</div>\n");
        
        WidgetList.Add(lbl_code);
        foreach (var sublist in list)
        {

            ColumnRow row = sublist as ColumnRow;
            if (row.isPrimaryKey)
            {

                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                modalCodeList.Add(gcCode);

                continue;
            }
            else if (row.isDropdownList)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class=""input-group input-group-sm"">
                <span class='input-group-text'>{1}</span>
                <asp:DropDownList ID=""{0}"" runat=""server"" CssClass=""form-select form-select-sm border-1  border-dark-secondary text-dark"" ></asp:DropDownList>
              
                </div>


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);


            }
            else if (row.isFileUpload)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                {1}
                <asp:FileUpload ID=""{0}"" CssClass=""form-control form-control-sm border-1 border-dark-secondary text-dark"" runat=""server"" />
                
                 


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);

            }
            else
            {

                switch (row.DataType)
                {
                    case "smallint":
                    case "bigint":
                    case "int":
                    case "money":
                    case "numeric":
                    case "bit":
                        widgetCode = String.Format("<div class=\"input-group  input-group-sm mb-3\">" +

                                                   "<span class=\"input-group-text\">{2}</span>\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"Number\"  CssClass=\"form-control form-control-sm form-control form-control-sm-sm\" ></asp:TextBox> \n",
                            row.widgetId, row.columnName, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                           " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                           "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                           row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }



                        widgetCode += String.Format("</div>\n");

                        gcCode = "public int " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "char":
                    case "nchar":
                    case "ntext":
                    case "nvarchar":
                    case "varchar":
                    case "text":

                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"input-group input-group-sm mb-3\">" +

                                                       "<span class=\"input-group-text\">{1}</span>\n \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  CssClass=\"form-control  form-control-sm\"  ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"input-group input-group-sm mb-3\">" +

                                                       "<span class=\"input-group-text\">{1}</span>\n \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }


                        if (row.isRequired)
                        {
                          

                            widgetCode += String.Format(
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }



                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "date":
                        widgetCode = String.Format("<div class=\"input-group input-group-sm mb-3\">" +


                                                   "<span class=\"input-group-text\">{1}</span>\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                         " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                         "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                           
                        }
                        else
                        {
                            widgetCode += "";

                        }



                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "datetime":
                    case "datetime2":
                    case "smalldatetime":
                        widgetCode = String.Format("<div class=\"input-group input-group-sm mb-3\">" +

                                                   "<span class=\"input-group-text\">{1}</span>\n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\"  CssClass=\"form-control form-control-sm\" ></asp:TextBox>",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                         " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                         "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }



                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;
                    case "image":
                        widgetCode = String.Format("<div class=\"input-group mb-3\">" +

                                                    "<span class=\"input-group-text\">{1}</span>\n" +
                                                   "<asp:FileUpload ID=\"{0}\" runat=\"server\"   CssClass=\"form-control form-control-sm\"/ >\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }


                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    default:
                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"input-group mb-3\">" +

                                                       "<span class=\"input-group-text\">{1}</span>\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"input-group mb-3\">" +

                                                       "<span class=\"input-group-text\">{1}</span>\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }


                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                            " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                            "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                            row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {


                            widgetCode += "";


                        }


                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;

                }
            }

        }
        string btn_code = String.Format("" +
            "<div class=\"row\">\n" +
            "<div class=\"col-md-3  \"></div>\n" +
            "<div class=\"col-md-6\" >\n" +
            "" +
            "<div class=\"row\">\n" +
                          "<div class=\"col-md-6  \">" +
                          " <asp:Button ID=\"btnClear\" CssClass=\"btn btn-sm btn-outline-danger w-100 mb-2\" runat=\"server\" Text=\"Clear\" onclick=\"btnClear_Click1\"/>" +

                          "</div>\n" +
                          "<div class=\"col-md-6\">" +
                          " <asp:Button ID=\"btnSubmit\" ValidationGroup=\"{0}\" OnClick=\"btnSave_OnClick\" CausesValidation=\"True\" runat=\"server\" Text=\"submit\" CssClass=\"btn btn-sm btn-outline-primary mb-2 w-100\"  />", tableName);
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("<div class=\"col-md-3\"></div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");

        WidgetList.Add(btn_code);
    }
    public void CheckDataAndCreateWidget(ArrayList list, ArrayList WidgetList, ArrayList modalCodeList, string tableName)
    {

        string widgetCode;
        string gcCode;

        string lbl_code = "<div class=\"row mb-4\">\n" +
                          "<div class=\"col-md-4\">\n" +
                          "<asp:Label ID=\"lblCode\" runat=\"server\" Text=\"\" Visible=\"False\" ></asp:Label>";
        lbl_code += String.Format("</div>\n");
        lbl_code += String.Format("</div>\n");
        WidgetList.Add(lbl_code);

        foreach (var sublist in list)
        {

            ColumnRow row = sublist as ColumnRow;
            if (row.isPrimaryKey)
            {

                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                modalCodeList.Add(gcCode);

                continue;
            }
          
            else if (row.isDropdownList)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class='row'>
                   <div class='col-md-3'></div>
                   <div class='col-md-6'>
                   {1}
                <asp:DropDownList ID=""{0}"" runat=""server"" CssClass=""form-select form-select-sm border-1  border-dark-secondary text-dark"" ></asp:DropDownList>

                   </div>
                </div>


                    ", row.widgetId,row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);


            }
            else if (row.isFileUpload)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class='row'>
                <div class='col-md-3'></div>
                <div class='col-md-6'>
                {1}
                <asp:FileUpload ID=""{0}"" CssClass=""form-control form-control-sm border-1 border-dark-secondary text-dark"" runat=""server"" />

                </div>
                </div>
              
                
                 


                    ", row.widgetId,row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);

            }
            else
            {

                switch (row.DataType)
                {
                    case "smallint":
                    case "bigint":
                    case "int":
                    case "money":
                    case "numeric":
                    case "bit":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"form-floating\"> \n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"Number\" placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox> \n",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                             " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                             "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                             row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else {
                            widgetCode += "";

                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");

                        gcCode = "public int " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "char":
                    case "nchar":
                    case "ntext":
                    case "nvarchar":
                    case "varchar":
                    case "text":

                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"form-floating\"> \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\" placeholder=\"{1}\" CssClass=\"form-control form-control-sm\"  ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"form-floating\">\n " +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }

                        widgetCode += String.Format("<label for=\"{0}\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                           " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                           "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                           row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "date":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"form-floating\"> \n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\">{1}</label>", row.widgetId, row.GetColumnlength());
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                        " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                        "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                        " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                        row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "datetime":
                    case "datetime2":
                    case "smalldatetime":
                        widgetCode = String.Format("<div class=\"row\">" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >" +
                                                   "<div class=\"form-floating\"> " +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\">{1}</label>", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                         " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                         "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>" +
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;
                    case "image":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"form-floating\">\n " +
                                                   "<asp:FileUpload ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\"/ >\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    default:
                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"form-floating\"> \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"form-floating\">\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\"{1}\" CssClass=\"form-control form-control-sm\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }

                        widgetCode += String.Format("<label for=\"{0}\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {


                            widgetCode += "";


                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;

                }
            }

        }
        string btn_code = String.Format("" +
             "<div class=\"row\">\n" +
             "<div class=\"col-md-3  \"></div>\n" +
             "<div class=\"col-md-6\" >\n" +
             "" +
             "<div class=\"row\">\n" +
                           "<div class=\"col-md-6  \">" +
                           " <asp:Button ID=\"btnClear\" CssClass=\"btn btn-sm btn-outline-danger w-100 mb-2\" runat=\"server\" Text=\"Clear\" onclick=\"btnClear_Click1\"/>" +

                           "</div>\n" +
                           "<div class=\"col-md-6\">" +
                           " <asp:Button ID=\"btnSubmit\" ValidationGroup=\"{0}\" OnClick=\"btnSave_OnClick\" CausesValidation=\"True\" runat=\"server\" Text=\"submit\" CssClass=\"btn btn-sm btn-outline-primary mb-2 w-100\"  />", tableName);
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("<div class=\"col-md-3\"></div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        WidgetList.Add(btn_code);






    }


    public void CheckDataAndCreateWidgetOutline(ArrayList list, ArrayList WidgetList, ArrayList modalCodeList, string tableName)
    {

        string widgetCode;
        string gcCode;

        string lbl_code = "<div class=\"row mb-4\">\n" +
                          "<div class=\"col-md-4\">\n" +
                          "<asp:Label ID=\"lblCode\" runat=\"server\" Text=\"\" Visible=\"False\" ></asp:Label>";
        lbl_code += String.Format("</div>\n");
        lbl_code += String.Format("</div>\n");
        WidgetList.Add(lbl_code);

        foreach (var sublist in list)
        {

            ColumnRow row = sublist as ColumnRow;
            if (row.isPrimaryKey)
            {

                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                modalCodeList.Add(gcCode);

                continue;
            }
            else if (row.isDropdownList)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class='row'>
                <div class='col-md-3'></div>
                <div class='col-md-6'>
                {1}
                <asp:DropDownList ID=""{0}"" runat=""server"" CssClass=""form-select form-select-sm border-1  border-dark-secondary text-dark"" ></asp:DropDownList>
                </div>
             


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);


            }
            else if (row.isFileUpload)
            {
                gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                string widget_code = String.Format(@"
                <div class='row'>
                <div class='col-md-3'></div>
                <div class='col-md-6'>
                {1}
                <asp:FileUpload ID=""{0}"" CssClass=""form-control form-control-sm border-1 border-dark-secondary text-dark"" runat=""server"" />

                </div>
               
                
                 


                    ", row.widgetId, row.columnName);
                WidgetList.Add(widget_code);
                modalCodeList.Add(gcCode);

            }
            else
            {

                switch (row.DataType)
                {
                    case "smallint":
                    case "bigint":
                    case "int":
                    case "money":
                    case "numeric":
                    case "bit":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"material-textfield\"> \n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\" placeholder=\" \"  TextMode=\"Number\"  CssClass=\"form-control\" ></asp:TextBox> \n",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\" class=\"material\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");

                        gcCode = "public int " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "char":
                    case "nchar":
                    case "ntext":
                    case "nvarchar":
                    case "varchar":
                    case "text":

                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"material-textfield\"> \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\" \" TextMode=\"MultiLine\"  CssClass=\"form-control \"  ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"material-textfield\">\n " +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\" \"   CssClass=\"form-control \" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }

                        widgetCode += String.Format("<label for=\"{0}\" class=\"material\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                         "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "date":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"material-textfield\"> \n" +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\" \"   CssClass=\"form-control\" ></asp:TextBox>\n",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\" class=\"material\">{1}</label>", row.widgetId, row.GetColumnlength());
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                         " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                         "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                         " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                         row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    case "datetime":
                    case "datetime2":
                    case "smalldatetime":
                        widgetCode = String.Format("<div class=\"row\">" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >" +
                                                   "<div class=\"material-textfield\"> " +
                                                   "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\" \"   CssClass=\"form-control\" ></asp:TextBox>",
                            row.widgetId, row.columnName);
                        widgetCode += String.Format("<label for=\"{0}\" class=\"material\">{1}</label>", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(

                       " <asp:CalendarExtender ID=\"CalendarExtender{0}\" runat=\"server\" Format=\"dd-MM-yyyy\" TargetControlID=\"{2}\"></asp:CalendarExtender>\n" +

                       "<asp:FilteredTextBoxExtender ID=\"FilteredTextBoxExtender_{0}\" runat=\"server\" FilterType=\"Numbers, Custom\"    ValidChars=\"-\" TargetControlID=\"{2}\"></asp:FilteredTextBoxExtender>\n" +
                       " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                        "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                       row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }

                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public DateTime " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;
                    case "image":
                        widgetCode = String.Format("<div class=\"row\">\n" +
                                                   "<div class=\"col-md-3  \"></div>\n" +
                                                   "<div class=\"col-md-6\" >\n" +
                                                   "<div class=\"material-textfield\">\n " +
                                                   "<asp:FileUpload ID=\"{0}\" runat=\"server\"   placeholder=\" \" CssClass=\"form-control \"/ >\n",
                            row.widgetId, row.columnName);

                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                          " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                          "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                          row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {
                            widgetCode += "";

                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);
                        break;
                    default:
                        if (row.isMax())
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"material-textfield\"> \n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\" TextMode=\"MultiLine\"  placeholder=\" \"  CssClass=\"form-control  form-control-sm\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName);
                        }
                        else
                        {
                            widgetCode = String.Format("<div class=\"row\">\n" +
                                                       "<div class=\"col-md-3  \"></div>\n" +
                                                       "<div class=\"col-md-6\" >\n" +
                                                       "<div class=\"material-textfield\">\n" +
                                                       "<asp:TextBox ID=\"{0}\" runat=\"server\"  placeholder=\" \"  CssClass=\"form-control\" MaxLength=\"{2}\" ></asp:TextBox>\n",
                                row.widgetId, row.columnName, row.GetColumnlength());
                        }

                        widgetCode += String.Format("<label for=\"{0}\" class=\"material\">{1}</label>\n", row.widgetId, row.columnName);
                        if (row.isRequired)
                        {
                            widgetCode += String.Format(
                           " <asp:RequiredFieldValidator ID=\"{0}\" SetFocusOnError=\"true\" Display=\"None\" runat=\"server\" ErrorMessage=\"Please Fill {1}\" ControlToValidate=\"{2}\" CssClass=\"text-danger\" ValidationGroup=\"{3}\"></asp:RequiredFieldValidator>\n" +

                           "<asp:ValidatorCalloutExtender ID=\"Extender_{0}\" runat=\"server\" TargetControlID=\"{0}\"></asp:ValidatorCalloutExtender>\n",
                           row.getValidatorName(), row.columnName, row.widgetId, tableName);
                        }
                        else
                        {


                            widgetCode += "";


                        }
                        widgetCode += String.Format("</div>\n");
                        widgetCode += String.Format("</div>\n");

                        widgetCode += String.Format("</div>\n");
                        gcCode = "public string " + row.columnName.Trim().ToString() + " {get;set;}\n";
                        modalCodeList.Add(gcCode);
                        WidgetList.Add(widgetCode);

                        break;

                }
            }

        }
        string btn_code = String.Format("" +
             "<div class=\"row\">\n" +
             "<div class=\"col-md-3  \"></div>\n" +
             "<div class=\"col-md-6\" >\n" +
             "" +
             "<div class=\"row\">\n" +
                           "<div class=\"col-md-6  \">" +
                           " <asp:Button ID=\"btnClear\" CssClass=\"btn btn-sm btn-outline-danger w-100 mb-2\" runat=\"server\" Text=\"Clear\" onclick=\"btnClear_Click1\"/>" +

                           "</div>\n" +
                           "<div class=\"col-md-6\">" +
                           " <asp:Button ID=\"btnSubmit\" ValidationGroup=\"{0}\" OnClick=\"btnSave_OnClick\" CausesValidation=\"True\" runat=\"server\" Text=\"submit\" CssClass=\"btn btn-sm btn-outline-primary mb-2 w-100\"  />", tableName);
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("<div class=\"col-md-3\"></div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
        btn_code += String.Format("</div>\n");
    }
    public void DeleteIFExists(string filepath)
    {
        FileInfo newFile = new FileInfo(filepath);


        if (newFile.Exists)
        {

            newFile.Delete();

        }
    }

    public void createHtmlReport(string[] tableColumn, string tableName, string aspxFilename)

    {
        DeleteIFExists(aspxFilename);
        if (!File.Exists(aspxFilename))
        {
            using (StreamWriter writer = File.CreateText(aspxFilename))
            {
                writer.WriteLine(String.Format("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"{0}.aspx.cs\" Inherits=\"{0}\" %>", tableName));
                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                writer.WriteLine("<head runat=\"server\">");
                writer.WriteLine("<title></title>");
                writer.WriteLine("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.1/css/bootstrap.min.css\" integrity=\"sha512-Ez0cGzNzHR1tYAv56860NLspgUGuQw16GiOOp/I2LuTmpSK9xDXlgJz3XN4cnpXWDmkNBKXR/VDMTCnAaEooxA==\" crossorigin=\"anonymous\" referrerpolicy=\"no-referrer\" />");
                writer.WriteLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.0.1/js/bootstrap.min.js\" integrity=\"sha512-EKWWs1ZcA2ZY9lbLISPz8aGR2+L7JVYqBAYTq5AXgBkSjRSuQEGqWx8R1zAX16KdXPaCjOCaKE8MCpU0wcHlHA==\" crossorigin=\"anonymous\" referrerpolicy=\"no-referrer\"></script>");
                writer.WriteLine("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css\" integrity=\"sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==\" crossorigin=\"anonymous\" referrerpolicy=\"no-referrer\" />");


                writer.WriteLine("<style>");
                writer.WriteLine(" *{");
                writer.WriteLine(" -webkit-print-color-adjust: exact !important;");

                writer.WriteLine(" }");
                writer.WriteLine(" body{");
                writer.WriteLine("  background: rgb(204,204,204);");
                writer.WriteLine("  }");
                writer.WriteLine("  page {");
                writer.WriteLine(" background: white;");

                writer.WriteLine("display: block;");
                writer.WriteLine("margin: 0 auto;");
                writer.WriteLine("margin-bottom: 0.5cm;");
                writer.WriteLine(" }");


                writer.WriteLine("page[size=\"A4\"] {");
                writer.WriteLine(" width: 21cm;");
                writer.WriteLine(" padding: 5px;");
                writer.WriteLine(" }");



                writer.WriteLine(" page[size=\"A4\"][layout=\"landscape\"] {");
                writer.WriteLine(" width: 29.7cm;");
                writer.WriteLine(" height: 21cm;");
                writer.WriteLine(" }");



                writer.WriteLine("page[size=\"A3\"] {");
                writer.WriteLine(" width: 29.7cm;");
                writer.WriteLine("height: 42cm;");
                writer.WriteLine(" }");

                writer.WriteLine("page[size=\"A3\"][layout=\"landscape\"] {");
                writer.WriteLine(" width: 42cm;");
                writer.WriteLine(" height: 29.7cm;");
                writer.WriteLine(" }");

                writer.WriteLine(" page[size=\"A5\"] {");

                writer.WriteLine(" width: 14.8cm;");
                writer.WriteLine(" height: 21cm;");
                writer.WriteLine("}");
                writer.WriteLine("th::first-letter{");
                writer.WriteLine("	text-transform:uppercase;");

                writer.WriteLine("}");

                writer.WriteLine("th{");
                writer.WriteLine("text-align:center;");
                writer.WriteLine("}");

                writer.WriteLine(" page[size=\"A5\"][layout=\"landscape\"] {");
                writer.WriteLine("width: 21cm;");
                writer.WriteLine("height: 14.8cm;");
                writer.WriteLine(" }");


                writer.WriteLine("@media print {");

                writer.WriteLine(" *{");

                writer.WriteLine(" -webkit-print-color-adjust: exact !important;");
                writer.WriteLine("  }");
                writer.WriteLine(" .title{");
                writer.WriteLine(" font-family: 'Open Sans', sans-serif;");
                writer.WriteLine("  }");
                writer.WriteLine(" @page {");
                writer.WriteLine("   size: A4;");

                writer.WriteLine(" }");
                writer.WriteLine(".no-print {");
                writer.WriteLine("  display: block !important;");
                writer.WriteLine("}");
                writer.WriteLine(" thead,tfoot{");
                writer.WriteLine("  background-color: #f9f9f9;");
                writer.WriteLine("  color: #000;");
                writer.WriteLine("}");
                writer.WriteLine(".row{");
                writer.WriteLine("  align-items:center;");
                writer.WriteLine(" }");
                writer.WriteLine(" }");
                writer.WriteLine(" </style>");
                writer.WriteLine("</head>");

                writer.WriteLine("<body>");
                writer.WriteLine("<form id=\"form\" runat=\"server\">");
                writer.WriteLine("<page size=\"A4\">");
                writer.WriteLine("<div class=\"row\">");
                writer.WriteLine("<div class=\"col-md-12\">");

                writer.WriteLine("<asp:Repeater ID=\"rptList\" runat=\"server\">");
                writer.WriteLine("\t <HeaderTemplate>");
                writer.WriteLine("\t\t <table id=\"listTable\" class=\"table table-hover table-striped\" >");
                writer.WriteLine("<thead>");
                writer.WriteLine("<tr>");

                for (int i = 0; i < tableColumn.Length; i++)
                {

                    writer.WriteLine(String.Format("<th>{0}</th>", tableColumn[i]));


                }

                writer.WriteLine("</tr>");
                writer.WriteLine("</thead>");
                writer.WriteLine("<tbody>");


                writer.WriteLine("\t </HeaderTemplate>");
                writer.WriteLine("\t <ItemTemplate>");

                writer.WriteLine("<tr>");


                for (int i = 0; i < tableColumn.Length; i++)
                {

                    writer.WriteLine(String.Format("<td><%#Eval(\"{0}\")%></td>", tableColumn[i]));


                }


                writer.WriteLine("</tr>");

                writer.WriteLine("\t</ItemTemplate>");
                writer.WriteLine(" <FooterTemplate>");
                writer.WriteLine("</tbody>");
                writer.WriteLine("</table");
                writer.WriteLine(" </FooterTemplate>");

                writer.WriteLine("</asp:Repeater>");


















                writer.WriteLine("</div>");
                writer.WriteLine("</div>");







                writer.WriteLine("</page>");
                writer.WriteLine("</form>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");






            }
        }

    }

    public void createHtmlReportCodeFile(string query, string codeFile, string tableName)
    {
        DeleteIFExists(codeFile);
        if (!File.Exists(codeFile))
        {
            using (StreamWriter writer = File.CreateText(codeFile))
            {
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Web;");
                writer.WriteLine("using System.Web.UI;");
                writer.WriteLine("using System.Web.UI.WebControls;");
                writer.WriteLine("using System.Data;");
                writer.WriteLine("using System.Data.SqlClient;");
               


                writer.WriteLine(String.Format("public partial class {0} : System.Web.UI.Page", tableName));
                writer.WriteLine("{");

                writer.WriteLine(" DataLayer  DL = new DataLayer();");
                writer.WriteLine("protected void Page_Load(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("if (!Page.IsPostBack)");
                writer.WriteLine("{");

                writer.WriteLine(String.Format("Rpt{0}Adapter(rptList);", tableName));

                writer.WriteLine("}");



                writer.WriteLine(String.Format("void Rpt{0}Adapter(Repeater list)", tableName, tableName));
                writer.WriteLine("{");
                writer.WriteLine(String.Format(" \tstring qry =\"{0}\";",query));
                writer.WriteLine("\tDataTable dt = new DataTable();");
                writer.WriteLine("\tSqlCommand cmd = new SqlCommand();");
                writer.WriteLine("\tcmd.CommandText = qry;");
                writer.WriteLine("\tdt = DL.GetDataTable(cmd);");
                writer.WriteLine("\tlist.DataSource = dt;");
                writer.WriteLine(" \tlist.DataBind();");
                writer.WriteLine("}");

                writer.WriteLine("}");
                writer.WriteLine("}");

            }



        }
    } 


          public void writeModalFile(string filePath, ArrayList modalCode, string tableName)
          {
        DeleteIFExists(filePath);
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Activities.Expressions;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Data.Common;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Web;");


                writer.WriteLine(String.Format("public class _GC{0}", tableName));
                writer.WriteLine("{");



                for (var i = 0; i < modalCode.Count; i++)
                {


                    writer.Write(modalCode[i].ToString());
                }

                writer.WriteLine("}");
                writer.Close();
            }
        }




    }

    public void writeCodePage(string filepath, ArrayList modalList, string tableName, ArrayList TableColumnRows, string primaryKey)
    {
        DeleteIFExists(filepath);
        if (!File.Exists(filepath))
        {
            using (StreamWriter writer = File.CreateText(filepath))
            {
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Web;");
                writer.WriteLine("using System.Web.UI;");
                writer.WriteLine("using System.Web.UI.WebControls;");


                writer.WriteLine(String.Format("public partial class {0} : System.Web.UI.Page", tableName));
                writer.WriteLine("{");

                writer.WriteLine(String.Format("_BL{0} BL=new _BL{0}();", tableName));
                writer.WriteLine(String.Format("_GC{0} GC=new _GC{0}();", tableName));
                writer.WriteLine("protected void Page_Load(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("if (!Page.IsPostBack)");
                writer.WriteLine("{");

                writer.WriteLine(String.Format("BL.Rpt{0}Adapter(rptList);", tableName));

                writer.WriteLine("}");
                writer.WriteLine("}");

                writer.WriteLine("  protected void Clear()");
                writer.WriteLine("{");
                foreach (var row in TableColumnRows)
                {
                    ColumnRow Colrow = row as ColumnRow;

                    if (!Colrow.isPrimaryKey && !Colrow.isDropdownList && !Colrow.isFileUpload)
                        writer.WriteLine(String.Format("{0}.Text=\"\";", Colrow.widgetId));

                }



                writer.WriteLine("}");
                writer.WriteLine("\n\n");
                writer.WriteLine(" protected void btnClear_Click1(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("Clear();"); 




                writer.WriteLine("}");
                writer.WriteLine("\n\n");
                writer.WriteLine(@"

                      string UploadDocument(FileUpload file,string path)
                    {
                     string fileName = """";
                     string DocumentRootPath = """";
                     try
                        {
                             if (file.HasFile)
                             {
                                 Random randomNumber = new Random();
                                 Guid newGuid = Guid.NewGuid();
                                 string extension = Path.GetExtension(file.FileName);

                                  fileName = String.Format(""{0}_{1}"", newGuid.ToString(), extension);
                                  if (!Directory.Exists(Server.MapPath(path)))
                                     {
                                         Directory.CreateDirectory(Server.MapPath(path));
                                     }
                              DocumentRootPath = Path.Combine(path, fileName);
                              file.SaveAs(Server.MapPath(DocumentRootPath));
                        }
               
              
                         }catch(Exception ex)
                            {
        
                            }
                        return fileName.ToString();
                      }






                        ");
                writer.WriteLine(" protected void btnSave_OnClick(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("try");
                writer.WriteLine("{");
                writer.WriteLine("if (lblCode.Text == \"\")");
                writer.WriteLine("{");
                writer.WriteLine(String.Format("GC.{0} = BL.Get{1}PrimaryCode();", primaryKey, tableName));


                writer.WriteLine("}");
                writer.WriteLine("else");
                writer.WriteLine("{");
                writer.WriteLine(String.Format("GC.{0} = lblCode.Text;", primaryKey));
                writer.WriteLine("}");

                foreach (var row in TableColumnRows)
                {
                    ColumnRow Colrow = row as ColumnRow;
                    if (Colrow.isDropdownList)
                    {
                        writer.WriteLine(String.Format("GC.{0}={1}.SelectedValue.ToString();", Colrow.columnName, Colrow.widgetId));

                    }
                    else if (Colrow.isFileUpload)
                    {
                        writer.WriteLine(String.Format(@"GC.{0}=UploadDocument({1},@""~\Documents\"");", Colrow.columnName, Colrow.widgetId));

                    }
                    else if (!Colrow.isPrimaryKey)
                    {
                        switch (Colrow.DataType)
                        {
                            case "char":
                            case "nchar":
                            case "ntext":
                            case "nvarchar":
                            case "varchar":
                            case "text":
                                writer.WriteLine(String.Format("GC.{0}={1}.Text.ToString();", Colrow.columnName, Colrow.widgetId));
                                break;
                            case "smallint":
                            case "bigint":
                            case "int":
                            case "money":
                            case "numeric":
                            case "bit":
                                writer.WriteLine(String.Format("GC.{0}= Convert.ToInt32({1}.Text);", Colrow.columnName, Colrow.widgetId));
                                break;
                            case "datetime":
                            case "datetime2":
                            case "smalldatetime":
                                writer.WriteLine(String.Format("GC.{0}= Convert.ToDateTime({1}.Text);", Colrow.columnName, Colrow.widgetId));
                                break;
                            default:
                                writer.WriteLine(String.Format("GC.{0}= {1}.Text;", Colrow.columnName, Colrow.widgetId));
                                break;
                        }
                    }
                   



                }


                writer.WriteLine(String.Format("BL.Save{0}(GC);", tableName));
                writer.WriteLine("Clear();");
                writer.WriteLine(String.Format("BL.Rpt{0}Adapter(rptList);", tableName));
                writer.WriteLine("string alertSuccess = \"AlertSuccess('Inserted Successfully')\";");
                writer.WriteLine("Page.ClientScript.RegisterStartupScript(this.GetType(), \"alert\", alertSuccess, true);");
                writer.WriteLine("}catch(Exception ex)");
                writer.WriteLine("{");
                writer.WriteLine("string alertException = \"AlertError(\" + ex.Message + \")\";");
                writer.WriteLine("Page.ClientScript.RegisterStartupScript(this.GetType(), \"alert\", alertException, true);");
                writer.WriteLine(" Response.Write(\"__________________________________________\");");
                writer.WriteLine(" Response.Write(\"Message: \"+ex.Message + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Source: \" + ex.Source + \" < br > \");");
                writer.WriteLine(" Response.Write(\"PrintStackTrace: \" + ex.StackTrace + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Inner Exception: \"+ex.InnerException + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Exception Data: \" + ex.Data + \" < br > \");");
                writer.WriteLine();


                writer.WriteLine("}");

                writer.WriteLine("}");

                writer.WriteLine("\n\n\n");
                writer.WriteLine("protected void rptDelBtn_OnClick(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("try");
                writer.WriteLine("{");
                string referenceLabelCode = "RepeaterItem item = (sender as Button).Parent as RepeaterItem;\n" +
                                            "Label idLbael = item.FindControl(\"lblId\") as Label;\n" +
                                             "string id = idLbael.Text.ToString();\n" +
                                            "GC." + primaryKey + "=" + "id;\n" +
                                            " BL.Delete" + tableName + "Item(GC);";

                writer.WriteLine(referenceLabelCode);
                writer.WriteLine("string alertSuccess = \"AlertSuccess('Deleted Successfully')\";");
                writer.WriteLine("Page.ClientScript.RegisterStartupScript(this.GetType(), \"alert\", alertSuccess, true);");
                writer.WriteLine(String.Format("BL.Rpt{0}Adapter(rptList);", tableName));





                writer.WriteLine("}");
                writer.WriteLine("catch(Exception ex)");
                writer.WriteLine("{");
                writer.WriteLine("string alertException = \"AlertError(\" + ex.Message + \")\";");
                writer.WriteLine("Page.ClientScript.RegisterStartupScript(this.GetType(), \"alert\", alertException, true);");
                writer.WriteLine(" Response.Write(\"__________________________________________\");");
                writer.WriteLine(" Response.Write(\"Message: \"+ex.Message + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Source: \" + ex.Source + \" < br > \");");
                writer.WriteLine(" Response.Write(\"PrintStackTrace: \" + ex.StackTrace + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Inner Exception: \"+ex.InnerException + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Exception Data: \" + ex.Data + \" < br > \");");
                writer.WriteLine("}");

                writer.WriteLine("}");

                writer.WriteLine(" protected void rptEditbtn_OnClick(object sender, EventArgs e)");
                writer.WriteLine("{");
                writer.WriteLine("try");
                writer.WriteLine("{");
                string editReference = "RepeaterItem item = (sender as Button).Parent as RepeaterItem;\n" +
                                       "Label idLbael = item.FindControl(\"lblId\") as Label;\n" +
                                       "string id = idLbael.Text.ToString();\n" +
                                       "GC." + primaryKey + "=" + "id;\n" +
                                       "BL.Get" + tableName + "(GC);\n";
                writer.WriteLine(editReference);
                foreach (var row in TableColumnRows)
                {
                    ColumnRow Colrow = row as ColumnRow;
                    if (Colrow.isPrimaryKey)
                    {
                        writer.WriteLine(String.Format("lblCode.Text=GC.{0}.ToString();", Colrow.columnName));
                    }
                    else if (Colrow.isDropdownList)
                    {
                        writer.WriteLine(String.Format("{0}.Items.FindByValue(GC.{1}.ToString()).Selected = true;", Colrow.widgetId ,Colrow.columnName));

                    }
                    else if (Colrow.isFileUpload)
                    {

                    }
                    else
                    {
                        writer.WriteLine(String.Format("{0}.Text=GC.{1}.ToString();", Colrow.widgetId, Colrow.columnName));
                    }



                }


                writer.WriteLine("}");
                writer.WriteLine("catch(Exception ex)");
                writer.WriteLine("{");
                writer.WriteLine("string alertException = \"AlertError(\" + ex.Message + \")\";");
                writer.WriteLine("Page.ClientScript.RegisterStartupScript(this.GetType(), \"alert\", alertException, true);");
                writer.WriteLine(" Response.Write(\"__________________________________________\");");
                writer.WriteLine(" Response.Write(\"Message: \"+ex.Message + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Source: \" + ex.Source + \" < br > \");");
                writer.WriteLine(" Response.Write(\"PrintStackTrace: \" + ex.StackTrace + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Inner Exception: \"+ex.InnerException + \" < br > \");");
                writer.WriteLine(" Response.Write(\"Exception Data: \" + ex.Data + \" < br > \");");
                writer.WriteLine("}");

                writer.WriteLine("}");
                writer.WriteLine("}");

                writer.Close();
            }
        }
    }


      public void writeAspxPage(string filepath, ArrayList codeList, int ContainerColumn,ArrayList repeaterList,String tableName,string primaryKey)
        {
            DeleteIFExists(filepath);
            if (!File.Exists(filepath))
            {
                using (StreamWriter writer = File.CreateText(filepath))
                {


                    writer.WriteLine(String.Format(
                        "<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/MasterPage.master\" AutoEventWireup=\"true\" CodeFile=\"{0}.aspx.cs\" Inherits=\"{0}\" %>\n" +
                        "<%@ Register Assembly=\"AjaxControlToolkit\" Namespace=\"AjaxControlToolkit\" TagPrefix=\"asp\" %>",
                        tableName));




                   
                   writer.WriteLine("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" Runat=\"Server\">");
              

                writer.WriteLine(@"
                    <style>
                    .material-textfield 
                    {
                     position: relative;  
                    }
                    label.material {
                position: absolute;
                font-size: 1rem;
                left: 0;
                top: 35%;
                transform: translateY(-50%);
                background-color: white;
                 color: gray;
                 padding: 0 0.3rem;
                 margin: 0 0.5rem;
                transition: .1s ease-out;
                transform-origin: left top;
                pointer-events: none;
                }
.material-textfield>input {
  font-size: 1rem;
  outline: none;
  border: 1px solid gray;
  border-radius: 5px;  
  padding: 1rem 0.7rem;
  color: gray;
  transition: 0.1s ease-out;
}

.material-textfield>input:focus {
  border-color: #6200EE;  
}
.material-textfield>input:focus + label {
  color: #6200EE;
  top: 0;
  transform: translateY(-50%) scale(.9);
}
.material-textfield>input:not(:placeholder-shown) + label {
  top: 0;
  transform: translateY(-50%) scale(.9);
}
                    </style>





");
                    writer.WriteLine("</asp:Content>");
                    writer.WriteLine(
                        "<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"ContentPlaceHolder1\" Runat=\"Server\">");
                writer.WriteLine("<asp:ToolkitScriptManager ID=\"ToolkitScriptManager1\" runat=\"server\"></asp:ToolkitScriptManager>");
                writer.WriteLine("<div class=\"container\">");
                    writer.WriteLine("<div class=\"row mt-3 mb-3\">");
                    writer.WriteLine(String.Format("<div class=\"col-md-1\"></div>"));
                    writer.WriteLine(String.Format("<div class=\"col-md-{0}\">", ContainerColumn));
                    writer.WriteLine("<div class=\"card bg-white\">");
                   
                

                    writer.WriteLine("\n\n");

                    for (var i = 0; i < codeList.Count; i++)
                    {
                        writer.WriteLine(codeList[i].ToString());
                    }
                  
                    writer.WriteLine("</div>");
                    writer.WriteLine("</div>");
                    writer.WriteLine("</div>");
                    writer.WriteLine("\n\n\n");



                    writer.WriteLine("<div class=\"row mt-5\">");

                    writer.WriteLine("<div class=\"col-md-12\" >\n");
                   if(repeaterList.Count >=1)
                {
                    writer.WriteLine("<asp:Repeater ID=\"rptList\" runat=\"server\">");
                    writer.WriteLine("\t <HeaderTemplate>");
                    writer.WriteLine("\t\t <table id=\"listTable\" class=\"table table-hover table-striped\" >");
                    writer.WriteLine("<thead>");
                    writer.WriteLine("<tr>");
                    for (int i = 0; i < repeaterList.Count; i++)
                    {

                        writer.WriteLine(String.Format("<th>{0}</th>", repeaterList[i]));


                    }
                    writer.WriteLine(String.Format("<th>Edit</th>"));
                    writer.WriteLine(String.Format("<th>Delete</th>"));
                    writer.WriteLine("</tr>");
                    writer.WriteLine("</thead>");
                    writer.WriteLine("<tbody>");
                    writer.WriteLine("\t </HeaderTemplate>");
                    writer.WriteLine("\t <ItemTemplate>");

                    writer.WriteLine("<tr>");
                    writer.WriteLine("<asp:Label ID=\"lblId\" Visible=\"False\" runat=\"server\" Text='<%#Eval(\"" + primaryKey + "\")%>'></asp:Label>");
                    for (int i = 0; i < repeaterList.Count; i++)
                    {

                        writer.WriteLine(String.Format("<td><%#Eval(\"{0}\")%></td>", repeaterList[i]));


                    }


                    writer.WriteLine(String.Format("<td> <asp:Button ID=\"rptEdit\" runat=\"server\" onClick=\"rptEditbtn_OnClick\"  CssClass=\"btn btn-secondary\" Text=\"Edit\"/></td>"));
                    writer.WriteLine(String.Format("<td><asp:Button ID=\"rptDelete\" onClick=\"rptDelBtn_OnClick\" OnClientClick=\"return confirm('Are you sure want to delete this?')\" runat=\"server\" CssClass=\"btn btn-danger\" Text=\"Delete\"/></td>"));
                    writer.WriteLine("</tr>");

                    writer.WriteLine("\t </ItemTemplate>");
                    writer.WriteLine(" <FooterTemplate>");
                    writer.WriteLine("</tbody>");
                    writer.WriteLine(" </FooterTemplate>");

                    writer.WriteLine("</asp:Repeater>");
                }








              



                    writer.WriteLine("</div>");
                    writer.WriteLine("</div>");
                    writer.WriteLine("</div>");


                    writer.WriteLine("<script   type=\"text/javascript\" >");
                    writer.WriteLine("$(document).ready( function () {");
                    writer.WriteLine(" $('#listTable').DataTable();");
                    writer.WriteLine("} );");

                    writer.WriteLine("</script>");
                    writer.WriteLine("</asp:Content>");



                    writer.Close();
                }

            }
        }
    


        public     void WriteBLPage(string filePath, string tableName, string primaryKey, string insertStatement, ArrayList TableColumnRows)
            {
                DeleteIFExists(filePath);
                if (!File.Exists(filePath))
                {
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine("using System;");
                        writer.WriteLine("using System.Collections.Generic;");
                        writer.WriteLine("using System.Linq;");
                        writer.WriteLine("using System.Web;");
                        writer.WriteLine("using System.Web.UI;");
                        writer.WriteLine("using System.Data.SqlClient;");
                        writer.WriteLine("using System.Data;");
                        writer.WriteLine("using System.Web.UI.WebControls;");


                        writer.WriteLine(String.Format("public class _BL{0} ", tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(" DataLayer  DL = new DataLayer();");
                        writer.WriteLine(String.Format("public void Save{0}(_GC{1} gc)", tableName, tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(String.Format("string qry=\"{0}\";", insertStatement));

                        writer.WriteLine(" SqlCommand cmd = new SqlCommand();");
                        foreach (var rows in TableColumnRows)
                        {
                            var Colrow = rows as ColumnRow;
                            writer.WriteLine(String.Format("cmd.Parameters.AddWithValue(\"@{0}\", gc.{1});", Colrow.columnName, Colrow.columnName));
                        }

                        writer.WriteLine(" cmd.CommandText = qry;");
                        writer.WriteLine("  DL.ExecuteCMD(cmd);");

                        writer.WriteLine("}");

                        writer.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
                        string selectStatement = String.Format(@"SELECT * FROM [{0}] WHERE [{1}]=@{1}", tableName, primaryKey);
                        writer.WriteLine(String.Format("public void Get{0}(_GC{1} gc)", tableName, tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(String.Format("string qry=\"{0}\";", selectStatement));
                        writer.WriteLine(" SqlCommand cmd = new SqlCommand();");
                        writer.WriteLine(String.Format("cmd.Parameters.AddWithValue(\"@{0}\", gc.{0});", primaryKey));

                        writer.WriteLine(" cmd.CommandText = qry;");
                        writer.WriteLine("SqlDataReader dtrData = (SqlDataReader) (DL.GetReader(cmd));");
                        writer.WriteLine("if (dtrData.Read())");
                        writer.WriteLine("{");
                        foreach (var row in TableColumnRows)
                        {

                            ColumnRow Colrow = row as ColumnRow;
                            if (Colrow.isPrimaryKey)
                            {
                                writer.WriteLine(String.Format("gc.{0}=dtrData[\"{1}\"].ToString();", Colrow.columnName, Colrow.columnName));
                            }
                            else
                            {
                                switch (Colrow.DataType)
                                {
                                    case "char":
                                    case "nchar":
                                    case "ntext":
                                    case "nvarchar":
                                    case "varchar":
                                    case "text":
                                        writer.WriteLine(String.Format("gc.{0}=dtrData[\"{1}\"].ToString();", Colrow.columnName, Colrow.columnName));
                                        break;
                                    case "smallint":
                                    case "bigint":
                                    case "int":
                                    case "money":
                                    case "numeric":
                                    case "bit":
                                        writer.WriteLine(String.Format("gc.{0}= Convert.ToInt32(dtrData[\"{1}\"]);", Colrow.columnName, Colrow.columnName));
                                        break;
                                    case "datetime":
                                    case "datetime2":
                                    case "smalldatetime":
                                    case "date":
                                        writer.WriteLine(String.Format("gc.{0}= Convert.ToDateTime(dtrData[\"{1}\"]);", Colrow.columnName, Colrow.columnName));
                                        break;
                                    default:
                                        writer.WriteLine(String.Format("gc.{0}= dtrData[\"{1}\"];", Colrow.columnName, Colrow.columnName));
                                        break;
                                }

                            }


                        }
                        writer.WriteLine("}");

                        writer.WriteLine("}");
                        writer.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
                        writer.WriteLine(String.Format("public void Rpt{0}Adapter(Repeater list)", tableName, tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(String.Format(" \tstring qry = @\"SELECT * from [{0}] order by {1} \";", tableName, primaryKey));
                        writer.WriteLine("\tDataTable dt = new DataTable();");
                        writer.WriteLine("\tSqlCommand cmd = new SqlCommand();");
                        writer.WriteLine("\tcmd.CommandText = qry;");
                        writer.WriteLine("\tdt = DL.GetDataTable(cmd);");
                        writer.WriteLine("\tlist.DataSource = dt;");
                        writer.WriteLine(" \tlist.DataBind();");
                        writer.WriteLine("}");
                        writer.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");


                 


                writer.WriteLine(String.Format("public string Get{0}PrimaryCode()", tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(" string result = \"\";");
                        writer.WriteLine(String.Format("string qry = \"select isnull(max(convert(int,[{0}])),0)+1 from [{1}]\";", primaryKey, tableName));
                        writer.WriteLine(" SqlCommand cmd = new SqlCommand();");
                        writer.WriteLine("  cmd.CommandText = qry;");
                        writer.WriteLine("SqlDataReader dtrData = (SqlDataReader)(DL.GetReader(cmd));");
                        writer.WriteLine("if (dtrData.Read())");
                        writer.WriteLine("{");
                        writer.WriteLine("result = dtrData[\"\"].ToString();");
                        writer.WriteLine("}");
                        writer.WriteLine("return result;");

                        writer.WriteLine("}");

                        writer.WriteLine(String.Format("public void Delete{0}Item(_GC{1} gc)", tableName, tableName));
                        writer.WriteLine("{");
                        writer.WriteLine(String.Format("string query =\"DELETE FROM [{0}] WHERE [{1}]=@{1};\";", tableName, primaryKey));
                        writer.WriteLine(" SqlCommand cmd = new SqlCommand();");
                        writer.WriteLine(String.Format("cmd.Parameters.AddWithValue(\"@{0}\", gc.{0});", primaryKey));
                        writer.WriteLine("cmd.CommandText = query;");
                        writer.WriteLine(" DL.ExecuteCMD(cmd);");
                        writer.WriteLine("}");






                        writer.WriteLine("}");
                        writer.Close();
                    }


                }


            }

        }

    
