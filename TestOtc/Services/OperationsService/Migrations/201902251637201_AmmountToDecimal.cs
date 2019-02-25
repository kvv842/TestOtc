namespace OperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmmountToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("oper.Bank", "InterestInternalTransfer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.Bank", "InterestExternalTransfer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.Invoice", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.MatrixInvoices", "Interest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.Transations", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.Transations", "TransferInterest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("oper.Transations", "BankInterest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("oper.Transations", "BankInterest", c => c.Double(nullable: false));
            AlterColumn("oper.Transations", "TransferInterest", c => c.Double(nullable: false));
            AlterColumn("oper.Transations", "Ammount", c => c.Double(nullable: false));
            AlterColumn("oper.MatrixInvoices", "Interest", c => c.Double(nullable: false));
            AlterColumn("oper.Invoice", "Ammount", c => c.Double(nullable: false));
            AlterColumn("oper.Bank", "InterestExternalTransfer", c => c.Double(nullable: false));
            AlterColumn("oper.Bank", "InterestInternalTransfer", c => c.Double(nullable: false));
        }
    }
}
