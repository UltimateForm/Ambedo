using Ambedo.Contract.Dtos;
using Ambedo.UI.Controllers;
using Ambedo.UI.Store.Data;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace Ambedo.UI.Shared
{
	public partial class ThootleCard : ComponentBase
	{

		[Parameter]
		public Thootle Thootle { get; set; }

		[Inject]
		private ThootleCardController CardController { get; set; }

		[Inject]
		public IState<DataState>  State {get; set;}
		public void Delete() => CardController.Delete(Thootle);

		public void Edit() => CardController.Edit(Thootle);
	}
}
