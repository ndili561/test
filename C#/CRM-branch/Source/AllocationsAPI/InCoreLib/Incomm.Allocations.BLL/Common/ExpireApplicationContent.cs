using System;
using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class ExpireApplicationContent
    {
        public static void AddContent(Document document,DateTime expiredDate, DateTime contactDate, ref object missing)
        {
            var para1Text =
                "I am writing with reference to your current VBL Housing application. Your application is due to or has expired on:";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Text = para1Text;
            para1.Range.Paragraphs.SpaceAfter = 10;
            para1.Range.InsertParagraphAfter();

            var para2Text = expiredDate.ToShortDateString();
            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Text = para2Text;
            para2.Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            para2.Range.InsertParagraphAfter();
            para2.Range.Paragraphs.SpaceAfter = 10;

            var para3Text =
               string.Format("Should you wish to reopen / extende the end date of your application please contact a member of the team on 01274 XXXXXX before {0} to make the required changes. If you do not make contact on phone on or before this date, your application will expire as agreed.", contactDate.ToShortDateString());
            var para3 = document.Content.Paragraphs.Add(ref missing);
            para3.Range.Text = para3Text;
            para3.Range.InsertParagraphAfter();
            para2.Range.Paragraphs.SpaceAfter = 10;

            var para4Text =
              "If you still required rehousing and make contact after DATE you will be asked to commence a new application.";
            var para4 = document.Content.Paragraphs.Add(ref missing);
            para4.Range.Text = para4Text;
            para4.Range.InsertParagraphAfter();
            para2.Range.Paragraphs.SpaceAfter = 10;
        }
       
    }
}
