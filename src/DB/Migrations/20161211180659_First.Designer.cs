using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DB;

namespace DB.Migrations
{
    [DbContext(typeof(TripleBDbContext))]
    [Migration("20161211180659_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountType");

                    b.Property<int>("Cash");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("RentId");

                    b.Property<bool>("Status");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Models.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoatType");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("ModelId");

                    b.Property<int>("OwnerId");

                    b.Property<int>("Speed");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("Models.BoatModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Height");

                    b.Property<string>("Length");

                    b.Property<string>("ManufacturerName");

                    b.Property<string>("Name");

                    b.Property<string>("Width");

                    b.HasKey("Id");

                    b.ToTable("BoatModels");
                });

            modelBuilder.Entity("Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Preview");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Models.Recall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoatId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("Recalls");
                });

            modelBuilder.Entity("Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoatId");

                    b.Property<DateTime>("From");

                    b.Property<DateTime>("To");

                    b.HasKey("Id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Models.TextBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerId");

                    b.Property<int>("Rank");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("NewsTexts");
                });
        }
    }
}
