using SharpMigrations;

namespace Oficina.Migrador.Migracoes
{
    public class Migracao_0002_AddTable_Carro : SchemaMigration
    {
        public override void Up()
        {
            Add.Table("Carro")
                .WithColumns(
                Column.Int64("Id").NotNull(),
                Column.Int64("Cliente").NotNull(),
                Column.String("Placa", 10).NotNull(),
                Column.String("Marca", 100).NotNull(),
                Column.String("Modelo", 100).NotNull(),
                Column.Int16("Ano").NotNull(),
                Column.String("Cor", 100).NotNull(),
                Column.String("Motor", 100).NotNull()
                );

            Add.PrimaryKey("PK_Carro").OnColumns("Id").OfTable("Carro");
            Add.ForeignKey("FK_Carro_Cliente")
                .OnColumn("Cliente").OfTable("Carro")
                .ReferencingColumn("Id").OfTable("Cliente")
                .OnDeleteNoAction();
        }

        public override void Down()
        {
            Remove.ForeignKey("FK_Carro_Cliente");
            Remove.PrimaryKey("PK_Carro");
            Remove.Table("Cliente");
        }
    }
}
