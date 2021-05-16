using System.Collections.Generic;
using Ambedo.Contract.Dtos;
using Fluxor;

namespace Ambedo.UI.Store.Data
{
	class DataFeature : Feature<DataState>
	{
		public override string GetName()=>"Data";

		protected override DataState GetInitialState()
		{
			return new DataState(new Thootle[]{}, false);
		}
	}
}