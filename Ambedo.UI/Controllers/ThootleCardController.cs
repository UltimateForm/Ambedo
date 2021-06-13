using Ambedo.Contract.Dtos;
using Ambedo.UI.Shared;
using Ambedo.UI.Store.Data;
using Fluxor;

namespace Ambedo.UI.Controllers
{
	public class ThootleCardController : IUIController<ThootleCard>
	{
		private readonly IDispatcher _dispatcher;
		public ThootleCardController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		public void Delete(Thootle thootle)
		{
			_dispatcher.Dispatch(new DeleteDataAction(thootle.Id));
		}

		public void Edit(Thootle thootle)
		{
			_dispatcher.Dispatch(new BeginEditAction(thootle));
		}
	}
}