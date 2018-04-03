using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skracacz.Models
{
    public class GetLinkRequest
    {
        public int? Page { get; set; } = 1;
        public string Search { get; set; }
    }
}
