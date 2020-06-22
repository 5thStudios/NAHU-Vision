using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHUvision.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AbrList { get; set; }
        public List<Link> LstLinks { get; set; }



        public Filter()
        {
            LstLinks = new List<Link>();
        }
    }
}
