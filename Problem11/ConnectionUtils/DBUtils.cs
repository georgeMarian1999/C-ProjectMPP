using System;
using System.Data;

namespace Problem11.ConnectionUtils
{
	public class DBUtils
	{
		private static IDbConnection instance = null;

		public static IDbConnection getConnection()
		{
			if (instance == null || instance.State == ConnectionState.Closed)
			{
				instance = getNewConnection();
				instance.Open();
			}
			return instance;
		}

		private static IDbConnection getNewConnection()
		{
			return ConnectionFactory.getInstance().CreateConnection();
		}
	}
}
