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
	/// <summary>List - Trustee</summary>
	[PublishedContentModel("trusteeList")]
	public partial class TrusteeList : PublishedContentModel, INavigation, ISEO, ISimpleBanner
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "trusteeList";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public TrusteeList(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<TrusteeList, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Side Navigation: This selection is used in conjunction with "Template 2" or "Template 4", in addition this is only for level 3 and 4 pages.
		///</summary>
		[ImplementPropertyType("allowInSideNav")]
		public bool AllowInSideNav
		{
			get { return Umbraco.Web.PublishedContentModels.Navigation.GetAllowInSideNav(this); }
		}

		///<summary>
		/// Eyebrow Navigation
		///</summary>
		[ImplementPropertyType("showInEyebrowNavigation")]
		public bool ShowInEyebrowNavigation
		{
			get { return Umbraco.Web.PublishedContentModels.Navigation.GetShowInEyebrowNavigation(this); }
		}

		///<summary>
		/// Footer Navigation
		///</summary>
		[ImplementPropertyType("showInFooter")]
		public bool ShowInFooter
		{
			get { return Umbraco.Web.PublishedContentModels.Navigation.GetShowInFooter(this); }
		}

		///<summary>
		/// Mega Menu Navigation: This selection also determines what shows in the mobile navigation.
		///</summary>
		[ImplementPropertyType("showInMegamenu")]
		public bool ShowInMegamenu
		{
			get { return Umbraco.Web.PublishedContentModels.Navigation.GetShowInMegamenu(this); }
		}

		///<summary>
		/// Drop Down Navigation
		///</summary>
		[ImplementPropertyType("showInNavigation")]
		public bool ShowInNavigation
		{
			get { return Umbraco.Web.PublishedContentModels.Navigation.GetShowInNavigation(this); }
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
		/// Drop Shadow
		///</summary>
		[ImplementPropertyType("dropShadow")]
		public object DropShadow
		{
			get { return Umbraco.Web.PublishedContentModels.SimpleBanner.GetDropShadow(this); }
		}

		///<summary>
		/// Background Image: The "FullBanner" or "NarrowBanner" crop will be used for the selected image.  If left blank, the simple banner will not be displayed.
		///</summary>
		[ImplementPropertyType("sb_backgroundImage")]
		public IPublishedContent Sb_backgroundImage
		{
			get { return Umbraco.Web.PublishedContentModels.SimpleBanner.GetSb_backgroundImage(this); }
		}

		///<summary>
		/// Subtitle
		///</summary>
		[ImplementPropertyType("sb_subtitle")]
		public string Sb_subtitle
		{
			get { return Umbraco.Web.PublishedContentModels.SimpleBanner.GetSb_subtitle(this); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("sb_title")]
		public string Sb_title
		{
			get { return Umbraco.Web.PublishedContentModels.SimpleBanner.GetSb_title(this); }
		}

		///<summary>
		/// Use Native Dimensions: Selecting this option will remove all parameters from the background image and use it's native style.
		///</summary>
		[ImplementPropertyType("useNativeDimensions")]
		public bool UseNativeDimensions
		{
			get { return Umbraco.Web.PublishedContentModels.SimpleBanner.GetUseNativeDimensions(this); }
		}
	}
}
