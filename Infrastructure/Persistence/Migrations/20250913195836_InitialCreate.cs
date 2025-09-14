using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZK.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    BodyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.BodyTypeId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Drivetrains",
                columns: table => new
                {
                    DrivetrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivetrains", x => x.DrivetrainId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    VehicleMakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.VehicleMakeId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "VehicleMakeId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    ExteriorColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    DrivetrainId = table.Column<int>(type: "int", nullable: false),
                    NumberOfOwners = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Vehicles_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "BodyTypeId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivetrains_DrivetrainId",
                        column: x => x.DrivetrainId,
                        principalTable: "Drivetrains",
                        principalColumn: "DrivetrainId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId");
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "TransmissionId");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "VehicleMakeId");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId");
                });

            migrationBuilder.CreateTable(
                name: "SaleHistories",
                columns: table => new
                {
                    SaleHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SaleDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhoneNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleHistories", x => x.SaleHistoryId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SaleHistories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    VehicleImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.VehicleImageId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "BodyTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A passenger car in a three-box configuration with separate compartments for engine, passenger, and cargo.", "Sedan" },
                    { 2, "Vehicle with an open cargo area and passenger cab, used for hauling.", "Pickup Truck" },
                    { 3, "Sport Utility Vehicle combining off-road capability with passenger comfort.", "SUV" },
                    { 4, "A two-door car with a fixed roof and sporty design.", "Coupe" },
                    { 5, "Compact car with a rear door that swings upward to provide access to cargo area.", "Hatchback" },
                    { 6, "Car with a roof structure that can be 'converted' to allow open-air or enclosed driving.", "Convertible" },
                    { 7, "A van designed for personal use, especially for families.", "Minivan" },
                    { 8, "A car with an extended rear cargo area, accessed via a rear door or hatch.", "Station Wagon" },
                    { 9, "A larger vehicle used for transporting goods or groups of people.", "Van" },
                    { 10, "Vehicle built on a car platform combining features of a hatchback and SUV.", "Crossover" }
                });

            migrationBuilder.InsertData(
                table: "Drivetrains",
                columns: new[] { "DrivetrainId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Power delivered to the front wheels, typical for fuel-efficient vehicles.", "Front-Wheel Drive (FWD)" },
                    { 2, "Power delivered to the rear wheels, preferred for performance and towing.", "Rear-Wheel Drive (RWD)" },
                    { 3, "Power automatically distributed to all wheels for better traction.", "All-Wheel Drive (AWD)" },
                    { 4, "Driver-selectable power distributed to all four wheels, for off-road driving.", "Four-Wheel Drive (4WD)" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "EngineId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Reliable 2.5 liter inline 4-cylinder engine, suitable for everyday driving.", "2.5L Inline 4 Cylinder" },
                    { 2, "Powerful 3.5 liter V6 engine for enhanced performance.", "3.5L V6" },
                    { 3, "Turbocharged 2.0 liter inline 4-cylinder engine with improved acceleration.", "2.0L Turbo Inline 4" },
                    { 4, "Large 5.3 liter V8 engine, commonly used in trucks and SUVs for towing.", "5.3L V8" },
                    { 5, "High-performance 5.0 liter V8 engine for sports vehicles.", "5.0L V8" },
                    { 6, "Fuel-efficient 1.5 liter turbocharged inline 4-cylinder engine.", "1.5L Turbo Inline 4" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "FuelTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Standard gasoline fuel used in most combustion engines.", "Gasoline" },
                    { 2, "Diesel fuel offering higher efficiency and torque for heavy-duty vehicles.", "Diesel" },
                    { 3, "Combination of gasoline engine and electric motor for improved fuel economy.", "Hybrid" },
                    { 4, "Fully electric powertrain using battery stored energy.", "Electric" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "TransmissionId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Requires driver to manually change gears using clutch and gear lever.", "Manual" },
                    { 2, "Automatically changes gears without driver input for convenience.", "Automatic" },
                    { 3, "Delivers smooth acceleration with a seamless range of gear ratios.", "Continuously Variable Transmission (CVT)" },
                    { 4, "Offers quick, efficient gear changes with two separate clutches.", "Dual-Clutch Automatic" },
                    { 5, "A manual transmission with automated clutch and gear shifts.", "Automated Manual (AMT)" }
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "VehicleMakeId", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "Honda" },
                    { 4, "Chevrolet" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Camry" },
                    { 2, 1, "Corolla" },
                    { 3, 1, "RAV4" },
                    { 4, 2, "F-150" },
                    { 5, 2, "Mustang" },
                    { 6, 3, "Civic" },
                    { 7, 3, "Accord" },
                    { 8, 4, "Silverado" },
                    { 9, 4, "Malibu" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BodyTypes_Name",
                table: "BodyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivetrains_Name",
                table: "Drivetrains",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_Name",
                table: "Engines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_Name",
                table: "FuelTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleHistories_VehicleId",
                table: "SaleHistories",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transmissions_Name",
                table: "Transmissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleId",
                table: "VehicleImages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BodyTypeId",
                table: "Vehicles",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DrivetrainId",
                table: "Vehicles",
                column: "DrivetrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineId",
                table: "Vehicles",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeId",
                table: "Vehicles",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Slug",
                table: "Vehicles",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleHistories");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Drivetrains");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleMakes");
        }
    }
}
