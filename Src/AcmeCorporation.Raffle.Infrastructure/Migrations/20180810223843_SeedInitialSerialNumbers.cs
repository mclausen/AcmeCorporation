using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.Raffle.Infrastructure.Migrations
{
    public partial class SeedInitialSerialNumbers : Migration
    {
        private const int InitialNumberOfSerials = 100;
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var seedScript = $@"
                DECLARE @initialNumberOfSeedSerials INT
                SET @initialNumberOfSeedSerials = {InitialNumberOfSerials}
                
                DECLARE @numberOfSerials INT
                SELECT @numberOfSerials = (SELECT COUNT (*) FROM [AcmeCorporationRaffle].[dbo].[SerialNumbers])
                
                IF @numberOfSerials < 1
                    DECLARE @i int = 0
                    WHILE @i < @initialNumberOfSeedSerials
                    BEGIN
                        SET @i = @i +1
                
                        DECLARE @serialNumber VARCHAR(25)
                        SELECT @serialNumber = (SELECT LEFT(REPLACE(NEWID(),'-',''),10))
                        INSERT INTO [AcmeCorporationRaffle].[dbo].[SerialNumbers] VALUES(@serialNumber, GETDATE(), 0)
                    END";

            migrationBuilder.Sql(seedScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
