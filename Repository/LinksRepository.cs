using System;
using System.Collections.Generic;
using System.Linq;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using skracacz.Interfaces;
using skracacz.Models;

namespace skracacz.Repository
{
    public class LinksRepository : ILinksRepository
    {
        //private List<Link> _links;
        private readonly SkracaczDBContext _context;

        public LinksRepository(SkracaczDBContext context)
        {
            _context = context;
        }
        public Link Create(Link link)
        {            
            _context.Links.Add(link);
            _context.SaveChanges();
            var l = _context.Links.Where(m => (m.FullUrl == link.FullUrl && m.ShortUrl == null)).FirstOrDefault();
            link.Id = l.Id;

            var hashids = new Hashids("abcdefgh", 6);
            link.ShortUrl = hashids.Encode(link.Id);
            _context.Links.Attach(link);

            _context.SaveChanges();
            return link;
        }
        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public (IEnumerable<Link>, int) Get (string search, int skip)
        {
            var linksFilteredByFullUrl = search != null ? _context.Links
                .Where(x => x.FullUrl.Contains(search)) : _context.Links;

            var linksCount = linksFilteredByFullUrl.Count();

            var paginatedLink = linksFilteredByFullUrl
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(5);

            return (paginatedLink, linksCount);
        }
        public Link Get(int id)
        {
            return _context.Links.Find(id);
        }
        public void Delete(int id)
        {
            Link linkEntity = _context.Links.Find(id);
            _context.Links.Remove(linkEntity);
            _context.SaveChanges();

            /* var linkToDelete = _links
                 .SingleOrDefault(element => element.FullUrl == link.FullUrl && element.ShortUrl == link.ShortUrl);
             _links.Remove(linkToDelete);
             */
        }
        public List<Link> GetAll()
        {
            return _context.Links.ToList<Link>();
        }
      /*  public void AddLink(Link link)
        {
            link.Id = _links.Count;

            var hashids = new Hashids("abcdefgh", 6);
            link.ShortUrl = hashids.Encode(link.Id);
            
            _links.Add(link);
        }*/
      /*  
        public Link GetLink(string hash)
        {
            Link l = _links.Find(link => link.ShortUrl == hash);

            return l;
        }*/
       /* public List<Link> GetLinks()
        {
            return _links;
        }*/

        
    }
}
