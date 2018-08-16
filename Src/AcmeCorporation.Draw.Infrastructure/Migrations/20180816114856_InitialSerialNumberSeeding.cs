using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.Draw.Infrastructure.Migrations
{
    public partial class InitialSerialNumberSeeding : Migration
    {
        const int InitialNumberOfSerials = 100;

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var seedScript = $@"
                DECLARE @initialNumberOfSeedSerials INT
                SET @initialNumberOfSeedSerials = {InitialNumberOfSerials}
                
                DECLARE @numberOfSerials INT
                SELECT @numberOfSerials = (SELECT COUNT (*) FROM [AcmeCorporationDraw].[dbo].[SerialNumbers])
                
                IF @numberOfSerials < 1
                    DECLARE @i int = 0
                    WHILE @i < @initialNumberOfSeedSerials
                    BEGIN
                        SET @i = @i +1
                
                        DECLARE @serialNumber VARCHAR(25)
                        SELECT @serialNumber = (SELECT LEFT(REPLACE(NEWID(),'-',''),10))
                        INSERT INTO [AcmeCorporationDraw].[dbo].[SerialNumbers] VALUES(@serialNumber, GETDATE(), 0)
                    END";

            migrationBuilder.Sql(seedScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
