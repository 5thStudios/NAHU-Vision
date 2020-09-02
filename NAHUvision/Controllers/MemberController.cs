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

using System.Linq;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Security;
using System.Web.Security;



namespace NAHUvision.Controller
{
    public class MemberController : SurfaceController
    {
        #region Properties
        private static MembershipHelper membershipHelper = new MembershipHelper(UmbracoContext.Current);
        #endregion



        #region "Methods"
        public static void SaveMemberData(ImisUserInfo imisUser)
        {
            try
            {
                //Instantiate variables
                IMemberService memberService = ApplicationContext.Current.Services.MemberService;
                IMember _member;
                Boolean memberExistsByLogin = false;
                Boolean memberExistsByEmail = false;
                Boolean memberNeesdUpdating = false;

                //--FOR TESTING ONLY--
                //TEMP MEMBER 
                //imisUser = new ImisUserInfo();
                //imisUser.WebLogin = "jfifth";
                //imisUser.FirstName = "James";
                //imisUser.LastName = "Fifth";
                //imisUser.FullName = "James Fifth";
                //imisUser.WorkPhone = "570-875-8351";
                //imisUser.EmailAddress = "jim.fifth@5thstudios.com";
                //imisUser.MemberType = "M";
                //imisUser.ImisId = 21;


                //Check if user name exists
                memberExistsByLogin = memberService.Exists(imisUser.WebLogin);
                memberExistsByEmail = memberService.Exists(imisUser.EmailAddress);


                //Determine if a user needs to be updated or created
                if (memberExistsByLogin)
                {
                    _member = memberService.GetByUsername(imisUser.WebLogin);
                    memberNeesdUpdating = DoesMemberNeedUpdating(ref _member, ref imisUser);
                    if (memberNeesdUpdating) UpdateMember(ref memberService, ref _member, ref imisUser);
                }
                else if (memberExistsByEmail)
                {
                    _member = memberService.GetByEmail(imisUser.EmailAddress);
                    memberNeesdUpdating = DoesMemberNeedUpdating(ref _member, ref imisUser);
                    if (memberNeesdUpdating) UpdateMember(ref memberService, ref _member, ref imisUser);
                }
                else
                {
                    //Create membership
                    _member = CreateNewMember(ref memberService, ref imisUser);
                }


                //--FOR TESTING ONLY--
                ////Save response in log
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine("GenericController | SaveMemberData()");
                //sb.AppendLine("** NON-ERROR **");
                //sb.AppendLine("Imis Data: ");
                //sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(imisUser));
                //sb.AppendLine("memberExistsByLogin: " + memberExistsByLogin.ToString());
                //sb.AppendLine("memberExistsByEmail: " + memberExistsByEmail.ToString());
                //sb.AppendLine("memberNeesdUpdating: " + memberNeesdUpdating.ToString());
                //sb.AppendLine("Member Data: ");
                //if (_member != null) sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(_member));

                //Exception tempExc = new Exception("non-error");
                //Common.SaveErrorMessage(tempExc, sb, typeof(GenericController), true);
            }
            catch (Exception ex)
            {
                //Save error to log
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("MemberController | SaveMemberData()");
                sb.AppendLine("** REAL ERROR **");
                sb.AppendLine("Imis Data:");
                sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(imisUser));
                Common.SaveErrorMessage(ex, sb, typeof(MemberController));
            }
        }
        private static IMember CreateNewMember(ref IMemberService memberService, ref ImisUserInfo imisUser)
        {
            //Create membership
            IMember _member = memberService.CreateMember(imisUser.WebLogin.Trim(), imisUser.EmailAddress.Trim().ToLower(), imisUser.FullName.Trim(), "Member");

            //Set member values
            _member.IsApproved = true;
            _member.SetValue(Common.NodeProperties.Email, imisUser.EmailAddress.Trim().ToLower());
            _member.SetValue(Common.NodeProperties.FirstName, imisUser.FirstName.Trim().ToFirstUpper());
            _member.SetValue(Common.NodeProperties.LastName, imisUser.LastName.Trim().ToFirstUpper());
            _member.SetValue(Common.NodeProperties.PhoneNumber, imisUser.WorkPhone.Trim());
            _member.SetValue(Common.NodeProperties.MemberType, imisUser.MemberType.Trim().ToUpper());
            _member.SetValue(Common.NodeProperties.Chapter, imisUser.Chapter.Trim().ToLower());
            _member.SetValue(Common.NodeProperties.ImisId, imisUser.ImisId);

            //Update member
            memberService.Save(_member);

            memberService.SavePassword(_member, "NAHUvision2020");

            //Return newly created member
            return _member;
        }
        private static void UpdateMember(ref IMemberService memberService, ref IMember _member, ref ImisUserInfo imisUser)
        {
            //Set member values
            if (!string.IsNullOrWhiteSpace(imisUser.EmailAddress)) _member.SetValue(Common.NodeProperties.Email, imisUser.EmailAddress.Trim().ToLower());
            if (!string.IsNullOrWhiteSpace(imisUser.FirstName)) _member.SetValue(Common.NodeProperties.FirstName, imisUser.FirstName.Trim().ToFirstUpper());
            if (imisUser.ImisId != null) _member.SetValue(Common.NodeProperties.ImisId, imisUser.ImisId);
            if (!string.IsNullOrWhiteSpace(imisUser.LastName)) _member.SetValue(Common.NodeProperties.LastName, imisUser.LastName.Trim().ToFirstUpper());
            if (!string.IsNullOrWhiteSpace(imisUser.MemberType)) _member.SetValue(Common.NodeProperties.MemberType, imisUser.MemberType.Trim().ToUpper());
            if (!string.IsNullOrWhiteSpace(imisUser.WorkPhone)) _member.SetValue(Common.NodeProperties.PhoneNumber, imisUser.WorkPhone.Trim());
            if (!string.IsNullOrWhiteSpace(imisUser.Chapter)) _member.SetValue(Common.NodeProperties.Chapter, imisUser.Chapter.Trim().ToLower());
            if (!string.IsNullOrWhiteSpace(imisUser.FullName)) _member.Name = imisUser.FullName;

            // Save data to member.
            memberService.Save(_member);
        }
        private static Boolean DoesMemberNeedUpdating(ref IMember _member, ref ImisUserInfo imisUser)
        {
            //If any values do not match return that an update is needed.
            if (imisUser.Chapter != _member.GetValue<string>(Common.NodeProperties.Chapter)) return true;
            if (imisUser.EmailAddress != _member.GetValue<string>(Common.NodeProperties.Email)) return true;
            if (imisUser.FirstName != _member.GetValue<string>(Common.NodeProperties.FirstName)) return true;
            if (imisUser.FullName != _member.Name) return true;
            if (imisUser.ImisId != _member.GetValue<int>(Common.NodeProperties.ImisId)) return true;
            if (imisUser.LastName != _member.GetValue<string>(Common.NodeProperties.LastName)) return true;
            if (imisUser.MemberType != _member.GetValue<string>(Common.NodeProperties.MemberType)) return true;
            if (imisUser.WorkPhone != _member.GetValue<string>(Common.NodeProperties.PhoneNumber)) return true;

            return false;
        }
        public static int GetMemberId_byImisId(string imisId)
        {
            //Find member by imisId and return member id
            IMemberService memberService = ApplicationContext.Current.Services.MemberService;
            IMember member = memberService.GetMembersByPropertyValue(Common.NodeProperties.ImisId, imisId).FirstOrDefault();

            if (member == null)
            {
                return -1;
            }
            else
            {
                return member.Id;
            }
        }
        public static string GetVideoGuid_byId(string videoId)
        {
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            GuidUdi udi = new GuidUdi("document", umbHelper.TypedContent(videoId).GetKey());

            return udi.ToString();
        }
        public static string UpdateMember_AddVideoById(int memberId, int videoId)
        {
            //Obtain member and videio guid
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            IMemberService memberService = ApplicationContext.Current.Services.MemberService;
            IMember member = memberService.GetById(memberId);
            GuidUdi udi = new GuidUdi("document", umbHelper.TypedContent(videoId).GetKey());
            string strListOfCompletedVideos = "";

            if (member != null)
            {
                if (udi != null)
                {
                    //Obtain all existing videos within member
                    string allCompletedVideos = member.GetValue<string>(Common.NodeProperties.CompletedVideos);

                    //Instantiate list
                    List<string> lstCompletedVideos = new List<string>();

                    //Populate list with any existing data
                    if (!string.IsNullOrWhiteSpace(allCompletedVideos))
                    {
                        lstCompletedVideos = allCompletedVideos.Split(',').ToList<string>();
                    }

                    //Add video udi to list if missing
                    if (!lstCompletedVideos.Contains(udi.ToString()))
                    {
                        lstCompletedVideos.Add(udi.ToString());
                    }

                    //Add data to member and save
                    member.SetValue(Common.NodeProperties.CompletedVideos, string.Join(",", lstCompletedVideos));
                    memberService.Save(member);

                    //Convert list to a csv string
                    strListOfCompletedVideos = string.Join(",", lstCompletedVideos);
                }
            }

            return strListOfCompletedVideos;
        }


