using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skracacz.Interfaces;
using skracacz.Models;

namespace skracacz.Controllers
{
    public class LinkController : Controller
    {
        private ILinksRepository _repository;

        public LinkController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var links = _repository.GetLinks();
            return View(links);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
              _repository.AddLink(link);
                        
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link);
            return Redirect("Index");
        }               
    }
}