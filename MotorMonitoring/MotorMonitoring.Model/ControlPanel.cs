using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class ControlPanel
    {
        public ControlPanel()
        {
            Speeds = new List<Speed>();
            Extensions = new List<Extension>();
            Bendings = new List<Bending>();
            TrainingTimes = new List<TrainingTime>();
            SensorPositionDatas = new List<SensorPositionData>();
            SensorResistanceMotorDatas = new List<SensorResistanceMotorData>();
        }

        public int ControlPanelId { get; set; }
        public double CurrentPosition { get; set; }

        public virtual List<Speed>  Speeds { get; set; }
        public virtual List<Extension> Extensions { get; set; }
        public virtual List<Bending> Bendings { get; set; }
        public virtual List<TrainingTime> TrainingTimes { get; set; }
        public virtual List<SensorPositionData> SensorPositionDatas { get; set; }
        public virtual List<SensorResistanceMotorData> SensorResistanceMotorDatas { get; set; }
    }
}
