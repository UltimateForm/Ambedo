using System;
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
			try
			{
				var thootles = await _dataService.GetThootlesAsync();
				dispatcher.Dispatch(new FetchDataResultAction(thootles));
			}
			catch (Exception e)
			{
				dispatcher.Dispatch(new ErrorAction(e.Message));
			}

		}

		[EffectMethod]
		public async Task HandleCreateDataAction(CreateDataAction action, IDispatcher dispatcher)
		{
			try
			{
				var response = await _dataService.PostThootleAsync(action.Thootle);
				dispatcher.Dispatch(new FetchDataAction());
			}
			catch (Exception e)
			{
				dispatcher.Dispatch(new ErrorAction(e.Message));
			}
		}

		[EffectMethod]
		public async Task HandleDeleteDataAction(DeleteDataAction action, IDispatcher dispatcher)
		{
			try
			{
				await _dataService.DeleteThootleAsync(action.Id);
				dispatcher.Dispatch(new FetchDataAction());
			}
			catch (Exception e)
			{
				dispatcher.Dispatch(new ErrorAction(e.Message));
			}
		}
	}
}