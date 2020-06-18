using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class Bending
    {
        public int BendingId { get; set; }
        public double BendingAngle { get; set; }
        public double PauseBending { get; set; }
        public double LimitEffort { get; set; }
        public TimeSpan BendingTime { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
