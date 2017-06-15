using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreActionResultsDemo.Controllers
{
    public class RedirectsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Target()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }

        [HttpGet]
        public IActionResult LocalRedirectResult()
        {
            return LocalRedirect("/redirects/target");
        }

        [HttpGet]
        public IActionResult RedirectResult()
        {
            return Redirect("https://www.exceptionnotfound.net");
        }

        [HttpGet]
        public IActionResult RedirectToActionResult()
        {
            return RedirectToAction("target");
        }

        [HttpGet]
        public IActionResult RedirectToRouteResult()
        {
            return RedirectToRoute("default", new { action = "target", controller = "redirects" });
        }
    }
}