using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSekolahWithIdentity.Data.Migrations
{
    public partial class chPKSiswa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siswa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NIM = table.Column<int>(nullable: false),
                    Nama = table.Column<string>(maxLength: 100, nullable: true),
                    KelasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siswa_Kelas_KelasId",
                        column: x => x.KelasId,
                        principalTable: "Kelas",
                        principalColumn: "KelasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siswa_KelasId",
                table: "Siswa",
                column: "KelasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siswa");
        }
    }
}
