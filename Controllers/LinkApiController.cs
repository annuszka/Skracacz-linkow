using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using skracacz.Interfaces;
using skracacz.Models;
using skracacz.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace skracacz.Controllers
{
  //  [Route("api/[controller]")]
    public class LinkApiController : Controller
    {
        private readonly ILinksRepository repository;
        private int itemPerPage = 5;
        public LinkApiController(ILinksRepository repository)
        {
            this.repository = repository;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpGet("{id}")]
        // GET api/links/{id}
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        //GET api/links/?search={string}&page={int}
        [HttpGet("[action]")]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = repository
                    .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            
                return Ok(result);
        }

        // DELETE api/links/{id}
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return Ok();
        }

        //POST api/links
        [HttpPost]
        public IActionResult AddLink(string FullUrl)
        {
            Link l = new Link();
            l.FullUrl = FullUrl;
            return Ok(repository.Create(l));
        }

        //POST api/links
        [HttpPut("{link}")]
        public IActionResult Put([FromBody]Link link)
        {
            return Ok(repository.Update(link));
        }
    }
}
