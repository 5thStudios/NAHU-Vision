using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHUvision.Models
{
    public class ImisMember
    {
        public string Member { get; set; }
        public string Email { get; set; }
        public string MemberEditUrl { get; set; }
        public string ImisId { get; set; }
        public string Chapter { get; set; }
        public string MemberType { get; set; }
        public List<VideoLink> LstVideoLinks { get; set; }



        public ImisMember()
        {
            LstVideoLinks = new List<VideoLink>();
        }
    }
}
