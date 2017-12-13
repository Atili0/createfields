using System.Collections.Generic;
using System.Threading.Tasks;
using DeXrm.CreateField.Controls.Model;
using DeXrm.CreateField.Controls.View;
using DeXrm.CreateField.Object;
using System.Threading.Tasks;


namespace DeXrm.CreateField.Controls.Controller
{
    public class COperations : ICOperations
    {
        public IOperations _view;
        public IMOperations _model;

        #region variables

        public List<Entities> _ListEntities;
        
        #endregion

        public COperations (IOperations view, IMOperations model)
        {
            _view = view;
            _model = model;
            _view.SetController(this);
        }

        public void GetEntities ()
        {
            this._ListEntities = _model.GetEntities();
            _view.SetEntities(this);
        }
    }
}