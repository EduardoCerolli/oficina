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
        public ObservableCollection<Carro> Carros { get; } = new();

        public CarrosListPage(
            IServiceProvider serviceProvider,
            Cliente cliente)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.cliente = cliente;

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
            //var mainWindow = (MainWindow)Application.Current.MainWindow;
            //mainWindow.MainFrame.Navigate(new ClientesListPage(serviceProvider, mainWindow));
        }
    }
}
