namespace EventSourcingCqrsSample.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00_Initialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventStream",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        StreamId = c.Guid(nullable: false),
                        Sequence = c.Long(),
                        EventName = c.String(nullable: false, maxLength: 256),
                        EventType = c.String(nullable: false, maxLength: 256),
                        EventBody = c.String(nullable: false),
                        DateOccurred = c.DateTime(nullable: false),
                        DateRecorded = c.DateTime(nullable: false),
                        DateProjected = c.DateTime(nullable: false),
                        ProjectedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8),
                        Name = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.EventStream");
        }
    }
}
