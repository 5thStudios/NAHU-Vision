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
using Examine;
using Examine.Providers;
using Umbraco.Web;
using System.Linq;

namespace NAHUvision.Controller
{
    public class NavigationController : SurfaceController
    {
        #region "Renders"
        public ActionResult RenderNavigation_Minor()
        {
            return PartialView("~/Views/Partials/Video/Navigation_Minor.cshtml", ObtainMinorNavLinks());
        }
        public ActionResult RenderNavigation_Main()
        {
            //
            List<NAHUvision.Models.Link> lstSortedNavLink = new List<NAHUvision.Models.Link>();

            try
            {
                ////Save error to log
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine("NavigationController | RenderNavigation_Main()");
                //sb.AppendLine(" ~TEST~ ");
                //Exception tempExc = new Exception();
                //Common.SaveErrorMessage(tempExc, sb, typeof(NavigationController));

                //Instantiate variables
                int parentLevel = 3;
                int childLevel = 4;
                List<NAHUvision.Models.Link> lstUnsortedLinks = new List<Link>();
                //int rootHomeNodeId = Umbraco.TypedContentAtRoot().FirstOrDefault().Id;
                IPublishedContent ipRoot = Umbraco.TypedContentAtRoot().FirstOrDefault();

                // Loop thru each id and build link list
                foreach (var result in ipRoot.Descendants().Where(x => x.GetPropertyValue<Boolean>(Common.NodeProperties.ShowInNavigation) == true))
                {
                    //Instantiate variables
                    IPublishedContent ipNode = Umbraco.TypedContent(result.Id);
                    List<int> LstPathIDs = new List<int>();
                    foreach (string id in ipNode.Path.Split(','))
                    {
                        LstPathIDs.Add(Convert.ToInt32(id));
                    }
                    int level = LstPathIDs.Count;

                    // Add to list only if the node's level does not exceed the max level and is part of the main site.
                    if (level <= childLevel)
                    {
                        //Create link
                        Link link = new Link();
                        link.Id = ipNode.Id;
                        link.Name = ipNode.Name;
                        link.Url = ipNode.UrlAbsolute();
                        link.Level = level;
                        link.ParentId = ipNode.Parent.Id;
                        if (level == parentLevel) { link.HasChildren = true; }
                        lstUnsortedLinks.Add(link);
                    }
                }

                //=========================================================================================
                //// Instantiate search provider and criteria
                //BaseSearchProvider searchProvider = ExamineManager.Instance.DefaultSearchProvider;
                //Examine.SearchCriteria.ISearchCriteria searchCriteria = searchProvider.CreateSearchCriteria();

                //// Obtain all marked items sorted by name
                //var query = searchCriteria.Field(Common.NodeProperties.ShowInNavigation, System.Convert.ToInt32(true).ToString());
                //var searchResults = searchProvider.Search(query.Compile());

                //// Loop thru each id and build link list
                //foreach (Examine.SearchResult result in searchResults)
                //{
                //    //Instantiate variables
                //    IPublishedContent ipNode = Umbraco.TypedContent(result.Id);
                //    List<int> LstPathIDs = new List<int>();
                //    foreach (string id in ipNode.Path.Split(','))
                //    {
                //        LstPathIDs.Add(Convert.ToInt32(id));
                //    }
                //    int level = LstPathIDs.Count;

                //    // Add to list only if the node's level does not exceed the max level and is part of the main site.
                //    if (ipNode.AncestorOrSelf(1).Id == rootHomeNodeId && level <= childLevel)
                //    {
                //        //Create link
                //        Link link = new Link();
                //        link.Id = ipNode.Id;
                //        link.Name = ipNode.Name;
                //        link.Url = ipNode.UrlAbsolute();
                //        link.Level = level;
                //        link.ParentId = ipNode.Parent.Id;
                //        if (level == parentLevel) { link.HasChildren = true; }
                //        lstUnsortedLinks.Add(link);
                //    }
                //}
                //=========================================================================================



                foreach (NAHUvision.Models.Link parentLink in lstUnsortedLinks.Where(x => x.HasChildren == true))
                {
                    foreach (NAHUvision.Models.Link childLink in lstUnsortedLinks.Where(x => x.ParentId == parentLink.Id))
                    {
                        parentLink.LstChildrenLinks.Add(childLink);
                    }
                    lstSortedNavLink.Add(parentLink);
                }

            }
            catch (Exception ex)
            {
                //Save error to log
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("NavigationController | RenderNavigation_Main()");
                Common.SaveErrorMessage(ex, sb, typeof(NavigationController));
            }
            
            return PartialView("~/Views/Partials/Video/Navigation_Main.cshtml", lstSortedNavLink);
        }
        public ActionResult RenderNavigation_Mega()
        {
            //Instantiate variables
            int parentLevel = 3;
            int childLevel = 4;
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            List<NAHUvision.Models.Link> lstUnsortedLinks = new List<Link>();
            IPublishedContent ipRoot = Umbraco.TypedContentAtRoot().FirstOrDefault();
            //int rootHomeNodeId = Umbraco.TypedContentAtRoot().FirstOrDefault().Id;

            // Loop thru each id and build link list
            foreach (IPublishedContent ipNode in ipRoot.Descendants().Where(x => x.GetPropertyValue<Boolean>(Common.NodeProperties.ShowInMegamenu) == true))
            {
                //Instantiate variables
                List<int> LstPathIDs = new List<int>();
                foreach (string id in ipNode.Path.Split(','))
                {
                    LstPathIDs.Add(Convert.ToInt32(id));
                }
                int level = LstPathIDs.Count;

                // Add to list only if the node's level does not exceed the max level and is part of the main site.
                if (level <= childLevel)
                {
                    //Create link
                    Link link = new Link();
                    link.Id = ipNode.Id;
                    link.Name = ipNode.Name;
                    link.Url = ipNode.UrlAbsolute();
                    link.Level = level;
                    link.ParentId = ipNode.Parent.Id;
                    if (level == parentLevel) { link.HasChildren = true; }

                    lstUnsortedLinks.Add(link);
                }
            }

            //=========================================================================================
            //// Instantiate search provider and criteria
            ////BaseSearchProvider searchProvider = ExamineManager.Instance.SearchProviderCollection[Common.SearchProviders.NavigationSearcher];
            //BaseSearchProvider searchProvider = ExamineManager.Instance.DefaultSearchProvider;
            //Examine.SearchCriteria.ISearchCriteria searchCriteria = searchProvider.CreateSearchCriteria();

            //// Obtain all marked items sorted by name
            //var query = searchCriteria.Field(Common.NodeProperties.ShowInMegamenu, System.Convert.ToInt32(true).ToString());
            //var searchResults = searchProvider.Search(query.Compile());

            //// Loop thru each id and build link list
            //foreach (Examine.SearchResult result in searchResults)
            //{
            //    //Instantiate variables
            //    IPublishedContent ipNode = umbHelper.TypedContent(result.Id);
            //    List<int> LstPathIDs = new List<int>();
            //    foreach (string id in ipNode.Path.Split(','))
            //    {
            //        LstPathIDs.Add(Convert.ToInt32(id));
            //    }
            //    int level = LstPathIDs.Count;

            //    // Add to list only if the node's level does not exceed the max level and is part of the main site.
            //    if (ipNode.AncestorOrSelf(1).Id == rootHomeNodeId && level <= childLevel)
            //    {
            //        //Create link
            //        Link link = new Link();
            //        link.Id = ipNode.Id;
            //        link.Name = ipNode.Name;
            //        link.Url = ipNode.UrlAbsolute();
            //        //link.LstPathIDs = LstPathIDs;
            //        link.Level = level;
            //        link.ParentId = ipNode.Parent.Id;
            //        //link.Path = ipNode.Path;
            //        //link.SortOrder = ipNode.SortOrder;
            //        //link.ExternalLink = ipNode.DocumentTypeAlias.Equals(Common.DocType.ExternalLink);
            //        if (level == parentLevel) { link.HasChildren = true; }

            //        lstUnsortedLinks.Add(link);
            //    }
            //}
            //=========================================================================================


            //Sort nav list into parent/child relationships
            List<NAHUvision.Models.Link> lstSortedNavLink = new List<NAHUvision.Models.Link>();
            foreach (NAHUvision.Models.Link parentLink in lstUnsortedLinks.Where(x => x.HasChildren == true))
            {
                foreach (NAHUvision.Models.Link childLink in lstUnsortedLinks.Where(x => x.ParentId == parentLink.Id))
                {
                    parentLink.LstChildrenLinks.Add(childLink);
                }
                lstSortedNavLink.Add(parentLink);
            }

            return PartialView("~/Views/Partials/Video/Navigation_Mega.cshtml", lstSortedNavLink);
        }
        #endregion


