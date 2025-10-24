using SharpMigrations;

namespace Oficina.Migrador.Migracoes
{
    public class Migracao_0001_AddTable_Cliente : SchemaMigration
    {
        public override void Up()
        {
            Add.Table("Cliente")
                .WithColumns(
                Column.Int64("Id").NotNull(),
                Column.String("Nome", 100).NotNull(),
                Column.String("Numero", 100)
                );

            Add.PrimaryKey("PK_Cliente").OnColumns("Id").OfTable("Cliente");
        }

        public override void Down()
        {
            Remove.PrimaryKey("PK_Cliente");
            Remove.Table("Cliente");
        }
    }
}
