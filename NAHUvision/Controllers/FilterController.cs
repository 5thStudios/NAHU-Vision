using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Text;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using NAHUvision.Models;
using System.Text.RegularExpressions;

namespace NAHUvision.Controller
{
    public class FilterController : SurfaceController
    {
        #region "Renders"
        public ActionResult RenderFilter()
        {
            //Instantiate datatype service
            List<Models.Filter> LstFilters = new List<Models.Filter>();

            LstFilters.Add(ObtainFilterCollection(Common.DataType.AgencyMembership, Common.NodeProperties.AgencyMembership));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.ChapterLeadershipTraining, Common.NodeProperties.ChapterLeadershipTraining));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.ComplianceCorner, Common.NodeProperties.ComplianceCorner));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.LeadershipTools, Common.NodeProperties.LeadershipTools));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.Membership, Common.NodeProperties.Membership));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.NationalCommittees, Common.NodeProperties.NationalCommittees));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.ProfessionalDevelopment, Common.NodeProperties.ProfessionalDevelopment));
            LstFilters.Add(ObtainFilterCollection(Common.DataType.SocialMedia, Common.NodeProperties.SocialMedia));


            return PartialView("~/Views/Partials/Video/Filter.cshtml", LstFilters);
        }
        #endregion


        #region "Methods"
        private Models.Filter ObtainFilterCollection(string dataTypeName, string parentName)
        {
            // Instantiate datatype service
            Models.Filter filter = new Models.Filter();
            IDataTypeService dtService = ApplicationContext.Current.Services.DataTypeService;
            IDataTypeDefinition dtDefinition;
            PreValueCollection pvCollection;
            StringBuilder sbAbrList = new StringBuilder();

            // Obtain prevalue collection from datatypes
            dtDefinition = dtService.GetDataTypeDefinitionByName(dataTypeName);
            pvCollection = dtService.GetPreValuesCollectionByDataTypeId(dtDefinition.Id);

            //Create filter
            filter.Name = dataTypeName;
            filter.Id = dtDefinition.Id;
            foreach (KeyValuePair<string, PreValue> pv in pvCollection.PreValuesAsDictionary)
            {
                Link link = new Link();
                link.Id = pv.Value.Id;
                link.Name = pv.Value.Value;

                parentName = Regex.Replace(parentName, "[^a-zA-Z0-9]", "");
                link.Abr = Regex.Replace(pv.Value.Value.Replace(" ", ""), "[^a-zA-Z0-9]", "");
                link.Abr = parentName + "-" + link.Abr;

                filter.LstLinks.Add(link);
            }

            //Create full filter list to view all for filter
            foreach (Models.Link link in filter.LstLinks)
            {
                sbAbrList.Append("." + link.Abr + " ");
            }
            filter.AbrList = sbAbrList.ToString();

            return filter;
        }
        #endregion
    }
}