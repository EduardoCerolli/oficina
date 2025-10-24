using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Oficina.Mappings;

namespace Oficina
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            try
            {
                return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(@"Server=(localdb)\MSSQLLocalDB;Database=Oficina;Trusted_Connection=True;")
                        .Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CarroMap>())
                    .ExposeConfiguration(cfg => cfg.SetProperty("hbm2ddl.auto", "update"))
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
