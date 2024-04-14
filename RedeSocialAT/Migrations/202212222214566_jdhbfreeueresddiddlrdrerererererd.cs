namespace RedeSocialAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jdhbfreeueresddiddlrdrerererererd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Fotourl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Perfil");
        }
    }
}
