using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreActionResultsDemo.Controllers
{
    public class FilesController : Controller
    {
        //In order to use PhysicalFileResult below, we need to inject the IHostingEnvironment to get the application's content root path.
        private IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FileResult()
        {
            return File("~/downloads/pdf-sample.pdf", "application/pdf");
        }

        [HttpGet]
        public IActionResult FileContentResult()
        {
            //Get the byte array for the document
            var pdfBytes = System.IO.File.ReadAllBytes("wwwroot/downloads/pdf-sample.pdf");

            //FileContentResult needs a byte array and returns a file with the specified content type.
            return new FileContentResult(pdfBytes, "application/pdf");
        }

        [HttpGet]
        public IActionResult FileStreamResult()
        {
            //Create a stream to read the file
            var fileStream = System.IO.File.OpenRead("wwwroot/downloads/pdf-sample.pdf");

            //Stream the file to the browser using the specified content type.
            return new FileStreamResult(fileStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult PhysicalFileResult()
        {
            return new PhysicalFileResult(_hostingEnvironment.ContentRootPath + "/wwwroot/downloads/pdf-sample.pdf", "application/pdf");
        }

        [HttpGet]
        public IActionResult VirtualFileResult()
        {
            //Paths given to the VirtualFileResult are relative to the wwwroot folder.
            return new VirtualFileResult("/downloads/pdf-sample.pdf", "application/pdf");
        }
    }
}