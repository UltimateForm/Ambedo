using System.Threading.Tasks;
using Ambedo.UI.Data.Services.Interfaces;
using Fluxor;

namespace Ambedo.UI.Store.Data
{
	public class DataEffects
	{
		private readonly IDataService _dataService;

		public DataEffects(IDataService dataService)
		{
			_dataService = dataService;
		}

		[EffectMethod]
		public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
		{
			var thootles = await _dataService.GetThootlesAsync();
			dispatcher.Dispatch(new FetchDataResultAction(thootles));
		}

		[EffectMethod]
		public async Task HandleCreateDataAction(CreateDataAction action, IDispatcher dispatcher)
		{
			var response = await _dataService.PostThootleAsync(action.Thootle);
			dispatcher.Dispatch(new FetchDataAction());
		}

		[EffectMethod]
		public async Task HandleDeleteDataAction(DeleteDataAction action, IDispatcher dispatcher)
		{
			await _dataService.DeleteThootleAsync(action.Id);
			dispatcher.Dispatch(new FetchDataAction());
		}
	}
}