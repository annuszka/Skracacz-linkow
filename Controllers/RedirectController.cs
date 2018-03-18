using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using skracacz.Models;
using HashidsNet;
using skracacz.Interfaces;

namespace skracacz.Controllers
{
    public class RedirectController : Controller
    {
        public ILinksRepository _repository;

        public RedirectController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet]
        public IActionResult RedirectToSite(string shortUrl)
        {
            Link link = _repository.GetLink(shortUrl);

            if (link == null)
                return Content("Nie ma takiej strony, nieprawidłowy adres!!");

            if(!(link.FullUrl.StartsWith("http://") || link.FullUrl.StartsWith("https://")))
            {
                link.FullUrl = "http://" + link.FullUrl;
            }

            return Redirect(link.FullUrl);
        }

    }
}