using Oficina.Migrador.Migracoes;
using SharpData;
using SharpMigrations.Runners;
using System.Reflection;

namespace Oficina.Migrador
{
    public class Migrador
    {
        [Obsolete]
        public void Migrar()
        {
            var connString = @"Server=(localdb)\MSSQLLocalDB;Database=Oficina;Trusted_Connection=True;";

            var databaseProvider = DBFinder.GetByName("SqlServer");
            SharpFactory.Default = DBFinder.GetSharpFactory(databaseProvider, connString);
            var runner = new Runner(SharpFactory.Default.CreateDataClient(), GetAssemblyWithMigrations(), "default");
            runner.Run(-1);
        }

        private Assembly GetAssemblyWithMigrations()
        {
            return typeof(Migracao_0001_AddTable_Cliente).Assembly;
        }
    }
}
