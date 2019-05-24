using Domain.Entities;
using Newtonsoft.Json;
using Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Criar(DashboardViewModel modelo)
        {
            TempData["tempo"] = modelo.Tempo;
            return RedirectToAction("GetAction");
        }


        [HttpGet]
        [Authorize]
        public ActionResult GetAction(int? tempo)
        {
            if (TempData["tempo"] != null)
            {

                //return View();
                var ret = new List<ReturnDashboardViewModel>();
                //Fake
                ret.Add(new ReturnDashboardViewModel
                {
                    AplicationDomain = new AplicationDomain
                    {
                        DateTimeUtc = DateTime.UtcNow,
                        MachiName = "FAKE",
                        ServiceDisplayName = "FAKE",
                        ServiceName = "FAKE",
                        ServiceType = System.ServiceProcess.ServiceType.Adapter,
                        Status = System.ServiceProcess.ServiceControllerStatus.ContinuePending
                    },
                    Status = Status.Alerta
                });

                ret.Add(new ReturnDashboardViewModel
                {
                    AplicationDomain = new AplicationDomain
                    {
                        DateTimeUtc = DateTime.UtcNow,
                        MachiName = "FAKE1",
                        ServiceDisplayName = "FAKE1",
                        ServiceName = "FAKE1",
                        ServiceType = System.ServiceProcess.ServiceType.Adapter,
                        Status = System.ServiceProcess.ServiceControllerStatus.ContinuePending
                    },
                    Status = Status.Alerta
                });

                ret.Add(new ReturnDashboardViewModel
                {
                    AplicationDomain = new AplicationDomain
                    {
                        DateTimeUtc = DateTime.UtcNow,
                        MachiName = "FAKE2",
                        ServiceDisplayName = "FAKE2",
                        ServiceName = "FAKE2",
                        ServiceType = System.ServiceProcess.ServiceType.Adapter,
                        Status = System.ServiceProcess.ServiceControllerStatus.ContinuePending
                    },
                    Status = Status.Alerta
                });

                return View(ret);
            }

            return View();
        }


    }
}