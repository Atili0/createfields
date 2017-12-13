using System.Linq;
using DeXrm.CreateField.Object;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System.Collections.Generic;
using CrmEarlyBound;

namespace DeXrm.CreateField.Controls.Model
{
    public class MOperations : IMOperations
    {
        public ILController _LoginController;


        public List<Entities> GetEntities ()
        {
            var lstEntities = new List<Entities>();


            using (var lServiceContext =
                new CrmServiceContext(_LoginController.ServerConnection.OrganizationServiceProxy))
            {
                var entityReq = new RetrieveAllEntitiesRequest
                {
                    EntityFilters = EntityFilters.Entity,
                    RetrieveAsIfPublished = true
                };

                var response = (RetrieveAllEntitiesResponse) lServiceContext.Execute(entityReq);

                lstEntities.AddRange(response.EntityMetadata.Select(currentEntity => new Entities
                {
                    PSchema = currentEntity.SchemaName,
                    EntitySchemaName = currentEntity.LogicalName,
                    OTC = currentEntity.ObjectTypeCode ?? 0,
                    Name = currentEntity.DisplayName.UserLocalizedLabel == null
                        ? currentEntity.LogicalName
                        : currentEntity.DisplayName.UserLocalizedLabel.Label
                }));
            }

            return lstEntities;
        }
    }
}