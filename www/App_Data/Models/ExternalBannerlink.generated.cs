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
	/// <summary>External Bannerlink</summary>
	[PublishedContentModel("externalBannerlink")]
	public partial class ExternalBannerlink : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "externalBannerlink";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ExternalBannerlink(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ExternalBannerlink, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// External Url
		///</summary>
		[ImplementPropertyType("externalUrl")]
		public string ExternalUrl
		{
			get { return this.GetPropertyValue<string>("externalUrl"); }
		}

		///<summary>
		/// Icon: Select a sprite icon for the banner's menu.
		///</summary>
		[ImplementPropertyType("icon")]
		public IPublishedContent Icon
		{
			get { return this.GetPropertyValue<IPublishedContent>("icon"); }
		}

		///<summary>
		/// Open In New Tab
		///</summary>
		[ImplementPropertyType("openInNewTab")]
		public bool OpenInNewTab
		{
			get { return this.GetPropertyValue<bool>("openInNewTab"); }
		}

		///<summary>
		/// Subtitle
		///</summary>
		[ImplementPropertyType("subtitle")]
		public string Subtitle
		{
			get { return this.GetPropertyValue<string>("subtitle"); }
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return this.GetPropertyValue<string>("title"); }
		}
	}
}
