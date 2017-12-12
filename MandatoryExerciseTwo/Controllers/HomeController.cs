using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MandatoryExerciseTwo.Models;
using Logic;

namespace MandatoryExerciseTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubmissionsService service;

        public HomeController(ISubmissionsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Submission submission)
        {
            if (ModelState.IsValid)
            {
                await service.RegisterSubmission(submission);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
