namespace OperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDbOp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "oper.Bank",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        InterestInternalTransfer = c.Double(nullable: false),
                        InterestExternalTransfer = c.Double(nullable: false),
                        AdditionalActionsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "oper.Invoice",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 20),
                        BankId = c.Guid(nullable: false),
                        InvoiceTypeId = c.Guid(nullable: false),
                        Ammount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("oper.Bank", t => t.BankId, cascadeDelete: false)
                .ForeignKey("oper.InvoiceType", t => t.InvoiceTypeId, cascadeDelete: false)
                .Index(t => t.BankId)
                .Index(t => t.InvoiceTypeId);
            
            CreateTable(
                "oper.InvoiceType",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        AdditionalActionsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "oper.MatrixInvoices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RecipientTypeId = c.Guid(nullable: false),
                        SenderTypeId = c.Guid(nullable: false),
                        Interest = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("oper.InvoiceType", t => t.RecipientTypeId, cascadeDelete: false)
                .ForeignKey("oper.InvoiceType", t => t.SenderTypeId, cascadeDelete: false)
                .Index(t => t.RecipientTypeId)
                .Index(t => t.SenderTypeId);
            
            CreateTable(
                "oper.Transations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RecipientInvoiceId = c.Guid(nullable: false),
                        SenderInvoiceId = c.Guid(nullable: false),
                        Ammount = c.Double(nullable: false),
                        TransferInterest = c.Double(nullable: false),
                        BankInterest = c.Double(nullable: false),
                        TransferDate = c.DateTime(nullable: false),
                        TransferUserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("oper.Invoice", t => t.RecipientInvoiceId, cascadeDelete: false)
                .ForeignKey("oper.Invoice", t => t.SenderInvoiceId, cascadeDelete: false)
                .Index(t => t.RecipientInvoiceId)
                .Index(t => t.SenderInvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("oper.Transations", "SenderInvoiceId", "oper.Invoice");
            DropForeignKey("oper.Transations", "RecipientInvoiceId", "oper.Invoice");
            DropForeignKey("oper.MatrixInvoices", "SenderTypeId", "oper.InvoiceType");
            DropForeignKey("oper.MatrixInvoices", "RecipientTypeId", "oper.InvoiceType");
            DropForeignKey("oper.Invoice", "InvoiceTypeId", "oper.InvoiceType");
            DropForeignKey("oper.Invoice", "BankId", "oper.Bank");
            DropIndex("oper.Transations", new[] { "SenderInvoiceId" });
            DropIndex("oper.Transations", new[] { "RecipientInvoiceId" });
            DropIndex("oper.MatrixInvoices", new[] { "SenderTypeId" });
            DropIndex("oper.MatrixInvoices", new[] { "RecipientTypeId" });
            DropIndex("oper.Invoice", new[] { "InvoiceTypeId" });
            DropIndex("oper.Invoice", new[] { "BankId" });
            DropTable("oper.Transations");
            DropTable("oper.MatrixInvoices");
            DropTable("oper.InvoiceType");
            DropTable("oper.Invoice");
            DropTable("oper.Bank");
        }
    }
}
