using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Text;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using NAHUvision.Models;
using System;
using System.Web;
using Umbraco.Web;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Examine.Providers;
using Examine;
using Examine.SearchCriteria;
using Examine.LuceneEngine.SearchCriteria;
using System.Diagnostics;

namespace NAHUvision.Controller
{
    public class VideoController : SurfaceController
    {
        #region "Renders"
        public ActionResult RenderVideoList(IPublishedContent ipModel, Boolean isLoggedIn, string searchParam = "", string loginResponse = "")
        {
            //Instantiate scope variables
            List<NAHUvision.Models.Video> LstVideos = new List<NAHUvision.Models.Video>();

            try
            {
                //Instantiate variables
                List<int> LstSearchIDs = new List<int>();
                List<int> lstVideoIDs = new List<int>();

                //Obtain a list of watched videos by this member
                if (!string.IsNullOrEmpty(loginResponse))
                {
                    FullLoginResponse fullLoginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<FullLoginResponse>(loginResponse);
                    Int32 id = NAHUvision.Controller.MemberController.GetMemberId_byImisId(fullLoginResponse.ImisUserId);
                    IMember member = ApplicationContext.Current.Services.MemberService.GetById(id);
                    lstVideoIDs = NAHUvision.Controller.MemberController.ObtainListOfCompletedVideos_byMember(member);
                }

                //get list of all IDs that match search criteria
                //foreach ipvideo if lst contains id then add 'search' as class so filter can show/hide
                if (!string.IsNullOrWhiteSpace(searchParam))
                {
                    LstSearchIDs = ObtainSearchResults(searchParam.Trim().ToLower(), ipModel);
                }

                //Loop through all videos
                foreach (IPublishedContent ipVideo in ipModel.Children.Where(x => x.DocumentTypeAlias == Common.DocType.Video).ToList())
                {
                    //Instantiate variables
                    NAHUvision.Models.Video video = new NAHUvision.Models.Video();

                    //Obtain video data
                    video.Id = ipVideo.Id;
                    video.PageUrl = ipVideo.Url();
                    if (ipVideo.HasValue(Common.NodeProperties.DatePublished)) video.DatePublished = ipVideo.GetPropertyValue<DateTime>(Common.NodeProperties.DatePublished);
                    if (ipVideo.HasValue(Common.NodeProperties.Title)) video.Title = ipVideo.GetPropertyValue<string>(Common.NodeProperties.Title);

                    //Obtain the image url.  [used 2 different methods to obtain url based on if the image has an Id or is an IPublishedContent]
                    try
                    {
                        if (ipVideo.HasValue(Common.NodeProperties.VideoImage)) video.ImgUrl = ipVideo.GetPropertyValue<IPublishedContent>(Common.NodeProperties.VideoImage).GetCropUrl(Common.Crop.Square_500x500);
                    }
                    catch
                    {
                        try
                        {
                            if (ipVideo.HasValue(Common.NodeProperties.VideoImage)) video.ImgUrl = Umbraco.TypedMedia(ipVideo.GetPropertyValue<int>(Common.NodeProperties.VideoImage)).GetCropUrl(Common.Crop.Square_500x500);
                        }
                        catch { }
                    }

                    video.LockedVideo = ipVideo.GetPropertyValue<Boolean>(Common.NodeProperties.PrivateVideo);
                    video.UnlockedVideo = false;
                    video.CompletedVideo = false;

                    //If user is logged in, show locked videos as unlocked and if video has been watched
                    if (isLoggedIn)
                    {
                        if (video.LockedVideo)
                        {
                            video.LockedVideo = false;
                            video.UnlockedVideo = true;
                        }
                        if (lstVideoIDs.Contains(video.Id))
                        {
                            video.CompletedVideo = true;
                        }
                    }

                    //Obtain a list of all selected categories
                    if (ipVideo.HasValue(Common.NodeProperties.AgencyMembership)) video.LstAgencyMembership = ipVideo.GetPropertyValue<string>(Common.NodeProperties.AgencyMembership).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.ChapterLeadershipTraining)) video.LstChapterLeadershipTraining = ipVideo.GetPropertyValue<string>(Common.NodeProperties.ChapterLeadershipTraining).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.ComplianceCorner)) video.LstComplianceCorner = ipVideo.GetPropertyValue<string>(Common.NodeProperties.ComplianceCorner).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.LeadershipTools)) video.LstLeadershipTools = ipVideo.GetPropertyValue<string>(Common.NodeProperties.LeadershipTools).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.Membership)) video.LstMembership = ipVideo.GetPropertyValue<string>(Common.NodeProperties.Membership).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.ProfessionalDevelopment)) video.LstProfessionalDevelopment = ipVideo.GetPropertyValue<string>(Common.NodeProperties.ProfessionalDevelopment).Split(',').ToList();
                    if (ipVideo.HasValue(Common.NodeProperties.SocialMedia)) video.LstSocialMedia = ipVideo.GetPropertyValue<string>(Common.NodeProperties.SocialMedia).Split(',').ToList();

                    //Consolidate lists
                    foreach (string category in video.LstAgencyMembership)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.AgencyMembership;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstChapterLeadershipTraining)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.ChapterLeadershipTraining;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstComplianceCorner)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.ComplianceCorner;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstLeadershipTools)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.LeadershipTools;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstMembership)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.Membership;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstProfessionalDevelopment)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.ProfessionalDevelopment;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }
                    foreach (string category in video.LstSocialMedia)
                    {
                        Link categoryLink = new Link();
                        categoryLink.Name = category;
                        categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                        categoryLink.ParentName = Common.NodeProperties.SocialMedia;
                        categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                        video.LstCategoryLinks.Add(categoryLink);
                        video.LstCategories.Add(categoryLink.Category);
                    }

                    //Determine if this video is part of the search result
                    if (LstSearchIDs.Contains(video.Id))
                    {
                        video.IsSearchResult = true;
                    }

                    //video.IframeUrl = Newtonsoft.Json.JsonConvert.SerializeObject(video.LstCategoryLinks);

                    LstVideos.Add(video);
                }

            }
            catch (Exception ex)
            {
                //Save error to log
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("VideoController | RenderVideoList()");
                sb.AppendLine("Videos:");
                sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(LstVideos));
                Common.SaveErrorMessage(ex, sb, typeof(VideoController));
            }


            return PartialView("~/Views/Partials/Video/VideoList.cshtml", LstVideos);
        }
        #endregion


        #region "Methods"
        public static Models.Video ObtainVideoData(IPublishedContent ipModel, Boolean isLoggedIn, string loginResponse = "")
        {
            //Instantiate variables
            List<int> lstVideoIDs = new List<int>();
            Models.Video video = new Models.Video();

            //Obtain a list of watched videos by this member
            if (!string.IsNullOrEmpty(loginResponse))
            {
                FullLoginResponse fullLoginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<FullLoginResponse>(loginResponse);
                Int32 id = NAHUvision.Controller.MemberController.GetMemberId_byImisId(fullLoginResponse.ImisUserId);
                IMember member = ApplicationContext.Current.Services.MemberService.GetById(id);
                lstVideoIDs = NAHUvision.Controller.MemberController.ObtainListOfCompletedVideos_byMember(member);
            }

            //Obtain data
            video.Id = ipModel.Id;
            video.Title = ipModel.GetPropertyValue<string>(Common.NodeProperties.Title);
            video.DatePublished = ipModel.GetPropertyValue<DateTime>(Common.NodeProperties.DatePublished);
            video.Description = new HtmlString(ipModel.GetPropertyValue<string>(Common.NodeProperties.Description));
            video.VimeoLink = ipModel.GetPropertyValue<string>(Common.NodeProperties.VimeoLink);

            video.LockedVideo = ipModel.GetPropertyValue<Boolean>(Common.NodeProperties.PrivateVideo);
            video.UnlockedVideo = false;
            video.CompletedVideo = false;

            //If user is logged in, show locked videos as unlocked and if video has been watched
            if (isLoggedIn)
            {
                if (video.LockedVideo)
                {
                    video.LockedVideo = false;
                    video.UnlockedVideo = true;
                }
                if (lstVideoIDs.Contains(video.Id))
                {
                    video.CompletedVideo = true;
                }
            }

            //Split url into segments.  The first full numeric set is the video id.  Add to player url.
            int videoId = 0;
            foreach (String seg in video.VimeoLink.Split('/'))
            {
                bool isNumeric = Int32.TryParse(seg, out videoId);
                if (isNumeric)
                {
                    //Determine if video controls should be shown or not.
                    if (ipModel.GetPropertyValue<Boolean>(Common.NodeProperties.AllowVideoControls))
                    {
                        video.IframeUrl = "https://player.vimeo.com/video/" + videoId.ToString() + "?controls=true";
                    }
                    else
                    {
                        video.IframeUrl = "https://player.vimeo.com/video/" + videoId.ToString() + "?controls=false";
                    }
                    break;
                }
            }

            //Obtain a list of all selected categories
            if (ipModel.HasValue(Common.NodeProperties.AgencyMembership)) video.LstAgencyMembership = ipModel.GetPropertyValue<string>(Common.NodeProperties.AgencyMembership).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.ChapterLeadershipTraining)) video.LstChapterLeadershipTraining = ipModel.GetPropertyValue<string>(Common.NodeProperties.ChapterLeadershipTraining).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.ComplianceCorner)) video.LstComplianceCorner = ipModel.GetPropertyValue<string>(Common.NodeProperties.ComplianceCorner).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.LeadershipTools)) video.LstLeadershipTools = ipModel.GetPropertyValue<string>(Common.NodeProperties.LeadershipTools).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.Membership)) video.LstMembership = ipModel.GetPropertyValue<string>(Common.NodeProperties.Membership).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.ProfessionalDevelopment)) video.LstProfessionalDevelopment = ipModel.GetPropertyValue<string>(Common.NodeProperties.ProfessionalDevelopment).Split(',').ToList();
            if (ipModel.HasValue(Common.NodeProperties.SocialMedia)) video.LstSocialMedia = ipModel.GetPropertyValue<string>(Common.NodeProperties.SocialMedia).Split(',').ToList();

            //Consolidate lists
            foreach (string category in video.LstAgencyMembership)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.AgencyMembership;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstChapterLeadershipTraining)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.ChapterLeadershipTraining;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstComplianceCorner)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.ComplianceCorner;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstLeadershipTools)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.LeadershipTools;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstMembership)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.Membership;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstProfessionalDevelopment)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.ProfessionalDevelopment;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }
            foreach (string category in video.LstSocialMedia)
            {
                Link categoryLink = new Link();
                categoryLink.Name = category;
                //categoryLink.Abr = category.Replace(" ", "");
                categoryLink.Abr = Regex.Replace(category.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                categoryLink.ParentName = Common.NodeProperties.SocialMedia;
                categoryLink.Category = categoryLink.ParentName + "-" + categoryLink.Abr;
                video.LstCategoryLinks.Add(categoryLink);
                video.LstCategories.Add(categoryLink.Category);
            }




            return video;
        }
        private List<int> ObtainSearchResults(string searchFor, IPublishedContent ipModel)
        {
            //// Create new stopwatch.
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            ////Instantiate variables
            //List<int> LstSearchIDs = new List<int>();
            //BaseSearchProvider mySearcher = ExamineManager.Instance.SearchProviderCollection[Common.SearchProviders.ExternalSearcher];
            //ISearchCriteria criteria = mySearcher.CreateSearchCriteria(BooleanOperation.Or);

            ////Setup up search fields by importance
            //IBooleanOperation query = criteria.Field(Common.NodeProperties.NodeName, searchFor.MultipleCharacterWildcard());
            //query.Or().Field(Common.NodeProperties.Title, searchFor.MultipleCharacterWildcard());
            //query.Or().Field(Common.NodeProperties.Description, searchFor.MultipleCharacterWildcard());

            ////Obtain result with query
            //ISearchResults searchResults = mySearcher.Search(query.Compile());

            ////Add IDs to list
            //foreach (SearchResult sRecord in searchResults)
            //{
            //    LstSearchIDs.Add(sRecord.Id);
            //}


            ////Instantiate variables
            //List<int> LstSearchIDs = new List<int>();
            //BaseSearchProvider mySearcher = ExamineManager.Instance.DefaultSearchProvider;
            //ISearchCriteria criteria = mySearcher.CreateSearchCriteria("content");

            ////IBooleanOperation query = criteria.Field("nodeTypeAlias", "video");
            //IBooleanOperation query = criteria.NodeTypeAlias("video");
            ////query.And().Field("isPublished", "true");
            //query.And().GroupedOr(new string[] {
            //    Common.NodeProperties.NodeName,
            //    Common.NodeProperties.Title,
            //    Common.NodeProperties.Description },
            //    searchFor.MultipleCharacterWildcard());

            ////Obtain result with query
            //ISearchResults searchResults = mySearcher.Search(query.Compile());

            ////Add IDs to list
            //foreach (SearchResult sRecord in searchResults)
            //{
            //    LstSearchIDs.Add(sRecord.Id);
            //}


            //=========================================================================================

            //Instantiate variables
            List<int> LstSearchIDs = new List<int>();

            foreach (IPublishedContent ipVideo in ipModel.Children.Where(
                x => x.Name.ToLower().Contains(searchFor) ||
                x.GetPropertyValue<string>(Common.NodeProperties.Title).ToLower().Contains(searchFor) ||
                x.GetPropertyValue<string>(Common.NodeProperties.Description).ToLower().Contains(searchFor)
                ).ToList())
            {
                LstSearchIDs.Add(ipVideo.Id);
            }

            //=========================================================================================

            //// Stop timing and record in log
            //stopwatch.Stop();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("VideoController | ObtainSearchResults()");
            //sb.AppendLine("Time Lapse for Examine NAHUvisionSearcher:");
            //sb.AppendLine(stopwatch.Elapsed.ToString(@"m\:ss\.fff"));
            //Exception ex = new Exception("Time Lapse for Examine NAHUvisionSearcher");
            //Common.SaveErrorMessage(ex, sb, typeof(VideoController), true);



            return LstSearchIDs;
        }
        #endregion
    }
}