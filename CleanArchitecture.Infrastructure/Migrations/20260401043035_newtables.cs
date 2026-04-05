using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_CustomerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_OrderId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Courses",
                newName: "IX_Courses_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_CustomerId",
                table: "Courses",
                column: "CustomerId",
                principalTable: "Students",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_OrderId",
                table: "StudentCourses",
                column: "OrderId",
                principalTable: "Courses",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
