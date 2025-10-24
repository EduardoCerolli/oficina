using SharpMigrations;

namespace Oficina.Migrador.Migracoes
{
    public class Migracao_0003_AddTable_Servico : SchemaMigration
    {
        public override void Up()
        {
            Add.Table("Servico")
                .WithColumns(
                Column.Int64("Id").NotNull(),
                Column.Int64("Carro").NotNull(),
                Column.Int64("KM").NotNull(),
                Column.Date("DataServico").NotNull(),
                Column.Date("FimGarantia"),
                Column.Decimal("ValorGasto").NotNull(),
                Column.Decimal("MaoObra").NotNull(),
                Column.Decimal("ValorCobrado").NotNull(),
                Column.String("Descricao").NotNull()
                );

            Add.PrimaryKey("PK_Servico").OnColumns("Id").OfTable("Servico");
            Add.ForeignKey("FK_Servico_Carro")
                .OnColumn("Carro").OfTable("Servico")
                .ReferencingColumn("Id").OfTable("Carro")
                .OnDeleteNoAction();
        }

        public override void Down()
        {
            Remove.ForeignKey("FK_Servico_Carro");
            Remove.PrimaryKey("PK_Carro");
            Remove.Table("Cliente");
        }
    }
}
