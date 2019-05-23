using CDDA.Models;
using CDDA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDDA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildsRepository _buildsRepository;
        public HomeController(IBuildsRepository buildsRepository)
        {
            _buildsRepository = buildsRepository;
        }

        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult Changelog()
        {
            var model = new BuildsViewModel(_buildsRepository).GenerateViewModel();
            return View(model);
        }

    }
}