        public static List<int> ObtainListOfCompletedVideos_byMember(IMember member)
        {
            //Instantiate variables
            List<int> lstVideoIDs = new List<int>();

            //Add member to list if the member has completed videos
            if (member.HasProperty(Common.NodeProperties.CompletedVideos))
            {
                if (!string.IsNullOrWhiteSpace(member.GetValue<string>(Common.NodeProperties.CompletedVideos)))
                {
                    //Instantiate variables
                    UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
                    List<string> lstCompletedVideos;
                    string allCompletedVideos;

                    //Obtain all existing videos within member
                    allCompletedVideos = member.GetValue<string>(Common.NodeProperties.CompletedVideos);
                    lstCompletedVideos = allCompletedVideos.Split(',').ToList<string>();

                    //Loop though each completed video in list
                    foreach (string guid in lstCompletedVideos)
                    {
                        IPublishedContent ipVideo = umbHelper.TypedContent(guid);
                        //VideoLink videoLink = new VideoLink();
                        //videoLink.Link = "/umbraco#/content/content/edit/" + ipVideo.Id;
                        //videoLink.Title = ipVideo.GetPropertyValue<string>(Common.NodeProperties.Title);
                        //lstVideoLinks.Add(videoLink);
                        lstVideoIDs.Add(ipVideo.Id);
                    }
                }
            }


            //Return member.
            return lstVideoIDs;
        }
        public static List<ImisMember> ObtainListOfCompletedVideos()
        {
            //Instantiate variables
            UmbracoHelper umbHelper = new UmbracoHelper(UmbracoContext.Current);
            IMemberService memberService = ApplicationContext.Current.Services.MemberService;
            IEnumerable<IMember> members;
            List<ImisMember> lstImisMembers = new List<ImisMember>();

            //Loop through each member
            members = memberService.GetAll(0, int.MaxValue, out int totalRecords);
            foreach (IMember member in members)
            {
                //Add member to list if the member has completed videos
                if (!string.IsNullOrWhiteSpace(member.GetValue<string>(Common.NodeProperties.CompletedVideos)))
                {
                    //Instantiate variables
                    List<VideoLink> lstVideoLinks = new List<VideoLink>();
                    List<string> lstCompletedVideos;
                    string allCompletedVideos;

                    //Obtain all existing videos within member
                    allCompletedVideos = member.GetValue<string>(Common.NodeProperties.CompletedVideos);
                    lstCompletedVideos = allCompletedVideos.Split(',').ToList<string>();

                    //Loop though each completed video in list
                    foreach (string guid in lstCompletedVideos)
                    {
                        IPublishedContent ipVideo = umbHelper.TypedContent(guid);
                        VideoLink videoLink = new VideoLink();
                        videoLink.Link = "/umbraco#/content/content/edit/" + ipVideo.Id;
                        videoLink.Title = ipVideo.GetPropertyValue<string>(Common.NodeProperties.Title);
                        lstVideoLinks.Add(videoLink);
                    }

                    //Add member data to class
                    ImisMember imisMember = new ImisMember();
                    imisMember.ImisId = member.GetValue<string>(Common.NodeProperties.ImisId);
                    imisMember.Chapter = member.GetValue<string>(Common.NodeProperties.Chapter);
                    imisMember.Email = member.GetValue<string>(Common.NodeProperties.Email);
                    imisMember.Member = member.Name;
                    imisMember.MemberType = member.GetValue<string>(Common.NodeProperties.MemberType);
                    imisMember.MemberEditUrl = "/umbraco/#/member/member/edit/" + member.Key.ToString();
                    imisMember.LstVideoLinks = lstVideoLinks.OrderBy(x => x.Title).ToList();
                    lstImisMembers.Add(imisMember);
                }
            }

            //Return members in alphabetical order.
            return lstImisMembers.OrderBy(x => x.Member).ToList();
        }
        #endregion
    }
}