using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace skracacz.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
