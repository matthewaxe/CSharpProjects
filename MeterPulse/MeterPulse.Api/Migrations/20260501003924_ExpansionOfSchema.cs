using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterPulse.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExpansionOfSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MeterId",
                table: "MeterReadings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FinePerBreach = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvidencePacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidencePacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherObservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StationReference = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Parameter = table.Column<string>(type: "TEXT", nullable: true),
                    ParameterName = table.Column<string>(type: "TEXT", nullable: true),
                    Period = table.Column<int>(type: "INTEGER", nullable: true),
                    UnitName = table.Column<string>(type: "TEXT", nullable: true),
                    Qualifier = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<double>(type: "REAL", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    RawData = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherObservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Latitiude = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    WaterBodyType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meters_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermitLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Parameter = table.Column<string>(type: "TEXT", nullable: false),
                    MinValue = table.Column<double>(type: "REAL", nullable: true),
                    MaxValue = table.Column<double>(type: "REAL", nullable: true),
                    WeatherCondition = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherThresholdMm = table.Column<double>(type: "REAL", nullable: true),
                    FineOverride = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermitLimits_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreachEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermitLimitId = table.Column<int>(type: "INTEGER", nullable: true),
                    Parameter = table.Column<string>(type: "TEXT", nullable: false),
                    StartTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<double>(type: "REAL", nullable: false),
                    FineAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    EvidencePackId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreachEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreachEvents_EvidencePacks_EvidencePackId",
                        column: x => x.EvidencePackId,
                        principalTable: "EvidencePacks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreachEvents_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreachEvents_PermitLimits_PermitLimitId",
                        column: x => x.PermitLimitId,
                        principalTable: "PermitLimits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_MeterId",
                table: "MeterReadings",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_BreachEvents_EvidencePackId",
                table: "BreachEvents",
                column: "EvidencePackId");

            migrationBuilder.CreateIndex(
                name: "IX_BreachEvents_MeterId",
                table: "BreachEvents",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_BreachEvents_PermitLimitId",
                table: "BreachEvents",
                column: "PermitLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_Meters_CompanyId",
                table: "Meters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PermitLimits_MeterId",
                table: "PermitLimits",
                column: "MeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Meters_MeterId",
                table: "MeterReadings",
                column: "MeterId",
                principalTable: "Meters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Meters_MeterId",
                table: "MeterReadings");

            migrationBuilder.DropTable(
                name: "BreachEvents");

            migrationBuilder.DropTable(
                name: "WeatherObservations");

            migrationBuilder.DropTable(
                name: "EvidencePacks");

            migrationBuilder.DropTable(
                name: "PermitLimits");

            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_MeterId",
                table: "MeterReadings");

            migrationBuilder.AlterColumn<string>(
                name: "MeterId",
                table: "MeterReadings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
