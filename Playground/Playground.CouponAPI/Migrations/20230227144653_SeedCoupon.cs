using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playground.CouponAPI.Migrations
{
    public partial class SeedCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount_amount",
                table: "coupon",
                newName: "discount_amount");

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { 1L, "marcanaster_10", 10m });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { 2L, "marcanaster_15", 15m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "discount_amount",
                table: "coupon",
                newName: "Discount_amount");
        }
    }
}
