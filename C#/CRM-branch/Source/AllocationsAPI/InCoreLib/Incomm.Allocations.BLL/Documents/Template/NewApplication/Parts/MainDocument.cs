using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Service.Api.DTOs;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using Ds = DocumentFormat.OpenXml.CustomXmlDataProperties;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using M = DocumentFormat.OpenXml.Math;

namespace Incomm.Allocations.BLL.Documents.Template.NewApplication.Parts
{
   public static class MainDocument
    {
        public static void GenerateMainDocumentPart1Content(DocumentFormat.OpenXml.Packaging.MainDocumentPart mainDocumentPart1)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize1 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(fontSize1);

            paragraphProperties1.Append(paragraphStyleId1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize2 = new FontSize() { Val = "24" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(fontSize2);
            Text text1 = new Text();
            text1.Text = "Application Details";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(bookmarkStart1);
            paragraph1.Append(bookmarkEnd1);
            paragraph1.Append(run1);

            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "10682", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout1 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);
            TableLook tableLook1 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableLayout1);
            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "1780" };
            GridColumn gridColumn2 = new GridColumn() { Width = "1780" };
            GridColumn gridColumn3 = new GridColumn() { Width = "1780" };
            GridColumn gridColumn4 = new GridColumn() { Width = "1780" };
            GridColumn gridColumn5 = new GridColumn() { Width = "1781" };
            GridColumn gridColumn6 = new GridColumn() { Width = "1781" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);
            tableGrid1.Append(gridColumn3);
            tableGrid1.Append(gridColumn4);
            tableGrid1.Append(gridColumn5);
            tableGrid1.Append(gridColumn6);

            TableRow tableRow1 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions1 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault2 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault2.Append(topMargin1);
            tableCellMarginDefault2.Append(bottomMargin1);

