using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;

namespace Nop.Data.Initializers
{
	public class NuoDbDatabaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
	{
		public void InitializeDatabase(TContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			using (var ts = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { Timeout = TimeSpan.FromHours(1) }))
			{
				if (IsInitialized(context))
					return;

				var script = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
				foreach (var item in script.Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()))
				{
					context.Database.ExecuteSqlCommand(item);
				}
				context.Database.ExecuteSqlCommand("create table _nopCommerce_NuoDB (dummy int)");
				Seed(context);
				context.SaveChanges();
				ts.Complete();
			}
		}

		static bool IsInitialized(TContext context)
		{
			try
			{
				context.Database.ExecuteSqlCommand("select dummy from _nopCommerce_NuoDB fetch first 0");
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected virtual void Seed(TContext context)
		{ }
	}
}
