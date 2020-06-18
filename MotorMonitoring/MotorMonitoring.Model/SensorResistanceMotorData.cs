using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class SensorResistanceMotorData
    {
        public int SensorResistanceMotorDataId { get; set; }
        public double ResistanceValue { get; set; }
        public TimeSpan ResistanceTime { get; set; }
        public bool ResistanceDel { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
