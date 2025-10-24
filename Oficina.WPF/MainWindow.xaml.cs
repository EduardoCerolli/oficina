using Oficina.Models;
using Oficina.Repositories;
using Oficina.WPF.Clientes;
using System.Windows;

namespace Oficina.WPF
{
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IRepository<Cliente> clienteRepository;

        public MainWindow(
            IServiceProvider serviceProvider,
            IRepository<Cliente> clienteRepository)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.clienteRepository = clienteRepository;

            MainFrame.Navigate(new ClientesListPage(serviceProvider, clienteRepository, this));
        }
    }
}
