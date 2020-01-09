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
        //private readonly IBuildsRepository _buildsRepository;
        private readonly BuildsViewModel _buildsViewModel;

        public HomeController(BuildsViewModel buildsViewModel)
        {
            _buildsViewModel = buildsViewModel;
            //_buildsRepository = buildsRepository;
        }

        public IActionResult Index()
        {          
            return View();
        }

        public IActionResult Changelog()
        {
            var model = _buildsViewModel.GenerateViewModel();
            return View(model);
        }

    }
}
