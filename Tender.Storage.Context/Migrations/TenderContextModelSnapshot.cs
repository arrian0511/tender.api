using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tender.Storage.Context;

namespace Tender.Storage.Context.Migrations
{
    [DbContext(typeof(TenderContext))]
    partial class TenderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tender.Models.Bidder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Credentials");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TenderTaskId");

                    b.HasKey("Id");

                    b.HasIndex("TenderTaskId");

                    b.ToTable("Bidders");
                });

            modelBuilder.Entity("Tender.Models.TenderOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Organization");

                    b.HasKey("Id");

                    b.ToTable("TenderOwners");
                });

            modelBuilder.Entity("Tender.Models.TenderTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentBid");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FinalBid");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Requirements");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("TenderTasks");
                });

            modelBuilder.Entity("Tender.Models.Bidder", b =>
                {
                    b.HasOne("Tender.Models.TenderTask")
                        .WithMany("Bidders")
                        .HasForeignKey("TenderTaskId");
                });

            modelBuilder.Entity("Tender.Models.TenderTask", b =>
                {
                    b.HasOne("Tender.Models.TenderOwner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });
        }
    }
}
