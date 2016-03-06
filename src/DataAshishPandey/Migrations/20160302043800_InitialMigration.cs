using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace DataAshishPandey.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    MovieMovieID = table.Column<int>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StateAbbreviation = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationID = table.Column<int>(nullable: true),
                    MovieName = table.Column<string>(nullable: false),
                    contact = table.Column<int>(nullable: false),
                    emailID = table.Column<string>(nullable: true),
                    numberOfTheaters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movie_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Location_Movie_MovieMovieID",
                table: "Location",
                column: "MovieMovieID",
                principalTable: "Movie",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Movie_Location_LocationID", table: "Movie");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("Movie");
        }
    }
}
