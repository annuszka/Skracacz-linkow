using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skracacz.Models
{
    public class SearchResult
    {
        public IEnumerable<LinkResult> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }

        public int MaxPage { get; set; }
    }
    public class LinkResult
    {
        public LinkResult(Link link)
        {
            Id = link.Id;
            FullUrl = link.FullUrl;
            ShortUrl = link.ShortUrl;
        }
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}   