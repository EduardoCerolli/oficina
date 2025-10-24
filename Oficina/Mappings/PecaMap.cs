using FluentNHibernate.Mapping;
using Oficina.Models;

namespace Oficina.Mappings
{
    internal class PecaMap : ClassMap<Peca>
    {
        public PecaMap()
        {
            Table("Peca");
            Id(c => c.Id).GeneratedBy.Increment();
            References(c => c.Servico).Column("Servico").Not.Nullable();
            Map(c => c.Marca).Not.Nullable();
            Map(c => c.DataCompra).Not.Nullable();
            Map(c => c.ValorPago).Not.Nullable();
            Map(c => c.ValorCobrado).Not.Nullable();
            Map(c => c.AutoPecas);
            Map(c => c.Garantia);
        }
    }
}
