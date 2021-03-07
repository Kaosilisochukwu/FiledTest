﻿// <auto-generated />
using System;
using FiledTest.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiledTest.Domain.Migrations
{
    [DbContext(typeof(PaymentDbContext))]
    partial class PaymentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("FiledTest.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentStateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PaymentStateId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FiledTest.Domain.Models.PaymentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentStates");
                });

            modelBuilder.Entity("FiledTest.Domain.Models.Payment", b =>
                {
                    b.HasOne("FiledTest.Domain.Models.PaymentState", "PaymentState")
                        .WithMany()
                        .HasForeignKey("PaymentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentState");
                });
#pragma warning restore 612, 618
        }
    }
}
