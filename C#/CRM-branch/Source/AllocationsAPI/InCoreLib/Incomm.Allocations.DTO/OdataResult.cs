namespace Incomm.Allocations.BLL.DTOs
{
public class OdataResult
    {
        public object[] Items { get; set; }
        public object NextPageLink { get; set; }
        public object Count { get; set; }
    }

   

}

public static class StringExtension
{
    public static string StandarizedForOdata(this string value)
    {
        return value == null ? string.Empty : value.Replace("@odata.count", "Count").Replace("value", "Items");
    }
}