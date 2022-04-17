using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class ConcertsController : BaseController
    {
        private readonly IConcertsService concertService;

        public ConcertsController(IConcertsService concertService)
        {
            this.concertService = concertService;
        }
        
        
        public IActionResult Index()
        {
            var data = concertService.GetAllConcerts();            
            return View(data);
        }

        public IActionResult Details(int id)
        {
           //TODO
            
            return View();
        }

    }
}
