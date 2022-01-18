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

          user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),

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
          table.ForeignKey(
            name: "FK_address_user_user_id",
            column: x => x.user_id,
            principalTable: "user",
            principalColumn: "user_id",
            onDelete: ReferentialAction.Cascade);
        })
      .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateIndex(
        name: "IX_address_user_id",
        table: "address",
        column: "user_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "address");
    }
  }
}