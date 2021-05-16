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

namespace Ambedo.UI
{
	public partial class App
	{

		[Inject]
		public IState<DataState> DataState { get; set; }
		[Inject]
		IDataService DataService { get; set; }
		private readonly Theme theme = new Theme
		{
			BarOptions = new ThemeBarOptions
			{
				VerticalWidth = "400px",
			},
		};
		private readonly List<Thootle> thootles = new List<Thootle>();
		protected override async Task OnInitializedAsync()
		{
			await LoadThootles();
		}
		private bool Loading { get; set; }
		async Task LoadThootles()
		{
			var apiTootles = await DataService.GetThootlesAsync();
			thootles.AddRange(apiTootles.Where(apiTootle => !thootles.Any(loadedThootle => apiTootle.Id == loadedThootle.Id)));
			thootles.Sort((x, y) => DateTime.Compare(y.CreatedTimeUtc, x.CreatedTimeUtc));
		}

		async Task OnCreate(Thootle thootle)
		{
			Loading = true;
			try
			{
				await DataService.PostThootleAsync(thootle);
			}
			finally
			{
				Loading = false;
			}
		}

		async Task OnFinishedPost()
		{
			await LoadThootles();
		}

		async Task OnThootleDelete(Thootle thootle)
		{
			Loading = true;
			try
			{
				await DataService.DeleteThootleAsync(thootle);
				thootles.Remove(thootle);
			}
			catch (Exception)
			{
				//ignore
			}
			finally
			{
				await LoadThootles();
				Loading = false;
			}
		}

		async Task OnThootleEdit(Thootle thootle)
		{

		}
	}
}
