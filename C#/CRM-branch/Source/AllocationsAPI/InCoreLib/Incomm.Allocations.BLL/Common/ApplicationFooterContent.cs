using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
    public static class ApplicationFooterContent
    {
        public static void AddContent(Document document, ref object missing)
        {
            foreach (Section wordSection in document.Sections)
            {
                //Get the footer range and add the footer details.
                var footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = WdColorIndex.wdBlack;
                footerRange.Font.Size = 10;
                footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                var para1 = footerRange.Paragraphs.Add(ref missing);
                para1.Range.Underline = WdUnderline.wdUnderlineSingle;
                para1.Range.Font.Bold = 0;
                para1.Range.Text = "if you need a translator or this letter in another language or format please tel: 01274 254321"; ;
                para1.Range.Paragraphs.SpaceAfter = 1;
                para1.Range.InsertParagraphAfter();
                footerRange.Underline = WdUnderline.wdUnderlineNone;
                var footerTable = document.Tables.Add(footerRange, 7, 4, ref missing, ref missing);
                footerTable.Columns[1].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
                footerTable.Columns[1].PreferredWidth = 50f;
                footerTable.Columns[2].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
                footerTable.Columns[2].PreferredWidth = 150f;
                footerTable.Columns[3].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
                footerTable.Columns[3].PreferredWidth = 300f;
                foreach (Row row in footerTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Header row
                        if (cell.RowIndex == 1)
                        {
                            continue;
                        }
                        if (cell.RowIndex == 2)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Range.Text = "tel:";
                                cell.Range.Font.Bold = -1;
                            }
                            else if (cell.ColumnIndex == 2)
                            {
                                cell.Range.Text = "01274 XXXXXXX";
                                cell.Range.Font.Bold = 0;
                            }
                          
                        }
                        else if (cell.RowIndex == 3)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Range.Text = "fax:";
                                cell.Range.Font.Bold = -1;
                            }
                            else if (cell.ColumnIndex == 2)
                            {
                                cell.Range.Text = "01274 XXXXXXX";
                                cell.Range.Font.Bold = 0;
                            }
                            else if (cell.ColumnIndex == 3)
                            {
                                cell.Range.Text = "Neighbourhood Services";
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                cell.Range.Font.Bold = -1;
                            }
                          
                        }
                        else if (cell.RowIndex == 4)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Range.Text = "email:";
                                cell.Range.Font.Bold = -1;
                            }
                            else if (cell.ColumnIndex == 2)
                            {
                                cell.Range.Text = "email@incommunities.co.uk";
                                cell.Range.Font.Bold = 0;
                            }
                            else if (cell.ColumnIndex == 3)
                            {
                                cell.Range.Text = "The Quays, Victoria Street,";
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                cell.Range.Font.Bold = 0;
                            }
                            
                        }
                        else if (cell.RowIndex == 5)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.Range.Text = "website:";
                                cell.Range.Font.Bold = -1;
                            }
                            else if (cell.ColumnIndex == 2)
                            {
                                cell.Range.Text = "www.incommunities.co.uk";
                                cell.Range.Font.Bold = 0;
                            }
                            else if (cell.ColumnIndex == 3)
                            {
                                cell.Range.Text = "Shipley, West Yorkshire, BD17 7BN";
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                cell.Range.Font.Bold = 0;
                                cell.Range.Font.Size = 8;
                            }
                        }
                        else if (cell.RowIndex == 6)
                        {
                           if (cell.ColumnIndex == 3)
                            {
                                cell.Range.Text = "service of documents/notices by email is not accepted";
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                cell.Range.Font.Bold = 0;
                                cell.Range.Font.Size = 8;
                            }
                        }
                        else if (cell.RowIndex == 7)
                        {
                           if(cell.ColumnIndex == 3)
                            {
                                var text =
                                    "Registered addressIncommunities Limited is a registered society under the Co-operative and Community Benefit Society Act 2014.  Registered in England with the Financial Conduct Authority No. 30178R. Registered address:  The Quays, Victoria Street, Shipley, West Yorkshire, BD17 7BN";
                                cell.Range.Text = text;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                cell.Range.Font.Bold = 0;
                                cell.Range.Font.Size = 5.5f;
                            }
                        }
                    }
                }
            }
        }
       
    }
}
