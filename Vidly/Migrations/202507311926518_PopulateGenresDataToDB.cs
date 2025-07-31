namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresDataToDB : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'nonfiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'poetry')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'drama')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'fantasy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (6, 'mystery')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (7, 'romance')");
        }
        
        public override void Down()
        {
        }
    }
}
