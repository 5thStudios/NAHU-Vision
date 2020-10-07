using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using umbraco;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;


namespace NAHUvision.Models
{
    public sealed class Common
    {
        #region "Properties"
        public enum SiteNode : int
        {
            NahuVisionHome = 69524
        }

        public struct NodeProperties
        {
            public const string AgencyMembership = "agencyMembership";
            public const string AllowVideoControls = "allowVideoControls";
            public const string B2BFollowUSURL = "b2BFollowUSURL";
            public const string Chapter = "chapter";
            public const string ChapterLeadershipTraining = "chapterLeadershipTraining";
            public const string CompletedVideos = "completedVideos";
            public const string ComplianceCorner = "complianceCorner";
            public const string DatePublished = "datePublished";
            public const string Description = "description";
            public const string Email = "email";
            public const string FacebookFollowUSURL = "facebookFollowUSURL";
            public const string FirstName = "firstName";
            public const string ImisId = "imisId";
            public const string LastName = "lastName";
            public const string LeadershipTools = "leadershipTools";
            public const string LinkedInFollowUSURL = "linkedInFollowUSURL";
            public const string Membership = "membership";
            public const string MemberType = "memberType";
            public const string NationalCommittees = "nationalCommittees";
            public const string NodeName = "nodeName";
            public const string PhoneNumber = "phoneNumber";
            public const string PrivateVideo = "privateVideo";
            public const string ProfessionalDevelopment = "professionalDevelopment";
            public const string SocialMedia = "socialMedia";
            public const string SaveErrorMessage = "saveErrorMessage";
            public const string ShowInEyebrowNavigation = "showInEyebrowNavigation";
            public const string ShowInMegamenu = "showInMegamenu";
            public const string ShowInNavigation = "showInNavigation";
            public const string Title = "title";
            public const string TwitterFollowUSURL = "twitterFollowUSURL";
            public const string VideoImage = "videoImage";
            public const string VimeoClientId = "vimeoClientId";
            public const string VimeoLink = "vimeoLink";
            public const string YouTubeFollowUSURL = "youTubeFollowUSURL";
        }
        public struct DocType
        {
            public const string AppStartEvents = "appStartEvents";
            public const string DataLayer = "dataLayer";
            public const string ExternalLink = "externalLink";
            public const string Home = "home";
            public const string HomeMicrosite = "homeMicrosite";
            public const string HomeVideo = "homeVideo";
            public const string Video = "video";
        }
        public struct DataType
        {
            public const string AgencyMembership = "Agency Membership";
            public const string ChapterLeadershipTraining = "Chapter Leadership Training";
            public const string ComplianceCorner = "Compliance Corner";
            public const string LeadershipTools = "Leadership Tools";
            public const string Membership = "Membership";
            public const string NationalCommittees = "National Committees";
            public const string ProfessionalDevelopment = "Professional Development";
            public const string SocialMedia = "Social Media";
        }
        public struct Crop
        {
            public const string Square_500x500 = "Square_500x500";
        }     
        public struct Miscellaneous
        {
            public const string SearchResult = "search-result";
        }
        #endregion


        #region "Methods"
        public static int getHomeNodeId(int _thisNodeId)
        {
            try
            {
                // Instantiate variables
                UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
                IPublishedContent ipNode = umbHelper.TypedContent(_thisNodeId);
                return ipNode.AncestorOrSelf(1).Id;
                // Determine if node is 2nd level or not.
                //switch (ipNode.DocumentTypeAlias)
                //{
                //    case object _ when DocType.Home:
                //    case object _ when DocType.HomeMicrosite:
                //        {
                //            return _thisNodeId;
                //        }

                //    case object _ when aliases.dataLayer:
                //        {
                //            return _thisNodeId;
                //        }

                //    default:
                //        {
                //            return getHomeNodeId(thisNode.Parent.Id);
                //        }
                //}
            }
            catch
            {
                return -1;
            }
        }

        public static void SaveErrorMessage(Exception ex, StringBuilder sb, Type type, bool saveAsWarning = false)
        {
            StringBuilder sbGeneralInfo = new StringBuilder();

            try
            {
                UmbracoHelper umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                bool SaveErrorMsgs = false;
                IPublishedContent ipData = umbracoHelper.TypedContentAtRoot().FirstOrDefault(x => x.ContentType.Alias.Equals(DocType.DataLayer));
                IPublishedContent ipAppStartEvents = ipData.FirstChild<IPublishedContent>(x => x.ContentType.Alias.Equals(DocType.AppStartEvents));
                if (ipAppStartEvents.HasProperty(NodeProperties.SaveErrorMessage))
                    SaveErrorMsgs = ipAppStartEvents.GetPropertyValue<bool>(NodeProperties.SaveErrorMessage);

                if (SaveErrorMsgs)
                {
                    try
                    {
                        StackTrace st = new StackTrace(ex, true);
                        StackFrame frame = st.GetFrame(0);
                        sbGeneralInfo.AppendLine("fileName: " + frame.GetFileName());
                        sbGeneralInfo.AppendLine("methodName: " + frame.GetMethod().Name);
                        sbGeneralInfo.AppendLine("line: " + frame.GetFileLineNumber());
                        sbGeneralInfo.AppendLine("col: " + frame.GetFileColumnNumber());
                    }
                    catch (Exception exc)
                    {
                        if (!saveAsWarning)
                        {
                            sbGeneralInfo.AppendLine("Error attempting to add stack information in SaveErrorMessage()");
                            sbGeneralInfo.AppendLine(exc.ToString());
                        }
                    }

                    sbGeneralInfo.AppendLine(sb.ToString());

                    if (saveAsWarning)
                    {
                        LogHelper.Warn(type, sbGeneralInfo.ToString());
                    }
                    else
                    {
                        LogHelper.Error(type, sbGeneralInfo.ToString(), ex);
                    }
                }
            }
            catch (Exception error)
            {
                LogHelper.Error(typeof(Common), "Error Saving Exception Message.  Original Data: " + sbGeneralInfo.ToString() + " ||| " + ex.ToString(), error);
            }
        }
        #endregion
    }
}