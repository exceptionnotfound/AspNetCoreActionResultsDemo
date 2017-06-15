using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreActionResultsDemo.Controllers
{
    public class StatusCodesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OkResult()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult CreatedResult()
        {
            return Created("http://example.org/myitem", new { name = "testitem" });
        }

        [HttpGet]
        public IActionResult NoContentResult()
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult BadRequestResult()
        {
            return BadRequest();
        }

        [HttpGet]
        public IActionResult UnauthorizedResult()
        {
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult NotFoundResult()
        {
            return NotFound();
        }

        [HttpGet]
        public IActionResult UnsupportedMediaTypeResult()
        {
            return new UnsupportedMediaTypeResult();
        }

        [HttpGet]
        public IActionResult StatusCodeResult(int statusCode)
        {
            return StatusCode(statusCode);
        }
    }
}