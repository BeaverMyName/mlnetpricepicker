using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLAPP.Migrations
{
    /// <inheritdoc />
    public partial class Add_NodeId_Field_To_TrainindData_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeId",
                table: "TrainingData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "TrainingData");
        }
    }
}
