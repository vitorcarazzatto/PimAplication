using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PimAplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(256)", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONE_TIPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE_TIPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(256)", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOA_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    ddd = table.Column<int>(type: "integer", nullable: false),
                    TipoTelefoneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TELEFONE_TELEFONE_TIPO_TipoTelefoneId",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TELEFONE_TIPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA_TELEFONE",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(type: "integer", nullable: false),
                    ID_TELEFONE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA_TELEFONE", x => new { x.ID_PESSOA, x.ID_TELEFONE });
                    table.ForeignKey(
                        name: "FK_PESSOA_TELEFONE_PESSOA_ID_PESSOA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PESSOA_TELEFONE_TELEFONE_ID_TELEFONE",
                        column: x => x.ID_TELEFONE,
                        principalTable: "TELEFONE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_EnderecoId",
                table: "PESSOA",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_TELEFONE_ID_TELEFONE",
                table: "PESSOA_TELEFONE",
                column: "ID_TELEFONE");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_TipoTelefoneId",
                table: "TELEFONE",
                column: "TipoTelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOA_TELEFONE");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "TELEFONE");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "TELEFONE_TIPO");
        }
    }
}
