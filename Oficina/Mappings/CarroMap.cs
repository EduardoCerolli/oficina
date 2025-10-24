using FluentNHibernate.Mapping;
using Oficina.Models;

namespace Oficina.Mappings
{
    internal class CarroMap : ClassMap<Carro>
    {
        public CarroMap()
        {
            Table("Carro");
            Id(c => c.Id).GeneratedBy.Increment();
            References(c => c.Cliente).Column("Cliente").Not.Nullable();
            Map(c => c.Placa).Not.Nullable();
            Map(c => c.Marca).Not.Nullable();
            Map(c => c.Modelo).Not.Nullable();
            Map(c => c.Ano).Not.Nullable();
            Map(c => c.Cor).Not.Nullable();
            Map(c => c.Motor).Not.Nullable();
            HasMany(x => x.Servicos).Inverse().Cascade.All();
        }
    }
}
