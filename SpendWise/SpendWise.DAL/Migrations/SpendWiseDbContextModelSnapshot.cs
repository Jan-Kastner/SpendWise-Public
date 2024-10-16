﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpendWise.DAL.dbContext;

#nullable disable

namespace SpendWise.DAL.Migrations
{
    [DbContext(typeof(SpendWiseDbContext))]
    partial class SpendWiseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SpendWise.DAL.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_CategoryEntity_Name");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.GroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_GroupEntity_Name");

                    b.ToTable("Groups", t =>
                        {
                            t.HasCheckConstraint("CK_GroupEntity_Name", "\"Name\" IS NOT NULL AND LENGTH(\"Name\") > 0");
                        });
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.GroupUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LimitId")
                        .HasColumnType("uuid");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("IX_GroupUserEntity_GroupId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_GroupUserEntity_UserId");

                    b.HasIndex("UserId", "GroupId")
                        .IsUnique()
                        .HasDatabaseName("IX_GroupUserEntity_Unique_UserId_GroupId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.InvitationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("timestamp(3) with time zone");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("timestamp(3) with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("IX_InvitationEntity_GroupId");

                    b.HasIndex("ReceiverId")
                        .HasDatabaseName("IX_InvitationEntity_ReceiverId");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("IX_InvitationEntity_SenderId");

                    b.HasIndex("SentDate")
                        .HasDatabaseName("IX_InvitationEntity_SentDate");

                    b.ToTable("Invitations", t =>
                        {
                            t.HasCheckConstraint("CK_InvitationEntity_IsAccepted", "\"IsAccepted\" IS NULL OR \"IsAccepted\" IN (true, false)");

                            t.HasCheckConstraint("CK_InvitationEntity_ResponseDate", "\"ResponseDate\" IS NULL OR \"ResponseDate\" >= \"SentDate\"");

                            t.HasCheckConstraint("CK_InvitationEntity_SentDate", "\"SentDate\" <= NOW()");
                        });
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.LimitEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("GroupUserId")
                        .HasColumnType("uuid");

                    b.Property<int>("NoticeType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupUserId")
                        .IsUnique();

                    b.ToTable("Limits", t =>
                        {
                            t.HasCheckConstraint("CK_Limit_Amount", "\"Amount\" >= 0");

                            t.HasCheckConstraint("CK_Limit_NoticeType", "\"NoticeType\" IS NOT NULL");
                        });
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp(3) with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions", t =>
                        {
                            t.HasCheckConstraint("CK_TransactionEntity_Amount", "\"Amount\" > 0");

                            t.HasCheckConstraint("CK_TransactionEntity_Date", "\"Date\" <= NOW()");

                            t.HasCheckConstraint("CK_TransactionEntity_Type", "\"Type\" IS NOT NULL");
                        });
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.TransactionGroupUserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupUserId");

                    b.HasIndex("TransactionId", "GroupUserId")
                        .IsUnique()
                        .HasDatabaseName("IX_TransactionGroupUser_Unique_TransactionId_GroupUserId");

                    b.ToTable("TransactionGroupUsers");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("timestamp(3) with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("EmailConfirmationToken")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("PreferredTheme")
                        .HasColumnType("integer");

                    b.Property<string>("ReinitPasswordToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ReinitPasswordTokenExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ResetPasswordToken")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("ResetPasswordTokenExpiry")
                        .HasColumnType("timestamp(3) with time zone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("TwoFactorSecret")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_UserEntity_Email");

                    b.ToTable("Users", t =>
                        {
                            t.HasCheckConstraint("CK_UserEntity_Date_of_registration", "\"DateOfRegistration\" <= NOW()");

                            t.HasCheckConstraint("CK_UserEntity_Email_Length", "LENGTH(\"Email\") >= 5");

                            t.HasCheckConstraint("CK_UserEntity_Name_Length", "LENGTH(\"Name\") >= 2");

                            t.HasCheckConstraint("CK_UserEntity_PasswordHash_Length", "LENGTH(\"PasswordHash\") >= 8");

                            t.HasCheckConstraint("CK_UserEntity_Surname_Length", "LENGTH(\"Surname\") >= 2");
                        });
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.GroupUserEntity", b =>
                {
                    b.HasOne("SpendWise.DAL.Entities.GroupEntity", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise.DAL.Entities.UserEntity", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.InvitationEntity", b =>
                {
                    b.HasOne("SpendWise.DAL.Entities.GroupEntity", "Group")
                        .WithMany("Invitations")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise.DAL.Entities.UserEntity", "Receiver")
                        .WithMany("ReceivedInvitations")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise.DAL.Entities.UserEntity", "Sender")
                        .WithMany("SentInvitations")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.LimitEntity", b =>
                {
                    b.HasOne("SpendWise.DAL.Entities.GroupUserEntity", null)
                        .WithOne("Limit")
                        .HasForeignKey("SpendWise.DAL.Entities.LimitEntity", "GroupUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.TransactionEntity", b =>
                {
                    b.HasOne("SpendWise.DAL.Entities.CategoryEntity", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.TransactionGroupUserEntity", b =>
                {
                    b.HasOne("SpendWise.DAL.Entities.GroupUserEntity", "GroupUser")
                        .WithMany("TransactionGroupUsers")
                        .HasForeignKey("GroupUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpendWise.DAL.Entities.TransactionEntity", "Transaction")
                        .WithMany("TransactionGroupUsers")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupUser");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.GroupEntity", b =>
                {
                    b.Navigation("GroupUsers");

                    b.Navigation("Invitations");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.GroupUserEntity", b =>
                {
                    b.Navigation("Limit");

                    b.Navigation("TransactionGroupUsers");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.TransactionEntity", b =>
                {
                    b.Navigation("TransactionGroupUsers");
                });

            modelBuilder.Entity("SpendWise.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("GroupUsers");

                    b.Navigation("ReceivedInvitations");

                    b.Navigation("SentInvitations");
                });
#pragma warning restore 612, 618
        }
    }
}
