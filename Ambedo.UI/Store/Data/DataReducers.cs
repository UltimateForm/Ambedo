using System.Collections.Generic;
using Ambedo.Contract.Dtos;
using Fluxor;

namespace Ambedo.UI.Store.Data
{
	public static class Reducers
	{
		[ReducerMethod]
		public static DataState ReduceFetchDataAction(DataState state, FetchDataAction action)
		{
			return new DataState(state.Thootles, true);
		}

		[ReducerMethod]
		public static DataState ReduceFetchDataResultAction(DataState state, FetchDataResultAction action)
		{
			return new DataState(action.Thootles, false);
		}

		[ReducerMethod]
		public static DataState ReduceCreateDataAction(DataState state, CreateDataAction action)
		{
			return new DataState(state.Thootles, true);
		}

		[ReducerMethod]
		public static DataState ReduceCreateDataResultAction(DataState state, CreateDataResultAction action)
		{
			List<Thootle> newThootles = new List<Thootle>();
			newThootles.AddRange(state.Thootles);
			newThootles.Add(action.Thootle);
			return new DataState(newThootles, false);
		}

		[ReducerMethod]
		public static DataState ReduceDeleteDataAction(DataState state, DeleteDataAction action)
		{
			return new DataState(state.Thootles, true);
		}

		[ReducerMethod]
		public static DataState ReduceErrorAction(DataState state, ErrorAction action)
		{
			return new DataState(state.Thootles, false, action.Error);
		}
	}
}