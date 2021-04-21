namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_table_name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TB_T_Department", newName: "TB_M_Department");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_M_Department", newName: "TB_T_Department");
        }
    }
}
