using skracacz.Models;
using System.Collections.Generic;

namespace skracacz.Interfaces
{
    public interface ILinksRepository
    {
        List<Link> GetLinks();
        void AddLink(Link link);
        void Delete(Link link);
        Link GetLink(string hash);
    }
}
