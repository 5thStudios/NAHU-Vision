//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Home - Main Site</summary>
	[PublishedContentModel("home")]
	public partial class Home : PublishedContentModel, ICustomPanels, IMaintenance, IPersonalNotes, IQuoteBanner, IRotatingBanner, ISEO, ISocialFollowUs
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "home";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Home(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Home, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Article Count: Number of articles to include in list.  (This does not include the featured article.)
		///</summary>
		[ImplementPropertyType("articleCount")]
		public int ArticleCount
		{
			get { return this.GetPropertyValue<int>("articleCount"); }
		}

		///<summary>
		/// Article Lists: List every parent FOLDER that can be used to generate articles for the home page.
		///</summary>
		[ImplementPropertyType("articleLists")]
		public IEnumerable<IPublishedContent> ArticleLists
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("articleLists"); }
		}

		///<summary>
		/// Content: When present, will be displayed in a "Breaking News" panel.  Both content and link are required if the "Breaking News" panel is to be displayed.
		///</summary>
		[ImplementPropertyType("bn_Content")]
		public string Bn_Content
		{
			get { return this.GetPropertyValue<string>("bn_Content"); }
		}

		///<summary>
		/// Link: Both content and link are required if the "Breaking News" panel is to be displayed.
		///</summary>
		[ImplementPropertyType("bn_Link")]
		public IPublishedContent Bn_Link
		{
			get { return this.GetPropertyValue<IPublishedContent>("bn_Link"); }
		}

		///<summary>
		/// Featured Item: Note: The image of the selected article will use crop "NewsPanelFeatured".
		///</summary>
		[ImplementPropertyType("featuredItem")]
		public IPublishedContent FeaturedItem
		{
			get { return this.GetPropertyValue<IPublishedContent>("featuredItem"); }
		}

		///<summary>
		/// Join Now Link
		///</summary>
		[ImplementPropertyType("joinNowLink")]
		public IPublishedContent JoinNowLink
		{
			get { return this.GetPropertyValue<IPublishedContent>("joinNowLink"); }
		}

		///<summary>
		/// Member Benefits
		///</summary>
		[ImplementPropertyType("memberBenefits")]
		public object MemberBenefits
		{
			get { return this.GetPropertyValue("memberBenefits"); }
		}

		///<summary>
		/// Show Ad
		///</summary>
		[ImplementPropertyType("news_showAd")]
		public bool News_showAd
		{
			get { return this.GetPropertyValue<bool>("news_showAd"); }
		}

		///<summary>
		/// Renew Membership Link
		///</summary>
		[ImplementPropertyType("renewMembershipLink")]
		public IPublishedContent RenewMembershipLink
		{
			get { return this.GetPropertyValue<IPublishedContent>("renewMembershipLink"); }
		}

		///<summary>
		/// Site Logo: Primary logo to site.
		///</summary>
		[ImplementPropertyType("siteLogo")]
		public IPublishedContent SiteLogo
		{
			get { return this.GetPropertyValue<IPublishedContent>("siteLogo"); }
		}

		///<summary>
		/// Background Image
		///</summary>
		[ImplementPropertyType("cp_BackgroundImage1")]
		public IPublishedContent Cp_BackgroundImage1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_BackgroundImage1(this); }
		}

		///<summary>
		/// Background Image
		///</summary>
		[ImplementPropertyType("cp_BackgroundImage2")]
		public IPublishedContent Cp_BackgroundImage2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_BackgroundImage2(this); }
		}

		///<summary>
		/// Background Image
		///</summary>
		[ImplementPropertyType("cp_BackgroundImage3")]
		public IPublishedContent Cp_BackgroundImage3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_BackgroundImage3(this); }
		}

		///<summary>
		/// Description
		///</summary>
		[ImplementPropertyType("cp_Description1")]
		public string Cp_Description1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Description1(this); }
		}

		///<summary>
		/// Description
		///</summary>
		[ImplementPropertyType("cp_Description2")]
		public string Cp_Description2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Description2(this); }
		}

		///<summary>
		/// Description
		///</summary>
		[ImplementPropertyType("cp_Description3")]
		public string Cp_Description3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Description3(this); }
		}

		///<summary>
		/// Panel 1
		///</summary>
		[ImplementPropertyType("cp_Panel1")]
		public string Cp_Panel1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Panel1(this); }
		}

		///<summary>
		/// Panel 2
		///</summary>
		[ImplementPropertyType("cp_Panel2")]
		public string Cp_Panel2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Panel2(this); }
		}

		///<summary>
		/// Panel 3
		///</summary>
		[ImplementPropertyType("cp_Panel3")]
		public string Cp_Panel3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Panel3(this); }
		}

		///<summary>
		/// Quicklink
		///</summary>
		[ImplementPropertyType("cp_Quicklink1")]
		public IPublishedContent Cp_Quicklink1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Quicklink1(this); }
		}

		///<summary>
		/// Quicklink
		///</summary>
		[ImplementPropertyType("cp_Quicklink2")]
		public IPublishedContent Cp_Quicklink2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Quicklink2(this); }
		}

		///<summary>
		/// Quicklink
		///</summary>
		[ImplementPropertyType("cp_Quicklink3")]
		public IPublishedContent Cp_Quicklink3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Quicklink3(this); }
		}

		///<summary>
		/// Quicklink Title
		///</summary>
		[ImplementPropertyType("cp_QuicklinkTitle1")]
		public string Cp_QuicklinkTitle1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_QuicklinkTitle1(this); }
		}

		///<summary>
		/// Quicklink Title
		///</summary>
		[ImplementPropertyType("cp_QuicklinkTitle2")]
		public string Cp_QuicklinkTitle2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_QuicklinkTitle2(this); }
		}

		///<summary>
		/// Quicklink Title
		///</summary>
		[ImplementPropertyType("cp_QuicklinkTitle3")]
		public string Cp_QuicklinkTitle3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_QuicklinkTitle3(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("cp_Title1")]
		public string Cp_Title1
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Title1(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("cp_Title2")]
		public string Cp_Title2
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Title2(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("cp_Title3")]
		public string Cp_Title3
		{
			get { return Umbraco.Web.PublishedContentModels.CustomPanels.GetCp_Title3(this); }
		}

		///<summary>
		/// Disable Login: Used when the site is to remain on but the SSO is under maintenance.
		///</summary>
		[ImplementPropertyType("disableLogin")]
		public object DisableLogin
		{
			get { return Umbraco.Web.PublishedContentModels.Maintenance.GetDisableLogin(this); }
		}

		///<summary>
		/// Notes
		///</summary>
		[ImplementPropertyType("notes")]
		public IHtmlString Notes
		{
			get { return Umbraco.Web.PublishedContentModels.PersonalNotes.GetNotes(this); }
		}

		///<summary>
		/// Drop Shadow
		///</summary>
		[ImplementPropertyType("dropShadow")]
		public object DropShadow
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetDropShadow(this); }
		}

		///<summary>
		/// Background Image: *Required
		///</summary>
		[ImplementPropertyType("qb_backgroundImage")]
		public IPublishedContent Qb_backgroundImage
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_backgroundImage(this); }
		}

		///<summary>
		/// Call to Action Link: *Optional: CTA Text & Link are both required to show button.
		///</summary>
		[ImplementPropertyType("qb_callToActionLink")]
		public IPublishedContent Qb_callToActionLink
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_callToActionLink(this); }
		}

		///<summary>
		/// Call to Action Text: *Optional: CTA Text & Link are both required to show button.
		///</summary>
		[ImplementPropertyType("qb_callToActionText")]
		public string Qb_callToActionText
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_callToActionText(this); }
		}

		///<summary>
		/// Subtitle
		///</summary>
		[ImplementPropertyType("qb_subtitle")]
		public string Qb_subtitle
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_subtitle(this); }
		}

		///<summary>
		/// Text Alignment: Default is left aligned.
		///</summary>
		[ImplementPropertyType("qb_textAlignment")]
		public object Qb_textAlignment
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_textAlignment(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("qb_title")]
		public string Qb_title
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetQb_title(this); }
		}

		///<summary>
		/// Use Native Dimensions: Selecting this option will remove all parameters from the background image and use it's native style.
		///</summary>
		[ImplementPropertyType("useNativeDimensions")]
		public bool UseNativeDimensions
		{
			get { return Umbraco.Web.PublishedContentModels.QuoteBanner.GetUseNativeDimensions(this); }
		}

		///<summary>
		/// Rotating Banners: Select 4 banners to display in the rotator.
		///</summary>
		[ImplementPropertyType("rotatingBanners")]
		public IEnumerable<IPublishedContent> RotatingBanners
		{
			get { return Umbraco.Web.PublishedContentModels.RotatingBanner.GetRotatingBanners(this); }
		}

		///<summary>
		/// Meta Robots
		///</summary>
		[ImplementPropertyType("metaRobots")]
		public object MetaRobots
		{
			get { return Umbraco.Web.PublishedContentModels.SEO.GetMetaRobots(this); }
		}

		///<summary>
		/// Redirects
		///</summary>
		[ImplementPropertyType("redirects")]
		public object Redirects
		{
			get { return Umbraco.Web.PublishedContentModels.SEO.GetRedirects(this); }
		}

		///<summary>
		/// SEO Checker
		///</summary>
		[ImplementPropertyType("sEOChecker")]
		public SEOChecker.MVC.MetaData SEochecker
		{
			get { return Umbraco.Web.PublishedContentModels.SEO.GetSEochecker(this); }
		}

		///<summary>
		/// Hide page from XML Sitemap
		///</summary>
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide
		{
			get { return Umbraco.Web.PublishedContentModels.SEO.GetUmbracoNaviHide(this); }
		}

		///<summary>
		/// XMLSitemap
		///</summary>
		[ImplementPropertyType("xMLSitemap")]
		public object XMlsitemap
		{
			get { return Umbraco.Web.PublishedContentModels.SEO.GetXMlsitemap(this); }
		}

		///<summary>
		/// B2B: B2B follow us URL
		///</summary>
		[ImplementPropertyType("b2BFollowUSURL")]
		public string B2BfollowUsurl
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetB2BfollowUsurl(this); }
		}

		///<summary>
		/// Facebook: Facebook follow us URL
		///</summary>
		[ImplementPropertyType("facebookFollowUSURL")]
		public string FacebookFollowUsurl
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetFacebookFollowUsurl(this); }
		}

		///<summary>
		/// Follow US URLs
		///</summary>
		[ImplementPropertyType("followUSURLs")]
		public string FollowUsurls
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetFollowUsurls(this); }
		}

		///<summary>
		/// LinkedIn: LinkedIn follow us URL
		///</summary>
		[ImplementPropertyType("linkedInFollowUSURL")]
		public string LinkedInFollowUsurl
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetLinkedInFollowUsurl(this); }
		}

		///<summary>
		/// Twitter: Twitter follow us URL
		///</summary>
		[ImplementPropertyType("twitterFollowUSURL")]
		public string TwitterFollowUsurl
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetTwitterFollowUsurl(this); }
		}

		///<summary>
		/// YouTube: YouTube Follow us URL
		///</summary>
		[ImplementPropertyType("youTubeFollowUSURL")]
		public string YouTubeFollowUsurl
		{
			get { return Umbraco.Web.PublishedContentModels.SocialFollowUs.GetYouTubeFollowUsurl(this); }
		}
	}
}
