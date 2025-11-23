using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FIUAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    pk_eventoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.pk_eventoid);
                });

            migrationBuilder.CreateTable(
                name: "mestre",
                columns: table => new
                {
                    pk_mestreid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    senha = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mestre", x => x.pk_mestreid);
                });

            migrationBuilder.CreateTable(
                name: "modalidade",
                columns: table => new
                {
                    pk_modalidadeid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modalidade", x => x.pk_modalidadeid);
                });

            migrationBuilder.CreateTable(
                name: "treinador",
                columns: table => new
                {
                    pk_treinadorid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treinador", x => x.pk_treinadorid);
                });

            migrationBuilder.CreateTable(
                name: "local",
                columns: table => new
                {
                    pk_localid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: true),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    fk_eventoid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local", x => x.pk_localid);
                    table.ForeignKey(
                        name: "FK_local_evento_fk_eventoid",
                        column: x => x.fk_eventoid,
                        principalTable: "evento",
                        principalColumn: "pk_eventoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipe",
                columns: table => new
                {
                    pk_equipeid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fk_mestreid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipe", x => x.pk_equipeid);
                    table.ForeignKey(
                        name: "FK_equipe_mestre_fk_mestreid",
                        column: x => x.fk_mestreid,
                        principalTable: "mestre",
                        principalColumn: "pk_mestreid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "faixa",
                columns: table => new
                {
                    pk_faixaid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fk_modalidadeid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faixa", x => x.pk_faixaid);
                    table.ForeignKey(
                        name: "FK_faixa_modalidade_fk_modalidadeid",
                        column: x => x.fk_modalidadeid,
                        principalTable: "modalidade",
                        principalColumn: "pk_modalidadeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relatorio",
                columns: table => new
                {
                    pk_relatorioid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_treinadorid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relatorio", x => x.pk_relatorioid);
                    table.ForeignKey(
                        name: "FK_relatorio_treinador_fk_treinadorid",
                        column: x => x.fk_treinadorid,
                        principalTable: "treinador",
                        principalColumn: "pk_treinadorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao",
                columns: table => new
                {
                    pk_avaliacaoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    nota = table.Column<decimal>(type: "numeric(4,2)", nullable: false),
                    fk_equipeid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao", x => x.pk_avaliacaoid);
                    table.ForeignKey(
                        name: "FK_avaliacao_equipe_fk_equipeid",
                        column: x => x.fk_equipeid,
                        principalTable: "equipe",
                        principalColumn: "pk_equipeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ct",
                columns: table => new
                {
                    pk_ctid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fk_equipeid = table.Column<long>(type: "bigint", nullable: false),
                    fk_treinadorid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ct", x => x.pk_ctid);
                    table.ForeignKey(
                        name: "FK_ct_equipe_fk_equipeid",
                        column: x => x.fk_equipeid,
                        principalTable: "equipe",
                        principalColumn: "pk_equipeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ct_treinador_fk_treinadorid",
                        column: x => x.fk_treinadorid,
                        principalTable: "treinador",
                        principalColumn: "pk_treinadorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atleta",
                columns: table => new
                {
                    pk_atletaid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    fk_faixaid = table.Column<long>(type: "bigint", nullable: false),
                    fk_ctid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atleta", x => x.pk_atletaid);
                    table.ForeignKey(
                        name: "FK_atleta_ct_fk_ctid",
                        column: x => x.fk_ctid,
                        principalTable: "ct",
                        principalColumn: "pk_ctid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atleta_faixa_fk_faixaid",
                        column: x => x.fk_faixaid,
                        principalTable: "faixa",
                        principalColumn: "pk_faixaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ct_evento",
                columns: table => new
                {
                    pk_ct_eventoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_eventoid = table.Column<long>(type: "bigint", nullable: false),
                    fk_ctid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ct_evento", x => x.pk_ct_eventoid);
                    table.ForeignKey(
                        name: "FK_ct_evento_ct_fk_ctid",
                        column: x => x.fk_ctid,
                        principalTable: "ct",
                        principalColumn: "pk_ctid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ct_evento_evento_fk_eventoid",
                        column: x => x.fk_eventoid,
                        principalTable: "evento",
                        principalColumn: "pk_eventoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    pk_enderecoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "integer", nullable: true),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    fk_ctid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.pk_enderecoid);
                    table.ForeignKey(
                        name: "FK_endereco_ct_fk_ctid",
                        column: x => x.fk_ctid,
                        principalTable: "ct",
                        principalColumn: "pk_ctid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participacao_evento",
                columns: table => new
                {
                    pk_participacaoeventoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_eventoid = table.Column<long>(type: "bigint", nullable: false),
                    fk_atletaid = table.Column<long>(type: "bigint", nullable: false),
                    colocacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participacao_evento", x => x.pk_participacaoeventoid);
                    table.ForeignKey(
                        name: "FK_participacao_evento_atleta_fk_atletaid",
                        column: x => x.fk_atletaid,
                        principalTable: "atleta",
                        principalColumn: "pk_atletaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participacao_evento_evento_fk_eventoid",
                        column: x => x.fk_eventoid,
                        principalTable: "evento",
                        principalColumn: "pk_eventoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_atleta_email",
                table: "atleta",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_atleta_fk_ctid",
                table: "atleta",
                column: "fk_ctid");

            migrationBuilder.CreateIndex(
                name: "IX_atleta_fk_faixaid",
                table: "atleta",
                column: "fk_faixaid");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_fk_equipeid",
                table: "avaliacao",
                column: "fk_equipeid");

            migrationBuilder.CreateIndex(
                name: "IX_ct_fk_equipeid",
                table: "ct",
                column: "fk_equipeid");

            migrationBuilder.CreateIndex(
                name: "IX_ct_fk_treinadorid",
                table: "ct",
                column: "fk_treinadorid");

            migrationBuilder.CreateIndex(
                name: "IX_ct_evento_fk_ctid",
                table: "ct_evento",
                column: "fk_ctid");

            migrationBuilder.CreateIndex(
                name: "IX_ct_evento_fk_eventoid",
                table: "ct_evento",
                column: "fk_eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_fk_ctid",
                table: "endereco",
                column: "fk_ctid");

            migrationBuilder.CreateIndex(
                name: "IX_equipe_fk_mestreid",
                table: "equipe",
                column: "fk_mestreid");

            migrationBuilder.CreateIndex(
                name: "IX_faixa_fk_modalidadeid",
                table: "faixa",
                column: "fk_modalidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_local_fk_eventoid",
                table: "local",
                column: "fk_eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_mestre_email",
                table: "mestre",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_participacao_evento_fk_atletaid",
                table: "participacao_evento",
                column: "fk_atletaid");

            migrationBuilder.CreateIndex(
                name: "IX_participacao_evento_fk_eventoid",
                table: "participacao_evento",
                column: "fk_eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_fk_treinadorid",
                table: "relatorio",
                column: "fk_treinadorid");

            migrationBuilder.CreateIndex(
                name: "IX_treinador_email",
                table: "treinador",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao");

            migrationBuilder.DropTable(
                name: "ct_evento");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "local");

            migrationBuilder.DropTable(
                name: "participacao_evento");

            migrationBuilder.DropTable(
                name: "relatorio");

            migrationBuilder.DropTable(
                name: "atleta");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "ct");

            migrationBuilder.DropTable(
                name: "faixa");

            migrationBuilder.DropTable(
                name: "equipe");

            migrationBuilder.DropTable(
                name: "treinador");

            migrationBuilder.DropTable(
                name: "modalidade");

            migrationBuilder.DropTable(
                name: "mestre");
        }
    }
}
