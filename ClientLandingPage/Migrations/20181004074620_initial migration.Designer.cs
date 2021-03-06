﻿// <auto-generated />
using ClientLandingPage.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientLandingPage.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181004074620_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientLandingPage.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdSource");

                    b.Property<string>("AdType");

                    b.Property<string>("ContactName");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.Property<string>("UploadFile");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
