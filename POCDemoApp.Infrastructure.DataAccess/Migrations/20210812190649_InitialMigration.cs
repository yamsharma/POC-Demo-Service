using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace POCDemoApp.Infrastructure.DataAccess.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "fnl",
				columns: table => new
				{
					fnl_key = table.Column<long>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					fnl_lname = table.Column<string>(maxLength: 50, nullable: false),
					fnl_fname = table.Column<string>(maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_fnl", x => x.fnl_key);
				});

			migrationBuilder.CreateTable(
				name: "doc",
				columns: table => new
				{
					doc_key = table.Column<long>(nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					doc_reference = table.Column<string>(maxLength: 80, nullable: false),
					doc_fk_key = table.Column<long>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_doc", x => x.doc_key);
					table.ForeignKey(
						name: "FK_doc_fnl_doc_fk_key",
						column: x => x.doc_fk_key,
						principalTable: "fnl",
						principalColumn: "fnl_key",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_doc_doc_fk_key",
				table: "doc",
				column: "doc_fk_key");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "doc");

			migrationBuilder.DropTable(
				name: "fnl");
		}
	}
}
