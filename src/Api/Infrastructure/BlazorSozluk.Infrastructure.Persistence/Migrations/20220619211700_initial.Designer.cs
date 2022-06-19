﻿// <auto-generated />
using System;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorSozluk.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BlazorSozlukContext))]
    [Migration("20220619211700_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EmailConfirmation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 773, DateTimeKind.Utc).AddTicks(9));

                    b.Property<string>("NewEmailAdress")
                        .HasColumnType("text");

                    b.Property<string>("OldEmailAdress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("emailconfirmation", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 773, DateTimeKind.Utc).AddTicks(845));

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("entry", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 773, DateTimeKind.Utc).AddTicks(8277));

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryId");

                    b.ToTable("entrycomment", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 774, DateTimeKind.Utc).AddTicks(923));

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("entrycommentfavorite", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 774, DateTimeKind.Utc).AddTicks(4770));

                    b.Property<Guid>("EntryCommentId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoteType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntryCommentId");

                    b.ToTable("entrycommentvote", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 773, DateTimeKind.Utc).AddTicks(2621));

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EntryId");

                    b.ToTable("entryfavorite", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryVote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 773, DateTimeKind.Utc).AddTicks(6587));

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoteType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("entryvote", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 19, 21, 17, 0, 774, DateTimeKind.Utc).AddTicks(6393));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("user", "dbo");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.Entry", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("Entries")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.User", "CreatedBy")
                        .WithMany("EntryComments")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorSozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryComments")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryCommentFavorite", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.User", "CreatedUser")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlazorSozluk.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentFavorites")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryCommentVote", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.EntryComment", "EntryComment")
                        .WithMany("EntryCommentVotes")
                        .HasForeignKey("EntryCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryComment");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryFavorite", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.User", "CreatedUser")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlazorSozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryFavorites")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryVote", b =>
                {
                    b.HasOne("BlazorSozluk.Api.Domain.Models.Entry", "Entry")
                        .WithMany("EntryVotes")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.Entry", b =>
                {
                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");

                    b.Navigation("EntryVotes");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.EntryComment", b =>
                {
                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryCommentVotes");
                });

            modelBuilder.Entity("BlazorSozluk.Api.Domain.Models.User", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("EntryCommentFavorites");

                    b.Navigation("EntryComments");

                    b.Navigation("EntryFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
