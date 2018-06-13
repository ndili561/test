using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class ApplicationHeaderContent
    {
        public static void AddContent(Document document)
        {
            foreach (Section section in document.Sections)
            {
                //Get the header range and add the header details.
                var headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                dynamic logoFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images/Incommunities.jpg");
                if (!string.IsNullOrEmpty(logoFilePath))
                {
                    headerRange.InlineShapes.AddPicture(logoFilePath);
                }
            }
        }
       
    }
}
