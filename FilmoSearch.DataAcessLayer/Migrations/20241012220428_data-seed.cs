using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmoSearch.DataAcessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1912641810, "Rachelle", "Schaden" },
                    { 966366263, "Petra", "Steuber" },
                    { 977980276, "Gabriel", "Watsica" },
                    { 1760710029, "Tyrique", "Jerde" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { -1490514713, "Fantastic Soft Salad" },
                    { -1379419950, "Generic Granite Pants" },
                    { -1213682734, "Refined Steel Pants" },
                    { 269060494, "Refined Concrete Sausages" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Description", "FilmId", "Stars", "Title" },
                values: new object[,]
                {
                    { -2103323266, "et", 269060494, 0.003957376782016353, "Ergonomic Frozen Fish" },
                    { -2080311550, "et", -1379419950, 0.5064816304696218, "Fantastic Wooden Ball" },
                    { -1353979155, "omnis", -1379419950, 0.92504622835128292, "Rustic Wooden Salad" },
                    { -1294168547, "quis", -1379419950, 0.84159178801492507, "Awesome Wooden Ball" },
                    { -971406953, "adipisci", -1213682734, 0.56614595293813297, "Handcrafted Plastic Hat" },
                    { -716151508, "ut", 269060494, 0.05004069543974643, "Gorgeous Frozen Tuna" },
                    { -110618787, "esse", -1490514713, 0.28668918037562086, "Rustic Cotton Pizza" },
                    { -69134539, "necessitatibus", 269060494, 0.76273204885580159, "Generic Cotton Chips" },
                    { -39545753, "ut", 269060494, 0.36380697469143852, "Tasty Wooden Soap" },
                    { 1462531681, "reprehenderit", -1490514713, 0.18058125535334324, "Small Rubber Fish" },
                    { 1637512937, "dolores", -1213682734, 0.12774875711702571, "Awesome Concrete Mouse" },
                    { 1989534010, "assumenda", -1379419950, 0.088410669657917551, "Intelligent Steel Pants" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: -1912641810);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 966366263);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 977980276);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1760710029);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -2103323266);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -2080311550);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -1353979155);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -1294168547);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -971406953);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -716151508);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -110618787);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -69134539);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: -39545753);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1462531681);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1637512937);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1989534010);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: -1490514713);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: -1379419950);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: -1213682734);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 269060494);
        }
    }
}
