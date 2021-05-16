using Ambedo.Contract.Dtos;
using Fluxor;

namespace Ambedo.UI.Store.Data
{
		public static class Reducers
		{
			[ReducerMethod]
			public static DataState ReduceFetchDataAction(DataState state, FetchDataAction action) 
			{
				return new DataState(null, true);
			}

			[ReducerMethod]
			public static DataState ReduceFetchDataResultAction(DataState state, FetchDataResultAction action)
			{
				return new DataState(action.Thootles, false);
			}
		}
}