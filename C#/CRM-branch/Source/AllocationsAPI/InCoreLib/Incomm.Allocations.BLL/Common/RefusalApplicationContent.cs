using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class RefusalApplicationContent
    {
        public static void AddContent(Document document,string address, string landlordName,string reason, string rejectedBy, ref object missing)
        {
            var para1Text =
                "I am writing with reference to your current VBL Housing application.You were previously matched to the below Property:";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Font.Bold = 0;
            para1.Range.Text = para1Text;
            para1.Range.Paragraphs.SpaceAfter = 10;
            para1.Range.InsertParagraphAfter();

            var para2Text = string.Format("Address: {0}, Landlord Name: {1}", address, landlordName);
            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Font.Bold = -1;
            para2.Range.Text = para2Text;
            para2.Range.Paragraphs.SpaceAfter = 10;
            para2.Range.InsertParagraphAfter();

            var para3Text ="";
            var para3 = document.Content.Paragraphs.Add(ref missing);
            para3.Range.Font.Bold = 0;
            para3.Range.Paragraphs.SpaceAfter = 10;
            para3.Range.Text = para3Text;
            para3.Range.InsertParagraphAfter();
          

            var para4Text =
              "Where nessesary your VBL application has been updated to prevent further incorrect matches, however should you disagree with this descion please contact {0} on 01274 XXXXXXX";
            var para4 = document.Content.Paragraphs.Add(ref missing);
            para4.Range.Font.Bold = 0;
            para4.Range.Text = para4Text;
            para4.Range.Paragraphs.SpaceAfter = 10;
            para4.Range.Paragraphs.SpaceAfter = 2;
            para4.Range.InsertParagraphAfter();
        }
       
    }
}
