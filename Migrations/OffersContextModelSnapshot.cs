﻿// <auto-generated />
using System;
using EFBugReproduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugReproduction.Migrations
{
    [DbContext(typeof(OffersContext))]
    partial class OffersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("EFBugReproduction.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("EFBugReproduction.Offer", b =>
                {
                    b.OwnsOne("EFBugReproduction.ScoreVO", "Score", b1 =>
                        {
                            b1.Property<Guid>("OfferId")
                                .HasColumnType("TEXT");

                            b1.Property<double>("DeliveryTypeScore")
                                .HasColumnType("FLOAT(53)");

                            b1.Property<double>("RandomScore")
                                .HasColumnType("FLOAT(53)");

                            b1.Property<double>("RatingScore")
                                .HasColumnType("FLOAT(53)");

                            b1.Property<double>("Score")
                                .HasColumnType("FLOAT(53)");

                            b1.HasKey("OfferId");

                            b1.ToTable("Offers");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.Navigation("Score");
                });
#pragma warning restore 612, 618
        }
    }
}
