using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Volleyball.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueSet",
                columns: table => new
                {
                    LeagueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSet", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "TeamSet",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSet", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TeamSet_LeagueSet_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "LeagueSet",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatcheSet",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfMatch = table.Column<DateTime>(nullable: false),
                    GuestTeamTeamId = table.Column<int>(nullable: true),
                    HostTeamTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatcheSet", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_MatcheSet_TeamSet_GuestTeamTeamId",
                        column: x => x.GuestTeamTeamId,
                        principalTable: "TeamSet",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatcheSet_TeamSet_HostTeamTeamId",
                        column: x => x.HostTeamTeamId,
                        principalTable: "TeamSet",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSet",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSet", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayerSet_TeamSet_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TeamSet",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatcheSet_GuestTeamTeamId",
                table: "MatcheSet",
                column: "GuestTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatcheSet_HostTeamTeamId",
                table: "MatcheSet",
                column: "HostTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSet_TeamId",
                table: "PlayerSet",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSet_LeagueId",
                table: "TeamSet",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatcheSet");

            migrationBuilder.DropTable(
                name: "PlayerSet");

            migrationBuilder.DropTable(
                name: "TeamSet");

            migrationBuilder.DropTable(
                name: "LeagueSet");
        }
    }
}
