using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikasi_Pengajuan_Cuti.Migrations
{
    public partial class secmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "division",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_division = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_division", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_cuti = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pegawai",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama_pegawai = table.Column<string>(nullable: true),
                    id_division = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pegawai", x => x.id);
                    table.ForeignKey(
                        name: "FK_pegawai_division_id_division",
                        column: x => x.id_division,
                        principalTable: "division",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cuti",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pegawai = table.Column<int>(nullable: false),
                    alasan = table.Column<string>(nullable: true),
                    id_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuti", x => x.id);
                    table.ForeignKey(
                        name: "FK_cuti_pegawai_id_pegawai",
                        column: x => x.id_pegawai,
                        principalTable: "pegawai",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cuti_status_id_status",
                        column: x => x.id_status,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuti_id_pegawai",
                table: "cuti",
                column: "id_pegawai");

            migrationBuilder.CreateIndex(
                name: "IX_cuti_id_status",
                table: "cuti",
                column: "id_status");

            migrationBuilder.CreateIndex(
                name: "IX_pegawai_id_division",
                table: "pegawai",
                column: "id_division");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuti");

            migrationBuilder.DropTable(
                name: "pegawai");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "division");
        }
    }
}
