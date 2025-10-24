using FluentNHibernate.Mapping;
using Oficina.Models;

namespace Oficina.Mappings
{
    internal class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");
            Id(c => c.Id).GeneratedBy.Increment();
            Map(c => c.Nome).Not.Nullable();
            Map(c => c.Numero).Not.Nullable();
            HasMany(x => x.Carros).Inverse().Cascade.All();
        }
    }
}
