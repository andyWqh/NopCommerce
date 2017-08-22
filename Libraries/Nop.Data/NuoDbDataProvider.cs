using System.Data.Common;
using System.Data.Entity;
using Nop.Core.Data;
using Nop.Data.Initializers;
using NuoDb.Data.Client;
using NuoDb.Data.Client.EntityFramework6;

namespace Nop.Data
{
	public class NuoDbDataProvider : IDataProvider
	{
		public void InitConnectionFactory()
		{
#pragma warning disable 0618
			Database.DefaultConnectionFactory = new NuoDbConnectionFactory();
		}

		public void SetDatabaseInitializer()
		{
			Database.SetInitializer(new NuoDbDatabaseInitializer<NopObjectContext>());
		}

		public void InitDatabase()
		{
			InitConnectionFactory();
			SetDatabaseInitializer();
		}

		public bool StoredProceduredSupported
		{
			get { return false; }
		}

		public DbParameter GetParameter()
		{
			return new NuoDbParameter();
		}
	}
}
