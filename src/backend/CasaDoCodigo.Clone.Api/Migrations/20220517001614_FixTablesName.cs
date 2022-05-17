using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDoCodigo.Clone.Api.Migrations
{
    public partial class FixTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Emails_EmailId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_Authors_AuthorId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_CategoryEntity_CategoryId",
                table: "BookEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StateEntity_CountryEntity_CountryId",
                table: "StateEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StateEntity",
                table: "StateEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEntity",
                table: "CategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "StateEntity",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "Email");

            migrationBuilder.RenameTable(
                name: "CountryEntity",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "CategoryEntity",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "BookEntity",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_StateEntity_CountryId",
                table: "State",
                newName: "IX_State_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_Value",
                table: "Email",
                newName: "IX_Email_Value");

            migrationBuilder.RenameIndex(
                name: "IX_CountryEntity_Name",
                table: "Country",
                newName: "IX_Country_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_Name",
                table: "Category",
                newName: "IX_Category_Name");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_Title",
                table: "Book",
                newName: "IX_Book_Title");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_ISBN",
                table: "Book",
                newName: "IX_Book_ISBN");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_CategoryId",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_EmailId",
                table: "Author",
                newName: "IX_Author_EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Email_EmailId",
                table: "Author",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Email_EmailId",
                table: "Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Email",
                table: "Email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "StateEntity");

            migrationBuilder.RenameTable(
                name: "Email",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "CountryEntity");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "CategoryEntity");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookEntity");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_State_CountryId",
                table: "StateEntity",
                newName: "IX_StateEntity_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Email_Value",
                table: "Emails",
                newName: "IX_Emails_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Name",
                table: "CountryEntity",
                newName: "IX_CountryEntity_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Name",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Title",
                table: "BookEntity",
                newName: "IX_BookEntity_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Book_ISBN",
                table: "BookEntity",
                newName: "IX_BookEntity_ISBN");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "BookEntity",
                newName: "IX_BookEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "BookEntity",
                newName: "IX_BookEntity_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Author_EmailId",
                table: "Authors",
                newName: "IX_Authors_EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateEntity",
                table: "StateEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEntity",
                table: "CategoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Emails_EmailId",
                table: "Authors",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_Authors_AuthorId",
                table: "BookEntity",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_CategoryEntity_CategoryId",
                table: "BookEntity",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateEntity_CountryEntity_CountryId",
                table: "StateEntity",
                column: "CountryId",
                principalTable: "CountryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
