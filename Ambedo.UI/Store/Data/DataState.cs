using System.Collections.Generic;
using System.Linq;
using Ambedo.Contract.Dtos;

namespace Ambedo.UI.Store.Data
{
	public class DataState
	{
		public IReadOnlyList<Thootle> Thootles { get; }
		public bool IsLoading {get;}
		public DataState(IEnumerable<Thootle> thootles, bool isLoading)
		{
			IsLoading = isLoading;
			Thootles = (thootles?.ToList() ?? new List<Thootle>()).AsReadOnly(); //not sure about this but...idk i feel fancy using ReadOnlyList :(
		}
	}
}