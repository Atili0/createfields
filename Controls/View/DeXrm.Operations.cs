using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeXrm.CreateField.Controls.Controller;
using DeXrm.CreateField.Controls.Model;
using DeXrm.CreateField.Object;
using Microsoft.Xrm.Sdk;

namespace DeXrm.CreateField.Controls.View
{
    public partial class Operations : UserControl, IOperations
    {
        private ICOperations _controllers;
        private Loading frmLoading;

        public Operations ()
        {
            InitializeComponent();

            #region eventos
            this.btnSave.Click += BtnSave_Click;
            this.cbEntities.Click += CbEntities_Click;
            #endregion

        }

        private void CbEntities_Click(object sender, EventArgs e)
        {
            if(cbEntities.Items.Count <= 0)
            #region GetEntity
                _controllers.GetEntities();
            #endregion
        }

        private void BtnSave_Click (object sender, EventArgs e)
        {
            
        }

        #region Set View

        public void SetEntities(COperations pOperation)
        {
            this.cbEntities.DataSource = pOperation._ListEntities;
            this.cbEntities.DisplayMember = "Name";
            this.cbEntities.ValueMember = "PSchema";
        }

        #endregion



        #region Set Controller
        public void SetController(ICOperations con)
        {
            _controllers = con;
        }
        #endregion

        #region Loading
        public void Message ()
        {
            frmLoading.Close();
            Enabled = true;
        }

        private async void OpenLoading ()
        {
            Enabled = false;
            frmLoading = new Loading();
            frmLoading.Show(this);
        }
        #endregion

    }
}
