using Microsoft.EntityFrameworkCore.Migrations;

namespace ClowlWebApp.Data.Migrations
{
    public partial class AddCreatorRole : Migration
    {
        const string CREATOR_ROLE_GUID = "31b75525-05d1-454d-ac64-0b690a5c0ce9";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{CREATOR_ROLE_GUID}','Creator','CREATOR')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{CREATOR_ROLE_GUID}'");
        }
    }
}
