﻿namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false), // change identity to true to make the Id automative
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Categories VALUES(1, 'Web Development')");
            Sql("INSERT INTO Categories VALUES(2, 'Programming languages')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
