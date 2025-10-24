using SharpMigrations;

namespace Oficina.Migrador.Migracoes
{
    public class Migracao_0004_AddTable_Peca : SchemaMigration
    {
        public override void Up()
        {
            Add.Table("Peca")
                .WithColumns(
                Column.Int64("Id").NotNull(),
                Column.Int64("Servico").NotNull(),
                Column.Date("DataCompra").NotNull(),
                Column.Decimal("ValorPago").NotNull(),
                Column.Decimal("ValorCobrado").NotNull(),
                Column.String("AutoPecas", 100),
                Column.Date("Garantia")
                );

            Add.PrimaryKey("PK_Peca").OnColumns("Id").OfTable("Peca");
            Add.ForeignKey("FK_Peca_Servico")
                .OnColumn("Servico").OfTable("Peca")
                .ReferencingColumn("Id").OfTable("Servico")
                .OnDeleteNoAction();
        }

        public override void Down()
        {
            Remove.ForeignKey("FK_Peca_Servico");
            Remove.PrimaryKey("PK_Carro");
            Remove.Table("Cliente");
        }
    }
}
