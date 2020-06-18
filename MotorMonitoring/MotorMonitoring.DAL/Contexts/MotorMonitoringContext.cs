using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MotorMonitoring.Model;

namespace MotorMonitoring.DAL
{
    public class MotorMonitoringContext : DbContext
    {
        public MotorMonitoringContext() : base("MotorMonitoring")
        {
            Database.SetInitializer(new Initializers.TestDataInitializer());
        }

        public DbSet<ControlPanel> ControlPanels { get; set; }
        public DbSet<Extension> Extensions { get; set; }
        public DbSet<SensorPositionData> SensorPositionDatas { get; set; }
        public DbSet<SensorResistanceMotorData> SensorResistanceMotorDatas { get; set; }
        public DbSet<Speed> Speeds { get; set; }
        public DbSet<Bending> Bendings { get; set; }
        public DbSet<TrainingTime> TrainingTimes { get; set; }
    }
}
