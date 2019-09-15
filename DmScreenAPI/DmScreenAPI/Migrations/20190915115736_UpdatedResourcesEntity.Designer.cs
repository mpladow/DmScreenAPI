﻿// <auto-generated />
using System;
using DmScreenAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DmScreenAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190915115736_UpdatedResourcesEntity")]
    partial class UpdatedResourcesEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DmScreenAPI.Context.Entities.AccountCreatureCard", b =>
                {
                    b.Property<int>("AccountCreatureCardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("CreatureCardId");

                    b.Property<decimal>("Sequence");

                    b.HasKey("AccountCreatureCardId");

                    b.ToTable("AccountCreatureCards");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.AccountNotes", b =>
                {
                    b.Property<int>("AccountNotesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Notes");

                    b.HasKey("AccountNotesId");

                    b.ToTable("AccountNotes");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.AccountResource", b =>
                {
                    b.Property<int>("AccountResourceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("ResourceId");

                    b.Property<decimal>("Sequence");

                    b.HasKey("AccountResourceId");

                    b.ToTable("AccountResources");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.CreatureAction", b =>
                {
                    b.Property<int>("CreatureActionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatureCardId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("CreatureActionId");

                    b.HasIndex("CreatureCardId");

                    b.ToTable("CreatureAction");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.CreatureCard", b =>
                {
                    b.Property<int>("CreatureCardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AC");

                    b.Property<int?>("AccountCreatureCardId");

                    b.Property<bool>("BlueIndicatorOn");

                    b.Property<int?>("Charisma");

                    b.Property<int?>("Constitution");

                    b.Property<int>("CurrentHP");

                    b.Property<int?>("Dexterity");

                    b.Property<bool>("GreenIndicatorOn");

                    b.Property<int>("Initiative");

                    b.Property<int?>("Intelligence");

                    b.Property<int>("MaxHP");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("PInsight");

                    b.Property<int>("PInvestigation");

                    b.Property<int>("PPerception");

                    b.Property<bool>("RedIndicatorOn");

                    b.Property<int?>("Strength");

                    b.Property<int?>("Wisdom");

                    b.Property<bool>("isHostile");

                    b.HasKey("CreatureCardId");

                    b.HasIndex("AccountCreatureCardId");

                    b.ToTable("CreatureCards");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.CreatureCardAction", b =>
                {
                    b.Property<int>("CreatureCardActionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatureActionId");

                    b.Property<int>("CreatureCardId");

                    b.HasKey("CreatureCardActionId");

                    b.ToTable("CreatureCardActions");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountResourceId");

                    b.Property<string>("Category");

                    b.Property<string>("Html");

                    b.HasKey("ResourceId");

                    b.HasIndex("AccountResourceId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("DmScreenAPI.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountCreatureCardId");

                    b.Property<int?>("AccountResourceId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountCreatureCardId");

                    b.HasIndex("AccountResourceId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.CreatureAction", b =>
                {
                    b.HasOne("DmScreenAPI.Context.Entities.CreatureCard")
                        .WithMany("Actions")
                        .HasForeignKey("CreatureCardId");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.CreatureCard", b =>
                {
                    b.HasOne("DmScreenAPI.Context.Entities.AccountCreatureCard")
                        .WithMany("CreatureCards")
                        .HasForeignKey("AccountCreatureCardId");
                });

            modelBuilder.Entity("DmScreenAPI.Context.Entities.Resource", b =>
                {
                    b.HasOne("DmScreenAPI.Context.Entities.AccountResource")
                        .WithMany("Resources")
                        .HasForeignKey("AccountResourceId");
                });

            modelBuilder.Entity("DmScreenAPI.Entities.Account", b =>
                {
                    b.HasOne("DmScreenAPI.Context.Entities.AccountCreatureCard")
                        .WithMany("Resources")
                        .HasForeignKey("AccountCreatureCardId");

                    b.HasOne("DmScreenAPI.Context.Entities.AccountResource")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountResourceId");
                });
#pragma warning restore 612, 618
        }
    }
}
