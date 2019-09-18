namespace ScoreBoard_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player_Score",
                c => new
                    {
                        PlayerScoreId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Score = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerScoreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Player_Score");
        }
    }
}
