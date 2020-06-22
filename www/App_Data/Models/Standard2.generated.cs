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
	/// <summary>Standard</summary>
	[PublishedContentModel("standard2")]
	public partial class Standard2 : PublishedContentModel, INavigation
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "standard2";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Standard2(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Standard2, TValue>> selector)
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
	}
}
