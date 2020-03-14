using System;
using System.Data;
using System.Reflection;

namespace Problem11.ConnectionUtils
{
	public abstract class ConnectionFactory
	{
		public ConnectionFactory()
		{
		}
		private static ConnectionFactory instance;

		public static ConnectionFactory getInstance()
		{
			if (instance == null)
			{

				Assembly assem = Assembly.GetExecutingAssembly();
				Type[] types = assem.GetTypes();
				foreach (var type in types)
				{
					if (type.IsSubclassOf(typeof(ConnectionFactory)))
						instance = (ConnectionFactory)Activator.CreateInstance(type);
				}
			}
			return instance;
		}

		public abstract IDbConnection CreateConnection();
	}
}
