using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avans.GameNight.Infrastructure.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGame",
                columns: table => new
                {
                    NameGame = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mature = table.Column<bool>(type: "bit", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KindOfGame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureB = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureFormat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGame", x => x.NameGame);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameNight",
                columns: table => new
                {
                    NameNight = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mature = table.Column<bool>(type: "bit", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameNight", x => x.NameNight);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    MailAdress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    alert = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mature = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrinkPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotShow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.MailAdress);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RaterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameRater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mature = table.Column<bool>(type: "bit", nullable: false),
                    RatingNight = table.Column<int>(type: "int", nullable: false),
                    FeedBack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RaterId);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameNightBoardGame",
                columns: table => new
                {
                    IdBoardGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameNight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boardNameGame = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BoardGameNightNameNight = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameNightBoardGame", x => x.IdBoardGame);
                    table.ForeignKey(
                        name: "FK_BoardGameNightBoardGame_BoardGame_boardNameGame",
                        column: x => x.boardNameGame,
                        principalTable: "BoardGame",
                        principalColumn: "NameGame");
                    table.ForeignKey(
                        name: "FK_BoardGameNightBoardGame_BoardGameNight_BoardGameNightNameNight",
                        column: x => x.BoardGameNightNameNight,
                        principalTable: "BoardGameNight",
                        principalColumn: "NameNight");
                });

            migrationBuilder.CreateTable(
                name: "BoardGameNightPlayer",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerMailAdress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameNight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardGameNightNameNight = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameNightPlayer", x => x.IdPlayer);
                    table.ForeignKey(
                        name: "FK_BoardGameNightPlayer_BoardGameNight_BoardGameNightNameNight",
                        column: x => x.BoardGameNightNameNight,
                        principalTable: "BoardGameNight",
                        principalColumn: "NameNight");
                    table.ForeignKey(
                        name: "FK_BoardGameNightPlayer_Player_PlayerMailAdress",
                        column: x => x.PlayerMailAdress,
                        principalTable: "Player",
                        principalColumn: "MailAdress");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameNightBoardGame_BoardGameNightNameNight",
                table: "BoardGameNightBoardGame",
                column: "BoardGameNightNameNight");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameNightBoardGame_boardNameGame",
                table: "BoardGameNightBoardGame",
                column: "boardNameGame");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameNightPlayer_BoardGameNightNameNight",
                table: "BoardGameNightPlayer",
                column: "BoardGameNightNameNight");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameNightPlayer_PlayerMailAdress",
                table: "BoardGameNightPlayer",
                column: "PlayerMailAdress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameNightBoardGame");

            migrationBuilder.DropTable(
                name: "BoardGameNightPlayer");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "BoardGame");

            migrationBuilder.DropTable(
                name: "BoardGameNight");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
