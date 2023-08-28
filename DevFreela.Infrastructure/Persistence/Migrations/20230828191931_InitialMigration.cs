using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdFreelancer = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Project_TB_User_IdClient",
                        column: x => x.IdClient,
                        principalTable: "TB_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Project_TB_User_IdFreelancer",
                        column: x => x.IdFreelancer,
                        principalTable: "TB_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_UserSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_UserSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_UserSkill_TB_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "TB_Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_UserSkill_TB_User_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "TB_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_ProjectComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ProjectComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ProjectComments_TB_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "TB_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_ProjectComments_TB_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TB_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Project_IdClient",
                table: "TB_Project",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Project_IdFreelancer",
                table: "TB_Project",
                column: "IdFreelancer");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ProjectComments_IdProject",
                table: "TB_ProjectComments",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ProjectComments_IdUser",
                table: "TB_ProjectComments",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TB_UserSkill_IdSkill",
                table: "TB_UserSkill",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_TB_UserSkill_SkillId",
                table: "TB_UserSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ProjectComments");

            migrationBuilder.DropTable(
                name: "TB_UserSkill");

            migrationBuilder.DropTable(
                name: "TB_Project");

            migrationBuilder.DropTable(
                name: "TB_Skill");

            migrationBuilder.DropTable(
                name: "TB_User");
        }
    }
}
