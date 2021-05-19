using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ambedo.UI.Data.Services.Interfaces;
using Ambedo.Contract.Dtos;
using Blazorise;
using Fluxor;
using Ambedo.UI.Store.Data;
using Newtonsoft.Json;

namespace Ambedo.UI
{
	public partial class App
	{

		[Inject]
		public IState<DataState> DataState { get; set; }
		[Inject]
		IDispatcher Dispatcher { get; set; }
		private readonly Theme theme = new Theme
		{
			BarOptions = new ThemeBarOptions
			{
				VerticalWidth = "400px",
			},
		};
		protected override void OnInitialized()
		{
			base.OnInitialized();
			DataState.StateChanged += DataState_StateChanged;
			Dispatcher.Dispatch(new FetchDataAction());
		}
		private bool Loading => DataState.Value.IsLoading;
		private void DataState_StateChanged(object sender, DataState e)
		{
			Console.WriteLine("==========================> DataState");
			Console.WriteLine($"DataState is {JsonConvert.SerializeObject(DataState.Value)}");
			Console.WriteLine("<========================== DataState");
		}
		async Task OnCreate(Thootle thootle)=>Dispatcher.Dispatch(new CreateDataAction(thootle));

		async Task OnFinishedPost()
		{
			//ignore
		}

		async Task OnThootleDelete(Thootle thootle) => Dispatcher.Dispatch(new DeleteDataAction(thootle.Id));

		async Task OnThootleEdit(Thootle thootle)
		{

		}
	}
}
