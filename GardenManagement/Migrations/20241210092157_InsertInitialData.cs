using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenManagement.Migrations
{
    /// <inheritdoc />
    public partial class InsertInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Plants values('3a853de2-ceee-47fd-a653-9c2611b56eac', 'Plant1')");
            migrationBuilder.Sql("insert into Plants values('3a853de2-ceee-47fd-a653-9c2611b56ead', 'Plant2')");
            migrationBuilder.Sql("insert into Keepers values('056fcd24-ed30-4d42-8a55-61710289b921', 'Sam')");
            migrationBuilder.Sql("insert into KeeperPlantChart values('056fcd24-ed30-4d42-8a55-61710289b921', '3a853de2-ceee-47fd-a653-9c2611b56eac')");
            migrationBuilder.Sql("insert into KeeperPlantChart values('056fcd24-ed30-4d42-8a55-61710289b921', '3a853de2-ceee-47fd-a653-9c2611b56ead')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Plants where Id = '3a853de2-ceee-47fd-a653-9c2611b56eac'");
            migrationBuilder.Sql("delete from Plants where Id = '3a853de2-ceee-47fd-a653-9c2611b56ead'");
            migrationBuilder.Sql("delete from Keepers where Id = '056fcd24-ed30-4d42-8a55-61710289b921'");
            migrationBuilder.Sql("delete from KeeperPlantChart where KeepersId = '056fcd24-ed30-4d42-8a55-61710289b921'");
        }
    }
}
