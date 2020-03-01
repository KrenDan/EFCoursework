using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoursework.DataAccess.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLanguage_Games_GameId",
                table: "GameLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLanguage_Languages_LanguageId",
                table: "GameLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Games_GameId",
                table: "GamePublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Publishers_PublisherId",
                table: "GamePublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSystem_Games_GameId",
                table: "GameSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSystem_Systems_OSId",
                table: "GameSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Games_GameId",
                table: "GameTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Tags_TagId",
                table: "GameTag");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLanguage_Games_GameId",
                table: "GameLanguage",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLanguage_Languages_LanguageId",
                table: "GameLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Games_GameId",
                table: "GamePublisher",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Publishers_PublisherId",
                table: "GamePublisher",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSystem_Games_GameId",
                table: "GameSystem",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSystem_Systems_OSId",
                table: "GameSystem",
                column: "OSId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Games_GameId",
                table: "GameTag",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Tags_TagId",
                table: "GameTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLanguage_Games_GameId",
                table: "GameLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLanguage_Languages_LanguageId",
                table: "GameLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Games_GameId",
                table: "GamePublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePublisher_Publishers_PublisherId",
                table: "GamePublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSystem_Games_GameId",
                table: "GameSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSystem_Systems_OSId",
                table: "GameSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Games_GameId",
                table: "GameTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTag_Tags_TagId",
                table: "GameTag");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Developers_DeveloperId",
                table: "GameDeveloper",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameDeveloper_Games_GameId",
                table: "GameDeveloper",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLanguage_Games_GameId",
                table: "GameLanguage",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameLanguage_Languages_LanguageId",
                table: "GameLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Games_GameId",
                table: "GamePublisher",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublisher_Publishers_PublisherId",
                table: "GamePublisher",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSystem_Games_GameId",
                table: "GameSystem",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSystem_Systems_OSId",
                table: "GameSystem",
                column: "OSId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Games_GameId",
                table: "GameTag",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTag_Tags_TagId",
                table: "GameTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
