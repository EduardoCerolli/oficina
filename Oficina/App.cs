using Oficina.Models;
using Oficina.Repositories;

namespace Oficina
{
    public class App
    {
        private readonly IRepository<Cliente> clienteRepository;

        public App(IRepository<Cliente> clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public void RunAsync()
        {
            var clientes = clienteRepository.List(null);
        }
    }
}
