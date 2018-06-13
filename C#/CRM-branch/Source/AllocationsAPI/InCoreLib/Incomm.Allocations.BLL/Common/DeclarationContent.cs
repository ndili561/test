using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class DeclarationContent
    {
        public static void AddContent(Document document, string name, ref object missing)
        {
            var para1Text =
                "Declaration";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Font.Bold = -1;
            para1.Range.Font.Name = "Ariel";
            para1.Range.Font.Size = 12;
            para1.Range.Font.Underline = WdUnderline.wdUnderlineSingle;
            para1.Range.Text = para1Text;
            para1.Range.Paragraphs.SpaceAfter = 0;
            para1.Range.InsertParagraphAfter();
           
            var para2Text =
               "I give my consent for Incommunities to share my information with third party organisations and for these organisations to share my information with them in order to provide me with housing, support and associated services and in order to monitor my progress. I understand that my consent will remain valid until such time as I give written notice to withdraw my consent.";
            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Font.Bold = 0;
            para2.Range.Font.Name = "Ariel";
            para2.Range.Font.Size = 12;
            para2.Range.Text = para2Text;
            para2.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            para2.Range.Paragraphs.SpaceAfter = 10;
            para2.Range.InsertParagraphAfter();

            var paraNameText ="Name   " + name;
            var paraName = document.Content.Paragraphs.Add(ref missing);
            paraName.Range.Font.Bold = 0;
            paraName.Range.Text = paraNameText;
            paraName.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            paraName.Range.Font.Name = "Ariel";
            paraName.Range.Font.Size = 12;
            paraName.Range.Paragraphs.SpaceAfter = 10;
            paraName.Range.InsertParagraphAfter();

            var paraDateText = "Date  _______________ ";
            var paraDate = document.Content.Paragraphs.Add(ref missing);
            paraDate.Range.Font.Bold = 0;
            paraDate.Range.Text = paraDateText;
            paraDate.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            paraDate.Range.Paragraphs.SpaceAfter = 10;
            paraDate.Range.Font.Name = "Ariel";
            paraDate.Range.Font.Size = 12;
            paraDate.Range.InsertParagraphAfter();

            var paraSignatureText = "Signature  __________________________________________________";
            var paraSignature = document.Content.Paragraphs.Add(ref missing);
            paraSignature.Range.Font.Bold = 0;
            paraSignature.Range.Text = paraSignatureText;
            paraSignature.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            paraSignature.Range.Paragraphs.SpaceAfter = 10;
            paraSignature.Range.Font.Name = "Ariel";
            paraSignature.Range.Font.Size = 12;
            paraSignature.Range.InsertParagraphAfter();
        }
       
    }
}
