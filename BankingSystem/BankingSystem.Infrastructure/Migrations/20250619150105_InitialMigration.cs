using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BoardingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MainAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Addresses_MainAddressId",
                        column: x => x.MainAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Addresses_SecondAddressId",
                        column: x => x.SecondAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Direction = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SourceIBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    TargetIBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    ExternalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "CreatedBy", "IsDeleted", "Number", "PostalCode", "Street", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("ef149a3e-2c0f-45ef-b358-908fa8aa431e"), "Sofia", "Bulgaria", new DateTime(2025, 6, 19, 15, 1, 4, 498, DateTimeKind.Utc).AddTicks(2235), null, false, "123", "1000", "Main St.", null, null });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6fd4d239-a763-4ee9-a125-2d5348a0665a"), new DateTime(2025, 6, 19, 15, 1, 4, 497, DateTimeKind.Utc).AddTicks(4278), null, "Administrator role with full permissions.", false, "Admin", null, null },
                    { new Guid("a03cb524-1815-4b14-8ea3-e6a3dd206c48"), new DateTime(2025, 6, 19, 15, 1, 4, 497, DateTimeKind.Utc).AddTicks(4270), null, "Default user role with basic permissions.", false, "NormalUser", null, null }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { new Guid("270c2aff-3a9b-4cdd-8eaf-b77181cc7c9b"), new DateTime(2025, 6, 19, 15, 1, 4, 497, DateTimeKind.Utc).AddTicks(918), "System", "NormalUser@gmail.com", "Normal", false, "User", "4ZTQ/j0CN2KvXIwGoEM2f9rPZ+T09wVc5Ek0JHkIZkP1BeZaYiPNIA2cptImGC+6dX8zBSNRaeIKyOuSgIhaZQ==", "Vox9j92SyA5tFQqDWR+NlUfHsxfqdZ6qD+NcGxiVbnEXlBD02TnbbLz/y64dwBWS/xAikghVRVwKlcts5XLnbfbbm7uuB9WjC1eTpV2j7180bOwHe/NFYDpVNH7fwj3Bn6p/wYv2XOEH2mXTIDeEufhHFZOtvJtP/cQrkF/zyzg=", "0987654321", null, null, "NormalUser" },
                    { new Guid("e12bde0e-828c-409b-8087-84450617dcd8"), new DateTime(2025, 6, 19, 15, 1, 4, 497, DateTimeKind.Utc).AddTicks(812), "System", "SysAdmin@gmail.com", "Sys", false, "Admin", "XMb6cl4NnZEV4mNQCGoLCJ0aU/H//ZK1IAIcyxvZvAOUaVoTyZAB+ZBpQz9fhZQCtSvjdHg5yjxDQB7DyeEScw==", "VEyOlH78ICKzMbFs/99lHZ+XmWsVSw1XoQ2O9ymigRcLE8aBf8Ebq4rBEh1kcsYZqJHs2+MSQE83m5X8Q8aEWzbqgizJ1kYB8rKN7gT+GSFQ9u7Mmal7MyCraMYe0s3BVshqO4FO1Y0gQkWVtL+6CWnfAWwZOF+x7iMcQsbXp1U=", "1234567890", null, null, "SysAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("bf9b7e93-aa9a-4686-b770-b6184245514e"), new DateTime(2025, 6, 19, 15, 1, 4, 501, DateTimeKind.Utc).AddTicks(3546), null, false, "Acme Financial Group", null, null });

            migrationBuilder.InsertData(
                table: "ApplicationUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a03cb524-1815-4b14-8ea3-e6a3dd206c48"), new Guid("270c2aff-3a9b-4cdd-8eaf-b77181cc7c9b") },
                    { new Guid("6fd4d239-a763-4ee9-a125-2d5348a0665a"), new Guid("e12bde0e-828c-409b-8087-84450617dcd8") }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "BoardingDate", "Country", "CreatedAt", "CreatedBy", "IsDeleted", "MainAddressId", "Name", "PartnerId", "SecondAddressId", "URL", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("1c751a11-50a3-4574-b65d-ca3272b13fd5"), new DateTime(2025, 6, 19, 15, 1, 4, 501, DateTimeKind.Utc).AddTicks(1046), "Bulgaria", new DateTime(2025, 6, 19, 15, 1, 4, 501, DateTimeKind.Utc).AddTicks(1021), null, false, new Guid("ef149a3e-2c0f-45ef-b358-908fa8aa431e"), "Acme Online Store", new Guid("bf9b7e93-aa9a-4686-b770-b6184245514e"), null, "https://acmestore.com", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoles_Name",
                table: "ApplicationRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_MainAddressId",
                table: "Merchants",
                column: "MainAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_PartnerId",
                table: "Merchants",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_SecondAddressId",
                table: "Merchants",
                column: "SecondAddressId",
                unique: true,
                filter: "[SecondAddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MerchantId",
                table: "Transactions",
                column: "MerchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
