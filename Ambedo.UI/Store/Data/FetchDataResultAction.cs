using System.Collections.Generic;
using Ambedo.Contract.Dtos;

namespace Ambedo.UI.Store.Data
{
	public class FetchDataResultAction
	{
		public IEnumerable<Thootle> Thootles { get; }

		public FetchDataResultAction(IEnumerable<Thootle> thootles)
		{
			Thootles = thootles;
		}
	}
}