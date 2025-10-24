namespace Oficina.Models
{
    public class Servico
    {
        public virtual long Id { get; protected set; }
        public virtual required Cliente Carro { get; set; }
        public virtual required long KM { get; set; }
        public virtual required DateTime DataServico { get; set; }
        public virtual DateTime FimGarantia { get; set; }
        public virtual required decimal ValorGasto { get; set; }
        public virtual required decimal MaoObra { get; set; }
        public virtual required decimal ValorCobrado { get; set; }
        public virtual required string Descricao { get; set; }
        public virtual IList<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
