using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymWorkoutTracker.Api.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Excercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExcerciseId = table.Column<Guid>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSets_Excercises_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Excercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("1b4835d4-1297-4195-aaea-d707c5150003"), new DateTime(2020, 2, 16, 21, 7, 10, 739, DateTimeKind.Local).AddTicks(3062), "Pull Ups" });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"), new DateTime(2020, 2, 16, 21, 7, 10, 743, DateTimeKind.Local).AddTicks(7274), "Lat Pull Down" });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"), new DateTime(2020, 2, 16, 21, 7, 10, 743, DateTimeKind.Local).AddTicks(7447), "Face Pulls" });

            migrationBuilder.InsertData(
                table: "WorkoutSets",
                columns: new[] { "Id", "ExcerciseId", "Reps", "TimeStamp", "Weight" },
                values: new object[,]
                {
                    { new Guid("1cb9ef9f-c82f-45de-add7-1babf17bdbae"), new Guid("1b4835d4-1297-4195-aaea-d707c5150003"), 6, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(249), -50f },
                    { new Guid("15152250-9cd5-4848-bab0-597f03673b03"), new Guid("1b4835d4-1297-4195-aaea-d707c5150003"), 4, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1102), -50f },
                    { new Guid("ae4c8f20-90c8-4cc2-957b-eb55aceb54c6"), new Guid("1b4835d4-1297-4195-aaea-d707c5150003"), 3, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1175), -50f },
                    { new Guid("555eee9d-3a2f-478a-b07a-15abd791cee8"), new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"), 12, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1204), 50f },
                    { new Guid("e7567c90-9a83-4e28-878f-152cc9d09206"), new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"), 12, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1229), 50f },
                    { new Guid("409921cc-9e1d-4302-bca4-aa31d9df53e8"), new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"), 12, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1257), 50f },
                    { new Guid("8fc8f646-cab5-4798-8090-7f33595de415"), new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"), 6, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1283), 20f },
                    { new Guid("09677d11-edee-4d4b-91d4-ccbddd1b3c49"), new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"), 6, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1307), 20f },
                    { new Guid("297fbabe-01db-42ef-badc-57855d5bad12"), new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"), 6, new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1332), 20f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSets_ExcerciseId",
                table: "WorkoutSets",
                column: "ExcerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutSets");

            migrationBuilder.DropTable(
                name: "Excercises");
        }
    }
}
