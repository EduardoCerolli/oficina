namespace Oficina.Models
{
    public class Cliente
    {
        public virtual long Id { get; protected set; }
        public virtual required string Nome { get; set; }
        public virtual required string Numero { get; set; }
        public virtual IList<Carro> Carros { get; set; } = new List<Carro>();
    }
}
