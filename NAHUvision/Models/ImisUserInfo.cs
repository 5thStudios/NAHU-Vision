using System;


namespace NAHUvision.Models
{
    public partial class ImisUserInfo
    {
        public string WebLogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string WorkPhone { get; set; }
        public string EmailAddress { get; set; }
        public string MemberType { get; set; }
        public string Chapter { get; set; }
        public long? ImisId { get; set; }


        //public string Prefix { get; set; }
        //public string Suffix { get; set; }
        //public string CompanyName { get; set; }
        //public ImisUserInfoExtensionData ExtensionData { get; set; }

    }
    //public partial class ImisUserInfoExtensionData
    //{
    //    public ExtensionDataExtensionData ExtensionData { get; set; }
    //}
    //public partial class ExtensionDataExtensionData
    //{
    //    public Uri Xmlns { get; set; }
    //    public Address1 Address1 { get; set; }
    //    public Address Address2 { get; set; }
    //    public Address Address3 { get; set; }
    //    public Address1 City { get; set; }
    //    public Address1 StateProvince { get; set; }
    //    public Address1 Country { get; set; }
    //}
    //public partial class Address1
    //{
    //    public string Xmlns { get; set; }
    //    public string Text { get; set; }
    //}
    //public partial class Address
    //{
    //    public string Xmlns { get; set; }
    //}
}