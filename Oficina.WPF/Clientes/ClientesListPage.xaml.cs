using Oficina.Models;
using Oficina.Repositories;
using Oficina.WPF.Carros;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Oficina.WPF.Clientes
{
    public partial class ClientesListPage : Page
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IRepository<Cliente> clienteRepository;
        private readonly MainWindow mainWindow;

        public ObservableCollection<Cliente> Clientes { get; } = new();

        public ClientesListPage(IServiceProvider serviceProvider, IRepository<Cliente> clienteRepository, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.serviceProvider = serviceProvider;
            this.clienteRepository = clienteRepository;
            this.mainWindow = mainWindow;

            CarregarClientes();
        }

        private void CarregarClientes()
        {
            Clientes.Clear();
            var lista = clienteRepository.List(null);
            foreach (var c in lista)
                Clientes.Add(c);
        }

        private void NovoCliente_Click(object sender, RoutedEventArgs e)
        {
            var popup = new CadastroClienteWindow(clienteRepository)
            {
                Owner = mainWindow
            };

            if (popup.ShowDialog() == true)
            {
                CarregarClientes();
            }
        }

        private void AbrirCarros_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Cliente cliente)
            {
                mainWindow.MainFrame.Navigate(new CarrosListPage(serviceProvider, cliente));
            }
        }
    }
}
