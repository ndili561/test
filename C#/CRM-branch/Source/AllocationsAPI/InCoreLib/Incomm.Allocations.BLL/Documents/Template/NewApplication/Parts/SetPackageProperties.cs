using System.Xml;
using DocumentFormat.OpenXml.Packaging;

namespace Incomm.Allocations.BLL.Documents.Template
{
    public static class SetPackageProperties
    {
        public static void Insert(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Richard Barker";
            document.PackageProperties.Revision = "2";
            document.PackageProperties.Created = XmlConvert.ToDateTime("2016-07-26T15:00:00Z", XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = XmlConvert.ToDateTime("2016-07-26T15:00:00Z", XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Nabin Kumar";
            document.PackageProperties.LastPrinted = XmlConvert.ToDateTime("2013-11-20T13:40:00Z", XmlDateTimeSerializationMode.RoundtripKind);
        }
    }
}
