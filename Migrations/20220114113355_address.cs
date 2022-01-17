using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
  public partial class address : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "address",
        columns: table => new
        {
          address_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

          address_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          complement = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          district = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          state = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          created_at = table.Column<DateTime>(type: "datetime", nullable: false),

          updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_address", x => x.address_id);
        })
      .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "address");
    }
  }
}