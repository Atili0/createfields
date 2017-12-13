using System;
using System.Windows.Forms;
using DeXrm.CreateField.Controls.Controller;
using DeXrm.CreateField.Controls.Model;
using DeXrm.CreateField.Controls.View;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;


namespace DeXrm.CreateField
{
    public partial class Login : Form
    {
        #region MVC Login

        private readonly Conexion _conexion;
        public ILController _controller;

        #endregion

        #region MVC Custom Task
        private Operations _operations;
        private MOperations _model;
        private COperations _coperations;

        #endregion

        private Microsoft.Office.Tools.CustomTaskPane _taskpane;

        internal enum ConectionType
        {
            Office365 = 8,
            Local = 7
        }

        public Login ()
        {
            InitializeComponent();

            _conexion = new Conexion();
            _controller = new LController();

            _operations = new Operations();
            _model = new MOperations();

            #region Controls
            this.rbOffice.Click += RbOffice_Click;
            this.btnAceptar.Click += BtnAceptar_Click;
            
            #endregion
        }



        private void GetNameOrganization (ConectionType type)
        {
            _conexion.nameOrganization = txtURL.Text.Substring((int)type, txtURL.Text.IndexOf('.') - (int)type);
        }

        private void BtnAceptar_Click (object sender, EventArgs e)
        {
            _conexion.url = txtURL.Text;
            _conexion.user = txtUser.Text;
            _conexion.password = txtPassword.Text;
            _conexion.domain = txtDominio.Text;

            if (rbLocal.Checked) GetNameOrganization(ConectionType.Local);
            else GetNameOrganization(ConectionType.Office365);

            try
            {
                _controller.ServerConnection = new CrmServiceClient(_conexion.ConnectionString);
                

                if (_controller.ServerConnection != null)
                {
                    var userid = (WhoAmIResponse)_controller.ServerConnection.Execute(new WhoAmIRequest());
                    if (userid.UserId == Guid.Empty)
                        MessageBox.Show("We can not connect to the DYN365", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    else
                    {
                        _controller.SystemUserConnectedGuid = userid.UserId;
                        SetObjectConnection(_controller);

                    }
                }
                else
                {
                    MessageBox.Show("Ups! Some problem here.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        public void SetObjectConnection (ILController pController)
        {
            _model._LoginController = pController;

            _coperations = new COperations(_operations, _model);
            _taskpane = Globals.ThisAddIn.CustomTaskPanes.Add(_operations, "DeXrm Operation");
            _taskpane.Visible = true;
        }




        private void RbOffice_Click (object sender, EventArgs e)
        {
            if (this.rbOffice.Checked)
            {
                this.txtDominio.Enabled = false;
                this.txtPuerto.Enabled = false;
            }
            else
            {
                this.txtDominio.Enabled = true;
                this.txtPuerto.Enabled = true;
            }
        }
    }

    public class Conexion
    {
        public string domain;
        public string nameOrganization;
        private string organizationName;
        public string password;
        private int port;
        private string server;
        public string url;
        public string user;

        public string ConnectionString
        {
            get
            {
                switch (Type)
                {
                    case AuthenticationProviderType.ActiveDirectory:
                        return
                            $"Url={url};Domain={domain};Username={user};Password={password};authtype=AD";
                    default:
                        return
                            $"Url={url};Username={user};Password={password};authtype=Office365";
                }
            }
        }

        public AuthenticationProviderType Type { get; set; }
    }
}
