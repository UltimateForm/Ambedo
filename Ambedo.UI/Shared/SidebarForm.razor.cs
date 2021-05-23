using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Ambedo.Contract.Dtos;
using Blazorise.States;
using Ambedo.UI.Data.Services.Interfaces;
using Ambedo.UI.Controllers;

namespace Ambedo.UI.Shared
{
	public partial class SidebarForm : ComponentBase
	{
		[Inject]
		private SidebarFormController Controller { get; set; }

		#region parameters
		[CascadingParameter]
		protected Theme Theme { get; set; }
		[CascadingParameter]
		protected BarState ParentBarState
		{
			get => parentBarState;
			set //not sure if this is the best way to manage this
			{
				parentBarState = value;
			}
		}
		#endregion

		record ThootleCategoryInput
		{
			public int Id { get; init; }
			public string Value { get; init; }
		}
		string ThootleText { get; set; }

		readonly IEnumerable<ThootleCategoryInput> inputCategories = Enum.GetNames(typeof(ThootleCategories)).Select((name, index) => new ThootleCategoryInput { Id = index, Value = name });
		IReadOnlyList<int> SelectedCategories { get; set; }
		private BarState parentBarState;


		// @NOTE: i'm aware i could use an actual <form/> but seems overkill for me at this point
		void OnCreateButtonClicked()
		{
			try
			{
				Controller.Create(new Thootle
				{
					Content = ThootleText,
					Categories = SelectedCategories?.Select(index => (ThootleCategories)index)
				});
			}
			finally
			{
				ClearForm();
			}
		}

		void ClearForm()
		{
			ThootleText = "";
			SelectedCategories = null;
		}

		void OnClearButtonClicked()
		{
			ClearForm();
		}
		void OnFilterButtonClicked()
		{
			Controller.Filter(new Thootle
			{
				Content = ThootleText,
				Categories = SelectedCategories?.Select(index => (ThootleCategories)index)
			});
		}
	}
}
