namespace Oficina.Models
{
    public class Peca
    {
        public virtual long Id { get; protected set; }
        public virtual required Servico Servico { get; set; }
        public virtual required string Marca { get; set; }
        public virtual required DateTime DataCompra { get; set; }
        public virtual required decimal ValorPago { get; set; }
        public virtual required decimal ValorCobrado { get; set; }
        public virtual string? AutoPecas { get; set; }
        public virtual DateTime? Garantia { get; set; }
    }
}
