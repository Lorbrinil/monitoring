using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class SensorPositionData
    {
        public int SensorPositionDataId { get; set; }
        public double PositionValue { get; set; }
        public TimeSpan PositionTime { get; set; }
        public int PositionDel { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
