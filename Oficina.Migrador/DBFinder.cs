using SharpData;
using SharpData.Databases;
using System.Data.SqlClient;

namespace Oficina.Migrador
{
    public static class DBFinder
    {
        private static Dictionary<DbProviderType, SharpFactory> _factories = new Dictionary<DbProviderType, SharpFactory>();

        [Obsolete]
        public static ISharpFactory GetSharpFactory(DbProviderType databaseProvider, string connectionString)
        {
            if (!_factories.ContainsKey(databaseProvider))
            {
                switch (databaseProvider)
                {
                    case DbProviderType.SqlServer:
                        _factories.Add(DbProviderType.SqlServer,
                            new SharpFactory(SqlClientFactory.Instance, connectionString));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(databaseProvider), databaseProvider, null);
                }
            }
            return _factories[databaseProvider];
        }

        public static DbProviderType GetByName(string name)
        {
            foreach (var dbProviderType in DbProviderTypeExtensions.GetAll())
            {
                if (String.Equals(dbProviderType.GetProviderName(), name, StringComparison.CurrentCultureIgnoreCase) ||
                    String.Equals(dbProviderType.ToString(), name, StringComparison.CurrentCultureIgnoreCase)
                    )
                {
                    return dbProviderType;
                }
            }
            var options = String.Join(Environment.NewLine, DbProviderTypeExtensions.GetAll().Select(p => p.ToString()));
            throw new ArgumentException($"Could not find database provider named {name}. Available options are: {Environment.NewLine}{options}");
        }
    }
}
