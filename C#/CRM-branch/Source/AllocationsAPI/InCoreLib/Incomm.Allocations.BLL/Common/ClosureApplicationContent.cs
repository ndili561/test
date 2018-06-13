using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class ClosureApplicationContent
    {
        public static void AddContent(Document document, ref object missing)
        {
            var para1Text =
                "I am writing with reference to your current VBL Housing application. We have tried to contact you, via the contact details you have provided on your application, regarding properties you have been matched to in order to carry out a suitability check. ";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Font.Bold = 0;
            para1.Range.Text = para1Text;
            para1.Range.Paragraphs.SpaceAfter = 10;
            para1.Range.InsertParagraphAfter();
           
            var para2Text =
               "Unfortunately, as we have been unable to make contact with you, we have now closed your application on the assumption you no longer required re-housing. If this is an incorrect assumption and you do wish to be rehoused, please contact a member of the team on 01274 435999 or 01274 257777 to reopen your application and update the necessary contact details.";
            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Font.Bold = 0;
            para2.Range.Text = para2Text;
            para2.Range.Paragraphs.SpaceAfter = 10;
            para2.Range.InsertParagraphAfter();
           
        }
       
    }
}
