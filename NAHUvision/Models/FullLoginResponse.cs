using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHUvision.Models
{
    public class FullLoginResponse
    {
        public bool IsValidated { get; set; }
        public string SessionToken { get; set; }
        public string StatusMessage { get; set; }
        public string ImisUserId { get; set; }
        public IList<CookieStructure> CookieStructures { get; set; }
    }
}
