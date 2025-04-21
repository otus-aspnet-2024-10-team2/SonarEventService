using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchLeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchLeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SonarProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonarProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestId = table.Column<long>(type: "INTEGER", nullable: false),
                    LeaderId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchGroups_SearchLeader_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "SearchLeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchGroups_SearchRequest_RequestId",
                        column: x => x.RequestId,
                        principalTable: "SearchRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SonarTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SonarProcessId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonarTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SonarTasks_SonarProcess_SonarProcessId",
                        column: x => x.SonarProcessId,
                        principalTable: "SonarProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMembers_SearchGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SearchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_SearchUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SearchUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SearchGroupId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchTask_SearchGroups_SearchGroupId",
                        column: x => x.SearchGroupId,
                        principalTable: "SearchGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchGroups_LeaderId",
                table: "SearchGroups",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchGroups_RequestId",
                table: "SearchGroups",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchTask_SearchGroupId",
                table: "SearchTask",
                column: "SearchGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SonarTasks_SonarProcessId",
                table: "SonarTasks",
                column: "SonarProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "SearchTask");

            migrationBuilder.DropTable(
                name: "SonarTasks");

            migrationBuilder.DropTable(
                name: "SearchUser");

            migrationBuilder.DropTable(
                name: "SearchGroups");

            migrationBuilder.DropTable(
                name: "SonarProcess");

            migrationBuilder.DropTable(
                name: "SearchLeader");

            migrationBuilder.DropTable(
                name: "SearchRequest");
        }
    }
}
