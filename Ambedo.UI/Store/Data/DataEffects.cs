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
	}
}