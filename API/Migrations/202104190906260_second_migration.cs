namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_T_Department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        divisionid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TB_M_Division", t => t.divisionid, cascadeDelete: true)
                .Index(t => t.divisionid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_Department", "divisionid", "dbo.TB_M_Division");
            DropIndex("dbo.TB_T_Department", new[] { "divisionid" });
            DropTable("dbo.TB_T_Department");
        }
    }
}
