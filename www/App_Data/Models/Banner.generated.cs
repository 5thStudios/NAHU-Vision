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
	/// <summary>Banner</summary>
	[PublishedContentModel("banner")]
	public partial class Banner : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "banner";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Banner(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Banner, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Background Image: *Required
		///</summary>
		[ImplementPropertyType("bl_backgroundImage")]
		public string Bl_backgroundImage
		{
			get { return this.GetPropertyValue<string>("bl_backgroundImage"); }
		}

		///<summary>
		/// Call to Action Link: *Optional: CTA Text & Link are both required to show button.
		///</summary>
		[ImplementPropertyType("bl_callToActionLink")]
		public IPublishedContent Bl_callToActionLink
		{
			get { return this.GetPropertyValue<IPublishedContent>("bl_callToActionLink"); }
		}

		///<summary>
		/// Call to Action Text: *Optional: CTA Text & Link are both required to show button.
		///</summary>
		[ImplementPropertyType("bl_callToActionText")]
		public string Bl_callToActionText
		{
			get { return this.GetPropertyValue<string>("bl_callToActionText"); }
		}

		///<summary>
		/// Icon: Select a sprite icon for the banner's menu.
		///</summary>
		[ImplementPropertyType("bl_icon")]
		public IPublishedContent Bl_icon
		{
			get { return this.GetPropertyValue<IPublishedContent>("bl_icon"); }
		}

		///<summary>
		/// Quicklink Subtitle
		///</summary>
		[ImplementPropertyType("bl_quicklinkSubtitle")]
		public string Bl_quicklinkSubtitle
		{
			get { return this.GetPropertyValue<string>("bl_quicklinkSubtitle"); }
		}

		///<summary>
		/// Quicklink Title
		///</summary>
		[ImplementPropertyType("bl_quicklinkTitle")]
		public string Bl_quicklinkTitle
		{
			get { return this.GetPropertyValue<string>("bl_quicklinkTitle"); }
		}

		///<summary>
		/// Subtitle: *Optional
		///</summary>
		[ImplementPropertyType("bl_subtitle")]
		public string Bl_subtitle
		{
			get { return this.GetPropertyValue<string>("bl_subtitle"); }
		}

		///<summary>
		/// Text Alignment: Default is left aligned.
		///</summary>
		[ImplementPropertyType("bl_textAlignment")]
		public object Bl_textAlignment
		{
			get { return this.GetPropertyValue("bl_textAlignment"); }
		}

		///<summary>
		/// Title: *Required
		///</summary>
		[ImplementPropertyType("bl_title")]
		public string Bl_title
		{
			get { return this.GetPropertyValue<string>("bl_title"); }
		}

		///<summary>
		/// Drop Shadow
		///</summary>
		[ImplementPropertyType("dropShadow")]
		public object DropShadow
		{
			get { return this.GetPropertyValue("dropShadow"); }
		}

		///<summary>
		/// Side Nav Settings: Minimum required information.
		///</summary>
		[ImplementPropertyType("lblMinimalInfo")]
		public string LblMinimalInfo
		{
			get { return this.GetPropertyValue<string>("lblMinimalInfo"); }
		}

		///<summary>
		/// Use Native Dimensions: Selecting this option will remove all parameters from the background image and use it's native style.
		///</summary>
		[ImplementPropertyType("useNativeDimensions")]
		public bool UseNativeDimensions
		{
			get { return this.GetPropertyValue<bool>("useNativeDimensions"); }
		}
	}
}
