using System.Collections.Generic;
using DeXrm.CreateField.Object;
using Microsoft.Xrm.Tooling.Connector;

namespace DeXrm.CreateField.Controls.Model
{
    public interface IMOperations
    {
        List<Entities> GetEntities ();
    }
}