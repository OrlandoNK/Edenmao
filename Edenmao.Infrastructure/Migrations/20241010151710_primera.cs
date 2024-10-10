using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edenmao.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Personificacions",
                columns: table => new
                {
                    IDPersonificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personificacions", x => x.IDPersonificacion);
                });

            migrationBuilder.CreateTable(
                name: "Roless",
                columns: table => new
                {
                    IDRolUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roless", x => x.IDRolUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Articulose",
                columns: table => new
                {
                    IDArticulo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IDcategoria = table.Column<int>(type: "int", nullable: false),
                    IDPersonificacion = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulose", x => x.IDArticulo);
                    table.ForeignKey(
                        name: "FK_Articulose_Categorias_IDCategoria",
                        column: x => x.IDCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IDCategoria");
                    table.ForeignKey(
                        name: "FK_Articulose_Personificacions_IDPersonificacion",
                        column: x => x.IDPersonificacion,
                        principalTable: "Personificacions",
                        principalColumn: "IDPersonificacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarioss",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    IDRolUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarioss", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarioss_Roless_IDRolUsuario",
                        column: x => x.IDRolUsuario,
                        principalTable: "Roless",
                        principalColumn: "IDRolUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientess",
                columns: table => new
                {
                    IDClientes = table.Column<int>(type: "int", nullable: false),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientess", x => x.IDClientes);
                    table.ForeignKey(
                        name: "FK_Clientess_Usuarioss_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarioss",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidoss",
                columns: table => new
                {
                    IDPedidos = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalDescuento = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalItbis = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    FechaEmisión = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidoss", x => x.IDPedidos);
                    table.ForeignKey(
                        name: "FK_Pedidoss_Clientess_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientess",
                        principalColumn: "IDClientes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos_Articulos",
                columns: table => new
                {
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    IDArticulo = table.Column<int>(type: "int", nullable: false),
                    IDDetalleArticulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos_Articulos", x => new { x.IDPedido, x.IDArticulo });
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Articulos_Articulose_IDArticulo",
                        column: x => x.IDArticulo,
                        principalTable: "Articulose",
                        principalColumn: "IDArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Articulos_Pedidoss_IDPedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedidoss",
                        principalColumn: "IDPedidos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidoss",
                columns: table => new
                {
                    IDDetallePedido = table.Column<int>(type: "int", nullable: false),
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Itbis = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidoss", x => x.IDDetallePedido);
                    table.ForeignKey(
                        name: "FK_DetallePedidoss_Pedidoss_IDPedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedidoss",
                        principalColumn: "IDPedidos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulose_IDCategoria",
                table: "Articulose",
                column: "IDCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulose_IDPersonificacion",
                table: "Articulose",
                column: "IDPersonificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Clientess_IDUsuario",
                table: "Clientess",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_Articulos_IDArticulo",
                table: "DetallePedidos_Articulos",
                column: "IDArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidoss_IDPedido",
                table: "DetallePedidoss",
                column: "IDPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidoss_IDCliente",
                table: "Pedidoss",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarioss_IDRolUsuario",
                table: "Usuarioss",
                column: "IDRolUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos_Articulos");

            migrationBuilder.DropTable(
                name: "DetallePedidoss");

            migrationBuilder.DropTable(
                name: "Articulose");

            migrationBuilder.DropTable(
                name: "Pedidoss");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Personificacions");

            migrationBuilder.DropTable(
                name: "Clientess");

            migrationBuilder.DropTable(
                name: "Usuarioss");

            migrationBuilder.DropTable(
                name: "Roless");
        }
    }
}
