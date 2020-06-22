using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHUvision.Models
{
    public class CookieStructure
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public string Expires { get; set; }
        public bool IsHttpOnly { get; set; }
        public bool IsSecure { get; set; }
    }
}
