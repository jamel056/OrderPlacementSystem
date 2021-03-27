﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using O.Infrastructure.Data;

namespace O.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210327073140_initDbWithAddingOrderFormAndOrderServicesEntities")]
    partial class initDbWithAddingOrderFormAndOrderServicesEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("O.Entities.Entities.OrderForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCarryOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("O.Entities.Entities.OrderServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderFormId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderFormId");

                    b.ToTable("OrderServices");
                });

            modelBuilder.Entity("O.Entities.Entities.OrderServices", b =>
                {
                    b.HasOne("O.Entities.Entities.OrderForm", "OrderForm")
                        .WithMany("OrderServices")
                        .HasForeignKey("OrderFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderForm");
                });

            modelBuilder.Entity("O.Entities.Entities.OrderForm", b =>
                {
                    b.Navigation("OrderServices");
                });
#pragma warning restore 612, 618
        }
    }
}
