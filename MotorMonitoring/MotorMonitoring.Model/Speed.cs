using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class Speed
    {
        public int SpeedId { get; set; }
        public double MaxSpeed { get; set; }
        public double MinSpeed { get; set; }
        public double SpeedValue { get; set; }
        public int Training { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