            tablePropertyExceptions1.Append(tableCellMarginDefault2);

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders1.Append(topBorder1);
            tableCellBorders1.Append(leftBorder1);
            tableCellBorders1.Append(bottomBorder1);
            tableCellBorders1.Append(rightBorder1);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin1 = new TableCellMargin();
            TopMargin topMargin2 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin1 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin2 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin1 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin1.Append(topMargin2);
            tableCellMargin1.Append(leftMargin1);
            tableCellMargin1.Append(bottomMargin2);
            tableCellMargin1.Append(rightMargin1);

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(tableCellBorders1);
            tableCellProperties1.Append(shading1);
            tableCellProperties1.Append(tableCellMargin1);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold1 = new Bold();
            FontSize fontSize3 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties2.Append(runFonts3);
            paragraphMarkRunProperties2.Append(bold1);
            paragraphMarkRunProperties2.Append(fontSize3);

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification1);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run2 = new Run();

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold2 = new Bold();
            FontSize fontSize4 = new FontSize() { Val = "24" };

            runProperties2.Append(runFonts4);
            runProperties2.Append(bold2);
            runProperties2.Append(fontSize4);
            Text text2 = new Text();
            text2.Text = "Application Status";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph2);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders2.Append(topBorder2);
            tableCellBorders2.Append(leftBorder2);
            tableCellBorders2.Append(bottomBorder2);
            tableCellBorders2.Append(rightBorder2);
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin2 = new TableCellMargin();
            TopMargin topMargin3 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin2 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin3 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin2 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin2.Append(topMargin3);
            tableCellMargin2.Append(leftMargin2);
            tableCellMargin2.Append(bottomMargin3);
            tableCellMargin2.Append(rightMargin2);

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(tableCellBorders2);
            tableCellProperties2.Append(shading2);
            tableCellProperties2.Append(tableCellMargin2);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId3 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification2 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold3 = new Bold();
            FontSize fontSize5 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties3.Append(runFonts5);
            paragraphMarkRunProperties3.Append(bold3);
            paragraphMarkRunProperties3.Append(fontSize5);

            paragraphProperties3.Append(paragraphStyleId3);
            paragraphProperties3.Append(justification2);
            paragraphProperties3.Append(paragraphMarkRunProperties3);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold4 = new Bold();
            FontSize fontSize6 = new FontSize() { Val = "24" };

            runProperties3.Append(runFonts6);
            runProperties3.Append(bold4);
            runProperties3.Append(fontSize6);
            Text text3 = new Text();
            text3.Text = "Application Date";

            run3.Append(runProperties3);
            run3.Append(text3);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run3);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph3);

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders3.Append(topBorder3);
            tableCellBorders3.Append(leftBorder3);
            tableCellBorders3.Append(bottomBorder3);
            tableCellBorders3.Append(rightBorder3);
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin3 = new TableCellMargin();
            TopMargin topMargin4 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin3 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin4 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin3 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin3.Append(topMargin4);
            tableCellMargin3.Append(leftMargin3);
            tableCellMargin3.Append(bottomMargin4);
            tableCellMargin3.Append(rightMargin3);

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(tableCellBorders3);
            tableCellProperties3.Append(shading3);
            tableCellProperties3.Append(tableCellMargin3);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId4 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification3 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold5 = new Bold();
            FontSize fontSize7 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties4.Append(runFonts7);
            paragraphMarkRunProperties4.Append(bold5);
            paragraphMarkRunProperties4.Append(fontSize7);

            paragraphProperties4.Append(paragraphStyleId4);
            paragraphProperties4.Append(justification3);
            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run4 = new Run();

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold6 = new Bold();
            FontSize fontSize8 = new FontSize() { Val = "24" };

            runProperties4.Append(runFonts8);
            runProperties4.Append(bold6);
            runProperties4.Append(fontSize8);
            Text text4 = new Text();
            text4.Text = "Banding";

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run4);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph4);

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders4.Append(topBorder4);
            tableCellBorders4.Append(leftBorder4);
            tableCellBorders4.Append(bottomBorder4);
            tableCellBorders4.Append(rightBorder4);
            Shading shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin4 = new TableCellMargin();
            TopMargin topMargin5 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin4 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin5 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin4 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin4.Append(topMargin5);
            tableCellMargin4.Append(leftMargin4);
            tableCellMargin4.Append(bottomMargin5);
            tableCellMargin4.Append(rightMargin4);

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(tableCellBorders4);
            tableCellProperties4.Append(shading4);
            tableCellProperties4.Append(tableCellMargin4);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId5 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification4 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold7 = new Bold();
            FontSize fontSize9 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties5.Append(runFonts9);
            paragraphMarkRunProperties5.Append(bold7);
            paragraphMarkRunProperties5.Append(fontSize9);

            paragraphProperties5.Append(paragraphStyleId5);
            paragraphProperties5.Append(justification4);
            paragraphProperties5.Append(paragraphMarkRunProperties5);

            Run run5 = new Run();

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold8 = new Bold();
            FontSize fontSize10 = new FontSize() { Val = "24" };

            runProperties5.Append(runFonts10);
            runProperties5.Append(bold8);
            runProperties5.Append(fontSize10);
            Text text5 = new Text();
            text5.Text = "Eligibility";

            run5.Append(runProperties5);
            run5.Append(text5);

            paragraph5.Append(paragraphProperties5);
            paragraph5.Append(run5);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph5);

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders5 = new TableCellBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders5.Append(topBorder5);
            tableCellBorders5.Append(leftBorder5);
            tableCellBorders5.Append(bottomBorder5);
            tableCellBorders5.Append(rightBorder5);
            Shading shading5 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin5 = new TableCellMargin();
            TopMargin topMargin6 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin5 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin6 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin5 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin5.Append(topMargin6);
            tableCellMargin5.Append(leftMargin5);
            tableCellMargin5.Append(bottomMargin6);
            tableCellMargin5.Append(rightMargin5);

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(tableCellBorders5);
            tableCellProperties5.Append(shading5);
            tableCellProperties5.Append(tableCellMargin5);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId6 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification5 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold9 = new Bold();
            FontSize fontSize11 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties6.Append(runFonts11);
            paragraphMarkRunProperties6.Append(bold9);
            paragraphMarkRunProperties6.Append(fontSize11);

            paragraphProperties6.Append(paragraphStyleId6);
            paragraphProperties6.Append(justification5);
            paragraphProperties6.Append(paragraphMarkRunProperties6);

            Run run6 = new Run();

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold10 = new Bold();
            FontSize fontSize12 = new FontSize() { Val = "24" };

            runProperties6.Append(runFonts12);
            runProperties6.Append(bold10);
            runProperties6.Append(fontSize12);
            Text text6 = new Text();
            text6.Text = "HOA Case";

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph6.Append(paragraphProperties6);
            paragraph6.Append(run6);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph6);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders6 = new TableCellBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder6 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder6 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders6.Append(topBorder6);
            tableCellBorders6.Append(leftBorder6);
            tableCellBorders6.Append(bottomBorder6);
            tableCellBorders6.Append(rightBorder6);
            Shading shading6 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin6 = new TableCellMargin();
            TopMargin topMargin7 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin6 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin7 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin6 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin6.Append(topMargin7);
            tableCellMargin6.Append(leftMargin6);
            tableCellMargin6.Append(bottomMargin7);
            tableCellMargin6.Append(rightMargin6);

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(tableCellBorders6);
            tableCellProperties6.Append(shading6);
            tableCellProperties6.Append(tableCellMargin6);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId7 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification6 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold11 = new Bold();
            FontSize fontSize13 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties7.Append(runFonts13);
            paragraphMarkRunProperties7.Append(bold11);
            paragraphMarkRunProperties7.Append(fontSize13);

            paragraphProperties7.Append(paragraphStyleId7);
            paragraphProperties7.Append(justification6);
            paragraphProperties7.Append(paragraphMarkRunProperties7);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold12 = new Bold();
            FontSize fontSize14 = new FontSize() { Val = "24" };

            runProperties7.Append(runFonts14);
            runProperties7.Append(bold12);
            runProperties7.Append(fontSize14);
            Text text7 = new Text();
            text7.Text = "Appointment";

            run7.Append(runProperties7);
            run7.Append(text7);

            paragraph7.Append(paragraphProperties7);
            paragraph7.Append(run7);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph7);

            tableRow1.Append(tablePropertyExceptions1);
            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);
            tableRow1.Append(tableCell3);
            tableRow1.Append(tableCell4);
            tableRow1.Append(tableCell5);
            tableRow1.Append(tableCell6);

            TableRow tableRow2 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions2 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault3 = new TableCellMarginDefault();
            TopMargin topMargin8 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin8 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault3.Append(topMargin8);
            tableCellMarginDefault3.Append(bottomMargin8);

            tablePropertyExceptions2.Append(tableCellMarginDefault3);

            TableCell tableCell7 = new TableCell();

            TableCellProperties tableCellProperties7 = new TableCellProperties();
            TableCellWidth tableCellWidth7 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders7 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder7 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder7 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders7.Append(topBorder7);
            tableCellBorders7.Append(leftBorder7);
            tableCellBorders7.Append(bottomBorder7);
            tableCellBorders7.Append(rightBorder7);
            Shading shading7 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin7 = new TableCellMargin();
            TopMargin topMargin9 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin7 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin9 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin7 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin7.Append(topMargin9);
            tableCellMargin7.Append(leftMargin7);
            tableCellMargin7.Append(bottomMargin9);
            tableCellMargin7.Append(rightMargin7);

            tableCellProperties7.Append(tableCellWidth7);
            tableCellProperties7.Append(tableCellBorders7);
            tableCellProperties7.Append(shading7);
            tableCellProperties7.Append(tableCellMargin7);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId8 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification7 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            RunFonts runFonts15 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize15 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties8.Append(runFonts15);
            paragraphMarkRunProperties8.Append(fontSize15);

            paragraphProperties8.Append(paragraphStyleId8);
            paragraphProperties8.Append(justification7);
            paragraphProperties8.Append(paragraphMarkRunProperties8);
            BookmarkStart bookmarkStart2 = new BookmarkStart() { Name = "OLE_LINK1", Id = "1" };
            BookmarkStart bookmarkStart3 = new BookmarkStart() { Name = "OLE_LINK2", Id = "2" };

            Run run8 = new Run();

            RunProperties runProperties8 = new RunProperties();
            RunFonts runFonts16 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize16 = new FontSize() { Val = "24" };

            runProperties8.Append(runFonts16);
            runProperties8.Append(fontSize16);
            Text text8 = new Text();
            text8.Text = "Application open";

            run8.Append(runProperties8);
            run8.Append(text8);
            BookmarkEnd bookmarkEnd2 = new BookmarkEnd() { Id = "1" };
            BookmarkEnd bookmarkEnd3 = new BookmarkEnd() { Id = "2" };

            paragraph8.Append(paragraphProperties8);
            paragraph8.Append(bookmarkStart2);
            paragraph8.Append(bookmarkStart3);
            paragraph8.Append(run8);
            paragraph8.Append(bookmarkEnd2);
            paragraph8.Append(bookmarkEnd3);

            tableCell7.Append(tableCellProperties7);
            tableCell7.Append(paragraph8);

            TableCell tableCell8 = new TableCell();

            TableCellProperties tableCellProperties8 = new TableCellProperties();
            TableCellWidth tableCellWidth8 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders8 = new TableCellBorders();
            TopBorder topBorder8 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder8 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder8 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder8 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders8.Append(topBorder8);
            tableCellBorders8.Append(leftBorder8);
            tableCellBorders8.Append(bottomBorder8);
            tableCellBorders8.Append(rightBorder8);
            Shading shading8 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin8 = new TableCellMargin();
            TopMargin topMargin10 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin8 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin10 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin8 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin8.Append(topMargin10);
            tableCellMargin8.Append(leftMargin8);
            tableCellMargin8.Append(bottomMargin10);
            tableCellMargin8.Append(rightMargin8);

            tableCellProperties8.Append(tableCellWidth8);
            tableCellProperties8.Append(tableCellBorders8);
            tableCellProperties8.Append(shading8);
            tableCellProperties8.Append(tableCellMargin8);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties9 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId9 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification8 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
            RunFonts runFonts17 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize17 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties9.Append(runFonts17);
            paragraphMarkRunProperties9.Append(fontSize17);

            paragraphProperties9.Append(paragraphStyleId9);
            paragraphProperties9.Append(justification8);
            paragraphProperties9.Append(paragraphMarkRunProperties9);

            Run run9 = new Run();

            RunProperties runProperties9 = new RunProperties();
            RunFonts runFonts18 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize18 = new FontSize() { Val = "24" };

            runProperties9.Append(runFonts18);
            runProperties9.Append(fontSize18);
            Text text9 = new Text();
            text9.Text = "24/02/2015 08:05:51";

            run9.Append(runProperties9);
            run9.Append(text9);

            paragraph9.Append(paragraphProperties9);
            paragraph9.Append(run9);

            tableCell8.Append(tableCellProperties8);
            tableCell8.Append(paragraph9);

            TableCell tableCell9 = new TableCell();

            TableCellProperties tableCellProperties9 = new TableCellProperties();
            TableCellWidth tableCellWidth9 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders9 = new TableCellBorders();
            TopBorder topBorder9 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder9 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder9 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder9 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders9.Append(topBorder9);
            tableCellBorders9.Append(leftBorder9);
            tableCellBorders9.Append(bottomBorder9);
            tableCellBorders9.Append(rightBorder9);
            Shading shading9 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin9 = new TableCellMargin();
            TopMargin topMargin11 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin9 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin11 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin9 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin9.Append(topMargin11);
            tableCellMargin9.Append(leftMargin9);
            tableCellMargin9.Append(bottomMargin11);
            tableCellMargin9.Append(rightMargin9);

            tableCellProperties9.Append(tableCellWidth9);
            tableCellProperties9.Append(tableCellBorders9);
            tableCellProperties9.Append(shading9);
            tableCellProperties9.Append(tableCellMargin9);

            Paragraph paragraph10 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties10 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId10 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification9 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
            RunFonts runFonts19 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize19 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties10.Append(runFonts19);
            paragraphMarkRunProperties10.Append(fontSize19);

            paragraphProperties10.Append(paragraphStyleId10);
            paragraphProperties10.Append(justification9);
            paragraphProperties10.Append(paragraphMarkRunProperties10);

            Run run10 = new Run();

            RunProperties runProperties10 = new RunProperties();
            RunFonts runFonts20 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize20 = new FontSize() { Val = "24" };

            runProperties10.Append(runFonts20);
            runProperties10.Append(fontSize20);
            Text text10 = new Text();
            text10.Text = "General Need";

            run10.Append(runProperties10);
            run10.Append(text10);

            paragraph10.Append(paragraphProperties10);
            paragraph10.Append(run10);

            tableCell9.Append(tableCellProperties9);
            tableCell9.Append(paragraph10);

            TableCell tableCell10 = new TableCell();

            TableCellProperties tableCellProperties10 = new TableCellProperties();
            TableCellWidth tableCellWidth10 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders10 = new TableCellBorders();
            TopBorder topBorder10 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder10 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder10 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder10 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders10.Append(topBorder10);
            tableCellBorders10.Append(leftBorder10);
            tableCellBorders10.Append(bottomBorder10);
            tableCellBorders10.Append(rightBorder10);
            Shading shading10 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin10 = new TableCellMargin();
            TopMargin topMargin12 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin10 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin12 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin10 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin10.Append(topMargin12);
            tableCellMargin10.Append(leftMargin10);
            tableCellMargin10.Append(bottomMargin12);
            tableCellMargin10.Append(rightMargin10);

            tableCellProperties10.Append(tableCellWidth10);
            tableCellProperties10.Append(tableCellBorders10);
            tableCellProperties10.Append(shading10);
            tableCellProperties10.Append(tableCellMargin10);

            Paragraph paragraph11 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties11 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId11 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification10 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
            RunFonts runFonts21 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize21 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties11.Append(runFonts21);
            paragraphMarkRunProperties11.Append(fontSize21);

            paragraphProperties11.Append(paragraphStyleId11);
            paragraphProperties11.Append(justification10);
            paragraphProperties11.Append(paragraphMarkRunProperties11);

            Run run11 = new Run();

            RunProperties runProperties11 = new RunProperties();
            RunFonts runFonts22 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize22 = new FontSize() { Val = "24" };

            runProperties11.Append(runFonts22);
            runProperties11.Append(fontSize22);
            Text text11 = new Text();
            text11.Text = "Applicant(s) Eligible";

            run11.Append(runProperties11);
            run11.Append(text11);

            paragraph11.Append(paragraphProperties11);
            paragraph11.Append(run11);

            tableCell10.Append(tableCellProperties10);
            tableCell10.Append(paragraph11);

            TableCell tableCell11 = new TableCell();

            TableCellProperties tableCellProperties11 = new TableCellProperties();
            TableCellWidth tableCellWidth11 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders11 = new TableCellBorders();
            TopBorder topBorder11 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder11 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder11 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder11 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders11.Append(topBorder11);
            tableCellBorders11.Append(leftBorder11);
            tableCellBorders11.Append(bottomBorder11);
            tableCellBorders11.Append(rightBorder11);
            Shading shading11 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin11 = new TableCellMargin();
            TopMargin topMargin13 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin11 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin13 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin11 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin11.Append(topMargin13);
            tableCellMargin11.Append(leftMargin11);
            tableCellMargin11.Append(bottomMargin13);
            tableCellMargin11.Append(rightMargin11);

            tableCellProperties11.Append(tableCellWidth11);
            tableCellProperties11.Append(tableCellBorders11);
            tableCellProperties11.Append(shading11);
            tableCellProperties11.Append(tableCellMargin11);

            Paragraph paragraph12 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties12 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId12 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification11 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
            RunFonts runFonts23 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize23 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties12.Append(runFonts23);
            paragraphMarkRunProperties12.Append(fontSize23);

            paragraphProperties12.Append(paragraphStyleId12);
            paragraphProperties12.Append(justification11);
            paragraphProperties12.Append(paragraphMarkRunProperties12);

            Run run12 = new Run();

            RunProperties runProperties12 = new RunProperties();
            RunFonts runFonts24 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize24 = new FontSize() { Val = "24" };

            runProperties12.Append(runFonts24);
            runProperties12.Append(fontSize24);
            Text text12 = new Text();
            text12.Text = "No HOA Case";

            run12.Append(runProperties12);
            run12.Append(text12);

            paragraph12.Append(paragraphProperties12);
            paragraph12.Append(run12);

            tableCell11.Append(tableCellProperties11);
            tableCell11.Append(paragraph12);

            TableCell tableCell12 = new TableCell();

            TableCellProperties tableCellProperties12 = new TableCellProperties();
            TableCellWidth tableCellWidth12 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders12 = new TableCellBorders();
            TopBorder topBorder12 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder12 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder12 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder12 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders12.Append(topBorder12);
            tableCellBorders12.Append(leftBorder12);
            tableCellBorders12.Append(bottomBorder12);
            tableCellBorders12.Append(rightBorder12);
            Shading shading12 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin12 = new TableCellMargin();
            TopMargin topMargin14 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin12 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin14 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin12 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin12.Append(topMargin14);
            tableCellMargin12.Append(leftMargin12);
            tableCellMargin12.Append(bottomMargin14);
            tableCellMargin12.Append(rightMargin12);

            tableCellProperties12.Append(tableCellWidth12);
            tableCellProperties12.Append(tableCellBorders12);
            tableCellProperties12.Append(shading12);
            tableCellProperties12.Append(tableCellMargin12);

            Paragraph paragraph13 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties13 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId13 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification12 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
            RunFonts runFonts25 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize25 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties13.Append(runFonts25);
            paragraphMarkRunProperties13.Append(fontSize25);

            paragraphProperties13.Append(paragraphStyleId13);
            paragraphProperties13.Append(justification12);
            paragraphProperties13.Append(paragraphMarkRunProperties13);

            paragraph13.Append(paragraphProperties13);

            tableCell12.Append(tableCellProperties12);
            tableCell12.Append(paragraph13);

            tableRow2.Append(tablePropertyExceptions2);
            tableRow2.Append(tableCell7);
            tableRow2.Append(tableCell8);
            tableRow2.Append(tableCell9);
            tableRow2.Append(tableCell10);
            tableRow2.Append(tableCell11);
            tableRow2.Append(tableCell12);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);

            Paragraph paragraph14 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties14 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId14 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
            RunFonts runFonts26 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize26 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties14.Append(runFonts26);
            paragraphMarkRunProperties14.Append(fontSize26);

            paragraphProperties14.Append(paragraphStyleId14);
            paragraphProperties14.Append(paragraphMarkRunProperties14);

            paragraph14.Append(paragraphProperties14);

            Paragraph paragraph15 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties15 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId15 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
            RunFonts runFonts27 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize27 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties15.Append(runFonts27);
            paragraphMarkRunProperties15.Append(fontSize27);

            paragraphProperties15.Append(paragraphStyleId15);
            paragraphProperties15.Append(paragraphMarkRunProperties15);

            Run run13 = new Run();

            RunProperties runProperties13 = new RunProperties();
            RunFonts runFonts28 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize28 = new FontSize() { Val = "24" };

            runProperties13.Append(runFonts28);
            runProperties13.Append(fontSize28);
            Text text13 = new Text();
            text13.Text = "Summary Of Household Details";

            run13.Append(runProperties13);
            run13.Append(text13);

            paragraph15.Append(paragraphProperties15);
            paragraph15.Append(run13);

            Table table2 = new Table();

            TableProperties tableProperties2 = new TableProperties();
            TableWidth tableWidth2 = new TableWidth() { Width = "10760", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout2 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault4 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin2 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault4.Append(tableCellLeftMargin2);
            tableCellMarginDefault4.Append(tableCellRightMargin2);
            TableLook tableLook2 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties2.Append(tableWidth2);
            tableProperties2.Append(tableLayout2);
            tableProperties2.Append(tableCellMarginDefault4);
            tableProperties2.Append(tableLook2);

            TableGrid tableGrid2 = new TableGrid();
            GridColumn gridColumn7 = new GridColumn() { Width = "1526" };
            GridColumn gridColumn8 = new GridColumn() { Width = "1276" };
            GridColumn gridColumn9 = new GridColumn() { Width = "1038" };
            GridColumn gridColumn10 = new GridColumn() { Width = "1371" };
            GridColumn gridColumn11 = new GridColumn() { Width = "1418" };
            GridColumn gridColumn12 = new GridColumn() { Width = "1134" };
            GridColumn gridColumn13 = new GridColumn() { Width = "1559" };
            GridColumn gridColumn14 = new GridColumn() { Width = "709" };
            GridColumn gridColumn15 = new GridColumn() { Width = "729" };

            tableGrid2.Append(gridColumn7);
            tableGrid2.Append(gridColumn8);
            tableGrid2.Append(gridColumn9);
            tableGrid2.Append(gridColumn10);
            tableGrid2.Append(gridColumn11);
            tableGrid2.Append(gridColumn12);
            tableGrid2.Append(gridColumn13);
            tableGrid2.Append(gridColumn14);
            tableGrid2.Append(gridColumn15);

            TableRow tableRow3 = new TableRow() { RsidTableRowAddition = "00B67984", RsidTableRowProperties = "0002564B" };

            TablePropertyExceptions tablePropertyExceptions3 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault5 = new TableCellMarginDefault();
            TopMargin topMargin15 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin15 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault5.Append(topMargin15);
            tableCellMarginDefault5.Append(bottomMargin15);

            tablePropertyExceptions3.Append(tableCellMarginDefault5);

            TableCell tableCell13 = new TableCell();

            TableCellProperties tableCellProperties13 = new TableCellProperties();
            TableCellWidth tableCellWidth13 = new TableCellWidth() { Width = "1526", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders13 = new TableCellBorders();
            TopBorder topBorder13 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder13 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder13 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder13 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders13.Append(topBorder13);
            tableCellBorders13.Append(leftBorder13);
            tableCellBorders13.Append(bottomBorder13);
            tableCellBorders13.Append(rightBorder13);
            Shading shading13 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin13 = new TableCellMargin();
            TopMargin topMargin16 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin13 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin16 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin13 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin13.Append(topMargin16);
            tableCellMargin13.Append(leftMargin13);
            tableCellMargin13.Append(bottomMargin16);
            tableCellMargin13.Append(rightMargin13);

            tableCellProperties13.Append(tableCellWidth13);
            tableCellProperties13.Append(tableCellBorders13);
            tableCellProperties13.Append(shading13);
            tableCellProperties13.Append(tableCellMargin13);

            Paragraph paragraph16 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties16 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId16 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification13 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
            RunFonts runFonts29 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold13 = new Bold();
            FontSize fontSize29 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties16.Append(runFonts29);
            paragraphMarkRunProperties16.Append(bold13);
            paragraphMarkRunProperties16.Append(fontSize29);

            paragraphProperties16.Append(paragraphStyleId16);
            paragraphProperties16.Append(justification13);
            paragraphProperties16.Append(paragraphMarkRunProperties16);

            paragraph16.Append(paragraphProperties16);

            Paragraph paragraph17 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties17 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId17 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification14 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
            RunFonts runFonts30 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold14 = new Bold();
            FontSize fontSize30 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties17.Append(runFonts30);
            paragraphMarkRunProperties17.Append(bold14);
            paragraphMarkRunProperties17.Append(fontSize30);

            paragraphProperties17.Append(paragraphStyleId17);
            paragraphProperties17.Append(justification14);
            paragraphProperties17.Append(paragraphMarkRunProperties17);

            Run run14 = new Run();

            RunProperties runProperties14 = new RunProperties();
            RunFonts runFonts31 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold15 = new Bold();
            FontSize fontSize31 = new FontSize() { Val = "24" };

            runProperties14.Append(runFonts31);
            runProperties14.Append(bold15);
            runProperties14.Append(fontSize31);
            Text text14 = new Text();
            text14.Text = "Name";

            run14.Append(runProperties14);
            run14.Append(text14);

            paragraph17.Append(paragraphProperties17);
            paragraph17.Append(run14);

            tableCell13.Append(tableCellProperties13);
            tableCell13.Append(paragraph16);
            tableCell13.Append(paragraph17);

            TableCell tableCell14 = new TableCell();

            TableCellProperties tableCellProperties14 = new TableCellProperties();
            TableCellWidth tableCellWidth14 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders14 = new TableCellBorders();
            TopBorder topBorder14 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder14 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder14 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder14 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders14.Append(topBorder14);
            tableCellBorders14.Append(leftBorder14);
            tableCellBorders14.Append(bottomBorder14);
            tableCellBorders14.Append(rightBorder14);
            Shading shading14 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin14 = new TableCellMargin();
            TopMargin topMargin17 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin14 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin17 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin14 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin14.Append(topMargin17);
            tableCellMargin14.Append(leftMargin14);
            tableCellMargin14.Append(bottomMargin17);
            tableCellMargin14.Append(rightMargin14);

            tableCellProperties14.Append(tableCellWidth14);
            tableCellProperties14.Append(tableCellBorders14);
            tableCellProperties14.Append(shading14);
            tableCellProperties14.Append(tableCellMargin14);

            Paragraph paragraph18 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties18 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId18 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification15 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
            RunFonts runFonts32 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold16 = new Bold();
            FontSize fontSize32 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties18.Append(runFonts32);
            paragraphMarkRunProperties18.Append(bold16);
            paragraphMarkRunProperties18.Append(fontSize32);

            paragraphProperties18.Append(paragraphStyleId18);
            paragraphProperties18.Append(justification15);
            paragraphProperties18.Append(paragraphMarkRunProperties18);

            Run run15 = new Run();

            RunProperties runProperties15 = new RunProperties();
            RunFonts runFonts33 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold17 = new Bold();
            FontSize fontSize33 = new FontSize() { Val = "24" };

            runProperties15.Append(runFonts33);
            runProperties15.Append(bold17);
            runProperties15.Append(fontSize33);
            Text text15 = new Text();
            text15.Text = "Type";

            run15.Append(runProperties15);
            run15.Append(text15);

            paragraph18.Append(paragraphProperties18);
            paragraph18.Append(run15);

            tableCell14.Append(tableCellProperties14);
            tableCell14.Append(paragraph18);

            TableCell tableCell15 = new TableCell();

            TableCellProperties tableCellProperties15 = new TableCellProperties();
            TableCellWidth tableCellWidth15 = new TableCellWidth() { Width = "1038", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders15 = new TableCellBorders();
            TopBorder topBorder15 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder15 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder15 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder15 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders15.Append(topBorder15);
            tableCellBorders15.Append(leftBorder15);
            tableCellBorders15.Append(bottomBorder15);
            tableCellBorders15.Append(rightBorder15);
            Shading shading15 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin15 = new TableCellMargin();
            TopMargin topMargin18 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin15 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin18 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin15 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin15.Append(topMargin18);
            tableCellMargin15.Append(leftMargin15);
            tableCellMargin15.Append(bottomMargin18);
            tableCellMargin15.Append(rightMargin15);

            tableCellProperties15.Append(tableCellWidth15);
            tableCellProperties15.Append(tableCellBorders15);
            tableCellProperties15.Append(shading15);
            tableCellProperties15.Append(tableCellMargin15);

            Paragraph paragraph19 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties19 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId19 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification16 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
            RunFonts runFonts34 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold18 = new Bold();
            FontSize fontSize34 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties19.Append(runFonts34);
            paragraphMarkRunProperties19.Append(bold18);
            paragraphMarkRunProperties19.Append(fontSize34);

            paragraphProperties19.Append(paragraphStyleId19);
            paragraphProperties19.Append(justification16);
            paragraphProperties19.Append(paragraphMarkRunProperties19);

            Run run16 = new Run();

            RunProperties runProperties16 = new RunProperties();
            RunFonts runFonts35 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold19 = new Bold();
            FontSize fontSize35 = new FontSize() { Val = "24" };

            runProperties16.Append(runFonts35);
            runProperties16.Append(bold19);
            runProperties16.Append(fontSize35);
            Text text16 = new Text();
            text16.Text = "Gender";

            run16.Append(runProperties16);
            run16.Append(text16);

            paragraph19.Append(paragraphProperties19);
            paragraph19.Append(run16);

            tableCell15.Append(tableCellProperties15);
            tableCell15.Append(paragraph19);

            TableCell tableCell16 = new TableCell();

            TableCellProperties tableCellProperties16 = new TableCellProperties();
            TableCellWidth tableCellWidth16 = new TableCellWidth() { Width = "1371", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders16 = new TableCellBorders();
            TopBorder topBorder16 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder16 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder16 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder16 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders16.Append(topBorder16);
            tableCellBorders16.Append(leftBorder16);
            tableCellBorders16.Append(bottomBorder16);
            tableCellBorders16.Append(rightBorder16);
            Shading shading16 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin16 = new TableCellMargin();
            TopMargin topMargin19 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin16 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin19 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin16 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin16.Append(topMargin19);
            tableCellMargin16.Append(leftMargin16);
            tableCellMargin16.Append(bottomMargin19);
            tableCellMargin16.Append(rightMargin16);

            tableCellProperties16.Append(tableCellWidth16);
            tableCellProperties16.Append(tableCellBorders16);
            tableCellProperties16.Append(shading16);
            tableCellProperties16.Append(tableCellMargin16);

            Paragraph paragraph20 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties20 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId20 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification17 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
            RunFonts runFonts36 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold20 = new Bold();
            FontSize fontSize36 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties20.Append(runFonts36);
            paragraphMarkRunProperties20.Append(bold20);
            paragraphMarkRunProperties20.Append(fontSize36);

            paragraphProperties20.Append(paragraphStyleId20);
            paragraphProperties20.Append(justification17);
            paragraphProperties20.Append(paragraphMarkRunProperties20);

            Run run17 = new Run();

            RunProperties runProperties17 = new RunProperties();
            RunFonts runFonts37 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold21 = new Bold();
            FontSize fontSize37 = new FontSize() { Val = "24" };

            runProperties17.Append(runFonts37);
            runProperties17.Append(bold21);
            runProperties17.Append(fontSize37);
            Text text17 = new Text();
            text17.Text = "DOB";

            run17.Append(runProperties17);
            run17.Append(text17);

            paragraph20.Append(paragraphProperties20);
            paragraph20.Append(run17);

            tableCell16.Append(tableCellProperties16);
            tableCell16.Append(paragraph20);

            TableCell tableCell17 = new TableCell();

            TableCellProperties tableCellProperties17 = new TableCellProperties();
            TableCellWidth tableCellWidth17 = new TableCellWidth() { Width = "1418", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders17 = new TableCellBorders();
            TopBorder topBorder17 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder17 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder17 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder17 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders17.Append(topBorder17);
            tableCellBorders17.Append(leftBorder17);
            tableCellBorders17.Append(bottomBorder17);
            tableCellBorders17.Append(rightBorder17);
            Shading shading17 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin17 = new TableCellMargin();
            TopMargin topMargin20 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin17 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin20 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin17 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin17.Append(topMargin20);
            tableCellMargin17.Append(leftMargin17);
            tableCellMargin17.Append(bottomMargin20);
            tableCellMargin17.Append(rightMargin17);

            tableCellProperties17.Append(tableCellWidth17);
            tableCellProperties17.Append(tableCellBorders17);
            tableCellProperties17.Append(shading17);
            tableCellProperties17.Append(tableCellMargin17);

            Paragraph paragraph21 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties21 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId21 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification18 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
            RunFonts runFonts38 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold22 = new Bold();
            FontSize fontSize38 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties21.Append(runFonts38);
            paragraphMarkRunProperties21.Append(bold22);
            paragraphMarkRunProperties21.Append(fontSize38);

            paragraphProperties21.Append(paragraphStyleId21);
            paragraphProperties21.Append(justification18);
            paragraphProperties21.Append(paragraphMarkRunProperties21);

            Run run18 = new Run();

            RunProperties runProperties18 = new RunProperties();
            RunFonts runFonts39 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold23 = new Bold();
            FontSize fontSize39 = new FontSize() { Val = "24" };

            runProperties18.Append(runFonts39);
            runProperties18.Append(bold23);
            runProperties18.Append(fontSize39);
            Text text18 = new Text();
            text18.Text = "Nationality";

            run18.Append(runProperties18);
            run18.Append(text18);

            paragraph21.Append(paragraphProperties21);
            paragraph21.Append(run18);

            tableCell17.Append(tableCellProperties17);
            tableCell17.Append(paragraph21);

            TableCell tableCell18 = new TableCell();

            TableCellProperties tableCellProperties18 = new TableCellProperties();
            TableCellWidth tableCellWidth18 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders18 = new TableCellBorders();
            TopBorder topBorder18 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder18 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder18 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder18 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders18.Append(topBorder18);
            tableCellBorders18.Append(leftBorder18);
            tableCellBorders18.Append(bottomBorder18);
            tableCellBorders18.Append(rightBorder18);
            Shading shading18 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin18 = new TableCellMargin();
            TopMargin topMargin21 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin18 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin21 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin18 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin18.Append(topMargin21);
            tableCellMargin18.Append(leftMargin18);
            tableCellMargin18.Append(bottomMargin21);
            tableCellMargin18.Append(rightMargin18);

            tableCellProperties18.Append(tableCellWidth18);
            tableCellProperties18.Append(tableCellBorders18);
            tableCellProperties18.Append(shading18);
            tableCellProperties18.Append(tableCellMargin18);

            Paragraph paragraph22 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties22 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId22 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification19 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
            RunFonts runFonts40 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold24 = new Bold();
            FontSize fontSize40 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties22.Append(runFonts40);
            paragraphMarkRunProperties22.Append(bold24);
            paragraphMarkRunProperties22.Append(fontSize40);

            paragraphProperties22.Append(paragraphStyleId22);
            paragraphProperties22.Append(justification19);
            paragraphProperties22.Append(paragraphMarkRunProperties22);

            Run run19 = new Run();

            RunProperties runProperties19 = new RunProperties();
            RunFonts runFonts41 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold25 = new Bold();
            FontSize fontSize41 = new FontSize() { Val = "24" };

            runProperties19.Append(runFonts41);
            runProperties19.Append(bold25);
            runProperties19.Append(fontSize41);
            Text text19 = new Text();
            text19.Text = "Eligible";

            run19.Append(runProperties19);
            run19.Append(text19);

            paragraph22.Append(paragraphProperties22);
            paragraph22.Append(run19);

            tableCell18.Append(tableCellProperties18);
            tableCell18.Append(paragraph22);

            TableCell tableCell19 = new TableCell();

            TableCellProperties tableCellProperties19 = new TableCellProperties();
            TableCellWidth tableCellWidth19 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders19 = new TableCellBorders();
            TopBorder topBorder19 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder19 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder19 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder19 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders19.Append(topBorder19);
            tableCellBorders19.Append(leftBorder19);
            tableCellBorders19.Append(bottomBorder19);
            tableCellBorders19.Append(rightBorder19);
            Shading shading19 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin19 = new TableCellMargin();
            TopMargin topMargin22 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin19 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin22 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin19 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin19.Append(topMargin22);
            tableCellMargin19.Append(leftMargin19);
            tableCellMargin19.Append(bottomMargin22);
            tableCellMargin19.Append(rightMargin19);

            tableCellProperties19.Append(tableCellWidth19);
            tableCellProperties19.Append(tableCellBorders19);
            tableCellProperties19.Append(shading19);
            tableCellProperties19.Append(tableCellMargin19);

            Paragraph paragraph23 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties23 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId23 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification20 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
            RunFonts runFonts42 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold26 = new Bold();
            FontSize fontSize42 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties23.Append(runFonts42);
            paragraphMarkRunProperties23.Append(bold26);
            paragraphMarkRunProperties23.Append(fontSize42);

            paragraphProperties23.Append(paragraphStyleId23);
            paragraphProperties23.Append(justification20);
            paragraphProperties23.Append(paragraphMarkRunProperties23);

            Run run20 = new Run();

            RunProperties runProperties20 = new RunProperties();
            RunFonts runFonts43 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold27 = new Bold();
            FontSize fontSize43 = new FontSize() { Val = "24" };

            runProperties20.Append(runFonts43);
            runProperties20.Append(bold27);
            runProperties20.Append(fontSize43);
            Text text20 = new Text();
            text20.Text = "Relationship To Applicant";

            run20.Append(runProperties20);
            run20.Append(text20);

            paragraph23.Append(paragraphProperties23);
            paragraph23.Append(run20);

            tableCell19.Append(tableCellProperties19);
            tableCell19.Append(paragraph23);

            TableCell tableCell20 = new TableCell();

            TableCellProperties tableCellProperties20 = new TableCellProperties();
            TableCellWidth tableCellWidth20 = new TableCellWidth() { Width = "709", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders20 = new TableCellBorders();
            TopBorder topBorder20 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder20 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder20 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder20 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders20.Append(topBorder20);
            tableCellBorders20.Append(leftBorder20);
            tableCellBorders20.Append(bottomBorder20);
            tableCellBorders20.Append(rightBorder20);
            Shading shading20 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin20 = new TableCellMargin();
            TopMargin topMargin23 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin20 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin23 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin20 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin20.Append(topMargin23);
            tableCellMargin20.Append(leftMargin20);
            tableCellMargin20.Append(bottomMargin23);
            tableCellMargin20.Append(rightMargin20);

            tableCellProperties20.Append(tableCellWidth20);
            tableCellProperties20.Append(tableCellBorders20);
            tableCellProperties20.Append(shading20);
            tableCellProperties20.Append(tableCellMargin20);

            Paragraph paragraph24 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties24 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId24 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification21 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
            RunFonts runFonts44 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold28 = new Bold();
            FontSize fontSize44 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties24.Append(runFonts44);
            paragraphMarkRunProperties24.Append(bold28);
            paragraphMarkRunProperties24.Append(fontSize44);

            paragraphProperties24.Append(paragraphStyleId24);
            paragraphProperties24.Append(justification21);
            paragraphProperties24.Append(paragraphMarkRunProperties24);

            Run run21 = new Run();

            RunProperties runProperties21 = new RunProperties();
            RunFonts runFonts45 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold29 = new Bold();
            FontSize fontSize45 = new FontSize() { Val = "24" };

            runProperties21.Append(runFonts45);
            runProperties21.Append(bold29);
            runProperties21.Append(fontSize45);
            Text text21 = new Text();
            text21.Text = "Disabled";

            run21.Append(runProperties21);
            run21.Append(text21);

            paragraph24.Append(paragraphProperties24);
            paragraph24.Append(run21);

            tableCell20.Append(tableCellProperties20);
            tableCell20.Append(paragraph24);

            TableCell tableCell21 = new TableCell();

            TableCellProperties tableCellProperties21 = new TableCellProperties();
            TableCellWidth tableCellWidth21 = new TableCellWidth() { Width = "729", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders21 = new TableCellBorders();
            TopBorder topBorder21 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder21 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder21 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder21 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders21.Append(topBorder21);
            tableCellBorders21.Append(leftBorder21);
            tableCellBorders21.Append(bottomBorder21);
            tableCellBorders21.Append(rightBorder21);
            Shading shading21 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin21 = new TableCellMargin();
            TopMargin topMargin24 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin21 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin24 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin21 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin21.Append(topMargin24);
            tableCellMargin21.Append(leftMargin21);
            tableCellMargin21.Append(bottomMargin24);
            tableCellMargin21.Append(rightMargin21);

            tableCellProperties21.Append(tableCellWidth21);
            tableCellProperties21.Append(tableCellBorders21);
            tableCellProperties21.Append(shading21);
            tableCellProperties21.Append(tableCellMargin21);

            Paragraph paragraph25 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties25 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId25 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification22 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
            RunFonts runFonts46 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold30 = new Bold();
            FontSize fontSize46 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties25.Append(runFonts46);
            paragraphMarkRunProperties25.Append(bold30);
            paragraphMarkRunProperties25.Append(fontSize46);

            paragraphProperties25.Append(paragraphStyleId25);
            paragraphProperties25.Append(justification22);
            paragraphProperties25.Append(paragraphMarkRunProperties25);

            Run run22 = new Run();

            RunProperties runProperties22 = new RunProperties();
            RunFonts runFonts47 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold31 = new Bold();
            FontSize fontSize47 = new FontSize() { Val = "24" };

            runProperties22.Append(runFonts47);
            runProperties22.Append(bold31);
            runProperties22.Append(fontSize47);
            Text text22 = new Text();
            text22.Text = "Pregnant";

            run22.Append(runProperties22);
            run22.Append(text22);

            paragraph25.Append(paragraphProperties25);
            paragraph25.Append(run22);

            tableCell21.Append(tableCellProperties21);
            tableCell21.Append(paragraph25);

            tableRow3.Append(tablePropertyExceptions3);
            tableRow3.Append(tableCell13);
            tableRow3.Append(tableCell14);
            tableRow3.Append(tableCell15);
            tableRow3.Append(tableCell16);
            tableRow3.Append(tableCell17);
            tableRow3.Append(tableCell18);
            tableRow3.Append(tableCell19);
            tableRow3.Append(tableCell20);
            tableRow3.Append(tableCell21);

            TableRow tableRow4 = new TableRow() { RsidTableRowAddition = "00B67984", RsidTableRowProperties = "0002564B" };

            TablePropertyExceptions tablePropertyExceptions4 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault6 = new TableCellMarginDefault();
            TopMargin topMargin25 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin25 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault6.Append(topMargin25);
            tableCellMarginDefault6.Append(bottomMargin25);

            tablePropertyExceptions4.Append(tableCellMarginDefault6);

            TableCell tableCell22 = new TableCell();

            TableCellProperties tableCellProperties22 = new TableCellProperties();
            TableCellWidth tableCellWidth22 = new TableCellWidth() { Width = "1526", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders22 = new TableCellBorders();
            TopBorder topBorder22 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder22 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder22 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder22 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders22.Append(topBorder22);
            tableCellBorders22.Append(leftBorder22);
            tableCellBorders22.Append(bottomBorder22);
            tableCellBorders22.Append(rightBorder22);
            Shading shading22 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin22 = new TableCellMargin();
            TopMargin topMargin26 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin22 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin26 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin22 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin22.Append(topMargin26);
            tableCellMargin22.Append(leftMargin22);
            tableCellMargin22.Append(bottomMargin26);
            tableCellMargin22.Append(rightMargin22);

            tableCellProperties22.Append(tableCellWidth22);
            tableCellProperties22.Append(tableCellBorders22);
            tableCellProperties22.Append(shading22);
            tableCellProperties22.Append(tableCellMargin22);

            Paragraph paragraph26 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties26 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId26 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
            RunFonts runFonts48 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize48 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties26.Append(runFonts48);
            paragraphMarkRunProperties26.Append(fontSize48);

            paragraphProperties26.Append(paragraphStyleId26);
            paragraphProperties26.Append(paragraphMarkRunProperties26);

            Run run23 = new Run();

            RunProperties runProperties23 = new RunProperties();
            RunFonts runFonts49 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize49 = new FontSize() { Val = "24" };

            runProperties23.Append(runFonts49);
            runProperties23.Append(fontSize49);
            Text text23 = new Text();
            text23.Text = "Aaron Smith";

            run23.Append(runProperties23);
            run23.Append(text23);

            paragraph26.Append(paragraphProperties26);
            paragraph26.Append(run23);

            tableCell22.Append(tableCellProperties22);
            tableCell22.Append(paragraph26);

            TableCell tableCell23 = new TableCell();

            TableCellProperties tableCellProperties23 = new TableCellProperties();
            TableCellWidth tableCellWidth23 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders23 = new TableCellBorders();
            TopBorder topBorder23 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder23 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder23 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder23 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders23.Append(topBorder23);
            tableCellBorders23.Append(leftBorder23);
            tableCellBorders23.Append(bottomBorder23);
            tableCellBorders23.Append(rightBorder23);
            Shading shading23 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin23 = new TableCellMargin();
            TopMargin topMargin27 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin23 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin27 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin23 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin23.Append(topMargin27);
            tableCellMargin23.Append(leftMargin23);
            tableCellMargin23.Append(bottomMargin27);
            tableCellMargin23.Append(rightMargin23);

            tableCellProperties23.Append(tableCellWidth23);
            tableCellProperties23.Append(tableCellBorders23);
            tableCellProperties23.Append(shading23);
            tableCellProperties23.Append(tableCellMargin23);

            Paragraph paragraph27 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties27 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId27 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
            RunFonts runFonts50 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize50 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties27.Append(runFonts50);
            paragraphMarkRunProperties27.Append(fontSize50);

            paragraphProperties27.Append(paragraphStyleId27);
            paragraphProperties27.Append(paragraphMarkRunProperties27);

            Run run24 = new Run();

            RunProperties runProperties24 = new RunProperties();
            RunFonts runFonts51 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize51 = new FontSize() { Val = "24" };

            runProperties24.Append(runFonts51);
            runProperties24.Append(fontSize51);
            Text text24 = new Text();
            text24.Text = "Applicant";

            run24.Append(runProperties24);
            run24.Append(text24);

            paragraph27.Append(paragraphProperties27);
            paragraph27.Append(run24);

            tableCell23.Append(tableCellProperties23);
            tableCell23.Append(paragraph27);

            TableCell tableCell24 = new TableCell();

            TableCellProperties tableCellProperties24 = new TableCellProperties();
            TableCellWidth tableCellWidth24 = new TableCellWidth() { Width = "1038", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders24 = new TableCellBorders();
            TopBorder topBorder24 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder24 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder24 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder24 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders24.Append(topBorder24);
            tableCellBorders24.Append(leftBorder24);
            tableCellBorders24.Append(bottomBorder24);
            tableCellBorders24.Append(rightBorder24);
            Shading shading24 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin24 = new TableCellMargin();
            TopMargin topMargin28 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin24 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin28 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin24 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin24.Append(topMargin28);
            tableCellMargin24.Append(leftMargin24);
            tableCellMargin24.Append(bottomMargin28);
            tableCellMargin24.Append(rightMargin24);

            tableCellProperties24.Append(tableCellWidth24);
            tableCellProperties24.Append(tableCellBorders24);
            tableCellProperties24.Append(shading24);
            tableCellProperties24.Append(tableCellMargin24);

            Paragraph paragraph28 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties28 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId28 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
            RunFonts runFonts52 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize52 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties28.Append(runFonts52);
            paragraphMarkRunProperties28.Append(fontSize52);

            paragraphProperties28.Append(paragraphStyleId28);
            paragraphProperties28.Append(paragraphMarkRunProperties28);

            Run run25 = new Run();

            RunProperties runProperties25 = new RunProperties();
            RunFonts runFonts53 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize53 = new FontSize() { Val = "24" };

            runProperties25.Append(runFonts53);
            runProperties25.Append(fontSize53);
            Text text25 = new Text();
            text25.Text = "Male";

            run25.Append(runProperties25);
            run25.Append(text25);

            paragraph28.Append(paragraphProperties28);
            paragraph28.Append(run25);

            tableCell24.Append(tableCellProperties24);
            tableCell24.Append(paragraph28);

            TableCell tableCell25 = new TableCell();

            TableCellProperties tableCellProperties25 = new TableCellProperties();
            TableCellWidth tableCellWidth25 = new TableCellWidth() { Width = "1371", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders25 = new TableCellBorders();
            TopBorder topBorder25 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder25 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder25 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder25 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders25.Append(topBorder25);
            tableCellBorders25.Append(leftBorder25);
            tableCellBorders25.Append(bottomBorder25);
            tableCellBorders25.Append(rightBorder25);
            Shading shading25 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin25 = new TableCellMargin();
            TopMargin topMargin29 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin25 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin29 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin25 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin25.Append(topMargin29);
            tableCellMargin25.Append(leftMargin25);
            tableCellMargin25.Append(bottomMargin29);
            tableCellMargin25.Append(rightMargin25);

            tableCellProperties25.Append(tableCellWidth25);
            tableCellProperties25.Append(tableCellBorders25);
            tableCellProperties25.Append(shading25);
            tableCellProperties25.Append(tableCellMargin25);

            Paragraph paragraph29 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties29 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId29 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
            RunFonts runFonts54 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize54 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties29.Append(runFonts54);
            paragraphMarkRunProperties29.Append(fontSize54);

            paragraphProperties29.Append(paragraphStyleId29);
            paragraphProperties29.Append(paragraphMarkRunProperties29);

            Run run26 = new Run();

            RunProperties runProperties26 = new RunProperties();
            RunFonts runFonts55 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize55 = new FontSize() { Val = "24" };

            runProperties26.Append(runFonts55);
            runProperties26.Append(fontSize55);
            Text text26 = new Text();
            text26.Text = "20/02/1990";

            run26.Append(runProperties26);
            run26.Append(text26);

            paragraph29.Append(paragraphProperties29);
            paragraph29.Append(run26);

            tableCell25.Append(tableCellProperties25);
            tableCell25.Append(paragraph29);

            TableCell tableCell26 = new TableCell();

            TableCellProperties tableCellProperties26 = new TableCellProperties();
            TableCellWidth tableCellWidth26 = new TableCellWidth() { Width = "1418", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders26 = new TableCellBorders();
            TopBorder topBorder26 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder26 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder26 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder26 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders26.Append(topBorder26);
            tableCellBorders26.Append(leftBorder26);
            tableCellBorders26.Append(bottomBorder26);
            tableCellBorders26.Append(rightBorder26);
            Shading shading26 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin26 = new TableCellMargin();
            TopMargin topMargin30 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin26 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin30 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin26 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin26.Append(topMargin30);
            tableCellMargin26.Append(leftMargin26);
            tableCellMargin26.Append(bottomMargin30);
            tableCellMargin26.Append(rightMargin26);

            tableCellProperties26.Append(tableCellWidth26);
            tableCellProperties26.Append(tableCellBorders26);
            tableCellProperties26.Append(shading26);
            tableCellProperties26.Append(tableCellMargin26);

            Paragraph paragraph30 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties30 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId30 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
            RunFonts runFonts56 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize56 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties30.Append(runFonts56);
            paragraphMarkRunProperties30.Append(fontSize56);

            paragraphProperties30.Append(paragraphStyleId30);
            paragraphProperties30.Append(paragraphMarkRunProperties30);

            Run run27 = new Run();

            RunProperties runProperties27 = new RunProperties();
            RunFonts runFonts57 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize57 = new FontSize() { Val = "24" };

            runProperties27.Append(runFonts57);
            runProperties27.Append(fontSize57);
            Text text27 = new Text();
            text27.Text = "UK National";

            run27.Append(runProperties27);
            run27.Append(text27);

            paragraph30.Append(paragraphProperties30);
            paragraph30.Append(run27);

            tableCell26.Append(tableCellProperties26);
            tableCell26.Append(paragraph30);

            TableCell tableCell27 = new TableCell();

            TableCellProperties tableCellProperties27 = new TableCellProperties();
            TableCellWidth tableCellWidth27 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders27 = new TableCellBorders();
            TopBorder topBorder27 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder27 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder27 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder27 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders27.Append(topBorder27);
            tableCellBorders27.Append(leftBorder27);
            tableCellBorders27.Append(bottomBorder27);
            tableCellBorders27.Append(rightBorder27);
            Shading shading27 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin27 = new TableCellMargin();
            TopMargin topMargin31 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin27 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin31 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin27 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin27.Append(topMargin31);
            tableCellMargin27.Append(leftMargin27);
            tableCellMargin27.Append(bottomMargin31);
            tableCellMargin27.Append(rightMargin27);

            tableCellProperties27.Append(tableCellWidth27);
            tableCellProperties27.Append(tableCellBorders27);
            tableCellProperties27.Append(shading27);
            tableCellProperties27.Append(tableCellMargin27);

            Paragraph paragraph31 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties31 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId31 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
            RunFonts runFonts58 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize58 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties31.Append(runFonts58);
            paragraphMarkRunProperties31.Append(fontSize58);

            paragraphProperties31.Append(paragraphStyleId31);
            paragraphProperties31.Append(paragraphMarkRunProperties31);

            Run run28 = new Run();

            RunProperties runProperties28 = new RunProperties();
            RunFonts runFonts59 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize59 = new FontSize() { Val = "24" };

            runProperties28.Append(runFonts59);
            runProperties28.Append(fontSize59);
            Text text28 = new Text();
            text28.Text = "Yes";

            run28.Append(runProperties28);
            run28.Append(text28);

            paragraph31.Append(paragraphProperties31);
            paragraph31.Append(run28);

            tableCell27.Append(tableCellProperties27);
            tableCell27.Append(paragraph31);

            TableCell tableCell28 = new TableCell();

            TableCellProperties tableCellProperties28 = new TableCellProperties();
            TableCellWidth tableCellWidth28 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders28 = new TableCellBorders();
            TopBorder topBorder28 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder28 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder28 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder28 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders28.Append(topBorder28);
            tableCellBorders28.Append(leftBorder28);
            tableCellBorders28.Append(bottomBorder28);
            tableCellBorders28.Append(rightBorder28);
            Shading shading28 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin28 = new TableCellMargin();
            TopMargin topMargin32 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin28 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin32 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin28 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin28.Append(topMargin32);
            tableCellMargin28.Append(leftMargin28);
            tableCellMargin28.Append(bottomMargin32);
            tableCellMargin28.Append(rightMargin28);

            tableCellProperties28.Append(tableCellWidth28);
            tableCellProperties28.Append(tableCellBorders28);
            tableCellProperties28.Append(shading28);
            tableCellProperties28.Append(tableCellMargin28);

            Paragraph paragraph32 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties32 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId32 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties32 = new ParagraphMarkRunProperties();
            RunFonts runFonts60 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize60 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties32.Append(runFonts60);
            paragraphMarkRunProperties32.Append(fontSize60);

            paragraphProperties32.Append(paragraphStyleId32);
            paragraphProperties32.Append(paragraphMarkRunProperties32);

            paragraph32.Append(paragraphProperties32);

            tableCell28.Append(tableCellProperties28);
            tableCell28.Append(paragraph32);

            TableCell tableCell29 = new TableCell();

            TableCellProperties tableCellProperties29 = new TableCellProperties();
            TableCellWidth tableCellWidth29 = new TableCellWidth() { Width = "709", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders29 = new TableCellBorders();
            TopBorder topBorder29 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder29 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder29 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder29 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders29.Append(topBorder29);
            tableCellBorders29.Append(leftBorder29);
            tableCellBorders29.Append(bottomBorder29);
            tableCellBorders29.Append(rightBorder29);
            Shading shading29 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin29 = new TableCellMargin();
            TopMargin topMargin33 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin29 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin33 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin29 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin29.Append(topMargin33);
            tableCellMargin29.Append(leftMargin29);
            tableCellMargin29.Append(bottomMargin33);
            tableCellMargin29.Append(rightMargin29);

            tableCellProperties29.Append(tableCellWidth29);
            tableCellProperties29.Append(tableCellBorders29);
            tableCellProperties29.Append(shading29);
            tableCellProperties29.Append(tableCellMargin29);

            Paragraph paragraph33 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties33 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId33 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
            RunFonts runFonts61 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize61 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties33.Append(runFonts61);
            paragraphMarkRunProperties33.Append(fontSize61);

            paragraphProperties33.Append(paragraphStyleId33);
            paragraphProperties33.Append(paragraphMarkRunProperties33);

            Run run29 = new Run();

            RunProperties runProperties29 = new RunProperties();
            RunFonts runFonts62 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize62 = new FontSize() { Val = "24" };

            runProperties29.Append(runFonts62);
            runProperties29.Append(fontSize62);
            Text text29 = new Text();
            text29.Text = "No";

            run29.Append(runProperties29);
            run29.Append(text29);

            paragraph33.Append(paragraphProperties33);
            paragraph33.Append(run29);

            tableCell29.Append(tableCellProperties29);
            tableCell29.Append(paragraph33);

            TableCell tableCell30 = new TableCell();

            TableCellProperties tableCellProperties30 = new TableCellProperties();
            TableCellWidth tableCellWidth30 = new TableCellWidth() { Width = "729", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders30 = new TableCellBorders();
            TopBorder topBorder30 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder30 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder30 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder30 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders30.Append(topBorder30);
            tableCellBorders30.Append(leftBorder30);
            tableCellBorders30.Append(bottomBorder30);
            tableCellBorders30.Append(rightBorder30);
            Shading shading30 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin30 = new TableCellMargin();
            TopMargin topMargin34 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin30 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin34 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin30 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin30.Append(topMargin34);
            tableCellMargin30.Append(leftMargin30);
            tableCellMargin30.Append(bottomMargin34);
            tableCellMargin30.Append(rightMargin30);

            tableCellProperties30.Append(tableCellWidth30);
            tableCellProperties30.Append(tableCellBorders30);
            tableCellProperties30.Append(shading30);
            tableCellProperties30.Append(tableCellMargin30);

            Paragraph paragraph34 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties34 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId34 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
            RunFonts runFonts63 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize63 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties34.Append(runFonts63);
            paragraphMarkRunProperties34.Append(fontSize63);

            paragraphProperties34.Append(paragraphStyleId34);
            paragraphProperties34.Append(paragraphMarkRunProperties34);

            Run run30 = new Run();

            RunProperties runProperties30 = new RunProperties();
            RunFonts runFonts64 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize64 = new FontSize() { Val = "24" };

            runProperties30.Append(runFonts64);
            runProperties30.Append(fontSize64);
            Text text30 = new Text();
            text30.Text = "No";

            run30.Append(runProperties30);
            run30.Append(text30);

            paragraph34.Append(paragraphProperties34);
            paragraph34.Append(run30);

            tableCell30.Append(tableCellProperties30);
            tableCell30.Append(paragraph34);

            tableRow4.Append(tablePropertyExceptions4);
            tableRow4.Append(tableCell22);
            tableRow4.Append(tableCell23);
            tableRow4.Append(tableCell24);
            tableRow4.Append(tableCell25);
            tableRow4.Append(tableCell26);
            tableRow4.Append(tableCell27);
            tableRow4.Append(tableCell28);
            tableRow4.Append(tableCell29);
            tableRow4.Append(tableCell30);

            TableRow tableRow5 = new TableRow() { RsidTableRowAddition = "00B67984", RsidTableRowProperties = "0002564B" };

            TablePropertyExceptions tablePropertyExceptions5 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault7 = new TableCellMarginDefault();
            TopMargin topMargin35 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin35 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault7.Append(topMargin35);
            tableCellMarginDefault7.Append(bottomMargin35);

            tablePropertyExceptions5.Append(tableCellMarginDefault7);

            TableCell tableCell31 = new TableCell();

            TableCellProperties tableCellProperties31 = new TableCellProperties();
            TableCellWidth tableCellWidth31 = new TableCellWidth() { Width = "1526", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders31 = new TableCellBorders();
            TopBorder topBorder31 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder31 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder31 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder31 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders31.Append(topBorder31);
            tableCellBorders31.Append(leftBorder31);
            tableCellBorders31.Append(bottomBorder31);
            tableCellBorders31.Append(rightBorder31);
            Shading shading31 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin31 = new TableCellMargin();
            TopMargin topMargin36 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin31 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin36 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin31 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin31.Append(topMargin36);
            tableCellMargin31.Append(leftMargin31);
            tableCellMargin31.Append(bottomMargin36);
            tableCellMargin31.Append(rightMargin31);

            tableCellProperties31.Append(tableCellWidth31);
            tableCellProperties31.Append(tableCellBorders31);
            tableCellProperties31.Append(shading31);
            tableCellProperties31.Append(tableCellMargin31);

            Paragraph paragraph35 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties35 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId35 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties35 = new ParagraphMarkRunProperties();
            RunFonts runFonts65 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize65 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties35.Append(runFonts65);
            paragraphMarkRunProperties35.Append(fontSize65);

            paragraphProperties35.Append(paragraphStyleId35);
            paragraphProperties35.Append(paragraphMarkRunProperties35);

            Run run31 = new Run();

            RunProperties runProperties31 = new RunProperties();
            RunFonts runFonts66 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize66 = new FontSize() { Val = "24" };

            runProperties31.Append(runFonts66);
            runProperties31.Append(fontSize66);
            Text text31 = new Text();
            text31.Text = "Stephanie James";

            run31.Append(runProperties31);
            run31.Append(text31);

            paragraph35.Append(paragraphProperties35);
            paragraph35.Append(run31);

            tableCell31.Append(tableCellProperties31);
            tableCell31.Append(paragraph35);

            TableCell tableCell32 = new TableCell();

            TableCellProperties tableCellProperties32 = new TableCellProperties();
            TableCellWidth tableCellWidth32 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders32 = new TableCellBorders();
            TopBorder topBorder32 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder32 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder32 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder32 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders32.Append(topBorder32);
            tableCellBorders32.Append(leftBorder32);
            tableCellBorders32.Append(bottomBorder32);
            tableCellBorders32.Append(rightBorder32);
            Shading shading32 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin32 = new TableCellMargin();
            TopMargin topMargin37 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin32 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin37 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin32 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin32.Append(topMargin37);
            tableCellMargin32.Append(leftMargin32);
            tableCellMargin32.Append(bottomMargin37);
            tableCellMargin32.Append(rightMargin32);

            tableCellProperties32.Append(tableCellWidth32);
            tableCellProperties32.Append(tableCellBorders32);
            tableCellProperties32.Append(shading32);
            tableCellProperties32.Append(tableCellMargin32);

            Paragraph paragraph36 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties36 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId36 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties36 = new ParagraphMarkRunProperties();
            RunFonts runFonts67 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize67 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties36.Append(runFonts67);
            paragraphMarkRunProperties36.Append(fontSize67);

            paragraphProperties36.Append(paragraphStyleId36);
            paragraphProperties36.Append(paragraphMarkRunProperties36);

            Run run32 = new Run();

            RunProperties runProperties32 = new RunProperties();
            RunFonts runFonts68 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize68 = new FontSize() { Val = "24" };

            runProperties32.Append(runFonts68);
            runProperties32.Append(fontSize68);
            Text text32 = new Text();
            text32.Text = "Household Member";

            run32.Append(runProperties32);
            run32.Append(text32);

            paragraph36.Append(paragraphProperties36);
            paragraph36.Append(run32);

            tableCell32.Append(tableCellProperties32);
            tableCell32.Append(paragraph36);

            TableCell tableCell33 = new TableCell();

            TableCellProperties tableCellProperties33 = new TableCellProperties();
            TableCellWidth tableCellWidth33 = new TableCellWidth() { Width = "1038", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders33 = new TableCellBorders();
            TopBorder topBorder33 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder33 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder33 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder33 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders33.Append(topBorder33);
            tableCellBorders33.Append(leftBorder33);
            tableCellBorders33.Append(bottomBorder33);
            tableCellBorders33.Append(rightBorder33);
            Shading shading33 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin33 = new TableCellMargin();
            TopMargin topMargin38 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin33 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin38 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin33 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin33.Append(topMargin38);
            tableCellMargin33.Append(leftMargin33);
            tableCellMargin33.Append(bottomMargin38);
            tableCellMargin33.Append(rightMargin33);

            tableCellProperties33.Append(tableCellWidth33);
            tableCellProperties33.Append(tableCellBorders33);
            tableCellProperties33.Append(shading33);
            tableCellProperties33.Append(tableCellMargin33);

            Paragraph paragraph37 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties37 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId37 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties37 = new ParagraphMarkRunProperties();
            RunFonts runFonts69 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize69 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties37.Append(runFonts69);
            paragraphMarkRunProperties37.Append(fontSize69);

            paragraphProperties37.Append(paragraphStyleId37);
            paragraphProperties37.Append(paragraphMarkRunProperties37);

            Run run33 = new Run();

            RunProperties runProperties33 = new RunProperties();
            RunFonts runFonts70 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize70 = new FontSize() { Val = "24" };

            runProperties33.Append(runFonts70);
            runProperties33.Append(fontSize70);
            Text text33 = new Text();
            text33.Text = "Female";

            run33.Append(runProperties33);
            run33.Append(text33);

            paragraph37.Append(paragraphProperties37);
            paragraph37.Append(run33);

            tableCell33.Append(tableCellProperties33);
            tableCell33.Append(paragraph37);

            TableCell tableCell34 = new TableCell();

            TableCellProperties tableCellProperties34 = new TableCellProperties();
            TableCellWidth tableCellWidth34 = new TableCellWidth() { Width = "1371", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders34 = new TableCellBorders();
            TopBorder topBorder34 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder34 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder34 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder34 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders34.Append(topBorder34);
            tableCellBorders34.Append(leftBorder34);
            tableCellBorders34.Append(bottomBorder34);
            tableCellBorders34.Append(rightBorder34);
            Shading shading34 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin34 = new TableCellMargin();
            TopMargin topMargin39 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin34 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin39 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin34 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin34.Append(topMargin39);
            tableCellMargin34.Append(leftMargin34);
            tableCellMargin34.Append(bottomMargin39);
            tableCellMargin34.Append(rightMargin34);

            tableCellProperties34.Append(tableCellWidth34);
            tableCellProperties34.Append(tableCellBorders34);
            tableCellProperties34.Append(shading34);
            tableCellProperties34.Append(tableCellMargin34);

            Paragraph paragraph38 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties38 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId38 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties38 = new ParagraphMarkRunProperties();
            RunFonts runFonts71 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize71 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties38.Append(runFonts71);
            paragraphMarkRunProperties38.Append(fontSize71);

            paragraphProperties38.Append(paragraphStyleId38);
            paragraphProperties38.Append(paragraphMarkRunProperties38);

            Run run34 = new Run();

            RunProperties runProperties34 = new RunProperties();
            RunFonts runFonts72 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize72 = new FontSize() { Val = "24" };

            runProperties34.Append(runFonts72);
            runProperties34.Append(fontSize72);
            Text text34 = new Text();
            text34.Text = "04/12/1991";

            run34.Append(runProperties34);
            run34.Append(text34);

            paragraph38.Append(paragraphProperties38);
            paragraph38.Append(run34);

            tableCell34.Append(tableCellProperties34);
            tableCell34.Append(paragraph38);

            TableCell tableCell35 = new TableCell();

            TableCellProperties tableCellProperties35 = new TableCellProperties();
            TableCellWidth tableCellWidth35 = new TableCellWidth() { Width = "1418", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders35 = new TableCellBorders();
            TopBorder topBorder35 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder35 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder35 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder35 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders35.Append(topBorder35);
            tableCellBorders35.Append(leftBorder35);
            tableCellBorders35.Append(bottomBorder35);
            tableCellBorders35.Append(rightBorder35);
            Shading shading35 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin35 = new TableCellMargin();
            TopMargin topMargin40 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin35 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin40 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin35 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin35.Append(topMargin40);
            tableCellMargin35.Append(leftMargin35);
            tableCellMargin35.Append(bottomMargin40);
            tableCellMargin35.Append(rightMargin35);

            tableCellProperties35.Append(tableCellWidth35);
            tableCellProperties35.Append(tableCellBorders35);
            tableCellProperties35.Append(shading35);
            tableCellProperties35.Append(tableCellMargin35);

            Paragraph paragraph39 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties39 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId39 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties39 = new ParagraphMarkRunProperties();
            RunFonts runFonts73 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize73 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties39.Append(runFonts73);
            paragraphMarkRunProperties39.Append(fontSize73);

            paragraphProperties39.Append(paragraphStyleId39);
            paragraphProperties39.Append(paragraphMarkRunProperties39);

            Run run35 = new Run();

            RunProperties runProperties35 = new RunProperties();
            RunFonts runFonts74 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize74 = new FontSize() { Val = "24" };

            runProperties35.Append(runFonts74);
            runProperties35.Append(fontSize74);
            Text text35 = new Text();
            text35.Text = "UK National";

            run35.Append(runProperties35);
            run35.Append(text35);

            paragraph39.Append(paragraphProperties39);
            paragraph39.Append(run35);

            tableCell35.Append(tableCellProperties35);
            tableCell35.Append(paragraph39);

            TableCell tableCell36 = new TableCell();

            TableCellProperties tableCellProperties36 = new TableCellProperties();
            TableCellWidth tableCellWidth36 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders36 = new TableCellBorders();
            TopBorder topBorder36 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder36 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder36 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder36 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders36.Append(topBorder36);
            tableCellBorders36.Append(leftBorder36);
            tableCellBorders36.Append(bottomBorder36);
            tableCellBorders36.Append(rightBorder36);
            Shading shading36 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin36 = new TableCellMargin();
            TopMargin topMargin41 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin36 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin41 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin36 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin36.Append(topMargin41);
            tableCellMargin36.Append(leftMargin36);
            tableCellMargin36.Append(bottomMargin41);
            tableCellMargin36.Append(rightMargin36);

            tableCellProperties36.Append(tableCellWidth36);
            tableCellProperties36.Append(tableCellBorders36);
            tableCellProperties36.Append(shading36);
            tableCellProperties36.Append(tableCellMargin36);

            Paragraph paragraph40 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties40 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId40 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties40 = new ParagraphMarkRunProperties();
            RunFonts runFonts75 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize75 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties40.Append(runFonts75);
            paragraphMarkRunProperties40.Append(fontSize75);

            paragraphProperties40.Append(paragraphStyleId40);
            paragraphProperties40.Append(paragraphMarkRunProperties40);

            Run run36 = new Run();

            RunProperties runProperties36 = new RunProperties();
            RunFonts runFonts76 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize76 = new FontSize() { Val = "24" };

            runProperties36.Append(runFonts76);
            runProperties36.Append(fontSize76);
            Text text36 = new Text();
            text36.Text = "Yes";

            run36.Append(runProperties36);
            run36.Append(text36);

            paragraph40.Append(paragraphProperties40);
            paragraph40.Append(run36);

            tableCell36.Append(tableCellProperties36);
            tableCell36.Append(paragraph40);

            TableCell tableCell37 = new TableCell();

            TableCellProperties tableCellProperties37 = new TableCellProperties();
            TableCellWidth tableCellWidth37 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders37 = new TableCellBorders();
            TopBorder topBorder37 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder37 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder37 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder37 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders37.Append(topBorder37);
            tableCellBorders37.Append(leftBorder37);
            tableCellBorders37.Append(bottomBorder37);
            tableCellBorders37.Append(rightBorder37);
            Shading shading37 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin37 = new TableCellMargin();
            TopMargin topMargin42 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin37 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin42 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin37 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin37.Append(topMargin42);
            tableCellMargin37.Append(leftMargin37);
            tableCellMargin37.Append(bottomMargin42);
            tableCellMargin37.Append(rightMargin37);

            tableCellProperties37.Append(tableCellWidth37);
            tableCellProperties37.Append(tableCellBorders37);
            tableCellProperties37.Append(shading37);
            tableCellProperties37.Append(tableCellMargin37);

            Paragraph paragraph41 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties41 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId41 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties41 = new ParagraphMarkRunProperties();
            RunFonts runFonts77 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize77 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties41.Append(runFonts77);
            paragraphMarkRunProperties41.Append(fontSize77);

            paragraphProperties41.Append(paragraphStyleId41);
            paragraphProperties41.Append(paragraphMarkRunProperties41);

            Run run37 = new Run();

            RunProperties runProperties37 = new RunProperties();
            RunFonts runFonts78 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize78 = new FontSize() { Val = "24" };

            runProperties37.Append(runFonts78);
            runProperties37.Append(fontSize78);
            Text text37 = new Text();
            text37.Text = "Partner";

            run37.Append(runProperties37);
            run37.Append(text37);

            paragraph41.Append(paragraphProperties41);
            paragraph41.Append(run37);

            tableCell37.Append(tableCellProperties37);
            tableCell37.Append(paragraph41);

            TableCell tableCell38 = new TableCell();

            TableCellProperties tableCellProperties38 = new TableCellProperties();
            TableCellWidth tableCellWidth38 = new TableCellWidth() { Width = "709", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders38 = new TableCellBorders();
            TopBorder topBorder38 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder38 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder38 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder38 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders38.Append(topBorder38);
            tableCellBorders38.Append(leftBorder38);
            tableCellBorders38.Append(bottomBorder38);
            tableCellBorders38.Append(rightBorder38);
            Shading shading38 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin38 = new TableCellMargin();
            TopMargin topMargin43 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin38 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin43 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin38 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin38.Append(topMargin43);
            tableCellMargin38.Append(leftMargin38);
            tableCellMargin38.Append(bottomMargin43);
            tableCellMargin38.Append(rightMargin38);

            tableCellProperties38.Append(tableCellWidth38);
            tableCellProperties38.Append(tableCellBorders38);
            tableCellProperties38.Append(shading38);
            tableCellProperties38.Append(tableCellMargin38);

            Paragraph paragraph42 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties42 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId42 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties42 = new ParagraphMarkRunProperties();
            RunFonts runFonts79 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize79 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties42.Append(runFonts79);
            paragraphMarkRunProperties42.Append(fontSize79);

            paragraphProperties42.Append(paragraphStyleId42);
            paragraphProperties42.Append(paragraphMarkRunProperties42);

            Run run38 = new Run();

            RunProperties runProperties38 = new RunProperties();
            RunFonts runFonts80 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize80 = new FontSize() { Val = "24" };

            runProperties38.Append(runFonts80);
            runProperties38.Append(fontSize80);
            Text text38 = new Text();
            text38.Text = "No";

            run38.Append(runProperties38);
            run38.Append(text38);

            paragraph42.Append(paragraphProperties42);
            paragraph42.Append(run38);

            tableCell38.Append(tableCellProperties38);
            tableCell38.Append(paragraph42);

            TableCell tableCell39 = new TableCell();

            TableCellProperties tableCellProperties39 = new TableCellProperties();
            TableCellWidth tableCellWidth39 = new TableCellWidth() { Width = "729", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders39 = new TableCellBorders();
            TopBorder topBorder39 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder39 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder39 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder39 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders39.Append(topBorder39);
            tableCellBorders39.Append(leftBorder39);
            tableCellBorders39.Append(bottomBorder39);
            tableCellBorders39.Append(rightBorder39);
            Shading shading39 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin39 = new TableCellMargin();
            TopMargin topMargin44 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin39 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin44 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin39 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin39.Append(topMargin44);
            tableCellMargin39.Append(leftMargin39);
            tableCellMargin39.Append(bottomMargin44);
            tableCellMargin39.Append(rightMargin39);

            tableCellProperties39.Append(tableCellWidth39);
            tableCellProperties39.Append(tableCellBorders39);
            tableCellProperties39.Append(shading39);
            tableCellProperties39.Append(tableCellMargin39);

            Paragraph paragraph43 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties43 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId43 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties43 = new ParagraphMarkRunProperties();
            RunFonts runFonts81 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize81 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties43.Append(runFonts81);
            paragraphMarkRunProperties43.Append(fontSize81);

            paragraphProperties43.Append(paragraphStyleId43);
            paragraphProperties43.Append(paragraphMarkRunProperties43);

            Run run39 = new Run();

            RunProperties runProperties39 = new RunProperties();
            RunFonts runFonts82 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize82 = new FontSize() { Val = "24" };

            runProperties39.Append(runFonts82);
            runProperties39.Append(fontSize82);
            Text text39 = new Text();
            text39.Text = "No";

            run39.Append(runProperties39);
            run39.Append(text39);

            paragraph43.Append(paragraphProperties43);
            paragraph43.Append(run39);

            tableCell39.Append(tableCellProperties39);
            tableCell39.Append(paragraph43);

            tableRow5.Append(tablePropertyExceptions5);
            tableRow5.Append(tableCell31);
            tableRow5.Append(tableCell32);
            tableRow5.Append(tableCell33);
            tableRow5.Append(tableCell34);
            tableRow5.Append(tableCell35);
            tableRow5.Append(tableCell36);
            tableRow5.Append(tableCell37);
            tableRow5.Append(tableCell38);
            tableRow5.Append(tableCell39);

            TableRow tableRow6 = new TableRow() { RsidTableRowAddition = "00B67984", RsidTableRowProperties = "0002564B" };

            TablePropertyExceptions tablePropertyExceptions6 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault8 = new TableCellMarginDefault();
            TopMargin topMargin45 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin45 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault8.Append(topMargin45);
            tableCellMarginDefault8.Append(bottomMargin45);

            tablePropertyExceptions6.Append(tableCellMarginDefault8);

            TableCell tableCell40 = new TableCell();

            TableCellProperties tableCellProperties40 = new TableCellProperties();
            TableCellWidth tableCellWidth40 = new TableCellWidth() { Width = "1526", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders40 = new TableCellBorders();
            TopBorder topBorder40 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder40 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder40 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder40 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders40.Append(topBorder40);
            tableCellBorders40.Append(leftBorder40);
            tableCellBorders40.Append(bottomBorder40);
            tableCellBorders40.Append(rightBorder40);
            Shading shading40 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin40 = new TableCellMargin();
            TopMargin topMargin46 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin40 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin46 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin40 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin40.Append(topMargin46);
            tableCellMargin40.Append(leftMargin40);
            tableCellMargin40.Append(bottomMargin46);
            tableCellMargin40.Append(rightMargin40);

            tableCellProperties40.Append(tableCellWidth40);
            tableCellProperties40.Append(tableCellBorders40);
            tableCellProperties40.Append(shading40);
            tableCellProperties40.Append(tableCellMargin40);

            Paragraph paragraph44 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties44 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId44 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties44 = new ParagraphMarkRunProperties();
            RunFonts runFonts83 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize83 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties44.Append(runFonts83);
            paragraphMarkRunProperties44.Append(fontSize83);

            paragraphProperties44.Append(paragraphStyleId44);
            paragraphProperties44.Append(paragraphMarkRunProperties44);

            Run run40 = new Run();

            RunProperties runProperties40 = new RunProperties();
            RunFonts runFonts84 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize84 = new FontSize() { Val = "24" };

            runProperties40.Append(runFonts84);
            runProperties40.Append(fontSize84);
            Text text40 = new Text();
            text40.Text = "Ella Rose Smith";

            run40.Append(runProperties40);
            run40.Append(text40);

            paragraph44.Append(paragraphProperties44);
            paragraph44.Append(run40);

            tableCell40.Append(tableCellProperties40);
            tableCell40.Append(paragraph44);

            TableCell tableCell41 = new TableCell();

            TableCellProperties tableCellProperties41 = new TableCellProperties();
            TableCellWidth tableCellWidth41 = new TableCellWidth() { Width = "1276", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders41 = new TableCellBorders();
            TopBorder topBorder41 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder41 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder41 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder41 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders41.Append(topBorder41);
            tableCellBorders41.Append(leftBorder41);
            tableCellBorders41.Append(bottomBorder41);
            tableCellBorders41.Append(rightBorder41);
            Shading shading41 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin41 = new TableCellMargin();
            TopMargin topMargin47 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin41 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin47 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin41 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin41.Append(topMargin47);
            tableCellMargin41.Append(leftMargin41);
            tableCellMargin41.Append(bottomMargin47);
            tableCellMargin41.Append(rightMargin41);

            tableCellProperties41.Append(tableCellWidth41);
            tableCellProperties41.Append(tableCellBorders41);
            tableCellProperties41.Append(shading41);
            tableCellProperties41.Append(tableCellMargin41);

            Paragraph paragraph45 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties45 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId45 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties45 = new ParagraphMarkRunProperties();
            RunFonts runFonts85 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize85 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties45.Append(runFonts85);
            paragraphMarkRunProperties45.Append(fontSize85);

            paragraphProperties45.Append(paragraphStyleId45);
            paragraphProperties45.Append(paragraphMarkRunProperties45);

            Run run41 = new Run();

            RunProperties runProperties41 = new RunProperties();
            RunFonts runFonts86 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize86 = new FontSize() { Val = "24" };

            runProperties41.Append(runFonts86);
            runProperties41.Append(fontSize86);
            Text text41 = new Text();
            text41.Text = "Household Member";

            run41.Append(runProperties41);
            run41.Append(text41);

            paragraph45.Append(paragraphProperties45);
            paragraph45.Append(run41);

            tableCell41.Append(tableCellProperties41);
            tableCell41.Append(paragraph45);

            TableCell tableCell42 = new TableCell();

            TableCellProperties tableCellProperties42 = new TableCellProperties();
            TableCellWidth tableCellWidth42 = new TableCellWidth() { Width = "1038", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders42 = new TableCellBorders();
            TopBorder topBorder42 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder42 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder42 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder42 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders42.Append(topBorder42);
            tableCellBorders42.Append(leftBorder42);
            tableCellBorders42.Append(bottomBorder42);
            tableCellBorders42.Append(rightBorder42);
            Shading shading42 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin42 = new TableCellMargin();
            TopMargin topMargin48 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin42 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin48 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin42 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin42.Append(topMargin48);
            tableCellMargin42.Append(leftMargin42);
            tableCellMargin42.Append(bottomMargin48);
            tableCellMargin42.Append(rightMargin42);

            tableCellProperties42.Append(tableCellWidth42);
            tableCellProperties42.Append(tableCellBorders42);
            tableCellProperties42.Append(shading42);
            tableCellProperties42.Append(tableCellMargin42);

            Paragraph paragraph46 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties46 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId46 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties46 = new ParagraphMarkRunProperties();
            RunFonts runFonts87 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize87 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties46.Append(runFonts87);
            paragraphMarkRunProperties46.Append(fontSize87);

            paragraphProperties46.Append(paragraphStyleId46);
            paragraphProperties46.Append(paragraphMarkRunProperties46);

            Run run42 = new Run();

            RunProperties runProperties42 = new RunProperties();
            RunFonts runFonts88 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize88 = new FontSize() { Val = "24" };

            runProperties42.Append(runFonts88);
            runProperties42.Append(fontSize88);
            Text text42 = new Text();
            text42.Text = "Female";

            run42.Append(runProperties42);
            run42.Append(text42);

            paragraph46.Append(paragraphProperties46);
            paragraph46.Append(run42);

            tableCell42.Append(tableCellProperties42);
            tableCell42.Append(paragraph46);

            TableCell tableCell43 = new TableCell();

            TableCellProperties tableCellProperties43 = new TableCellProperties();
            TableCellWidth tableCellWidth43 = new TableCellWidth() { Width = "1371", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders43 = new TableCellBorders();
            TopBorder topBorder43 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder43 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder43 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder43 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders43.Append(topBorder43);
            tableCellBorders43.Append(leftBorder43);
            tableCellBorders43.Append(bottomBorder43);
            tableCellBorders43.Append(rightBorder43);
            Shading shading43 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin43 = new TableCellMargin();
            TopMargin topMargin49 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin43 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin49 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin43 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin43.Append(topMargin49);
            tableCellMargin43.Append(leftMargin43);
            tableCellMargin43.Append(bottomMargin49);
            tableCellMargin43.Append(rightMargin43);

            tableCellProperties43.Append(tableCellWidth43);
            tableCellProperties43.Append(tableCellBorders43);
            tableCellProperties43.Append(shading43);
            tableCellProperties43.Append(tableCellMargin43);

            Paragraph paragraph47 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties47 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId47 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties47 = new ParagraphMarkRunProperties();
            RunFonts runFonts89 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize89 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties47.Append(runFonts89);
            paragraphMarkRunProperties47.Append(fontSize89);

            paragraphProperties47.Append(paragraphStyleId47);
            paragraphProperties47.Append(paragraphMarkRunProperties47);

            Run run43 = new Run();

            RunProperties runProperties43 = new RunProperties();
            RunFonts runFonts90 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize90 = new FontSize() { Val = "24" };

            runProperties43.Append(runFonts90);
            runProperties43.Append(fontSize90);
            Text text43 = new Text();
            text43.Text = "03/01/2012";

            run43.Append(runProperties43);
            run43.Append(text43);

            paragraph47.Append(paragraphProperties47);
            paragraph47.Append(run43);

            tableCell43.Append(tableCellProperties43);
            tableCell43.Append(paragraph47);

            TableCell tableCell44 = new TableCell();

            TableCellProperties tableCellProperties44 = new TableCellProperties();
            TableCellWidth tableCellWidth44 = new TableCellWidth() { Width = "1418", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders44 = new TableCellBorders();
            TopBorder topBorder44 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder44 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder44 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder44 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders44.Append(topBorder44);
            tableCellBorders44.Append(leftBorder44);
            tableCellBorders44.Append(bottomBorder44);
            tableCellBorders44.Append(rightBorder44);
            Shading shading44 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin44 = new TableCellMargin();
            TopMargin topMargin50 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin44 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin50 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin44 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin44.Append(topMargin50);
            tableCellMargin44.Append(leftMargin44);
            tableCellMargin44.Append(bottomMargin50);
            tableCellMargin44.Append(rightMargin44);

            tableCellProperties44.Append(tableCellWidth44);
            tableCellProperties44.Append(tableCellBorders44);
            tableCellProperties44.Append(shading44);
            tableCellProperties44.Append(tableCellMargin44);

            Paragraph paragraph48 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties48 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId48 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties48 = new ParagraphMarkRunProperties();
            RunFonts runFonts91 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize91 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties48.Append(runFonts91);
            paragraphMarkRunProperties48.Append(fontSize91);

            paragraphProperties48.Append(paragraphStyleId48);
            paragraphProperties48.Append(paragraphMarkRunProperties48);

            Run run44 = new Run();

            RunProperties runProperties44 = new RunProperties();
            RunFonts runFonts92 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize92 = new FontSize() { Val = "24" };

            runProperties44.Append(runFonts92);
            runProperties44.Append(fontSize92);
            Text text44 = new Text();
            text44.Text = "UK National";

            run44.Append(runProperties44);
            run44.Append(text44);

            paragraph48.Append(paragraphProperties48);
            paragraph48.Append(run44);

            tableCell44.Append(tableCellProperties44);
            tableCell44.Append(paragraph48);

            TableCell tableCell45 = new TableCell();

            TableCellProperties tableCellProperties45 = new TableCellProperties();
            TableCellWidth tableCellWidth45 = new TableCellWidth() { Width = "1134", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders45 = new TableCellBorders();
            TopBorder topBorder45 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder45 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder45 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder45 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders45.Append(topBorder45);
            tableCellBorders45.Append(leftBorder45);
            tableCellBorders45.Append(bottomBorder45);
            tableCellBorders45.Append(rightBorder45);
            Shading shading45 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin45 = new TableCellMargin();
            TopMargin topMargin51 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin45 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin51 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin45 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin45.Append(topMargin51);
            tableCellMargin45.Append(leftMargin45);
            tableCellMargin45.Append(bottomMargin51);
            tableCellMargin45.Append(rightMargin45);

            tableCellProperties45.Append(tableCellWidth45);
            tableCellProperties45.Append(tableCellBorders45);
            tableCellProperties45.Append(shading45);
            tableCellProperties45.Append(tableCellMargin45);

            Paragraph paragraph49 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties49 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId49 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties49 = new ParagraphMarkRunProperties();
            RunFonts runFonts93 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize93 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties49.Append(runFonts93);
            paragraphMarkRunProperties49.Append(fontSize93);

            paragraphProperties49.Append(paragraphStyleId49);
            paragraphProperties49.Append(paragraphMarkRunProperties49);

            Run run45 = new Run();

            RunProperties runProperties45 = new RunProperties();
            RunFonts runFonts94 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize94 = new FontSize() { Val = "24" };

            runProperties45.Append(runFonts94);
            runProperties45.Append(fontSize94);
            Text text45 = new Text();
            text45.Text = "Yes";

            run45.Append(runProperties45);
            run45.Append(text45);

            paragraph49.Append(paragraphProperties49);
            paragraph49.Append(run45);

            tableCell45.Append(tableCellProperties45);
            tableCell45.Append(paragraph49);

            TableCell tableCell46 = new TableCell();

            TableCellProperties tableCellProperties46 = new TableCellProperties();
            TableCellWidth tableCellWidth46 = new TableCellWidth() { Width = "1559", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders46 = new TableCellBorders();
            TopBorder topBorder46 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder46 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder46 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder46 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders46.Append(topBorder46);
            tableCellBorders46.Append(leftBorder46);
            tableCellBorders46.Append(bottomBorder46);
            tableCellBorders46.Append(rightBorder46);
            Shading shading46 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin46 = new TableCellMargin();
            TopMargin topMargin52 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin46 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin52 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin46 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin46.Append(topMargin52);
            tableCellMargin46.Append(leftMargin46);
            tableCellMargin46.Append(bottomMargin52);
            tableCellMargin46.Append(rightMargin46);

            tableCellProperties46.Append(tableCellWidth46);
            tableCellProperties46.Append(tableCellBorders46);
            tableCellProperties46.Append(shading46);
            tableCellProperties46.Append(tableCellMargin46);

            Paragraph paragraph50 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties50 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId50 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties50 = new ParagraphMarkRunProperties();
            RunFonts runFonts95 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize95 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties50.Append(runFonts95);
            paragraphMarkRunProperties50.Append(fontSize95);

            paragraphProperties50.Append(paragraphStyleId50);
            paragraphProperties50.Append(paragraphMarkRunProperties50);

            Run run46 = new Run();

            RunProperties runProperties46 = new RunProperties();
            RunFonts runFonts96 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize96 = new FontSize() { Val = "24" };

            runProperties46.Append(runFonts96);
            runProperties46.Append(fontSize96);
            Text text46 = new Text();
            text46.Text = "Daughter";

            run46.Append(runProperties46);
            run46.Append(text46);

            paragraph50.Append(paragraphProperties50);
            paragraph50.Append(run46);

            tableCell46.Append(tableCellProperties46);
            tableCell46.Append(paragraph50);

            TableCell tableCell47 = new TableCell();

            TableCellProperties tableCellProperties47 = new TableCellProperties();
            TableCellWidth tableCellWidth47 = new TableCellWidth() { Width = "709", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders47 = new TableCellBorders();
            TopBorder topBorder47 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder47 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder47 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder47 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders47.Append(topBorder47);
            tableCellBorders47.Append(leftBorder47);
            tableCellBorders47.Append(bottomBorder47);
            tableCellBorders47.Append(rightBorder47);
            Shading shading47 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin47 = new TableCellMargin();
            TopMargin topMargin53 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin47 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin53 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin47 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin47.Append(topMargin53);
            tableCellMargin47.Append(leftMargin47);
            tableCellMargin47.Append(bottomMargin53);
            tableCellMargin47.Append(rightMargin47);

            tableCellProperties47.Append(tableCellWidth47);
            tableCellProperties47.Append(tableCellBorders47);
            tableCellProperties47.Append(shading47);
            tableCellProperties47.Append(tableCellMargin47);

            Paragraph paragraph51 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties51 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId51 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties51 = new ParagraphMarkRunProperties();
            RunFonts runFonts97 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize97 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties51.Append(runFonts97);
            paragraphMarkRunProperties51.Append(fontSize97);

            paragraphProperties51.Append(paragraphStyleId51);
            paragraphProperties51.Append(paragraphMarkRunProperties51);

            Run run47 = new Run();

            RunProperties runProperties47 = new RunProperties();
            RunFonts runFonts98 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize98 = new FontSize() { Val = "24" };

            runProperties47.Append(runFonts98);
            runProperties47.Append(fontSize98);
            Text text47 = new Text();
            text47.Text = "No";

            run47.Append(runProperties47);
            run47.Append(text47);

            paragraph51.Append(paragraphProperties51);
            paragraph51.Append(run47);

            tableCell47.Append(tableCellProperties47);
            tableCell47.Append(paragraph51);

            TableCell tableCell48 = new TableCell();

            TableCellProperties tableCellProperties48 = new TableCellProperties();
            TableCellWidth tableCellWidth48 = new TableCellWidth() { Width = "729", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders48 = new TableCellBorders();
            TopBorder topBorder48 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder48 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder48 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder48 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders48.Append(topBorder48);
            tableCellBorders48.Append(leftBorder48);
            tableCellBorders48.Append(bottomBorder48);
            tableCellBorders48.Append(rightBorder48);
            Shading shading48 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin48 = new TableCellMargin();
            TopMargin topMargin54 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin48 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin54 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin48 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin48.Append(topMargin54);
            tableCellMargin48.Append(leftMargin48);
            tableCellMargin48.Append(bottomMargin54);
            tableCellMargin48.Append(rightMargin48);

            tableCellProperties48.Append(tableCellWidth48);
            tableCellProperties48.Append(tableCellBorders48);
            tableCellProperties48.Append(shading48);
            tableCellProperties48.Append(tableCellMargin48);

            Paragraph paragraph52 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties52 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId52 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties52 = new ParagraphMarkRunProperties();
            RunFonts runFonts99 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize99 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties52.Append(runFonts99);
            paragraphMarkRunProperties52.Append(fontSize99);

            paragraphProperties52.Append(paragraphStyleId52);
            paragraphProperties52.Append(paragraphMarkRunProperties52);

            Run run48 = new Run();

            RunProperties runProperties48 = new RunProperties();
            RunFonts runFonts100 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize100 = new FontSize() { Val = "24" };

            runProperties48.Append(runFonts100);
            runProperties48.Append(fontSize100);
            Text text48 = new Text();
            text48.Text = "No";

            run48.Append(runProperties48);
            run48.Append(text48);

            paragraph52.Append(paragraphProperties52);
            paragraph52.Append(run48);

            tableCell48.Append(tableCellProperties48);
            tableCell48.Append(paragraph52);

            tableRow6.Append(tablePropertyExceptions6);
            tableRow6.Append(tableCell40);
            tableRow6.Append(tableCell41);
            tableRow6.Append(tableCell42);
            tableRow6.Append(tableCell43);
            tableRow6.Append(tableCell44);
            tableRow6.Append(tableCell45);
            tableRow6.Append(tableCell46);
            tableRow6.Append(tableCell47);
            tableRow6.Append(tableCell48);

            table2.Append(tableProperties2);
            table2.Append(tableGrid2);
            table2.Append(tableRow3);
            table2.Append(tableRow4);
            table2.Append(tableRow5);
            table2.Append(tableRow6);

            Paragraph paragraph53 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties53 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId53 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties53 = new ParagraphMarkRunProperties();
            RunFonts runFonts101 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize101 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties53.Append(runFonts101);
            paragraphMarkRunProperties53.Append(fontSize101);

            paragraphProperties53.Append(paragraphStyleId53);
            paragraphProperties53.Append(paragraphMarkRunProperties53);

            paragraph53.Append(paragraphProperties53);

            Paragraph paragraph54 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties54 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId54 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties54 = new ParagraphMarkRunProperties();
            RunFonts runFonts102 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize102 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties54.Append(runFonts102);
            paragraphMarkRunProperties54.Append(fontSize102);

            paragraphProperties54.Append(paragraphStyleId54);
            paragraphProperties54.Append(paragraphMarkRunProperties54);

            Run run49 = new Run();

            RunProperties runProperties49 = new RunProperties();
            RunFonts runFonts103 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize103 = new FontSize() { Val = "24" };

            runProperties49.Append(runFonts103);
            runProperties49.Append(fontSize103);
            Text text49 = new Text();
            text49.Text = "Contact Information";

            run49.Append(runProperties49);
            run49.Append(text49);

            paragraph54.Append(paragraphProperties54);
            paragraph54.Append(run49);

            Table table3 = new Table();

            TableProperties tableProperties3 = new TableProperties();
            TableWidth tableWidth3 = new TableWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout3 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault9 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin3 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin3 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault9.Append(tableCellLeftMargin3);
            tableCellMarginDefault9.Append(tableCellRightMargin3);
            TableLook tableLook3 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties3.Append(tableWidth3);
            tableProperties3.Append(tableLayout3);
            tableProperties3.Append(tableCellMarginDefault9);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            GridColumn gridColumn16 = new GridColumn() { Width = "2400" };
            GridColumn gridColumn17 = new GridColumn() { Width = "3600" };

            tableGrid3.Append(gridColumn16);
            tableGrid3.Append(gridColumn17);

            TableRow tableRow7 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions7 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault10 = new TableCellMarginDefault();
            TopMargin topMargin55 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin55 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault10.Append(topMargin55);
            tableCellMarginDefault10.Append(bottomMargin55);

            tablePropertyExceptions7.Append(tableCellMarginDefault10);

            TableCell tableCell49 = new TableCell();

            TableCellProperties tableCellProperties49 = new TableCellProperties();
            TableCellWidth tableCellWidth49 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders49 = new TableCellBorders();
            TopBorder topBorder49 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder49 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder49 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder49 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders49.Append(topBorder49);
            tableCellBorders49.Append(leftBorder49);
            tableCellBorders49.Append(bottomBorder49);
            tableCellBorders49.Append(rightBorder49);
            Shading shading49 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin49 = new TableCellMargin();
            TopMargin topMargin56 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin49 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin56 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin49 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin49.Append(topMargin56);
            tableCellMargin49.Append(leftMargin49);
            tableCellMargin49.Append(bottomMargin56);
            tableCellMargin49.Append(rightMargin49);

            tableCellProperties49.Append(tableCellWidth49);
            tableCellProperties49.Append(tableCellBorders49);
            tableCellProperties49.Append(shading49);
            tableCellProperties49.Append(tableCellMargin49);

            Paragraph paragraph55 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties55 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId55 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification23 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties55 = new ParagraphMarkRunProperties();
            RunFonts runFonts104 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold32 = new Bold();
            FontSize fontSize104 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties55.Append(runFonts104);
            paragraphMarkRunProperties55.Append(bold32);
            paragraphMarkRunProperties55.Append(fontSize104);

            paragraphProperties55.Append(paragraphStyleId55);
            paragraphProperties55.Append(justification23);
            paragraphProperties55.Append(paragraphMarkRunProperties55);

            Run run50 = new Run();

            RunProperties runProperties50 = new RunProperties();
            RunFonts runFonts105 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold33 = new Bold();
            FontSize fontSize105 = new FontSize() { Val = "24" };

            runProperties50.Append(runFonts105);
            runProperties50.Append(bold33);
            runProperties50.Append(fontSize105);
            Text text50 = new Text();
            text50.Text = "Item";

            run50.Append(runProperties50);
            run50.Append(text50);

            paragraph55.Append(paragraphProperties55);
            paragraph55.Append(run50);

            tableCell49.Append(tableCellProperties49);
            tableCell49.Append(paragraph55);

            TableCell tableCell50 = new TableCell();

            TableCellProperties tableCellProperties50 = new TableCellProperties();
            TableCellWidth tableCellWidth50 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders50 = new TableCellBorders();
            TopBorder topBorder50 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder50 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder50 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder50 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders50.Append(topBorder50);
            tableCellBorders50.Append(leftBorder50);
            tableCellBorders50.Append(bottomBorder50);
            tableCellBorders50.Append(rightBorder50);
            Shading shading50 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin50 = new TableCellMargin();
            TopMargin topMargin57 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin50 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin57 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin50 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin50.Append(topMargin57);
            tableCellMargin50.Append(leftMargin50);
            tableCellMargin50.Append(bottomMargin57);
            tableCellMargin50.Append(rightMargin50);

            tableCellProperties50.Append(tableCellWidth50);
            tableCellProperties50.Append(tableCellBorders50);
            tableCellProperties50.Append(shading50);
            tableCellProperties50.Append(tableCellMargin50);

            Paragraph paragraph56 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties56 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId56 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification24 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties56 = new ParagraphMarkRunProperties();
            RunFonts runFonts106 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold34 = new Bold();
            FontSize fontSize106 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties56.Append(runFonts106);
            paragraphMarkRunProperties56.Append(bold34);
            paragraphMarkRunProperties56.Append(fontSize106);

            paragraphProperties56.Append(paragraphStyleId56);
            paragraphProperties56.Append(justification24);
            paragraphProperties56.Append(paragraphMarkRunProperties56);

            Run run51 = new Run();

            RunProperties runProperties51 = new RunProperties();
            RunFonts runFonts107 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold35 = new Bold();
            FontSize fontSize107 = new FontSize() { Val = "24" };

            runProperties51.Append(runFonts107);
            runProperties51.Append(bold35);
            runProperties51.Append(fontSize107);
            Text text51 = new Text();
            text51.Text = "Selected Value";

            run51.Append(runProperties51);
            run51.Append(text51);

            paragraph56.Append(paragraphProperties56);
            paragraph56.Append(run51);

            tableCell50.Append(tableCellProperties50);
            tableCell50.Append(paragraph56);

            tableRow7.Append(tablePropertyExceptions7);
            tableRow7.Append(tableCell49);
            tableRow7.Append(tableCell50);

            TableRow tableRow8 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions8 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault11 = new TableCellMarginDefault();
            TopMargin topMargin58 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin58 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault11.Append(topMargin58);
            tableCellMarginDefault11.Append(bottomMargin58);

            tablePropertyExceptions8.Append(tableCellMarginDefault11);

            TableCell tableCell51 = new TableCell();

            TableCellProperties tableCellProperties51 = new TableCellProperties();
            TableCellWidth tableCellWidth51 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders51 = new TableCellBorders();
            TopBorder topBorder51 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder51 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder51 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder51 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders51.Append(topBorder51);
            tableCellBorders51.Append(leftBorder51);
            tableCellBorders51.Append(bottomBorder51);
            tableCellBorders51.Append(rightBorder51);
            Shading shading51 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin51 = new TableCellMargin();
            TopMargin topMargin59 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin51 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin59 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin51 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin51.Append(topMargin59);
            tableCellMargin51.Append(leftMargin51);
            tableCellMargin51.Append(bottomMargin59);
            tableCellMargin51.Append(rightMargin51);

            tableCellProperties51.Append(tableCellWidth51);
            tableCellProperties51.Append(tableCellBorders51);
            tableCellProperties51.Append(shading51);
            tableCellProperties51.Append(tableCellMargin51);

            Paragraph paragraph57 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties57 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId57 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification25 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties57 = new ParagraphMarkRunProperties();
            RunFonts runFonts108 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize108 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties57.Append(runFonts108);
            paragraphMarkRunProperties57.Append(fontSize108);

            paragraphProperties57.Append(paragraphStyleId57);
            paragraphProperties57.Append(justification25);
            paragraphProperties57.Append(paragraphMarkRunProperties57);

            Run run52 = new Run();

            RunProperties runProperties52 = new RunProperties();
            RunFonts runFonts109 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize109 = new FontSize() { Val = "24" };

            runProperties52.Append(runFonts109);
            runProperties52.Append(fontSize109);
            Text text52 = new Text();
            text52.Text = "Contact By Email";

            run52.Append(runProperties52);
            run52.Append(text52);

            paragraph57.Append(paragraphProperties57);
            paragraph57.Append(run52);

            tableCell51.Append(tableCellProperties51);
            tableCell51.Append(paragraph57);

            TableCell tableCell52 = new TableCell();

            TableCellProperties tableCellProperties52 = new TableCellProperties();
            TableCellWidth tableCellWidth52 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders52 = new TableCellBorders();
            TopBorder topBorder52 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder52 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder52 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder52 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders52.Append(topBorder52);
            tableCellBorders52.Append(leftBorder52);
            tableCellBorders52.Append(bottomBorder52);
            tableCellBorders52.Append(rightBorder52);
            Shading shading52 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin52 = new TableCellMargin();
            TopMargin topMargin60 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin52 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin60 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin52 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin52.Append(topMargin60);
            tableCellMargin52.Append(leftMargin52);
            tableCellMargin52.Append(bottomMargin60);
            tableCellMargin52.Append(rightMargin52);

            tableCellProperties52.Append(tableCellWidth52);
            tableCellProperties52.Append(tableCellBorders52);
            tableCellProperties52.Append(shading52);
            tableCellProperties52.Append(tableCellMargin52);

            Paragraph paragraph58 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties58 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId58 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification26 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties58 = new ParagraphMarkRunProperties();
            RunFonts runFonts110 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize110 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties58.Append(runFonts110);
            paragraphMarkRunProperties58.Append(fontSize110);

            paragraphProperties58.Append(paragraphStyleId58);
            paragraphProperties58.Append(justification26);
            paragraphProperties58.Append(paragraphMarkRunProperties58);

            Run run53 = new Run();

            RunProperties runProperties53 = new RunProperties();
            RunFonts runFonts111 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize111 = new FontSize() { Val = "24" };

            runProperties53.Append(runFonts111);
            runProperties53.Append(fontSize111);
            Text text53 = new Text();
            text53.Text = "stephanie.james@live.co.uk";

            run53.Append(runProperties53);
            run53.Append(text53);

            paragraph58.Append(paragraphProperties58);
            paragraph58.Append(run53);

            tableCell52.Append(tableCellProperties52);
            tableCell52.Append(paragraph58);

            tableRow8.Append(tablePropertyExceptions8);
            tableRow8.Append(tableCell51);
            tableRow8.Append(tableCell52);

            TableRow tableRow9 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions9 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault12 = new TableCellMarginDefault();
            TopMargin topMargin61 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin61 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault12.Append(topMargin61);
            tableCellMarginDefault12.Append(bottomMargin61);

            tablePropertyExceptions9.Append(tableCellMarginDefault12);

            TableCell tableCell53 = new TableCell();

            TableCellProperties tableCellProperties53 = new TableCellProperties();
            TableCellWidth tableCellWidth53 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders53 = new TableCellBorders();
            TopBorder topBorder53 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder53 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder53 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder53 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders53.Append(topBorder53);
            tableCellBorders53.Append(leftBorder53);
            tableCellBorders53.Append(bottomBorder53);
            tableCellBorders53.Append(rightBorder53);
            Shading shading53 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin53 = new TableCellMargin();
            TopMargin topMargin62 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin53 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin62 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin53 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin53.Append(topMargin62);
            tableCellMargin53.Append(leftMargin53);
            tableCellMargin53.Append(bottomMargin62);
            tableCellMargin53.Append(rightMargin53);

            tableCellProperties53.Append(tableCellWidth53);
            tableCellProperties53.Append(tableCellBorders53);
            tableCellProperties53.Append(shading53);
            tableCellProperties53.Append(tableCellMargin53);

            Paragraph paragraph59 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties59 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId59 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification27 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties59 = new ParagraphMarkRunProperties();
            RunFonts runFonts112 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize112 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties59.Append(runFonts112);
            paragraphMarkRunProperties59.Append(fontSize112);

            paragraphProperties59.Append(paragraphStyleId59);
            paragraphProperties59.Append(justification27);
            paragraphProperties59.Append(paragraphMarkRunProperties59);

            Run run54 = new Run();

            RunProperties runProperties54 = new RunProperties();
            RunFonts runFonts113 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize113 = new FontSize() { Val = "24" };

            runProperties54.Append(runFonts113);
            runProperties54.Append(fontSize113);
            Text text54 = new Text();
            text54.Text = "Contact By Text";

            run54.Append(runProperties54);
            run54.Append(text54);

            paragraph59.Append(paragraphProperties59);
            paragraph59.Append(run54);

            tableCell53.Append(tableCellProperties53);
            tableCell53.Append(paragraph59);

            TableCell tableCell54 = new TableCell();

            TableCellProperties tableCellProperties54 = new TableCellProperties();
            TableCellWidth tableCellWidth54 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders54 = new TableCellBorders();
            TopBorder topBorder54 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder54 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder54 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder54 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders54.Append(topBorder54);
            tableCellBorders54.Append(leftBorder54);
            tableCellBorders54.Append(bottomBorder54);
            tableCellBorders54.Append(rightBorder54);
            Shading shading54 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin54 = new TableCellMargin();
            TopMargin topMargin63 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin54 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin63 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin54 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin54.Append(topMargin63);
            tableCellMargin54.Append(leftMargin54);
            tableCellMargin54.Append(bottomMargin63);
            tableCellMargin54.Append(rightMargin54);

            tableCellProperties54.Append(tableCellWidth54);
            tableCellProperties54.Append(tableCellBorders54);
            tableCellProperties54.Append(shading54);
            tableCellProperties54.Append(tableCellMargin54);

            Paragraph paragraph60 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties60 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId60 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification28 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties60 = new ParagraphMarkRunProperties();
            RunFonts runFonts114 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize114 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties60.Append(runFonts114);
            paragraphMarkRunProperties60.Append(fontSize114);

            paragraphProperties60.Append(paragraphStyleId60);
            paragraphProperties60.Append(justification28);
            paragraphProperties60.Append(paragraphMarkRunProperties60);

            Run run55 = new Run();

            RunProperties runProperties55 = new RunProperties();
            RunFonts runFonts115 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize115 = new FontSize() { Val = "24" };

            runProperties55.Append(runFonts115);
            runProperties55.Append(fontSize115);
            Text text55 = new Text();
            text55.Text = "07908 153772";

            run55.Append(runProperties55);
            run55.Append(text55);

            paragraph60.Append(paragraphProperties60);
            paragraph60.Append(run55);

            tableCell54.Append(tableCellProperties54);
            tableCell54.Append(paragraph60);

            tableRow9.Append(tablePropertyExceptions9);
            tableRow9.Append(tableCell53);
            tableRow9.Append(tableCell54);

            TableRow tableRow10 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions10 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault13 = new TableCellMarginDefault();
            TopMargin topMargin64 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin64 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault13.Append(topMargin64);
            tableCellMarginDefault13.Append(bottomMargin64);

            tablePropertyExceptions10.Append(tableCellMarginDefault13);

            TableCell tableCell55 = new TableCell();

            TableCellProperties tableCellProperties55 = new TableCellProperties();
            TableCellWidth tableCellWidth55 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders55 = new TableCellBorders();
            TopBorder topBorder55 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder55 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder55 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder55 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders55.Append(topBorder55);
            tableCellBorders55.Append(leftBorder55);
            tableCellBorders55.Append(bottomBorder55);
            tableCellBorders55.Append(rightBorder55);
            Shading shading55 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin55 = new TableCellMargin();
            TopMargin topMargin65 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin55 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin65 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin55 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin55.Append(topMargin65);
            tableCellMargin55.Append(leftMargin55);
            tableCellMargin55.Append(bottomMargin65);
            tableCellMargin55.Append(rightMargin55);

            tableCellProperties55.Append(tableCellWidth55);
            tableCellProperties55.Append(tableCellBorders55);
            tableCellProperties55.Append(shading55);
            tableCellProperties55.Append(tableCellMargin55);

            Paragraph paragraph61 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties61 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId61 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification29 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties61 = new ParagraphMarkRunProperties();
            RunFonts runFonts116 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize116 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties61.Append(runFonts116);
            paragraphMarkRunProperties61.Append(fontSize116);

            paragraphProperties61.Append(paragraphStyleId61);
            paragraphProperties61.Append(justification29);
            paragraphProperties61.Append(paragraphMarkRunProperties61);

            Run run56 = new Run();

            RunProperties runProperties56 = new RunProperties();
            RunFonts runFonts117 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize117 = new FontSize() { Val = "24" };

            runProperties56.Append(runFonts117);
            runProperties56.Append(fontSize117);
            Text text56 = new Text();
            text56.Text = "Contact By Phone";

            run56.Append(runProperties56);
            run56.Append(text56);

            paragraph61.Append(paragraphProperties61);
            paragraph61.Append(run56);

            tableCell55.Append(tableCellProperties55);
            tableCell55.Append(paragraph61);

            TableCell tableCell56 = new TableCell();

            TableCellProperties tableCellProperties56 = new TableCellProperties();
            TableCellWidth tableCellWidth56 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders56 = new TableCellBorders();
            TopBorder topBorder56 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder56 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder56 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder56 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders56.Append(topBorder56);
            tableCellBorders56.Append(leftBorder56);
            tableCellBorders56.Append(bottomBorder56);
            tableCellBorders56.Append(rightBorder56);
            Shading shading56 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin56 = new TableCellMargin();
            TopMargin topMargin66 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin56 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin66 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin56 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin56.Append(topMargin66);
            tableCellMargin56.Append(leftMargin56);
            tableCellMargin56.Append(bottomMargin66);
            tableCellMargin56.Append(rightMargin56);

            tableCellProperties56.Append(tableCellWidth56);
            tableCellProperties56.Append(tableCellBorders56);
            tableCellProperties56.Append(shading56);
            tableCellProperties56.Append(tableCellMargin56);

            Paragraph paragraph62 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties62 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId62 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification30 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties62 = new ParagraphMarkRunProperties();
            RunFonts runFonts118 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize118 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties62.Append(runFonts118);
            paragraphMarkRunProperties62.Append(fontSize118);

            paragraphProperties62.Append(paragraphStyleId62);
            paragraphProperties62.Append(justification30);
            paragraphProperties62.Append(paragraphMarkRunProperties62);

            Run run57 = new Run();

            RunProperties runProperties57 = new RunProperties();
            RunFonts runFonts119 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize119 = new FontSize() { Val = "24" };

            runProperties57.Append(runFonts119);
            runProperties57.Append(fontSize119);
            Text text57 = new Text();
            text57.Text = "07908 153772";

            run57.Append(runProperties57);
            run57.Append(text57);

            paragraph62.Append(paragraphProperties62);
            paragraph62.Append(run57);

            tableCell56.Append(tableCellProperties56);
            tableCell56.Append(paragraph62);

            tableRow10.Append(tablePropertyExceptions10);
            tableRow10.Append(tableCell55);
            tableRow10.Append(tableCell56);

            table3.Append(tableProperties3);
            table3.Append(tableGrid3);
            table3.Append(tableRow7);
            table3.Append(tableRow8);
            table3.Append(tableRow9);
            table3.Append(tableRow10);

            Paragraph paragraph63 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties63 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId63 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties63 = new ParagraphMarkRunProperties();
            RunFonts runFonts120 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize120 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties63.Append(runFonts120);
            paragraphMarkRunProperties63.Append(fontSize120);

            paragraphProperties63.Append(paragraphStyleId63);
            paragraphProperties63.Append(paragraphMarkRunProperties63);

            paragraph63.Append(paragraphProperties63);

            Paragraph paragraph64 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties64 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId64 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties64 = new ParagraphMarkRunProperties();
            RunFonts runFonts121 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize121 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties64.Append(runFonts121);
            paragraphMarkRunProperties64.Append(fontSize121);

            paragraphProperties64.Append(paragraphStyleId64);
            paragraphProperties64.Append(paragraphMarkRunProperties64);

            Run run58 = new Run();

            RunProperties runProperties58 = new RunProperties();
            RunFonts runFonts122 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize122 = new FontSize() { Val = "24" };

            runProperties58.Append(runFonts122);
            runProperties58.Append(fontSize122);
            Text text58 = new Text();
            text58.Text = "Customer Circumstances";

            run58.Append(runProperties58);
            run58.Append(text58);

            paragraph64.Append(paragraphProperties64);
            paragraph64.Append(run58);

            Table table4 = new Table();

            TableProperties tableProperties4 = new TableProperties();
            TableWidth tableWidth4 = new TableWidth() { Width = "10000", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout4 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault14 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin4 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin4 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault14.Append(tableCellLeftMargin4);
            tableCellMarginDefault14.Append(tableCellRightMargin4);
            TableLook tableLook4 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties4.Append(tableWidth4);
            tableProperties4.Append(tableLayout4);
            tableProperties4.Append(tableCellMarginDefault14);
            tableProperties4.Append(tableLook4);

            TableGrid tableGrid4 = new TableGrid();
            GridColumn gridColumn18 = new GridColumn() { Width = "4000" };
            GridColumn gridColumn19 = new GridColumn() { Width = "6000" };

            tableGrid4.Append(gridColumn18);
            tableGrid4.Append(gridColumn19);

            TableRow tableRow11 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions11 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault15 = new TableCellMarginDefault();
            TopMargin topMargin67 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin67 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault15.Append(topMargin67);
            tableCellMarginDefault15.Append(bottomMargin67);

            tablePropertyExceptions11.Append(tableCellMarginDefault15);

            TableCell tableCell57 = new TableCell();

            TableCellProperties tableCellProperties57 = new TableCellProperties();
            TableCellWidth tableCellWidth57 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders57 = new TableCellBorders();
            TopBorder topBorder57 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder57 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder57 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder57 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders57.Append(topBorder57);
            tableCellBorders57.Append(leftBorder57);
            tableCellBorders57.Append(bottomBorder57);
            tableCellBorders57.Append(rightBorder57);
            Shading shading57 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin57 = new TableCellMargin();
            TopMargin topMargin68 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin57 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin68 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin57 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin57.Append(topMargin68);
            tableCellMargin57.Append(leftMargin57);
            tableCellMargin57.Append(bottomMargin68);
            tableCellMargin57.Append(rightMargin57);

            tableCellProperties57.Append(tableCellWidth57);
            tableCellProperties57.Append(tableCellBorders57);
            tableCellProperties57.Append(shading57);
            tableCellProperties57.Append(tableCellMargin57);

            Paragraph paragraph65 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties65 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId65 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification31 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties65 = new ParagraphMarkRunProperties();
            RunFonts runFonts123 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold36 = new Bold();
            FontSize fontSize123 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties65.Append(runFonts123);
            paragraphMarkRunProperties65.Append(bold36);
            paragraphMarkRunProperties65.Append(fontSize123);

            paragraphProperties65.Append(paragraphStyleId65);
            paragraphProperties65.Append(justification31);
            paragraphProperties65.Append(paragraphMarkRunProperties65);

            Run run59 = new Run();

            RunProperties runProperties59 = new RunProperties();
            RunFonts runFonts124 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold37 = new Bold();
            FontSize fontSize124 = new FontSize() { Val = "24" };

            runProperties59.Append(runFonts124);
            runProperties59.Append(bold37);
            runProperties59.Append(fontSize124);
            Text text59 = new Text();
            text59.Text = "Item";

            run59.Append(runProperties59);
            run59.Append(text59);

            paragraph65.Append(paragraphProperties65);
            paragraph65.Append(run59);

            tableCell57.Append(tableCellProperties57);
            tableCell57.Append(paragraph65);

            TableCell tableCell58 = new TableCell();

            TableCellProperties tableCellProperties58 = new TableCellProperties();
            TableCellWidth tableCellWidth58 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders58 = new TableCellBorders();
            TopBorder topBorder58 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder58 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder58 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder58 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders58.Append(topBorder58);
            tableCellBorders58.Append(leftBorder58);
            tableCellBorders58.Append(bottomBorder58);
            tableCellBorders58.Append(rightBorder58);
            Shading shading58 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin58 = new TableCellMargin();
            TopMargin topMargin69 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin58 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin69 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin58 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin58.Append(topMargin69);
            tableCellMargin58.Append(leftMargin58);
            tableCellMargin58.Append(bottomMargin69);
            tableCellMargin58.Append(rightMargin58);

            tableCellProperties58.Append(tableCellWidth58);
            tableCellProperties58.Append(tableCellBorders58);
            tableCellProperties58.Append(shading58);
            tableCellProperties58.Append(tableCellMargin58);

            Paragraph paragraph66 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties66 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId66 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification32 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties66 = new ParagraphMarkRunProperties();
            RunFonts runFonts125 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold38 = new Bold();
            FontSize fontSize125 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties66.Append(runFonts125);
            paragraphMarkRunProperties66.Append(bold38);
            paragraphMarkRunProperties66.Append(fontSize125);

            paragraphProperties66.Append(paragraphStyleId66);
            paragraphProperties66.Append(justification32);
            paragraphProperties66.Append(paragraphMarkRunProperties66);

            Run run60 = new Run();

            RunProperties runProperties60 = new RunProperties();
            RunFonts runFonts126 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold39 = new Bold();
            FontSize fontSize126 = new FontSize() { Val = "24" };

            runProperties60.Append(runFonts126);
            runProperties60.Append(bold39);
            runProperties60.Append(fontSize126);
            Text text60 = new Text();
            text60.Text = "Selected value";

            run60.Append(runProperties60);
            run60.Append(text60);

            paragraph66.Append(paragraphProperties66);
            paragraph66.Append(run60);

            tableCell58.Append(tableCellProperties58);
            tableCell58.Append(paragraph66);

            tableRow11.Append(tablePropertyExceptions11);
            tableRow11.Append(tableCell57);
            tableRow11.Append(tableCell58);

            TableRow tableRow12 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions12 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault16 = new TableCellMarginDefault();
            TopMargin topMargin70 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin70 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault16.Append(topMargin70);
            tableCellMarginDefault16.Append(bottomMargin70);

            tablePropertyExceptions12.Append(tableCellMarginDefault16);

            TableCell tableCell59 = new TableCell();

            TableCellProperties tableCellProperties59 = new TableCellProperties();
            TableCellWidth tableCellWidth59 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders59 = new TableCellBorders();
            TopBorder topBorder59 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder59 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder59 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder59 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders59.Append(topBorder59);
            tableCellBorders59.Append(leftBorder59);
            tableCellBorders59.Append(bottomBorder59);
            tableCellBorders59.Append(rightBorder59);
            Shading shading59 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin59 = new TableCellMargin();
            TopMargin topMargin71 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin59 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin71 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin59 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin59.Append(topMargin71);
            tableCellMargin59.Append(leftMargin59);
            tableCellMargin59.Append(bottomMargin71);
            tableCellMargin59.Append(rightMargin59);

            tableCellProperties59.Append(tableCellWidth59);
            tableCellProperties59.Append(tableCellBorders59);
            tableCellProperties59.Append(shading59);
            tableCellProperties59.Append(tableCellMargin59);

            Paragraph paragraph67 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties67 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId67 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification33 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties67 = new ParagraphMarkRunProperties();
            RunFonts runFonts127 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize127 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties67.Append(runFonts127);
            paragraphMarkRunProperties67.Append(fontSize127);

            paragraphProperties67.Append(paragraphStyleId67);
            paragraphProperties67.Append(justification33);
            paragraphProperties67.Append(paragraphMarkRunProperties67);

            Run run61 = new Run();

            RunProperties runProperties61 = new RunProperties();
            RunFonts runFonts128 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize128 = new FontSize() { Val = "24" };

            runProperties61.Append(runFonts128);
            runProperties61.Append(fontSize128);
            Text text61 = new Text();
            text61.Text = "Residency Type";

            run61.Append(runProperties61);
            run61.Append(text61);

            paragraph67.Append(paragraphProperties67);
            paragraph67.Append(run61);

            tableCell59.Append(tableCellProperties59);
            tableCell59.Append(paragraph67);

            TableCell tableCell60 = new TableCell();

            TableCellProperties tableCellProperties60 = new TableCellProperties();
            TableCellWidth tableCellWidth60 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders60 = new TableCellBorders();
            TopBorder topBorder60 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder60 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder60 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder60 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders60.Append(topBorder60);
            tableCellBorders60.Append(leftBorder60);
            tableCellBorders60.Append(bottomBorder60);
            tableCellBorders60.Append(rightBorder60);
            Shading shading60 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin60 = new TableCellMargin();
            TopMargin topMargin72 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin60 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin72 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin60 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin60.Append(topMargin72);
            tableCellMargin60.Append(leftMargin60);
            tableCellMargin60.Append(bottomMargin72);
            tableCellMargin60.Append(rightMargin60);

            tableCellProperties60.Append(tableCellWidth60);
            tableCellProperties60.Append(tableCellBorders60);
            tableCellProperties60.Append(shading60);
            tableCellProperties60.Append(tableCellMargin60);

            Paragraph paragraph68 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties68 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId68 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification34 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties68 = new ParagraphMarkRunProperties();
            RunFonts runFonts129 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize129 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties68.Append(runFonts129);
            paragraphMarkRunProperties68.Append(fontSize129);

            paragraphProperties68.Append(paragraphStyleId68);
            paragraphProperties68.Append(justification34);
            paragraphProperties68.Append(paragraphMarkRunProperties68);

            Run run62 = new Run();

            RunProperties runProperties62 = new RunProperties();
            RunFonts runFonts130 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize130 = new FontSize() { Val = "24" };

            runProperties62.Append(runFonts130);
            runProperties62.Append(fontSize130);
            Text text62 = new Text();
            text62.Text = "Own";

            run62.Append(runProperties62);
            run62.Append(text62);

            paragraph68.Append(paragraphProperties68);
            paragraph68.Append(run62);

            tableCell60.Append(tableCellProperties60);
            tableCell60.Append(paragraph68);

            tableRow12.Append(tablePropertyExceptions12);
            tableRow12.Append(tableCell59);
            tableRow12.Append(tableCell60);

            TableRow tableRow13 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions13 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault17 = new TableCellMarginDefault();
            TopMargin topMargin73 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin73 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault17.Append(topMargin73);
            tableCellMarginDefault17.Append(bottomMargin73);

            tablePropertyExceptions13.Append(tableCellMarginDefault17);

            TableCell tableCell61 = new TableCell();

            TableCellProperties tableCellProperties61 = new TableCellProperties();
            TableCellWidth tableCellWidth61 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders61 = new TableCellBorders();
            TopBorder topBorder61 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder61 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder61 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder61 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders61.Append(topBorder61);
            tableCellBorders61.Append(leftBorder61);
            tableCellBorders61.Append(bottomBorder61);
            tableCellBorders61.Append(rightBorder61);
            Shading shading61 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin61 = new TableCellMargin();
            TopMargin topMargin74 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin61 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin74 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin61 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin61.Append(topMargin74);
            tableCellMargin61.Append(leftMargin61);
            tableCellMargin61.Append(bottomMargin74);
            tableCellMargin61.Append(rightMargin61);

            tableCellProperties61.Append(tableCellWidth61);
            tableCellProperties61.Append(tableCellBorders61);
            tableCellProperties61.Append(shading61);
            tableCellProperties61.Append(tableCellMargin61);

            Paragraph paragraph69 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties69 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId69 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification35 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties69 = new ParagraphMarkRunProperties();
            RunFonts runFonts131 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize131 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties69.Append(runFonts131);
            paragraphMarkRunProperties69.Append(fontSize131);

            paragraphProperties69.Append(paragraphStyleId69);
            paragraphProperties69.Append(justification35);
            paragraphProperties69.Append(paragraphMarkRunProperties69);

            Run run63 = new Run();

            RunProperties runProperties63 = new RunProperties();
            RunFonts runFonts132 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize132 = new FontSize() { Val = "24" };

            runProperties63.Append(runFonts132);
            runProperties63.Append(fontSize132);
            Text text63 = new Text();
            text63.Text = "Current Address";

            run63.Append(runProperties63);
            run63.Append(text63);

            paragraph69.Append(paragraphProperties69);
            paragraph69.Append(run63);

            tableCell61.Append(tableCellProperties61);
            tableCell61.Append(paragraph69);

            TableCell tableCell62 = new TableCell();

            TableCellProperties tableCellProperties62 = new TableCellProperties();
            TableCellWidth tableCellWidth62 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders62 = new TableCellBorders();
            TopBorder topBorder62 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder62 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder62 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder62 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders62.Append(topBorder62);
            tableCellBorders62.Append(leftBorder62);
            tableCellBorders62.Append(bottomBorder62);
            tableCellBorders62.Append(rightBorder62);
            Shading shading62 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin62 = new TableCellMargin();
            TopMargin topMargin75 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin62 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin75 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin62 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin62.Append(topMargin75);
            tableCellMargin62.Append(leftMargin62);
            tableCellMargin62.Append(bottomMargin75);
            tableCellMargin62.Append(rightMargin62);

            tableCellProperties62.Append(tableCellWidth62);
            tableCellProperties62.Append(tableCellBorders62);
            tableCellProperties62.Append(shading62);
            tableCellProperties62.Append(tableCellMargin62);

            Paragraph paragraph70 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties70 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId70 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification36 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties70 = new ParagraphMarkRunProperties();
            RunFonts runFonts133 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize133 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties70.Append(runFonts133);
            paragraphMarkRunProperties70.Append(fontSize133);

            paragraphProperties70.Append(paragraphStyleId70);
            paragraphProperties70.Append(justification36);
            paragraphProperties70.Append(paragraphMarkRunProperties70);

            Run run64 = new Run();

            RunProperties runProperties64 = new RunProperties();
            RunFonts runFonts134 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize134 = new FontSize() { Val = "24" };

            runProperties64.Append(runFonts134);
            runProperties64.Append(fontSize134);
            Text text64 = new Text();
            text64.Text = "10 Fiddlers Mill";

            run64.Append(runProperties64);
            run64.Append(text64);

            paragraph70.Append(paragraphProperties70);
            paragraph70.Append(run64);

            Paragraph paragraph71 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties71 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId71 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification37 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties71 = new ParagraphMarkRunProperties();
            RunFonts runFonts135 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize135 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties71.Append(runFonts135);
            paragraphMarkRunProperties71.Append(fontSize135);

            paragraphProperties71.Append(paragraphStyleId71);
            paragraphProperties71.Append(justification37);
            paragraphProperties71.Append(paragraphMarkRunProperties71);

            Run run65 = new Run();

            RunProperties runProperties65 = new RunProperties();
            RunFonts runFonts136 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize136 = new FontSize() { Val = "24" };

            runProperties65.Append(runFonts136);
            runProperties65.Append(fontSize136);
            LastRenderedPageBreak lastRenderedPageBreak1 = new LastRenderedPageBreak();
            Text text65 = new Text();
            text65.Text = "Crossflatts";

            run65.Append(runProperties65);
            run65.Append(lastRenderedPageBreak1);
            run65.Append(text65);

            paragraph71.Append(paragraphProperties71);
            paragraph71.Append(run65);

            Paragraph paragraph72 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties72 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId72 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification38 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties72 = new ParagraphMarkRunProperties();
            RunFonts runFonts137 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize137 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties72.Append(runFonts137);
            paragraphMarkRunProperties72.Append(fontSize137);

            paragraphProperties72.Append(paragraphStyleId72);
            paragraphProperties72.Append(justification38);
            paragraphProperties72.Append(paragraphMarkRunProperties72);

            Run run66 = new Run();

            RunProperties runProperties66 = new RunProperties();
            RunFonts runFonts138 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize138 = new FontSize() { Val = "24" };

            runProperties66.Append(runFonts138);
            runProperties66.Append(fontSize138);
            Text text66 = new Text();
            text66.Text = "Bingley";

            run66.Append(runProperties66);
            run66.Append(text66);

            paragraph72.Append(paragraphProperties72);
            paragraph72.Append(run66);

            Paragraph paragraph73 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties73 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId73 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification39 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties73 = new ParagraphMarkRunProperties();
            RunFonts runFonts139 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize139 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties73.Append(runFonts139);
            paragraphMarkRunProperties73.Append(fontSize139);

            paragraphProperties73.Append(paragraphStyleId73);
            paragraphProperties73.Append(justification39);
            paragraphProperties73.Append(paragraphMarkRunProperties73);

            Run run67 = new Run();

            RunProperties runProperties67 = new RunProperties();
            RunFonts runFonts140 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize140 = new FontSize() { Val = "24" };

            runProperties67.Append(runFonts140);
            runProperties67.Append(fontSize140);
            Text text67 = new Text();
            text67.Text = "BD16 2AQ";

            run67.Append(runProperties67);
            run67.Append(text67);

            paragraph73.Append(paragraphProperties73);
            paragraph73.Append(run67);

            Paragraph paragraph74 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties74 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId74 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification40 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties74 = new ParagraphMarkRunProperties();
            RunFonts runFonts141 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize141 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties74.Append(runFonts141);
            paragraphMarkRunProperties74.Append(fontSize141);

            paragraphProperties74.Append(paragraphStyleId74);
            paragraphProperties74.Append(justification40);
            paragraphProperties74.Append(paragraphMarkRunProperties74);

            paragraph74.Append(paragraphProperties74);

            tableCell62.Append(tableCellProperties62);
            tableCell62.Append(paragraph70);
            tableCell62.Append(paragraph71);
            tableCell62.Append(paragraph72);
            tableCell62.Append(paragraph73);
            tableCell62.Append(paragraph74);

            tableRow13.Append(tablePropertyExceptions13);
            tableRow13.Append(tableCell61);
            tableRow13.Append(tableCell62);

            TableRow tableRow14 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions14 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault18 = new TableCellMarginDefault();
            TopMargin topMargin76 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin76 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault18.Append(topMargin76);
            tableCellMarginDefault18.Append(bottomMargin76);

            tablePropertyExceptions14.Append(tableCellMarginDefault18);

            TableCell tableCell63 = new TableCell();

            TableCellProperties tableCellProperties63 = new TableCellProperties();
            TableCellWidth tableCellWidth63 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders63 = new TableCellBorders();
            TopBorder topBorder63 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder63 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder63 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder63 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders63.Append(topBorder63);
            tableCellBorders63.Append(leftBorder63);
            tableCellBorders63.Append(bottomBorder63);
            tableCellBorders63.Append(rightBorder63);
            Shading shading63 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin63 = new TableCellMargin();
            TopMargin topMargin77 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin63 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin77 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin63 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin63.Append(topMargin77);
            tableCellMargin63.Append(leftMargin63);
            tableCellMargin63.Append(bottomMargin77);
            tableCellMargin63.Append(rightMargin63);

            tableCellProperties63.Append(tableCellWidth63);
            tableCellProperties63.Append(tableCellBorders63);
            tableCellProperties63.Append(shading63);
            tableCellProperties63.Append(tableCellMargin63);

            Paragraph paragraph75 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties75 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId75 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification41 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties75 = new ParagraphMarkRunProperties();
            RunFonts runFonts142 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize142 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties75.Append(runFonts142);
            paragraphMarkRunProperties75.Append(fontSize142);

            paragraphProperties75.Append(paragraphStyleId75);
            paragraphProperties75.Append(justification41);
            paragraphProperties75.Append(paragraphMarkRunProperties75);

            Run run68 = new Run();

            RunProperties runProperties68 = new RunProperties();
            RunFonts runFonts143 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize143 = new FontSize() { Val = "24" };

            runProperties68.Append(runFonts143);
            runProperties68.Append(fontSize143);
            LastRenderedPageBreak lastRenderedPageBreak2 = new LastRenderedPageBreak();
            Text text68 = new Text();
            text68.Text = "Duration";

            run68.Append(runProperties68);
            run68.Append(lastRenderedPageBreak2);
            run68.Append(text68);

            paragraph75.Append(paragraphProperties75);
            paragraph75.Append(run68);

            tableCell63.Append(tableCellProperties63);
            tableCell63.Append(paragraph75);

            TableCell tableCell64 = new TableCell();

            TableCellProperties tableCellProperties64 = new TableCellProperties();
            TableCellWidth tableCellWidth64 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders64 = new TableCellBorders();
            TopBorder topBorder64 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder64 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder64 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder64 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders64.Append(topBorder64);
            tableCellBorders64.Append(leftBorder64);
            tableCellBorders64.Append(bottomBorder64);
            tableCellBorders64.Append(rightBorder64);
            Shading shading64 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin64 = new TableCellMargin();
            TopMargin topMargin78 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin64 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin78 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin64 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin64.Append(topMargin78);
            tableCellMargin64.Append(leftMargin64);
            tableCellMargin64.Append(bottomMargin78);
            tableCellMargin64.Append(rightMargin64);

            tableCellProperties64.Append(tableCellWidth64);
            tableCellProperties64.Append(tableCellBorders64);
            tableCellProperties64.Append(shading64);
            tableCellProperties64.Append(tableCellMargin64);

            Paragraph paragraph76 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties76 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId76 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification42 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties76 = new ParagraphMarkRunProperties();
            RunFonts runFonts144 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize144 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties76.Append(runFonts144);
            paragraphMarkRunProperties76.Append(fontSize144);

            paragraphProperties76.Append(paragraphStyleId76);
            paragraphProperties76.Append(justification42);
            paragraphProperties76.Append(paragraphMarkRunProperties76);

            Run run69 = new Run();

            RunProperties runProperties69 = new RunProperties();
            RunFonts runFonts145 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize145 = new FontSize() { Val = "24" };

            runProperties69.Append(runFonts145);
            runProperties69.Append(fontSize145);
            Text text69 = new Text();
            text69.Text = "Has lived at address for 13 years, 0 months and 0 days.";

            run69.Append(runProperties69);
            run69.Append(text69);

            paragraph76.Append(paragraphProperties76);
            paragraph76.Append(run69);

            tableCell64.Append(tableCellProperties64);
            tableCell64.Append(paragraph76);

            tableRow14.Append(tablePropertyExceptions14);
            tableRow14.Append(tableCell63);
            tableRow14.Append(tableCell64);

            TableRow tableRow15 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions15 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault19 = new TableCellMarginDefault();
            TopMargin topMargin79 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin79 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault19.Append(topMargin79);
            tableCellMarginDefault19.Append(bottomMargin79);

            tablePropertyExceptions15.Append(tableCellMarginDefault19);

            TableCell tableCell65 = new TableCell();

            TableCellProperties tableCellProperties65 = new TableCellProperties();
            TableCellWidth tableCellWidth65 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders65 = new TableCellBorders();
            TopBorder topBorder65 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder65 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder65 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder65 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders65.Append(topBorder65);
            tableCellBorders65.Append(leftBorder65);
            tableCellBorders65.Append(bottomBorder65);
            tableCellBorders65.Append(rightBorder65);
            Shading shading65 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin65 = new TableCellMargin();
            TopMargin topMargin80 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin65 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin80 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin65 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin65.Append(topMargin80);
            tableCellMargin65.Append(leftMargin65);
            tableCellMargin65.Append(bottomMargin80);
            tableCellMargin65.Append(rightMargin65);

            tableCellProperties65.Append(tableCellWidth65);
            tableCellProperties65.Append(tableCellBorders65);
            tableCellProperties65.Append(shading65);
            tableCellProperties65.Append(tableCellMargin65);

            Paragraph paragraph77 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties77 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId77 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification43 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties77 = new ParagraphMarkRunProperties();
            RunFonts runFonts146 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize146 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties77.Append(runFonts146);
            paragraphMarkRunProperties77.Append(fontSize146);

            paragraphProperties77.Append(paragraphStyleId77);
            paragraphProperties77.Append(justification43);
            paragraphProperties77.Append(paragraphMarkRunProperties77);

            Run run70 = new Run();

            RunProperties runProperties70 = new RunProperties();
            RunFonts runFonts147 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize147 = new FontSize() { Val = "24" };

            runProperties70.Append(runFonts147);
            runProperties70.Append(fontSize147);
            Text text70 = new Text();
            text70.Text = "Reason for Moving";

            run70.Append(runProperties70);
            run70.Append(text70);

            paragraph77.Append(paragraphProperties77);
            paragraph77.Append(run70);

            tableCell65.Append(tableCellProperties65);
            tableCell65.Append(paragraph77);

            TableCell tableCell66 = new TableCell();

            TableCellProperties tableCellProperties66 = new TableCellProperties();
            TableCellWidth tableCellWidth66 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders66 = new TableCellBorders();
            TopBorder topBorder66 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder66 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder66 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder66 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders66.Append(topBorder66);
            tableCellBorders66.Append(leftBorder66);
            tableCellBorders66.Append(bottomBorder66);
            tableCellBorders66.Append(rightBorder66);
            Shading shading66 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin66 = new TableCellMargin();
            TopMargin topMargin81 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin66 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin81 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin66 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin66.Append(topMargin81);
            tableCellMargin66.Append(leftMargin66);
            tableCellMargin66.Append(bottomMargin81);
            tableCellMargin66.Append(rightMargin66);

            tableCellProperties66.Append(tableCellWidth66);
            tableCellProperties66.Append(tableCellBorders66);
            tableCellProperties66.Append(shading66);
            tableCellProperties66.Append(tableCellMargin66);

            Paragraph paragraph78 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties78 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId78 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification44 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties78 = new ParagraphMarkRunProperties();
            RunFonts runFonts148 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize148 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties78.Append(runFonts148);
            paragraphMarkRunProperties78.Append(fontSize148);

            paragraphProperties78.Append(paragraphStyleId78);
            paragraphProperties78.Append(justification44);
            paragraphProperties78.Append(paragraphMarkRunProperties78);

            Run run71 = new Run();

            RunProperties runProperties71 = new RunProperties();
            RunFonts runFonts149 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize149 = new FontSize() { Val = "24" };

            runProperties71.Append(runFonts149);
            runProperties71.Append(fontSize149);
            Text text71 = new Text();
            text71.Text = "Independent Living (inc. Care Leavers)";

            run71.Append(runProperties71);
            run71.Append(text71);

            paragraph78.Append(paragraphProperties78);
            paragraph78.Append(run71);

            tableCell66.Append(tableCellProperties66);
            tableCell66.Append(paragraph78);

            tableRow15.Append(tablePropertyExceptions15);
            tableRow15.Append(tableCell65);
            tableRow15.Append(tableCell66);

            table4.Append(tableProperties4);
            table4.Append(tableGrid4);
            table4.Append(tableRow11);
            table4.Append(tableRow12);
            table4.Append(tableRow13);
            table4.Append(tableRow14);
            table4.Append(tableRow15);

            Paragraph paragraph79 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties79 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId79 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties79 = new ParagraphMarkRunProperties();
            RunFonts runFonts150 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize150 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties79.Append(runFonts150);
            paragraphMarkRunProperties79.Append(fontSize150);

            paragraphProperties79.Append(paragraphStyleId79);
            paragraphProperties79.Append(paragraphMarkRunProperties79);

            paragraph79.Append(paragraphProperties79);

            Paragraph paragraph80 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties80 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId80 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties80 = new ParagraphMarkRunProperties();
            RunFonts runFonts151 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize151 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties80.Append(runFonts151);
            paragraphMarkRunProperties80.Append(fontSize151);

            paragraphProperties80.Append(paragraphStyleId80);
            paragraphProperties80.Append(paragraphMarkRunProperties80);

            Run run72 = new Run();

            RunProperties runProperties72 = new RunProperties();
            RunFonts runFonts152 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize152 = new FontSize() { Val = "24" };

            runProperties72.Append(runFonts152);
            runProperties72.Append(fontSize152);
            Text text72 = new Text();
            text72.Text = "Income Details";

            run72.Append(runProperties72);
            run72.Append(text72);

            paragraph80.Append(paragraphProperties80);
            paragraph80.Append(run72);

            Table table5 = new Table();

            TableProperties tableProperties5 = new TableProperties();
            TableWidth tableWidth5 = new TableWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout5 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault20 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin5 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin5 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault20.Append(tableCellLeftMargin5);
            tableCellMarginDefault20.Append(tableCellRightMargin5);
            TableLook tableLook5 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties5.Append(tableWidth5);
            tableProperties5.Append(tableLayout5);
            tableProperties5.Append(tableCellMarginDefault20);
            tableProperties5.Append(tableLook5);

            TableGrid tableGrid5 = new TableGrid();
            GridColumn gridColumn20 = new GridColumn() { Width = "3000" };
            GridColumn gridColumn21 = new GridColumn() { Width = "3000" };

            tableGrid5.Append(gridColumn20);
            tableGrid5.Append(gridColumn21);

            TableRow tableRow16 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions16 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault21 = new TableCellMarginDefault();
            TopMargin topMargin82 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin82 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault21.Append(topMargin82);
            tableCellMarginDefault21.Append(bottomMargin82);

            tablePropertyExceptions16.Append(tableCellMarginDefault21);

            TableCell tableCell67 = new TableCell();

            TableCellProperties tableCellProperties67 = new TableCellProperties();
            TableCellWidth tableCellWidth67 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders67 = new TableCellBorders();
            TopBorder topBorder67 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder67 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder67 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder67 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders67.Append(topBorder67);
            tableCellBorders67.Append(leftBorder67);
            tableCellBorders67.Append(bottomBorder67);
            tableCellBorders67.Append(rightBorder67);
            Shading shading67 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin67 = new TableCellMargin();
            TopMargin topMargin83 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin67 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin83 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin67 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin67.Append(topMargin83);
            tableCellMargin67.Append(leftMargin67);
            tableCellMargin67.Append(bottomMargin83);
            tableCellMargin67.Append(rightMargin67);

            tableCellProperties67.Append(tableCellWidth67);
            tableCellProperties67.Append(tableCellBorders67);
            tableCellProperties67.Append(shading67);
            tableCellProperties67.Append(tableCellMargin67);

            Paragraph paragraph81 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties81 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId81 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification45 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties81 = new ParagraphMarkRunProperties();
            RunFonts runFonts153 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold40 = new Bold();
            FontSize fontSize153 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties81.Append(runFonts153);
            paragraphMarkRunProperties81.Append(bold40);
            paragraphMarkRunProperties81.Append(fontSize153);

            paragraphProperties81.Append(paragraphStyleId81);
            paragraphProperties81.Append(justification45);
            paragraphProperties81.Append(paragraphMarkRunProperties81);

            Run run73 = new Run();

            RunProperties runProperties73 = new RunProperties();
            RunFonts runFonts154 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold41 = new Bold();
            FontSize fontSize154 = new FontSize() { Val = "24" };

            runProperties73.Append(runFonts154);
            runProperties73.Append(bold41);
            runProperties73.Append(fontSize154);
            Text text73 = new Text();
            text73.Text = "Item";

            run73.Append(runProperties73);
            run73.Append(text73);

            paragraph81.Append(paragraphProperties81);
            paragraph81.Append(run73);

            tableCell67.Append(tableCellProperties67);
            tableCell67.Append(paragraph81);

            TableCell tableCell68 = new TableCell();

            TableCellProperties tableCellProperties68 = new TableCellProperties();
            TableCellWidth tableCellWidth68 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders68 = new TableCellBorders();
            TopBorder topBorder68 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder68 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder68 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder68 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders68.Append(topBorder68);
            tableCellBorders68.Append(leftBorder68);
            tableCellBorders68.Append(bottomBorder68);
            tableCellBorders68.Append(rightBorder68);
            Shading shading68 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin68 = new TableCellMargin();
            TopMargin topMargin84 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin68 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin84 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin68 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin68.Append(topMargin84);
            tableCellMargin68.Append(leftMargin68);
            tableCellMargin68.Append(bottomMargin84);
            tableCellMargin68.Append(rightMargin68);

            tableCellProperties68.Append(tableCellWidth68);
            tableCellProperties68.Append(tableCellBorders68);
            tableCellProperties68.Append(shading68);
            tableCellProperties68.Append(tableCellMargin68);

            Paragraph paragraph82 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties82 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId82 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification46 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties82 = new ParagraphMarkRunProperties();
            RunFonts runFonts155 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold42 = new Bold();
            FontSize fontSize155 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties82.Append(runFonts155);
            paragraphMarkRunProperties82.Append(bold42);
            paragraphMarkRunProperties82.Append(fontSize155);

            paragraphProperties82.Append(paragraphStyleId82);
            paragraphProperties82.Append(justification46);
            paragraphProperties82.Append(paragraphMarkRunProperties82);

            Run run74 = new Run();

            RunProperties runProperties74 = new RunProperties();
            RunFonts runFonts156 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold43 = new Bold();
            FontSize fontSize156 = new FontSize() { Val = "24" };

            runProperties74.Append(runFonts156);
            runProperties74.Append(bold43);
            runProperties74.Append(fontSize156);
            Text text74 = new Text();
            text74.Text = "Selected Value";

            run74.Append(runProperties74);
            run74.Append(text74);

            paragraph82.Append(paragraphProperties82);
            paragraph82.Append(run74);

            tableCell68.Append(tableCellProperties68);
            tableCell68.Append(paragraph82);

            tableRow16.Append(tablePropertyExceptions16);
            tableRow16.Append(tableCell67);
            tableRow16.Append(tableCell68);

            TableRow tableRow17 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions17 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault22 = new TableCellMarginDefault();
            TopMargin topMargin85 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin85 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault22.Append(topMargin85);
            tableCellMarginDefault22.Append(bottomMargin85);

            tablePropertyExceptions17.Append(tableCellMarginDefault22);

            TableCell tableCell69 = new TableCell();

            TableCellProperties tableCellProperties69 = new TableCellProperties();
            TableCellWidth tableCellWidth69 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders69 = new TableCellBorders();
            TopBorder topBorder69 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder69 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder69 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder69 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders69.Append(topBorder69);
            tableCellBorders69.Append(leftBorder69);
            tableCellBorders69.Append(bottomBorder69);
            tableCellBorders69.Append(rightBorder69);
            Shading shading69 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin69 = new TableCellMargin();
            TopMargin topMargin86 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin69 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin86 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin69 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin69.Append(topMargin86);
            tableCellMargin69.Append(leftMargin69);
            tableCellMargin69.Append(bottomMargin86);
            tableCellMargin69.Append(rightMargin69);

            tableCellProperties69.Append(tableCellWidth69);
            tableCellProperties69.Append(tableCellBorders69);
            tableCellProperties69.Append(shading69);
            tableCellProperties69.Append(tableCellMargin69);

            Paragraph paragraph83 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties83 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId83 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification47 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties83 = new ParagraphMarkRunProperties();
            RunFonts runFonts157 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize157 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties83.Append(runFonts157);
            paragraphMarkRunProperties83.Append(fontSize157);

            paragraphProperties83.Append(paragraphStyleId83);
            paragraphProperties83.Append(justification47);
            paragraphProperties83.Append(paragraphMarkRunProperties83);

            Run run75 = new Run();

            RunProperties runProperties75 = new RunProperties();
            RunFonts runFonts158 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize158 = new FontSize() { Val = "24" };

            runProperties75.Append(runFonts158);
            runProperties75.Append(fontSize158);
            Text text75 = new Text();
            text75.Text = "Total Income / Month";

            run75.Append(runProperties75);
            run75.Append(text75);

            paragraph83.Append(paragraphProperties83);
            paragraph83.Append(run75);

            tableCell69.Append(tableCellProperties69);
            tableCell69.Append(paragraph83);

            TableCell tableCell70 = new TableCell();

            TableCellProperties tableCellProperties70 = new TableCellProperties();
            TableCellWidth tableCellWidth70 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders70 = new TableCellBorders();
            TopBorder topBorder70 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder70 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder70 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder70 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders70.Append(topBorder70);
            tableCellBorders70.Append(leftBorder70);
            tableCellBorders70.Append(bottomBorder70);
            tableCellBorders70.Append(rightBorder70);
            Shading shading70 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin70 = new TableCellMargin();
            TopMargin topMargin87 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin70 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin87 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin70 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin70.Append(topMargin87);
            tableCellMargin70.Append(leftMargin70);
            tableCellMargin70.Append(bottomMargin87);
            tableCellMargin70.Append(rightMargin70);

            tableCellProperties70.Append(tableCellWidth70);
            tableCellProperties70.Append(tableCellBorders70);
            tableCellProperties70.Append(shading70);
            tableCellProperties70.Append(tableCellMargin70);

            Paragraph paragraph84 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties84 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId84 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification48 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties84 = new ParagraphMarkRunProperties();
            RunFonts runFonts159 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize159 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties84.Append(runFonts159);
            paragraphMarkRunProperties84.Append(fontSize159);

            paragraphProperties84.Append(paragraphStyleId84);
            paragraphProperties84.Append(justification48);
            paragraphProperties84.Append(paragraphMarkRunProperties84);

            Run run76 = new Run();

            RunProperties runProperties76 = new RunProperties();
            RunFonts runFonts160 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize160 = new FontSize() { Val = "24" };

            runProperties76.Append(runFonts160);
            runProperties76.Append(fontSize160);
            Text text76 = new Text();
            text76.Text = "£2,107.25";

            run76.Append(runProperties76);
            run76.Append(text76);

            paragraph84.Append(paragraphProperties84);
            paragraph84.Append(run76);

            tableCell70.Append(tableCellProperties70);
            tableCell70.Append(paragraph84);

            tableRow17.Append(tablePropertyExceptions17);
            tableRow17.Append(tableCell69);
            tableRow17.Append(tableCell70);

            table5.Append(tableProperties5);
            table5.Append(tableGrid5);
            table5.Append(tableRow16);
            table5.Append(tableRow17);

            Paragraph paragraph85 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties85 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId85 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties85 = new ParagraphMarkRunProperties();
            RunFonts runFonts161 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize161 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties85.Append(runFonts161);
            paragraphMarkRunProperties85.Append(fontSize161);

            paragraphProperties85.Append(paragraphStyleId85);
            paragraphProperties85.Append(paragraphMarkRunProperties85);

            paragraph85.Append(paragraphProperties85);

            Paragraph paragraph86 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties86 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId86 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties86 = new ParagraphMarkRunProperties();
            RunFonts runFonts162 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize162 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties86.Append(runFonts162);
            paragraphMarkRunProperties86.Append(fontSize162);

            paragraphProperties86.Append(paragraphStyleId86);
            paragraphProperties86.Append(paragraphMarkRunProperties86);

            paragraph86.Append(paragraphProperties86);

            Paragraph paragraph87 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties87 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId87 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties87 = new ParagraphMarkRunProperties();
            RunFonts runFonts163 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize163 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties87.Append(runFonts163);
            paragraphMarkRunProperties87.Append(fontSize163);

            paragraphProperties87.Append(paragraphStyleId87);
            paragraphProperties87.Append(paragraphMarkRunProperties87);

            Run run77 = new Run();

            RunProperties runProperties77 = new RunProperties();
            RunFonts runFonts164 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize164 = new FontSize() { Val = "24" };

            runProperties77.Append(runFonts164);
            runProperties77.Append(fontSize164);
            Text text77 = new Text();
            text77.Text = "Mr Aaron Smith";

            run77.Append(runProperties77);
            run77.Append(text77);

            paragraph87.Append(paragraphProperties87);
            paragraph87.Append(run77);

            Table table6 = new Table();

            TableProperties tableProperties6 = new TableProperties();
            TableWidth tableWidth6 = new TableWidth() { Width = "9000", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout6 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault23 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin6 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin6 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault23.Append(tableCellLeftMargin6);
            tableCellMarginDefault23.Append(tableCellRightMargin6);
            TableLook tableLook6 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties6.Append(tableWidth6);
            tableProperties6.Append(tableLayout6);
            tableProperties6.Append(tableCellMarginDefault23);
            tableProperties6.Append(tableLook6);

            TableGrid tableGrid6 = new TableGrid();
            GridColumn gridColumn22 = new GridColumn() { Width = "3000" };
            GridColumn gridColumn23 = new GridColumn() { Width = "3000" };
            GridColumn gridColumn24 = new GridColumn() { Width = "3000" };

            tableGrid6.Append(gridColumn22);
            tableGrid6.Append(gridColumn23);
            tableGrid6.Append(gridColumn24);

            TableRow tableRow18 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions18 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault24 = new TableCellMarginDefault();
            TopMargin topMargin88 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin88 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault24.Append(topMargin88);
            tableCellMarginDefault24.Append(bottomMargin88);

            tablePropertyExceptions18.Append(tableCellMarginDefault24);

            TableCell tableCell71 = new TableCell();

            TableCellProperties tableCellProperties71 = new TableCellProperties();
            TableCellWidth tableCellWidth71 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders71 = new TableCellBorders();
            TopBorder topBorder71 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder71 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder71 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder71 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders71.Append(topBorder71);
            tableCellBorders71.Append(leftBorder71);
            tableCellBorders71.Append(bottomBorder71);
            tableCellBorders71.Append(rightBorder71);
            Shading shading71 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin71 = new TableCellMargin();
            TopMargin topMargin89 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin71 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin89 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin71 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin71.Append(topMargin89);
            tableCellMargin71.Append(leftMargin71);
            tableCellMargin71.Append(bottomMargin89);
            tableCellMargin71.Append(rightMargin71);

            tableCellProperties71.Append(tableCellWidth71);
            tableCellProperties71.Append(tableCellBorders71);
            tableCellProperties71.Append(shading71);
            tableCellProperties71.Append(tableCellMargin71);

            Paragraph paragraph88 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties88 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId88 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification49 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties88 = new ParagraphMarkRunProperties();
            RunFonts runFonts165 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold44 = new Bold();
            FontSize fontSize165 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties88.Append(runFonts165);
            paragraphMarkRunProperties88.Append(bold44);
            paragraphMarkRunProperties88.Append(fontSize165);

            paragraphProperties88.Append(paragraphStyleId88);
            paragraphProperties88.Append(justification49);
            paragraphProperties88.Append(paragraphMarkRunProperties88);

            Run run78 = new Run();

            RunProperties runProperties78 = new RunProperties();
            RunFonts runFonts166 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold45 = new Bold();
            FontSize fontSize166 = new FontSize() { Val = "24" };

            runProperties78.Append(runFonts166);
            runProperties78.Append(bold45);
            runProperties78.Append(fontSize166);
            Text text78 = new Text();
            text78.Text = "Income Source";

            run78.Append(runProperties78);
            run78.Append(text78);

            paragraph88.Append(paragraphProperties88);
            paragraph88.Append(run78);

            tableCell71.Append(tableCellProperties71);
            tableCell71.Append(paragraph88);

            TableCell tableCell72 = new TableCell();

            TableCellProperties tableCellProperties72 = new TableCellProperties();
            TableCellWidth tableCellWidth72 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders72 = new TableCellBorders();
            TopBorder topBorder72 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder72 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder72 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder72 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders72.Append(topBorder72);
            tableCellBorders72.Append(leftBorder72);
            tableCellBorders72.Append(bottomBorder72);
            tableCellBorders72.Append(rightBorder72);
            Shading shading72 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin72 = new TableCellMargin();
            TopMargin topMargin90 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin72 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin90 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin72 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin72.Append(topMargin90);
            tableCellMargin72.Append(leftMargin72);
            tableCellMargin72.Append(bottomMargin90);
            tableCellMargin72.Append(rightMargin72);

            tableCellProperties72.Append(tableCellWidth72);
            tableCellProperties72.Append(tableCellBorders72);
            tableCellProperties72.Append(shading72);
            tableCellProperties72.Append(tableCellMargin72);

            Paragraph paragraph89 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties89 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId89 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification50 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties89 = new ParagraphMarkRunProperties();
            RunFonts runFonts167 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold46 = new Bold();
            FontSize fontSize167 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties89.Append(runFonts167);
            paragraphMarkRunProperties89.Append(bold46);
            paragraphMarkRunProperties89.Append(fontSize167);

            paragraphProperties89.Append(paragraphStyleId89);
            paragraphProperties89.Append(justification50);
            paragraphProperties89.Append(paragraphMarkRunProperties89);

            Run run79 = new Run();

            RunProperties runProperties79 = new RunProperties();
            RunFonts runFonts168 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold47 = new Bold();
            FontSize fontSize168 = new FontSize() { Val = "24" };

            runProperties79.Append(runFonts168);
            runProperties79.Append(bold47);
            runProperties79.Append(fontSize168);
            Text text79 = new Text();
            text79.Text = "Amount";

            run79.Append(runProperties79);
            run79.Append(text79);

            paragraph89.Append(paragraphProperties89);
            paragraph89.Append(run79);

            tableCell72.Append(tableCellProperties72);
            tableCell72.Append(paragraph89);

            TableCell tableCell73 = new TableCell();

            TableCellProperties tableCellProperties73 = new TableCellProperties();
            TableCellWidth tableCellWidth73 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders73 = new TableCellBorders();
            TopBorder topBorder73 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder73 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder73 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder73 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders73.Append(topBorder73);
            tableCellBorders73.Append(leftBorder73);
            tableCellBorders73.Append(bottomBorder73);
            tableCellBorders73.Append(rightBorder73);
            Shading shading73 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin73 = new TableCellMargin();
            TopMargin topMargin91 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin73 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin91 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin73 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin73.Append(topMargin91);
            tableCellMargin73.Append(leftMargin73);
            tableCellMargin73.Append(bottomMargin91);
            tableCellMargin73.Append(rightMargin73);

            tableCellProperties73.Append(tableCellWidth73);
            tableCellProperties73.Append(tableCellBorders73);
            tableCellProperties73.Append(shading73);
            tableCellProperties73.Append(tableCellMargin73);

            Paragraph paragraph90 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties90 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId90 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification51 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties90 = new ParagraphMarkRunProperties();
            RunFonts runFonts169 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold48 = new Bold();
            FontSize fontSize169 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties90.Append(runFonts169);
            paragraphMarkRunProperties90.Append(bold48);
            paragraphMarkRunProperties90.Append(fontSize169);

            paragraphProperties90.Append(paragraphStyleId90);
            paragraphProperties90.Append(justification51);
            paragraphProperties90.Append(paragraphMarkRunProperties90);

            Run run80 = new Run();

            RunProperties runProperties80 = new RunProperties();
            RunFonts runFonts170 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold49 = new Bold();
            FontSize fontSize170 = new FontSize() { Val = "24" };

            runProperties80.Append(runFonts170);
            runProperties80.Append(bold49);
            runProperties80.Append(fontSize170);
            Text text80 = new Text();
            text80.Text = "Frequency";

            run80.Append(runProperties80);
            run80.Append(text80);

            paragraph90.Append(paragraphProperties90);
            paragraph90.Append(run80);

            tableCell73.Append(tableCellProperties73);
            tableCell73.Append(paragraph90);

            tableRow18.Append(tablePropertyExceptions18);
            tableRow18.Append(tableCell71);
            tableRow18.Append(tableCell72);
            tableRow18.Append(tableCell73);

            TableRow tableRow19 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions19 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault25 = new TableCellMarginDefault();
            TopMargin topMargin92 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin92 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault25.Append(topMargin92);
            tableCellMarginDefault25.Append(bottomMargin92);

            tablePropertyExceptions19.Append(tableCellMarginDefault25);

            TableCell tableCell74 = new TableCell();

            TableCellProperties tableCellProperties74 = new TableCellProperties();
            TableCellWidth tableCellWidth74 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders74 = new TableCellBorders();
            TopBorder topBorder74 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder74 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder74 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder74 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders74.Append(topBorder74);
            tableCellBorders74.Append(leftBorder74);
            tableCellBorders74.Append(bottomBorder74);
            tableCellBorders74.Append(rightBorder74);
            Shading shading74 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin74 = new TableCellMargin();
            TopMargin topMargin93 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin74 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin93 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin74 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin74.Append(topMargin93);
            tableCellMargin74.Append(leftMargin74);
            tableCellMargin74.Append(bottomMargin93);
            tableCellMargin74.Append(rightMargin74);

            tableCellProperties74.Append(tableCellWidth74);
            tableCellProperties74.Append(tableCellBorders74);
            tableCellProperties74.Append(shading74);
            tableCellProperties74.Append(tableCellMargin74);

            Paragraph paragraph91 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties91 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId91 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification52 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties91 = new ParagraphMarkRunProperties();
            RunFonts runFonts171 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize171 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties91.Append(runFonts171);
            paragraphMarkRunProperties91.Append(fontSize171);

            paragraphProperties91.Append(paragraphStyleId91);
            paragraphProperties91.Append(justification52);
            paragraphProperties91.Append(paragraphMarkRunProperties91);

            Run run81 = new Run();

            RunProperties runProperties81 = new RunProperties();
            RunFonts runFonts172 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize172 = new FontSize() { Val = "24" };

            runProperties81.Append(runFonts172);
            runProperties81.Append(fontSize172);
            Text text81 = new Text();
            text81.Text = "Wage";

            run81.Append(runProperties81);
            run81.Append(text81);

            paragraph91.Append(paragraphProperties91);
            paragraph91.Append(run81);

            tableCell74.Append(tableCellProperties74);
            tableCell74.Append(paragraph91);

            TableCell tableCell75 = new TableCell();

            TableCellProperties tableCellProperties75 = new TableCellProperties();
            TableCellWidth tableCellWidth75 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders75 = new TableCellBorders();
            TopBorder topBorder75 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder75 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder75 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder75 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders75.Append(topBorder75);
            tableCellBorders75.Append(leftBorder75);
            tableCellBorders75.Append(bottomBorder75);
            tableCellBorders75.Append(rightBorder75);
            Shading shading75 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin75 = new TableCellMargin();
            TopMargin topMargin94 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin75 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin94 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin75 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin75.Append(topMargin94);
            tableCellMargin75.Append(leftMargin75);
            tableCellMargin75.Append(bottomMargin94);
            tableCellMargin75.Append(rightMargin75);

            tableCellProperties75.Append(tableCellWidth75);
            tableCellProperties75.Append(tableCellBorders75);
            tableCellProperties75.Append(shading75);
            tableCellProperties75.Append(tableCellMargin75);

            Paragraph paragraph92 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties92 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId92 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification53 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties92 = new ParagraphMarkRunProperties();
            RunFonts runFonts173 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize173 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties92.Append(runFonts173);
            paragraphMarkRunProperties92.Append(fontSize173);

            paragraphProperties92.Append(paragraphStyleId92);
            paragraphProperties92.Append(justification53);
            paragraphProperties92.Append(paragraphMarkRunProperties92);

            Run run82 = new Run();

            RunProperties runProperties82 = new RunProperties();
            RunFonts runFonts174 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize174 = new FontSize() { Val = "24" };

            runProperties82.Append(runFonts174);
            runProperties82.Append(fontSize174);
            Text text82 = new Text();
            text82.Text = "979.00";

            run82.Append(runProperties82);
            run82.Append(text82);

            paragraph92.Append(paragraphProperties92);
            paragraph92.Append(run82);

            tableCell75.Append(tableCellProperties75);
            tableCell75.Append(paragraph92);

            TableCell tableCell76 = new TableCell();

            TableCellProperties tableCellProperties76 = new TableCellProperties();
            TableCellWidth tableCellWidth76 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders76 = new TableCellBorders();
            TopBorder topBorder76 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder76 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder76 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder76 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders76.Append(topBorder76);
            tableCellBorders76.Append(leftBorder76);
            tableCellBorders76.Append(bottomBorder76);
            tableCellBorders76.Append(rightBorder76);
            Shading shading76 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin76 = new TableCellMargin();
            TopMargin topMargin95 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin76 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin95 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin76 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin76.Append(topMargin95);
            tableCellMargin76.Append(leftMargin76);
            tableCellMargin76.Append(bottomMargin95);
            tableCellMargin76.Append(rightMargin76);

            tableCellProperties76.Append(tableCellWidth76);
            tableCellProperties76.Append(tableCellBorders76);
            tableCellProperties76.Append(shading76);
            tableCellProperties76.Append(tableCellMargin76);

            Paragraph paragraph93 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties93 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId93 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification54 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties93 = new ParagraphMarkRunProperties();
            RunFonts runFonts175 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize175 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties93.Append(runFonts175);
            paragraphMarkRunProperties93.Append(fontSize175);

            paragraphProperties93.Append(paragraphStyleId93);
            paragraphProperties93.Append(justification54);
            paragraphProperties93.Append(paragraphMarkRunProperties93);

            Run run83 = new Run();

            RunProperties runProperties83 = new RunProperties();
            RunFonts runFonts176 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize176 = new FontSize() { Val = "24" };

            runProperties83.Append(runFonts176);
            runProperties83.Append(fontSize176);
            Text text83 = new Text();
            text83.Text = "4 Weekly";

            run83.Append(runProperties83);
            run83.Append(text83);

            paragraph93.Append(paragraphProperties93);
            paragraph93.Append(run83);

            tableCell76.Append(tableCellProperties76);
            tableCell76.Append(paragraph93);

            tableRow19.Append(tablePropertyExceptions19);
            tableRow19.Append(tableCell74);
            tableRow19.Append(tableCell75);
            tableRow19.Append(tableCell76);

            table6.Append(tableProperties6);
            table6.Append(tableGrid6);
            table6.Append(tableRow18);
            table6.Append(tableRow19);

            Paragraph paragraph94 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties94 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId94 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties94 = new ParagraphMarkRunProperties();
            RunFonts runFonts177 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize177 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties94.Append(runFonts177);
            paragraphMarkRunProperties94.Append(fontSize177);

            paragraphProperties94.Append(paragraphStyleId94);
            paragraphProperties94.Append(paragraphMarkRunProperties94);

            paragraph94.Append(paragraphProperties94);

            Paragraph paragraph95 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties95 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId95 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties95 = new ParagraphMarkRunProperties();
            RunFonts runFonts178 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize178 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties95.Append(runFonts178);
            paragraphMarkRunProperties95.Append(fontSize178);

            paragraphProperties95.Append(paragraphStyleId95);
            paragraphProperties95.Append(paragraphMarkRunProperties95);

            paragraph95.Append(paragraphProperties95);

            Paragraph paragraph96 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties96 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId96 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties96 = new ParagraphMarkRunProperties();
            RunFonts runFonts179 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize179 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties96.Append(runFonts179);
            paragraphMarkRunProperties96.Append(fontSize179);

            paragraphProperties96.Append(paragraphStyleId96);
            paragraphProperties96.Append(paragraphMarkRunProperties96);

            Run run84 = new Run();

            RunProperties runProperties84 = new RunProperties();
            RunFonts runFonts180 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize180 = new FontSize() { Val = "24" };

            runProperties84.Append(runFonts180);
            runProperties84.Append(fontSize180);
            Text text84 = new Text();
            text84.Text = "Miss Stephanie James";

            run84.Append(runProperties84);
            run84.Append(text84);

            paragraph96.Append(paragraphProperties96);
            paragraph96.Append(run84);

            Table table7 = new Table();

            TableProperties tableProperties7 = new TableProperties();
            TableWidth tableWidth7 = new TableWidth() { Width = "9000", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout7 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault26 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin7 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin7 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault26.Append(tableCellLeftMargin7);
            tableCellMarginDefault26.Append(tableCellRightMargin7);
            TableLook tableLook7 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties7.Append(tableWidth7);
            tableProperties7.Append(tableLayout7);
            tableProperties7.Append(tableCellMarginDefault26);
            tableProperties7.Append(tableLook7);

            TableGrid tableGrid7 = new TableGrid();
            GridColumn gridColumn25 = new GridColumn() { Width = "3000" };
            GridColumn gridColumn26 = new GridColumn() { Width = "3000" };
            GridColumn gridColumn27 = new GridColumn() { Width = "3000" };

            tableGrid7.Append(gridColumn25);
            tableGrid7.Append(gridColumn26);
            tableGrid7.Append(gridColumn27);

            TableRow tableRow20 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions20 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault27 = new TableCellMarginDefault();
            TopMargin topMargin96 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin96 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault27.Append(topMargin96);
            tableCellMarginDefault27.Append(bottomMargin96);

            tablePropertyExceptions20.Append(tableCellMarginDefault27);

            TableCell tableCell77 = new TableCell();

            TableCellProperties tableCellProperties77 = new TableCellProperties();
            TableCellWidth tableCellWidth77 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders77 = new TableCellBorders();
            TopBorder topBorder77 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder77 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder77 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder77 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders77.Append(topBorder77);
            tableCellBorders77.Append(leftBorder77);
            tableCellBorders77.Append(bottomBorder77);
            tableCellBorders77.Append(rightBorder77);
            Shading shading77 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin77 = new TableCellMargin();
            TopMargin topMargin97 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin77 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin97 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin77 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin77.Append(topMargin97);
            tableCellMargin77.Append(leftMargin77);
            tableCellMargin77.Append(bottomMargin97);
            tableCellMargin77.Append(rightMargin77);

            tableCellProperties77.Append(tableCellWidth77);
            tableCellProperties77.Append(tableCellBorders77);
            tableCellProperties77.Append(shading77);
            tableCellProperties77.Append(tableCellMargin77);

            Paragraph paragraph97 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties97 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId97 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification55 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties97 = new ParagraphMarkRunProperties();
            RunFonts runFonts181 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold50 = new Bold();
            FontSize fontSize181 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties97.Append(runFonts181);
            paragraphMarkRunProperties97.Append(bold50);
            paragraphMarkRunProperties97.Append(fontSize181);

            paragraphProperties97.Append(paragraphStyleId97);
            paragraphProperties97.Append(justification55);
            paragraphProperties97.Append(paragraphMarkRunProperties97);

            Run run85 = new Run();

            RunProperties runProperties85 = new RunProperties();
            RunFonts runFonts182 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold51 = new Bold();
            FontSize fontSize182 = new FontSize() { Val = "24" };

            runProperties85.Append(runFonts182);
            runProperties85.Append(bold51);
            runProperties85.Append(fontSize182);
            Text text85 = new Text();
            text85.Text = "Income Source";

            run85.Append(runProperties85);
            run85.Append(text85);

            paragraph97.Append(paragraphProperties97);
            paragraph97.Append(run85);

            tableCell77.Append(tableCellProperties77);
            tableCell77.Append(paragraph97);

            TableCell tableCell78 = new TableCell();

            TableCellProperties tableCellProperties78 = new TableCellProperties();
            TableCellWidth tableCellWidth78 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders78 = new TableCellBorders();
            TopBorder topBorder78 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder78 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder78 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder78 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders78.Append(topBorder78);
            tableCellBorders78.Append(leftBorder78);
            tableCellBorders78.Append(bottomBorder78);
            tableCellBorders78.Append(rightBorder78);
            Shading shading78 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin78 = new TableCellMargin();
            TopMargin topMargin98 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin78 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin98 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin78 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin78.Append(topMargin98);
            tableCellMargin78.Append(leftMargin78);
            tableCellMargin78.Append(bottomMargin98);
            tableCellMargin78.Append(rightMargin78);

            tableCellProperties78.Append(tableCellWidth78);
            tableCellProperties78.Append(tableCellBorders78);
            tableCellProperties78.Append(shading78);
            tableCellProperties78.Append(tableCellMargin78);

            Paragraph paragraph98 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties98 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId98 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification56 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties98 = new ParagraphMarkRunProperties();
            RunFonts runFonts183 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold52 = new Bold();
            FontSize fontSize183 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties98.Append(runFonts183);
            paragraphMarkRunProperties98.Append(bold52);
            paragraphMarkRunProperties98.Append(fontSize183);

            paragraphProperties98.Append(paragraphStyleId98);
            paragraphProperties98.Append(justification56);
            paragraphProperties98.Append(paragraphMarkRunProperties98);

            Run run86 = new Run();

            RunProperties runProperties86 = new RunProperties();
            RunFonts runFonts184 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold53 = new Bold();
            FontSize fontSize184 = new FontSize() { Val = "24" };

            runProperties86.Append(runFonts184);
            runProperties86.Append(bold53);
            runProperties86.Append(fontSize184);
            Text text86 = new Text();
            text86.Text = "Amount";

            run86.Append(runProperties86);
            run86.Append(text86);

            paragraph98.Append(paragraphProperties98);
            paragraph98.Append(run86);

            tableCell78.Append(tableCellProperties78);
            tableCell78.Append(paragraph98);

            TableCell tableCell79 = new TableCell();

            TableCellProperties tableCellProperties79 = new TableCellProperties();
            TableCellWidth tableCellWidth79 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders79 = new TableCellBorders();
            TopBorder topBorder79 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder79 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder79 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder79 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders79.Append(topBorder79);
            tableCellBorders79.Append(leftBorder79);
            tableCellBorders79.Append(bottomBorder79);
            tableCellBorders79.Append(rightBorder79);
            Shading shading79 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin79 = new TableCellMargin();
            TopMargin topMargin99 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin79 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin99 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin79 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin79.Append(topMargin99);
            tableCellMargin79.Append(leftMargin79);
            tableCellMargin79.Append(bottomMargin99);
            tableCellMargin79.Append(rightMargin79);

            tableCellProperties79.Append(tableCellWidth79);
            tableCellProperties79.Append(tableCellBorders79);
            tableCellProperties79.Append(shading79);
            tableCellProperties79.Append(tableCellMargin79);

            Paragraph paragraph99 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties99 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId99 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification57 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties99 = new ParagraphMarkRunProperties();
            RunFonts runFonts185 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold54 = new Bold();
            FontSize fontSize185 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties99.Append(runFonts185);
            paragraphMarkRunProperties99.Append(bold54);
            paragraphMarkRunProperties99.Append(fontSize185);

            paragraphProperties99.Append(paragraphStyleId99);
            paragraphProperties99.Append(justification57);
            paragraphProperties99.Append(paragraphMarkRunProperties99);

            Run run87 = new Run();

            RunProperties runProperties87 = new RunProperties();
            RunFonts runFonts186 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold55 = new Bold();
            FontSize fontSize186 = new FontSize() { Val = "24" };

            runProperties87.Append(runFonts186);
            runProperties87.Append(bold55);
            runProperties87.Append(fontSize186);
            Text text87 = new Text();
            text87.Text = "Frequency";

            run87.Append(runProperties87);
            run87.Append(text87);

            paragraph99.Append(paragraphProperties99);
            paragraph99.Append(run87);

            tableCell79.Append(tableCellProperties79);
            tableCell79.Append(paragraph99);

            tableRow20.Append(tablePropertyExceptions20);
            tableRow20.Append(tableCell77);
            tableRow20.Append(tableCell78);
            tableRow20.Append(tableCell79);

            TableRow tableRow21 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions21 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault28 = new TableCellMarginDefault();
            TopMargin topMargin100 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin100 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault28.Append(topMargin100);
            tableCellMarginDefault28.Append(bottomMargin100);

            tablePropertyExceptions21.Append(tableCellMarginDefault28);

            TableCell tableCell80 = new TableCell();

            TableCellProperties tableCellProperties80 = new TableCellProperties();
            TableCellWidth tableCellWidth80 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders80 = new TableCellBorders();
            TopBorder topBorder80 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder80 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder80 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder80 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders80.Append(topBorder80);
            tableCellBorders80.Append(leftBorder80);
            tableCellBorders80.Append(bottomBorder80);
            tableCellBorders80.Append(rightBorder80);
            Shading shading80 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin80 = new TableCellMargin();
            TopMargin topMargin101 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin80 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin101 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin80 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin80.Append(topMargin101);
            tableCellMargin80.Append(leftMargin80);
            tableCellMargin80.Append(bottomMargin101);
            tableCellMargin80.Append(rightMargin80);

            tableCellProperties80.Append(tableCellWidth80);
            tableCellProperties80.Append(tableCellBorders80);
            tableCellProperties80.Append(shading80);
            tableCellProperties80.Append(tableCellMargin80);

            Paragraph paragraph100 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties100 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId100 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification58 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties100 = new ParagraphMarkRunProperties();
            RunFonts runFonts187 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize187 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties100.Append(runFonts187);
            paragraphMarkRunProperties100.Append(fontSize187);

            paragraphProperties100.Append(paragraphStyleId100);
            paragraphProperties100.Append(justification58);
            paragraphProperties100.Append(paragraphMarkRunProperties100);

            Run run88 = new Run();

            RunProperties runProperties88 = new RunProperties();
            RunFonts runFonts188 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize188 = new FontSize() { Val = "24" };

            runProperties88.Append(runFonts188);
            runProperties88.Append(fontSize188);
            Text text88 = new Text();
            text88.Text = "Income Support";

            run88.Append(runProperties88);
            run88.Append(text88);

            paragraph100.Append(paragraphProperties100);
            paragraph100.Append(run88);

            tableCell80.Append(tableCellProperties80);
            tableCell80.Append(paragraph100);

            TableCell tableCell81 = new TableCell();

            TableCellProperties tableCellProperties81 = new TableCellProperties();
            TableCellWidth tableCellWidth81 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders81 = new TableCellBorders();
            TopBorder topBorder81 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder81 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder81 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder81 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders81.Append(topBorder81);
            tableCellBorders81.Append(leftBorder81);
            tableCellBorders81.Append(bottomBorder81);
            tableCellBorders81.Append(rightBorder81);
            Shading shading81 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin81 = new TableCellMargin();
            TopMargin topMargin102 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin81 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin102 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin81 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin81.Append(topMargin102);
            tableCellMargin81.Append(leftMargin81);
            tableCellMargin81.Append(bottomMargin102);
            tableCellMargin81.Append(rightMargin81);

            tableCellProperties81.Append(tableCellWidth81);
            tableCellProperties81.Append(tableCellBorders81);
            tableCellProperties81.Append(shading81);
            tableCellProperties81.Append(tableCellMargin81);

            Paragraph paragraph101 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties101 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId101 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification59 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties101 = new ParagraphMarkRunProperties();
            RunFonts runFonts189 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize189 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties101.Append(runFonts189);
            paragraphMarkRunProperties101.Append(fontSize189);

            paragraphProperties101.Append(paragraphStyleId101);
            paragraphProperties101.Append(justification59);
            paragraphProperties101.Append(paragraphMarkRunProperties101);

            Run run89 = new Run();

            RunProperties runProperties89 = new RunProperties();
            RunFonts runFonts190 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize190 = new FontSize() { Val = "24" };

            runProperties89.Append(runFonts190);
            runProperties89.Append(fontSize190);
            Text text89 = new Text();
            text89.Text = "400.00";

            run89.Append(runProperties89);
            run89.Append(text89);

            paragraph101.Append(paragraphProperties101);
            paragraph101.Append(run89);

            tableCell81.Append(tableCellProperties81);
            tableCell81.Append(paragraph101);

            TableCell tableCell82 = new TableCell();

            TableCellProperties tableCellProperties82 = new TableCellProperties();
            TableCellWidth tableCellWidth82 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders82 = new TableCellBorders();
            TopBorder topBorder82 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder82 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder82 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder82 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders82.Append(topBorder82);
            tableCellBorders82.Append(leftBorder82);
            tableCellBorders82.Append(bottomBorder82);
            tableCellBorders82.Append(rightBorder82);
            Shading shading82 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin82 = new TableCellMargin();
            TopMargin topMargin103 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin82 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin103 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin82 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin82.Append(topMargin103);
            tableCellMargin82.Append(leftMargin82);
            tableCellMargin82.Append(bottomMargin103);
            tableCellMargin82.Append(rightMargin82);

            tableCellProperties82.Append(tableCellWidth82);
            tableCellProperties82.Append(tableCellBorders82);
            tableCellProperties82.Append(shading82);
            tableCellProperties82.Append(tableCellMargin82);

            Paragraph paragraph102 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties102 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId102 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification60 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties102 = new ParagraphMarkRunProperties();
            RunFonts runFonts191 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize191 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties102.Append(runFonts191);
            paragraphMarkRunProperties102.Append(fontSize191);

            paragraphProperties102.Append(paragraphStyleId102);
            paragraphProperties102.Append(justification60);
            paragraphProperties102.Append(paragraphMarkRunProperties102);

            Run run90 = new Run();

            RunProperties runProperties90 = new RunProperties();
            RunFonts runFonts192 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize192 = new FontSize() { Val = "24" };

            runProperties90.Append(runFonts192);
            runProperties90.Append(fontSize192);
            Text text90 = new Text();
            text90.Text = "Monthly";

            run90.Append(runProperties90);
            run90.Append(text90);

            paragraph102.Append(paragraphProperties102);
            paragraph102.Append(run90);

            tableCell82.Append(tableCellProperties82);
            tableCell82.Append(paragraph102);

            tableRow21.Append(tablePropertyExceptions21);
            tableRow21.Append(tableCell80);
            tableRow21.Append(tableCell81);
            tableRow21.Append(tableCell82);

            TableRow tableRow22 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions22 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault29 = new TableCellMarginDefault();
            TopMargin topMargin104 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin104 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault29.Append(topMargin104);
            tableCellMarginDefault29.Append(bottomMargin104);

            tablePropertyExceptions22.Append(tableCellMarginDefault29);

            TableCell tableCell83 = new TableCell();

            TableCellProperties tableCellProperties83 = new TableCellProperties();
            TableCellWidth tableCellWidth83 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders83 = new TableCellBorders();
            TopBorder topBorder83 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder83 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder83 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder83 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders83.Append(topBorder83);
            tableCellBorders83.Append(leftBorder83);
            tableCellBorders83.Append(bottomBorder83);
            tableCellBorders83.Append(rightBorder83);
            Shading shading83 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin83 = new TableCellMargin();
            TopMargin topMargin105 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin83 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin105 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin83 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin83.Append(topMargin105);
            tableCellMargin83.Append(leftMargin83);
            tableCellMargin83.Append(bottomMargin105);
            tableCellMargin83.Append(rightMargin83);

            tableCellProperties83.Append(tableCellWidth83);
            tableCellProperties83.Append(tableCellBorders83);
            tableCellProperties83.Append(shading83);
            tableCellProperties83.Append(tableCellMargin83);

            Paragraph paragraph103 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties103 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId103 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification61 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties103 = new ParagraphMarkRunProperties();
            RunFonts runFonts193 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize193 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties103.Append(runFonts193);
            paragraphMarkRunProperties103.Append(fontSize193);

            paragraphProperties103.Append(paragraphStyleId103);
            paragraphProperties103.Append(justification61);
            paragraphProperties103.Append(paragraphMarkRunProperties103);

            Run run91 = new Run();

            RunProperties runProperties91 = new RunProperties();
            RunFonts runFonts194 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize194 = new FontSize() { Val = "24" };

            runProperties91.Append(runFonts194);
            runProperties91.Append(fontSize194);
            Text text91 = new Text();
            text91.Text = "Child Benefit";

            run91.Append(runProperties91);
            run91.Append(text91);

            paragraph103.Append(paragraphProperties103);
            paragraph103.Append(run91);

            tableCell83.Append(tableCellProperties83);
            tableCell83.Append(paragraph103);

            TableCell tableCell84 = new TableCell();

            TableCellProperties tableCellProperties84 = new TableCellProperties();
            TableCellWidth tableCellWidth84 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders84 = new TableCellBorders();
            TopBorder topBorder84 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder84 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder84 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder84 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders84.Append(topBorder84);
            tableCellBorders84.Append(leftBorder84);
            tableCellBorders84.Append(bottomBorder84);
            tableCellBorders84.Append(rightBorder84);
            Shading shading84 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin84 = new TableCellMargin();
            TopMargin topMargin106 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin84 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin106 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin84 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin84.Append(topMargin106);
            tableCellMargin84.Append(leftMargin84);
            tableCellMargin84.Append(bottomMargin106);
            tableCellMargin84.Append(rightMargin84);

            tableCellProperties84.Append(tableCellWidth84);
            tableCellProperties84.Append(tableCellBorders84);
            tableCellProperties84.Append(shading84);
            tableCellProperties84.Append(tableCellMargin84);

            Paragraph paragraph104 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties104 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId104 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification62 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties104 = new ParagraphMarkRunProperties();
            RunFonts runFonts195 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize195 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties104.Append(runFonts195);
            paragraphMarkRunProperties104.Append(fontSize195);

            paragraphProperties104.Append(paragraphStyleId104);
            paragraphProperties104.Append(justification62);
            paragraphProperties104.Append(paragraphMarkRunProperties104);

            Run run92 = new Run();

            RunProperties runProperties92 = new RunProperties();
            RunFonts runFonts196 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize196 = new FontSize() { Val = "24" };

            runProperties92.Append(runFonts196);
            runProperties92.Append(fontSize196);
            Text text92 = new Text();
            text92.Text = "20.00";

            run92.Append(runProperties92);
            run92.Append(text92);

            paragraph104.Append(paragraphProperties104);
            paragraph104.Append(run92);

            tableCell84.Append(tableCellProperties84);
            tableCell84.Append(paragraph104);

            TableCell tableCell85 = new TableCell();

            TableCellProperties tableCellProperties85 = new TableCellProperties();
            TableCellWidth tableCellWidth85 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders85 = new TableCellBorders();
            TopBorder topBorder85 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder85 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder85 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder85 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders85.Append(topBorder85);
            tableCellBorders85.Append(leftBorder85);
            tableCellBorders85.Append(bottomBorder85);
            tableCellBorders85.Append(rightBorder85);
            Shading shading85 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin85 = new TableCellMargin();
            TopMargin topMargin107 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin85 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin107 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin85 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin85.Append(topMargin107);
            tableCellMargin85.Append(leftMargin85);
            tableCellMargin85.Append(bottomMargin107);
            tableCellMargin85.Append(rightMargin85);

            tableCellProperties85.Append(tableCellWidth85);
            tableCellProperties85.Append(tableCellBorders85);
            tableCellProperties85.Append(shading85);
            tableCellProperties85.Append(tableCellMargin85);

            Paragraph paragraph105 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties105 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId105 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification63 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties105 = new ParagraphMarkRunProperties();
            RunFonts runFonts197 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize197 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties105.Append(runFonts197);
            paragraphMarkRunProperties105.Append(fontSize197);

            paragraphProperties105.Append(paragraphStyleId105);
            paragraphProperties105.Append(justification63);
            paragraphProperties105.Append(paragraphMarkRunProperties105);

            Run run93 = new Run();

            RunProperties runProperties93 = new RunProperties();
            RunFonts runFonts198 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize198 = new FontSize() { Val = "24" };

            runProperties93.Append(runFonts198);
            runProperties93.Append(fontSize198);
            Text text93 = new Text();
            text93.Text = "Weekly";

            run93.Append(runProperties93);
            run93.Append(text93);

            paragraph105.Append(paragraphProperties105);
            paragraph105.Append(run93);

            tableCell85.Append(tableCellProperties85);
            tableCell85.Append(paragraph105);

            tableRow22.Append(tablePropertyExceptions22);
            tableRow22.Append(tableCell83);
            tableRow22.Append(tableCell84);
            tableRow22.Append(tableCell85);

            TableRow tableRow23 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions23 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault30 = new TableCellMarginDefault();
            TopMargin topMargin108 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin108 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault30.Append(topMargin108);
            tableCellMarginDefault30.Append(bottomMargin108);

            tablePropertyExceptions23.Append(tableCellMarginDefault30);

            TableCell tableCell86 = new TableCell();

            TableCellProperties tableCellProperties86 = new TableCellProperties();
            TableCellWidth tableCellWidth86 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders86 = new TableCellBorders();
            TopBorder topBorder86 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder86 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder86 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder86 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders86.Append(topBorder86);
            tableCellBorders86.Append(leftBorder86);
            tableCellBorders86.Append(bottomBorder86);
            tableCellBorders86.Append(rightBorder86);
            Shading shading86 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin86 = new TableCellMargin();
            TopMargin topMargin109 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin86 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin109 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin86 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin86.Append(topMargin109);
            tableCellMargin86.Append(leftMargin86);
            tableCellMargin86.Append(bottomMargin109);
            tableCellMargin86.Append(rightMargin86);

            tableCellProperties86.Append(tableCellWidth86);
            tableCellProperties86.Append(tableCellBorders86);
            tableCellProperties86.Append(shading86);
            tableCellProperties86.Append(tableCellMargin86);

            Paragraph paragraph106 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties106 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId106 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification64 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties106 = new ParagraphMarkRunProperties();
            RunFonts runFonts199 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize199 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties106.Append(runFonts199);
            paragraphMarkRunProperties106.Append(fontSize199);

            paragraphProperties106.Append(paragraphStyleId106);
            paragraphProperties106.Append(justification64);
            paragraphProperties106.Append(paragraphMarkRunProperties106);

            Run run94 = new Run();

            RunProperties runProperties94 = new RunProperties();
            RunFonts runFonts200 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize200 = new FontSize() { Val = "24" };

            runProperties94.Append(runFonts200);
            runProperties94.Append(fontSize200);
            Text text94 = new Text();
            text94.Text = "Disability Living Allowance (Care)";

            run94.Append(runProperties94);
            run94.Append(text94);

            paragraph106.Append(paragraphProperties106);
            paragraph106.Append(run94);

            tableCell86.Append(tableCellProperties86);
            tableCell86.Append(paragraph106);

            TableCell tableCell87 = new TableCell();

            TableCellProperties tableCellProperties87 = new TableCellProperties();
            TableCellWidth tableCellWidth87 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders87 = new TableCellBorders();
            TopBorder topBorder87 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder87 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder87 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder87 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders87.Append(topBorder87);
            tableCellBorders87.Append(leftBorder87);
            tableCellBorders87.Append(bottomBorder87);
            tableCellBorders87.Append(rightBorder87);
            Shading shading87 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin87 = new TableCellMargin();
            TopMargin topMargin110 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin87 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin110 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin87 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin87.Append(topMargin110);
            tableCellMargin87.Append(leftMargin87);
            tableCellMargin87.Append(bottomMargin110);
            tableCellMargin87.Append(rightMargin87);

            tableCellProperties87.Append(tableCellWidth87);
            tableCellProperties87.Append(tableCellBorders87);
            tableCellProperties87.Append(shading87);
            tableCellProperties87.Append(tableCellMargin87);

            Paragraph paragraph107 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties107 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId107 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification65 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties107 = new ParagraphMarkRunProperties();
            RunFonts runFonts201 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize201 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties107.Append(runFonts201);
            paragraphMarkRunProperties107.Append(fontSize201);

            paragraphProperties107.Append(paragraphStyleId107);
            paragraphProperties107.Append(justification65);
            paragraphProperties107.Append(paragraphMarkRunProperties107);

            Run run95 = new Run();

            RunProperties runProperties95 = new RunProperties();
            RunFonts runFonts202 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize202 = new FontSize() { Val = "24" };

            runProperties95.Append(runFonts202);
            runProperties95.Append(fontSize202);
            Text text95 = new Text();
            text95.Text = "300.00";

            run95.Append(runProperties95);
            run95.Append(text95);

            paragraph107.Append(paragraphProperties107);
            paragraph107.Append(run95);

            tableCell87.Append(tableCellProperties87);
            tableCell87.Append(paragraph107);

            TableCell tableCell88 = new TableCell();

            TableCellProperties tableCellProperties88 = new TableCellProperties();
            TableCellWidth tableCellWidth88 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders88 = new TableCellBorders();
            TopBorder topBorder88 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder88 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder88 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder88 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders88.Append(topBorder88);
            tableCellBorders88.Append(leftBorder88);
            tableCellBorders88.Append(bottomBorder88);
            tableCellBorders88.Append(rightBorder88);
            Shading shading88 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin88 = new TableCellMargin();
            TopMargin topMargin111 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin88 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin111 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin88 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin88.Append(topMargin111);
            tableCellMargin88.Append(leftMargin88);
            tableCellMargin88.Append(bottomMargin111);
            tableCellMargin88.Append(rightMargin88);

            tableCellProperties88.Append(tableCellWidth88);
            tableCellProperties88.Append(tableCellBorders88);
            tableCellProperties88.Append(shading88);
            tableCellProperties88.Append(tableCellMargin88);

            Paragraph paragraph108 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties108 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId108 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification66 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties108 = new ParagraphMarkRunProperties();
            RunFonts runFonts203 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize203 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties108.Append(runFonts203);
            paragraphMarkRunProperties108.Append(fontSize203);

            paragraphProperties108.Append(paragraphStyleId108);
            paragraphProperties108.Append(justification66);
            paragraphProperties108.Append(paragraphMarkRunProperties108);

            Run run96 = new Run();

            RunProperties runProperties96 = new RunProperties();
            RunFonts runFonts204 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize204 = new FontSize() { Val = "24" };

            runProperties96.Append(runFonts204);
            runProperties96.Append(fontSize204);
            Text text96 = new Text();
            text96.Text = "Monthly";

            run96.Append(runProperties96);
            run96.Append(text96);

            paragraph108.Append(paragraphProperties108);
            paragraph108.Append(run96);

            tableCell88.Append(tableCellProperties88);
            tableCell88.Append(paragraph108);

            tableRow23.Append(tablePropertyExceptions23);
            tableRow23.Append(tableCell86);
            tableRow23.Append(tableCell87);
            tableRow23.Append(tableCell88);

            TableRow tableRow24 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions24 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault31 = new TableCellMarginDefault();
            TopMargin topMargin112 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin112 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault31.Append(topMargin112);
            tableCellMarginDefault31.Append(bottomMargin112);

            tablePropertyExceptions24.Append(tableCellMarginDefault31);

            TableCell tableCell89 = new TableCell();

            TableCellProperties tableCellProperties89 = new TableCellProperties();
            TableCellWidth tableCellWidth89 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders89 = new TableCellBorders();
            TopBorder topBorder89 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder89 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder89 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder89 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders89.Append(topBorder89);
            tableCellBorders89.Append(leftBorder89);
            tableCellBorders89.Append(bottomBorder89);
            tableCellBorders89.Append(rightBorder89);
            Shading shading89 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin89 = new TableCellMargin();
            TopMargin topMargin113 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin89 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin113 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin89 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin89.Append(topMargin113);
            tableCellMargin89.Append(leftMargin89);
            tableCellMargin89.Append(bottomMargin113);
            tableCellMargin89.Append(rightMargin89);

            tableCellProperties89.Append(tableCellWidth89);
            tableCellProperties89.Append(tableCellBorders89);
            tableCellProperties89.Append(shading89);
            tableCellProperties89.Append(tableCellMargin89);

            Paragraph paragraph109 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties109 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId109 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification67 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties109 = new ParagraphMarkRunProperties();
            RunFonts runFonts205 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize205 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties109.Append(runFonts205);
            paragraphMarkRunProperties109.Append(fontSize205);

            paragraphProperties109.Append(paragraphStyleId109);
            paragraphProperties109.Append(justification67);
            paragraphProperties109.Append(paragraphMarkRunProperties109);

            Run run97 = new Run();

            RunProperties runProperties97 = new RunProperties();
            RunFonts runFonts206 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize206 = new FontSize() { Val = "24" };

            runProperties97.Append(runFonts206);
            runProperties97.Append(fontSize206);
            Text text97 = new Text();
            text97.Text = "Child Tax Credit";

            run97.Append(runProperties97);
            run97.Append(text97);

            paragraph109.Append(paragraphProperties109);
            paragraph109.Append(run97);

            tableCell89.Append(tableCellProperties89);
            tableCell89.Append(paragraph109);

            TableCell tableCell90 = new TableCell();

            TableCellProperties tableCellProperties90 = new TableCellProperties();
            TableCellWidth tableCellWidth90 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders90 = new TableCellBorders();
            TopBorder topBorder90 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder90 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder90 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder90 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders90.Append(topBorder90);
            tableCellBorders90.Append(leftBorder90);
            tableCellBorders90.Append(bottomBorder90);
            tableCellBorders90.Append(rightBorder90);
            Shading shading90 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin90 = new TableCellMargin();
            TopMargin topMargin114 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin90 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin114 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin90 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin90.Append(topMargin114);
            tableCellMargin90.Append(leftMargin90);
            tableCellMargin90.Append(bottomMargin114);
            tableCellMargin90.Append(rightMargin90);

            tableCellProperties90.Append(tableCellWidth90);
            tableCellProperties90.Append(tableCellBorders90);
            tableCellProperties90.Append(shading90);
            tableCellProperties90.Append(tableCellMargin90);

            Paragraph paragraph110 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties110 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId110 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification68 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties110 = new ParagraphMarkRunProperties();
            RunFonts runFonts207 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize207 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties110.Append(runFonts207);
            paragraphMarkRunProperties110.Append(fontSize207);

            paragraphProperties110.Append(paragraphStyleId110);
            paragraphProperties110.Append(justification68);
            paragraphProperties110.Append(paragraphMarkRunProperties110);

            Run run98 = new Run();

            RunProperties runProperties98 = new RunProperties();
            RunFonts runFonts208 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize208 = new FontSize() { Val = "24" };

            runProperties98.Append(runFonts208);
            runProperties98.Append(fontSize208);
            Text text98 = new Text();
            text98.Text = "60.00";

            run98.Append(runProperties98);
            run98.Append(text98);

            paragraph110.Append(paragraphProperties110);
            paragraph110.Append(run98);

            tableCell90.Append(tableCellProperties90);
            tableCell90.Append(paragraph110);

            TableCell tableCell91 = new TableCell();

            TableCellProperties tableCellProperties91 = new TableCellProperties();
            TableCellWidth tableCellWidth91 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders91 = new TableCellBorders();
            TopBorder topBorder91 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder91 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder91 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder91 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders91.Append(topBorder91);
            tableCellBorders91.Append(leftBorder91);
            tableCellBorders91.Append(bottomBorder91);
            tableCellBorders91.Append(rightBorder91);
            Shading shading91 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin91 = new TableCellMargin();
            TopMargin topMargin115 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin91 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin115 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin91 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin91.Append(topMargin115);
            tableCellMargin91.Append(leftMargin91);
            tableCellMargin91.Append(bottomMargin115);
            tableCellMargin91.Append(rightMargin91);

            tableCellProperties91.Append(tableCellWidth91);
            tableCellProperties91.Append(tableCellBorders91);
            tableCellProperties91.Append(shading91);
            tableCellProperties91.Append(tableCellMargin91);

            Paragraph paragraph111 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties111 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId111 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification69 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties111 = new ParagraphMarkRunProperties();
            RunFonts runFonts209 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize209 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties111.Append(runFonts209);
            paragraphMarkRunProperties111.Append(fontSize209);

            paragraphProperties111.Append(paragraphStyleId111);
            paragraphProperties111.Append(justification69);
            paragraphProperties111.Append(paragraphMarkRunProperties111);

            Run run99 = new Run();

            RunProperties runProperties99 = new RunProperties();
            RunFonts runFonts210 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize210 = new FontSize() { Val = "24" };

            runProperties99.Append(runFonts210);
            runProperties99.Append(fontSize210);
            Text text99 = new Text();
            text99.Text = "Weekly";

            run99.Append(runProperties99);
            run99.Append(text99);

            paragraph111.Append(paragraphProperties111);
            paragraph111.Append(run99);

            tableCell91.Append(tableCellProperties91);
            tableCell91.Append(paragraph111);

            tableRow24.Append(tablePropertyExceptions24);
            tableRow24.Append(tableCell89);
            tableRow24.Append(tableCell90);
            tableRow24.Append(tableCell91);

            table7.Append(tableProperties7);
            table7.Append(tableGrid7);
            table7.Append(tableRow20);
            table7.Append(tableRow21);
            table7.Append(tableRow22);
            table7.Append(tableRow23);
            table7.Append(tableRow24);

            Paragraph paragraph112 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties112 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId112 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties112 = new ParagraphMarkRunProperties();
            RunFonts runFonts211 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize211 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties112.Append(runFonts211);
            paragraphMarkRunProperties112.Append(fontSize211);

            paragraphProperties112.Append(paragraphStyleId112);
            paragraphProperties112.Append(paragraphMarkRunProperties112);

            paragraph112.Append(paragraphProperties112);

            Paragraph paragraph113 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties113 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId113 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties113 = new ParagraphMarkRunProperties();
            RunFonts runFonts212 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize212 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties113.Append(runFonts212);
            paragraphMarkRunProperties113.Append(fontSize212);

            paragraphProperties113.Append(paragraphStyleId113);
            paragraphProperties113.Append(paragraphMarkRunProperties113);

            paragraph113.Append(paragraphProperties113);

            Paragraph paragraph114 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties114 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId114 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties114 = new ParagraphMarkRunProperties();
            RunFonts runFonts213 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize213 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties114.Append(runFonts213);
            paragraphMarkRunProperties114.Append(fontSize213);

            paragraphProperties114.Append(paragraphStyleId114);
            paragraphProperties114.Append(paragraphMarkRunProperties114);

            paragraph114.Append(paragraphProperties114);

            Paragraph paragraph115 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties115 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId115 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties115 = new ParagraphMarkRunProperties();
            RunFonts runFonts214 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize214 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties115.Append(runFonts214);
            paragraphMarkRunProperties115.Append(fontSize214);

            paragraphProperties115.Append(paragraphStyleId115);
            paragraphProperties115.Append(paragraphMarkRunProperties115);

            Run run100 = new Run();

            RunProperties runProperties100 = new RunProperties();
            RunFonts runFonts215 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize215 = new FontSize() { Val = "24" };

            runProperties100.Append(runFonts215);
            runProperties100.Append(fontSize215);
            Text text100 = new Text();
            text100.Text = "Property Requirements";

            run100.Append(runProperties100);
            run100.Append(text100);

            paragraph115.Append(paragraphProperties115);
            paragraph115.Append(run100);

            Table table8 = new Table();

            TableProperties tableProperties8 = new TableProperties();
            TableWidth tableWidth8 = new TableWidth() { Width = "9600", Type = TableWidthUnitValues.Dxa };
            TableLayout tableLayout8 = new TableLayout() { Type = TableLayoutValues.Fixed };

            TableCellMarginDefault tableCellMarginDefault32 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin8 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin8 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault32.Append(tableCellLeftMargin8);
            tableCellMarginDefault32.Append(tableCellRightMargin8);
            TableLook tableLook8 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties8.Append(tableWidth8);
            tableProperties8.Append(tableLayout8);
            tableProperties8.Append(tableCellMarginDefault32);
            tableProperties8.Append(tableLook8);

            TableGrid tableGrid8 = new TableGrid();
            GridColumn gridColumn28 = new GridColumn() { Width = "1600" };
            GridColumn gridColumn29 = new GridColumn() { Width = "8000" };

            tableGrid8.Append(gridColumn28);
            tableGrid8.Append(gridColumn29);

            TableRow tableRow25 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions25 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault33 = new TableCellMarginDefault();
            TopMargin topMargin116 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin116 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault33.Append(topMargin116);
            tableCellMarginDefault33.Append(bottomMargin116);

            tablePropertyExceptions25.Append(tableCellMarginDefault33);

            TableCell tableCell92 = new TableCell();

            TableCellProperties tableCellProperties92 = new TableCellProperties();
            TableCellWidth tableCellWidth92 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders92 = new TableCellBorders();
            TopBorder topBorder92 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder92 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder92 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder92 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders92.Append(topBorder92);
            tableCellBorders92.Append(leftBorder92);
            tableCellBorders92.Append(bottomBorder92);
            tableCellBorders92.Append(rightBorder92);
            Shading shading92 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin92 = new TableCellMargin();
            TopMargin topMargin117 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin92 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin117 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin92 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin92.Append(topMargin117);
            tableCellMargin92.Append(leftMargin92);
            tableCellMargin92.Append(bottomMargin117);
            tableCellMargin92.Append(rightMargin92);

            tableCellProperties92.Append(tableCellWidth92);
            tableCellProperties92.Append(tableCellBorders92);
            tableCellProperties92.Append(shading92);
            tableCellProperties92.Append(tableCellMargin92);

            Paragraph paragraph116 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties116 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId116 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification70 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties116 = new ParagraphMarkRunProperties();
            RunFonts runFonts216 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold56 = new Bold();
            FontSize fontSize216 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties116.Append(runFonts216);
            paragraphMarkRunProperties116.Append(bold56);
            paragraphMarkRunProperties116.Append(fontSize216);

            paragraphProperties116.Append(paragraphStyleId116);
            paragraphProperties116.Append(justification70);
            paragraphProperties116.Append(paragraphMarkRunProperties116);

            Run run101 = new Run();

            RunProperties runProperties101 = new RunProperties();
            RunFonts runFonts217 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold57 = new Bold();
            FontSize fontSize217 = new FontSize() { Val = "24" };

            runProperties101.Append(runFonts217);
            runProperties101.Append(bold57);
            runProperties101.Append(fontSize217);
            Text text101 = new Text();
            text101.Text = "Item";

            run101.Append(runProperties101);
            run101.Append(text101);

            paragraph116.Append(paragraphProperties116);
            paragraph116.Append(run101);

            tableCell92.Append(tableCellProperties92);
            tableCell92.Append(paragraph116);

            TableCell tableCell93 = new TableCell();

            TableCellProperties tableCellProperties93 = new TableCellProperties();
            TableCellWidth tableCellWidth93 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders93 = new TableCellBorders();
            TopBorder topBorder93 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder93 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder93 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder93 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders93.Append(topBorder93);
            tableCellBorders93.Append(leftBorder93);
            tableCellBorders93.Append(bottomBorder93);
            tableCellBorders93.Append(rightBorder93);
            Shading shading93 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin93 = new TableCellMargin();
            TopMargin topMargin118 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin93 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin118 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin93 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin93.Append(topMargin118);
            tableCellMargin93.Append(leftMargin93);
            tableCellMargin93.Append(bottomMargin118);
            tableCellMargin93.Append(rightMargin93);

            tableCellProperties93.Append(tableCellWidth93);
            tableCellProperties93.Append(tableCellBorders93);
            tableCellProperties93.Append(shading93);
            tableCellProperties93.Append(tableCellMargin93);

            Paragraph paragraph117 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties117 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId117 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification71 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties117 = new ParagraphMarkRunProperties();
            RunFonts runFonts218 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold58 = new Bold();
            FontSize fontSize218 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties117.Append(runFonts218);
            paragraphMarkRunProperties117.Append(bold58);
            paragraphMarkRunProperties117.Append(fontSize218);

            paragraphProperties117.Append(paragraphStyleId117);
            paragraphProperties117.Append(justification71);
            paragraphProperties117.Append(paragraphMarkRunProperties117);

            Run run102 = new Run();

            RunProperties runProperties102 = new RunProperties();
            RunFonts runFonts219 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold59 = new Bold();
            FontSize fontSize219 = new FontSize() { Val = "24" };

            runProperties102.Append(runFonts219);
            runProperties102.Append(bold59);
            runProperties102.Append(fontSize219);
            Text text102 = new Text();
            text102.Text = "Selected Values";

            run102.Append(runProperties102);
            run102.Append(text102);

            paragraph117.Append(paragraphProperties117);
            paragraph117.Append(run102);

            tableCell93.Append(tableCellProperties93);
            tableCell93.Append(paragraph117);

            tableRow25.Append(tablePropertyExceptions25);
            tableRow25.Append(tableCell92);
            tableRow25.Append(tableCell93);

            TableRow tableRow26 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions26 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault34 = new TableCellMarginDefault();
            TopMargin topMargin119 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin119 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault34.Append(topMargin119);
            tableCellMarginDefault34.Append(bottomMargin119);

            tablePropertyExceptions26.Append(tableCellMarginDefault34);

            TableCell tableCell94 = new TableCell();

            TableCellProperties tableCellProperties94 = new TableCellProperties();
            TableCellWidth tableCellWidth94 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders94 = new TableCellBorders();
            TopBorder topBorder94 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder94 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder94 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder94 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders94.Append(topBorder94);
            tableCellBorders94.Append(leftBorder94);
            tableCellBorders94.Append(bottomBorder94);
            tableCellBorders94.Append(rightBorder94);
            Shading shading94 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin94 = new TableCellMargin();
            TopMargin topMargin120 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin94 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin120 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin94 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin94.Append(topMargin120);
            tableCellMargin94.Append(leftMargin94);
            tableCellMargin94.Append(bottomMargin120);
            tableCellMargin94.Append(rightMargin94);

            tableCellProperties94.Append(tableCellWidth94);
            tableCellProperties94.Append(tableCellBorders94);
            tableCellProperties94.Append(shading94);
            tableCellProperties94.Append(tableCellMargin94);

            Paragraph paragraph118 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties118 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId118 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification72 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties118 = new ParagraphMarkRunProperties();
            RunFonts runFonts220 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize220 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties118.Append(runFonts220);
            paragraphMarkRunProperties118.Append(fontSize220);

            paragraphProperties118.Append(paragraphStyleId118);
            paragraphProperties118.Append(justification72);
            paragraphProperties118.Append(paragraphMarkRunProperties118);

            Run run103 = new Run();

            RunProperties runProperties103 = new RunProperties();
            RunFonts runFonts221 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize221 = new FontSize() { Val = "24" };

            runProperties103.Append(runFonts221);
            runProperties103.Append(fontSize221);
            Text text103 = new Text();
            text103.Text = "Areas";

            run103.Append(runProperties103);
            run103.Append(text103);

            paragraph118.Append(paragraphProperties118);
            paragraph118.Append(run103);

            tableCell94.Append(tableCellProperties94);
            tableCell94.Append(paragraph118);

            TableCell tableCell95 = new TableCell();

            TableCellProperties tableCellProperties95 = new TableCellProperties();
            TableCellWidth tableCellWidth95 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders95 = new TableCellBorders();
            TopBorder topBorder95 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder95 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder95 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder95 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders95.Append(topBorder95);
            tableCellBorders95.Append(leftBorder95);
            tableCellBorders95.Append(bottomBorder95);
            tableCellBorders95.Append(rightBorder95);
            Shading shading95 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin95 = new TableCellMargin();
            TopMargin topMargin121 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin95 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin121 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin95 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin95.Append(topMargin121);
            tableCellMargin95.Append(leftMargin95);
            tableCellMargin95.Append(bottomMargin121);
            tableCellMargin95.Append(rightMargin95);

            tableCellProperties95.Append(tableCellWidth95);
            tableCellProperties95.Append(tableCellBorders95);
            tableCellProperties95.Append(shading95);
            tableCellProperties95.Append(tableCellMargin95);

            Paragraph paragraph119 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties119 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId119 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification73 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties119 = new ParagraphMarkRunProperties();
            RunFonts runFonts222 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize222 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties119.Append(runFonts222);
            paragraphMarkRunProperties119.Append(fontSize222);

            paragraphProperties119.Append(paragraphStyleId119);
            paragraphProperties119.Append(justification73);
            paragraphProperties119.Append(paragraphMarkRunProperties119);

            Run run104 = new Run();

            RunProperties runProperties104 = new RunProperties();
            RunFonts runFonts223 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize223 = new FontSize() { Val = "24" };

            runProperties104.Append(runFonts223);
            runProperties104.Append(fontSize223);
            Text text104 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text104.Text = "Holmewood Felcourt, Holmewood Landsholme, Holmewood Stirling ";

            run104.Append(runProperties104);
            run104.Append(text104);

            paragraph119.Append(paragraphProperties119);
            paragraph119.Append(run104);

            tableCell95.Append(tableCellProperties95);
            tableCell95.Append(paragraph119);

            tableRow26.Append(tablePropertyExceptions26);
            tableRow26.Append(tableCell94);
            tableRow26.Append(tableCell95);

            TableRow tableRow27 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions27 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault35 = new TableCellMarginDefault();
            TopMargin topMargin122 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin122 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault35.Append(topMargin122);
            tableCellMarginDefault35.Append(bottomMargin122);

            tablePropertyExceptions27.Append(tableCellMarginDefault35);

            TableCell tableCell96 = new TableCell();

            TableCellProperties tableCellProperties96 = new TableCellProperties();
            TableCellWidth tableCellWidth96 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders96 = new TableCellBorders();
            TopBorder topBorder96 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder96 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder96 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder96 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders96.Append(topBorder96);
            tableCellBorders96.Append(leftBorder96);
            tableCellBorders96.Append(bottomBorder96);
            tableCellBorders96.Append(rightBorder96);
            Shading shading96 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin96 = new TableCellMargin();
            TopMargin topMargin123 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin96 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin123 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin96 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin96.Append(topMargin123);
            tableCellMargin96.Append(leftMargin96);
            tableCellMargin96.Append(bottomMargin123);
            tableCellMargin96.Append(rightMargin96);

            tableCellProperties96.Append(tableCellWidth96);
            tableCellProperties96.Append(tableCellBorders96);
            tableCellProperties96.Append(shading96);
            tableCellProperties96.Append(tableCellMargin96);

            Paragraph paragraph120 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties120 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId120 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification74 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties120 = new ParagraphMarkRunProperties();
            RunFonts runFonts224 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize224 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties120.Append(runFonts224);
            paragraphMarkRunProperties120.Append(fontSize224);

            paragraphProperties120.Append(paragraphStyleId120);
            paragraphProperties120.Append(justification74);
            paragraphProperties120.Append(paragraphMarkRunProperties120);

            Run run105 = new Run();

            RunProperties runProperties105 = new RunProperties();
            RunFonts runFonts225 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize225 = new FontSize() { Val = "24" };

            runProperties105.Append(runFonts225);
            runProperties105.Append(fontSize225);
            Text text105 = new Text();
            text105.Text = "Types";

            run105.Append(runProperties105);
            run105.Append(text105);

            paragraph120.Append(paragraphProperties120);
            paragraph120.Append(run105);

            tableCell96.Append(tableCellProperties96);
            tableCell96.Append(paragraph120);

            TableCell tableCell97 = new TableCell();

            TableCellProperties tableCellProperties97 = new TableCellProperties();
            TableCellWidth tableCellWidth97 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders97 = new TableCellBorders();
            TopBorder topBorder97 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder97 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder97 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder97 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders97.Append(topBorder97);
            tableCellBorders97.Append(leftBorder97);
            tableCellBorders97.Append(bottomBorder97);
            tableCellBorders97.Append(rightBorder97);
            Shading shading97 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin97 = new TableCellMargin();
            TopMargin topMargin124 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin97 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin124 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin97 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin97.Append(topMargin124);
            tableCellMargin97.Append(leftMargin97);
            tableCellMargin97.Append(bottomMargin124);
            tableCellMargin97.Append(rightMargin97);

            tableCellProperties97.Append(tableCellWidth97);
            tableCellProperties97.Append(tableCellBorders97);
            tableCellProperties97.Append(shading97);
            tableCellProperties97.Append(tableCellMargin97);

            Paragraph paragraph121 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties121 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId121 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification75 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties121 = new ParagraphMarkRunProperties();
            RunFonts runFonts226 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize226 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties121.Append(runFonts226);
            paragraphMarkRunProperties121.Append(fontSize226);

            paragraphProperties121.Append(paragraphStyleId121);
            paragraphProperties121.Append(justification75);
            paragraphProperties121.Append(paragraphMarkRunProperties121);

            Run run106 = new Run();

            RunProperties runProperties106 = new RunProperties();
            RunFonts runFonts227 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize227 = new FontSize() { Val = "24" };

            runProperties106.Append(runFonts227);
            runProperties106.Append(fontSize227);
            Text text106 = new Text();
            text106.Text = "House";

            run106.Append(runProperties106);
            run106.Append(text106);

            paragraph121.Append(paragraphProperties121);
            paragraph121.Append(run106);

            tableCell97.Append(tableCellProperties97);
            tableCell97.Append(paragraph121);

            tableRow27.Append(tablePropertyExceptions27);
            tableRow27.Append(tableCell96);
            tableRow27.Append(tableCell97);

            TableRow tableRow28 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions28 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault36 = new TableCellMarginDefault();
            TopMargin topMargin125 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin125 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault36.Append(topMargin125);
            tableCellMarginDefault36.Append(bottomMargin125);

            tablePropertyExceptions28.Append(tableCellMarginDefault36);

            TableCell tableCell98 = new TableCell();

            TableCellProperties tableCellProperties98 = new TableCellProperties();
            TableCellWidth tableCellWidth98 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders98 = new TableCellBorders();
            TopBorder topBorder98 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder98 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder98 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder98 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders98.Append(topBorder98);
            tableCellBorders98.Append(leftBorder98);
            tableCellBorders98.Append(bottomBorder98);
            tableCellBorders98.Append(rightBorder98);
            Shading shading98 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin98 = new TableCellMargin();
            TopMargin topMargin126 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin98 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin126 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin98 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin98.Append(topMargin126);
            tableCellMargin98.Append(leftMargin98);
            tableCellMargin98.Append(bottomMargin126);
            tableCellMargin98.Append(rightMargin98);

            tableCellProperties98.Append(tableCellWidth98);
            tableCellProperties98.Append(tableCellBorders98);
            tableCellProperties98.Append(shading98);
            tableCellProperties98.Append(tableCellMargin98);

            Paragraph paragraph122 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties122 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId122 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification76 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties122 = new ParagraphMarkRunProperties();
            RunFonts runFonts228 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize228 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties122.Append(runFonts228);
            paragraphMarkRunProperties122.Append(fontSize228);

            paragraphProperties122.Append(paragraphStyleId122);
            paragraphProperties122.Append(justification76);
            paragraphProperties122.Append(paragraphMarkRunProperties122);

            Run run107 = new Run();

            RunProperties runProperties107 = new RunProperties();
            RunFonts runFonts229 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize229 = new FontSize() { Val = "24" };

            runProperties107.Append(runFonts229);
            runProperties107.Append(fontSize229);
            Text text107 = new Text();
            text107.Text = "Size";

            run107.Append(runProperties107);
            run107.Append(text107);

            paragraph122.Append(paragraphProperties122);
            paragraph122.Append(run107);

            tableCell98.Append(tableCellProperties98);
            tableCell98.Append(paragraph122);

            TableCell tableCell99 = new TableCell();

            TableCellProperties tableCellProperties99 = new TableCellProperties();
            TableCellWidth tableCellWidth99 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders99 = new TableCellBorders();
            TopBorder topBorder99 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder99 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder99 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder99 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders99.Append(topBorder99);
            tableCellBorders99.Append(leftBorder99);
            tableCellBorders99.Append(bottomBorder99);
            tableCellBorders99.Append(rightBorder99);
            Shading shading99 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin99 = new TableCellMargin();
            TopMargin topMargin127 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin99 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin127 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin99 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin99.Append(topMargin127);
            tableCellMargin99.Append(leftMargin99);
            tableCellMargin99.Append(bottomMargin127);
            tableCellMargin99.Append(rightMargin99);

            tableCellProperties99.Append(tableCellWidth99);
            tableCellProperties99.Append(tableCellBorders99);
            tableCellProperties99.Append(shading99);
            tableCellProperties99.Append(tableCellMargin99);

            Paragraph paragraph123 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties123 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId123 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification77 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties123 = new ParagraphMarkRunProperties();
            RunFonts runFonts230 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize230 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties123.Append(runFonts230);
            paragraphMarkRunProperties123.Append(fontSize230);

            paragraphProperties123.Append(paragraphStyleId123);
            paragraphProperties123.Append(justification77);
            paragraphProperties123.Append(paragraphMarkRunProperties123);

            Run run108 = new Run();

            RunProperties runProperties108 = new RunProperties();
            RunFonts runFonts231 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize231 = new FontSize() { Val = "24" };

            runProperties108.Append(runFonts231);
            runProperties108.Append(fontSize231);
            Text text108 = new Text();
            text108.Text = "3 Bedrooms";

            run108.Append(runProperties108);
            run108.Append(text108);

            paragraph123.Append(paragraphProperties123);
            paragraph123.Append(run108);

            tableCell99.Append(tableCellProperties99);
            tableCell99.Append(paragraph123);

            tableRow28.Append(tablePropertyExceptions28);
            tableRow28.Append(tableCell98);
            tableRow28.Append(tableCell99);

            TableRow tableRow29 = new TableRow() { RsidTableRowAddition = "00B67984" };

            TablePropertyExceptions tablePropertyExceptions29 = new TablePropertyExceptions();

            TableCellMarginDefault tableCellMarginDefault37 = new TableCellMarginDefault();
            TopMargin topMargin128 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin128 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

            tableCellMarginDefault37.Append(topMargin128);
            tableCellMarginDefault37.Append(bottomMargin128);

            tablePropertyExceptions29.Append(tableCellMarginDefault37);

            TableCell tableCell100 = new TableCell();

            TableCellProperties tableCellProperties100 = new TableCellProperties();
            TableCellWidth tableCellWidth100 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders100 = new TableCellBorders();
            TopBorder topBorder100 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder100 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder100 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder100 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders100.Append(topBorder100);
            tableCellBorders100.Append(leftBorder100);
            tableCellBorders100.Append(bottomBorder100);
            tableCellBorders100.Append(rightBorder100);
            Shading shading100 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin100 = new TableCellMargin();
            TopMargin topMargin129 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin100 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin129 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin100 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin100.Append(topMargin129);
            tableCellMargin100.Append(leftMargin100);
            tableCellMargin100.Append(bottomMargin129);
            tableCellMargin100.Append(rightMargin100);

            tableCellProperties100.Append(tableCellWidth100);
            tableCellProperties100.Append(tableCellBorders100);
            tableCellProperties100.Append(shading100);
            tableCellProperties100.Append(tableCellMargin100);

            Paragraph paragraph124 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties124 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId124 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification78 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties124 = new ParagraphMarkRunProperties();
            RunFonts runFonts232 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize232 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties124.Append(runFonts232);
            paragraphMarkRunProperties124.Append(fontSize232);

            paragraphProperties124.Append(paragraphStyleId124);
            paragraphProperties124.Append(justification78);
            paragraphProperties124.Append(paragraphMarkRunProperties124);

            Run run109 = new Run();

            RunProperties runProperties109 = new RunProperties();
            RunFonts runFonts233 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize233 = new FontSize() { Val = "24" };

            runProperties109.Append(runFonts233);
            runProperties109.Append(fontSize233);
            Text text109 = new Text();
            text109.Text = "Dates";

            run109.Append(runProperties109);
            run109.Append(text109);

            paragraph124.Append(paragraphProperties124);
            paragraph124.Append(run109);

            tableCell100.Append(tableCellProperties100);
            tableCell100.Append(paragraph124);

            TableCell tableCell101 = new TableCell();

            TableCellProperties tableCellProperties101 = new TableCellProperties();
            TableCellWidth tableCellWidth101 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders101 = new TableCellBorders();
            TopBorder topBorder101 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder101 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder101 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder101 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders101.Append(topBorder101);
            tableCellBorders101.Append(leftBorder101);
            tableCellBorders101.Append(bottomBorder101);
            tableCellBorders101.Append(rightBorder101);
            Shading shading101 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            TableCellMargin tableCellMargin101 = new TableCellMargin();
            TopMargin topMargin130 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            LeftMargin leftMargin101 = new LeftMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };
            BottomMargin bottomMargin130 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
            RightMargin rightMargin101 = new RightMargin() { Width = "108", Type = TableWidthUnitValues.Dxa };

            tableCellMargin101.Append(topMargin130);
            tableCellMargin101.Append(leftMargin101);
            tableCellMargin101.Append(bottomMargin130);
            tableCellMargin101.Append(rightMargin101);

            tableCellProperties101.Append(tableCellWidth101);
            tableCellProperties101.Append(tableCellBorders101);
            tableCellProperties101.Append(shading101);
            tableCellProperties101.Append(tableCellMargin101);

            Paragraph paragraph125 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties125 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId125 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification79 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties125 = new ParagraphMarkRunProperties();
            RunFonts runFonts234 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize234 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties125.Append(runFonts234);
            paragraphMarkRunProperties125.Append(fontSize234);

            paragraphProperties125.Append(paragraphStyleId125);
            paragraphProperties125.Append(justification79);
            paragraphProperties125.Append(paragraphMarkRunProperties125);

            Run run110 = new Run();

            RunProperties runProperties110 = new RunProperties();
            RunFonts runFonts235 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize235 = new FontSize() { Val = "24" };

            runProperties110.Append(runFonts235);
            runProperties110.Append(fontSize235);
            Text text110 = new Text();
            text110.Text = "Looking to move between Tue 24/Feb/2015 and Sun 19/Feb/2017";

            run110.Append(runProperties110);
            run110.Append(text110);

            paragraph125.Append(paragraphProperties125);
            paragraph125.Append(run110);

            tableCell101.Append(tableCellProperties101);
            tableCell101.Append(paragraph125);

            tableRow29.Append(tablePropertyExceptions29);
            tableRow29.Append(tableCell100);
            tableRow29.Append(tableCell101);

            table8.Append(tableProperties8);
            table8.Append(tableGrid8);
            table8.Append(tableRow25);
            table8.Append(tableRow26);
            table8.Append(tableRow27);
            table8.Append(tableRow28);
            table8.Append(tableRow29);

            Paragraph paragraph126 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties126 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId126 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties126 = new ParagraphMarkRunProperties();
            RunFonts runFonts236 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize236 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties126.Append(runFonts236);
            paragraphMarkRunProperties126.Append(fontSize236);

            paragraphProperties126.Append(paragraphStyleId126);
            paragraphProperties126.Append(paragraphMarkRunProperties126);

            paragraph126.Append(paragraphProperties126);

            Paragraph paragraph127 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties127 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId127 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties127 = new ParagraphMarkRunProperties();
            RunFonts runFonts237 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize237 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties127.Append(runFonts237);
            paragraphMarkRunProperties127.Append(fontSize237);

            paragraphProperties127.Append(paragraphStyleId127);
            paragraphProperties127.Append(paragraphMarkRunProperties127);

            paragraph127.Append(paragraphProperties127);

            Paragraph paragraph128 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties128 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId128 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties128 = new ParagraphMarkRunProperties();
            RunFonts runFonts238 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize238 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties128.Append(runFonts238);
            paragraphMarkRunProperties128.Append(fontSize238);

            paragraphProperties128.Append(paragraphStyleId128);
            paragraphProperties128.Append(paragraphMarkRunProperties128);

            paragraph128.Append(paragraphProperties128);

            Paragraph paragraph129 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties129 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId129 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties129 = new ParagraphMarkRunProperties();
            RunFonts runFonts239 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold60 = new Bold();
            FontSize fontSize239 = new FontSize() { Val = "24" };
            Underline underline1 = new Underline() { Val = UnderlineValues.Single };

            paragraphMarkRunProperties129.Append(runFonts239);
            paragraphMarkRunProperties129.Append(bold60);
            paragraphMarkRunProperties129.Append(fontSize239);
            paragraphMarkRunProperties129.Append(underline1);

            paragraphProperties129.Append(paragraphStyleId129);
            paragraphProperties129.Append(paragraphMarkRunProperties129);

            Run run111 = new Run();

            RunProperties runProperties111 = new RunProperties();
            RunFonts runFonts240 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold61 = new Bold();
            FontSize fontSize240 = new FontSize() { Val = "24" };
            Underline underline2 = new Underline() { Val = UnderlineValues.Single };

            runProperties111.Append(runFonts240);
            runProperties111.Append(bold61);
            runProperties111.Append(fontSize240);
            runProperties111.Append(underline2);
            Text text111 = new Text();
            text111.Text = "Data Protection Statement";

            run111.Append(runProperties111);
            run111.Append(text111);

            paragraph129.Append(paragraphProperties129);
            paragraph129.Append(run111);

            Paragraph paragraph130 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties130 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId130 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties130 = new ParagraphMarkRunProperties();
            RunFonts runFonts241 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize241 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties130.Append(runFonts241);
            paragraphMarkRunProperties130.Append(fontSize241);

            paragraphProperties130.Append(paragraphStyleId130);
            paragraphProperties130.Append(paragraphMarkRunProperties130);

            Run run112 = new Run();

            RunProperties runProperties112 = new RunProperties();
            RunFonts runFonts242 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize242 = new FontSize() { Val = "24" };

            runProperties112.Append(runFonts242);
            runProperties112.Append(fontSize242);
            Text text112 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text112.Text = "The Council and Incommunities will comply with the Data Protection Act 1998 and any subsequent legislation that may apply. The Council and Incommunities will store the information that you have provided in this application form and use this to provide you with housing, welfare advice, support and associated services. From time to time, we will also use this information for the purpose of improving our services and for producing housing demand and other performance information. ";

            run112.Append(runProperties112);
            run112.Append(text112);

            paragraph130.Append(paragraphProperties130);
            paragraph130.Append(run112);

            Paragraph paragraph131 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties131 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId131 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties131 = new ParagraphMarkRunProperties();
            RunFonts runFonts243 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize243 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties131.Append(runFonts243);
            paragraphMarkRunProperties131.Append(fontSize243);

            paragraphProperties131.Append(paragraphStyleId131);
            paragraphProperties131.Append(paragraphMarkRunProperties131);

            paragraph131.Append(paragraphProperties131);

            Paragraph paragraph132 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties132 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId132 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties132 = new ParagraphMarkRunProperties();
            RunFonts runFonts244 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize244 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties132.Append(runFonts244);
            paragraphMarkRunProperties132.Append(fontSize244);

            paragraphProperties132.Append(paragraphStyleId132);
            paragraphProperties132.Append(paragraphMarkRunProperties132);

            Run run113 = new Run();

            RunProperties runProperties113 = new RunProperties();
            RunFonts runFonts245 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize245 = new FontSize() { Val = "24" };

            runProperties113.Append(runFonts245);
            runProperties113.Append(fontSize245);
            Text text113 = new Text();
            text113.Text = "In order to provide you with these services, the Council and Incommunities will share your data with third party organisations including other local authorities, public sector organisations and providers of housing, support and associated services.";

            run113.Append(runProperties113);
            run113.Append(text113);

            paragraph132.Append(paragraphProperties132);
            paragraph132.Append(run113);

            Paragraph paragraph133 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties133 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId133 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties133 = new ParagraphMarkRunProperties();
            RunFonts runFonts246 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize246 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties133.Append(runFonts246);
            paragraphMarkRunProperties133.Append(fontSize246);

            paragraphProperties133.Append(paragraphStyleId133);
            paragraphProperties133.Append(paragraphMarkRunProperties133);

            paragraph133.Append(paragraphProperties133);

            Paragraph paragraph134 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties134 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId134 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties134 = new ParagraphMarkRunProperties();
            RunFonts runFonts247 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize247 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties134.Append(runFonts247);
            paragraphMarkRunProperties134.Append(fontSize247);

            paragraphProperties134.Append(paragraphStyleId134);
            paragraphProperties134.Append(paragraphMarkRunProperties134);

            Run run114 = new Run();

            RunProperties runProperties114 = new RunProperties();
            RunFonts runFonts248 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize248 = new FontSize() { Val = "24" };

            runProperties114.Append(runFonts248);
            runProperties114.Append(fontSize248);
            Text text114 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text114.Text = "We need your consent to share your information with organisations outside of the Council and Incommunities.  You are able to withdraw your consent at any time by providing written notice to the Data ";

            run114.Append(runProperties114);
            run114.Append(text114);

            Run run115 = new Run();

            RunProperties runProperties115 = new RunProperties();
            RunFonts runFonts249 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize249 = new FontSize() { Val = "24" };

            runProperties115.Append(runFonts249);
            runProperties115.Append(fontSize249);
            LastRenderedPageBreak lastRenderedPageBreak3 = new LastRenderedPageBreak();
            Text text115 = new Text();
            text115.Text = "Protection Team/  Housing Options Team, Bradford Metropolitan District Council, Britannia House, 4th Floor, Hall Ings, Bradford, BD1 1HX.";

            run115.Append(runProperties115);
            run115.Append(lastRenderedPageBreak3);
            run115.Append(text115);

            paragraph134.Append(paragraphProperties134);
            paragraph134.Append(run114);
            paragraph134.Append(run115);

            Paragraph paragraph135 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties135 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId135 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties135 = new ParagraphMarkRunProperties();
            RunFonts runFonts250 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize250 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties135.Append(runFonts250);
            paragraphMarkRunProperties135.Append(fontSize250);

            paragraphProperties135.Append(paragraphStyleId135);
            paragraphProperties135.Append(paragraphMarkRunProperties135);

            paragraph135.Append(paragraphProperties135);

            Paragraph paragraph136 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties136 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId136 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties136 = new ParagraphMarkRunProperties();
            Bold bold62 = new Bold();
            FontSize fontSize251 = new FontSize() { Val = "24" };
            Underline underline3 = new Underline() { Val = UnderlineValues.Single };

            paragraphMarkRunProperties136.Append(bold62);
            paragraphMarkRunProperties136.Append(fontSize251);
            paragraphMarkRunProperties136.Append(underline3);

            paragraphProperties136.Append(paragraphStyleId136);
            paragraphProperties136.Append(paragraphMarkRunProperties136);

            Run run116 = new Run();

            RunProperties runProperties116 = new RunProperties();
            Bold bold63 = new Bold();
            FontSize fontSize252 = new FontSize() { Val = "24" };
            Underline underline4 = new Underline() { Val = UnderlineValues.Single };

            runProperties116.Append(bold63);
            runProperties116.Append(fontSize252);
            runProperties116.Append(underline4);
            Text text116 = new Text();
            text116.Text = "Declaration";

            run116.Append(runProperties116);
            run116.Append(text116);

            paragraph136.Append(paragraphProperties136);
            paragraph136.Append(run116);

            Paragraph paragraph137 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties137 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId137 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties137 = new ParagraphMarkRunProperties();
            RunFonts runFonts251 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize253 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties137.Append(runFonts251);
            paragraphMarkRunProperties137.Append(fontSize253);

            paragraphProperties137.Append(paragraphStyleId137);
            paragraphProperties137.Append(paragraphMarkRunProperties137);

            Run run117 = new Run();

            RunProperties runProperties117 = new RunProperties();
            RunFonts runFonts252 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize254 = new FontSize() { Val = "24" };

            runProperties117.Append(runFonts252);
            runProperties117.Append(fontSize254);
            Text text117 = new Text();
            text117.Text = "I give my consent for Incommunities to share my information with third party organisations and for these organisations to share my information with them in order to provide me with housing, support and associated services and in order to monitor my progress. I understand that my consent will remain valid until such time as I give written notice to withdraw my consent.";

            run117.Append(runProperties117);
            run117.Append(text117);

            paragraph137.Append(paragraphProperties137);
            paragraph137.Append(run117);

            Paragraph paragraph138 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties138 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId138 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties138 = new ParagraphMarkRunProperties();
            RunFonts runFonts253 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize255 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties138.Append(runFonts253);
            paragraphMarkRunProperties138.Append(fontSize255);

            paragraphProperties138.Append(paragraphStyleId138);
            paragraphProperties138.Append(paragraphMarkRunProperties138);

            paragraph138.Append(paragraphProperties138);

            Paragraph paragraph139 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties139 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId139 = new ParagraphStyleId() { Val = "NoSpacing" };

            paragraphProperties139.Append(paragraphStyleId139);

            Run run118 = new Run();

            RunProperties runProperties118 = new RunProperties();
            RunFonts runFonts254 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize256 = new FontSize() { Val = "24" };

            runProperties118.Append(runFonts254);
            runProperties118.Append(fontSize256);
            Text text118 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text118.Text = "Name   ";

            run118.Append(runProperties118);
            run118.Append(text118);

            Run run119 = new Run() { RsidRunProperties = "00053F5B", RsidRunAddition = "00053F5B" };

            RunProperties runProperties119 = new RunProperties();
            RunFonts runFonts255 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize257 = new FontSize() { Val = "24" };
            Underline underline5 = new Underline() { Val = UnderlineValues.Single };

            runProperties119.Append(runFonts255);
            runProperties119.Append(fontSize257);
            runProperties119.Append(underline5);
            Text text119 = new Text();
            text119.Text = "ApplicantNamePlaceHolder";

            run119.Append(runProperties119);
            run119.Append(text119);

            paragraph139.Append(paragraphProperties139);
            paragraph139.Append(run118);
            paragraph139.Append(run119);

            Paragraph paragraph140 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties140 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId140 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties139 = new ParagraphMarkRunProperties();
            RunFonts runFonts256 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize258 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties139.Append(runFonts256);
            paragraphMarkRunProperties139.Append(fontSize258);

            paragraphProperties140.Append(paragraphStyleId140);
            paragraphProperties140.Append(paragraphMarkRunProperties139);

            paragraph140.Append(paragraphProperties140);

            Paragraph paragraph141 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties141 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId141 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties140 = new ParagraphMarkRunProperties();
            RunFonts runFonts257 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize259 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties140.Append(runFonts257);
            paragraphMarkRunProperties140.Append(fontSize259);

            paragraphProperties141.Append(paragraphStyleId141);
            paragraphProperties141.Append(paragraphMarkRunProperties140);

            Run run120 = new Run();

            RunProperties runProperties120 = new RunProperties();
            RunFonts runFonts258 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize260 = new FontSize() { Val = "24" };

            runProperties120.Append(runFonts258);
            runProperties120.Append(fontSize260);
            Text text120 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text120.Text = "Date  _______________ ";

            run120.Append(runProperties120);
            run120.Append(text120);

            paragraph141.Append(paragraphProperties141);
            paragraph141.Append(run120);

            Paragraph paragraph142 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties142 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId142 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties141 = new ParagraphMarkRunProperties();
            RunFonts runFonts259 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize261 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties141.Append(runFonts259);
            paragraphMarkRunProperties141.Append(fontSize261);

            paragraphProperties142.Append(paragraphStyleId142);
            paragraphProperties142.Append(paragraphMarkRunProperties141);

            paragraph142.Append(paragraphProperties142);

            Paragraph paragraph143 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties143 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId143 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties142 = new ParagraphMarkRunProperties();
            RunFonts runFonts260 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize262 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties142.Append(runFonts260);
            paragraphMarkRunProperties142.Append(fontSize262);

            paragraphProperties143.Append(paragraphStyleId143);
            paragraphProperties143.Append(paragraphMarkRunProperties142);

            Run run121 = new Run();

            RunProperties runProperties121 = new RunProperties();
            RunFonts runFonts261 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize263 = new FontSize() { Val = "24" };

            runProperties121.Append(runFonts261);
            runProperties121.Append(fontSize263);
            Text text121 = new Text();
            text121.Text = "Signature  __________________________________________________";

            run121.Append(runProperties121);
            run121.Append(text121);

            paragraph143.Append(paragraphProperties143);
            paragraph143.Append(run121);

            Paragraph paragraph144 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00B67984" };

            ParagraphProperties paragraphProperties144 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId144 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties143 = new ParagraphMarkRunProperties();
            RunFonts runFonts262 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize264 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties143.Append(runFonts262);
            paragraphMarkRunProperties143.Append(fontSize264);

            paragraphProperties144.Append(paragraphStyleId144);
            paragraphProperties144.Append(paragraphMarkRunProperties143);

            paragraph144.Append(paragraphProperties144);

            Paragraph paragraph145 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties145 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId145 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties144 = new ParagraphMarkRunProperties();
            RunFonts runFonts263 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold64 = new Bold();
            FontSize fontSize265 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties144.Append(runFonts263);
            paragraphMarkRunProperties144.Append(bold64);
            paragraphMarkRunProperties144.Append(fontSize265);

            paragraphProperties145.Append(paragraphStyleId145);
            paragraphProperties145.Append(paragraphMarkRunProperties144);

            Run run122 = new Run();

            RunProperties runProperties122 = new RunProperties();
            RunFonts runFonts264 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            Bold bold65 = new Bold();
            FontSize fontSize266 = new FontSize() { Val = "24" };

            runProperties122.Append(runFonts264);
            runProperties122.Append(bold65);
            runProperties122.Append(fontSize266);
            Text text122 = new Text();
            text122.Text = "* Participating Landlords Include:";

            run122.Append(runProperties122);
            run122.Append(text122);

            paragraph145.Append(paragraphProperties145);
            paragraph145.Append(run122);

            Paragraph paragraph146 = new Paragraph() { RsidParagraphAddition = "00B67984", RsidRunAdditionDefault = "00810623" };

            ParagraphProperties paragraphProperties146 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId146 = new ParagraphStyleId() { Val = "NoSpacing" };

            ParagraphMarkRunProperties paragraphMarkRunProperties145 = new ParagraphMarkRunProperties();
            RunFonts runFonts265 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize267 = new FontSize() { Val = "24" };

            paragraphMarkRunProperties145.Append(runFonts265);
            paragraphMarkRunProperties145.Append(fontSize267);

            paragraphProperties146.Append(paragraphStyleId146);
            paragraphProperties146.Append(paragraphMarkRunProperties145);

            Run run123 = new Run();

            RunProperties runProperties123 = new RunProperties();
            RunFonts runFonts266 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
            FontSize fontSize268 = new FontSize() { Val = "24" };

            runProperties123.Append(runFonts266);
            runProperties123.Append(fontSize268);
            Text text123 = new Text();
            text123.Text = "Abbeyfield Bradford Society Ltd, Anchor Trust, Accent Group Ltd, Affinity Sutton, Equity Housing Association, Habinteg Housing Association, Hanover Housing, Headrow Housing Group, Home Group, Housing 21, Incommunities Group Ltd, Jephson Housing Association, Jonny Johnson Housing Association, Manningham Housing Association, Muir Housing Association, Places for People, Sanctuary Housing, The Riverside Group Ltd, Yorkshire Housing";

            run123.Append(runProperties123);
            run123.Append(text123);

            paragraph146.Append(paragraphProperties146);
            paragraph146.Append(run123);

            SectionProperties sectionProperties1 = new SectionProperties() { RsidR = "00B67984" };
            HeaderReference headerReference1 = new HeaderReference() { Type = HeaderFooterValues.First, Id = "rId8" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
            PageMargin pageMargin1 = new PageMargin() { Top = 720, Right = (UInt32Value)720U, Bottom = 720, Left = (UInt32Value)720U, Header = (UInt32Value)567U, Footer = (UInt32Value)283U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "720" };
            TitlePage titlePage1 = new TitlePage();

            sectionProperties1.Append(headerReference1);
            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(titlePage1);

            body1.Append(paragraph1);
            body1.Append(table1);
            body1.Append(paragraph14);
            body1.Append(paragraph15);
            body1.Append(table2);
            body1.Append(paragraph53);
            body1.Append(paragraph54);
            body1.Append(table3);
            body1.Append(paragraph63);
            body1.Append(paragraph64);
            body1.Append(table4);
            body1.Append(paragraph79);
            body1.Append(paragraph80);
            body1.Append(table5);
            body1.Append(paragraph85);
            body1.Append(paragraph86);
            body1.Append(paragraph87);
            body1.Append(table6);
            body1.Append(paragraph94);
            body1.Append(paragraph95);
            body1.Append(paragraph96);
            body1.Append(table7);
            body1.Append(paragraph112);
            body1.Append(paragraph113);
            body1.Append(paragraph114);
            body1.Append(paragraph115);
            body1.Append(table8);
            body1.Append(paragraph126);
            body1.Append(paragraph127);
            body1.Append(paragraph128);
            body1.Append(paragraph129);
            body1.Append(paragraph130);
            body1.Append(paragraph131);
            body1.Append(paragraph132);
            body1.Append(paragraph133);
            body1.Append(paragraph134);
            body1.Append(paragraph135);
            body1.Append(paragraph136);
            body1.Append(paragraph137);
            body1.Append(paragraph138);
            body1.Append(paragraph139);
            body1.Append(paragraph140);
            body1.Append(paragraph141);
            body1.Append(paragraph142);
            body1.Append(paragraph143);
            body1.Append(paragraph144);
            body1.Append(paragraph145);
            body1.Append(paragraph146);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

    }
}
