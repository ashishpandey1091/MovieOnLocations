using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAshishPandey.Models;

namespace DataAshishPandey.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160302043800_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAshishPandey.Models.Location", b =>
                {
                    b.Property<int>("LocationID");

                    b.Property<string>("Country");

                    b.Property<string>("County");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int?>("MovieMovieID");

                    b.Property<string>("Place");

                    b.Property<string>("State");

                    b.Property<string>("StateAbbreviation");

                    b.Property<string>("ZipCode");

                    b.HasKey("LocationID");
                });

            modelBuilder.Entity("DataAshishPandey.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LocationID");

                    b.Property<string>("MovieName")
                        .IsRequired();

                    b.Property<int>("contact");

                    b.Property<string>("emailID");

                    b.Property<int>("numberOfTheaters");

                    b.HasKey("MovieID");
                });

            modelBuilder.Entity("DataAshishPandey.Models.Location", b =>
                {
                    b.HasOne("DataAshishPandey.Models.Movie")
                        .WithMany()
                        .HasForeignKey("MovieMovieID");
                });

            modelBuilder.Entity("DataAshishPandey.Models.Movie", b =>
                {
                    b.HasOne("DataAshishPandey.Models.Location")
                        .WithMany()
                        .HasForeignKey("LocationID");
                });
        }
    }
}
