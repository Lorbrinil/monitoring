namespace MotorMonitoring.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeChangeToTimeSpan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bendings", "BendingTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Extensions", "ExtensionTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.SensorPositionDatas", "PositionTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.SensorResistanceMotorDatas", "ResistanceTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TrainingTimes", "TrainingStart", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TrainingTimes", "AllTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TrainingTimes", "TimeLeft", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TrainingTimes", "RealTrainingLeft", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingTimes", "RealTrainingLeft", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingTimes", "TimeLeft", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingTimes", "AllTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingTimes", "TrainingStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SensorResistanceMotorDatas", "ResistanceTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SensorPositionDatas", "PositionTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Extensions", "ExtensionTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bendings", "BendingTime", c => c.DateTime(nullable: false));
        }
    }
}
