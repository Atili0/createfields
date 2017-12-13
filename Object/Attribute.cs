using System;
using Microsoft.Xrm.Sdk.Metadata;

namespace DeXrm.CreateField.Object
{
    public interface IAttribute
    {
        string Name { get; set; }
        Guid AttributeId { get; set; }
        int AttributeType { get; set; }
        string Description { get; set; }
        string DisplayName { get; set; }
        string LogicalName { get; set; }
        string SchemaName { get; set; }
        int MaxLength { get; set; }
        string Target { get; set; }
        int MaxValue { get; set; }
        int MinValue { get; set; }
        int Precision { get; set; }
        decimal DecimalMinValue { get; set; }
        decimal DecimalMaxValue { get; set; }
        double MoneyMinValue { get; set; }
        double MoneyMaxValue { get; set; }
        string TypeName { get; set; }
        StringFormatName PFormatName { get; set; }
        AttributeRequiredLevelManagedProperty PRequiredLevel { get; set; }
    }

    public class Dx_Attribute : IAttribute
    {
        public string Name { get; set; }
        public Guid AttributeId { get; set; }
        public int AttributeType { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string LogicalName { get; set; }
        public string SchemaName { get; set; }
        public int MaxLength { get; set; }
        public string Target { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public int Precision { get; set; }
        public decimal DecimalMinValue { get; set; }
        public decimal DecimalMaxValue { get; set; }
        public double MoneyMinValue { get; set; }
        public double MoneyMaxValue { get; set; }
        public string TypeName { get; set; }

        public StringFormatName PFormatName { get; set; }
        public AttributeRequiredLevelManagedProperty PRequiredLevel { get; set; }
    }
}