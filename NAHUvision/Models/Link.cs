using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAHUvision.Models
{
    public class Link
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int? Level { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Abr { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public List<Link> LstChildrenLinks { get; set; }
        public Boolean HasChildren { get; set; } = false;
        public Boolean Selected { get; set; }



        public Link(int _id = 0, string _name = "", string _parentName = "", string _abr = "", string _category = "", string _url = "", Boolean _selected = false)
        {
            Id = _id;
            Name = _name;
            ParentName = _parentName;
            Abr = _abr;
            Url = _url;
            Selected = _selected;
            Category = _category;
            LstChildrenLinks = new List<Link>();
        }
    }
}
