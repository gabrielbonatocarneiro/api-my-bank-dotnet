using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
  public partial class endereco : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "endereco",
          columns: table => new
          {
            endereco_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            logradouro = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            complemento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            bairro = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            cidade = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            created_at = table.Column<DateTime>(type: "datetime", nullable: false),
            updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_endereco", x => x.endereco_id);
          })
          .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "endereco");
    }
  }
}
