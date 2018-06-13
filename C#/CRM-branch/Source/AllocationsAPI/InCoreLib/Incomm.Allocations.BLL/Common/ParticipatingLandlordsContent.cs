using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class ParticipatingLandlordsContent
    {
        public static void AddContent(Document document, ref object missing)
        {
            var para1Text =
                "* Participating Landlords Include:";
            var para1 = document.Content.Paragraphs.Add(ref missing);
            para1.Range.Font.Bold = -1;
            para1.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            para1.Range.Text = para1Text;
            para1.Range.Font.Name = "Ariel";
            para1.Range.Font.Size = 12;
            para1.Range.Paragraphs.SpaceAfter = 0;
            para1.Range.InsertParagraphAfter();
           
            var para2Text =
               "Abbeyfield Bradford Society Ltd, Anchor Trust, Accent Group Ltd, Affinity Sutton, Equity Housing Association, Habinteg Housing Association, Hanover Housing, Headrow Housing Group, Home Group, Housing 21, Incommunities Group Ltd, Jephson Housing Association, Jonny Johnson Housing Association, Manningham Housing Association, Muir Housing Association, Places for People, Sanctuary Housing, The Riverside Group Ltd, Yorkshire Housing";
            var para2 = document.Content.Paragraphs.Add(ref missing);
            para2.Range.Font.Bold = 0;
            para2.Range.Text = para2Text;
            para2.Range.Font.Underline = WdUnderline.wdUnderlineNone;
            para2.Range.Paragraphs.SpaceAfter = 10;
            para2.Range.Font.Name = "Ariel";
            para2.Range.Font.Size = 12;
            para2.Range.InsertParagraphAfter();

        }
       
    }
}