        #region "Methods"
        public static List<NAHUvision.Models.Link> ObtainMinorNavLinks()
        {
            //Instantiate variables
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            List<NAHUvision.Models.Link> lstLinks = new List<Link>();
            //int rootHomeNodeId = umbHelper.TypedContentAtRoot().FirstOrDefault().Id;
            IPublishedContent ipRoot = umbHelper.TypedContentAtRoot().FirstOrDefault();

            // Loop thru each id and build link list
            foreach (IPublishedContent ipNode in ipRoot.Descendants().Where(x => x.GetPropertyValue<Boolean>(Common.NodeProperties.ShowInEyebrowNavigation) == true))
            {
                //Create link
                Link link = new Link();
                link.Id = ipNode.Id;
                link.Name = ipNode.Name;
                link.Url = ipNode.UrlAbsolute();
                lstLinks.Add(link);
            }

            //=========================================================================================
            //// Instantiate search provider and criteria
            ////BaseSearchProvider searchProvider = ExamineManager.Instance.SearchProviderCollection[Common.SearchProviders.NavigationSearcher];
            //BaseSearchProvider searchProvider = ExamineManager.Instance.DefaultSearchProvider;
            //Examine.SearchCriteria.ISearchCriteria searchCriteria = searchProvider.CreateSearchCriteria();

            //// Obtain all marked items sorted by name
            //var query = searchCriteria.Field(Common.NodeProperties.ShowInEyebrowNavigation, System.Convert.ToInt32(true).ToString()).And().OrderBy(Common.NodeProperties.NodeName);
            //query.And().Field("isPublished", "true");
            //var searchResults = searchProvider.Search(query.Compile());

            //// Loop thru each id and build links
            //foreach (Examine.SearchResult result in searchResults)
            //{
            //    //Instantiate variables
            //    IPublishedContent ipNode = umbHelper.TypedContent(result.Id);

            //    // Add to list only if the node's level does not exceed the max level and is part of the main site.
            //    if (ipNode.AncestorOrSelf(1).Id == rootHomeNodeId)
            //    {
            //        //Create link
            //        Link link = new Link();
            //        link.Id = ipNode.Id;
            //        link.Name = ipNode.Name;
            //        link.Url = ipNode.UrlAbsolute();
            //        lstLinks.Add(link);
            //    }
            //}
            //=========================================================================================

            return lstLinks;
        }
        public static List<NAHUvision.Models.SocialLink> ObtainSocialLinks()
        {
            //Instantiate variables
            List<NAHUvision.Models.SocialLink> LstSocialLinks = new List<SocialLink>();
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            IPublishedContent ipHome = umbHelper.TypedContentAtRoot().FirstOrDefault();

            //
            SocialLink link = new SocialLink();
            link.ImgUrl = "../images/common/icons/facebook.png";
            link.Title = "Facebook";
            link.Url = ipHome.GetPropertyValue<string>(Common.NodeProperties.FacebookFollowUSURL);
            LstSocialLinks.Add(link);

            link = new SocialLink();
            link.ImgUrl = "../images/common/icons/twitter.png";
            link.Title = "Twitter";
            link.Url = ipHome.GetPropertyValue<string>(Common.NodeProperties.TwitterFollowUSURL);
            LstSocialLinks.Add(link);

            link = new SocialLink();
            link.ImgUrl = "../images/common/icons/youtube.png";
            link.Title = "YouTube";
            link.Url = ipHome.GetPropertyValue<string>(Common.NodeProperties.YouTubeFollowUSURL);
            LstSocialLinks.Add(link);

            link = new SocialLink();
            link.ImgUrl = "../images/common/icons/linkedin.png";
            link.Title = "LinkedIn";
            link.Url = ipHome.GetPropertyValue<string>(Common.NodeProperties.LinkedInFollowUSURL);
            LstSocialLinks.Add(link);

            link = new SocialLink();
            link.ImgUrl = "../images/common/icons/b2b.png";
            link.Title = "B2B";
            link.Url = ipHome.GetPropertyValue<string>(Common.NodeProperties.B2BFollowUSURL);
            LstSocialLinks.Add(link);

            return LstSocialLinks;
        }
        #endregion
    }
}