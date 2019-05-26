using Domain.Entities;
using Domain.Interfaces;
using Service.Services;
using Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IService<AplicationDomain> service = new AplicationService<AplicationDomain>();

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(DashboardViewModel modelo)
        {
            TempData["time"] = modelo.Timee;
            return RedirectToAction("GetAction");
        }


        [HttpGet]
        [Authorize]
        public ActionResult GetAction(int? tempo)
        {
            if (TempData["time"] != null)
            {
                var allMachine = GetAllMachineByTime();
                TempData["List"] = allMachine;
                var ret = FillDashBoard();
                return View(ret);
            }

            return View();
        }

        private ReturnDashboardViewModel FillDashBoard()
        {
            var dbvm = new ReturnDashboardViewModel();
            if (TempData["List"] != null)
            {

                var ret = (List<AplicationDomain>)TempData["List"];
                var groupyapp = ret.GroupBy(x => x.ServiceName).Select(grp =>
                        new {
                            ServiceName = grp.Key,
                            Count = grp.Count()
                        }).ToList()
                        .OrderBy(e => e.Count)
                        .Take(10);            
                dbvm.AplicationName.AddRange(groupyapp.Select(s => s.ServiceName).ToList());


                var dta = DateTime.UtcNow.AddMinutes(-30);
                var dta15 = DateTime.UtcNow.AddMinutes(-30 * 1.5);
                var dta20 = DateTime.UtcNow.AddMinutes(-30 * 2);

                var resultadoonline = ret.Where(a => (a.DateTimeUtc) <= dta).Select(a => a.MachiName);    
                var resultadoalerta = ret.Where(a => (a.DateTimeUtc) <= dta15).Select(a => a.MachiName);
                var resultadoff = ret.Where(a => (a.DateTimeUtc) <= dta20).Select(a => a.MachiName);

                dbvm.MachineOnlineName.AddRange(resultadoff.Distinct().Take(10));         

                dbvm.ReturnStatusMachine.Add(new MachineAmount { Amount = resultadoonline.Distinct().Count(), Status = Status.Online });
                dbvm.ReturnStatusMachine.Add(new MachineAmount { Amount = resultadoalerta.Distinct().Count(), Status = Status.Alerta });
                dbvm.ReturnStatusMachine.Add(new MachineAmount { Amount = resultadoff.Distinct().Count(), Status = Status.Offline });
            }
            return dbvm;
        }

        private IList<AplicationDomain> GetAllMachineByTime()
        {
            try
            {
                if (TempData["time"] == null)
                {
                    return null;
                }
                var time = Convert.ToInt32(TempData["time"].ToString()) * 2;
                return service.Get(time);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public PartialViewResult OnlineMachine()
        {
            List<AplicationDomain> allMachine = (List<AplicationDomain>)TempData["List"];
            return PartialView("OnlineMachine", allMachine);
        }
    }
}