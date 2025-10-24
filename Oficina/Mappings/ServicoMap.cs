using FluentNHibernate.Mapping;
using Oficina.Models;

namespace Oficina.Mappings
{
    internal class ServicoMap : ClassMap<Servico>
    {
        public ServicoMap()
        {
            Table("Servico");
            Id(c => c.Id).GeneratedBy.Increment();
            References(c => c.Carro).Column("Carro").Not.Nullable();
            Map(c => c.KM).Not.Nullable();
            Map(c => c.DataServico).Not.Nullable();
            Map(c => c.FimGarantia);
            Map(c => c.ValorGasto).Not.Nullable();
            Map(c => c.MaoObra).Not.Nullable();
            Map(c => c.ValorCobrado).Not.Nullable();
            Map(c => c.Descricao).Not.Nullable();
            HasMany(x => x.Pecas).Inverse().Cascade.All();
        }
    }
}
