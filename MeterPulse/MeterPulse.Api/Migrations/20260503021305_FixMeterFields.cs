using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterPulse.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixMeterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitiude",
                table: "Meters");

            migrationBuilder.AlterColumn<string>(
                name: "WaterBodyType",
                table: "Meters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Meters",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Meters",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeatherObservationId",
                table: "Meters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeatherStationReference",
                table: "Meters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BreachEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meters_WeatherObservationId",
                table: "Meters",
                column: "WeatherObservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meters_WeatherObservations_WeatherObservationId",
                table: "Meters",
                column: "WeatherObservationId",
                principalTable: "WeatherObservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meters_WeatherObservations_WeatherObservationId",
                table: "Meters");

            migrationBuilder.DropIndex(
                name: "IX_Meters_WeatherObservationId",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "WeatherObservationId",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "WeatherStationReference",
                table: "Meters");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BreachEvents");

            migrationBuilder.AlterColumn<string>(
                name: "WaterBodyType",
                table: "Meters",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Meters",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitiude",
                table: "Meters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
