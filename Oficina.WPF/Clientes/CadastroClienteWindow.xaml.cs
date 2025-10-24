using Microsoft.IdentityModel.Tokens;
using Oficina.Models;
using Oficina.Repositories;
using System.Windows;

namespace Oficina.WPF.Clientes
{
    public partial class CadastroClienteWindow : Window
    {
        private readonly IRepository<Cliente> clienteRepository;

        public CadastroClienteWindow(IRepository<Cliente> clienteRepository)
        {
            InitializeComponent();
            this.clienteRepository = clienteRepository;
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            var nome = txtNome.Text.Trim();
            if (nome.IsNullOrEmpty())
            {
                MessageBox.Show("Informe o Nome do cliente.");
                return;
            }

            if (clienteRepository.Exists(c => c.Nome == nome))
            {
                MessageBox.Show("Já existe um Cliente com o mesmo nome.");
                return;
            }

            var numero = txtNumero.Text.Trim();
            if (numero.IsNullOrEmpty())
            {
                MessageBox.Show("Informe o Número do cliente.");
                return;
            }

            var cliente = new Cliente
            {
                Nome = nome,
                Numero = numero
            };

            clienteRepository.SaveOrUpdate(cliente);
            DialogResult = true;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
