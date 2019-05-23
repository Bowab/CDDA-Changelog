using CDDA.Models;
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
            var model = _buildsRepository.GetStaticBuilds();

            return View(model);
        }
    }
}
