using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
namespace MotorMonitoring.Controllers
{
    public class MonitorController : ApiController
    {
        DAL.MotorMonitoringContext db = new DAL.MotorMonitoringContext();
        public static int currentDataReturn = 0;
        public static int currentControlPanelId = -1;
        // GET api/<controller>/5
        public JsonResult<Dictionary<string, string>> Get(int id)
        {
            var dict = new Dictionary<string, string>();
            currentDataReturn++;
            var where = db.ControlPanels.Where(el => el.ControlPanelId == currentControlPanelId);
            if (where != null)
            {
                var row = (where.Count() > 0) ? where.First() : db.ControlPanels.First();

                dict["id"] = currentControlPanelId.ToString();

                dict["positionTime"] = row.SensorPositionDatas[currentDataReturn].PositionTime.ToString();
                dict["positionValue"] = row.SensorPositionDatas[currentDataReturn].PositionValue.ToString();

                dict["resistanceTime"] = row.SensorResistanceMotorDatas[currentDataReturn].ResistanceTime.ToString();
                dict["resistanceValue"] = row.SensorResistanceMotorDatas[currentDataReturn].ResistanceValue.ToString();
            }
            else
            {
                dict["id"] = "1";
            }
            return Json(dict);
        }
    }
}
