using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class Extension
    {
        public int ExtensionId { get; set; }
        public double ExtensionAngle { get; set; }
        public double PauseExtension { get; set; }
        public double LimitEffort { get; set; }
        public TimeSpan ExtensionTime { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
