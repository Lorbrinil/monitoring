using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorMonitoring.Model
{
    public class TrainingTime
    {
        public int TrainingtimeId { get; set; }
        public TimeSpan TrainingStart { get; set; }
        public TimeSpan AllTime { get; set; }
        public TimeSpan TimeLeft { get; set; }
        public TimeSpan RealTrainingLeft { get; set; }

        public ControlPanel ControlPanel { get; set; }
    }
}
