﻿// <auto-generated />
using System;
using Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auction.LotsArchiveMicroservice.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Lot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsUnpurchased")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("RepurchasePrice")
                        .HasColumnType("money");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("_repurchasedLotId")
                        .HasColumnType("uuid")
                        .HasColumnName("RepurchasedLotId");

                    b.Property<Guid?>("_withdrawnLotId")
                        .HasColumnType("uuid")
                        .HasColumnName("WithdrawnLotId");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeletedSoftly")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.RepurchasedLot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("_lotId")
                        .HasColumnType("uuid")
                        .HasColumnName("LotId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("_lotId")
                        .IsUnique();

                    b.ToTable("RepurchasedLots");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.WithdrawnLot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("_lotId")
                        .HasColumnType("uuid")
                        .HasColumnName("LotId");

                    b.HasKey("Id");

                    b.HasIndex("_lotId")
                        .IsUnique();

                    b.ToTable("WithdrawnLots");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Buyer", b =>
                {
                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Person", "PersonInfo")
                        .WithOne("BuyerInfo")
                        .HasForeignKey("Auction.LotsArchiveMicroservice.Domain.Entities.Buyer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Lot", b =>
                {
                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Seller", "Seller")
                        .WithMany("_allLots")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Auction.Common.Domain.ValueObjects.String.Text", "Description", b1 =>
                        {
                            b1.Property<Guid>("LotId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Description");

                            b1.HasKey("LotId");

                            b1.ToTable("Lots");

                            b1.WithOwner()
                                .HasForeignKey("LotId");
                        });

                    b.OwnsOne("Auction.Common.Domain.ValueObjects.String.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("LotId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Title");

                            b1.HasKey("LotId");

                            b1.ToTable("Lots");

                            b1.WithOwner()
                                .HasForeignKey("LotId");
                        });

                    b.OwnsOne("Auction.Common.Domain.ValueObjects.Numeric.Price", "BidIncrement", b1 =>
                        {
                            b1.Property<Guid>("LotId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Value")
                                .HasColumnType("money")
                                .HasColumnName("BidIncrement");

                            b1.HasKey("LotId");

                            b1.ToTable("Lots");

                            b1.WithOwner()
                                .HasForeignKey("LotId");
                        });

                    b.OwnsOne("Auction.Common.Domain.ValueObjects.Numeric.Price", "StartingPrice", b1 =>
                        {
                            b1.Property<Guid>("LotId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Value")
                                .HasColumnType("money")
                                .HasColumnName("StartingPrice");

                            b1.HasKey("LotId");

                            b1.ToTable("Lots");

                            b1.WithOwner()
                                .HasForeignKey("LotId");
                        });

                    b.Navigation("BidIncrement")
                        .IsRequired();

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Seller");

                    b.Navigation("StartingPrice")
                        .IsRequired();

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Person", b =>
                {
                    b.OwnsOne("Auction.Common.Domain.ValueObjects.String.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)")
                                .HasColumnName("Username");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.RepurchasedLot", b =>
                {
                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Buyer", "Buyer")
                        .WithMany("_boughtLots")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Lot", "Lot")
                        .WithOne("RepurchasedLot")
                        .HasForeignKey("Auction.LotsArchiveMicroservice.Domain.Entities.RepurchasedLot", "_lotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Auction.Common.Domain.ValueObjects.Numeric.Price", "HammerPrice", b1 =>
                        {
                            b1.Property<Guid>("RepurchasedLotId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Value")
                                .HasColumnType("money")
                                .HasColumnName("HammerPrice");

                            b1.HasKey("RepurchasedLotId");

                            b1.ToTable("RepurchasedLots");

                            b1.WithOwner()
                                .HasForeignKey("RepurchasedLotId");
                        });

                    b.Navigation("Buyer");

                    b.Navigation("HammerPrice")
                        .IsRequired();

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Seller", b =>
                {
                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Person", "PersonInfo")
                        .WithOne("SellerInfo")
                        .HasForeignKey("Auction.LotsArchiveMicroservice.Domain.Entities.Seller", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.WithdrawnLot", b =>
                {
                    b.HasOne("Auction.LotsArchiveMicroservice.Domain.Entities.Lot", "Lot")
                        .WithOne("WithdrawnLot")
                        .HasForeignKey("Auction.LotsArchiveMicroservice.Domain.Entities.WithdrawnLot", "_lotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lot");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Buyer", b =>
                {
                    b.Navigation("_boughtLots");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Lot", b =>
                {
                    b.Navigation("RepurchasedLot");

                    b.Navigation("WithdrawnLot");
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Person", b =>
                {
                    b.Navigation("BuyerInfo")
                        .IsRequired();

                    b.Navigation("SellerInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("Auction.LotsArchiveMicroservice.Domain.Entities.Seller", b =>
                {
                    b.Navigation("_allLots");
                });
#pragma warning restore 612, 618
        }
    }
}
