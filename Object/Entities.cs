using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace DeXrm.CreateField.Object
{
    public interface IEntities
    {
        string EntitySchemaName { get; set; }
        int OTC { get; set; }
        string Name { get; set; }
        string PName { get; set; }
        string PSchema { get; set; }
        string PNamePlural { get; set; }
        string PDescription { get; set; }
        bool IsActivity { get; set; }
        OwnershipTypes POwnershipType { get; set; }
        BooleanManagedProperty IsConnectionsEnabled { get; set; }
        IAttribute DxAttribute { get; set; }
        string PSolutionSchema { get; set; }
    }

    public class Entities : IEntities
    {
        public string EntitySchemaName { get; set; }
        public int OTC { get; set; }
        public string Name { get; set; }

        public string PName { get; set; }
        public string PSchema { get; set; }
        public string PNamePlural { get; set; }
        public string PDescription { get; set; }
        public bool IsActivity { get; set; }
        public OwnershipTypes POwnershipType { get; set; }
        public BooleanManagedProperty IsConnectionsEnabled { get; set; }
        public IAttribute DxAttribute { get; set; }
        public string PSolutionSchema { get; set; }
    }
}