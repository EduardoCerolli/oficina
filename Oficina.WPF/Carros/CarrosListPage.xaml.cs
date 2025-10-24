using Oficina.Models;
using Oficina.WPF.Clientes;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Oficina.WPF.Carros
{
    public partial class CarrosListPage : Page
    {
        private readonly IServiceProvider serviceProvider;
        private readonly Cliente cliente;
        private readonly MainWindow mainWindow;
        private readonly ClientesListPage clientesListPage;

        public ObservableCollection<Carro> Carros { get; } = new();

        public CarrosListPage(
            IServiceProvider serviceProvider,
            Cliente cliente,
            MainWindow mainWindow,
            ClientesListPage clientesListPage)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.cliente = cliente;
            this.mainWindow = mainWindow;
            this.clientesListPage = clientesListPage;
            DataContext = this;
            CarregarCarros();
        }

        private void CarregarCarros()
        {
            Carros.Clear();
            foreach (var c in cliente.Carros)
                Carros.Add(c);
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Navigate(clientesListPage);
        }
    }
}
