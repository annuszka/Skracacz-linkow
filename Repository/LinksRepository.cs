using System;
using System.Collections.Generic;
using System.Linq;
using HashidsNet;
using skracacz.Interfaces;
using skracacz.Models;

namespace skracacz.Repository
{
    public class LinksRepository : ILinksRepository
    {
        private List<Link> _links;

        public LinksRepository()
        {
            _links = new List<Link>
            {
                new Link { Id = 0, FullUrl = "https://softwaretalks.pl/wydarzenia/akademia-webdev-kurs-asp-net-corereactredux/", ShortUrl = "JKbw6m" }
            };
        }
        public void AddLink(Link link)
        {
            link.Id = _links.Count;

            var hashids = new Hashids("abcdefgh", 6);
            link.ShortUrl = hashids.Encode(link.Id);
            
            _links.Add(link);
        }

        public Link GetLink(string hash)
        {
            Link l = _links.Find(link => link.ShortUrl == hash);

            return l;
        }

        public List<Link> GetLinks()
        {
            return _links;
        }

        public void Delete(Link link)
        {
            var linkToDelete = _links
                .SingleOrDefault(element => element.FullUrl == link.FullUrl && element.ShortUrl == link.ShortUrl);
            _links.Remove(linkToDelete);
        }
    }
}
