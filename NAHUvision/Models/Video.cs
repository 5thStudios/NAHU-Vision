using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NAHUvision.Models
{
    public class Video
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string VimeoLink { get; set; }
        public string IframeUrl { get; set; }
        public string ImgUrl { get; set; }
        public string PageUrl { get; set; }
        public IHtmlString Description { get; set; }


        public Boolean LockedVideo { get; set; }
        public Boolean UnlockedVideo { get; set; }
        public Boolean CompletedVideo { get; set; }
        public Boolean IsSearchResult { get; set; }

        public List<string> LstAgencyMembership { get; set; }
        public List<string> LstChapterLeadershipTraining { get; set; }
        public List<string> LstComplianceCorner { get; set; }
        public List<string> LstLeadershipTools { get; set; }
        public List<string> LstMembership { get; set; }
        public List<string> LstProfessionalDevelopment { get; set; }
        public List<string> LstNationalCommittees { get; set; }
        public List<string> LstSocialMedia { get; set; }
        public List<string> LstCategories { get; set; }
        public List<Link> LstCategoryLinks { get; set; }



        public Video()
        {
            LstAgencyMembership = new List<string>();
            LstChapterLeadershipTraining = new List<string>();
            LstComplianceCorner = new List<string>();
            LstLeadershipTools = new List<string>();
            LstMembership = new List<string>();
            LstNationalCommittees = new List<string>();
            LstProfessionalDevelopment = new List<string>();
            LstSocialMedia = new List<string>();
            LstCategories = new List<string>();
            LstCategoryLinks = new List<Link>();
        }
    }
}
