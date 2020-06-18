using MotorMonitoring.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.DAL.Initializers
{
    class TestDataInitializer : DropCreateDatabaseIfModelChanges<MotorMonitoringContext>
    {
        protected override void Seed(MotorMonitoringContext context)
        {
            base.Seed(context);

            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
            var rnd = new Random();
            var positions = new List<double> { 66.46, 69.47, 78, 22.5, 11.85 };
            for (int j = 0; j < 100; ++j)
            {
                positions.Add(Math.Round(rnd.Next(0, 360) + rnd.NextDouble(), 2));
            }
            
            int timeSec = rnd.Next(5, 40);
            foreach (var position in positions)
            {
                timeSec++;
                var cp = new ControlPanel() { CurrentPosition = position };
                for (int i = 0; i < 2; i++)
                {
                    cp.Bendings.Add(new Bending()
                    {
                        BendingAngle = Math.Round(rnd.Next(0, 360) + rnd.NextDouble(), 2),
                        BendingTime = TimeSpan.FromSeconds(rnd.Next(i * 60, (i + 1) * 60)),
                        LimitEffort = rnd.Next(1, 12),
                        PauseBending = rnd.Next(20, 80)
                    });
                    cp.Speeds.Add(new Speed()
                    {
                        MaxSpeed = Math.Round(rnd.Next(200, 400) + rnd.NextDouble(), 2),
                        MinSpeed = Math.Round(rnd.Next(5, 200) + rnd.NextDouble(), 2),
                        SpeedValue = Math.Round(rnd.Next(5, 400) + rnd.NextDouble(), 2),
                        Training = rnd.Next(300, 3600)
                    });
                    cp.Extensions.Add(new Extension()
                    {
                        ExtensionAngle = Math.Round(rnd.Next(0, 360) + rnd.NextDouble(), 2),
                        ExtensionTime = TimeSpan.FromSeconds(rnd.Next(i * 44, (i + 1) * 44)),
                        PauseExtension = Math.Round(rnd.Next(555, 1556) + rnd.NextDouble(), 2),
                        LimitEffort = rnd.Next(24, 56)
                    });
                    cp.TrainingTimes.Add(new TrainingTime()
                    {
                        AllTime = TimeSpan.FromSeconds(rnd.Next(i * 60, (i + 1) * 60)),
                        RealTrainingLeft = TimeSpan.FromSeconds(rnd.Next(i * 22, (i + 1) * 22)),
                        TrainingStart = TimeSpan.FromSeconds(timeSec + i),
                        TimeLeft = TimeSpan.FromSeconds(rnd.Next(i * 60, (i + 1) * 60))
                    });
                }

                double positionValue = Math.Round(rnd.Next(0, 360) + rnd.NextDouble(), 2);
                double resistanceValue = Math.Round(rnd.Next(0, 100000) + rnd.NextDouble(), 2);
                for (int j = 0; j < 300; ++j)
                {
                    resistanceValue += Math.Round(rnd.Next(0, 5) + rnd.NextDouble(), 2);
                    positionValue += Math.Round(rnd.Next(2, 10) + rnd.NextDouble(), 2);
                    cp.SensorPositionDatas.Add(new SensorPositionData()
                    {
                        PositionDel = rnd.Next(66, 224),
                        PositionTime = TimeSpan.FromSeconds(j * 2),
                        PositionValue = positionValue,
                    });
                    cp.SensorResistanceMotorDatas.Add(new SensorResistanceMotorData()
                    {
                        ResistanceTime = TimeSpan.FromSeconds(j * 2),
                        ResistanceValue = resistanceValue,
                        ResistanceDel = rnd.Next(1, 100) > 50
                    });
                }

                context.ControlPanels.Add(cp);
            } 
        }
    }
}
