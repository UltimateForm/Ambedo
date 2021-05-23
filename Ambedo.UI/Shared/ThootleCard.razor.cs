using Ambedo.Contract.Dtos;
using Ambedo.UI.Controllers;
using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Ambedo.UI.Shared
{
	public partial class ThootleCard : ComponentBase
	{

		[Parameter]
		public Thootle Thootle { get; set; }

		[Inject]
		private ThootleCardController CardController { get; set; }

		public void Delete() => CardController.Delete(Thootle);

		public void Edit() => CardController.Edit(Thootle);
	}
}
