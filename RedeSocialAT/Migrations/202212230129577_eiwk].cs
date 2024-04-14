namespace RedeSocialAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eiwk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.Perfil", "Post_PostId", "dbo.Post");
            DropIndex("dbo.Perfil", new[] { "Post_PostId" });
            DropIndex("dbo.Post", new[] { "PerfilId" });
            DropColumn("dbo.Perfil", "Post_PostId");
            DropTable("dbo.Post");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        DataPost = c.DateTime(nullable: false),
                        Texto = c.String(),
                        ImagemPost = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            AddColumn("dbo.Perfil", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Post", "PerfilId");
            CreateIndex("dbo.Perfil", "Post_PostId");
            AddForeignKey("dbo.Perfil", "Post_PostId", "dbo.Post", "PostId");
            AddForeignKey("dbo.Post", "PerfilId", "dbo.Perfil", "Id", cascadeDelete: true);
        }
    }
}
