using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeXrm.CreateField.Controls;
using Microsoft.Xrm.Tooling.Connector;

namespace DeXrm.CreateField
{
    public class LController : ILController
    {
        private Login _Login;

        public CrmServiceClient ServerConnection { get; set; }
        public Guid SystemUserConnectedGuid { get; set; }

        public void CreateConnectionDynamics()
        {
            _Login = new Login();
            _Login.ShowDialog();

        }
    }
}
