using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotorMonitoring.Controllers
{
    public class MainController : Controller
    {
        MotorMonitoring.DAL.MotorMonitoringContext db = new DAL.MotorMonitoringContext();

        public ActionResult Home()
        {
            MonitorController.currentControlPanelId = -1;
            var controlPanel = db.ControlPanels.ToList().First();
            ViewBag.id = controlPanel.ControlPanelId;
            ViewBag.position = controlPanel.CurrentPosition;
            ViewBag.time = controlPanel.TrainingTimes.First().TrainingStart;
            ViewBag.angle1 = controlPanel.Bendings.First().BendingAngle;
            ViewBag.angle2 = controlPanel.Extensions.First().ExtensionAngle;
            ViewBag.limits = controlPanel.Extensions.First().LimitEffort;
            ViewBag.pause1 = controlPanel.Bendings.First().PauseBending;
            ViewBag.pause2 = controlPanel.Extensions.First().PauseExtension;
            ViewBag.speed = controlPanel.Speeds.First().SpeedValue;
            return View();
        }

        public ActionResult Monitoring()
        {
            var rnd = new Random();
            var controlPanelList = db.ControlPanels.ToList();
            if (MonitorController.currentControlPanelId == -1)
            {
                MonitorController.currentControlPanelId = rnd.Next(controlPanelList.Count);
                MonitorController.currentDataReturn = 0;
            }
            var controlPanel = controlPanelList[MonitorController.currentControlPanelId];
            ViewBag.id = MonitorController.currentControlPanelId;

            ViewBag.positionTime = controlPanel.SensorPositionDatas[MonitorController.currentDataReturn].PositionTime;
            ViewBag.positionValue = controlPanel.SensorPositionDatas[MonitorController.currentDataReturn].PositionValue;

            ViewBag.resistanceTime = controlPanel.SensorResistanceMotorDatas[MonitorController.currentDataReturn].ResistanceTime;
            ViewBag.resistanceValue = controlPanel.SensorResistanceMotorDatas[MonitorController.currentDataReturn].ResistanceValue;

            return View();
        }

        public ActionResult Error()
        {
            var problemsAndSolutions = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("Motor angle to big.","Rotate to apropirate position."),
                new Tuple<string, string>("Resitance to big.","Move resistance fader down."),
                new Tuple<string, string>("Speed to big.","Rotate back speed regulator.")
            };
            var pobl = problemsAndSolutions[new Random().Next(problemsAndSolutions.Count)];
            ViewBag.Problem = pobl.Item1;
            ViewBag.Solution = pobl.Item2;
            return View();
        }
    }
}