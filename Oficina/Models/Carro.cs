namespace Oficina.Models
{
    public class Carro
    {
        public virtual long Id { get; protected set; }
        public virtual required Cliente Cliente { get; set; }
        public virtual required string Placa { get; set; }
        public virtual required string Marca { get; set; }
        public virtual required string Modelo { get; set; }
        public virtual required int Ano { get; set; }
        public virtual required string Cor { get; set; }
        public virtual required string Motor { get; set; }
        public virtual IList<Servico> Servicos { get; set; } = new List<Servico>();
    }
}