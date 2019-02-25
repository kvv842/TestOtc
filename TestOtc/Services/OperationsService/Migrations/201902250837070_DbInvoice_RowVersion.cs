namespace OperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInvoice_RowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("oper.Invoice", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("oper.Invoice", "RowVersion");
        }
    }
}
