using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_core_API.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "User1", new byte[] { 117, 183, 182, 87, 195, 212, 190, 66, 30, 115, 158, 167, 62, 137, 158, 242, 139, 135, 143, 229, 232, 225, 248, 47, 25, 64, 18, 118, 226, 122, 210, 159, 122, 122, 85, 247, 66, 96, 73, 54, 36, 28, 53, 141, 120, 239, 4, 66, 42, 44, 151, 219, 200, 194, 253, 16, 152, 38, 103, 210, 28, 230, 89, 36 }, new byte[] { 27, 124, 151, 161, 231, 151, 81, 27, 30, 21, 251, 199, 180, 35, 203, 239, 83, 25, 105, 215, 34, 94, 79, 10, 153, 230, 113, 72, 157, 214, 88, 7, 62, 241, 148, 188, 215, 119, 232, 125, 5, 50, 131, 155, 139, 193, 194, 128, 224, 166, 155, 80, 195, 47, 209, 223, 225, 75, 206, 118, 28, 65, 90, 118, 140, 234, 7, 61, 129, 252, 199, 63, 118, 79, 164, 154, 16, 175, 17, 8, 121, 216, 209, 151, 225, 79, 235, 50, 241, 32, 255, 154, 67, 54, 126, 240, 74, 163, 159, 177, 147, 210, 135, 114, 152, 58, 130, 206, 165, 227, 65, 129, 235, 83, 20, 82, 59, 181, 170, 55, 92, 142, 210, 189, 211, 182, 159, 142 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 2, "User2", new byte[] { 117, 183, 182, 87, 195, 212, 190, 66, 30, 115, 158, 167, 62, 137, 158, 242, 139, 135, 143, 229, 232, 225, 248, 47, 25, 64, 18, 118, 226, 122, 210, 159, 122, 122, 85, 247, 66, 96, 73, 54, 36, 28, 53, 141, 120, 239, 4, 66, 42, 44, 151, 219, 200, 194, 253, 16, 152, 38, 103, 210, 28, 230, 89, 36 }, new byte[] { 27, 124, 151, 161, 231, 151, 81, 27, 30, 21, 251, 199, 180, 35, 203, 239, 83, 25, 105, 215, 34, 94, 79, 10, 153, 230, 113, 72, 157, 214, 88, 7, 62, 241, 148, 188, 215, 119, 232, 125, 5, 50, 131, 155, 139, 193, 194, 128, 224, 166, 155, 80, 195, 47, 209, 223, 225, 75, 206, 118, 28, 65, 90, 118, 140, 234, 7, 61, 129, 252, 199, 63, 118, 79, 164, 154, 16, 175, 17, 8, 121, 216, 209, 151, 225, 79, 235, 50, 241, 32, 255, 154, 67, 54, 126, 240, 74, 163, 159, 177, 147, 210, 135, 114, 152, 58, 130, 206, 165, 227, 65, 129, 235, 83, 20, 82, 59, 181, 170, 55, 92, 142, 210, 189, 211, 182, 159, 142 } });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "Hitpoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 1, 0, 10, 0, 100, 10, "Frodo", 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "Hitpoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 2, 0, 5, 0, 100, 20, "Raistlin", 5, 2, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 1, 20, "The Master Sword" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 5, "Crystal Wand" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
