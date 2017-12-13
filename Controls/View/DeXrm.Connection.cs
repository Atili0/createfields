using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Xrm.Sdk.Metadata;

namespace DeXrm.CreateField.Controls.View
{
    public partial class DeXrm
    {
        #region Variables
        private ILController _controller;
        private Int64 file;
        private Int64 Columna;
        private Int64 Seleccion;
        
        #endregion


        private void DeXrm_Load (object sender, RibbonUIEventArgs e)
        {
            #region Create Objects
            _controller = new LController();
            #endregion

            btnConnection.Click += new RibbonControlEventHandler(this.BtnConnection_Click);
            btnTemplate.Click += new RibbonControlEventHandler(this.btnTemplate_Click);
        }

        private void btnTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            var celda = Globals.ThisAddIn.Application.Cells;
            celda[1, 1] = "Name";
            celda[1, 2] = "DisplayName";
            celda[1, 3] = "Type";
            celda[1, 4] = "StringFormat";
            celda[1, 5] = "Description";
            celda[1, 6] = "MaxLength";


            #region Create a List
            var excel = Globals.ThisAddIn.Application;
            var worksheet = (Worksheet)excel.ActiveSheet;

            var list = new List<string>();
            list.Add("Alpha");
            list.Add("Bravo");
            list.Add("Charlie");
            list.Add("Delta");
            list.Add("Echo");

            var flatList = string.Join(",", list.ToArray());

            var cell = (Range)worksheet.Cells[2, 2];
            cell.Validation.Delete();
            cell.Validation.Add(
                XlDVType.xlValidateList,
                XlDVAlertStyle.xlValidAlertInformation,
                XlFormatConditionOperator.xlBetween,
                flatList,
                Type.Missing);

            cell.Validation.IgnoreBlank = true;
            cell.Validation.InCellDropdown = true;
            #endregion


        }

        private void BtnConnection_Click (object sender, RibbonControlEventArgs e)
        {
            _controller.CreateConnectionDynamics();
        }
    }
}
