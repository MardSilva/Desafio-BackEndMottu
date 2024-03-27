using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackend.Mottu.Migrations
{
    /// <inheritdoc />
    public partial class Motorcycle_Rental_and_Delivery_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MottuTablesDeliveryPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CnhNumber = table.Column<string>(type: "text", nullable: false),
                    CnhType = table.Column<string>(type: "text", nullable: false),
                    CnhImageType = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MottuTablesDeliveryPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MottuTablesMotorcycleRentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExpectedEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlanDays = table.Column<int>(type: "integer", nullable: false),
                    DailyRate = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MottuTablesMotorcycleRentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MottuTablesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeliveryPersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MottuTablesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MottuTablesOrders_MottuTablesDeliveryPersons_DeliveryPerson~",
                        column: x => x.DeliveryPersonId,
                        principalTable: "MottuTablesDeliveryPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MottuTablesOrders_DeliveryPersonId",
                table: "MottuTablesOrders",
                column: "DeliveryPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MottuTablesMotorcycleRentals");

            migrationBuilder.DropTable(
                name: "MottuTablesOrders");

            migrationBuilder.DropTable(
                name: "MottuTablesDeliveryPersons");
        }
    }
}
