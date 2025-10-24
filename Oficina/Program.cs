using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using Oficina;
using Oficina.Repositories;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // cria e registra a SessionFactory como Singleton
                try
                {
                    var sessionFactory = NHibernateHelper.CreateSessionFactory();
                    services.AddSingleton<ISessionFactory>(sessionFactory);
                }
                catch (FluentNHibernate.Cfg.FluentConfigurationException ex)
                {
                    Console.WriteLine("Erro NHibernate:");
                    foreach (var reason in ex.PotentialReasons)
                        Console.WriteLine(" - " + reason);

                    Console.WriteLine("InnerException: " + ex.InnerException?.Message);
                    throw;
                }

                // registra ISession como Scoped (uma sessão por escopo)
                services.AddScoped(factory => factory.GetRequiredService<ISessionFactory>().OpenSession());

                // registra o Repository e o App
                var entityAssembly = Assembly.GetExecutingAssembly();
                var entityTypes = entityAssembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "Oficina.Models"); // só as entidades
                foreach (var type in entityTypes)
                {
                    var repositoryInterface = typeof(IRepository<>).MakeGenericType(type);
                    var repositoryImplementation = typeof(Repository<>).MakeGenericType(type);

                    services.AddScoped(repositoryInterface, repositoryImplementation);
                }

                services.AddScoped<App>();
            })
            .Build();

        var app = host.Services.GetRequiredService<App>();
    }
}