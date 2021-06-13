using System.Collections.Generic;
using Ambedo.Contract.Dtos;

namespace Ambedo.UI.Store.Data
{
	public class FetchDataAction
	{

	}
	public class FetchDataResultAction
	{
		public IEnumerable<Thootle> Thootles { get; }

		public FetchDataResultAction(IEnumerable<Thootle> thootles)
		{
			Thootles = thootles;
		}
	}

	public class CreateDataAction
	{
		public Thootle Thootle;

		public CreateDataAction(Thootle thootle)
		{
			Thootle = thootle;
		}
	}

	public class CreateDataResultAction
	{
		public Thootle Thootle;
		public CreateDataResultAction(Thootle thootle)
		{
			Thootle = thootle;
		}
	}

	public class DeleteDataAction
	{
		public string Id;
		public DeleteDataAction(string id)
		{
			Id = id;
		}
	}

	public class DeleteDataResultAction
	{
		public string Id;
		public DeleteDataResultAction(string id)
		{
			Id = id;
		}
	}

	public class BeginEditAction
	{
		public Thootle Thootle;
		public BeginEditAction(Thootle thootle)
		{
			Thootle = thootle;
		}
	}
	public class UpdateAction
	{
		public Thootle Thootle;
		public UpdateAction(Thootle thootle)
		{
			Thootle = thootle;
		}
	}
	public class CancelEditAction
	{
	}

	public class ErrorAction
	{
		public string Error;
		public ErrorAction(string error)
		{
			Error = error;
		}
	}
}