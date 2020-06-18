using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace MotorMonitoring.Controllers
{
    public class MotorController : ApiController
    {
        DAL.MotorMonitoringContext db = new DAL.MotorMonitoringContext();

        // GET api/<controller>/5
        public JsonResult<Dictionary<string, string>> Get(int id)
        {
            var dict = new Dictionary<string, string>();
            var where = db.ControlPanels.Where(el => el.ControlPanelId == id);
            if (where != null)
            {
                var row = (where.Count() > 0) ? where.First() : db.ControlPanels.First();

                dict["id"] = row.ControlPanelId.ToString();
                dict["position"] = row.CurrentPosition.ToString();
                dict["time"] = row.TrainingTimes.First().TrainingStart.ToString();
                dict["angle1"] = row.Bendings.First().BendingAngle.ToString();
                dict["angle2"] = row.Extensions.First().ExtensionAngle.ToString();
                dict["limits"] = row.Extensions.First().LimitEffort.ToString();
                dict["pause1"] = row.Bendings.First().PauseBending.ToString();
                dict["pause2"] = row.Extensions.First().PauseExtension.ToString();
                dict["speed"] = row.Speeds.First().SpeedValue.ToString();
            }
            else
            {
                dict["id"] = "1";
            }
            return Json(dict);
        }
    }
}