using Ambedo.Contract.Dtos;
using Ambedo.UI.Shared;
using Ambedo.UI.Store.Data;
using Fluxor;

namespace Ambedo.UI.Controllers
{
	public class SidebarFormController : IUIController<SidebarForm>
	{
		private readonly IDispatcher _dispatcher;
		public SidebarFormController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		public void Create(Thootle thootle) => _dispatcher.Dispatch(new CreateDataAction(thootle));
		public void Filter(Thootle filter)
		{
			//todo
		}

		public void CancelEdit() => _dispatcher.Dispatch(new CancelEditAction());
		public void Update(Thootle thootle) => _dispatcher.Dispatch(new UpdateAction(thootle));
	}
}