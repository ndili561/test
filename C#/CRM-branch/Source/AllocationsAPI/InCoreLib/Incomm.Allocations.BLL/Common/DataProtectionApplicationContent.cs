using System;
using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class DataProtectionApplicationContent
    {
        public static void AddContent(Document document, ref object missing)
        {
            string dataStatement =
                   "The Council and Incommunities will comply with the Data Protection Act 1998 and any subsequent legislation" +
                   " that may apply. The Council and Incommunities will store the information that you have provided in this application form and use this to provide" +
                   " you with housing, welfare advice, support and associated services. From time to time, we will also use this information for the purpose of improving" +
                   " our services and for producing housing demand and other performance information. " +
                   Environment.NewLine + Environment.NewLine +
                   "In order to provide you with these services, the Council and Incommunities will share your data with third party organisations including other local" +
                   " authorities, public sector organisations and providers of housing, support and associated services." +
                   Environment.NewLine + Environment.NewLine +
                   "We need your consent to share your information with organisations outside of the Council and Incommunities.  You are able to withdraw your consent at" +
                   " any time by providing written notice to the Data Protection Team/  Housing Options Team, Bradford Metropolitan District Council," +
                   " Britannia House, 4th Floor, Hall Ings, Bradford, BD1 1HX.";
            var para1Text =
                "Data Protection Statement";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Font.Bold = -1;
            para1.Range.Font.Underline = WdUnderline.wdUnderlineSingle;
            para1.Range.Text = para1Text;
            para1.Range.Font.Name = "Ariel";
            para1.Range.Font.Size = 12;
            para1.Range.Paragraphs.SpaceAfter = 0;
            para1.Range.InsertParagraphAfter();

            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Font.Bold = 0;
            para2.Range.Text = dataStatement;
            para2.Range.Font.Name = "Ariel";
            para2.Range.Font.Size = 12;
            para2.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            para2.Range.Paragraphs.SpaceAfter =10;
            para2.Range.InsertParagraphAfter();
        }
       
    }
}
