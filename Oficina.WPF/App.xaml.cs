using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using Oficina.Models;
using Oficina.Repositories;
using Oficina.WPF.Clientes;
using System.Data;
using System.Windows;

namespace Oficina.WPF
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // NHibernate
                    var sessionFactory = NHibernateHelper.CreateSessionFactory();
                    services.AddSingleton(sessionFactory);
                    services.AddScoped(factory => factory.GetRequiredService<ISessionFactory>().OpenSession());

                    // Registro automático de repositórios
                    var entityAssembly = typeof(Carro).Assembly;
                    var entityTypes = entityAssembly.GetTypes()
                        .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "Oficina.Models");

                    foreach (var type in entityTypes)
                    {
                        var repoInterface = typeof(IRepository<>).MakeGenericType(type);
                        var repoImplementation = typeof(Repository<>).MakeGenericType(type);
                        services.AddScoped(repoInterface, repoImplementation);
                    }

                    // ViewModels e Views
                    services.AddScoped<MainWindow>();
                    services.AddScoped<CadastroClienteWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            if (AppHost == null)
                return;

            await AppHost.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (AppHost == null)
                return;

            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }

}
