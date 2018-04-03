using skracacz.Models;
using System.Collections.Generic;

namespace skracacz.Interfaces
{
    public interface ILinksRepository
    {
        (IEnumerable<Link>, int) Get(string search, int skip);
        Link Get(int Id);
        List<Link> GetAll();
        Link Create(Link link);
        Link Update(Link link);
        void Delete(int id);
    }
}
