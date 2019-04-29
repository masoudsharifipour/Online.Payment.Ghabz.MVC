using Online.Payment.Ghabz.MVC.Service;
using Online.Payment.Ghabz.MVC.Service.Dto;
using Online.Payment.Ghabz.MVC.Service.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online.Payment.Ghabz.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public readonly IGenerateGhabzService _generateGhabzService;
        public HomeController(IGenerateGhabzService generateGhabzService)
        {
            this._generateGhabzService = generateGhabzService;
        }

        public HomeController()
        {
            this._generateGhabzService = new GenerateGhabzService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("GenerateGhabz")]
        public ActionResult GenerateGhabz(GenerateGhabzInputDto generateGhabzInputDto)
        {
            var result = this._generateGhabzService.generateGhabz(generateGhabzInputDto);
            var ghabzHistory = new Ghabz.MVC.Models.ghabzHistory
            {
                Price = int.Parse(result.Price),
                ShenaseGhabz = result.ShenaseGhabz,
                ShenasePardakht = result.ShenasePardakht,
                Type = result.Type,
            };
            return View("Ghabz", ghabzHistory);
        }
    }
}