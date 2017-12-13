using System;
using Microsoft.Xrm.Tooling.Connector;

namespace DeXrm.CreateField
{
    public interface ILController
    {
        void CreateConnectionDynamics();
        CrmServiceClient ServerConnection { get; set; }
        Guid SystemUserConnectedGuid { get; set; }
    }
}