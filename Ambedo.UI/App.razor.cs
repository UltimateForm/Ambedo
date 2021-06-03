using Microsoft.AspNetCore.Components;
using System;
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
		private Modal stateModalRef;
		protected override void OnInitialized()
		{
			base.OnInitialized();
			DataState.StateChanged += DataState_StateChanged;
			Dispatcher.Dispatch(new FetchDataAction());
		}
		private bool Loading => DataState.Value.IsLoading;
		private void DataState_StateChanged(object sender, DataState e)
		{
			if (!string.IsNullOrEmpty(e.Error))
			{
				ShowModal();
			}
			Console.WriteLine("==========================> DataState");
			Console.WriteLine($"DataState is {JsonConvert.SerializeObject(DataState.Value)}");
			Console.WriteLine("<========================== DataState");
		}
		private void ShowModal()
		{
			stateModalRef.Show();
		}

		private void HideModal()
		{
			stateModalRef.Hide();
		}
	}
}
