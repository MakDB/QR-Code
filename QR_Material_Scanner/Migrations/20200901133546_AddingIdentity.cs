using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QR_Material_Scanner.Migrations
{
    public partial class AddingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_Material_Information",
                columns: table => new
                {
                    Serial_Number = table.Column<string>(nullable: false),
                    Material_Number = table.Column<string>(nullable: false),
                    Vendor_Number = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    Product_Description = table.Column<string>(nullable: true),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Machine_ID = table.Column<string>(nullable: true),
                    Capturing_Date = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modification_Date = table.Column<DateTime>(nullable: true),
                    Cancelled = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Material_Information", x => new { x.Serial_Number, x.Material_Number, x.Vendor_Number });
                });

            migrationBuilder.CreateTable(
                name: "result_Material",
                columns: table => new
                {
                    Serial_Number = table.Column<string>(nullable: false),
                    Status_Code = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result_Material", x => x.Serial_Number);
                });

            migrationBuilder.CreateTable(
                name: "tran_Delivery_Information",
                columns: table => new
                {
                    Delivery_Number = table.Column<string>(nullable: false),
                    Line_Item_Number = table.Column<string>(nullable: false),
                    Customer_Number = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true),
                    Shipping_Point = table.Column<string>(nullable: true),
                    Storage_Location = table.Column<string>(nullable: true),
                    Material_Number = table.Column<string>(nullable: true),
                    Quantity_To_Be_Picked = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sales_Order_Number = table.Column<string>(nullable: true),
                    Document_Date = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tran_Delivery_Information", x => new { x.Delivery_Number, x.Line_Item_Number });
                });

            migrationBuilder.CreateTable(
                name: "tran_GR_Information",
                columns: table => new
                {
                    GR_Number = table.Column<string>(nullable: false),
                    Line_Item_Number = table.Column<string>(nullable: false),
                    Material_Number = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true),
                    Storage_Location = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    PO_Number = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GR_Date = table.Column<DateTime>(nullable: false),
                    Document_Date = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tran_GR_Information", x => new { x.GR_Number, x.Line_Item_Number });
                });

            migrationBuilder.CreateTable(
                name: "tran_Material_Transaction",
                columns: table => new
                {
                    Serial_Number = table.Column<string>(nullable: false),
                    Transaction_Type = table.Column<string>(nullable: false),
                    Document_No = table.Column<string>(nullable: false),
                    Line_Item_Number = table.Column<int>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Storage_Location = table.Column<string>(nullable: true),
                    Ref_Doc_No = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    QA_Status = table.Column<string>(nullable: true),
                    Scrap = table.Column<string>(nullable: true),
                    Cancellation_Indicator = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modification_Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tran_Material_Transaction", x => new { x.Serial_Number, x.Transaction_Type, x.Document_No, x.Line_Item_Number });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "mst_Material_Information");

            migrationBuilder.DropTable(
                name: "result_Material");

            migrationBuilder.DropTable(
                name: "tran_Delivery_Information");

            migrationBuilder.DropTable(
                name: "tran_GR_Information");

            migrationBuilder.DropTable(
                name: "tran_Material_Transaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
