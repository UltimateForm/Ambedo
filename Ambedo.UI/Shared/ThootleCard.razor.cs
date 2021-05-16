using Ambedo.Contract.Dtos;
using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Ambedo.UI.Shared
{
	public partial class ThootleCard : ComponentBase
	{
		[Parameter]
		public Thootle Thootle { get; set; }
		[Parameter]
		public EventCallback<Thootle> OnDelete { get; set; }
		[Parameter]
		public EventCallback<Thootle> OnEdit { get; set; }
		public async Task Delete()
		{
			await OnDelete.InvokeAsync(Thootle);
		}

		public async Task Edit()
		{
			await OnEdit.InvokeAsync(Thootle);
		}
	}
}
