using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedImagesColumnToVehicleMake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 7);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "VehicleMakes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 1,
                column: "ImageData",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 2,
                column: "ImageData",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 3,
                column: "ImageData",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "VehicleMakes",
                keyColumn: "VehicleMakeId",
                keyValue: 4,
                column: "ImageData",
                value: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "VehicleMakes");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AddedDateTime", "BodyTypeId", "Description", "DrivetrainId", "EngineId", "ExteriorColor", "Features", "FuelTypeId", "InteriorColor", "IsSold", "LastUpdatedDateTime", "MakeId", "Mileage", "ModelId", "NumberOfDoors", "NumberOfOwners", "Price", "SeatingCapacity", "Slug", "TransmissionId", "Trim", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reliable midsize sedan with advanced safety features", 1, 1, "White", "Backup Camera, Bluetooth, Lane Departure Warning", 1, "Black", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15000, 1, 4, 1, 24999.99m, 5, "toyota-camry-2022-se", 2, "SE", "JT123456789012345", 2022 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Powerful pickup truck with towing package", 2, 2, "Blue", "Tow Package, Bluetooth, Rear Parking Sensors", 2, "Gray", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 40000, 4, 2, 2, 35999.99m, 3, "ford-f150-2019-xl", 2, "XL", "1FTFW1EF1KFB12345", 2019 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Compact car with sporty handling", 1, 3, "Red", "Sunroof, Apple CarPlay, Heated Seats", 1, "Beige", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 12000, 6, 4, 1, 19999.99m, 5, "honda-civic-2020-ex", 3, "EX", "2HGFC2F59LH123456", 2020 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Full-size pickup with off-road capability", 2, 4, "Black", "4WD, Navigation, Bluetooth", 1, "Gray", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 55000, 8, 4, 2, 28999.99m, 5, "chevrolet-silverado-2018-lt", 2, "LT", "3GCUKREC7JG123456", 2018 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Compact SUV with fuel efficiency", 1, 1, "Silver", "Blind Spot Monitor, Apple CarPlay, Heated Seats", 1, "Black", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8000, 3, 4, 1, 30500.00m, 5, "toyota-rav4-2021-xle", 2, "XLE", "JTMRWRFV0MD123456", 2021 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Performance coupe with V8 engine", 1, 5, "Red", "Leather Seats, Performance Package, Bluetooth", 1, "Black", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 30000, 5, 2, 1, 27999.99m, 4, "ford-mustang-2017-gt", 1, "GT", "1FA6P8CF3H1234567", 2017 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Midsize sedan with sporty design", 1, 3, "Gray", "Apple CarPlay, Remote Start, Sunroof", 1, "Black", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25000, 7, 4, 1, 21999.99m, 5, "honda-accord-2019-sport", 3, "Sport", "1HGCV1F39KA123456", 2019 }
                });
        }
    }
}
