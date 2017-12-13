using DeXrm.CreateField.Controls.Controller;

namespace DeXrm.CreateField.Controls.View
{
    public interface IOperations
    {
        void SetController(ICOperations con);
        void SetEntities(COperations pOperation);
        void Message ();
    }
}