namespace MotorMonitoring.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bendings",
                c => new
                    {
                        BendingId = c.Int(nullable: false, identity: true),
                        BendingAngle = c.Double(nullable: false),
                        PauseBending = c.Double(nullable: false),
                        LimitEffort = c.Double(nullable: false),
                        BendingTime = c.DateTime(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.BendingId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
            CreateTable(
                "dbo.ControlPanels",
                c => new
                    {
                        ControlPanelId = c.Int(nullable: false, identity: true),
                        CurrentPosition = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ControlPanelId);
            
            CreateTable(
                "dbo.Extensions",
                c => new
                    {
                        ExtensionId = c.Int(nullable: false, identity: true),
                        ExtensionAngle = c.Double(nullable: false),
                        PauseExtension = c.Double(nullable: false),
                        LimitEffort = c.Double(nullable: false),
                        ExtensionTime = c.DateTime(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.ExtensionId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
            CreateTable(
                "dbo.SensorPositionDatas",
                c => new
                    {
                        SensorPositionDataId = c.Int(nullable: false, identity: true),
                        PositionValue = c.Double(nullable: false),
                        PositionTime = c.DateTime(nullable: false),
                        PositionDel = c.Int(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.SensorPositionDataId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
            CreateTable(
                "dbo.SensorResistanceMotorDatas",
                c => new
                    {
                        SensorResistanceMotorDataId = c.Int(nullable: false, identity: true),
                        ResistanceValue = c.Double(nullable: false),
                        ResistanceTime = c.DateTime(nullable: false),
                        ResistanceDel = c.Boolean(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.SensorResistanceMotorDataId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
            CreateTable(
                "dbo.Speeds",
                c => new
                    {
                        SpeedId = c.Int(nullable: false, identity: true),
                        MaxSpeed = c.Double(nullable: false),
                        MinSpeed = c.Double(nullable: false),
                        SpeedValue = c.Double(nullable: false),
                        Training = c.Int(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.SpeedId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
            CreateTable(
                "dbo.TrainingTimes",
                c => new
                    {
                        TrainingtimeId = c.Int(nullable: false, identity: true),
                        TrainingStart = c.DateTime(nullable: false),
                        AllTime = c.DateTime(nullable: false),
                        TimeLeft = c.DateTime(nullable: false),
                        RealTrainingLeft = c.DateTime(nullable: false),
                        ControlPanel_ControlPanelId = c.Int(),
                    })
                .PrimaryKey(t => t.TrainingtimeId)
                .ForeignKey("dbo.ControlPanels", t => t.ControlPanel_ControlPanelId)
                .Index(t => t.ControlPanel_ControlPanelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingTimes", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropForeignKey("dbo.Speeds", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropForeignKey("dbo.SensorResistanceMotorDatas", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropForeignKey("dbo.SensorPositionDatas", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropForeignKey("dbo.Extensions", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropForeignKey("dbo.Bendings", "ControlPanel_ControlPanelId", "dbo.ControlPanels");
            DropIndex("dbo.TrainingTimes", new[] { "ControlPanel_ControlPanelId" });
            DropIndex("dbo.Speeds", new[] { "ControlPanel_ControlPanelId" });
            DropIndex("dbo.SensorResistanceMotorDatas", new[] { "ControlPanel_ControlPanelId" });
            DropIndex("dbo.SensorPositionDatas", new[] { "ControlPanel_ControlPanelId" });
            DropIndex("dbo.Extensions", new[] { "ControlPanel_ControlPanelId" });
            DropIndex("dbo.Bendings", new[] { "ControlPanel_ControlPanelId" });
            DropTable("dbo.TrainingTimes");
            DropTable("dbo.Speeds");
            DropTable("dbo.SensorResistanceMotorDatas");
            DropTable("dbo.SensorPositionDatas");
            DropTable("dbo.Extensions");
            DropTable("dbo.ControlPanels");
            DropTable("dbo.Bendings");
        }
    }
}
