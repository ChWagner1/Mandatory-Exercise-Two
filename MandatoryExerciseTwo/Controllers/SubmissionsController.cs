using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MandatoryExerciseTwo.Models;
using Logic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MandatoryExerciseTwo.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService service;

        public SubmissionsController(ISubmissionsService service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public async Task< IActionResult> Submissions()
        {
            return View(await service.GetAll());
        }
        
    }
}
