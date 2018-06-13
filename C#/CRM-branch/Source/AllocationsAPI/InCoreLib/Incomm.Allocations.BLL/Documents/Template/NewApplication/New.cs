using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using A = DocumentFormat.OpenXml.Drawing;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Service.Api.DTOs;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.DTO;
using InCoreLib.Service.Api.Service;
using Newtonsoft.Json;

namespace GeneratedCode
{
    //public class NewApplication: GatewayAPIClient
    //{
    //    private VBLApplication _vblApplication;
    //    private VBLDocumentDTO _documentDto;
    //    private VBLContact _mainApplicant;
    //    private string _addressLine1;
    //    private string _addressLine2;
    //    private string _addressCity;
    //    private string _addressPostcode;
    //    private string _mainApplicantName;
    //    private string _propertyRequirementAreas;
    //    private List<string> _propertyNeighbourhoodIds;
    //    private string _propertyRequirementTypes;
    //    private string _propertyRequirementSize;
    //    private string _propertyRequirementDates;
    //    private string _customerCircumstancesResidencyType;
    //    private string _customerCircumstancesCurrentAddress;
    //    private string _customerCircumstancesDuration;
    //    private string _customerCircumstancesReasonforMoving;
    //    decimal _incomePerMonth = 0;
    //    List<VBLContactByDetails> _contactByDetails = new List<VBLContactByDetails>();
    //    public NewApplication(VBLApplication vblApplication, VBLDocumentDTO documentDto)
    //    {
    //        _vblApplication = vblApplication;
    //        _documentDto = documentDto;
    //        _mainApplicant = _vblApplication.Contacts.First(x => x.ContactTypeId == 1);
    //        _addressLine1 = _vblApplication.Address != null ? _vblApplication.Address.AddressLine1 : "";
    //        _addressLine2 = _vblApplication.Address != null ? _vblApplication.Address.AddressLine2 : "";
    //        _addressCity = _vblApplication.Address != null ? _vblApplication.Address.AddressLine3 : "";
    //        _addressPostcode = _vblApplication.Address != null ? _vblApplication.Address.PostCode : "";
    //        _mainApplicantName = _mainApplicant.Forename + " " + _mainApplicant.Surname;
    //        _customerCircumstancesResidencyType = vblApplication.ResidencyType==null?string.Empty:vblApplication.ResidencyType.Name;
    //        _customerCircumstancesCurrentAddress = _addressLine1 + " " + _addressLine2 + " " + _addressCity + " " + _addressPostcode;
    //        _customerCircumstancesDuration = "Has lived at address for " + new DateDifference(vblApplication.ApplicationDate, vblApplication.DateMovedIn.HasValue ? vblApplication.DateMovedIn.Value : vblApplication.ApplicationDate).ToString();
    //        _customerCircumstancesReasonforMoving = vblApplication.MoveReason == null ? string.Empty : vblApplication.MoveReason.Name;
    //        if (vblApplication.VBLRequestedPropertymatchDetail != null)
    //        {
    //            if (vblApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods != null 
    //                && vblApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.Any()
    //                && vblApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.FirstOrDefault(x => x.IsCurrent) != null 
    //                && vblApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.First(x => x.IsCurrent).RequestedPropertyPrefferedNeighbourhoodDetails != null)
    //            {
    //                _propertyNeighbourhoodIds = vblApplication.VBLRequestedPropertymatchDetail.RequestedPropertyPrefferedNeighbourhoods.First(x => x.IsCurrent).RequestedPropertyPrefferedNeighbourhoodDetails.Select(x => x.NeighbourhoodId.ToString()).ToList();
    //                _propertyRequirementAreas = string.Join(",",GetPropertyNeighbourhood(_propertyNeighbourhoodIds).Select(x => x.Name));
    //            }
    //            if (vblApplication.VBLRequestedPropertymatchDetail.PropertyTypes != null)
    //            {
    //                _propertyRequirementTypes = string.Join(", ", vblApplication.VBLRequestedPropertymatchDetail.PropertyTypes.Select(x => x.PropertyType.Name));
    //            }
    //            if (vblApplication.VBLRequestedPropertymatchDetail.PropertySizes != null)
    //            {
    //                _propertyRequirementSize = string.Join(", ", vblApplication.VBLRequestedPropertymatchDetail.PropertySizes.Select(x => x.PropertySize.Name));
    //            }
    //            if ( vblApplication.VBLRequestedPropertymatchDetail.StartDate.HasValue && vblApplication.VBLRequestedPropertymatchDetail.EndDate.HasValue)
    //            {
    //                _propertyRequirementDates = string.Format("Looking to move between {0} and {1} ", vblApplication.VBLRequestedPropertymatchDetail.StartDate.Value.ToString("D"), vblApplication.VBLRequestedPropertymatchDetail.EndDate.Value.ToString("D"));
    //            }
    //        }
         
    //        GetIncomePerMonth(vblApplication);
    //        GetContactByDetails();
    //    }

       
    //    private void GetContactByDetails()
    //    {
    //        foreach (var contact in _vblApplication.Contacts)
    //        {
    //            var contactDetails = _contactByDetails.Select(x => x.ContactValue).ToArray();
    //            _contactByDetails.AddRange(contact.ContactByDetails.Where(x => !contactDetails.Contains(x.ContactValue)));
    //        }
    //    }

    //    private void GetIncomePerMonth(VBLApplication vblApplication)
    //    {
    //        var incomeDetails = new List<VBLIncomeDetail>();
    //        decimal incomePerMonth = 0;
    //        foreach (var vblContact in vblApplication.Contacts)
    //        {
    //            incomeDetails.AddRange(vblContact.IncomeDetails);
    //        }
    //        foreach (var incomeDetail in incomeDetails)
    //        {
    //            switch (incomeDetail.IncomeFrequencyId)
    //            {
    //                case 1://Weekly
    //                    incomePerMonth = (incomeDetail.Amount * 52 / 12) + incomePerMonth;
    //                    break;
    //                case 2://Monthly
    //                    incomePerMonth = incomeDetail.Amount + _incomePerMonth;
    //                    break;
    //                case 3://Fortnightly
    //                    incomePerMonth = (incomeDetail.Amount * 26 / 12) + incomePerMonth;
    //                    break;
    //                case 4://4 Weekly
    //                    incomePerMonth = (incomeDetail.Amount * 13 / 12) + incomePerMonth;
    //                    break;
    //                case 5://Annual
    //                    incomePerMonth = (incomeDetail.Amount / 12) + incomePerMonth;
    //                    break;
    //            }
    //        }
    //        _incomePerMonth = incomePerMonth;
    //    }
    //    // Creates a WordprocessingDocument.
    //    public void CreatePackage(string filePath)
    //    {
    //        using (var package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
    //        {
    //            CreateParts(package);
    //        }
    //    }

    //    // Adds child parts and generates content of the specified part.
    //    private void CreateParts(WordprocessingDocument document)
    //    {
    //        var extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
    //        GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

    //        var mainDocumentPart1 = document.AddMainDocumentPart();
    //        GenerateMainDocumentPart1Content(mainDocumentPart1);

    //        var footerPart1 = mainDocumentPart1.AddNewPart<FooterPart>("rId8");
    //        GenerateFooterPart1Content(footerPart1);

    //        var documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId3");
    //        GenerateDocumentSettingsPart1Content(documentSettingsPart1);

    //        var footerPart2 = mainDocumentPart1.AddNewPart<FooterPart>("rId7");
    //        GenerateFooterPart2Content(footerPart2);

    //        var themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId12");
    //        GenerateThemePart1Content(themePart1);

    //        var stylesWithEffectsPart1 = mainDocumentPart1.AddNewPart<StylesWithEffectsPart>("rId2");
    //        GenerateStylesWithEffectsPart1Content(stylesWithEffectsPart1);

    //        var styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
    //        GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

    //        var headerPart1 = mainDocumentPart1.AddNewPart<HeaderPart>("rId6");
    //        GenerateHeaderPart1Content(headerPart1);

    //        var fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId11");
    //        GenerateFontTablePart1Content(fontTablePart1);

    //        var headerPart2 = mainDocumentPart1.AddNewPart<HeaderPart>("rId5");
    //        GenerateHeaderPart2Content(headerPart2);

    //        var footerPart3 = mainDocumentPart1.AddNewPart<FooterPart>("rId10");
    //        GenerateFooterPart3Content(footerPart3);

    //        var webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId4");
    //        GenerateWebSettingsPart1Content(webSettingsPart1);

    //        var headerPart3 = mainDocumentPart1.AddNewPart<HeaderPart>("rId9");
    //        GenerateHeaderPart3Content(headerPart3);

    //        var imagePart1 = headerPart3.AddNewPart<ImagePart>("image/jpeg", "rId1");
    //        GenerateImagePart1Content(imagePart1);

    //        SetPackageProperties(document);
    //    }

    //    // Generates content of extendedFilePropertiesPart1.
    //    private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
    //    {
    //        var properties1 = new Ap.Properties();
    //        properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
    //        var template1 = new Ap.Template();
    //        template1.Text = "Normal.dotm";
    //        var totalTime1 = new Ap.TotalTime();
    //        totalTime1.Text = "0";
    //        var pages1 = new Ap.Pages();
    //        pages1.Text = "3";
    //        var words1 = new Ap.Words();
    //        words1.Text = "528";
    //        var characters1 = new Ap.Characters();
    //        characters1.Text = "3014";
    //        var application1 = new Ap.Application();
    //        application1.Text = "Microsoft Office Word";
    //        var documentSecurity1 = new Ap.DocumentSecurity();
    //        documentSecurity1.Text = "0";
    //        var lines1 = new Ap.Lines();
    //        lines1.Text = "25";
    //        var paragraphs1 = new Ap.Paragraphs();
    //        paragraphs1.Text = "7";
    //        var scaleCrop1 = new Ap.ScaleCrop();
    //        scaleCrop1.Text = "false";

    //        var headingPairs1 = new Ap.HeadingPairs();

    //        var vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

    //        var variant1 = new Vt.Variant();
    //        var vTLPSTR1 = new Vt.VTLPSTR();
    //        vTLPSTR1.Text = "Title";

    //        variant1.Append(vTLPSTR1);

    //        var variant2 = new Vt.Variant();
    //        var vTInt321 = new Vt.VTInt32();
    //        vTInt321.Text = "1";

    //        variant2.Append(vTInt321);

    //        vTVector1.Append(variant1);
    //        vTVector1.Append(variant2);

    //        headingPairs1.Append(vTVector1);

    //        var titlesOfParts1 = new Ap.TitlesOfParts();

    //        var vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
    //        var vTLPSTR2 = new Vt.VTLPSTR();
    //        vTLPSTR2.Text = "";

    //        vTVector2.Append(vTLPSTR2);

    //        titlesOfParts1.Append(vTVector2);
    //        var company1 = new Ap.Company();
    //        company1.Text = "Microsoft";
    //        var linksUpToDate1 = new Ap.LinksUpToDate();
    //        linksUpToDate1.Text = "false";
    //        var charactersWithSpaces1 = new Ap.CharactersWithSpaces();
    //        charactersWithSpaces1.Text = "3535";
    //        var sharedDocument1 = new Ap.SharedDocument();
    //        sharedDocument1.Text = "false";
    //        var hyperlinksChanged1 = new Ap.HyperlinksChanged();
    //        hyperlinksChanged1.Text = "false";
    //        var applicationVersion1 = new Ap.ApplicationVersion();
    //        applicationVersion1.Text = "14.0000";

    //        properties1.Append(template1);
    //        properties1.Append(totalTime1);
    //        properties1.Append(pages1);
    //        properties1.Append(words1);
    //        properties1.Append(characters1);
    //        properties1.Append(application1);
    //        properties1.Append(documentSecurity1);
    //        properties1.Append(lines1);
    //        properties1.Append(paragraphs1);
    //        properties1.Append(scaleCrop1);
    //        properties1.Append(headingPairs1);
    //        properties1.Append(titlesOfParts1);
    //        properties1.Append(company1);
    //        properties1.Append(linksUpToDate1);
    //        properties1.Append(charactersWithSpaces1);
    //        properties1.Append(sharedDocument1);
    //        properties1.Append(hyperlinksChanged1);
    //        properties1.Append(applicationVersion1);

    //        extendedFilePropertiesPart1.Properties = properties1;
    //    }

    //    // Generates content of mainDocumentPart1.
    //    private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
    //    {

    //        var document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var body1 = new Body();

    //        Table table1;
    //        Table table2;
    //        var paragraph15 = new Paragraph();
    //        var paragraph53 = new Paragraph();
    //        var paragraph1 = CreateApplicationDetails(out table1);
    //        var paragraph14 = CreateSummaryOfHouseholdDetails(out table2, out paragraph15, out paragraph53);


    //        var paragraph54 = new Paragraph() { RsidParagraphMarkRevision = "00B46F26", RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var table3 = CreateContactInformations(paragraph54);

    //        var paragraph63 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties63 = new ParagraphProperties();
    //        var paragraphStyleId63 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties63 = new ParagraphMarkRunProperties();
    //        var runFonts120 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize120 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties63.Append(runFonts120);
    //        paragraphMarkRunProperties63.Append(fontSize120);

    //        paragraphProperties63.Append(paragraphStyleId63);
    //        paragraphProperties63.Append(paragraphMarkRunProperties63);

    //        paragraph63.Append(paragraphProperties63);

    //        Table table4;
    //        var paragraph64 = AddCustomerCircumtances(out table4);

    //        Paragraph paragraph80;
    //        Table table5;
    //        var paragraph79 = AddIncomeSummary(out paragraph80, out table5);

    //        var paragraph85 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties85 = new ParagraphProperties();
    //        var paragraphStyleId85 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties85 = new ParagraphMarkRunProperties();
    //        var runFonts162 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize162 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties85.Append(runFonts162);
    //        paragraphMarkRunProperties85.Append(fontSize162);

    //        paragraphProperties85.Append(paragraphStyleId85);
    //        paragraphProperties85.Append(paragraphMarkRunProperties85);

    //        paragraph85.Append(paragraphProperties85);

    //        var paragraph86 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties86 = new ParagraphProperties();
    //        var paragraphStyleId86 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties86 = new ParagraphMarkRunProperties();
    //        var runFonts163 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize163 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties86.Append(runFonts163);
    //        paragraphMarkRunProperties86.Append(fontSize163);

    //        paragraphProperties86.Append(paragraphStyleId86);
    //        paragraphProperties86.Append(paragraphMarkRunProperties86);

    //        paragraph86.Append(paragraphProperties86);
    //        var contactByTableList = new List<Table>();
    //        var contactByParagraphList = new List<Paragraph>();
    //        foreach (var contact in _vblApplication.Contacts)
    //        {
    //            if (contact.IncomeDetails.Any())
    //            {
    //                Table table;
    //                var paragraph = AddIncomeDetailsOfHoseholdMembers(out table, contact);
    //                contactByTableList.Add(table);
    //                contactByParagraphList.Add(paragraph);
    //            }
    //        }

    //        Paragraph paragraph113;
    //        Paragraph paragraph114;
    //        Paragraph paragraph115;
    //        Table table8;
    //        var paragraph112 = AddPropertyRequirement(out paragraph113, out paragraph114, out paragraph115, out table8);

    //        Paragraph paragraph127;
    //        Paragraph paragraph128;
    //        Paragraph paragraph129;
    //        Paragraph paragraph130;
    //        Paragraph paragraph131;
    //        Paragraph paragraph132;
    //        Paragraph paragraph133;
    //        Paragraph paragraph134;
    //        var paragraph126 = AddDataProtectionStatement(out paragraph127, out paragraph128, out paragraph129, out paragraph130, out paragraph131, out paragraph132, out paragraph133, out paragraph134);

    //        Paragraph paragraph136;
    //        Paragraph paragraph137;
    //        Paragraph paragraph138;
    //        Paragraph paragraph139;
    //        ParagraphProperties paragraphProperties139;
    //        var paragraph135 = AddDeclaration(out paragraph136, out paragraph137, out paragraph138, out paragraph139, out paragraphProperties139);

    //        Paragraph paragraph141;
    //        Paragraph paragraph142;
    //        Paragraph paragraph143;
    //        Paragraph paragraph144;
    //        Paragraph paragraph145;
    //        ParagraphProperties paragraphProperties145;
    //        var paragraph140 = AddNameDateAndSignature(paragraph139, paragraphProperties139, out paragraph141, out paragraph142, out paragraph143, out paragraph144, out paragraph145, out paragraphProperties145);

    //        var paragraph146 = AddParticipatingLandlords(paragraph145, paragraphProperties145);

    //        var paragraph147 = new Paragraph() { RsidParagraphAddition = "00D37468", RsidRunAdditionDefault = "00D37468" };
    //        var bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
    //        var bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

    //        paragraph147.Append(bookmarkStart1);
    //        paragraph147.Append(bookmarkEnd1);

    //        var sectionProperties1 = new SectionProperties() { RsidR = "00D37468", RsidSect = "004E4E45" };
    //        var headerReference1 = new HeaderReference() { Type = HeaderFooterValues.Even, Id = "rId5" };
    //        var headerReference2 = new HeaderReference() { Type = HeaderFooterValues.Default, Id = "rId6" };
    //        var footerReference1 = new FooterReference() { Type = HeaderFooterValues.Even, Id = "rId7" };
    //        var footerReference2 = new FooterReference() { Type = HeaderFooterValues.Default, Id = "rId8" };
    //        var headerReference3 = new HeaderReference() { Type = HeaderFooterValues.First, Id = "rId9" };
    //        var footerReference3 = new FooterReference() { Type = HeaderFooterValues.First, Id = "rId10" };
    //        var pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
    //        var pageMargin1 = new PageMargin() { Top = 720, Right = (UInt32Value)720U, Bottom = 720, Left = (UInt32Value)720U, Header = (UInt32Value)567U, Footer = (UInt32Value)283U, Gutter = (UInt32Value)0U };
    //        var columns1 = new Columns() { Space = "708" };
    //        var titlePage1 = new TitlePage();
    //        var docGrid1 = new DocGrid() { LinePitch = 360 };

    //        sectionProperties1.Append(headerReference1);
    //        sectionProperties1.Append(headerReference2);
    //        sectionProperties1.Append(footerReference1);
    //        sectionProperties1.Append(footerReference2);
    //        sectionProperties1.Append(headerReference3);
    //        sectionProperties1.Append(footerReference3);
    //        sectionProperties1.Append(pageSize1);
    //        sectionProperties1.Append(pageMargin1);
    //        sectionProperties1.Append(columns1);
    //        sectionProperties1.Append(titlePage1);
    //        sectionProperties1.Append(docGrid1);

    //        body1.Append(paragraph1);
    //        body1.Append(table1);
    //        body1.Append(paragraph14);
    //        body1.Append(paragraph15);
    //        body1.Append(table2);
    //        body1.Append(paragraph53);
    //        body1.Append(paragraph54);
    //        body1.Append(table3);
    //        body1.Append(paragraph63);
    //        body1.Append(paragraph64);
    //        body1.Append(table4);
    //        body1.Append(paragraph79);
    //        body1.Append(paragraph80);
    //        body1.Append(table5);
    //        body1.Append(paragraph85);
    //        body1.Append(paragraph86);
    //        for (int ctr = 0; ctr < contactByTableList.Count; ctr++)
    //        {
    //            body1.Append(contactByParagraphList[ctr]);
    //            body1.Append(contactByTableList[ctr]);
    //        }
    //        body1.Append(paragraph112);
    //        body1.Append(paragraph113);
    //        body1.Append(paragraph114);
    //        body1.Append(paragraph115);
    //        body1.Append(table8);
    //        body1.Append(paragraph126);
    //        body1.Append(paragraph127);
    //        body1.Append(paragraph128);
    //        body1.Append(paragraph129);
    //        body1.Append(paragraph130);
    //        body1.Append(paragraph131);
    //        body1.Append(paragraph132);
    //        body1.Append(paragraph133);
    //        body1.Append(paragraph134);
    //        body1.Append(paragraph135);
    //        body1.Append(paragraph136);
    //        body1.Append(paragraph137);
    //        body1.Append(paragraph138);
    //        body1.Append(paragraph139);
    //        body1.Append(paragraph140);
    //        body1.Append(paragraph141);
    //        body1.Append(paragraph142);
    //        body1.Append(paragraph143);
    //        body1.Append(paragraph144);
    //        body1.Append(paragraph145);
    //        body1.Append(paragraph146);
    //        body1.Append(paragraph147);
    //        body1.Append(sectionProperties1);

    //        document1.Append(body1);

    //        mainDocumentPart1.Document = document1;
    //    }

    //    private Paragraph AddIncomeDetailsOfHoseholdMembers(out Table table7, VBLContact contact)
    //    {
    //        var paragraph96 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties96 = new ParagraphProperties();
    //        var paragraphStyleId96 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties96 = new ParagraphMarkRunProperties();
    //        var runFonts180 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize180 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties96.Append(runFonts180);
    //        paragraphMarkRunProperties96.Append(fontSize180);

    //        paragraphProperties96.Append(paragraphStyleId96);
    //        paragraphProperties96.Append(paragraphMarkRunProperties96);

    //        var run85 = new Run();

    //        var runProperties85 = new RunProperties();
    //        var runFonts181 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize181 = new FontSize() { Val = "24" };

    //        runProperties85.Append(runFonts181);
    //        runProperties85.Append(fontSize181);
    //        var text85 = new Text();
    //        text85.Text = contact.Forename + " " + contact.Surname;

    //        run85.Append(runProperties85);
    //        run85.Append(text85);

    //        paragraph96.Append(paragraphProperties96);
    //        paragraph96.Append(run85);

    //        table7 = new Table();

    //        var tableProperties7 = new TableProperties();
    //        var tableWidth7 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders7 = new TableBorders();
    //        var topBorder7 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder7 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder7 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder7 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder7 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder7 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders7.Append(topBorder7);
    //        tableBorders7.Append(leftBorder7);
    //        tableBorders7.Append(bottomBorder7);
    //        tableBorders7.Append(rightBorder7);
    //        tableBorders7.Append(insideHorizontalBorder7);
    //        tableBorders7.Append(insideVerticalBorder7);
    //        var tableLayout7 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook7 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties7.Append(tableWidth7);
    //        tableProperties7.Append(tableBorders7);
    //        tableProperties7.Append(tableLayout7);
    //        tableProperties7.Append(tableLook7);

    //        var tableGrid7 = new TableGrid();
    //        var gridColumn25 = new GridColumn() { Width = "3000" };
    //        var gridColumn26 = new GridColumn() { Width = "3000" };
    //        var gridColumn27 = new GridColumn() { Width = "3000" };

    //        tableGrid7.Append(gridColumn25);
    //        tableGrid7.Append(gridColumn26);
    //        tableGrid7.Append(gridColumn27);

    //        var tableRow20 = CreateIncomeDetailsHeader();
    //        List<TableRow> tableRowList = new List<TableRow>();
    //        foreach (var incomeDetail in contact.IncomeDetails)
    //        {
    //            tableRowList.Add(CreateTableRowForEachIncomeType(incomeDetail));
    //        }

    //        table7.Append(tableProperties7);
    //        table7.Append(tableGrid7);
    //        table7.Append(tableRow20);
    //        foreach (var tableRow in tableRowList)
    //        {
    //            table7.Append(tableRow);
    //        }
    //        return paragraph96;
    //    }

    //    private static TableRow CreateIncomeDetailsHeader()
    //    {
    //        var tableRow20 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions20 = new TablePropertyExceptions();

    //        var tableCellMarginDefault20 = new TableCellMarginDefault();
    //        var topMargin96 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin96 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault20.Append(topMargin96);
    //        tableCellMarginDefault20.Append(bottomMargin96);

    //        tablePropertyExceptions20.Append(tableCellMarginDefault20);

    //        var tableCell77 = new TableCell();

    //        var tableCellProperties77 = new TableCellProperties();
    //        var tableCellWidth77 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading77 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin77 = new TableCellMargin();
    //        var topMargin97 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin97 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin77.Append(topMargin97);
    //        tableCellMargin77.Append(bottomMargin97);

    //        tableCellProperties77.Append(tableCellWidth77);
    //        tableCellProperties77.Append(shading77);
    //        tableCellProperties77.Append(tableCellMargin77);

    //        var paragraph97 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties97 = new ParagraphProperties();
    //        var paragraphStyleId97 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification55 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties97 = new ParagraphMarkRunProperties();
    //        var runFonts182 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold50 = new Bold();
    //        var fontSize182 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties97.Append(runFonts182);
    //        paragraphMarkRunProperties97.Append(bold50);
    //        paragraphMarkRunProperties97.Append(fontSize182);

    //        paragraphProperties97.Append(paragraphStyleId97);
    //        paragraphProperties97.Append(justification55);
    //        paragraphProperties97.Append(paragraphMarkRunProperties97);

    //        var run86 = new Run();

    //        var runProperties86 = new RunProperties();
    //        var runFonts183 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold51 = new Bold();
    //        var fontSize183 = new FontSize() { Val = "24" };

    //        runProperties86.Append(runFonts183);
    //        runProperties86.Append(bold51);
    //        runProperties86.Append(fontSize183);
    //        var text86 = new Text();
    //        text86.Text = "Income Source";

    //        run86.Append(runProperties86);
    //        run86.Append(text86);

    //        paragraph97.Append(paragraphProperties97);
    //        paragraph97.Append(run86);

    //        tableCell77.Append(tableCellProperties77);
    //        tableCell77.Append(paragraph97);

    //        var tableCell78 = new TableCell();

    //        var tableCellProperties78 = new TableCellProperties();
    //        var tableCellWidth78 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading78 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin78 = new TableCellMargin();
    //        var topMargin98 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin98 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin78.Append(topMargin98);
    //        tableCellMargin78.Append(bottomMargin98);

    //        tableCellProperties78.Append(tableCellWidth78);
    //        tableCellProperties78.Append(shading78);
    //        tableCellProperties78.Append(tableCellMargin78);

    //        var paragraph98 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties98 = new ParagraphProperties();
    //        var paragraphStyleId98 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification56 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties98 = new ParagraphMarkRunProperties();
    //        var runFonts184 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold52 = new Bold();
    //        var fontSize184 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties98.Append(runFonts184);
    //        paragraphMarkRunProperties98.Append(bold52);
    //        paragraphMarkRunProperties98.Append(fontSize184);

    //        paragraphProperties98.Append(paragraphStyleId98);
    //        paragraphProperties98.Append(justification56);
    //        paragraphProperties98.Append(paragraphMarkRunProperties98);

    //        var run87 = new Run();

    //        var runProperties87 = new RunProperties();
    //        var runFonts185 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold53 = new Bold();
    //        var fontSize185 = new FontSize() { Val = "24" };

    //        runProperties87.Append(runFonts185);
    //        runProperties87.Append(bold53);
    //        runProperties87.Append(fontSize185);
    //        var text87 = new Text();
    //        text87.Text = "Amount";

    //        run87.Append(runProperties87);
    //        run87.Append(text87);

    //        paragraph98.Append(paragraphProperties98);
    //        paragraph98.Append(run87);

    //        tableCell78.Append(tableCellProperties78);
    //        tableCell78.Append(paragraph98);

    //        var tableCell79 = new TableCell();

    //        var tableCellProperties79 = new TableCellProperties();
    //        var tableCellWidth79 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading79 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin79 = new TableCellMargin();
    //        var topMargin99 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin99 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin79.Append(topMargin99);
    //        tableCellMargin79.Append(bottomMargin99);

    //        tableCellProperties79.Append(tableCellWidth79);
    //        tableCellProperties79.Append(shading79);
    //        tableCellProperties79.Append(tableCellMargin79);

    //        var paragraph99 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties99 = new ParagraphProperties();
    //        var paragraphStyleId99 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification57 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties99 = new ParagraphMarkRunProperties();
    //        var runFonts186 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold54 = new Bold();
    //        var fontSize186 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties99.Append(runFonts186);
    //        paragraphMarkRunProperties99.Append(bold54);
    //        paragraphMarkRunProperties99.Append(fontSize186);

    //        paragraphProperties99.Append(paragraphStyleId99);
    //        paragraphProperties99.Append(justification57);
    //        paragraphProperties99.Append(paragraphMarkRunProperties99);

    //        var run88 = new Run();

    //        var runProperties88 = new RunProperties();
    //        var runFonts187 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold55 = new Bold();
    //        var fontSize187 = new FontSize() { Val = "24" };

    //        runProperties88.Append(runFonts187);
    //        runProperties88.Append(bold55);
    //        runProperties88.Append(fontSize187);
    //        var text88 = new Text();
    //        text88.Text = "Frequency";

    //        run88.Append(runProperties88);
    //        run88.Append(text88);

    //        paragraph99.Append(paragraphProperties99);
    //        paragraph99.Append(run88);

    //        tableCell79.Append(tableCellProperties79);
    //        tableCell79.Append(paragraph99);

    //        tableRow20.Append(tablePropertyExceptions20);
    //        tableRow20.Append(tableCell77);
    //        tableRow20.Append(tableCell78);
    //        tableRow20.Append(tableCell79);
    //        return tableRow20;
    //    }

    //    private static TableRow CreateTableRowForEachIncomeType(VBLIncomeDetail incomeDetail)
    //    {
    //        var tableRow21 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions21 = new TablePropertyExceptions();

    //        var tableCellMarginDefault21 = new TableCellMarginDefault();
    //        var topMargin100 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin100 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault21.Append(topMargin100);
    //        tableCellMarginDefault21.Append(bottomMargin100);

    //        tablePropertyExceptions21.Append(tableCellMarginDefault21);

    //        var tableCell80 = new TableCell();

    //        var tableCellProperties80 = new TableCellProperties();
    //        var tableCellWidth80 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading80 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin80 = new TableCellMargin();
    //        var topMargin101 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin101 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin80.Append(topMargin101);
    //        tableCellMargin80.Append(bottomMargin101);

    //        tableCellProperties80.Append(tableCellWidth80);
    //        tableCellProperties80.Append(shading80);
    //        tableCellProperties80.Append(tableCellMargin80);

    //        var paragraph100 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties100 = new ParagraphProperties();
    //        var paragraphStyleId100 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification58 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties100 = new ParagraphMarkRunProperties();
    //        var runFonts188 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize188 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties100.Append(runFonts188);
    //        paragraphMarkRunProperties100.Append(fontSize188);

    //        paragraphProperties100.Append(paragraphStyleId100);
    //        paragraphProperties100.Append(justification58);
    //        paragraphProperties100.Append(paragraphMarkRunProperties100);

    //        var run89 = new Run();

    //        var runProperties89 = new RunProperties();
    //        var runFonts189 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize189 = new FontSize() { Val = "24" };

    //        runProperties89.Append(runFonts189);
    //        runProperties89.Append(fontSize189);
    //        var text89 = new Text();
    //        text89.Text = incomeDetail.IncomeType.Name;

    //        run89.Append(runProperties89);
    //        run89.Append(text89);

    //        paragraph100.Append(paragraphProperties100);
    //        paragraph100.Append(run89);

    //        tableCell80.Append(tableCellProperties80);
    //        tableCell80.Append(paragraph100);

    //        var tableCell81 = new TableCell();

    //        var tableCellProperties81 = new TableCellProperties();
    //        var tableCellWidth81 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading81 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin81 = new TableCellMargin();
    //        var topMargin102 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin102 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin81.Append(topMargin102);
    //        tableCellMargin81.Append(bottomMargin102);

    //        tableCellProperties81.Append(tableCellWidth81);
    //        tableCellProperties81.Append(shading81);
    //        tableCellProperties81.Append(tableCellMargin81);

    //        var paragraph101 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties101 = new ParagraphProperties();
    //        var paragraphStyleId101 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification59 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties101 = new ParagraphMarkRunProperties();
    //        var runFonts190 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize190 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties101.Append(runFonts190);
    //        paragraphMarkRunProperties101.Append(fontSize190);

    //        paragraphProperties101.Append(paragraphStyleId101);
    //        paragraphProperties101.Append(justification59);
    //        paragraphProperties101.Append(paragraphMarkRunProperties101);

    //        var run90 = new Run();

    //        var runProperties90 = new RunProperties();
    //        var runFonts191 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize191 = new FontSize() { Val = "24" };

    //        runProperties90.Append(runFonts191);
    //        runProperties90.Append(fontSize191);
    //        var text90 = new Text();
    //        text90.Text = incomeDetail.Amount.ToString("F");

    //        run90.Append(runProperties90);
    //        run90.Append(text90);

    //        paragraph101.Append(paragraphProperties101);
    //        paragraph101.Append(run90);

    //        tableCell81.Append(tableCellProperties81);
    //        tableCell81.Append(paragraph101);

    //        var tableCell82 = new TableCell();

    //        var tableCellProperties82 = new TableCellProperties();
    //        var tableCellWidth82 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading82 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin82 = new TableCellMargin();
    //        var topMargin103 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin103 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin82.Append(topMargin103);
    //        tableCellMargin82.Append(bottomMargin103);

    //        tableCellProperties82.Append(tableCellWidth82);
    //        tableCellProperties82.Append(shading82);
    //        tableCellProperties82.Append(tableCellMargin82);

    //        var paragraph102 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties102 = new ParagraphProperties();
    //        var paragraphStyleId102 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification60 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties102 = new ParagraphMarkRunProperties();
    //        var runFonts192 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize192 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties102.Append(runFonts192);
    //        paragraphMarkRunProperties102.Append(fontSize192);

    //        paragraphProperties102.Append(paragraphStyleId102);
    //        paragraphProperties102.Append(justification60);
    //        paragraphProperties102.Append(paragraphMarkRunProperties102);

    //        var run91 = new Run();

    //        var runProperties91 = new RunProperties();
    //        var runFonts193 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize193 = new FontSize() { Val = "24" };

    //        runProperties91.Append(runFonts193);
    //        runProperties91.Append(fontSize193);
    //        var text91 = new Text();
    //        text91.Text = incomeDetail.IncomeFrequency.Name;

    //        run91.Append(runProperties91);
    //        run91.Append(text91);

    //        paragraph102.Append(paragraphProperties102);
    //        paragraph102.Append(run91);

    //        tableCell82.Append(tableCellProperties82);
    //        tableCell82.Append(paragraph102);

    //        tableRow21.Append(tablePropertyExceptions21);
    //        tableRow21.Append(tableCell80);
    //        tableRow21.Append(tableCell81);
    //        tableRow21.Append(tableCell82);
    //        return tableRow21;
    //    }

    //    private Paragraph AddParticipatingLandlords(Paragraph paragraph145, ParagraphProperties paragraphProperties145)
    //    {
    //        var run122 = new Run();

    //        var runProperties122 = new RunProperties();
    //        var runFonts265 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold65 = new Bold();
    //        var fontSize267 = new FontSize() { Val = "24" };

    //        runProperties122.Append(runFonts265);
    //        runProperties122.Append(bold65);
    //        runProperties122.Append(fontSize267);
    //        var text122 = new Text();
    //        text122.Text = "* Participating Landlords Include:";

    //        run122.Append(runProperties122);
    //        run122.Append(text122);

    //        paragraph145.Append(paragraphProperties145);
    //        paragraph145.Append(run122);

    //        var paragraph146 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties146 = new ParagraphProperties();
    //        var paragraphStyleId146 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties146 = new ParagraphMarkRunProperties();
    //        var runFonts266 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize268 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties146.Append(runFonts266);
    //        paragraphMarkRunProperties146.Append(fontSize268);

    //        paragraphProperties146.Append(paragraphStyleId146);
    //        paragraphProperties146.Append(paragraphMarkRunProperties146);

    //        var run123 = new Run();

    //        var runProperties123 = new RunProperties();
    //        var runFonts267 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize269 = new FontSize() { Val = "24" };

    //        runProperties123.Append(runFonts267);
    //        runProperties123.Append(fontSize269);
    //        var text123 = new Text();
    //        text123.Text =
    //            "Abbeyfield Bradford Society Ltd, Anchor Trust, Accent Group Ltd, Affinity Sutton, Equity Housing Association, Habinteg Housing Association, Hanover Housing, Headrow Housing Group, Home Group, Housing 21, Incommunities Group Ltd, Jephson Housing Association, Jonny Johnson Housing Association, Manningham Housing Association, Muir Housing Association, Places for People, Sanctuary Housing, The Riverside Group Ltd, Yorkshire Housing";

    //        run123.Append(runProperties123);
    //        run123.Append(text123);

    //        paragraph146.Append(paragraphProperties146);
    //        paragraph146.Append(run123);
    //        return paragraph146;
    //    }

    //    private Paragraph AddNameDateAndSignature(Paragraph paragraph139, ParagraphProperties paragraphProperties139,
    //        out Paragraph paragraph141, out Paragraph paragraph142, out Paragraph paragraph143, out Paragraph paragraph144,
    //        out Paragraph paragraph145, out ParagraphProperties paragraphProperties145)
    //    {
    //        var run118 = new Run();

    //        var runProperties118 = new RunProperties();
    //        var runFonts255 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize257 = new FontSize() { Val = "24" };

    //        runProperties118.Append(runFonts255);
    //        runProperties118.Append(fontSize257);
    //        var text118 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text118.Text = "Name   ";

    //        run118.Append(runProperties118);
    //        run118.Append(text118);

    //        var run119 = new Run();

    //        var runProperties119 = new RunProperties();
    //        var runFonts256 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize258 = new FontSize() { Val = "24" };
    //        var underline5 = new Underline() { Val = UnderlineValues.Single };

    //        runProperties119.Append(runFonts256);
    //        runProperties119.Append(fontSize258);
    //        runProperties119.Append(underline5);
    //        var text119 = new Text();
    //        text119.Text = _mainApplicantName;

    //        run119.Append(runProperties119);
    //        run119.Append(text119);

    //        paragraph139.Append(paragraphProperties139);
    //        paragraph139.Append(run118);
    //        paragraph139.Append(run119);

    //        var paragraph140 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties140 = new ParagraphProperties();
    //        var paragraphStyleId140 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties140 = new ParagraphMarkRunProperties();
    //        var runFonts257 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize259 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties140.Append(runFonts257);
    //        paragraphMarkRunProperties140.Append(fontSize259);

    //        paragraphProperties140.Append(paragraphStyleId140);
    //        paragraphProperties140.Append(paragraphMarkRunProperties140);

    //        paragraph140.Append(paragraphProperties140);

    //        paragraph141 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties141 = new ParagraphProperties();
    //        var paragraphStyleId141 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties141 = new ParagraphMarkRunProperties();
    //        var runFonts258 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize260 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties141.Append(runFonts258);
    //        paragraphMarkRunProperties141.Append(fontSize260);

    //        paragraphProperties141.Append(paragraphStyleId141);
    //        paragraphProperties141.Append(paragraphMarkRunProperties141);

    //        var run120 = new Run();

    //        var runProperties120 = new RunProperties();
    //        var runFonts259 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize261 = new FontSize() { Val = "24" };

    //        runProperties120.Append(runFonts259);
    //        runProperties120.Append(fontSize261);
    //        var text120 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text120.Text = "Date  _______________ ";

    //        run120.Append(runProperties120);
    //        run120.Append(text120);

    //        paragraph141.Append(paragraphProperties141);
    //        paragraph141.Append(run120);

    //        paragraph142 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties142 = new ParagraphProperties();
    //        var paragraphStyleId142 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties142 = new ParagraphMarkRunProperties();
    //        var runFonts260 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize262 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties142.Append(runFonts260);
    //        paragraphMarkRunProperties142.Append(fontSize262);

    //        paragraphProperties142.Append(paragraphStyleId142);
    //        paragraphProperties142.Append(paragraphMarkRunProperties142);

    //        paragraph142.Append(paragraphProperties142);

    //        paragraph143 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties143 = new ParagraphProperties();
    //        var paragraphStyleId143 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties143 = new ParagraphMarkRunProperties();
    //        var runFonts261 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize263 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties143.Append(runFonts261);
    //        paragraphMarkRunProperties143.Append(fontSize263);

    //        paragraphProperties143.Append(paragraphStyleId143);
    //        paragraphProperties143.Append(paragraphMarkRunProperties143);

    //        var run121 = new Run();

    //        var runProperties121 = new RunProperties();
    //        var runFonts262 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize264 = new FontSize() { Val = "24" };

    //        runProperties121.Append(runFonts262);
    //        runProperties121.Append(fontSize264);
    //        var text121 = new Text();
    //        text121.Text = "Signature  __________________________________________________";

    //        run121.Append(runProperties121);
    //        run121.Append(text121);

    //        paragraph143.Append(paragraphProperties143);
    //        paragraph143.Append(run121);

    //        paragraph144 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties144 = new ParagraphProperties();
    //        var paragraphStyleId144 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties144 = new ParagraphMarkRunProperties();
    //        var runFonts263 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize265 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties144.Append(runFonts263);
    //        paragraphMarkRunProperties144.Append(fontSize265);

    //        paragraphProperties144.Append(paragraphStyleId144);
    //        paragraphProperties144.Append(paragraphMarkRunProperties144);

    //        paragraph144.Append(paragraphProperties144);

    //        paragraph145 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        paragraphProperties145 = new ParagraphProperties();
    //        var paragraphStyleId145 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties145 = new ParagraphMarkRunProperties();
    //        var runFonts264 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold64 = new Bold();
    //        var fontSize266 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties145.Append(runFonts264);
    //        paragraphMarkRunProperties145.Append(bold64);
    //        paragraphMarkRunProperties145.Append(fontSize266);

    //        paragraphProperties145.Append(paragraphStyleId145);
    //        paragraphProperties145.Append(paragraphMarkRunProperties145);
    //        return paragraph140;
    //    }

    //    private Paragraph AddDeclaration(out Paragraph paragraph136, out Paragraph paragraph137,
    //        out Paragraph paragraph138, out Paragraph paragraph139, out ParagraphProperties paragraphProperties139)
    //    {
    //        var paragraph135 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties135 = new ParagraphProperties();
    //        var paragraphStyleId135 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties135 = new ParagraphMarkRunProperties();
    //        var runFonts250 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize250 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties135.Append(runFonts250);
    //        paragraphMarkRunProperties135.Append(fontSize250);

    //        paragraphProperties135.Append(paragraphStyleId135);
    //        paragraphProperties135.Append(paragraphMarkRunProperties135);

    //        paragraph135.Append(paragraphProperties135);

    //        paragraph136 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties136 = new ParagraphProperties();
    //        var paragraphStyleId136 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties136 = new ParagraphMarkRunProperties();
    //        var bold62 = new Bold();
    //        var fontSize251 = new FontSize() { Val = "24" };
    //        var underline3 = new Underline() { Val = UnderlineValues.Single };

    //        paragraphMarkRunProperties136.Append(bold62);
    //        paragraphMarkRunProperties136.Append(fontSize251);
    //        paragraphMarkRunProperties136.Append(underline3);

    //        paragraphProperties136.Append(paragraphStyleId136);
    //        paragraphProperties136.Append(paragraphMarkRunProperties136);

    //        var run116 = new Run();

    //        var runProperties116 = new RunProperties();
    //        var bold63 = new Bold();
    //        var fontSize252 = new FontSize() { Val = "24" };
    //        var underline4 = new Underline() { Val = UnderlineValues.Single };

    //        runProperties116.Append(bold63);
    //        runProperties116.Append(fontSize252);
    //        runProperties116.Append(underline4);
    //        var text116 = new Text();
    //        text116.Text = "Declaration";

    //        run116.Append(runProperties116);
    //        run116.Append(text116);

    //        paragraph136.Append(paragraphProperties136);
    //        paragraph136.Append(run116);

    //        paragraph137 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties137 = new ParagraphProperties();
    //        var paragraphStyleId137 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties137 = new ParagraphMarkRunProperties();
    //        var runFonts251 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize253 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties137.Append(runFonts251);
    //        paragraphMarkRunProperties137.Append(fontSize253);

    //        paragraphProperties137.Append(paragraphStyleId137);
    //        paragraphProperties137.Append(paragraphMarkRunProperties137);

    //        var run117 = new Run();

    //        var runProperties117 = new RunProperties();
    //        var runFonts252 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize254 = new FontSize() { Val = "24" };

    //        runProperties117.Append(runFonts252);
    //        runProperties117.Append(fontSize254);
    //        var text117 = new Text();
    //        text117.Text =
    //            "I give my consent for Incommunities to share my information with third party organisations and for these organisations to share my information with them in order to provide me with housing, support and associated services and in order to monitor my progress. I understand that my consent will remain valid until such time as I give written notice to withdraw my consent.";

    //        run117.Append(runProperties117);
    //        run117.Append(text117);

    //        paragraph137.Append(paragraphProperties137);
    //        paragraph137.Append(run117);

    //        paragraph138 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties138 = new ParagraphProperties();
    //        var paragraphStyleId138 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties138 = new ParagraphMarkRunProperties();
    //        var runFonts253 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize255 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties138.Append(runFonts253);
    //        paragraphMarkRunProperties138.Append(fontSize255);

    //        paragraphProperties138.Append(paragraphStyleId138);
    //        paragraphProperties138.Append(paragraphMarkRunProperties138);

    //        paragraph138.Append(paragraphProperties138);

    //        paragraph139 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        paragraphProperties139 = new ParagraphProperties();
    //        var paragraphStyleId139 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties139 = new ParagraphMarkRunProperties();
    //        var runFonts254 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize256 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties139.Append(runFonts254);
    //        paragraphMarkRunProperties139.Append(fontSize256);

    //        paragraphProperties139.Append(paragraphStyleId139);
    //        paragraphProperties139.Append(paragraphMarkRunProperties139);
    //        return paragraph135;
    //    }

    //    private Paragraph AddDataProtectionStatement(out Paragraph paragraph127, out Paragraph paragraph128,
    //        out Paragraph paragraph129, out Paragraph paragraph130, out Paragraph paragraph131, out Paragraph paragraph132,
    //        out Paragraph paragraph133, out Paragraph paragraph134)
    //    {
    //        var paragraph126 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties126 = new ParagraphProperties();
    //        var paragraphStyleId126 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties126 = new ParagraphMarkRunProperties();
    //        var runFonts237 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize237 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties126.Append(runFonts237);
    //        paragraphMarkRunProperties126.Append(fontSize237);

    //        paragraphProperties126.Append(paragraphStyleId126);
    //        paragraphProperties126.Append(paragraphMarkRunProperties126);

    //        paragraph126.Append(paragraphProperties126);

    //        paragraph127 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties127 = new ParagraphProperties();
    //        var paragraphStyleId127 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties127 = new ParagraphMarkRunProperties();
    //        var runFonts238 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize238 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties127.Append(runFonts238);
    //        paragraphMarkRunProperties127.Append(fontSize238);

    //        paragraphProperties127.Append(paragraphStyleId127);
    //        paragraphProperties127.Append(paragraphMarkRunProperties127);

    //        paragraph127.Append(paragraphProperties127);

    //        paragraph128 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties128 = new ParagraphProperties();
    //        var paragraphStyleId128 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties128 = new ParagraphMarkRunProperties();
    //        var runFonts239 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize239 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties128.Append(runFonts239);
    //        paragraphMarkRunProperties128.Append(fontSize239);

    //        paragraphProperties128.Append(paragraphStyleId128);
    //        paragraphProperties128.Append(paragraphMarkRunProperties128);

    //        paragraph128.Append(paragraphProperties128);

    //        paragraph129 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties129 = new ParagraphProperties();
    //        var paragraphStyleId129 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties129 = new ParagraphMarkRunProperties();
    //        var runFonts240 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold60 = new Bold();
    //        var fontSize240 = new FontSize() { Val = "24" };
    //        var underline1 = new Underline() { Val = UnderlineValues.Single };

    //        paragraphMarkRunProperties129.Append(runFonts240);
    //        paragraphMarkRunProperties129.Append(bold60);
    //        paragraphMarkRunProperties129.Append(fontSize240);
    //        paragraphMarkRunProperties129.Append(underline1);

    //        paragraphProperties129.Append(paragraphStyleId129);
    //        paragraphProperties129.Append(paragraphMarkRunProperties129);

    //        var run112 = new Run();

    //        var runProperties112 = new RunProperties();
    //        var runFonts241 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold61 = new Bold();
    //        var fontSize241 = new FontSize() { Val = "24" };
    //        var underline2 = new Underline() { Val = UnderlineValues.Single };

    //        runProperties112.Append(runFonts241);
    //        runProperties112.Append(bold61);
    //        runProperties112.Append(fontSize241);
    //        runProperties112.Append(underline2);
    //        var text112 = new Text();
    //        text112.Text = "Data Protection Statement";

    //        run112.Append(runProperties112);
    //        run112.Append(text112);

    //        paragraph129.Append(paragraphProperties129);
    //        paragraph129.Append(run112);

    //        paragraph130 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties130 = new ParagraphProperties();
    //        var paragraphStyleId130 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties130 = new ParagraphMarkRunProperties();
    //        var runFonts242 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize242 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties130.Append(runFonts242);
    //        paragraphMarkRunProperties130.Append(fontSize242);

    //        paragraphProperties130.Append(paragraphStyleId130);
    //        paragraphProperties130.Append(paragraphMarkRunProperties130);

    //        var run113 = new Run();

    //        var runProperties113 = new RunProperties();
    //        var runFonts243 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize243 = new FontSize() { Val = "24" };

    //        runProperties113.Append(runFonts243);
    //        runProperties113.Append(fontSize243);
    //        var text113 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text113.Text =
    //            "The Council and Incommunities will comply with the Data Protection Act 1998 and any subsequent legislation that may apply. The Council and Incommunities will store the information that you have provided in this application form and use this to provide you with housing, welfare advice, support and associated services. From time to time, we will also use this information for the purpose of improving our services and for producing housing demand and other performance information. ";

    //        run113.Append(runProperties113);
    //        run113.Append(text113);

    //        paragraph130.Append(paragraphProperties130);
    //        paragraph130.Append(run113);

    //        paragraph131 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties131 = new ParagraphProperties();
    //        var paragraphStyleId131 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties131 = new ParagraphMarkRunProperties();
    //        var runFonts244 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize244 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties131.Append(runFonts244);
    //        paragraphMarkRunProperties131.Append(fontSize244);

    //        paragraphProperties131.Append(paragraphStyleId131);
    //        paragraphProperties131.Append(paragraphMarkRunProperties131);

    //        paragraph131.Append(paragraphProperties131);

    //        paragraph132 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties132 = new ParagraphProperties();
    //        var paragraphStyleId132 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties132 = new ParagraphMarkRunProperties();
    //        var runFonts245 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize245 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties132.Append(runFonts245);
    //        paragraphMarkRunProperties132.Append(fontSize245);

    //        paragraphProperties132.Append(paragraphStyleId132);
    //        paragraphProperties132.Append(paragraphMarkRunProperties132);

    //        var run114 = new Run();

    //        var runProperties114 = new RunProperties();
    //        var runFonts246 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize246 = new FontSize() { Val = "24" };

    //        runProperties114.Append(runFonts246);
    //        runProperties114.Append(fontSize246);
    //        var text114 = new Text();
    //        text114.Text =
    //            "In order to provide you with these services, the Council and Incommunities will share your data with third party organisations including other local authorities, public sector organisations and providers of housing, support and associated services.";

    //        run114.Append(runProperties114);
    //        run114.Append(text114);

    //        paragraph132.Append(paragraphProperties132);
    //        paragraph132.Append(run114);

    //        paragraph133 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties133 = new ParagraphProperties();
    //        var paragraphStyleId133 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties133 = new ParagraphMarkRunProperties();
    //        var runFonts247 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize247 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties133.Append(runFonts247);
    //        paragraphMarkRunProperties133.Append(fontSize247);

    //        paragraphProperties133.Append(paragraphStyleId133);
    //        paragraphProperties133.Append(paragraphMarkRunProperties133);

    //        paragraph133.Append(paragraphProperties133);

    //        paragraph134 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties134 = new ParagraphProperties();
    //        var paragraphStyleId134 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties134 = new ParagraphMarkRunProperties();
    //        var runFonts248 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize248 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties134.Append(runFonts248);
    //        paragraphMarkRunProperties134.Append(fontSize248);

    //        paragraphProperties134.Append(paragraphStyleId134);
    //        paragraphProperties134.Append(paragraphMarkRunProperties134);

    //        var run115 = new Run();

    //        var runProperties115 = new RunProperties();
    //        var runFonts249 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize249 = new FontSize() { Val = "24" };

    //        runProperties115.Append(runFonts249);
    //        runProperties115.Append(fontSize249);
    //        var text115 = new Text();
    //        text115.Text =
    //            "We need your consent to share your information with organisations outside of the Council and Incommunities.  You are able to withdraw your consent at any time by providing written notice to the Data Protection Team/  Housing Options Team, Bradford Metropolitan District Council, Britannia House, 4th Floor, Hall Ings, Bradford, BD1 1HX.";

    //        run115.Append(runProperties115);
    //        run115.Append(text115);

    //        paragraph134.Append(paragraphProperties134);
    //        paragraph134.Append(run115);
    //        return paragraph126;
    //    }

    //    private Paragraph AddPropertyRequirement(out Paragraph paragraph113, out Paragraph paragraph114,
    //        out Paragraph paragraph115, out Table table8)
    //    {
    //        var paragraph112 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties112 = new ParagraphProperties();
    //        var paragraphStyleId112 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties112 = new ParagraphMarkRunProperties();
    //        var runFonts212 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize212 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties112.Append(runFonts212);
    //        paragraphMarkRunProperties112.Append(fontSize212);

    //        paragraphProperties112.Append(paragraphStyleId112);
    //        paragraphProperties112.Append(paragraphMarkRunProperties112);

    //        paragraph112.Append(paragraphProperties112);

    //        paragraph113 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties113 = new ParagraphProperties();
    //        var paragraphStyleId113 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties113 = new ParagraphMarkRunProperties();
    //        var runFonts213 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize213 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties113.Append(runFonts213);
    //        paragraphMarkRunProperties113.Append(fontSize213);

    //        paragraphProperties113.Append(paragraphStyleId113);
    //        paragraphProperties113.Append(paragraphMarkRunProperties113);

    //        paragraph113.Append(paragraphProperties113);

    //        paragraph114 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties114 = new ParagraphProperties();
    //        var paragraphStyleId114 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties114 = new ParagraphMarkRunProperties();
    //        var runFonts214 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize214 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties114.Append(runFonts214);
    //        paragraphMarkRunProperties114.Append(fontSize214);

    //        paragraphProperties114.Append(paragraphStyleId114);
    //        paragraphProperties114.Append(paragraphMarkRunProperties114);

    //        paragraph114.Append(paragraphProperties114);

    //        paragraph115 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties115 = new ParagraphProperties();
    //        var paragraphStyleId115 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties115 = new ParagraphMarkRunProperties();
    //        var runFonts215 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize215 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties115.Append(runFonts215);
    //        paragraphMarkRunProperties115.Append(fontSize215);

    //        paragraphProperties115.Append(paragraphStyleId115);
    //        paragraphProperties115.Append(paragraphMarkRunProperties115);

    //        var run101 = new Run();

    //        var runProperties101 = new RunProperties();
    //        var runFonts216 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize216 = new FontSize() { Val = "24" };

    //        runProperties101.Append(runFonts216);
    //        runProperties101.Append(fontSize216);
    //        var text101 = new Text();
    //        text101.Text = "Property Requirements";

    //        run101.Append(runProperties101);
    //        run101.Append(text101);

    //        paragraph115.Append(paragraphProperties115);
    //        paragraph115.Append(run101);

    //        table8 = new Table();

    //        var tableProperties8 = new TableProperties();
    //        var tableWidth8 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders8 = new TableBorders();
    //        var topBorder8 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder8 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder8 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder8 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder8 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder8 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders8.Append(topBorder8);
    //        tableBorders8.Append(leftBorder8);
    //        tableBorders8.Append(bottomBorder8);
    //        tableBorders8.Append(rightBorder8);
    //        tableBorders8.Append(insideHorizontalBorder8);
    //        tableBorders8.Append(insideVerticalBorder8);
    //        var tableLayout8 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook8 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties8.Append(tableWidth8);
    //        tableProperties8.Append(tableBorders8);
    //        tableProperties8.Append(tableLayout8);
    //        tableProperties8.Append(tableLook8);

    //        var tableGrid8 = new TableGrid();
    //        var gridColumn28 = new GridColumn() { Width = "1600" };
    //        var gridColumn29 = new GridColumn() { Width = "8000" };

    //        tableGrid8.Append(gridColumn28);
    //        tableGrid8.Append(gridColumn29);

    //        var tableRow25 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions25 = new TablePropertyExceptions();

    //        var tableCellMarginDefault25 = new TableCellMarginDefault();
    //        var topMargin116 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin116 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault25.Append(topMargin116);
    //        tableCellMarginDefault25.Append(bottomMargin116);

    //        tablePropertyExceptions25.Append(tableCellMarginDefault25);

    //        var tableCell92 = new TableCell();

    //        var tableCellProperties92 = new TableCellProperties();
    //        var tableCellWidth92 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading92 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin92 = new TableCellMargin();
    //        var topMargin117 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin117 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin92.Append(topMargin117);
    //        tableCellMargin92.Append(bottomMargin117);

    //        tableCellProperties92.Append(tableCellWidth92);
    //        tableCellProperties92.Append(shading92);
    //        tableCellProperties92.Append(tableCellMargin92);

    //        var paragraph116 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties116 = new ParagraphProperties();
    //        var paragraphStyleId116 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification70 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties116 = new ParagraphMarkRunProperties();
    //        var runFonts217 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold56 = new Bold();
    //        var fontSize217 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties116.Append(runFonts217);
    //        paragraphMarkRunProperties116.Append(bold56);
    //        paragraphMarkRunProperties116.Append(fontSize217);

    //        paragraphProperties116.Append(paragraphStyleId116);
    //        paragraphProperties116.Append(justification70);
    //        paragraphProperties116.Append(paragraphMarkRunProperties116);

    //        var run102 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties102 = new RunProperties();
    //        var runFonts218 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold57 = new Bold();
    //        var fontSize218 = new FontSize() { Val = "24" };

    //        runProperties102.Append(runFonts218);
    //        runProperties102.Append(bold57);
    //        runProperties102.Append(fontSize218);
    //        var text102 = new Text();
    //        text102.Text = "Item";

    //        run102.Append(runProperties102);
    //        run102.Append(text102);

    //        paragraph116.Append(paragraphProperties116);
    //        paragraph116.Append(run102);

    //        tableCell92.Append(tableCellProperties92);
    //        tableCell92.Append(paragraph116);

    //        var tableCell93 = new TableCell();

    //        var tableCellProperties93 = new TableCellProperties();
    //        var tableCellWidth93 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };
    //        var shading93 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin93 = new TableCellMargin();
    //        var topMargin118 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin118 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin93.Append(topMargin118);
    //        tableCellMargin93.Append(bottomMargin118);

    //        tableCellProperties93.Append(tableCellWidth93);
    //        tableCellProperties93.Append(shading93);
    //        tableCellProperties93.Append(tableCellMargin93);

    //        var paragraph117 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties117 = new ParagraphProperties();
    //        var paragraphStyleId117 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification71 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties117 = new ParagraphMarkRunProperties();
    //        var runFonts219 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold58 = new Bold();
    //        var fontSize219 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties117.Append(runFonts219);
    //        paragraphMarkRunProperties117.Append(bold58);
    //        paragraphMarkRunProperties117.Append(fontSize219);

    //        paragraphProperties117.Append(paragraphStyleId117);
    //        paragraphProperties117.Append(justification71);
    //        paragraphProperties117.Append(paragraphMarkRunProperties117);

    //        var run103 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties103 = new RunProperties();
    //        var runFonts220 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold59 = new Bold();
    //        var fontSize220 = new FontSize() { Val = "24" };

    //        runProperties103.Append(runFonts220);
    //        runProperties103.Append(bold59);
    //        runProperties103.Append(fontSize220);
    //        var text103 = new Text();
    //        text103.Text = "Selected Values";

    //        run103.Append(runProperties103);
    //        run103.Append(text103);

    //        paragraph117.Append(paragraphProperties117);
    //        paragraph117.Append(run103);

    //        tableCell93.Append(tableCellProperties93);
    //        tableCell93.Append(paragraph117);

    //        tableRow25.Append(tablePropertyExceptions25);
    //        tableRow25.Append(tableCell92);
    //        tableRow25.Append(tableCell93);

    //        var tableRow26 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions26 = new TablePropertyExceptions();

    //        var tableCellMarginDefault26 = new TableCellMarginDefault();
    //        var topMargin119 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin119 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault26.Append(topMargin119);
    //        tableCellMarginDefault26.Append(bottomMargin119);

    //        tablePropertyExceptions26.Append(tableCellMarginDefault26);

    //        var tableCell94 = new TableCell();

    //        var tableCellProperties94 = new TableCellProperties();
    //        var tableCellWidth94 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading94 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin94 = new TableCellMargin();
    //        var topMargin120 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin120 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin94.Append(topMargin120);
    //        tableCellMargin94.Append(bottomMargin120);

    //        tableCellProperties94.Append(tableCellWidth94);
    //        tableCellProperties94.Append(shading94);
    //        tableCellProperties94.Append(tableCellMargin94);

    //        var paragraph118 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties118 = new ParagraphProperties();
    //        var paragraphStyleId118 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification72 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties118 = new ParagraphMarkRunProperties();
    //        var runFonts221 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize221 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties118.Append(runFonts221);
    //        paragraphMarkRunProperties118.Append(fontSize221);

    //        paragraphProperties118.Append(paragraphStyleId118);
    //        paragraphProperties118.Append(justification72);
    //        paragraphProperties118.Append(paragraphMarkRunProperties118);

    //        var run104 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties104 = new RunProperties();
    //        var runFonts222 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize222 = new FontSize() { Val = "24" };

    //        runProperties104.Append(runFonts222);
    //        runProperties104.Append(fontSize222);
    //        var text104 = new Text();
    //        text104.Text = "Areas";

    //        run104.Append(runProperties104);
    //        run104.Append(text104);

    //        paragraph118.Append(paragraphProperties118);
    //        paragraph118.Append(run104);

    //        tableCell94.Append(tableCellProperties94);
    //        tableCell94.Append(paragraph118);

    //        var tableCell95 = new TableCell();

    //        var tableCellProperties95 = new TableCellProperties();
    //        var tableCellWidth95 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };
    //        var shading95 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin95 = new TableCellMargin();
    //        var topMargin121 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin121 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin95.Append(topMargin121);
    //        tableCellMargin95.Append(bottomMargin121);

    //        tableCellProperties95.Append(tableCellWidth95);
    //        tableCellProperties95.Append(shading95);
    //        tableCellProperties95.Append(tableCellMargin95);

    //        var paragraph119 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties119 = new ParagraphProperties();
    //        var paragraphStyleId119 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification73 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties119 = new ParagraphMarkRunProperties();
    //        var runFonts223 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize223 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties119.Append(runFonts223);
    //        paragraphMarkRunProperties119.Append(fontSize223);

    //        paragraphProperties119.Append(paragraphStyleId119);
    //        paragraphProperties119.Append(justification73);
    //        paragraphProperties119.Append(paragraphMarkRunProperties119);

    //        var run105 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties105 = new RunProperties();
    //        var runFonts224 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize224 = new FontSize() { Val = "24" };

    //        runProperties105.Append(runFonts224);
    //        runProperties105.Append(fontSize224);
    //        var text105 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text105.Text = _propertyRequirementAreas;

    //        run105.Append(runProperties105);
    //        run105.Append(text105);

    //        paragraph119.Append(paragraphProperties119);
    //        paragraph119.Append(run105);

    //        tableCell95.Append(tableCellProperties95);
    //        tableCell95.Append(paragraph119);

    //        tableRow26.Append(tablePropertyExceptions26);
    //        tableRow26.Append(tableCell94);
    //        tableRow26.Append(tableCell95);

    //        var tableRow27 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions27 = new TablePropertyExceptions();

    //        var tableCellMarginDefault27 = new TableCellMarginDefault();
    //        var topMargin122 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin122 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault27.Append(topMargin122);
    //        tableCellMarginDefault27.Append(bottomMargin122);

    //        tablePropertyExceptions27.Append(tableCellMarginDefault27);

    //        var tableCell96 = new TableCell();

    //        var tableCellProperties96 = new TableCellProperties();
    //        var tableCellWidth96 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading96 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin96 = new TableCellMargin();
    //        var topMargin123 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin123 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin96.Append(topMargin123);
    //        tableCellMargin96.Append(bottomMargin123);

    //        tableCellProperties96.Append(tableCellWidth96);
    //        tableCellProperties96.Append(shading96);
    //        tableCellProperties96.Append(tableCellMargin96);

    //        var paragraph120 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties120 = new ParagraphProperties();
    //        var paragraphStyleId120 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification74 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties120 = new ParagraphMarkRunProperties();
    //        var runFonts225 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize225 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties120.Append(runFonts225);
    //        paragraphMarkRunProperties120.Append(fontSize225);

    //        paragraphProperties120.Append(paragraphStyleId120);
    //        paragraphProperties120.Append(justification74);
    //        paragraphProperties120.Append(paragraphMarkRunProperties120);

    //        var run106 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties106 = new RunProperties();
    //        var runFonts226 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize226 = new FontSize() { Val = "24" };

    //        runProperties106.Append(runFonts226);
    //        runProperties106.Append(fontSize226);
    //        var text106 = new Text();
    //        text106.Text = "Types";

    //        run106.Append(runProperties106);
    //        run106.Append(text106);

    //        paragraph120.Append(paragraphProperties120);
    //        paragraph120.Append(run106);

    //        tableCell96.Append(tableCellProperties96);
    //        tableCell96.Append(paragraph120);

    //        var tableCell97 = new TableCell();

    //        var tableCellProperties97 = new TableCellProperties();
    //        var tableCellWidth97 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };
    //        var shading97 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin97 = new TableCellMargin();
    //        var topMargin124 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin124 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin97.Append(topMargin124);
    //        tableCellMargin97.Append(bottomMargin124);

    //        tableCellProperties97.Append(tableCellWidth97);
    //        tableCellProperties97.Append(shading97);
    //        tableCellProperties97.Append(tableCellMargin97);

    //        var paragraph121 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties121 = new ParagraphProperties();
    //        var paragraphStyleId121 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification75 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties121 = new ParagraphMarkRunProperties();
    //        var runFonts227 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize227 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties121.Append(runFonts227);
    //        paragraphMarkRunProperties121.Append(fontSize227);

    //        paragraphProperties121.Append(paragraphStyleId121);
    //        paragraphProperties121.Append(justification75);
    //        paragraphProperties121.Append(paragraphMarkRunProperties121);

    //        var run107 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties107 = new RunProperties();
    //        var runFonts228 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize228 = new FontSize() { Val = "24" };

    //        runProperties107.Append(runFonts228);
    //        runProperties107.Append(fontSize228);
    //        var text107 = new Text();
    //        text107.Text = _propertyRequirementTypes;

    //        run107.Append(runProperties107);
    //        run107.Append(text107);

    //        paragraph121.Append(paragraphProperties121);
    //        paragraph121.Append(run107);

    //        tableCell97.Append(tableCellProperties97);
    //        tableCell97.Append(paragraph121);

    //        tableRow27.Append(tablePropertyExceptions27);
    //        tableRow27.Append(tableCell96);
    //        tableRow27.Append(tableCell97);

    //        var tableRow28 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions28 = new TablePropertyExceptions();

    //        var tableCellMarginDefault28 = new TableCellMarginDefault();
    //        var topMargin125 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin125 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault28.Append(topMargin125);
    //        tableCellMarginDefault28.Append(bottomMargin125);

    //        tablePropertyExceptions28.Append(tableCellMarginDefault28);

    //        var tableCell98 = new TableCell();

    //        var tableCellProperties98 = new TableCellProperties();
    //        var tableCellWidth98 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading98 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin98 = new TableCellMargin();
    //        var topMargin126 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin126 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin98.Append(topMargin126);
    //        tableCellMargin98.Append(bottomMargin126);

    //        tableCellProperties98.Append(tableCellWidth98);
    //        tableCellProperties98.Append(shading98);
    //        tableCellProperties98.Append(tableCellMargin98);

    //        var paragraph122 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties122 = new ParagraphProperties();
    //        var paragraphStyleId122 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification76 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties122 = new ParagraphMarkRunProperties();
    //        var runFonts229 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize229 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties122.Append(runFonts229);
    //        paragraphMarkRunProperties122.Append(fontSize229);

    //        paragraphProperties122.Append(paragraphStyleId122);
    //        paragraphProperties122.Append(justification76);
    //        paragraphProperties122.Append(paragraphMarkRunProperties122);

    //        var run108 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties108 = new RunProperties();
    //        var runFonts230 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize230 = new FontSize() { Val = "24" };

    //        runProperties108.Append(runFonts230);
    //        runProperties108.Append(fontSize230);
    //        var text108 = new Text();
    //        text108.Text = "Size";

    //        run108.Append(runProperties108);
    //        run108.Append(text108);

    //        paragraph122.Append(paragraphProperties122);
    //        paragraph122.Append(run108);

    //        tableCell98.Append(tableCellProperties98);
    //        tableCell98.Append(paragraph122);

    //        var tableCell99 = new TableCell();

    //        var tableCellProperties99 = new TableCellProperties();
    //        var tableCellWidth99 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };
    //        var shading99 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin99 = new TableCellMargin();
    //        var topMargin127 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin127 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin99.Append(topMargin127);
    //        tableCellMargin99.Append(bottomMargin127);

    //        tableCellProperties99.Append(tableCellWidth99);
    //        tableCellProperties99.Append(shading99);
    //        tableCellProperties99.Append(tableCellMargin99);

    //        var paragraph123 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties123 = new ParagraphProperties();
    //        var paragraphStyleId123 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification77 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties123 = new ParagraphMarkRunProperties();
    //        var runFonts231 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize231 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties123.Append(runFonts231);
    //        paragraphMarkRunProperties123.Append(fontSize231);

    //        paragraphProperties123.Append(paragraphStyleId123);
    //        paragraphProperties123.Append(justification77);
    //        paragraphProperties123.Append(paragraphMarkRunProperties123);

    //        var run109 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties109 = new RunProperties();
    //        var runFonts232 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize232 = new FontSize() { Val = "24" };

    //        runProperties109.Append(runFonts232);
    //        runProperties109.Append(fontSize232);
    //        var text109 = new Text();
    //        text109.Text =_propertyRequirementSize;

    //        run109.Append(runProperties109);
    //        run109.Append(text109);

    //        paragraph123.Append(paragraphProperties123);
    //        paragraph123.Append(run109);

    //        tableCell99.Append(tableCellProperties99);
    //        tableCell99.Append(paragraph123);

    //        tableRow28.Append(tablePropertyExceptions28);
    //        tableRow28.Append(tableCell98);
    //        tableRow28.Append(tableCell99);

    //        var tableRow29 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions29 = new TablePropertyExceptions();

    //        var tableCellMarginDefault29 = new TableCellMarginDefault();
    //        var topMargin128 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin128 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault29.Append(topMargin128);
    //        tableCellMarginDefault29.Append(bottomMargin128);

    //        tablePropertyExceptions29.Append(tableCellMarginDefault29);

    //        var tableCell100 = new TableCell();

    //        var tableCellProperties100 = new TableCellProperties();
    //        var tableCellWidth100 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading100 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin100 = new TableCellMargin();
    //        var topMargin129 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin129 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin100.Append(topMargin129);
    //        tableCellMargin100.Append(bottomMargin129);

    //        tableCellProperties100.Append(tableCellWidth100);
    //        tableCellProperties100.Append(shading100);
    //        tableCellProperties100.Append(tableCellMargin100);

    //        var paragraph124 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties124 = new ParagraphProperties();
    //        var paragraphStyleId124 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification78 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties124 = new ParagraphMarkRunProperties();
    //        var runFonts233 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize233 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties124.Append(runFonts233);
    //        paragraphMarkRunProperties124.Append(fontSize233);

    //        paragraphProperties124.Append(paragraphStyleId124);
    //        paragraphProperties124.Append(justification78);
    //        paragraphProperties124.Append(paragraphMarkRunProperties124);

    //        var run110 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties110 = new RunProperties();
    //        var runFonts234 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize234 = new FontSize() { Val = "24" };

    //        runProperties110.Append(runFonts234);
    //        runProperties110.Append(fontSize234);
    //        var text110 = new Text();
    //        text110.Text = "Dates";

    //        run110.Append(runProperties110);
    //        run110.Append(text110);

    //        paragraph124.Append(paragraphProperties124);
    //        paragraph124.Append(run110);

    //        tableCell100.Append(tableCellProperties100);
    //        tableCell100.Append(paragraph124);

    //        var tableCell101 = new TableCell();

    //        var tableCellProperties101 = new TableCellProperties();
    //        var tableCellWidth101 = new TableCellWidth() { Width = "8000", Type = TableWidthUnitValues.Dxa };
    //        var shading101 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin101 = new TableCellMargin();
    //        var topMargin130 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin130 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin101.Append(topMargin130);
    //        tableCellMargin101.Append(bottomMargin130);

    //        tableCellProperties101.Append(tableCellWidth101);
    //        tableCellProperties101.Append(shading101);
    //        tableCellProperties101.Append(tableCellMargin101);

    //        var paragraph125 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties125 = new ParagraphProperties();
    //        var paragraphStyleId125 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification79 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties125 = new ParagraphMarkRunProperties();
    //        var runFonts235 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize235 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties125.Append(runFonts235);
    //        paragraphMarkRunProperties125.Append(fontSize235);

    //        paragraphProperties125.Append(paragraphStyleId125);
    //        paragraphProperties125.Append(justification79);
    //        paragraphProperties125.Append(paragraphMarkRunProperties125);

    //        var run111 = new Run() { RsidRunProperties = "00B46F26" };

    //        var runProperties111 = new RunProperties();
    //        var runFonts236 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize236 = new FontSize() { Val = "24" };

    //        runProperties111.Append(runFonts236);
    //        runProperties111.Append(fontSize236);
    //        var text111 = new Text();
    //        text111.Text = _propertyRequirementDates;

    //        run111.Append(runProperties111);
    //        run111.Append(text111);

    //        paragraph125.Append(paragraphProperties125);
    //        paragraph125.Append(run111);

    //        tableCell101.Append(tableCellProperties101);
    //        tableCell101.Append(paragraph125);

    //        tableRow29.Append(tablePropertyExceptions29);
    //        tableRow29.Append(tableCell100);
    //        tableRow29.Append(tableCell101);

    //        table8.Append(tableProperties8);
    //        table8.Append(tableGrid8);
    //        table8.Append(tableRow25);
    //        table8.Append(tableRow26);
    //        table8.Append(tableRow27);
    //        table8.Append(tableRow28);
    //        table8.Append(tableRow29);
    //        return paragraph112;
    //    }

    //    #region Income Details Per Month
    //    private Paragraph AddIncomeSummary(out Paragraph paragraph80, out Table table5)
    //    {
    //        var paragraph79 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties79 = new ParagraphProperties();
    //        var paragraphStyleId79 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties79 = new ParagraphMarkRunProperties();
    //        var runFonts150 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize150 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties79.Append(runFonts150);
    //        paragraphMarkRunProperties79.Append(fontSize150);

    //        paragraphProperties79.Append(paragraphStyleId79);
    //        paragraphProperties79.Append(paragraphMarkRunProperties79);

    //        paragraph79.Append(paragraphProperties79);

    //        paragraph80 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties80 = new ParagraphProperties();
    //        var paragraphStyleId80 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties80 = new ParagraphMarkRunProperties();
    //        var runFonts151 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize151 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties80.Append(runFonts151);
    //        paragraphMarkRunProperties80.Append(fontSize151);

    //        paragraphProperties80.Append(paragraphStyleId80);
    //        paragraphProperties80.Append(paragraphMarkRunProperties80);

    //        var run72 = new Run();

    //        var runProperties72 = new RunProperties();
    //        var runFonts152 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize152 = new FontSize() { Val = "24" };

    //        runProperties72.Append(runFonts152);
    //        runProperties72.Append(fontSize152);
    //        var text72 = new Text();
    //        text72.Text = "Income Details";

    //        run72.Append(runProperties72);
    //        run72.Append(text72);

    //        paragraph80.Append(paragraphProperties80);
    //        paragraph80.Append(run72);

    //        table5 = new Table();

    //        var tableProperties5 = new TableProperties();
    //        var tableWidth5 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders5 = new TableBorders();
    //        var topBorder5 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder5 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder5 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder5 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder5 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder5 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders5.Append(topBorder5);
    //        tableBorders5.Append(leftBorder5);
    //        tableBorders5.Append(bottomBorder5);
    //        tableBorders5.Append(rightBorder5);
    //        tableBorders5.Append(insideHorizontalBorder5);
    //        tableBorders5.Append(insideVerticalBorder5);
    //        var tableLayout5 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook5 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties5.Append(tableWidth5);
    //        tableProperties5.Append(tableBorders5);
    //        tableProperties5.Append(tableLayout5);
    //        tableProperties5.Append(tableLook5);

    //        var tableGrid5 = new TableGrid();
    //        var gridColumn20 = new GridColumn() { Width = "3000" };
    //        var gridColumn21 = new GridColumn() { Width = "3000" };

    //        tableGrid5.Append(gridColumn20);
    //        tableGrid5.Append(gridColumn21);

    //        var tableRow16 = CreatePerMonthIncomeDetailsHeaderRow();

    //        var tableRow17 = CreatePerMonthIncomeDetailsDataRow();

    //        table5.Append(tableProperties5);
    //        table5.Append(tableGrid5);
    //        table5.Append(tableRow16);
    //        table5.Append(tableRow17);
    //        return paragraph79;
    //    }

    //    private TableRow CreatePerMonthIncomeDetailsDataRow()
    //    {
    //        var tableRow17 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions17 = new TablePropertyExceptions();

    //        var tableCellMarginDefault17 = new TableCellMarginDefault();
    //        var topMargin85 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin85 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault17.Append(topMargin85);
    //        tableCellMarginDefault17.Append(bottomMargin85);

    //        tablePropertyExceptions17.Append(tableCellMarginDefault17);

    //        var tableCell69 = new TableCell();

    //        var tableCellProperties69 = new TableCellProperties();
    //        var tableCellWidth69 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading69 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin69 = new TableCellMargin();
    //        var topMargin86 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin86 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin69.Append(topMargin86);
    //        tableCellMargin69.Append(bottomMargin86);

    //        tableCellProperties69.Append(tableCellWidth69);
    //        tableCellProperties69.Append(shading69);
    //        tableCellProperties69.Append(tableCellMargin69);

    //        var paragraph83 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties83 = new ParagraphProperties();
    //        var paragraphStyleId83 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification47 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties83 = new ParagraphMarkRunProperties();
    //        var runFonts157 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize157 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties83.Append(runFonts157);
    //        paragraphMarkRunProperties83.Append(fontSize157);

    //        paragraphProperties83.Append(paragraphStyleId83);
    //        paragraphProperties83.Append(justification47);
    //        paragraphProperties83.Append(paragraphMarkRunProperties83);

    //        var run75 = new Run();

    //        var runProperties75 = new RunProperties();
    //        var runFonts158 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize158 = new FontSize() { Val = "24" };

    //        runProperties75.Append(runFonts158);
    //        runProperties75.Append(fontSize158);
    //        var text75 = new Text();
    //        text75.Text = "Total Income / Month";

    //        run75.Append(runProperties75);
    //        run75.Append(text75);

    //        paragraph83.Append(paragraphProperties83);
    //        paragraph83.Append(run75);

    //        tableCell69.Append(tableCellProperties69);
    //        tableCell69.Append(paragraph83);

    //        var tableCell70 = new TableCell();

    //        var tableCellProperties70 = new TableCellProperties();
    //        var tableCellWidth70 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading70 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin70 = new TableCellMargin();
    //        var topMargin87 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin87 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin70.Append(topMargin87);
    //        tableCellMargin70.Append(bottomMargin87);

    //        tableCellProperties70.Append(tableCellWidth70);
    //        tableCellProperties70.Append(shading70);
    //        tableCellProperties70.Append(tableCellMargin70);

    //        var paragraph84 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties84 = new ParagraphProperties();
    //        var paragraphStyleId84 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification48 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties84 = new ParagraphMarkRunProperties();
    //        var runFonts159 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize159 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties84.Append(runFonts159);
    //        paragraphMarkRunProperties84.Append(fontSize159);

    //        paragraphProperties84.Append(paragraphStyleId84);
    //        paragraphProperties84.Append(justification48);
    //        paragraphProperties84.Append(paragraphMarkRunProperties84);

    //        var run76 = new Run();

    //        var runProperties76 = new RunProperties();
    //        var runFonts160 = new RunFonts() { Hint = FontTypeHintValues.EastAsia, Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize160 = new FontSize() { Val = "24" };

    //        runProperties76.Append(runFonts160);
    //        runProperties76.Append(fontSize160);
    //        var text76 = new Text();
    //        text76.Text = "£";

    //        run76.Append(runProperties76);
    //        run76.Append(text76);

    //        var run77 = new Run();

    //        var runProperties77 = new RunProperties();
    //        var runFonts161 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize161 = new FontSize() { Val = "24" };

    //        runProperties77.Append(runFonts161);
    //        runProperties77.Append(fontSize161);
    //        var text77 = new Text();
    //        text77.Text = _incomePerMonth.ToString("F");

    //        run77.Append(runProperties77);
    //        run77.Append(text77);

    //        paragraph84.Append(paragraphProperties84);
    //        paragraph84.Append(run76);
    //        paragraph84.Append(run77);

    //        tableCell70.Append(tableCellProperties70);
    //        tableCell70.Append(paragraph84);

    //        tableRow17.Append(tablePropertyExceptions17);
    //        tableRow17.Append(tableCell69);
    //        tableRow17.Append(tableCell70);
    //        return tableRow17;
    //    }

    //    private static TableRow CreatePerMonthIncomeDetailsHeaderRow()
    //    {
    //        var tableRow16 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions16 = new TablePropertyExceptions();

    //        var tableCellMarginDefault16 = new TableCellMarginDefault();
    //        var topMargin82 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin82 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault16.Append(topMargin82);
    //        tableCellMarginDefault16.Append(bottomMargin82);

    //        tablePropertyExceptions16.Append(tableCellMarginDefault16);

    //        var tableCell67 = new TableCell();

    //        var tableCellProperties67 = new TableCellProperties();
    //        var tableCellWidth67 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading67 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin67 = new TableCellMargin();
    //        var topMargin83 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin83 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin67.Append(topMargin83);
    //        tableCellMargin67.Append(bottomMargin83);

    //        tableCellProperties67.Append(tableCellWidth67);
    //        tableCellProperties67.Append(shading67);
    //        tableCellProperties67.Append(tableCellMargin67);

    //        var paragraph81 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties81 = new ParagraphProperties();
    //        var paragraphStyleId81 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification45 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties81 = new ParagraphMarkRunProperties();
    //        var runFonts153 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold40 = new Bold();
    //        var fontSize153 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties81.Append(runFonts153);
    //        paragraphMarkRunProperties81.Append(bold40);
    //        paragraphMarkRunProperties81.Append(fontSize153);

    //        paragraphProperties81.Append(paragraphStyleId81);
    //        paragraphProperties81.Append(justification45);
    //        paragraphProperties81.Append(paragraphMarkRunProperties81);

    //        var run73 = new Run();

    //        var runProperties73 = new RunProperties();
    //        var runFonts154 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold41 = new Bold();
    //        var fontSize154 = new FontSize() { Val = "24" };

    //        runProperties73.Append(runFonts154);
    //        runProperties73.Append(bold41);
    //        runProperties73.Append(fontSize154);
    //        var text73 = new Text();
    //        text73.Text = "Item";

    //        run73.Append(runProperties73);
    //        run73.Append(text73);

    //        paragraph81.Append(paragraphProperties81);
    //        paragraph81.Append(run73);

    //        tableCell67.Append(tableCellProperties67);
    //        tableCell67.Append(paragraph81);

    //        var tableCell68 = new TableCell();

    //        var tableCellProperties68 = new TableCellProperties();
    //        var tableCellWidth68 = new TableCellWidth() { Width = "3000", Type = TableWidthUnitValues.Dxa };
    //        var shading68 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin68 = new TableCellMargin();
    //        var topMargin84 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin84 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin68.Append(topMargin84);
    //        tableCellMargin68.Append(bottomMargin84);

    //        tableCellProperties68.Append(tableCellWidth68);
    //        tableCellProperties68.Append(shading68);
    //        tableCellProperties68.Append(tableCellMargin68);

    //        var paragraph82 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties82 = new ParagraphProperties();
    //        var paragraphStyleId82 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification46 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties82 = new ParagraphMarkRunProperties();
    //        var runFonts155 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold42 = new Bold();
    //        var fontSize155 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties82.Append(runFonts155);
    //        paragraphMarkRunProperties82.Append(bold42);
    //        paragraphMarkRunProperties82.Append(fontSize155);

    //        paragraphProperties82.Append(paragraphStyleId82);
    //        paragraphProperties82.Append(justification46);
    //        paragraphProperties82.Append(paragraphMarkRunProperties82);

    //        var run74 = new Run();

    //        var runProperties74 = new RunProperties();
    //        var runFonts156 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold43 = new Bold();
    //        var fontSize156 = new FontSize() { Val = "24" };

    //        runProperties74.Append(runFonts156);
    //        runProperties74.Append(bold43);
    //        runProperties74.Append(fontSize156);
    //        var text74 = new Text();
    //        text74.Text = "Selected Value";

    //        run74.Append(runProperties74);
    //        run74.Append(text74);

    //        paragraph82.Append(paragraphProperties82);
    //        paragraph82.Append(run74);

    //        tableCell68.Append(tableCellProperties68);
    //        tableCell68.Append(paragraph82);

    //        tableRow16.Append(tablePropertyExceptions16);
    //        tableRow16.Append(tableCell67);
    //        tableRow16.Append(tableCell68);
    //        return tableRow16;
    //    }

    //    #endregion
    //    private Paragraph AddCustomerCircumtances(out Table table4)
    //    {
    //        var paragraph64 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties64 = new ParagraphProperties();
    //        var paragraphStyleId64 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties64 = new ParagraphMarkRunProperties();
    //        var runFonts121 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize121 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties64.Append(runFonts121);
    //        paragraphMarkRunProperties64.Append(fontSize121);

    //        paragraphProperties64.Append(paragraphStyleId64);
    //        paragraphProperties64.Append(paragraphMarkRunProperties64);

    //        var run58 = new Run();

    //        var runProperties58 = new RunProperties();
    //        var runFonts122 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize122 = new FontSize() { Val = "24" };

    //        runProperties58.Append(runFonts122);
    //        runProperties58.Append(fontSize122);
    //        var text58 = new Text();
    //        text58.Text = "Customer Circumstances";

    //        run58.Append(runProperties58);
    //        run58.Append(text58);

    //        paragraph64.Append(paragraphProperties64);
    //        paragraph64.Append(run58);

    //        table4 = new Table();

    //        var tableProperties4 = new TableProperties();
    //        var tableWidth4 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders4 = new TableBorders();
    //        var topBorder4 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder4 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder4 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder4 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder4 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder4 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders4.Append(topBorder4);
    //        tableBorders4.Append(leftBorder4);
    //        tableBorders4.Append(bottomBorder4);
    //        tableBorders4.Append(rightBorder4);
    //        tableBorders4.Append(insideHorizontalBorder4);
    //        tableBorders4.Append(insideVerticalBorder4);
    //        var tableLayout4 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook4 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties4.Append(tableWidth4);
    //        tableProperties4.Append(tableBorders4);
    //        tableProperties4.Append(tableLayout4);
    //        tableProperties4.Append(tableLook4);

    //        var tableGrid4 = new TableGrid();
    //        var gridColumn18 = new GridColumn() { Width = "4000" };
    //        var gridColumn19 = new GridColumn() { Width = "6000" };

    //        tableGrid4.Append(gridColumn18);
    //        tableGrid4.Append(gridColumn19);

    //        var tableRow11 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions11 = new TablePropertyExceptions();

    //        var tableCellMarginDefault11 = new TableCellMarginDefault();
    //        var topMargin67 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin67 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault11.Append(topMargin67);
    //        tableCellMarginDefault11.Append(bottomMargin67);

    //        tablePropertyExceptions11.Append(tableCellMarginDefault11);

    //        var tableCell57 = new TableCell();

    //        var tableCellProperties57 = new TableCellProperties();
    //        var tableCellWidth57 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };
    //        var shading57 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin57 = new TableCellMargin();
    //        var topMargin68 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin68 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin57.Append(topMargin68);
    //        tableCellMargin57.Append(bottomMargin68);

    //        tableCellProperties57.Append(tableCellWidth57);
    //        tableCellProperties57.Append(shading57);
    //        tableCellProperties57.Append(tableCellMargin57);

    //        var paragraph65 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties65 = new ParagraphProperties();
    //        var paragraphStyleId65 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification31 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties65 = new ParagraphMarkRunProperties();
    //        var runFonts123 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold36 = new Bold();
    //        var fontSize123 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties65.Append(runFonts123);
    //        paragraphMarkRunProperties65.Append(bold36);
    //        paragraphMarkRunProperties65.Append(fontSize123);

    //        paragraphProperties65.Append(paragraphStyleId65);
    //        paragraphProperties65.Append(justification31);
    //        paragraphProperties65.Append(paragraphMarkRunProperties65);

    //        var run59 = new Run();

    //        var runProperties59 = new RunProperties();
    //        var runFonts124 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold37 = new Bold();
    //        var fontSize124 = new FontSize() { Val = "24" };

    //        runProperties59.Append(runFonts124);
    //        runProperties59.Append(bold37);
    //        runProperties59.Append(fontSize124);
    //        var text59 = new Text();
    //        text59.Text = "Item";

    //        run59.Append(runProperties59);
    //        run59.Append(text59);

    //        paragraph65.Append(paragraphProperties65);
    //        paragraph65.Append(run59);

    //        tableCell57.Append(tableCellProperties57);
    //        tableCell57.Append(paragraph65);

    //        var tableCell58 = new TableCell();

    //        var tableCellProperties58 = new TableCellProperties();
    //        var tableCellWidth58 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
    //        var shading58 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin58 = new TableCellMargin();
    //        var topMargin69 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin69 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin58.Append(topMargin69);
    //        tableCellMargin58.Append(bottomMargin69);

    //        tableCellProperties58.Append(tableCellWidth58);
    //        tableCellProperties58.Append(shading58);
    //        tableCellProperties58.Append(tableCellMargin58);

    //        var paragraph66 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties66 = new ParagraphProperties();
    //        var paragraphStyleId66 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification32 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties66 = new ParagraphMarkRunProperties();
    //        var runFonts125 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold38 = new Bold();
    //        var fontSize125 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties66.Append(runFonts125);
    //        paragraphMarkRunProperties66.Append(bold38);
    //        paragraphMarkRunProperties66.Append(fontSize125);

    //        paragraphProperties66.Append(paragraphStyleId66);
    //        paragraphProperties66.Append(justification32);
    //        paragraphProperties66.Append(paragraphMarkRunProperties66);

    //        var run60 = new Run();

    //        var runProperties60 = new RunProperties();
    //        var runFonts126 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold39 = new Bold();
    //        var fontSize126 = new FontSize() { Val = "24" };

    //        runProperties60.Append(runFonts126);
    //        runProperties60.Append(bold39);
    //        runProperties60.Append(fontSize126);
    //        var text60 = new Text();
    //        text60.Text = "Selected value";

    //        run60.Append(runProperties60);
    //        run60.Append(text60);

    //        paragraph66.Append(paragraphProperties66);
    //        paragraph66.Append(run60);

    //        tableCell58.Append(tableCellProperties58);
    //        tableCell58.Append(paragraph66);

    //        tableRow11.Append(tablePropertyExceptions11);
    //        tableRow11.Append(tableCell57);
    //        tableRow11.Append(tableCell58);

    //        var tableRow12 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions12 = new TablePropertyExceptions();

    //        var tableCellMarginDefault12 = new TableCellMarginDefault();
    //        var topMargin70 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin70 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault12.Append(topMargin70);
    //        tableCellMarginDefault12.Append(bottomMargin70);

    //        tablePropertyExceptions12.Append(tableCellMarginDefault12);

    //        var tableCell59 = new TableCell();

    //        var tableCellProperties59 = new TableCellProperties();
    //        var tableCellWidth59 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };
    //        var shading59 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin59 = new TableCellMargin();
    //        var topMargin71 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin71 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin59.Append(topMargin71);
    //        tableCellMargin59.Append(bottomMargin71);

    //        tableCellProperties59.Append(tableCellWidth59);
    //        tableCellProperties59.Append(shading59);
    //        tableCellProperties59.Append(tableCellMargin59);

    //        var paragraph67 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties67 = new ParagraphProperties();
    //        var paragraphStyleId67 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification33 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties67 = new ParagraphMarkRunProperties();
    //        var runFonts127 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize127 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties67.Append(runFonts127);
    //        paragraphMarkRunProperties67.Append(fontSize127);

    //        paragraphProperties67.Append(paragraphStyleId67);
    //        paragraphProperties67.Append(justification33);
    //        paragraphProperties67.Append(paragraphMarkRunProperties67);

    //        var run61 = new Run();

    //        var runProperties61 = new RunProperties();
    //        var runFonts128 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize128 = new FontSize() { Val = "24" };

    //        runProperties61.Append(runFonts128);
    //        runProperties61.Append(fontSize128);
    //        var lastRenderedPageBreak1 = new LastRenderedPageBreak();
    //        var text61 = new Text();
    //        text61.Text = "Residency Type";

    //        run61.Append(runProperties61);
    //        run61.Append(lastRenderedPageBreak1);
    //        run61.Append(text61);

    //        paragraph67.Append(paragraphProperties67);
    //        paragraph67.Append(run61);

    //        tableCell59.Append(tableCellProperties59);
    //        tableCell59.Append(paragraph67);

    //        var tableCell60 = new TableCell();

    //        var tableCellProperties60 = new TableCellProperties();
    //        var tableCellWidth60 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
    //        var shading60 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin60 = new TableCellMargin();
    //        var topMargin72 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin72 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin60.Append(topMargin72);
    //        tableCellMargin60.Append(bottomMargin72);

    //        tableCellProperties60.Append(tableCellWidth60);
    //        tableCellProperties60.Append(shading60);
    //        tableCellProperties60.Append(tableCellMargin60);

    //        var paragraph68 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties68 = new ParagraphProperties();
    //        var paragraphStyleId68 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification34 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties68 = new ParagraphMarkRunProperties();
    //        var runFonts129 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize129 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties68.Append(runFonts129);
    //        paragraphMarkRunProperties68.Append(fontSize129);

    //        paragraphProperties68.Append(paragraphStyleId68);
    //        paragraphProperties68.Append(justification34);
    //        paragraphProperties68.Append(paragraphMarkRunProperties68);

    //        var run62 = new Run();

    //        var runProperties62 = new RunProperties();
    //        var runFonts130 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize130 = new FontSize() { Val = "24" };

    //        runProperties62.Append(runFonts130);
    //        runProperties62.Append(fontSize130);
    //        var text62 = new Text();
    //        text62.Text = _customerCircumstancesResidencyType;

    //        run62.Append(runProperties62);
    //        run62.Append(text62);

    //        paragraph68.Append(paragraphProperties68);
    //        paragraph68.Append(run62);

    //        tableCell60.Append(tableCellProperties60);
    //        tableCell60.Append(paragraph68);

    //        tableRow12.Append(tablePropertyExceptions12);
    //        tableRow12.Append(tableCell59);
    //        tableRow12.Append(tableCell60);

    //        var tableRow13 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions13 = new TablePropertyExceptions();

    //        var tableCellMarginDefault13 = new TableCellMarginDefault();
    //        var topMargin73 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin73 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault13.Append(topMargin73);
    //        tableCellMarginDefault13.Append(bottomMargin73);

    //        tablePropertyExceptions13.Append(tableCellMarginDefault13);

    //        var tableCell61 = new TableCell();

    //        var tableCellProperties61 = new TableCellProperties();
    //        var tableCellWidth61 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };
    //        var shading61 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin61 = new TableCellMargin();
    //        var topMargin74 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin74 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin61.Append(topMargin74);
    //        tableCellMargin61.Append(bottomMargin74);

    //        tableCellProperties61.Append(tableCellWidth61);
    //        tableCellProperties61.Append(shading61);
    //        tableCellProperties61.Append(tableCellMargin61);

    //        var paragraph69 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties69 = new ParagraphProperties();
    //        var paragraphStyleId69 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification35 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties69 = new ParagraphMarkRunProperties();
    //        var runFonts131 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize131 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties69.Append(runFonts131);
    //        paragraphMarkRunProperties69.Append(fontSize131);

    //        paragraphProperties69.Append(paragraphStyleId69);
    //        paragraphProperties69.Append(justification35);
    //        paragraphProperties69.Append(paragraphMarkRunProperties69);

    //        var run63 = new Run();

    //        var runProperties63 = new RunProperties();
    //        var runFonts132 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize132 = new FontSize() { Val = "24" };

    //        runProperties63.Append(runFonts132);
    //        runProperties63.Append(fontSize132);
    //        var text63 = new Text();
    //        text63.Text = "Current Address";

    //        run63.Append(runProperties63);
    //        run63.Append(text63);

    //        paragraph69.Append(paragraphProperties69);
    //        paragraph69.Append(run63);

    //        tableCell61.Append(tableCellProperties61);
    //        tableCell61.Append(paragraph69);

    //        var tableCell62 = new TableCell();

    //        var tableCellProperties62 = new TableCellProperties();
    //        var tableCellWidth62 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
    //        var shading62 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin62 = new TableCellMargin();
    //        var topMargin75 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin75 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin62.Append(topMargin75);
    //        tableCellMargin62.Append(bottomMargin75);

    //        tableCellProperties62.Append(tableCellWidth62);
    //        tableCellProperties62.Append(shading62);
    //        tableCellProperties62.Append(tableCellMargin62);

    //        var paragraphCurrentAddress = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };
    //        var runCurrentAddress = new Run();

    //        var runPropertiesCurrentAddress = new RunProperties();
    //        var runFontsCurrentAddress = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSizeCurrentAddress = new FontSize() { Val = "24" };

    //        runPropertiesCurrentAddress.Append(runFontsCurrentAddress);
    //        runPropertiesCurrentAddress.Append(fontSizeCurrentAddress);
    //        var textCurrentAddress = new Text();
    //        textCurrentAddress.Text = _customerCircumstancesCurrentAddress;

    //        runCurrentAddress.Append(runPropertiesCurrentAddress);
    //        runCurrentAddress.Append(textCurrentAddress);
    //        tableCell62.Append(tableCellProperties62);
    //        tableCell62.Append(paragraphCurrentAddress);


    //        var paragraph70 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties70 = new ParagraphProperties();
    //        var paragraphStyleId70 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification36 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties70 = new ParagraphMarkRunProperties();
    //        var runFonts133 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize133 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties70.Append(runFonts133);
    //        paragraphMarkRunProperties70.Append(fontSize133);

    //        paragraphProperties70.Append(paragraphStyleId70);
    //        paragraphProperties70.Append(justification36);
    //        paragraphProperties70.Append(paragraphMarkRunProperties70);

    //        var run64 = new Run();

    //        var runProperties64 = new RunProperties();
    //        var runFonts134 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize134 = new FontSize() { Val = "24" };

    //        runProperties64.Append(runFonts134);
    //        runProperties64.Append(fontSize134);
    //        var text64 = new Text();
    //        text64.Text = _addressLine1; //Edited

    //        run64.Append(runProperties64);
    //        run64.Append(text64);

    //        paragraph70.Append(paragraphProperties70);
    //        paragraph70.Append(run64);

    //        var paragraph71 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties71 = new ParagraphProperties();
    //        var paragraphStyleId71 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification37 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties71 = new ParagraphMarkRunProperties();
    //        var runFonts135 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize135 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties71.Append(runFonts135);
    //        paragraphMarkRunProperties71.Append(fontSize135);

    //        paragraphProperties71.Append(paragraphStyleId71);
    //        paragraphProperties71.Append(justification37);
    //        paragraphProperties71.Append(paragraphMarkRunProperties71);

    //        var run65 = new Run();

    //        var runProperties65 = new RunProperties();
    //        var runFonts136 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize136 = new FontSize() { Val = "24" };

    //        runProperties65.Append(runFonts136);
    //        runProperties65.Append(fontSize136);
    //        var text65 = new Text();
    //        text65.Text = _addressLine2; //Edited

    //        run65.Append(runProperties65);
    //        run65.Append(text65);

    //        paragraph71.Append(paragraphProperties71);
    //        paragraph71.Append(run65);

    //        var paragraph72 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties72 = new ParagraphProperties();
    //        var paragraphStyleId72 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification38 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties72 = new ParagraphMarkRunProperties();
    //        var runFonts137 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize137 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties72.Append(runFonts137);
    //        paragraphMarkRunProperties72.Append(fontSize137);

    //        paragraphProperties72.Append(paragraphStyleId72);
    //        paragraphProperties72.Append(justification38);
    //        paragraphProperties72.Append(paragraphMarkRunProperties72);

    //        var run66 = new Run();

    //        var runProperties66 = new RunProperties();
    //        var runFonts138 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize138 = new FontSize() { Val = "24" };

    //        runProperties66.Append(runFonts138);
    //        runProperties66.Append(fontSize138);
    //        var text66 = new Text();
    //        text66.Text = _addressCity; //Edited "Bingley";

    //        run66.Append(runProperties66);
    //        run66.Append(text66);

    //        paragraph72.Append(paragraphProperties72);
    //        paragraph72.Append(run66);

    //        var paragraph73 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties73 = new ParagraphProperties();
    //        var paragraphStyleId73 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification39 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties73 = new ParagraphMarkRunProperties();
    //        var runFonts139 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize139 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties73.Append(runFonts139);
    //        paragraphMarkRunProperties73.Append(fontSize139);

    //        paragraphProperties73.Append(paragraphStyleId73);
    //        paragraphProperties73.Append(justification39);
    //        paragraphProperties73.Append(paragraphMarkRunProperties73);

    //        var run67 = new Run();

    //        var runProperties67 = new RunProperties();
    //        var runFonts140 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize140 = new FontSize() { Val = "24" };

    //        runProperties67.Append(runFonts140);
    //        runProperties67.Append(fontSize140);
    //        var text67 = new Text();
    //        text67.Text = _addressPostcode; //Edited "BD16 2AQ";

    //        run67.Append(runProperties67);
    //        run67.Append(text67);

    //        paragraph73.Append(paragraphProperties73);
    //        paragraph73.Append(run67);

    //        var paragraph74 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties74 = new ParagraphProperties();
    //        var paragraphStyleId74 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification40 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties74 = new ParagraphMarkRunProperties();
    //        var runFonts141 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize141 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties74.Append(runFonts141);
    //        paragraphMarkRunProperties74.Append(fontSize141);

    //        paragraphProperties74.Append(paragraphStyleId74);
    //        paragraphProperties74.Append(justification40);
    //        paragraphProperties74.Append(paragraphMarkRunProperties74);

    //        paragraph74.Append(paragraphProperties74);

    //       // tableCell62.Append(tableCellProperties62);
    //        tableCell62.Append(paragraph70);
    //        tableCell62.Append(paragraph71);
    //        tableCell62.Append(paragraph72);
    //        tableCell62.Append(paragraph73);
    //        tableCell62.Append(paragraph74);

    //        tableRow13.Append(tablePropertyExceptions13);
    //        tableRow13.Append(tableCell61);
    //        tableRow13.Append(tableCell62);

    //        var tableRow14 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions14 = new TablePropertyExceptions();

    //        var tableCellMarginDefault14 = new TableCellMarginDefault();
    //        var topMargin76 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin76 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault14.Append(topMargin76);
    //        tableCellMarginDefault14.Append(bottomMargin76);

    //        tablePropertyExceptions14.Append(tableCellMarginDefault14);

    //        var tableCell63 = new TableCell();

    //        var tableCellProperties63 = new TableCellProperties();
    //        var tableCellWidth63 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };
    //        var shading63 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin63 = new TableCellMargin();
    //        var topMargin77 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin77 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin63.Append(topMargin77);
    //        tableCellMargin63.Append(bottomMargin77);

    //        tableCellProperties63.Append(tableCellWidth63);
    //        tableCellProperties63.Append(shading63);
    //        tableCellProperties63.Append(tableCellMargin63);

    //        var paragraph75 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties75 = new ParagraphProperties();
    //        var paragraphStyleId75 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification41 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties75 = new ParagraphMarkRunProperties();
    //        var runFonts142 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize142 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties75.Append(runFonts142);
    //        paragraphMarkRunProperties75.Append(fontSize142);

    //        paragraphProperties75.Append(paragraphStyleId75);
    //        paragraphProperties75.Append(justification41);
    //        paragraphProperties75.Append(paragraphMarkRunProperties75);

    //        var run68 = new Run();

    //        var runProperties68 = new RunProperties();
    //        var runFonts143 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize143 = new FontSize() { Val = "24" };

    //        runProperties68.Append(runFonts143);
    //        runProperties68.Append(fontSize143);
    //        var text68 = new Text();
    //        text68.Text = "Duration";

    //        run68.Append(runProperties68);
    //        run68.Append(text68);

    //        paragraph75.Append(paragraphProperties75);
    //        paragraph75.Append(run68);

    //        tableCell63.Append(tableCellProperties63);
    //        tableCell63.Append(paragraph75);

    //        var tableCell64 = new TableCell();

    //        var tableCellProperties64 = new TableCellProperties();
    //        var tableCellWidth64 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
    //        var shading64 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin64 = new TableCellMargin();
    //        var topMargin78 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin78 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin64.Append(topMargin78);
    //        tableCellMargin64.Append(bottomMargin78);

    //        tableCellProperties64.Append(tableCellWidth64);
    //        tableCellProperties64.Append(shading64);
    //        tableCellProperties64.Append(tableCellMargin64);

    //        var paragraph76 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties76 = new ParagraphProperties();
    //        var paragraphStyleId76 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification42 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties76 = new ParagraphMarkRunProperties();
    //        var runFonts144 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize144 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties76.Append(runFonts144);
    //        paragraphMarkRunProperties76.Append(fontSize144);

    //        paragraphProperties76.Append(paragraphStyleId76);
    //        paragraphProperties76.Append(justification42);
    //        paragraphProperties76.Append(paragraphMarkRunProperties76);

    //        var run69 = new Run();

    //        var runProperties69 = new RunProperties();
    //        var runFonts145 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize145 = new FontSize() { Val = "24" };

    //        runProperties69.Append(runFonts145);
    //        runProperties69.Append(fontSize145);
    //        var text69 = new Text();
    //        text69.Text = _customerCircumstancesDuration;

    //        run69.Append(runProperties69);
    //        run69.Append(text69);

    //        paragraph76.Append(paragraphProperties76);
    //        paragraph76.Append(run69);

    //        tableCell64.Append(tableCellProperties64);
    //        tableCell64.Append(paragraph76);

    //        tableRow14.Append(tablePropertyExceptions14);
    //        tableRow14.Append(tableCell63);
    //        tableRow14.Append(tableCell64);

    //        var tableRow15 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions15 = new TablePropertyExceptions();

    //        var tableCellMarginDefault15 = new TableCellMarginDefault();
    //        var topMargin79 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin79 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault15.Append(topMargin79);
    //        tableCellMarginDefault15.Append(bottomMargin79);

    //        tablePropertyExceptions15.Append(tableCellMarginDefault15);

    //        var tableCell65 = new TableCell();

    //        var tableCellProperties65 = new TableCellProperties();
    //        var tableCellWidth65 = new TableCellWidth() { Width = "4000", Type = TableWidthUnitValues.Dxa };
    //        var shading65 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin65 = new TableCellMargin();
    //        var topMargin80 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin80 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin65.Append(topMargin80);
    //        tableCellMargin65.Append(bottomMargin80);

    //        tableCellProperties65.Append(tableCellWidth65);
    //        tableCellProperties65.Append(shading65);
    //        tableCellProperties65.Append(tableCellMargin65);

    //        var paragraph77 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties77 = new ParagraphProperties();
    //        var paragraphStyleId77 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification43 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties77 = new ParagraphMarkRunProperties();
    //        var runFonts146 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize146 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties77.Append(runFonts146);
    //        paragraphMarkRunProperties77.Append(fontSize146);

    //        paragraphProperties77.Append(paragraphStyleId77);
    //        paragraphProperties77.Append(justification43);
    //        paragraphProperties77.Append(paragraphMarkRunProperties77);

    //        var run70 = new Run();

    //        var runProperties70 = new RunProperties();
    //        var runFonts147 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize147 = new FontSize() { Val = "24" };

    //        runProperties70.Append(runFonts147);
    //        runProperties70.Append(fontSize147);
    //        var text70 = new Text();
    //        text70.Text = "Reason for Moving";

    //        run70.Append(runProperties70);
    //        run70.Append(text70);

    //        paragraph77.Append(paragraphProperties77);
    //        paragraph77.Append(run70);

    //        tableCell65.Append(tableCellProperties65);
    //        tableCell65.Append(paragraph77);

    //        var tableCell66 = new TableCell();

    //        var tableCellProperties66 = new TableCellProperties();
    //        var tableCellWidth66 = new TableCellWidth() { Width = "6000", Type = TableWidthUnitValues.Dxa };
    //        var shading66 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin66 = new TableCellMargin();
    //        var topMargin81 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin81 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin66.Append(topMargin81);
    //        tableCellMargin66.Append(bottomMargin81);

    //        tableCellProperties66.Append(tableCellWidth66);
    //        tableCellProperties66.Append(shading66);
    //        tableCellProperties66.Append(tableCellMargin66);

    //        var paragraph78 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties78 = new ParagraphProperties();
    //        var paragraphStyleId78 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification44 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties78 = new ParagraphMarkRunProperties();
    //        var runFonts148 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize148 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties78.Append(runFonts148);
    //        paragraphMarkRunProperties78.Append(fontSize148);

    //        paragraphProperties78.Append(paragraphStyleId78);
    //        paragraphProperties78.Append(justification44);
    //        paragraphProperties78.Append(paragraphMarkRunProperties78);

    //        var run71 = new Run();

    //        var runProperties71 = new RunProperties();
    //        var runFonts149 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize149 = new FontSize() { Val = "24" };

    //        runProperties71.Append(runFonts149);
    //        runProperties71.Append(fontSize149);
    //        var text71 = new Text();
    //        text71.Text = _customerCircumstancesReasonforMoving;

    //        run71.Append(runProperties71);
    //        run71.Append(text71);

    //        paragraph78.Append(paragraphProperties78);
    //        paragraph78.Append(run71);

    //        tableCell66.Append(tableCellProperties66);
    //        tableCell66.Append(paragraph78);

    //        tableRow15.Append(tablePropertyExceptions15);
    //        tableRow15.Append(tableCell65);
    //        tableRow15.Append(tableCell66);

    //        table4.Append(tableProperties4);
    //        table4.Append(tableGrid4);
    //        table4.Append(tableRow11);
    //        table4.Append(tableRow12);
    //        table4.Append(tableRow13);
    //        table4.Append(tableRow14);
    //        table4.Append(tableRow15);
    //        return paragraph64;
    //    }

    //    private Table CreateContactInformations(Paragraph paragraph54)
    //    {

    //        var paragraphProperties54 = new ParagraphProperties();
    //        var paragraphStyleId54 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties54 = new ParagraphMarkRunProperties();
    //        var runFonts102 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize102 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties54.Append(runFonts102);
    //        paragraphMarkRunProperties54.Append(fontSize102);

    //        paragraphProperties54.Append(paragraphStyleId54);
    //        paragraphProperties54.Append(paragraphMarkRunProperties54);

    //        var run49 = new Run();

    //        var runProperties49 = new RunProperties();
    //        var runFonts103 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize103 = new FontSize() { Val = "24" };

    //        runProperties49.Append(runFonts103);
    //        runProperties49.Append(fontSize103);
    //        var text49 = new Text();
    //        text49.Text = "Contact Information";

    //        run49.Append(runProperties49);
    //        run49.Append(text49);

    //        paragraph54.Append(paragraphProperties54);
    //        paragraph54.Append(run49);

    //        var table3 = new Table();

    //        var tableProperties3 = new TableProperties();
    //        var tableWidth3 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders3 = new TableBorders();
    //        var topBorder3 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder3 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder3 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder3 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder3 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder3 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders3.Append(topBorder3);
    //        tableBorders3.Append(leftBorder3);
    //        tableBorders3.Append(bottomBorder3);
    //        tableBorders3.Append(rightBorder3);
    //        tableBorders3.Append(insideHorizontalBorder3);
    //        tableBorders3.Append(insideVerticalBorder3);
    //        var tableLayout3 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook3 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties3.Append(tableWidth3);
    //        tableProperties3.Append(tableBorders3);
    //        tableProperties3.Append(tableLayout3);
    //        tableProperties3.Append(tableLook3);

    //        var tableGrid3 = new TableGrid();
    //        var gridColumn16 = new GridColumn() { Width = "2400" };
    //        var gridColumn17 = new GridColumn() { Width = "3600" };

    //        tableGrid3.Append(gridColumn16);
    //        tableGrid3.Append(gridColumn17);
    //        var tableRowList = new List<TableRow>();
    //        var tableRow7 = CreateContactInformationHeaderRow();
    //        foreach (var contactBy in _contactByDetails)
    //        {
    //            tableRowList.Add(CreateContactInformationDataRow(contactBy));
    //        }

    //        table3.Append(tableProperties3);
    //        table3.Append(tableGrid3);
    //        table3.Append(tableRow7);

    //        foreach (var tableRow in tableRowList)
    //        {
    //            table3.Append(tableRow);
    //        }
    //        return table3;
    //    }

    //    private static TableRow CreateContactInformationDataRow(VBLContactByDetails contactByDetail)
    //    {
    //        var tableRow8 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions8 = new TablePropertyExceptions();

    //        var tableCellMarginDefault8 = new TableCellMarginDefault();
    //        var topMargin58 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin58 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault8.Append(topMargin58);
    //        tableCellMarginDefault8.Append(bottomMargin58);

    //        tablePropertyExceptions8.Append(tableCellMarginDefault8);

    //        var tableCell51 = new TableCell();

    //        var tableCellProperties51 = new TableCellProperties();
    //        var tableCellWidth51 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };
    //        var shading51 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin51 = new TableCellMargin();
    //        var topMargin59 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin59 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin51.Append(topMargin59);
    //        tableCellMargin51.Append(bottomMargin59);

    //        tableCellProperties51.Append(tableCellWidth51);
    //        tableCellProperties51.Append(shading51);
    //        tableCellProperties51.Append(tableCellMargin51);

    //        var paragraph57 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties57 = new ParagraphProperties();
    //        var paragraphStyleId57 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification25 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties57 = new ParagraphMarkRunProperties();
    //        var runFonts108 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize108 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties57.Append(runFonts108);
    //        paragraphMarkRunProperties57.Append(fontSize108);

    //        paragraphProperties57.Append(paragraphStyleId57);
    //        paragraphProperties57.Append(justification25);
    //        paragraphProperties57.Append(paragraphMarkRunProperties57);

    //        var run52 = new Run();

    //        var runProperties52 = new RunProperties();
    //        var runFonts109 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize109 = new FontSize() { Val = "24" };

    //        runProperties52.Append(runFonts109);
    //        runProperties52.Append(fontSize109);
    //        var text52 = new Text();
    //        text52.Text = "Contact By " + contactByDetail.ContactBy.Code;

    //        run52.Append(runProperties52);
    //        run52.Append(text52);

    //        paragraph57.Append(paragraphProperties57);
    //        paragraph57.Append(run52);

    //        tableCell51.Append(tableCellProperties51);
    //        tableCell51.Append(paragraph57);

    //        var tableCell52 = new TableCell();

    //        var tableCellProperties52 = new TableCellProperties();
    //        var tableCellWidth52 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };
    //        var shading52 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin52 = new TableCellMargin();
    //        var topMargin60 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin60 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin52.Append(topMargin60);
    //        tableCellMargin52.Append(bottomMargin60);

    //        tableCellProperties52.Append(tableCellWidth52);
    //        tableCellProperties52.Append(shading52);
    //        tableCellProperties52.Append(tableCellMargin52);

    //        var paragraph58 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties58 = new ParagraphProperties();
    //        var paragraphStyleId58 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification26 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties58 = new ParagraphMarkRunProperties();
    //        var runFonts110 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize110 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties58.Append(runFonts110);
    //        paragraphMarkRunProperties58.Append(fontSize110);

    //        paragraphProperties58.Append(paragraphStyleId58);
    //        paragraphProperties58.Append(justification26);
    //        paragraphProperties58.Append(paragraphMarkRunProperties58);

    //        var run53 = new Run();

    //        var runProperties53 = new RunProperties();
    //        var runFonts111 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize111 = new FontSize() { Val = "24" };

    //        runProperties53.Append(runFonts111);
    //        runProperties53.Append(fontSize111);
    //        var text53 = new Text();
    //        text53.Text = contactByDetail.ContactValue;

    //        run53.Append(runProperties53);
    //        run53.Append(text53);

    //        paragraph58.Append(paragraphProperties58);
    //        paragraph58.Append(run53);

    //        tableCell52.Append(tableCellProperties52);
    //        tableCell52.Append(paragraph58);

    //        tableRow8.Append(tablePropertyExceptions8);
    //        tableRow8.Append(tableCell51);
    //        tableRow8.Append(tableCell52);
    //        return tableRow8;
    //    }

    //    private static TableRow CreateContactInformationHeaderRow()
    //    {
    //        var tableRow7 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions7 = new TablePropertyExceptions();

    //        var tableCellMarginDefault7 = new TableCellMarginDefault();
    //        var topMargin55 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin55 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault7.Append(topMargin55);
    //        tableCellMarginDefault7.Append(bottomMargin55);

    //        tablePropertyExceptions7.Append(tableCellMarginDefault7);

    //        var tableCell49 = new TableCell();

    //        var tableCellProperties49 = new TableCellProperties();
    //        var tableCellWidth49 = new TableCellWidth() { Width = "2400", Type = TableWidthUnitValues.Dxa };
    //        var shading49 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin49 = new TableCellMargin();
    //        var topMargin56 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin56 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin49.Append(topMargin56);
    //        tableCellMargin49.Append(bottomMargin56);

    //        tableCellProperties49.Append(tableCellWidth49);
    //        tableCellProperties49.Append(shading49);
    //        tableCellProperties49.Append(tableCellMargin49);

    //        var paragraph55 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties55 = new ParagraphProperties();
    //        var paragraphStyleId55 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification23 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties55 = new ParagraphMarkRunProperties();
    //        var runFonts104 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold32 = new Bold();
    //        var fontSize104 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties55.Append(runFonts104);
    //        paragraphMarkRunProperties55.Append(bold32);
    //        paragraphMarkRunProperties55.Append(fontSize104);

    //        paragraphProperties55.Append(paragraphStyleId55);
    //        paragraphProperties55.Append(justification23);
    //        paragraphProperties55.Append(paragraphMarkRunProperties55);

    //        var run50 = new Run();

    //        var runProperties50 = new RunProperties();
    //        var runFonts105 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold33 = new Bold();
    //        var fontSize105 = new FontSize() { Val = "24" };

    //        runProperties50.Append(runFonts105);
    //        runProperties50.Append(bold33);
    //        runProperties50.Append(fontSize105);
    //        var text50 = new Text();
    //        text50.Text = "Item";

    //        run50.Append(runProperties50);
    //        run50.Append(text50);

    //        paragraph55.Append(paragraphProperties55);
    //        paragraph55.Append(run50);

    //        tableCell49.Append(tableCellProperties49);
    //        tableCell49.Append(paragraph55);

    //        var tableCell50 = new TableCell();

    //        var tableCellProperties50 = new TableCellProperties();
    //        var tableCellWidth50 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };
    //        var shading50 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin50 = new TableCellMargin();
    //        var topMargin57 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin57 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin50.Append(topMargin57);
    //        tableCellMargin50.Append(bottomMargin57);

    //        tableCellProperties50.Append(tableCellWidth50);
    //        tableCellProperties50.Append(shading50);
    //        tableCellProperties50.Append(tableCellMargin50);

    //        var paragraph56 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties56 = new ParagraphProperties();
    //        var paragraphStyleId56 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification24 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties56 = new ParagraphMarkRunProperties();
    //        var runFonts106 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold34 = new Bold();
    //        var fontSize106 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties56.Append(runFonts106);
    //        paragraphMarkRunProperties56.Append(bold34);
    //        paragraphMarkRunProperties56.Append(fontSize106);

    //        paragraphProperties56.Append(paragraphStyleId56);
    //        paragraphProperties56.Append(justification24);
    //        paragraphProperties56.Append(paragraphMarkRunProperties56);

    //        var run51 = new Run();

    //        var runProperties51 = new RunProperties();
    //        var runFonts107 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold35 = new Bold();
    //        var fontSize107 = new FontSize() { Val = "24" };

    //        runProperties51.Append(runFonts107);
    //        runProperties51.Append(bold35);
    //        runProperties51.Append(fontSize107);
    //        var text51 = new Text();
    //        text51.Text = "Selected Value";

    //        run51.Append(runProperties51);
    //        run51.Append(text51);

    //        paragraph56.Append(paragraphProperties56);
    //        paragraph56.Append(run51);

    //        tableCell50.Append(tableCellProperties50);
    //        tableCell50.Append(paragraph56);

    //        tableRow7.Append(tablePropertyExceptions7);
    //        tableRow7.Append(tableCell49);
    //        tableRow7.Append(tableCell50);
    //        return tableRow7;
    //    }

    //    private Paragraph CreateSummaryOfHouseholdDetails(out Table table2, out Paragraph paragraph15, out Paragraph paragraph53)
    //    {
    //        var paragraph14 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties14 = new ParagraphProperties();
    //        var paragraphStyleId14 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
    //        var runFonts26 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize26 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties14.Append(runFonts26);
    //        paragraphMarkRunProperties14.Append(fontSize26);

    //        paragraphProperties14.Append(paragraphStyleId14);
    //        paragraphProperties14.Append(paragraphMarkRunProperties14);

    //        paragraph14.Append(paragraphProperties14);

    //        paragraph15 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties15 = new ParagraphProperties();
    //        var paragraphStyleId15 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
    //        var runFonts27 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize27 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties15.Append(runFonts27);
    //        paragraphMarkRunProperties15.Append(fontSize27);

    //        paragraphProperties15.Append(paragraphStyleId15);
    //        paragraphProperties15.Append(paragraphMarkRunProperties15);

    //        var run13 = new Run();

    //        var runProperties13 = new RunProperties();
    //        var runFonts28 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize28 = new FontSize() { Val = "24" };

    //        runProperties13.Append(runFonts28);
    //        runProperties13.Append(fontSize28);
    //        var text13 = new Text();
    //        text13.Text = "Summary Of Household Details";

    //        run13.Append(runProperties13);
    //        run13.Append(text13);

    //        paragraph15.Append(paragraphProperties15);
    //        paragraph15.Append(run13);

    //        table2 = new Table();

    //        var tableProperties2 = new TableProperties();
    //        var tableWidth2 = new TableWidth() { Width = "10760", Type = TableWidthUnitValues.Dxa };

    //        var tableBorders2 = new TableBorders();
    //        var topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
    //        var leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
    //        var bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
    //        var rightBorder2 = new RightBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
    //        var insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
    //        var insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "000000", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

    //        tableBorders2.Append(topBorder2);
    //        tableBorders2.Append(leftBorder2);
    //        tableBorders2.Append(bottomBorder2);
    //        tableBorders2.Append(rightBorder2);
    //        tableBorders2.Append(insideHorizontalBorder2);
    //        tableBorders2.Append(insideVerticalBorder2);
    //        var tableLayout2 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook2 = new TableLook() { Val = "0000", FirstRow = false, LastRow = false, FirstColumn = false, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = false };

    //        tableProperties2.Append(tableWidth2);
    //        tableProperties2.Append(tableBorders2);
    //        tableProperties2.Append(tableLayout2);
    //        tableProperties2.Append(tableLook2);

    //        var tableGrid2 = new TableGrid();
    //        var gridColumn7 = new GridColumn() { Width = "1640" };
    //        var gridColumn8 = new GridColumn() { Width = "1200" };
    //        var gridColumn9 = new GridColumn() { Width = "1000" };
    //        var gridColumn10 = new GridColumn() { Width = "1200" };
    //        var gridColumn11 = new GridColumn() { Width = "1480" };
    //        var gridColumn12 = new GridColumn() { Width = "1040" };
    //        var gridColumn13 = new GridColumn() { Width = "1600" };
    //        var gridColumn14 = new GridColumn() { Width = "800" };
    //        var gridColumn15 = new GridColumn() { Width = "800" };

    //        tableGrid2.Append(gridColumn7);
    //        tableGrid2.Append(gridColumn8);
    //        tableGrid2.Append(gridColumn9);
    //        tableGrid2.Append(gridColumn10);
    //        tableGrid2.Append(gridColumn11);
    //        tableGrid2.Append(gridColumn12);
    //        tableGrid2.Append(gridColumn13);
    //        tableGrid2.Append(gridColumn14);
    //        tableGrid2.Append(gridColumn15);
    //        var tableRowList = new List<TableRow>();
    //        var tableRow3 = CreateSummaryOfHouseholdDetailsHeaderRow();
    //        foreach (var vblContact in _vblApplication.Contacts)
    //        {
    //            tableRowList.Add(CreateSummaryOfHouseholdDetailsDataRow(vblContact));
    //        }


    //        table2.Append(tableProperties2);
    //        table2.Append(tableGrid2);
    //        table2.Append(tableRow3);
    //        foreach (var tableRow in tableRowList)
    //        {
    //            table2.Append(tableRow);
    //        }

    //        paragraph53 = new Paragraph() { RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00602ED1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties53 = new ParagraphProperties();
    //        var paragraphStyleId53 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties53 = new ParagraphMarkRunProperties();
    //        var runFonts101 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize101 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties53.Append(runFonts101);
    //        paragraphMarkRunProperties53.Append(fontSize101);

    //        paragraphProperties53.Append(paragraphStyleId53);
    //        paragraphProperties53.Append(paragraphMarkRunProperties53);

    //        paragraph53.Append(paragraphProperties53);

    //        return paragraph14;
    //    }

    //    #region Summary Of Household Details
    //    private TableRow CreateSummaryOfHouseholdDetailsHeaderRow()
    //    {
    //        var tableRow3 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions3 = new TablePropertyExceptions();

    //        var tableCellMarginDefault3 = new TableCellMarginDefault();
    //        var topMargin15 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin15 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault3.Append(topMargin15);
    //        tableCellMarginDefault3.Append(bottomMargin15);

    //        tablePropertyExceptions3.Append(tableCellMarginDefault3);

    //        var tableCell13 = new TableCell();

    //        var tableCellProperties13 = new TableCellProperties();
    //        var tableCellWidth13 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading13 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin13 = new TableCellMargin();
    //        var topMargin16 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin16 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin13.Append(topMargin16);
    //        tableCellMargin13.Append(bottomMargin16);

    //        tableCellProperties13.Append(tableCellWidth13);
    //        tableCellProperties13.Append(shading13);
    //        tableCellProperties13.Append(tableCellMargin13);

    //        var paragraph16 = new Paragraph()
    //        {
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties16 = new ParagraphProperties();
    //        var paragraphStyleId16 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification13 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
    //        var runFonts29 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold13 = new Bold();
    //        var fontSize29 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties16.Append(runFonts29);
    //        paragraphMarkRunProperties16.Append(bold13);
    //        paragraphMarkRunProperties16.Append(fontSize29);

    //        paragraphProperties16.Append(paragraphStyleId16);
    //        paragraphProperties16.Append(justification13);
    //        paragraphProperties16.Append(paragraphMarkRunProperties16);

    //        paragraph16.Append(paragraphProperties16);

    //        var paragraph17 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties17 = new ParagraphProperties();
    //        var paragraphStyleId17 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification14 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
    //        var runFonts30 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold14 = new Bold();
    //        var fontSize30 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties17.Append(runFonts30);
    //        paragraphMarkRunProperties17.Append(bold14);
    //        paragraphMarkRunProperties17.Append(fontSize30);

    //        paragraphProperties17.Append(paragraphStyleId17);
    //        paragraphProperties17.Append(justification14);
    //        paragraphProperties17.Append(paragraphMarkRunProperties17);

    //        var run14 = new Run();

    //        var runProperties14 = new RunProperties();
    //        var runFonts31 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold15 = new Bold();
    //        var fontSize31 = new FontSize() { Val = "24" };

    //        runProperties14.Append(runFonts31);
    //        runProperties14.Append(bold15);
    //        runProperties14.Append(fontSize31);
    //        var text14 = new Text();
    //        text14.Text = "Name";

    //        run14.Append(runProperties14);
    //        run14.Append(text14);

    //        paragraph17.Append(paragraphProperties17);
    //        paragraph17.Append(run14);

    //        tableCell13.Append(tableCellProperties13);
    //        tableCell13.Append(paragraph16);
    //        tableCell13.Append(paragraph17);

    //        var tableCell14 = new TableCell();

    //        var tableCellProperties14 = new TableCellProperties();
    //        var tableCellWidth14 = new TableCellWidth() { Width = "1220", Type = TableWidthUnitValues.Dxa };
    //        var shading14 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin14 = new TableCellMargin();
    //        var topMargin17 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin17 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin14.Append(topMargin17);
    //        tableCellMargin14.Append(bottomMargin17);

    //        tableCellProperties14.Append(tableCellWidth14);
    //        tableCellProperties14.Append(shading14);
    //        tableCellProperties14.Append(tableCellMargin14);

    //        var paragraph18 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties18 = new ParagraphProperties();
    //        var paragraphStyleId18 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification15 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
    //        var runFonts32 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold16 = new Bold();
    //        var fontSize32 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties18.Append(runFonts32);
    //        paragraphMarkRunProperties18.Append(bold16);
    //        paragraphMarkRunProperties18.Append(fontSize32);

    //        paragraphProperties18.Append(paragraphStyleId18);
    //        paragraphProperties18.Append(justification15);
    //        paragraphProperties18.Append(paragraphMarkRunProperties18);

    //        var run15 = new Run();

    //        var runProperties15 = new RunProperties();
    //        var runFonts33 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold17 = new Bold();
    //        var fontSize33 = new FontSize() { Val = "24" };

    //        runProperties15.Append(runFonts33);
    //        runProperties15.Append(bold17);
    //        runProperties15.Append(fontSize33);
    //        var text15 = new Text();
    //        text15.Text = "Type";

    //        run15.Append(runProperties15);
    //        run15.Append(text15);

    //        paragraph18.Append(paragraphProperties18);
    //        paragraph18.Append(run15);

    //        tableCell14.Append(tableCellProperties14);
    //        tableCell14.Append(paragraph18);

    //        var tableCell15 = new TableCell();

    //        var tableCellProperties15 = new TableCellProperties();
    //        var tableCellWidth15 = new TableCellWidth() { Width = "1000", Type = TableWidthUnitValues.Dxa };
    //        var shading15 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin15 = new TableCellMargin();
    //        var topMargin18 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin18 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin15.Append(topMargin18);
    //        tableCellMargin15.Append(bottomMargin18);

    //        tableCellProperties15.Append(tableCellWidth15);
    //        tableCellProperties15.Append(shading15);
    //        tableCellProperties15.Append(tableCellMargin15);

    //        var paragraph19 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties19 = new ParagraphProperties();
    //        var paragraphStyleId19 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification16 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
    //        var runFonts34 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold18 = new Bold();
    //        var fontSize34 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties19.Append(runFonts34);
    //        paragraphMarkRunProperties19.Append(bold18);
    //        paragraphMarkRunProperties19.Append(fontSize34);

    //        paragraphProperties19.Append(paragraphStyleId19);
    //        paragraphProperties19.Append(justification16);
    //        paragraphProperties19.Append(paragraphMarkRunProperties19);

    //        var run16 = new Run();

    //        var runProperties16 = new RunProperties();
    //        var runFonts35 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold19 = new Bold();
    //        var fontSize35 = new FontSize() { Val = "24" };

    //        runProperties16.Append(runFonts35);
    //        runProperties16.Append(bold19);
    //        runProperties16.Append(fontSize35);
    //        var text16 = new Text();
    //        text16.Text = "Gender";

    //        run16.Append(runProperties16);
    //        run16.Append(text16);

    //        paragraph19.Append(paragraphProperties19);
    //        paragraph19.Append(run16);

    //        tableCell15.Append(tableCellProperties15);
    //        tableCell15.Append(paragraph19);

    //        var tableCell16 = new TableCell();

    //        var tableCellProperties16 = new TableCellProperties();
    //        var tableCellWidth16 = new TableCellWidth() { Width = "1220", Type = TableWidthUnitValues.Dxa };
    //        var shading16 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin16 = new TableCellMargin();
    //        var topMargin19 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin19 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin16.Append(topMargin19);
    //        tableCellMargin16.Append(bottomMargin19);

    //        tableCellProperties16.Append(tableCellWidth16);
    //        tableCellProperties16.Append(shading16);
    //        tableCellProperties16.Append(tableCellMargin16);

    //        var paragraph20 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties20 = new ParagraphProperties();
    //        var paragraphStyleId20 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification17 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
    //        var runFonts36 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold20 = new Bold();
    //        var fontSize36 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties20.Append(runFonts36);
    //        paragraphMarkRunProperties20.Append(bold20);
    //        paragraphMarkRunProperties20.Append(fontSize36);

    //        paragraphProperties20.Append(paragraphStyleId20);
    //        paragraphProperties20.Append(justification17);
    //        paragraphProperties20.Append(paragraphMarkRunProperties20);

    //        var run17 = new Run();

    //        var runProperties17 = new RunProperties();
    //        var runFonts37 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold21 = new Bold();
    //        var fontSize37 = new FontSize() { Val = "24" };

    //        runProperties17.Append(runFonts37);
    //        runProperties17.Append(bold21);
    //        runProperties17.Append(fontSize37);
    //        var text17 = new Text();
    //        text17.Text = "DOB";

    //        run17.Append(runProperties17);
    //        run17.Append(text17);

    //        paragraph20.Append(paragraphProperties20);
    //        paragraph20.Append(run17);

    //        tableCell16.Append(tableCellProperties16);
    //        tableCell16.Append(paragraph20);

    //        var tableCell17 = new TableCell();

    //        var tableCellProperties17 = new TableCellProperties();
    //        var tableCellWidth17 = new TableCellWidth() { Width = "1480", Type = TableWidthUnitValues.Dxa };
    //        var shading17 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin17 = new TableCellMargin();
    //        var topMargin20 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin20 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin17.Append(topMargin20);
    //        tableCellMargin17.Append(bottomMargin20);

    //        tableCellProperties17.Append(tableCellWidth17);
    //        tableCellProperties17.Append(shading17);
    //        tableCellProperties17.Append(tableCellMargin17);

    //        var paragraph21 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties21 = new ParagraphProperties();
    //        var paragraphStyleId21 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification18 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
    //        var runFonts38 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold22 = new Bold();
    //        var fontSize38 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties21.Append(runFonts38);
    //        paragraphMarkRunProperties21.Append(bold22);
    //        paragraphMarkRunProperties21.Append(fontSize38);

    //        paragraphProperties21.Append(paragraphStyleId21);
    //        paragraphProperties21.Append(justification18);
    //        paragraphProperties21.Append(paragraphMarkRunProperties21);

    //        var run18 = new Run();

    //        var runProperties18 = new RunProperties();
    //        var runFonts39 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold23 = new Bold();
    //        var fontSize39 = new FontSize() { Val = "24" };

    //        runProperties18.Append(runFonts39);
    //        runProperties18.Append(bold23);
    //        runProperties18.Append(fontSize39);
    //        var text18 = new Text();
    //        text18.Text = "Nationality";

    //        run18.Append(runProperties18);
    //        run18.Append(text18);

    //        paragraph21.Append(paragraphProperties21);
    //        paragraph21.Append(run18);

    //        tableCell17.Append(tableCellProperties17);
    //        tableCell17.Append(paragraph21);

    //        var tableCell18 = new TableCell();

    //        var tableCellProperties18 = new TableCellProperties();
    //        var tableCellWidth18 = new TableCellWidth() { Width = "1040", Type = TableWidthUnitValues.Dxa };
    //        var shading18 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin18 = new TableCellMargin();
    //        var topMargin21 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin21 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin18.Append(topMargin21);
    //        tableCellMargin18.Append(bottomMargin21);

    //        tableCellProperties18.Append(tableCellWidth18);
    //        tableCellProperties18.Append(shading18);
    //        tableCellProperties18.Append(tableCellMargin18);

    //        var paragraph22 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties22 = new ParagraphProperties();
    //        var paragraphStyleId22 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification19 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
    //        var runFonts40 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold24 = new Bold();
    //        var fontSize40 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties22.Append(runFonts40);
    //        paragraphMarkRunProperties22.Append(bold24);
    //        paragraphMarkRunProperties22.Append(fontSize40);

    //        paragraphProperties22.Append(paragraphStyleId22);
    //        paragraphProperties22.Append(justification19);
    //        paragraphProperties22.Append(paragraphMarkRunProperties22);

    //        var run19 = new Run();

    //        var runProperties19 = new RunProperties();
    //        var runFonts41 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold25 = new Bold();
    //        var fontSize41 = new FontSize() { Val = "24" };

    //        runProperties19.Append(runFonts41);
    //        runProperties19.Append(bold25);
    //        runProperties19.Append(fontSize41);
    //        var text19 = new Text();
    //        text19.Text = "Eligible";

    //        run19.Append(runProperties19);
    //        run19.Append(text19);

    //        paragraph22.Append(paragraphProperties22);
    //        paragraph22.Append(run19);

    //        tableCell18.Append(tableCellProperties18);
    //        tableCell18.Append(paragraph22);

    //        var tableCell19 = new TableCell();

    //        var tableCellProperties19 = new TableCellProperties();
    //        var tableCellWidth19 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading19 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin19 = new TableCellMargin();
    //        var topMargin22 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin22 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin19.Append(topMargin22);
    //        tableCellMargin19.Append(bottomMargin22);

    //        tableCellProperties19.Append(tableCellWidth19);
    //        tableCellProperties19.Append(shading19);
    //        tableCellProperties19.Append(tableCellMargin19);

    //        var paragraph23 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties23 = new ParagraphProperties();
    //        var paragraphStyleId23 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification20 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
    //        var runFonts42 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold26 = new Bold();
    //        var fontSize42 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties23.Append(runFonts42);
    //        paragraphMarkRunProperties23.Append(bold26);
    //        paragraphMarkRunProperties23.Append(fontSize42);

    //        paragraphProperties23.Append(paragraphStyleId23);
    //        paragraphProperties23.Append(justification20);
    //        paragraphProperties23.Append(paragraphMarkRunProperties23);

    //        var run20 = new Run();

    //        var runProperties20 = new RunProperties();
    //        var runFonts43 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold27 = new Bold();
    //        var fontSize43 = new FontSize() { Val = "24" };

    //        runProperties20.Append(runFonts43);
    //        runProperties20.Append(bold27);
    //        runProperties20.Append(fontSize43);
    //        var text20 = new Text();
    //        text20.Text = "Relationship To Applicant";

    //        run20.Append(runProperties20);
    //        run20.Append(text20);

    //        paragraph23.Append(paragraphProperties23);
    //        paragraph23.Append(run20);

    //        tableCell19.Append(tableCellProperties19);
    //        tableCell19.Append(paragraph23);

    //        var tableCell20 = new TableCell();

    //        var tableCellProperties20 = new TableCellProperties();
    //        var tableCellWidth20 = new TableCellWidth() { Width = "800", Type = TableWidthUnitValues.Dxa };
    //        var shading20 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin20 = new TableCellMargin();
    //        var topMargin23 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin23 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin20.Append(topMargin23);
    //        tableCellMargin20.Append(bottomMargin23);

    //        tableCellProperties20.Append(tableCellWidth20);
    //        tableCellProperties20.Append(shading20);
    //        tableCellProperties20.Append(tableCellMargin20);

    //        var paragraph24 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties24 = new ParagraphProperties();
    //        var paragraphStyleId24 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification21 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
    //        var runFonts44 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold28 = new Bold();
    //        var fontSize44 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties24.Append(runFonts44);
    //        paragraphMarkRunProperties24.Append(bold28);
    //        paragraphMarkRunProperties24.Append(fontSize44);

    //        paragraphProperties24.Append(paragraphStyleId24);
    //        paragraphProperties24.Append(justification21);
    //        paragraphProperties24.Append(paragraphMarkRunProperties24);

    //        var run21 = new Run();

    //        var runProperties21 = new RunProperties();
    //        var runFonts45 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold29 = new Bold();
    //        var fontSize45 = new FontSize() { Val = "24" };

    //        runProperties21.Append(runFonts45);
    //        runProperties21.Append(bold29);
    //        runProperties21.Append(fontSize45);
    //        var text21 = new Text();
    //        text21.Text = "Disabled";

    //        run21.Append(runProperties21);
    //        run21.Append(text21);

    //        paragraph24.Append(paragraphProperties24);
    //        paragraph24.Append(run21);

    //        tableCell20.Append(tableCellProperties20);
    //        tableCell20.Append(paragraph24);

    //        var tableCell21 = new TableCell();

    //        var tableCellProperties21 = new TableCellProperties();
    //        var tableCellWidth21 = new TableCellWidth() { Width = "800", Type = TableWidthUnitValues.Dxa };
    //        var shading21 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin21 = new TableCellMargin();
    //        var topMargin24 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin24 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin21.Append(topMargin24);
    //        tableCellMargin21.Append(bottomMargin24);

    //        tableCellProperties21.Append(tableCellWidth21);
    //        tableCellProperties21.Append(shading21);
    //        tableCellProperties21.Append(tableCellMargin21);

    //        var paragraph25 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties25 = new ParagraphProperties();
    //        var paragraphStyleId25 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification22 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
    //        var runFonts46 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold30 = new Bold();
    //        var fontSize46 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties25.Append(runFonts46);
    //        paragraphMarkRunProperties25.Append(bold30);
    //        paragraphMarkRunProperties25.Append(fontSize46);

    //        paragraphProperties25.Append(paragraphStyleId25);
    //        paragraphProperties25.Append(justification22);
    //        paragraphProperties25.Append(paragraphMarkRunProperties25);

    //        var run22 = new Run();

    //        var runProperties22 = new RunProperties();
    //        var runFonts47 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold31 = new Bold();
    //        var fontSize47 = new FontSize() { Val = "24" };

    //        runProperties22.Append(runFonts47);
    //        runProperties22.Append(bold31);
    //        runProperties22.Append(fontSize47);
    //        var text22 = new Text();
    //        text22.Text = "Pregnant";

    //        run22.Append(runProperties22);
    //        run22.Append(text22);

    //        paragraph25.Append(paragraphProperties25);
    //        paragraph25.Append(run22);

    //        tableCell21.Append(tableCellProperties21);
    //        tableCell21.Append(paragraph25);

    //        tableRow3.Append(tablePropertyExceptions3);
    //        tableRow3.Append(tableCell13);
    //        tableRow3.Append(tableCell14);
    //        tableRow3.Append(tableCell15);
    //        tableRow3.Append(tableCell16);
    //        tableRow3.Append(tableCell17);
    //        tableRow3.Append(tableCell18);
    //        tableRow3.Append(tableCell19);
    //        tableRow3.Append(tableCell20);
    //        tableRow3.Append(tableCell21);
    //        return tableRow3;
    //    }
    //    private TableRow CreateSummaryOfHouseholdDetailsDataRow(VBLContact contact)
    //    {
    //        var tableRow4 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions4 = new TablePropertyExceptions();

    //        var tableCellMarginDefault4 = new TableCellMarginDefault();
    //        var topMargin25 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin25 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault4.Append(topMargin25);
    //        tableCellMarginDefault4.Append(bottomMargin25);

    //        tablePropertyExceptions4.Append(tableCellMarginDefault4);

    //        var tableCell22 = new TableCell();

    //        var tableCellProperties22 = new TableCellProperties();
    //        var tableCellWidth22 = new TableCellWidth() { Width = "1640", Type = TableWidthUnitValues.Dxa };
    //        var shading22 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin22 = new TableCellMargin();
    //        var topMargin26 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin26 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin22.Append(topMargin26);
    //        tableCellMargin22.Append(bottomMargin26);

    //        tableCellProperties22.Append(tableCellWidth22);
    //        tableCellProperties22.Append(shading22);
    //        tableCellProperties22.Append(tableCellMargin22);

    //        var paragraph26 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties26 = new ParagraphProperties();
    //        var paragraphStyleId26 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
    //        var runFonts48 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize48 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties26.Append(runFonts48);
    //        paragraphMarkRunProperties26.Append(fontSize48);

    //        paragraphProperties26.Append(paragraphStyleId26);
    //        paragraphProperties26.Append(paragraphMarkRunProperties26);

    //        var run23 = new Run();

    //        var runProperties23 = new RunProperties();
    //        var runFonts49 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize49 = new FontSize() { Val = "24" };

    //        runProperties23.Append(runFonts49);
    //        runProperties23.Append(fontSize49);
    //        var text23 = new Text();
    //        text23.Text = contact.Forename + " " + contact.Surname; //Edited

    //        run23.Append(runProperties23);
    //        run23.Append(text23);

    //        paragraph26.Append(paragraphProperties26);
    //        paragraph26.Append(run23);

    //        tableCell22.Append(tableCellProperties22);
    //        tableCell22.Append(paragraph26);

    //        var tableCell23 = new TableCell();

    //        var tableCellProperties23 = new TableCellProperties();
    //        var tableCellWidth23 = new TableCellWidth() { Width = "1200", Type = TableWidthUnitValues.Dxa };
    //        var shading23 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin23 = new TableCellMargin();
    //        var topMargin27 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin27 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin23.Append(topMargin27);
    //        tableCellMargin23.Append(bottomMargin27);

    //        tableCellProperties23.Append(tableCellWidth23);
    //        tableCellProperties23.Append(shading23);
    //        tableCellProperties23.Append(tableCellMargin23);

    //        var paragraph27 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties27 = new ParagraphProperties();
    //        var paragraphStyleId27 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
    //        var runFonts50 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize50 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties27.Append(runFonts50);
    //        paragraphMarkRunProperties27.Append(fontSize50);

    //        paragraphProperties27.Append(paragraphStyleId27);
    //        paragraphProperties27.Append(paragraphMarkRunProperties27);

    //        var run24 = new Run();

    //        var runProperties24 = new RunProperties();
    //        var runFonts51 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize51 = new FontSize() { Val = "24" };

    //        runProperties24.Append(runFonts51);
    //        runProperties24.Append(fontSize51);
    //        var text24 = new Text();
    //        text24.Text = contact.ContactTypeId == 1 ? "Applicant" : "Household Member";

    //        run24.Append(runProperties24);
    //        run24.Append(text24);

    //        paragraph27.Append(paragraphProperties27);
    //        paragraph27.Append(run24);

    //        tableCell23.Append(tableCellProperties23);
    //        tableCell23.Append(paragraph27);

    //        var tableCell24 = new TableCell();

    //        var tableCellProperties24 = new TableCellProperties();
    //        var tableCellWidth24 = new TableCellWidth() { Width = "1000", Type = TableWidthUnitValues.Dxa };
    //        var shading24 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin24 = new TableCellMargin();
    //        var topMargin28 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin28 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin24.Append(topMargin28);
    //        tableCellMargin24.Append(bottomMargin28);

    //        tableCellProperties24.Append(tableCellWidth24);
    //        tableCellProperties24.Append(shading24);
    //        tableCellProperties24.Append(tableCellMargin24);

    //        var paragraph28 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties28 = new ParagraphProperties();
    //        var paragraphStyleId28 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
    //        var runFonts52 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize52 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties28.Append(runFonts52);
    //        paragraphMarkRunProperties28.Append(fontSize52);

    //        paragraphProperties28.Append(paragraphStyleId28);
    //        paragraphProperties28.Append(paragraphMarkRunProperties28);

    //        var run25 = new Run();

    //        var runProperties25 = new RunProperties();
    //        var runFonts53 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize53 = new FontSize() { Val = "24" };

    //        runProperties25.Append(runFonts53);
    //        runProperties25.Append(fontSize53);
    //        var text25 = new Text();
    //        text25.Text = contact.Gender.Name;

    //        run25.Append(runProperties25);
    //        run25.Append(text25);

    //        paragraph28.Append(paragraphProperties28);
    //        paragraph28.Append(run25);

    //        tableCell24.Append(tableCellProperties24);
    //        tableCell24.Append(paragraph28);

    //        var tableCell25 = new TableCell();

    //        var tableCellProperties25 = new TableCellProperties();
    //        var tableCellWidth25 = new TableCellWidth() { Width = "1200", Type = TableWidthUnitValues.Dxa };
    //        var shading25 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin25 = new TableCellMargin();
    //        var topMargin29 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin29 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin25.Append(topMargin29);
    //        tableCellMargin25.Append(bottomMargin29);

    //        tableCellProperties25.Append(tableCellWidth25);
    //        tableCellProperties25.Append(shading25);
    //        tableCellProperties25.Append(tableCellMargin25);

    //        var paragraph29 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties29 = new ParagraphProperties();
    //        var paragraphStyleId29 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
    //        var runFonts54 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize54 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties29.Append(runFonts54);
    //        paragraphMarkRunProperties29.Append(fontSize54);

    //        paragraphProperties29.Append(paragraphStyleId29);
    //        paragraphProperties29.Append(paragraphMarkRunProperties29);

    //        var run26 = new Run();

    //        var runProperties26 = new RunProperties();
    //        var runFonts55 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize55 = new FontSize() { Val = "24" };

    //        runProperties26.Append(runFonts55);
    //        runProperties26.Append(fontSize55);
    //        var text26 = new Text();
    //        text26.Text = contact.DateOfBirth.ToShortDateString();

    //        run26.Append(runProperties26);
    //        run26.Append(text26);

    //        paragraph29.Append(paragraphProperties29);
    //        paragraph29.Append(run26);

    //        tableCell25.Append(tableCellProperties25);
    //        tableCell25.Append(paragraph29);

    //        var tableCell26 = new TableCell();

    //        var tableCellProperties26 = new TableCellProperties();
    //        var tableCellWidth26 = new TableCellWidth() { Width = "1480", Type = TableWidthUnitValues.Dxa };
    //        var shading26 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin26 = new TableCellMargin();
    //        var topMargin30 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin30 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin26.Append(topMargin30);
    //        tableCellMargin26.Append(bottomMargin30);

    //        tableCellProperties26.Append(tableCellWidth26);
    //        tableCellProperties26.Append(shading26);
    //        tableCellProperties26.Append(tableCellMargin26);

    //        var paragraph30 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties30 = new ParagraphProperties();
    //        var paragraphStyleId30 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
    //        var runFonts56 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize56 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties30.Append(runFonts56);
    //        paragraphMarkRunProperties30.Append(fontSize56);

    //        paragraphProperties30.Append(paragraphStyleId30);
    //        paragraphProperties30.Append(paragraphMarkRunProperties30);

    //        var run27 = new Run();

    //        var runProperties27 = new RunProperties();
    //        var runFonts57 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize57 = new FontSize() { Val = "24" };

    //        runProperties27.Append(runFonts57);
    //        runProperties27.Append(fontSize57);
    //        var text27 = new Text();
    //        text27.Text = contact.NationalityType.Name;

    //        run27.Append(runProperties27);
    //        run27.Append(text27);

    //        paragraph30.Append(paragraphProperties30);
    //        paragraph30.Append(run27);

    //        tableCell26.Append(tableCellProperties26);
    //        tableCell26.Append(paragraph30);

    //        var tableCell27 = new TableCell();

    //        var tableCellProperties27 = new TableCellProperties();
    //        var tableCellWidth27 = new TableCellWidth() { Width = "1040", Type = TableWidthUnitValues.Dxa };
    //        var shading27 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin27 = new TableCellMargin();
    //        var topMargin31 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin31 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin27.Append(topMargin31);
    //        tableCellMargin27.Append(bottomMargin31);

    //        tableCellProperties27.Append(tableCellWidth27);
    //        tableCellProperties27.Append(shading27);
    //        tableCellProperties27.Append(tableCellMargin27);

    //        var paragraph31 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties31 = new ParagraphProperties();
    //        var paragraphStyleId31 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
    //        var runFonts58 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize58 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties31.Append(runFonts58);
    //        paragraphMarkRunProperties31.Append(fontSize58);

    //        paragraphProperties31.Append(paragraphStyleId31);
    //        paragraphProperties31.Append(paragraphMarkRunProperties31);

    //        var run28 = new Run();

    //        var runProperties28 = new RunProperties();
    //        var runFonts59 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize59 = new FontSize() { Val = "24" };

    //        runProperties28.Append(runFonts59);
    //        runProperties28.Append(fontSize59);
    //        var text28 = new Text();
    //        text28.Text = contact.PublicFunds && !contact.ImmigrationControl && contact.LivedInUKForFiveYears ? "Yes" : "No";

    //        run28.Append(runProperties28);
    //        run28.Append(text28);

    //        paragraph31.Append(paragraphProperties31);
    //        paragraph31.Append(run28);

    //        tableCell27.Append(tableCellProperties27);
    //        tableCell27.Append(paragraph31);



    //        var tableCellRelationship = new TableCell();

    //        var tableCellProperties46 = new TableCellProperties();
    //        var tableCellWidth46 = new TableCellWidth() { Width = "1600", Type = TableWidthUnitValues.Dxa };
    //        var shading46 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin46 = new TableCellMargin();
    //        var topMargin52 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin52 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin46.Append(topMargin52);
    //        tableCellMargin46.Append(bottomMargin52);

    //        tableCellProperties46.Append(tableCellWidth46);
    //        tableCellProperties46.Append(shading46);
    //        tableCellProperties46.Append(tableCellMargin46);

    //        var paragraphRelationship = new Paragraph() { RsidParagraphMarkRevision = "00B46F26", RsidParagraphAddition = "00602ED1", RsidParagraphProperties = "00BA3FA1", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties50 = new ParagraphProperties();
    //        var paragraphStyleId50 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties50 = new ParagraphMarkRunProperties();
    //        var runFonts95 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize95 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties50.Append(runFonts95);
    //        paragraphMarkRunProperties50.Append(fontSize95);

    //        paragraphProperties50.Append(paragraphStyleId50);
    //        paragraphProperties50.Append(paragraphMarkRunProperties50);

    //        var runRelationship = new Run();

    //        var runProperties46 = new RunProperties();
    //        var runFonts96 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize96 = new FontSize() { Val = "24" };

    //        runProperties46.Append(runFonts96);
    //        runProperties46.Append(fontSize96);
    //        var text46 = new Text();
    //        text46.Text = contact.Relationship != null ? contact.Relationship.Name : string.Empty;

    //        runRelationship.Append(runProperties46);
    //        runRelationship.Append(text46);

    //        paragraphRelationship.Append(paragraphProperties50);
    //        paragraphRelationship.Append(runRelationship);

    //        tableCellRelationship.Append(tableCellProperties46);
    //        tableCellRelationship.Append(paragraphRelationship);

    //        var tableCell29 = new TableCell();

    //        var tableCellProperties29 = new TableCellProperties();
    //        var tableCellWidth29 = new TableCellWidth() { Width = "800", Type = TableWidthUnitValues.Dxa };
    //        var shading29 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin29 = new TableCellMargin();
    //        var topMargin33 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin33 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin29.Append(topMargin33);
    //        tableCellMargin29.Append(bottomMargin33);

    //        tableCellProperties29.Append(tableCellWidth29);
    //        tableCellProperties29.Append(shading29);
    //        tableCellProperties29.Append(tableCellMargin29);

    //        var paragraph33 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties33 = new ParagraphProperties();
    //        var paragraphStyleId33 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
    //        var runFonts61 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize61 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties33.Append(runFonts61);
    //        paragraphMarkRunProperties33.Append(fontSize61);

    //        paragraphProperties33.Append(paragraphStyleId33);
    //        paragraphProperties33.Append(paragraphMarkRunProperties33);

    //        var run29 = new Run();

    //        var runProperties29 = new RunProperties();
    //        var runFonts62 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize62 = new FontSize() { Val = "24" };

    //        runProperties29.Append(runFonts62);
    //        runProperties29.Append(fontSize62);
    //        var text29 = new Text();
    //        text29.Text = contact.DisabilityDetails.Any() ? "Yes" : "No";

    //        run29.Append(runProperties29);
    //        run29.Append(text29);

    //        paragraph33.Append(paragraphProperties33);
    //        paragraph33.Append(run29);

    //        tableCell29.Append(tableCellProperties29);
    //        tableCell29.Append(paragraph33);

    //        var tableCell30 = new TableCell();

    //        var tableCellProperties30 = new TableCellProperties();
    //        var tableCellWidth30 = new TableCellWidth() { Width = "800", Type = TableWidthUnitValues.Dxa };
    //        var shading30 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin30 = new TableCellMargin();
    //        var topMargin34 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin34 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin30.Append(topMargin34);
    //        tableCellMargin30.Append(bottomMargin34);

    //        tableCellProperties30.Append(tableCellWidth30);
    //        tableCellProperties30.Append(shading30);
    //        tableCellProperties30.Append(tableCellMargin30);

    //        var paragraph34 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties34 = new ParagraphProperties();
    //        var paragraphStyleId34 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
    //        var runFonts63 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize63 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties34.Append(runFonts63);
    //        paragraphMarkRunProperties34.Append(fontSize63);

    //        paragraphProperties34.Append(paragraphStyleId34);
    //        paragraphProperties34.Append(paragraphMarkRunProperties34);

    //        var run30 = new Run();

    //        var runProperties30 = new RunProperties();
    //        var runFonts64 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize64 = new FontSize() { Val = "24" };

    //        runProperties30.Append(runFonts64);
    //        runProperties30.Append(fontSize64);
    //        var text30 = new Text();
    //        text30.Text = contact.IsPregnant ? "Yes" : "No";

    //        run30.Append(runProperties30);
    //        run30.Append(text30);

    //        paragraph34.Append(paragraphProperties34);
    //        paragraph34.Append(run30);

    //        tableCell30.Append(tableCellProperties30);
    //        tableCell30.Append(paragraph34);

    //        tableRow4.Append(tablePropertyExceptions4);
    //        tableRow4.Append(tableCell22);
    //        tableRow4.Append(tableCell23);
    //        tableRow4.Append(tableCell24);
    //        tableRow4.Append(tableCell25);
    //        tableRow4.Append(tableCell26);
    //        tableRow4.Append(tableCell27);
    //        tableRow4.Append(tableCellRelationship);
    //        tableRow4.Append(tableCell29);
    //        tableRow4.Append(tableCell30);
    //        return tableRow4;
    //    }

    //    #endregion

    //    #region Application Details
    //    private Paragraph CreateApplicationDetails(out Table table1)
    //    {
    //        var paragraph1 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00602ED1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties1 = new ParagraphProperties();
    //        var paragraphStyleId1 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
    //        var runFonts1 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize1 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties1.Append(runFonts1);
    //        paragraphMarkRunProperties1.Append(fontSize1);

    //        paragraphProperties1.Append(paragraphStyleId1);
    //        paragraphProperties1.Append(paragraphMarkRunProperties1);

    //        var run1 = new Run();

    //        var runProperties1 = new RunProperties();
    //        var runFonts2 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize2 = new FontSize() { Val = "24" };

    //        runProperties1.Append(runFonts2);
    //        runProperties1.Append(fontSize2);
    //        var text1 = new Text();
    //        text1.Text = "Application Details";

    //        run1.Append(runProperties1);
    //        run1.Append(text1);

    //        paragraph1.Append(paragraphProperties1);
    //        paragraph1.Append(run1);

    //        table1 = new Table();

    //        var tableProperties1 = new TableProperties();
    //        var tableWidth1 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

    //        var tableBorders1 = new TableBorders();
    //        var topBorder1 = new TopBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var leftBorder1 = new LeftBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var bottomBorder1 = new BottomBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var rightBorder1 = new RightBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideHorizontalBorder1 = new InsideHorizontalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };
    //        var insideVerticalBorder1 = new InsideVerticalBorder()
    //        {
    //            Val = BorderValues.Single,
    //            Color = "000000",
    //            Size = (UInt32Value)4U,
    //            Space = (UInt32Value)0U
    //        };

    //        tableBorders1.Append(topBorder1);
    //        tableBorders1.Append(leftBorder1);
    //        tableBorders1.Append(bottomBorder1);
    //        tableBorders1.Append(rightBorder1);
    //        tableBorders1.Append(insideHorizontalBorder1);
    //        tableBorders1.Append(insideVerticalBorder1);
    //        var tableLayout1 = new TableLayout() { Type = TableLayoutValues.Fixed };
    //        var tableLook1 = new TableLook()
    //        {
    //            Val = "0000",
    //            FirstRow = false,
    //            LastRow = false,
    //            FirstColumn = false,
    //            LastColumn = false,
    //            NoHorizontalBand = false,
    //            NoVerticalBand = false
    //        };

    //        tableProperties1.Append(tableWidth1);
    //        tableProperties1.Append(tableBorders1);
    //        tableProperties1.Append(tableLayout1);
    //        tableProperties1.Append(tableLook1);

    //        var tableGrid1 = new TableGrid();
    //        var gridColumn1 = new GridColumn() { Width = "1780" };
    //        var gridColumn2 = new GridColumn() { Width = "1780" };
    //        var gridColumn3 = new GridColumn() { Width = "1780" };
    //        var gridColumn4 = new GridColumn() { Width = "1780" };
    //        var gridColumn5 = new GridColumn() { Width = "1781" };
    //        var gridColumn6 = new GridColumn() { Width = "1781" };

    //        tableGrid1.Append(gridColumn1);
    //        tableGrid1.Append(gridColumn2);
    //        tableGrid1.Append(gridColumn3);
    //        tableGrid1.Append(gridColumn4);
    //        tableGrid1.Append(gridColumn5);
    //        tableGrid1.Append(gridColumn6);

    //        var tableRow1 = CreateApplicationDetailsHeader();
    //        var tableRow2 = CreateApplicationDetailsDataRow();

    //        table1.Append(tableProperties1);
    //        table1.Append(tableGrid1);
    //        table1.Append(tableRow1);
    //        table1.Append(tableRow2);
    //        return paragraph1;
    //    }
    //    private TableRow CreateApplicationDetailsHeader()
    //    {
    //        var tableRow1 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions1 = new TablePropertyExceptions();

    //        var tableCellMarginDefault1 = new TableCellMarginDefault();
    //        var topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault1.Append(topMargin1);
    //        tableCellMarginDefault1.Append(bottomMargin1);

    //        tablePropertyExceptions1.Append(tableCellMarginDefault1);

    //        var tableCell1 = new TableCell();

    //        var tableCellProperties1 = new TableCellProperties();
    //        var tableCellWidth1 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin1 = new TableCellMargin();
    //        var topMargin2 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin2 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin1.Append(topMargin2);
    //        tableCellMargin1.Append(bottomMargin2);

    //        tableCellProperties1.Append(tableCellWidth1);
    //        tableCellProperties1.Append(shading1);
    //        tableCellProperties1.Append(tableCellMargin1);

    //        var paragraph2 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties2 = new ParagraphProperties();
    //        var paragraphStyleId2 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification1 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
    //        var runFonts3 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold1 = new Bold();
    //        var fontSize3 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties2.Append(runFonts3);
    //        paragraphMarkRunProperties2.Append(bold1);
    //        paragraphMarkRunProperties2.Append(fontSize3);

    //        paragraphProperties2.Append(paragraphStyleId2);
    //        paragraphProperties2.Append(justification1);
    //        paragraphProperties2.Append(paragraphMarkRunProperties2);

    //        var run2 = new Run();

    //        var runProperties2 = new RunProperties();
    //        var runFonts4 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold2 = new Bold();
    //        var fontSize4 = new FontSize() { Val = "24" };

    //        runProperties2.Append(runFonts4);
    //        runProperties2.Append(bold2);
    //        runProperties2.Append(fontSize4);
    //        var text2 = new Text();
    //        text2.Text = "Application Status";

    //        run2.Append(runProperties2);
    //        run2.Append(text2);

    //        paragraph2.Append(paragraphProperties2);
    //        paragraph2.Append(run2);

    //        tableCell1.Append(tableCellProperties1);
    //        tableCell1.Append(paragraph2);

    //        var tableCell2 = new TableCell();

    //        var tableCellProperties2 = new TableCellProperties();
    //        var tableCellWidth2 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin2 = new TableCellMargin();
    //        var topMargin3 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin3 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin2.Append(topMargin3);
    //        tableCellMargin2.Append(bottomMargin3);

    //        tableCellProperties2.Append(tableCellWidth2);
    //        tableCellProperties2.Append(shading2);
    //        tableCellProperties2.Append(tableCellMargin2);

    //        var paragraph3 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties3 = new ParagraphProperties();
    //        var paragraphStyleId3 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification2 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
    //        var runFonts5 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold3 = new Bold();
    //        var fontSize5 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties3.Append(runFonts5);
    //        paragraphMarkRunProperties3.Append(bold3);
    //        paragraphMarkRunProperties3.Append(fontSize5);

    //        paragraphProperties3.Append(paragraphStyleId3);
    //        paragraphProperties3.Append(justification2);
    //        paragraphProperties3.Append(paragraphMarkRunProperties3);

    //        var run3 = new Run();

    //        var runProperties3 = new RunProperties();
    //        var runFonts6 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold4 = new Bold();
    //        var fontSize6 = new FontSize() { Val = "24" };

    //        runProperties3.Append(runFonts6);
    //        runProperties3.Append(bold4);
    //        runProperties3.Append(fontSize6);
    //        var text3 = new Text();
    //        text3.Text = "Application Date";

    //        run3.Append(runProperties3);
    //        run3.Append(text3);

    //        paragraph3.Append(paragraphProperties3);
    //        paragraph3.Append(run3);

    //        tableCell2.Append(tableCellProperties2);
    //        tableCell2.Append(paragraph3);

    //        var tableCell3 = new TableCell();

    //        var tableCellProperties3 = new TableCellProperties();
    //        var tableCellWidth3 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin3 = new TableCellMargin();
    //        var topMargin4 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin4 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin3.Append(topMargin4);
    //        tableCellMargin3.Append(bottomMargin4);

    //        tableCellProperties3.Append(tableCellWidth3);
    //        tableCellProperties3.Append(shading3);
    //        tableCellProperties3.Append(tableCellMargin3);

    //        var paragraph4 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties4 = new ParagraphProperties();
    //        var paragraphStyleId4 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification3 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
    //        var runFonts7 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold5 = new Bold();
    //        var fontSize7 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties4.Append(runFonts7);
    //        paragraphMarkRunProperties4.Append(bold5);
    //        paragraphMarkRunProperties4.Append(fontSize7);

    //        paragraphProperties4.Append(paragraphStyleId4);
    //        paragraphProperties4.Append(justification3);
    //        paragraphProperties4.Append(paragraphMarkRunProperties4);

    //        var run4 = new Run();

    //        var runProperties4 = new RunProperties();
    //        var runFonts8 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold6 = new Bold();
    //        var fontSize8 = new FontSize() { Val = "24" };

    //        runProperties4.Append(runFonts8);
    //        runProperties4.Append(bold6);
    //        runProperties4.Append(fontSize8);
    //        var text4 = new Text();
    //        text4.Text = "Banding";

    //        run4.Append(runProperties4);
    //        run4.Append(text4);

    //        paragraph4.Append(paragraphProperties4);
    //        paragraph4.Append(run4);

    //        tableCell3.Append(tableCellProperties3);
    //        tableCell3.Append(paragraph4);

    //        var tableCell4 = new TableCell();

    //        var tableCellProperties4 = new TableCellProperties();
    //        var tableCellWidth4 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin4 = new TableCellMargin();
    //        var topMargin5 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin5 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin4.Append(topMargin5);
    //        tableCellMargin4.Append(bottomMargin5);

    //        tableCellProperties4.Append(tableCellWidth4);
    //        tableCellProperties4.Append(shading4);
    //        tableCellProperties4.Append(tableCellMargin4);

    //        var paragraph5 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties5 = new ParagraphProperties();
    //        var paragraphStyleId5 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification4 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
    //        var runFonts9 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold7 = new Bold();
    //        var fontSize9 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties5.Append(runFonts9);
    //        paragraphMarkRunProperties5.Append(bold7);
    //        paragraphMarkRunProperties5.Append(fontSize9);

    //        paragraphProperties5.Append(paragraphStyleId5);
    //        paragraphProperties5.Append(justification4);
    //        paragraphProperties5.Append(paragraphMarkRunProperties5);

    //        var run5 = new Run();

    //        var runProperties5 = new RunProperties();
    //        var runFonts10 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold8 = new Bold();
    //        var fontSize10 = new FontSize() { Val = "24" };

    //        runProperties5.Append(runFonts10);
    //        runProperties5.Append(bold8);
    //        runProperties5.Append(fontSize10);
    //        var text5 = new Text();
    //        text5.Text = "Eligibility";

    //        run5.Append(runProperties5);
    //        run5.Append(text5);

    //        paragraph5.Append(paragraphProperties5);
    //        paragraph5.Append(run5);

    //        tableCell4.Append(tableCellProperties4);
    //        tableCell4.Append(paragraph5);

    //        var tableCell5 = new TableCell();

    //        var tableCellProperties5 = new TableCellProperties();
    //        var tableCellWidth5 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };
    //        var shading5 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin5 = new TableCellMargin();
    //        var topMargin6 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin6 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin5.Append(topMargin6);
    //        tableCellMargin5.Append(bottomMargin6);

    //        tableCellProperties5.Append(tableCellWidth5);
    //        tableCellProperties5.Append(shading5);
    //        tableCellProperties5.Append(tableCellMargin5);

    //        var paragraph6 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties6 = new ParagraphProperties();
    //        var paragraphStyleId6 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification5 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
    //        var runFonts11 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold9 = new Bold();
    //        var fontSize11 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties6.Append(runFonts11);
    //        paragraphMarkRunProperties6.Append(bold9);
    //        paragraphMarkRunProperties6.Append(fontSize11);

    //        paragraphProperties6.Append(paragraphStyleId6);
    //        paragraphProperties6.Append(justification5);
    //        paragraphProperties6.Append(paragraphMarkRunProperties6);

    //        var run6 = new Run();

    //        var runProperties6 = new RunProperties();
    //        var runFonts12 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold10 = new Bold();
    //        var fontSize12 = new FontSize() { Val = "24" };

    //        runProperties6.Append(runFonts12);
    //        runProperties6.Append(bold10);
    //        runProperties6.Append(fontSize12);
    //        var text6 = new Text();
    //        text6.Text = "HOA Case";

    //        run6.Append(runProperties6);
    //        run6.Append(text6);

    //        paragraph6.Append(paragraphProperties6);
    //        paragraph6.Append(run6);

    //        tableCell5.Append(tableCellProperties5);
    //        tableCell5.Append(paragraph6);

    //        var tableCell6 = new TableCell();

    //        var tableCellProperties6 = new TableCellProperties();
    //        var tableCellWidth6 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };
    //        var shading6 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin6 = new TableCellMargin();
    //        var topMargin7 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin7 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin6.Append(topMargin7);
    //        tableCellMargin6.Append(bottomMargin7);

    //        tableCellProperties6.Append(tableCellWidth6);
    //        tableCellProperties6.Append(shading6);
    //        tableCellProperties6.Append(tableCellMargin6);

    //        var paragraph7 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties7 = new ParagraphProperties();
    //        var paragraphStyleId7 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification6 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
    //        var runFonts13 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold11 = new Bold();
    //        var fontSize13 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties7.Append(runFonts13);
    //        paragraphMarkRunProperties7.Append(bold11);
    //        paragraphMarkRunProperties7.Append(fontSize13);

    //        paragraphProperties7.Append(paragraphStyleId7);
    //        paragraphProperties7.Append(justification6);
    //        paragraphProperties7.Append(paragraphMarkRunProperties7);

    //        var run7 = new Run();

    //        var runProperties7 = new RunProperties();
    //        var runFonts14 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var bold12 = new Bold();
    //        var fontSize14 = new FontSize() { Val = "24" };

    //        runProperties7.Append(runFonts14);
    //        runProperties7.Append(bold12);
    //        runProperties7.Append(fontSize14);
    //        var text7 = new Text();
    //        text7.Text = "Appointment";

    //        run7.Append(runProperties7);
    //        run7.Append(text7);

    //        paragraph7.Append(paragraphProperties7);
    //        paragraph7.Append(run7);

    //        tableCell6.Append(tableCellProperties6);
    //        tableCell6.Append(paragraph7);

    //        tableRow1.Append(tablePropertyExceptions1);
    //        tableRow1.Append(tableCell1);
    //        tableRow1.Append(tableCell2);
    //        tableRow1.Append(tableCell3);
    //        tableRow1.Append(tableCell4);
    //        tableRow1.Append(tableCell5);
    //        tableRow1.Append(tableCell6);
    //        return tableRow1;
    //    }
    //    private TableRow CreateApplicationDetailsDataRow()
    //    {
    //        var tableRow2 = new TableRow()
    //        {
    //            RsidTableRowMarkRevision = "00B46F26",
    //            RsidTableRowAddition = "00602ED1",
    //            RsidTableRowProperties = "00BA3FA1"
    //        };

    //        var tablePropertyExceptions2 = new TablePropertyExceptions();

    //        var tableCellMarginDefault2 = new TableCellMarginDefault();
    //        var topMargin8 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin8 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };

    //        tableCellMarginDefault2.Append(topMargin8);
    //        tableCellMarginDefault2.Append(bottomMargin8);

    //        tablePropertyExceptions2.Append(tableCellMarginDefault2);

    //        var tableCell7 = new TableCell();

    //        var tableCellProperties7 = new TableCellProperties();
    //        var tableCellWidth7 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading7 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin7 = new TableCellMargin();
    //        var topMargin9 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin9 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin7.Append(topMargin9);
    //        tableCellMargin7.Append(bottomMargin9);

    //        tableCellProperties7.Append(tableCellWidth7);
    //        tableCellProperties7.Append(shading7);
    //        tableCellProperties7.Append(tableCellMargin7);

    //        var paragraph8 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties8 = new ParagraphProperties();
    //        var paragraphStyleId8 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification7 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
    //        var runFonts15 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize15 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties8.Append(runFonts15);
    //        paragraphMarkRunProperties8.Append(fontSize15);

    //        paragraphProperties8.Append(paragraphStyleId8);
    //        paragraphProperties8.Append(justification7);
    //        paragraphProperties8.Append(paragraphMarkRunProperties8);

    //        var run8 = new Run();

    //        var runProperties8 = new RunProperties();
    //        var runFonts16 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize16 = new FontSize() { Val = "24" };

    //        runProperties8.Append(runFonts16);
    //        runProperties8.Append(fontSize16);
    //        var text8 = new Text();
    //        text8.Text = "Application " + _vblApplication.ApplicationStatus == null ? String.Empty : _vblApplication.ApplicationStatus.Name.ToString(); //Edited

    //        run8.Append(runProperties8);
    //        run8.Append(text8);

    //        paragraph8.Append(paragraphProperties8);
    //        paragraph8.Append(run8);

    //        tableCell7.Append(tableCellProperties7);
    //        tableCell7.Append(paragraph8);

    //        var tableCell8 = new TableCell();

    //        var tableCellProperties8 = new TableCellProperties();
    //        var tableCellWidth8 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading8 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin8 = new TableCellMargin();
    //        var topMargin10 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin10 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin8.Append(topMargin10);
    //        tableCellMargin8.Append(bottomMargin10);

    //        tableCellProperties8.Append(tableCellWidth8);
    //        tableCellProperties8.Append(shading8);
    //        tableCellProperties8.Append(tableCellMargin8);

    //        var paragraph9 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties9 = new ParagraphProperties();
    //        var paragraphStyleId9 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification8 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
    //        var runFonts17 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize17 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties9.Append(runFonts17);
    //        paragraphMarkRunProperties9.Append(fontSize17);

    //        paragraphProperties9.Append(paragraphStyleId9);
    //        paragraphProperties9.Append(justification8);
    //        paragraphProperties9.Append(paragraphMarkRunProperties9);

    //        var run9 = new Run();

    //        var runProperties9 = new RunProperties();
    //        var runFonts18 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize18 = new FontSize() { Val = "24" };

    //        runProperties9.Append(runFonts18);
    //        runProperties9.Append(fontSize18);
    //        var text9 = new Text();
    //        text9.Text = _vblApplication.ApplicationDate.ToString(); // "24/02/2015 08:05:51";

    //        run9.Append(runProperties9);
    //        run9.Append(text9);

    //        paragraph9.Append(paragraphProperties9);
    //        paragraph9.Append(run9);

    //        tableCell8.Append(tableCellProperties8);
    //        tableCell8.Append(paragraph9);

    //        var tableCell9 = new TableCell();

    //        var tableCellProperties9 = new TableCellProperties();
    //        var tableCellWidth9 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading9 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin9 = new TableCellMargin();
    //        var topMargin11 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin11 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin9.Append(topMargin11);
    //        tableCellMargin9.Append(bottomMargin11);

    //        tableCellProperties9.Append(tableCellWidth9);
    //        tableCellProperties9.Append(shading9);
    //        tableCellProperties9.Append(tableCellMargin9);

    //        var paragraph10 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties10 = new ParagraphProperties();
    //        var paragraphStyleId10 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification9 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
    //        var runFonts19 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize19 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties10.Append(runFonts19);
    //        paragraphMarkRunProperties10.Append(fontSize19);

    //        paragraphProperties10.Append(paragraphStyleId10);
    //        paragraphProperties10.Append(justification9);
    //        paragraphProperties10.Append(paragraphMarkRunProperties10);

    //        var run10 = new Run();

    //        var runProperties10 = new RunProperties();
    //        var runFonts20 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize20 = new FontSize() { Val = "24" };

    //        runProperties10.Append(runFonts20);
    //        runProperties10.Append(fontSize20);
    //        var text10 = new Text();
    //        text10.Text = _vblApplication.LevelOfNeeds == null ? string.Empty : _vblApplication.LevelOfNeeds.Name; // "General Need";

    //        run10.Append(runProperties10);
    //        run10.Append(text10);

    //        paragraph10.Append(paragraphProperties10);
    //        paragraph10.Append(run10);

    //        tableCell9.Append(tableCellProperties9);
    //        tableCell9.Append(paragraph10);

    //        var tableCell10 = new TableCell();

    //        var tableCellProperties10 = new TableCellProperties();
    //        var tableCellWidth10 = new TableCellWidth() { Width = "1780", Type = TableWidthUnitValues.Dxa };
    //        var shading10 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin10 = new TableCellMargin();
    //        var topMargin12 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin12 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin10.Append(topMargin12);
    //        tableCellMargin10.Append(bottomMargin12);

    //        tableCellProperties10.Append(tableCellWidth10);
    //        tableCellProperties10.Append(shading10);
    //        tableCellProperties10.Append(tableCellMargin10);

    //        var paragraph11 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties11 = new ParagraphProperties();
    //        var paragraphStyleId11 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification10 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
    //        var runFonts21 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize21 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties11.Append(runFonts21);
    //        paragraphMarkRunProperties11.Append(fontSize21);

    //        paragraphProperties11.Append(paragraphStyleId11);
    //        paragraphProperties11.Append(justification10);
    //        paragraphProperties11.Append(paragraphMarkRunProperties11);

    //        var run11 = new Run();

    //        var runProperties11 = new RunProperties();
    //        var runFonts22 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize22 = new FontSize() { Val = "24" };

    //        runProperties11.Append(runFonts22);
    //        runProperties11.Append(fontSize22);
    //        var text11 = new Text();
    //        text11.Text = "Applicant(s) Eligible";

    //        run11.Append(runProperties11);
    //        run11.Append(text11);

    //        paragraph11.Append(paragraphProperties11);
    //        paragraph11.Append(run11);

    //        tableCell10.Append(tableCellProperties10);
    //        tableCell10.Append(paragraph11);

    //        var tableCell11 = new TableCell();

    //        var tableCellProperties11 = new TableCellProperties();
    //        var tableCellWidth11 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };
    //        var shading11 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin11 = new TableCellMargin();
    //        var topMargin13 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin13 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin11.Append(topMargin13);
    //        tableCellMargin11.Append(bottomMargin13);

    //        tableCellProperties11.Append(tableCellWidth11);
    //        tableCellProperties11.Append(shading11);
    //        tableCellProperties11.Append(tableCellMargin11);

    //        var paragraph12 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties12 = new ParagraphProperties();
    //        var paragraphStyleId12 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification11 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
    //        var runFonts23 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize23 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties12.Append(runFonts23);
    //        paragraphMarkRunProperties12.Append(fontSize23);

    //        paragraphProperties12.Append(paragraphStyleId12);
    //        paragraphProperties12.Append(justification11);
    //        paragraphProperties12.Append(paragraphMarkRunProperties12);

    //        var run12 = new Run();

    //        var runProperties12 = new RunProperties();
    //        var runFonts24 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize24 = new FontSize() { Val = "24" };

    //        runProperties12.Append(runFonts24);
    //        runProperties12.Append(fontSize24);
    //        var text12 = new Text();
    //        text12.Text = "No HOA Case";

    //        run12.Append(runProperties12);
    //        run12.Append(text12);

    //        paragraph12.Append(paragraphProperties12);
    //        paragraph12.Append(run12);

    //        tableCell11.Append(tableCellProperties11);
    //        tableCell11.Append(paragraph12);

    //        var tableCell12 = new TableCell();

    //        var tableCellProperties12 = new TableCellProperties();
    //        var tableCellWidth12 = new TableCellWidth() { Width = "1781", Type = TableWidthUnitValues.Dxa };
    //        var shading12 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        var tableCellMargin12 = new TableCellMargin();
    //        var topMargin14 = new TopMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };
    //        var bottomMargin14 = new BottomMargin() { Width = "40", Type = TableWidthUnitValues.Dxa };

    //        tableCellMargin12.Append(topMargin14);
    //        tableCellMargin12.Append(bottomMargin14);

    //        tableCellProperties12.Append(tableCellWidth12);
    //        tableCellProperties12.Append(shading12);
    //        tableCellProperties12.Append(tableCellMargin12);

    //        var paragraph13 = new Paragraph()
    //        {
    //            RsidParagraphMarkRevision = "00B46F26",
    //            RsidParagraphAddition = "00602ED1",
    //            RsidParagraphProperties = "00BA3FA1",
    //            RsidRunAdditionDefault = "00602ED1"
    //        };

    //        var paragraphProperties13 = new ParagraphProperties();
    //        var paragraphStyleId13 = new ParagraphStyleId() { Val = "NoSpacing" };
    //        var justification12 = new Justification() { Val = JustificationValues.Center };

    //        var paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
    //        var runFonts25 = new RunFonts() { Ascii = "Ariel", HighAnsi = "Ariel" };
    //        var fontSize25 = new FontSize() { Val = "24" };

    //        paragraphMarkRunProperties13.Append(runFonts25);
    //        paragraphMarkRunProperties13.Append(fontSize25);

    //        paragraphProperties13.Append(paragraphStyleId13);
    //        paragraphProperties13.Append(justification12);
    //        paragraphProperties13.Append(paragraphMarkRunProperties13);

    //        paragraph13.Append(paragraphProperties13);

    //        tableCell12.Append(tableCellProperties12);
    //        tableCell12.Append(paragraph13);

    //        tableRow2.Append(tablePropertyExceptions2);
    //        tableRow2.Append(tableCell7);
    //        tableRow2.Append(tableCell8);
    //        tableRow2.Append(tableCell9);
    //        tableRow2.Append(tableCell10);
    //        tableRow2.Append(tableCell11);
    //        tableRow2.Append(tableCell12);
    //        return tableRow2;
    //    }
    //    #endregion
    //    // Generates content of footerPart1.
    //    private void GenerateFooterPart1Content(FooterPart footerPart1)
    //    {
    //        var footer1 = new Footer() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        footer1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        footer1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        footer1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        footer1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        footer1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        footer1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        footer1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        footer1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        footer1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        footer1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        footer1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        footer1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        footer1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        footer1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        footer1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var paragraph148 = new Paragraph() { RsidParagraphAddition = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties147 = new ParagraphProperties();
    //        var paragraphStyleId147 = new ParagraphStyleId() { Val = "Footer" };

    //        paragraphProperties147.Append(paragraphStyleId147);

    //        paragraph148.Append(paragraphProperties147);

    //        footer1.Append(paragraph148);

    //        footerPart1.Footer = footer1;
    //    }

    //    // Generates content of documentSettingsPart1.
    //    private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
    //    {
    //        var settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
    //        settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
    //        var zoom1 = new Zoom() { Percent = "100" };
    //        var defaultTabStop1 = new DefaultTabStop() { Val = 720 };
    //        var characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

    //        var compatibility1 = new Compatibility();
    //        var compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "14" };
    //        var compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
    //        var compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
    //        var compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

    //        compatibility1.Append(compatibilitySetting1);
    //        compatibility1.Append(compatibilitySetting2);
    //        compatibility1.Append(compatibilitySetting3);
    //        compatibility1.Append(compatibilitySetting4);

    //        var rsids1 = new Rsids();
    //        var rsidRoot1 = new RsidRoot() { Val = "00B07FF9" };
    //        var rsid1 = new Rsid() { Val = "00602ED1" };
    //        var rsid2 = new Rsid() { Val = "00B07FF9" };
    //        var rsid3 = new Rsid() { Val = "00D37468" };

    //        rsids1.Append(rsidRoot1);
    //        rsids1.Append(rsid1);
    //        rsids1.Append(rsid2);
    //        rsids1.Append(rsid3);

    //        var mathProperties1 = new M.MathProperties();
    //        var mathFont1 = new M.MathFont() { Val = "Cambria Math" };
    //        var breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
    //        var breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
    //        var smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
    //        var displayDefaults1 = new M.DisplayDefaults();
    //        var leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
    //        var rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
    //        var defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
    //        var wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
    //        var integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
    //        var naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

    //        mathProperties1.Append(mathFont1);
    //        mathProperties1.Append(breakBinary1);
    //        mathProperties1.Append(breakBinarySubtraction1);
    //        mathProperties1.Append(smallFraction1);
    //        mathProperties1.Append(displayDefaults1);
    //        mathProperties1.Append(leftMargin1);
    //        mathProperties1.Append(rightMargin1);
    //        mathProperties1.Append(defaultJustification1);
    //        mathProperties1.Append(wrapIndent1);
    //        mathProperties1.Append(integralLimitLocation1);
    //        mathProperties1.Append(naryLimitLocation1);
    //        var themeFontLanguages1 = new ThemeFontLanguages() { Val = "en-GB" };
    //        var colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

    //        var shapeDefaults1 = new ShapeDefaults();
    //        var shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

    //        var shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
    //        var shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

    //        shapeLayout1.Append(shapeIdMap1);

    //        shapeDefaults1.Append(shapeDefaults2);
    //        shapeDefaults1.Append(shapeLayout1);
    //        var decimalSymbol1 = new DecimalSymbol() { Val = "." };
    //        var listSeparator1 = new ListSeparator() { Val = "," };

    //        settings1.Append(zoom1);
    //        settings1.Append(defaultTabStop1);
    //        settings1.Append(characterSpacingControl1);
    //        settings1.Append(compatibility1);
    //        settings1.Append(rsids1);
    //        settings1.Append(mathProperties1);
    //        settings1.Append(themeFontLanguages1);
    //        settings1.Append(colorSchemeMapping1);
    //        settings1.Append(shapeDefaults1);
    //        settings1.Append(decimalSymbol1);
    //        settings1.Append(listSeparator1);

    //        documentSettingsPart1.Settings = settings1;
    //    }

    //    // Generates content of footerPart2.
    //    private void GenerateFooterPart2Content(FooterPart footerPart2)
    //    {
    //        var footer2 = new Footer() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        footer2.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        footer2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        footer2.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        footer2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        footer2.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        footer2.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        footer2.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        footer2.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        footer2.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        footer2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        footer2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        footer2.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        footer2.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        footer2.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        footer2.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var paragraph149 = new Paragraph() { RsidParagraphAddition = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties148 = new ParagraphProperties();
    //        var paragraphStyleId148 = new ParagraphStyleId() { Val = "Footer" };

    //        paragraphProperties148.Append(paragraphStyleId148);

    //        paragraph149.Append(paragraphProperties148);

    //        footer2.Append(paragraph149);

    //        footerPart2.Footer = footer2;
    //    }

    //    // Generates content of themePart1.
    //    private void GenerateThemePart1Content(ThemePart themePart1)
    //    {
    //        var theme1 = new A.Theme() { Name = "Office Theme" };
    //        theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

    //        var themeElements1 = new A.ThemeElements();

    //        var colorScheme1 = new A.ColorScheme() { Name = "Office" };

    //        var dark1Color1 = new A.Dark1Color();
    //        var systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

    //        dark1Color1.Append(systemColor1);

    //        var light1Color1 = new A.Light1Color();
    //        var systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

    //        light1Color1.Append(systemColor2);

    //        var dark2Color1 = new A.Dark2Color();
    //        var rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

    //        dark2Color1.Append(rgbColorModelHex1);

    //        var light2Color1 = new A.Light2Color();
    //        var rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

    //        light2Color1.Append(rgbColorModelHex2);

    //        var accent1Color1 = new A.Accent1Color();
    //        var rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

    //        accent1Color1.Append(rgbColorModelHex3);

    //        var accent2Color1 = new A.Accent2Color();
    //        var rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

    //        accent2Color1.Append(rgbColorModelHex4);

    //        var accent3Color1 = new A.Accent3Color();
    //        var rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

    //        accent3Color1.Append(rgbColorModelHex5);

    //        var accent4Color1 = new A.Accent4Color();
    //        var rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

    //        accent4Color1.Append(rgbColorModelHex6);

    //        var accent5Color1 = new A.Accent5Color();
    //        var rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

    //        accent5Color1.Append(rgbColorModelHex7);

    //        var accent6Color1 = new A.Accent6Color();
    //        var rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

    //        accent6Color1.Append(rgbColorModelHex8);

    //        var hyperlink1 = new A.Hyperlink();
    //        var rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

    //        hyperlink1.Append(rgbColorModelHex9);

    //        var followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
    //        var rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

    //        followedHyperlinkColor1.Append(rgbColorModelHex10);

    //        colorScheme1.Append(dark1Color1);
    //        colorScheme1.Append(light1Color1);
    //        colorScheme1.Append(dark2Color1);
    //        colorScheme1.Append(light2Color1);
    //        colorScheme1.Append(accent1Color1);
    //        colorScheme1.Append(accent2Color1);
    //        colorScheme1.Append(accent3Color1);
    //        colorScheme1.Append(accent4Color1);
    //        colorScheme1.Append(accent5Color1);
    //        colorScheme1.Append(accent6Color1);
    //        colorScheme1.Append(hyperlink1);
    //        colorScheme1.Append(followedHyperlinkColor1);

    //        var fontScheme1 = new A.FontScheme() { Name = "Office" };

    //        var majorFont1 = new A.MajorFont();
    //        var latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
    //        var eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
    //        var complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
    //        var supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ ゴシック" };
    //        var supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
    //        var supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
    //        var supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
    //        var supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
    //        var supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
    //        var supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
    //        var supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
    //        var supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
    //        var supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
    //        var supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
    //        var supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
    //        var supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
    //        var supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
    //        var supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
    //        var supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
    //        var supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
    //        var supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
    //        var supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
    //        var supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
    //        var supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
    //        var supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
    //        var supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
    //        var supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
    //        var supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
    //        var supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
    //        var supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
    //        var supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
    //        var supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
    //        var supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

    //        majorFont1.Append(latinFont1);
    //        majorFont1.Append(eastAsianFont1);
    //        majorFont1.Append(complexScriptFont1);
    //        majorFont1.Append(supplementalFont1);
    //        majorFont1.Append(supplementalFont2);
    //        majorFont1.Append(supplementalFont3);
    //        majorFont1.Append(supplementalFont4);
    //        majorFont1.Append(supplementalFont5);
    //        majorFont1.Append(supplementalFont6);
    //        majorFont1.Append(supplementalFont7);
    //        majorFont1.Append(supplementalFont8);
    //        majorFont1.Append(supplementalFont9);
    //        majorFont1.Append(supplementalFont10);
    //        majorFont1.Append(supplementalFont11);
    //        majorFont1.Append(supplementalFont12);
    //        majorFont1.Append(supplementalFont13);
    //        majorFont1.Append(supplementalFont14);
    //        majorFont1.Append(supplementalFont15);
    //        majorFont1.Append(supplementalFont16);
    //        majorFont1.Append(supplementalFont17);
    //        majorFont1.Append(supplementalFont18);
    //        majorFont1.Append(supplementalFont19);
    //        majorFont1.Append(supplementalFont20);
    //        majorFont1.Append(supplementalFont21);
    //        majorFont1.Append(supplementalFont22);
    //        majorFont1.Append(supplementalFont23);
    //        majorFont1.Append(supplementalFont24);
    //        majorFont1.Append(supplementalFont25);
    //        majorFont1.Append(supplementalFont26);
    //        majorFont1.Append(supplementalFont27);
    //        majorFont1.Append(supplementalFont28);
    //        majorFont1.Append(supplementalFont29);
    //        majorFont1.Append(supplementalFont30);

    //        var minorFont1 = new A.MinorFont();
    //        var latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
    //        var eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
    //        var complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
    //        var supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ 明朝" };
    //        var supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
    //        var supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
    //        var supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
    //        var supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
    //        var supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
    //        var supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
    //        var supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
    //        var supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
    //        var supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
    //        var supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
    //        var supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
    //        var supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
    //        var supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
    //        var supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
    //        var supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
    //        var supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
    //        var supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
    //        var supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
    //        var supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
    //        var supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
    //        var supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
    //        var supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
    //        var supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
    //        var supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
    //        var supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
    //        var supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
    //        var supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
    //        var supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
    //        var supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

    //        minorFont1.Append(latinFont2);
    //        minorFont1.Append(eastAsianFont2);
    //        minorFont1.Append(complexScriptFont2);
    //        minorFont1.Append(supplementalFont31);
    //        minorFont1.Append(supplementalFont32);
    //        minorFont1.Append(supplementalFont33);
    //        minorFont1.Append(supplementalFont34);
    //        minorFont1.Append(supplementalFont35);
    //        minorFont1.Append(supplementalFont36);
    //        minorFont1.Append(supplementalFont37);
    //        minorFont1.Append(supplementalFont38);
    //        minorFont1.Append(supplementalFont39);
    //        minorFont1.Append(supplementalFont40);
    //        minorFont1.Append(supplementalFont41);
    //        minorFont1.Append(supplementalFont42);
    //        minorFont1.Append(supplementalFont43);
    //        minorFont1.Append(supplementalFont44);
    //        minorFont1.Append(supplementalFont45);
    //        minorFont1.Append(supplementalFont46);
    //        minorFont1.Append(supplementalFont47);
    //        minorFont1.Append(supplementalFont48);
    //        minorFont1.Append(supplementalFont49);
    //        minorFont1.Append(supplementalFont50);
    //        minorFont1.Append(supplementalFont51);
    //        minorFont1.Append(supplementalFont52);
    //        minorFont1.Append(supplementalFont53);
    //        minorFont1.Append(supplementalFont54);
    //        minorFont1.Append(supplementalFont55);
    //        minorFont1.Append(supplementalFont56);
    //        minorFont1.Append(supplementalFont57);
    //        minorFont1.Append(supplementalFont58);
    //        minorFont1.Append(supplementalFont59);
    //        minorFont1.Append(supplementalFont60);

    //        fontScheme1.Append(majorFont1);
    //        fontScheme1.Append(minorFont1);

    //        var formatScheme1 = new A.FormatScheme() { Name = "Office" };

    //        var fillStyleList1 = new A.FillStyleList();

    //        var solidFill1 = new A.SolidFill();
    //        var schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

    //        solidFill1.Append(schemeColor1);

    //        var gradientFill1 = new A.GradientFill() { RotateWithShape = true };

    //        var gradientStopList1 = new A.GradientStopList();

    //        var gradientStop1 = new A.GradientStop() { Position = 0 };

    //        var schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint1 = new A.Tint() { Val = 50000 };
    //        var saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

    //        schemeColor2.Append(tint1);
    //        schemeColor2.Append(saturationModulation1);

    //        gradientStop1.Append(schemeColor2);

    //        var gradientStop2 = new A.GradientStop() { Position = 35000 };

    //        var schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint2 = new A.Tint() { Val = 37000 };
    //        var saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

    //        schemeColor3.Append(tint2);
    //        schemeColor3.Append(saturationModulation2);

    //        gradientStop2.Append(schemeColor3);

    //        var gradientStop3 = new A.GradientStop() { Position = 100000 };

    //        var schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint3 = new A.Tint() { Val = 15000 };
    //        var saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

    //        schemeColor4.Append(tint3);
    //        schemeColor4.Append(saturationModulation3);

    //        gradientStop3.Append(schemeColor4);

    //        gradientStopList1.Append(gradientStop1);
    //        gradientStopList1.Append(gradientStop2);
    //        gradientStopList1.Append(gradientStop3);
    //        var linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

    //        gradientFill1.Append(gradientStopList1);
    //        gradientFill1.Append(linearGradientFill1);

    //        var gradientFill2 = new A.GradientFill() { RotateWithShape = true };

    //        var gradientStopList2 = new A.GradientStopList();

    //        var gradientStop4 = new A.GradientStop() { Position = 0 };

    //        var schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade1 = new A.Shade() { Val = 51000 };
    //        var saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

    //        schemeColor5.Append(shade1);
    //        schemeColor5.Append(saturationModulation4);

    //        gradientStop4.Append(schemeColor5);

    //        var gradientStop5 = new A.GradientStop() { Position = 80000 };

    //        var schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade2 = new A.Shade() { Val = 93000 };
    //        var saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

    //        schemeColor6.Append(shade2);
    //        schemeColor6.Append(saturationModulation5);

    //        gradientStop5.Append(schemeColor6);

    //        var gradientStop6 = new A.GradientStop() { Position = 100000 };

    //        var schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade3 = new A.Shade() { Val = 94000 };
    //        var saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

    //        schemeColor7.Append(shade3);
    //        schemeColor7.Append(saturationModulation6);

    //        gradientStop6.Append(schemeColor7);

    //        gradientStopList2.Append(gradientStop4);
    //        gradientStopList2.Append(gradientStop5);
    //        gradientStopList2.Append(gradientStop6);
    //        var linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

    //        gradientFill2.Append(gradientStopList2);
    //        gradientFill2.Append(linearGradientFill2);

    //        fillStyleList1.Append(solidFill1);
    //        fillStyleList1.Append(gradientFill1);
    //        fillStyleList1.Append(gradientFill2);

    //        var lineStyleList1 = new A.LineStyleList();

    //        var outline1 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

    //        var solidFill2 = new A.SolidFill();

    //        var schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade4 = new A.Shade() { Val = 95000 };
    //        var saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

    //        schemeColor8.Append(shade4);
    //        schemeColor8.Append(saturationModulation7);

    //        solidFill2.Append(schemeColor8);
    //        var presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

    //        outline1.Append(solidFill2);
    //        outline1.Append(presetDash1);

    //        var outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

    //        var solidFill3 = new A.SolidFill();
    //        var schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

    //        solidFill3.Append(schemeColor9);
    //        var presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

    //        outline2.Append(solidFill3);
    //        outline2.Append(presetDash2);

    //        var outline3 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

    //        var solidFill4 = new A.SolidFill();
    //        var schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

    //        solidFill4.Append(schemeColor10);
    //        var presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

    //        outline3.Append(solidFill4);
    //        outline3.Append(presetDash3);

    //        lineStyleList1.Append(outline1);
    //        lineStyleList1.Append(outline2);
    //        lineStyleList1.Append(outline3);

    //        var effectStyleList1 = new A.EffectStyleList();

    //        var effectStyle1 = new A.EffectStyle();

    //        var effectList1 = new A.EffectList();

    //        var outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

    //        var rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
    //        var alpha1 = new A.Alpha() { Val = 38000 };

    //        rgbColorModelHex11.Append(alpha1);

    //        outerShadow1.Append(rgbColorModelHex11);

    //        effectList1.Append(outerShadow1);

    //        effectStyle1.Append(effectList1);

    //        var effectStyle2 = new A.EffectStyle();

    //        var effectList2 = new A.EffectList();

    //        var outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

    //        var rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
    //        var alpha2 = new A.Alpha() { Val = 35000 };

    //        rgbColorModelHex12.Append(alpha2);

    //        outerShadow2.Append(rgbColorModelHex12);

    //        effectList2.Append(outerShadow2);

    //        effectStyle2.Append(effectList2);

    //        var effectStyle3 = new A.EffectStyle();

    //        var effectList3 = new A.EffectList();

    //        var outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

    //        var rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
    //        var alpha3 = new A.Alpha() { Val = 35000 };

    //        rgbColorModelHex13.Append(alpha3);

    //        outerShadow3.Append(rgbColorModelHex13);

    //        effectList3.Append(outerShadow3);

    //        var scene3DType1 = new A.Scene3DType();

    //        var camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
    //        var rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

    //        camera1.Append(rotation1);

    //        var lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
    //        var rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

    //        lightRig1.Append(rotation2);

    //        scene3DType1.Append(camera1);
    //        scene3DType1.Append(lightRig1);

    //        var shape3DType1 = new A.Shape3DType();
    //        var bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

    //        shape3DType1.Append(bevelTop1);

    //        effectStyle3.Append(effectList3);
    //        effectStyle3.Append(scene3DType1);
    //        effectStyle3.Append(shape3DType1);

    //        effectStyleList1.Append(effectStyle1);
    //        effectStyleList1.Append(effectStyle2);
    //        effectStyleList1.Append(effectStyle3);

    //        var backgroundFillStyleList1 = new A.BackgroundFillStyleList();

    //        var solidFill5 = new A.SolidFill();
    //        var schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

    //        solidFill5.Append(schemeColor11);

    //        var gradientFill3 = new A.GradientFill() { RotateWithShape = true };

    //        var gradientStopList3 = new A.GradientStopList();

    //        var gradientStop7 = new A.GradientStop() { Position = 0 };

    //        var schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint4 = new A.Tint() { Val = 40000 };
    //        var saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

    //        schemeColor12.Append(tint4);
    //        schemeColor12.Append(saturationModulation8);

    //        gradientStop7.Append(schemeColor12);

    //        var gradientStop8 = new A.GradientStop() { Position = 40000 };

    //        var schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint5 = new A.Tint() { Val = 45000 };
    //        var shade5 = new A.Shade() { Val = 99000 };
    //        var saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

    //        schemeColor13.Append(tint5);
    //        schemeColor13.Append(shade5);
    //        schemeColor13.Append(saturationModulation9);

    //        gradientStop8.Append(schemeColor13);

    //        var gradientStop9 = new A.GradientStop() { Position = 100000 };

    //        var schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade6 = new A.Shade() { Val = 20000 };
    //        var saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

    //        schemeColor14.Append(shade6);
    //        schemeColor14.Append(saturationModulation10);

    //        gradientStop9.Append(schemeColor14);

    //        gradientStopList3.Append(gradientStop7);
    //        gradientStopList3.Append(gradientStop8);
    //        gradientStopList3.Append(gradientStop9);

    //        var pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
    //        var fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

    //        pathGradientFill1.Append(fillToRectangle1);

    //        gradientFill3.Append(gradientStopList3);
    //        gradientFill3.Append(pathGradientFill1);

    //        var gradientFill4 = new A.GradientFill() { RotateWithShape = true };

    //        var gradientStopList4 = new A.GradientStopList();

    //        var gradientStop10 = new A.GradientStop() { Position = 0 };

    //        var schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var tint6 = new A.Tint() { Val = 80000 };
    //        var saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

    //        schemeColor15.Append(tint6);
    //        schemeColor15.Append(saturationModulation11);

    //        gradientStop10.Append(schemeColor15);

    //        var gradientStop11 = new A.GradientStop() { Position = 100000 };

    //        var schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
    //        var shade7 = new A.Shade() { Val = 30000 };
    //        var saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

    //        schemeColor16.Append(shade7);
    //        schemeColor16.Append(saturationModulation12);

    //        gradientStop11.Append(schemeColor16);

    //        gradientStopList4.Append(gradientStop10);
    //        gradientStopList4.Append(gradientStop11);

    //        var pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
    //        var fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

    //        pathGradientFill2.Append(fillToRectangle2);

    //        gradientFill4.Append(gradientStopList4);
    //        gradientFill4.Append(pathGradientFill2);

    //        backgroundFillStyleList1.Append(solidFill5);
    //        backgroundFillStyleList1.Append(gradientFill3);
    //        backgroundFillStyleList1.Append(gradientFill4);

    //        formatScheme1.Append(fillStyleList1);
    //        formatScheme1.Append(lineStyleList1);
    //        formatScheme1.Append(effectStyleList1);
    //        formatScheme1.Append(backgroundFillStyleList1);

    //        themeElements1.Append(colorScheme1);
    //        themeElements1.Append(fontScheme1);
    //        themeElements1.Append(formatScheme1);
    //        var objectDefaults1 = new A.ObjectDefaults();
    //        var extraColorSchemeList1 = new A.ExtraColorSchemeList();

    //        theme1.Append(themeElements1);
    //        theme1.Append(objectDefaults1);
    //        theme1.Append(extraColorSchemeList1);

    //        themePart1.Theme = theme1;
    //    }

    //    // Generates content of stylesWithEffectsPart1.
    //    private void GenerateStylesWithEffectsPart1Content(StylesWithEffectsPart stylesWithEffectsPart1)
    //    {
    //        var styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        styles1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        styles1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        styles1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        styles1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        styles1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        styles1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        styles1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        styles1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        styles1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        styles1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        styles1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var docDefaults1 = new DocDefaults();

    //        var runPropertiesDefault1 = new RunPropertiesDefault();

    //        var runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
    //        var runFonts268 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
    //        var fontSize270 = new FontSize() { Val = "22" };
    //        var fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "22" };
    //        var languages1 = new Languages() { Val = "en-GB", EastAsia = "en-US", Bidi = "ar-SA" };

    //        runPropertiesBaseStyle1.Append(runFonts268);
    //        runPropertiesBaseStyle1.Append(fontSize270);
    //        runPropertiesBaseStyle1.Append(fontSizeComplexScript1);
    //        runPropertiesBaseStyle1.Append(languages1);

    //        runPropertiesDefault1.Append(runPropertiesBaseStyle1);

    //        var paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

    //        var paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
    //        var spacingBetweenLines1 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

    //        paragraphPropertiesBaseStyle1.Append(spacingBetweenLines1);

    //        paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

    //        docDefaults1.Append(runPropertiesDefault1);
    //        docDefaults1.Append(paragraphPropertiesDefault1);

    //        var latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
    //        var latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
    //        var latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
    //        var latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
    //        var latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
    //        var latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
    //        var latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
    //        var latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
    //        var latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
    //        var latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
    //        var latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
    //        var latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
    //        var latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
    //        var latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

    //        latentStyles1.Append(latentStyleExceptionInfo1);
    //        latentStyles1.Append(latentStyleExceptionInfo2);
    //        latentStyles1.Append(latentStyleExceptionInfo3);
    //        latentStyles1.Append(latentStyleExceptionInfo4);
    //        latentStyles1.Append(latentStyleExceptionInfo5);
    //        latentStyles1.Append(latentStyleExceptionInfo6);
    //        latentStyles1.Append(latentStyleExceptionInfo7);
    //        latentStyles1.Append(latentStyleExceptionInfo8);
    //        latentStyles1.Append(latentStyleExceptionInfo9);
    //        latentStyles1.Append(latentStyleExceptionInfo10);
    //        latentStyles1.Append(latentStyleExceptionInfo11);
    //        latentStyles1.Append(latentStyleExceptionInfo12);
    //        latentStyles1.Append(latentStyleExceptionInfo13);
    //        latentStyles1.Append(latentStyleExceptionInfo14);
    //        latentStyles1.Append(latentStyleExceptionInfo15);
    //        latentStyles1.Append(latentStyleExceptionInfo16);
    //        latentStyles1.Append(latentStyleExceptionInfo17);
    //        latentStyles1.Append(latentStyleExceptionInfo18);
    //        latentStyles1.Append(latentStyleExceptionInfo19);
    //        latentStyles1.Append(latentStyleExceptionInfo20);
    //        latentStyles1.Append(latentStyleExceptionInfo21);
    //        latentStyles1.Append(latentStyleExceptionInfo22);
    //        latentStyles1.Append(latentStyleExceptionInfo23);
    //        latentStyles1.Append(latentStyleExceptionInfo24);
    //        latentStyles1.Append(latentStyleExceptionInfo25);
    //        latentStyles1.Append(latentStyleExceptionInfo26);
    //        latentStyles1.Append(latentStyleExceptionInfo27);
    //        latentStyles1.Append(latentStyleExceptionInfo28);
    //        latentStyles1.Append(latentStyleExceptionInfo29);
    //        latentStyles1.Append(latentStyleExceptionInfo30);
    //        latentStyles1.Append(latentStyleExceptionInfo31);
    //        latentStyles1.Append(latentStyleExceptionInfo32);
    //        latentStyles1.Append(latentStyleExceptionInfo33);
    //        latentStyles1.Append(latentStyleExceptionInfo34);
    //        latentStyles1.Append(latentStyleExceptionInfo35);
    //        latentStyles1.Append(latentStyleExceptionInfo36);
    //        latentStyles1.Append(latentStyleExceptionInfo37);
    //        latentStyles1.Append(latentStyleExceptionInfo38);
    //        latentStyles1.Append(latentStyleExceptionInfo39);
    //        latentStyles1.Append(latentStyleExceptionInfo40);
    //        latentStyles1.Append(latentStyleExceptionInfo41);
    //        latentStyles1.Append(latentStyleExceptionInfo42);
    //        latentStyles1.Append(latentStyleExceptionInfo43);
    //        latentStyles1.Append(latentStyleExceptionInfo44);
    //        latentStyles1.Append(latentStyleExceptionInfo45);
    //        latentStyles1.Append(latentStyleExceptionInfo46);
    //        latentStyles1.Append(latentStyleExceptionInfo47);
    //        latentStyles1.Append(latentStyleExceptionInfo48);
    //        latentStyles1.Append(latentStyleExceptionInfo49);
    //        latentStyles1.Append(latentStyleExceptionInfo50);
    //        latentStyles1.Append(latentStyleExceptionInfo51);
    //        latentStyles1.Append(latentStyleExceptionInfo52);
    //        latentStyles1.Append(latentStyleExceptionInfo53);
    //        latentStyles1.Append(latentStyleExceptionInfo54);
    //        latentStyles1.Append(latentStyleExceptionInfo55);
    //        latentStyles1.Append(latentStyleExceptionInfo56);
    //        latentStyles1.Append(latentStyleExceptionInfo57);
    //        latentStyles1.Append(latentStyleExceptionInfo58);
    //        latentStyles1.Append(latentStyleExceptionInfo59);
    //        latentStyles1.Append(latentStyleExceptionInfo60);
    //        latentStyles1.Append(latentStyleExceptionInfo61);
    //        latentStyles1.Append(latentStyleExceptionInfo62);
    //        latentStyles1.Append(latentStyleExceptionInfo63);
    //        latentStyles1.Append(latentStyleExceptionInfo64);
    //        latentStyles1.Append(latentStyleExceptionInfo65);
    //        latentStyles1.Append(latentStyleExceptionInfo66);
    //        latentStyles1.Append(latentStyleExceptionInfo67);
    //        latentStyles1.Append(latentStyleExceptionInfo68);
    //        latentStyles1.Append(latentStyleExceptionInfo69);
    //        latentStyles1.Append(latentStyleExceptionInfo70);
    //        latentStyles1.Append(latentStyleExceptionInfo71);
    //        latentStyles1.Append(latentStyleExceptionInfo72);
    //        latentStyles1.Append(latentStyleExceptionInfo73);
    //        latentStyles1.Append(latentStyleExceptionInfo74);
    //        latentStyles1.Append(latentStyleExceptionInfo75);
    //        latentStyles1.Append(latentStyleExceptionInfo76);
    //        latentStyles1.Append(latentStyleExceptionInfo77);
    //        latentStyles1.Append(latentStyleExceptionInfo78);
    //        latentStyles1.Append(latentStyleExceptionInfo79);
    //        latentStyles1.Append(latentStyleExceptionInfo80);
    //        latentStyles1.Append(latentStyleExceptionInfo81);
    //        latentStyles1.Append(latentStyleExceptionInfo82);
    //        latentStyles1.Append(latentStyleExceptionInfo83);
    //        latentStyles1.Append(latentStyleExceptionInfo84);
    //        latentStyles1.Append(latentStyleExceptionInfo85);
    //        latentStyles1.Append(latentStyleExceptionInfo86);
    //        latentStyles1.Append(latentStyleExceptionInfo87);
    //        latentStyles1.Append(latentStyleExceptionInfo88);
    //        latentStyles1.Append(latentStyleExceptionInfo89);
    //        latentStyles1.Append(latentStyleExceptionInfo90);
    //        latentStyles1.Append(latentStyleExceptionInfo91);
    //        latentStyles1.Append(latentStyleExceptionInfo92);
    //        latentStyles1.Append(latentStyleExceptionInfo93);
    //        latentStyles1.Append(latentStyleExceptionInfo94);
    //        latentStyles1.Append(latentStyleExceptionInfo95);
    //        latentStyles1.Append(latentStyleExceptionInfo96);
    //        latentStyles1.Append(latentStyleExceptionInfo97);
    //        latentStyles1.Append(latentStyleExceptionInfo98);
    //        latentStyles1.Append(latentStyleExceptionInfo99);
    //        latentStyles1.Append(latentStyleExceptionInfo100);
    //        latentStyles1.Append(latentStyleExceptionInfo101);
    //        latentStyles1.Append(latentStyleExceptionInfo102);
    //        latentStyles1.Append(latentStyleExceptionInfo103);
    //        latentStyles1.Append(latentStyleExceptionInfo104);
    //        latentStyles1.Append(latentStyleExceptionInfo105);
    //        latentStyles1.Append(latentStyleExceptionInfo106);
    //        latentStyles1.Append(latentStyleExceptionInfo107);
    //        latentStyles1.Append(latentStyleExceptionInfo108);
    //        latentStyles1.Append(latentStyleExceptionInfo109);
    //        latentStyles1.Append(latentStyleExceptionInfo110);
    //        latentStyles1.Append(latentStyleExceptionInfo111);
    //        latentStyles1.Append(latentStyleExceptionInfo112);
    //        latentStyles1.Append(latentStyleExceptionInfo113);
    //        latentStyles1.Append(latentStyleExceptionInfo114);
    //        latentStyles1.Append(latentStyleExceptionInfo115);
    //        latentStyles1.Append(latentStyleExceptionInfo116);
    //        latentStyles1.Append(latentStyleExceptionInfo117);
    //        latentStyles1.Append(latentStyleExceptionInfo118);
    //        latentStyles1.Append(latentStyleExceptionInfo119);
    //        latentStyles1.Append(latentStyleExceptionInfo120);
    //        latentStyles1.Append(latentStyleExceptionInfo121);
    //        latentStyles1.Append(latentStyleExceptionInfo122);
    //        latentStyles1.Append(latentStyleExceptionInfo123);
    //        latentStyles1.Append(latentStyleExceptionInfo124);
    //        latentStyles1.Append(latentStyleExceptionInfo125);
    //        latentStyles1.Append(latentStyleExceptionInfo126);
    //        latentStyles1.Append(latentStyleExceptionInfo127);
    //        latentStyles1.Append(latentStyleExceptionInfo128);
    //        latentStyles1.Append(latentStyleExceptionInfo129);
    //        latentStyles1.Append(latentStyleExceptionInfo130);
    //        latentStyles1.Append(latentStyleExceptionInfo131);
    //        latentStyles1.Append(latentStyleExceptionInfo132);
    //        latentStyles1.Append(latentStyleExceptionInfo133);
    //        latentStyles1.Append(latentStyleExceptionInfo134);
    //        latentStyles1.Append(latentStyleExceptionInfo135);
    //        latentStyles1.Append(latentStyleExceptionInfo136);
    //        latentStyles1.Append(latentStyleExceptionInfo137);

    //        var style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normal", Default = true };
    //        var styleName1 = new StyleName() { Val = "Normal" };
    //        var primaryStyle1 = new PrimaryStyle();
    //        var rsid4 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties1 = new StyleRunProperties();
    //        var runFonts269 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties1.Append(runFonts269);

    //        style1.Append(styleName1);
    //        style1.Append(primaryStyle1);
    //        style1.Append(rsid4);
    //        style1.Append(styleRunProperties1);

    //        var style2 = new Style() { Type = StyleValues.Paragraph, StyleId = "Heading1" };
    //        var styleName2 = new StyleName() { Val = "heading 1" };
    //        var basedOn1 = new BasedOn() { Val = "Normal" };
    //        var nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
    //        var linkedStyle1 = new LinkedStyle() { Val = "Heading1Char" };
    //        var uIPriority1 = new UIPriority() { Val = 9 };
    //        var primaryStyle2 = new PrimaryStyle();
    //        var rsid5 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties1 = new StyleParagraphProperties();
    //        var keepNext1 = new KeepNext();
    //        var spacingBetweenLines2 = new SpacingBetweenLines() { Before = "240", After = "60" };
    //        var outlineLevel1 = new OutlineLevel() { Val = 0 };

    //        styleParagraphProperties1.Append(keepNext1);
    //        styleParagraphProperties1.Append(spacingBetweenLines2);
    //        styleParagraphProperties1.Append(outlineLevel1);

    //        var styleRunProperties2 = new StyleRunProperties();
    //        var runFonts270 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman" };
    //        var bold66 = new Bold();
    //        var boldComplexScript1 = new BoldComplexScript();
    //        var kern1 = new Kern() { Val = (UInt32Value)32U };
    //        var fontSize271 = new FontSize() { Val = "32" };
    //        var fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "32" };

    //        styleRunProperties2.Append(runFonts270);
    //        styleRunProperties2.Append(bold66);
    //        styleRunProperties2.Append(boldComplexScript1);
    //        styleRunProperties2.Append(kern1);
    //        styleRunProperties2.Append(fontSize271);
    //        styleRunProperties2.Append(fontSizeComplexScript2);

    //        style2.Append(styleName2);
    //        style2.Append(basedOn1);
    //        style2.Append(nextParagraphStyle1);
    //        style2.Append(linkedStyle1);
    //        style2.Append(uIPriority1);
    //        style2.Append(primaryStyle2);
    //        style2.Append(rsid5);
    //        style2.Append(styleParagraphProperties1);
    //        style2.Append(styleRunProperties2);

    //        var style3 = new Style() { Type = StyleValues.Character, StyleId = "DefaultParagraphFont", Default = true };
    //        var styleName3 = new StyleName() { Val = "Default Paragraph Font" };
    //        var uIPriority2 = new UIPriority() { Val = 1 };
    //        var semiHidden1 = new SemiHidden();
    //        var unhideWhenUsed1 = new UnhideWhenUsed();

    //        style3.Append(styleName3);
    //        style3.Append(uIPriority2);
    //        style3.Append(semiHidden1);
    //        style3.Append(unhideWhenUsed1);

    //        var style4 = new Style() { Type = StyleValues.Table, StyleId = "TableNormal", Default = true };
    //        var styleName4 = new StyleName() { Val = "Normal Table" };
    //        var uIPriority3 = new UIPriority() { Val = 99 };
    //        var semiHidden2 = new SemiHidden();
    //        var unhideWhenUsed2 = new UnhideWhenUsed();

    //        var styleTableProperties1 = new StyleTableProperties();
    //        var tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

    //        var tableCellMarginDefault30 = new TableCellMarginDefault();
    //        var topMargin131 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
    //        var bottomMargin131 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

    //        tableCellMarginDefault30.Append(topMargin131);
    //        tableCellMarginDefault30.Append(tableCellLeftMargin1);
    //        tableCellMarginDefault30.Append(bottomMargin131);
    //        tableCellMarginDefault30.Append(tableCellRightMargin1);

    //        styleTableProperties1.Append(tableIndentation1);
    //        styleTableProperties1.Append(tableCellMarginDefault30);

    //        style4.Append(styleName4);
    //        style4.Append(uIPriority3);
    //        style4.Append(semiHidden2);
    //        style4.Append(unhideWhenUsed2);
    //        style4.Append(styleTableProperties1);

    //        var style5 = new Style() { Type = StyleValues.Numbering, StyleId = "NoList", Default = true };
    //        var styleName5 = new StyleName() { Val = "No List" };
    //        var uIPriority4 = new UIPriority() { Val = 99 };
    //        var semiHidden3 = new SemiHidden();
    //        var unhideWhenUsed3 = new UnhideWhenUsed();

    //        style5.Append(styleName5);
    //        style5.Append(uIPriority4);
    //        style5.Append(semiHidden3);
    //        style5.Append(unhideWhenUsed3);

    //        var style6 = new Style() { Type = StyleValues.Character, StyleId = "Heading1Char", CustomStyle = true };
    //        var styleName6 = new StyleName() { Val = "Heading 1 Char" };
    //        var basedOn2 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle2 = new LinkedStyle() { Val = "Heading1" };
    //        var uIPriority5 = new UIPriority() { Val = 9 };
    //        var rsid6 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties3 = new StyleRunProperties();
    //        var runFonts271 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
    //        var bold67 = new Bold();
    //        var boldComplexScript2 = new BoldComplexScript();
    //        var kern2 = new Kern() { Val = (UInt32Value)32U };
    //        var fontSize272 = new FontSize() { Val = "32" };
    //        var fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "32" };

    //        styleRunProperties3.Append(runFonts271);
    //        styleRunProperties3.Append(bold67);
    //        styleRunProperties3.Append(boldComplexScript2);
    //        styleRunProperties3.Append(kern2);
    //        styleRunProperties3.Append(fontSize272);
    //        styleRunProperties3.Append(fontSizeComplexScript3);

    //        style6.Append(styleName6);
    //        style6.Append(basedOn2);
    //        style6.Append(linkedStyle2);
    //        style6.Append(uIPriority5);
    //        style6.Append(rsid6);
    //        style6.Append(styleRunProperties3);

    //        var style7 = new Style() { Type = StyleValues.Paragraph, StyleId = "NoSpacing" };
    //        var styleName7 = new StyleName() { Val = "No Spacing" };
    //        var uIPriority6 = new UIPriority() { Val = 1 };
    //        var primaryStyle3 = new PrimaryStyle();
    //        var rsid7 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties2 = new StyleParagraphProperties();
    //        var spacingBetweenLines3 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

    //        styleParagraphProperties2.Append(spacingBetweenLines3);

    //        var styleRunProperties4 = new StyleRunProperties();
    //        var runFonts272 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties4.Append(runFonts272);

    //        style7.Append(styleName7);
    //        style7.Append(uIPriority6);
    //        style7.Append(primaryStyle3);
    //        style7.Append(rsid7);
    //        style7.Append(styleParagraphProperties2);
    //        style7.Append(styleRunProperties4);

    //        var style8 = new Style() { Type = StyleValues.Paragraph, StyleId = "Header" };
    //        var styleName8 = new StyleName() { Val = "header" };
    //        var basedOn3 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle3 = new LinkedStyle() { Val = "HeaderChar" };
    //        var uIPriority7 = new UIPriority() { Val = 99 };
    //        var unhideWhenUsed4 = new UnhideWhenUsed();
    //        var rsid8 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties3 = new StyleParagraphProperties();

    //        var tabs1 = new Tabs();
    //        var tabStop1 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
    //        var tabStop2 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

    //        tabs1.Append(tabStop1);
    //        tabs1.Append(tabStop2);

    //        styleParagraphProperties3.Append(tabs1);

    //        style8.Append(styleName8);
    //        style8.Append(basedOn3);
    //        style8.Append(linkedStyle3);
    //        style8.Append(uIPriority7);
    //        style8.Append(unhideWhenUsed4);
    //        style8.Append(rsid8);
    //        style8.Append(styleParagraphProperties3);

    //        var style9 = new Style() { Type = StyleValues.Character, StyleId = "HeaderChar", CustomStyle = true };
    //        var styleName9 = new StyleName() { Val = "Header Char" };
    //        var basedOn4 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle4 = new LinkedStyle() { Val = "Header" };
    //        var uIPriority8 = new UIPriority() { Val = 99 };
    //        var rsid9 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties5 = new StyleRunProperties();
    //        var runFonts273 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties5.Append(runFonts273);

    //        style9.Append(styleName9);
    //        style9.Append(basedOn4);
    //        style9.Append(linkedStyle4);
    //        style9.Append(uIPriority8);
    //        style9.Append(rsid9);
    //        style9.Append(styleRunProperties5);

    //        var style10 = new Style() { Type = StyleValues.Paragraph, StyleId = "Footer" };
    //        var styleName10 = new StyleName() { Val = "footer" };
    //        var basedOn5 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle5 = new LinkedStyle() { Val = "FooterChar" };
    //        var uIPriority9 = new UIPriority() { Val = 99 };
    //        var unhideWhenUsed5 = new UnhideWhenUsed();
    //        var rsid10 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties4 = new StyleParagraphProperties();

    //        var tabs2 = new Tabs();
    //        var tabStop3 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
    //        var tabStop4 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

    //        tabs2.Append(tabStop3);
    //        tabs2.Append(tabStop4);

    //        styleParagraphProperties4.Append(tabs2);

    //        style10.Append(styleName10);
    //        style10.Append(basedOn5);
    //        style10.Append(linkedStyle5);
    //        style10.Append(uIPriority9);
    //        style10.Append(unhideWhenUsed5);
    //        style10.Append(rsid10);
    //        style10.Append(styleParagraphProperties4);

    //        var style11 = new Style() { Type = StyleValues.Character, StyleId = "FooterChar", CustomStyle = true };
    //        var styleName11 = new StyleName() { Val = "Footer Char" };
    //        var basedOn6 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle6 = new LinkedStyle() { Val = "Footer" };
    //        var uIPriority10 = new UIPriority() { Val = 99 };
    //        var rsid11 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties6 = new StyleRunProperties();
    //        var runFonts274 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties6.Append(runFonts274);

    //        style11.Append(styleName11);
    //        style11.Append(basedOn6);
    //        style11.Append(linkedStyle6);
    //        style11.Append(uIPriority10);
    //        style11.Append(rsid11);
    //        style11.Append(styleRunProperties6);

    //        var style12 = new Style() { Type = StyleValues.Paragraph, StyleId = "BalloonText" };
    //        var styleName12 = new StyleName() { Val = "Balloon Text" };
    //        var basedOn7 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle7 = new LinkedStyle() { Val = "BalloonTextChar" };
    //        var uIPriority11 = new UIPriority() { Val = 99 };
    //        var semiHidden4 = new SemiHidden();
    //        var unhideWhenUsed6 = new UnhideWhenUsed();
    //        var rsid12 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties5 = new StyleParagraphProperties();
    //        var spacingBetweenLines4 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

    //        styleParagraphProperties5.Append(spacingBetweenLines4);

    //        var styleRunProperties7 = new StyleRunProperties();
    //        var runFonts275 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", ComplexScript = "Tahoma" };
    //        var fontSize273 = new FontSize() { Val = "16" };
    //        var fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "16" };

    //        styleRunProperties7.Append(runFonts275);
    //        styleRunProperties7.Append(fontSize273);
    //        styleRunProperties7.Append(fontSizeComplexScript4);

    //        style12.Append(styleName12);
    //        style12.Append(basedOn7);
    //        style12.Append(linkedStyle7);
    //        style12.Append(uIPriority11);
    //        style12.Append(semiHidden4);
    //        style12.Append(unhideWhenUsed6);
    //        style12.Append(rsid12);
    //        style12.Append(styleParagraphProperties5);
    //        style12.Append(styleRunProperties7);

    //        var style13 = new Style() { Type = StyleValues.Character, StyleId = "BalloonTextChar", CustomStyle = true };
    //        var styleName13 = new StyleName() { Val = "Balloon Text Char" };
    //        var basedOn8 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle8 = new LinkedStyle() { Val = "BalloonText" };
    //        var uIPriority12 = new UIPriority() { Val = 99 };
    //        var semiHidden5 = new SemiHidden();
    //        var rsid13 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties8 = new StyleRunProperties();
    //        var runFonts276 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", EastAsia = "Calibri", ComplexScript = "Tahoma" };
    //        var fontSize274 = new FontSize() { Val = "16" };
    //        var fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "16" };

    //        styleRunProperties8.Append(runFonts276);
    //        styleRunProperties8.Append(fontSize274);
    //        styleRunProperties8.Append(fontSizeComplexScript5);

    //        style13.Append(styleName13);
    //        style13.Append(basedOn8);
    //        style13.Append(linkedStyle8);
    //        style13.Append(uIPriority12);
    //        style13.Append(semiHidden5);
    //        style13.Append(rsid13);
    //        style13.Append(styleRunProperties8);

    //        styles1.Append(docDefaults1);
    //        styles1.Append(latentStyles1);
    //        styles1.Append(style1);
    //        styles1.Append(style2);
    //        styles1.Append(style3);
    //        styles1.Append(style4);
    //        styles1.Append(style5);
    //        styles1.Append(style6);
    //        styles1.Append(style7);
    //        styles1.Append(style8);
    //        styles1.Append(style9);
    //        styles1.Append(style10);
    //        styles1.Append(style11);
    //        styles1.Append(style12);
    //        styles1.Append(style13);

    //        stylesWithEffectsPart1.Styles = styles1;
    //    }

    //    // Generates content of styleDefinitionsPart1.
    //    private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
    //    {
    //        var styles2 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
    //        styles2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        styles2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        styles2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        styles2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

    //        var docDefaults2 = new DocDefaults();

    //        var runPropertiesDefault2 = new RunPropertiesDefault();

    //        var runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
    //        var runFonts277 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
    //        var fontSize275 = new FontSize() { Val = "22" };
    //        var fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "22" };
    //        var languages2 = new Languages() { Val = "en-GB", EastAsia = "en-US", Bidi = "ar-SA" };

    //        runPropertiesBaseStyle2.Append(runFonts277);
    //        runPropertiesBaseStyle2.Append(fontSize275);
    //        runPropertiesBaseStyle2.Append(fontSizeComplexScript6);
    //        runPropertiesBaseStyle2.Append(languages2);

    //        runPropertiesDefault2.Append(runPropertiesBaseStyle2);

    //        var paragraphPropertiesDefault2 = new ParagraphPropertiesDefault();

    //        var paragraphPropertiesBaseStyle2 = new ParagraphPropertiesBaseStyle();
    //        var spacingBetweenLines5 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

    //        paragraphPropertiesBaseStyle2.Append(spacingBetweenLines5);

    //        paragraphPropertiesDefault2.Append(paragraphPropertiesBaseStyle2);

    //        docDefaults2.Append(runPropertiesDefault2);
    //        docDefaults2.Append(paragraphPropertiesDefault2);

    //        var latentStyles2 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
    //        var latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
    //        var latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
    //        var latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
    //        var latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
    //        var latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
    //        var latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
    //        var latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
    //        var latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
    //        var latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
    //        var latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
    //        var latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
    //        var latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
    //        var latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
    //        var latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
    //        var latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
    //        var latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

    //        latentStyles2.Append(latentStyleExceptionInfo138);
    //        latentStyles2.Append(latentStyleExceptionInfo139);
    //        latentStyles2.Append(latentStyleExceptionInfo140);
    //        latentStyles2.Append(latentStyleExceptionInfo141);
    //        latentStyles2.Append(latentStyleExceptionInfo142);
    //        latentStyles2.Append(latentStyleExceptionInfo143);
    //        latentStyles2.Append(latentStyleExceptionInfo144);
    //        latentStyles2.Append(latentStyleExceptionInfo145);
    //        latentStyles2.Append(latentStyleExceptionInfo146);
    //        latentStyles2.Append(latentStyleExceptionInfo147);
    //        latentStyles2.Append(latentStyleExceptionInfo148);
    //        latentStyles2.Append(latentStyleExceptionInfo149);
    //        latentStyles2.Append(latentStyleExceptionInfo150);
    //        latentStyles2.Append(latentStyleExceptionInfo151);
    //        latentStyles2.Append(latentStyleExceptionInfo152);
    //        latentStyles2.Append(latentStyleExceptionInfo153);
    //        latentStyles2.Append(latentStyleExceptionInfo154);
    //        latentStyles2.Append(latentStyleExceptionInfo155);
    //        latentStyles2.Append(latentStyleExceptionInfo156);
    //        latentStyles2.Append(latentStyleExceptionInfo157);
    //        latentStyles2.Append(latentStyleExceptionInfo158);
    //        latentStyles2.Append(latentStyleExceptionInfo159);
    //        latentStyles2.Append(latentStyleExceptionInfo160);
    //        latentStyles2.Append(latentStyleExceptionInfo161);
    //        latentStyles2.Append(latentStyleExceptionInfo162);
    //        latentStyles2.Append(latentStyleExceptionInfo163);
    //        latentStyles2.Append(latentStyleExceptionInfo164);
    //        latentStyles2.Append(latentStyleExceptionInfo165);
    //        latentStyles2.Append(latentStyleExceptionInfo166);
    //        latentStyles2.Append(latentStyleExceptionInfo167);
    //        latentStyles2.Append(latentStyleExceptionInfo168);
    //        latentStyles2.Append(latentStyleExceptionInfo169);
    //        latentStyles2.Append(latentStyleExceptionInfo170);
    //        latentStyles2.Append(latentStyleExceptionInfo171);
    //        latentStyles2.Append(latentStyleExceptionInfo172);
    //        latentStyles2.Append(latentStyleExceptionInfo173);
    //        latentStyles2.Append(latentStyleExceptionInfo174);
    //        latentStyles2.Append(latentStyleExceptionInfo175);
    //        latentStyles2.Append(latentStyleExceptionInfo176);
    //        latentStyles2.Append(latentStyleExceptionInfo177);
    //        latentStyles2.Append(latentStyleExceptionInfo178);
    //        latentStyles2.Append(latentStyleExceptionInfo179);
    //        latentStyles2.Append(latentStyleExceptionInfo180);
    //        latentStyles2.Append(latentStyleExceptionInfo181);
    //        latentStyles2.Append(latentStyleExceptionInfo182);
    //        latentStyles2.Append(latentStyleExceptionInfo183);
    //        latentStyles2.Append(latentStyleExceptionInfo184);
    //        latentStyles2.Append(latentStyleExceptionInfo185);
    //        latentStyles2.Append(latentStyleExceptionInfo186);
    //        latentStyles2.Append(latentStyleExceptionInfo187);
    //        latentStyles2.Append(latentStyleExceptionInfo188);
    //        latentStyles2.Append(latentStyleExceptionInfo189);
    //        latentStyles2.Append(latentStyleExceptionInfo190);
    //        latentStyles2.Append(latentStyleExceptionInfo191);
    //        latentStyles2.Append(latentStyleExceptionInfo192);
    //        latentStyles2.Append(latentStyleExceptionInfo193);
    //        latentStyles2.Append(latentStyleExceptionInfo194);
    //        latentStyles2.Append(latentStyleExceptionInfo195);
    //        latentStyles2.Append(latentStyleExceptionInfo196);
    //        latentStyles2.Append(latentStyleExceptionInfo197);
    //        latentStyles2.Append(latentStyleExceptionInfo198);
    //        latentStyles2.Append(latentStyleExceptionInfo199);
    //        latentStyles2.Append(latentStyleExceptionInfo200);
    //        latentStyles2.Append(latentStyleExceptionInfo201);
    //        latentStyles2.Append(latentStyleExceptionInfo202);
    //        latentStyles2.Append(latentStyleExceptionInfo203);
    //        latentStyles2.Append(latentStyleExceptionInfo204);
    //        latentStyles2.Append(latentStyleExceptionInfo205);
    //        latentStyles2.Append(latentStyleExceptionInfo206);
    //        latentStyles2.Append(latentStyleExceptionInfo207);
    //        latentStyles2.Append(latentStyleExceptionInfo208);
    //        latentStyles2.Append(latentStyleExceptionInfo209);
    //        latentStyles2.Append(latentStyleExceptionInfo210);
    //        latentStyles2.Append(latentStyleExceptionInfo211);
    //        latentStyles2.Append(latentStyleExceptionInfo212);
    //        latentStyles2.Append(latentStyleExceptionInfo213);
    //        latentStyles2.Append(latentStyleExceptionInfo214);
    //        latentStyles2.Append(latentStyleExceptionInfo215);
    //        latentStyles2.Append(latentStyleExceptionInfo216);
    //        latentStyles2.Append(latentStyleExceptionInfo217);
    //        latentStyles2.Append(latentStyleExceptionInfo218);
    //        latentStyles2.Append(latentStyleExceptionInfo219);
    //        latentStyles2.Append(latentStyleExceptionInfo220);
    //        latentStyles2.Append(latentStyleExceptionInfo221);
    //        latentStyles2.Append(latentStyleExceptionInfo222);
    //        latentStyles2.Append(latentStyleExceptionInfo223);
    //        latentStyles2.Append(latentStyleExceptionInfo224);
    //        latentStyles2.Append(latentStyleExceptionInfo225);
    //        latentStyles2.Append(latentStyleExceptionInfo226);
    //        latentStyles2.Append(latentStyleExceptionInfo227);
    //        latentStyles2.Append(latentStyleExceptionInfo228);
    //        latentStyles2.Append(latentStyleExceptionInfo229);
    //        latentStyles2.Append(latentStyleExceptionInfo230);
    //        latentStyles2.Append(latentStyleExceptionInfo231);
    //        latentStyles2.Append(latentStyleExceptionInfo232);
    //        latentStyles2.Append(latentStyleExceptionInfo233);
    //        latentStyles2.Append(latentStyleExceptionInfo234);
    //        latentStyles2.Append(latentStyleExceptionInfo235);
    //        latentStyles2.Append(latentStyleExceptionInfo236);
    //        latentStyles2.Append(latentStyleExceptionInfo237);
    //        latentStyles2.Append(latentStyleExceptionInfo238);
    //        latentStyles2.Append(latentStyleExceptionInfo239);
    //        latentStyles2.Append(latentStyleExceptionInfo240);
    //        latentStyles2.Append(latentStyleExceptionInfo241);
    //        latentStyles2.Append(latentStyleExceptionInfo242);
    //        latentStyles2.Append(latentStyleExceptionInfo243);
    //        latentStyles2.Append(latentStyleExceptionInfo244);
    //        latentStyles2.Append(latentStyleExceptionInfo245);
    //        latentStyles2.Append(latentStyleExceptionInfo246);
    //        latentStyles2.Append(latentStyleExceptionInfo247);
    //        latentStyles2.Append(latentStyleExceptionInfo248);
    //        latentStyles2.Append(latentStyleExceptionInfo249);
    //        latentStyles2.Append(latentStyleExceptionInfo250);
    //        latentStyles2.Append(latentStyleExceptionInfo251);
    //        latentStyles2.Append(latentStyleExceptionInfo252);
    //        latentStyles2.Append(latentStyleExceptionInfo253);
    //        latentStyles2.Append(latentStyleExceptionInfo254);
    //        latentStyles2.Append(latentStyleExceptionInfo255);
    //        latentStyles2.Append(latentStyleExceptionInfo256);
    //        latentStyles2.Append(latentStyleExceptionInfo257);
    //        latentStyles2.Append(latentStyleExceptionInfo258);
    //        latentStyles2.Append(latentStyleExceptionInfo259);
    //        latentStyles2.Append(latentStyleExceptionInfo260);
    //        latentStyles2.Append(latentStyleExceptionInfo261);
    //        latentStyles2.Append(latentStyleExceptionInfo262);
    //        latentStyles2.Append(latentStyleExceptionInfo263);
    //        latentStyles2.Append(latentStyleExceptionInfo264);
    //        latentStyles2.Append(latentStyleExceptionInfo265);
    //        latentStyles2.Append(latentStyleExceptionInfo266);
    //        latentStyles2.Append(latentStyleExceptionInfo267);
    //        latentStyles2.Append(latentStyleExceptionInfo268);
    //        latentStyles2.Append(latentStyleExceptionInfo269);
    //        latentStyles2.Append(latentStyleExceptionInfo270);
    //        latentStyles2.Append(latentStyleExceptionInfo271);
    //        latentStyles2.Append(latentStyleExceptionInfo272);
    //        latentStyles2.Append(latentStyleExceptionInfo273);
    //        latentStyles2.Append(latentStyleExceptionInfo274);

    //        var style14 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normal", Default = true };
    //        var styleName14 = new StyleName() { Val = "Normal" };
    //        var primaryStyle4 = new PrimaryStyle();
    //        var rsid14 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties9 = new StyleRunProperties();
    //        var runFonts278 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties9.Append(runFonts278);

    //        style14.Append(styleName14);
    //        style14.Append(primaryStyle4);
    //        style14.Append(rsid14);
    //        style14.Append(styleRunProperties9);

    //        var style15 = new Style() { Type = StyleValues.Paragraph, StyleId = "Heading1" };
    //        var styleName15 = new StyleName() { Val = "heading 1" };
    //        var basedOn9 = new BasedOn() { Val = "Normal" };
    //        var nextParagraphStyle2 = new NextParagraphStyle() { Val = "Normal" };
    //        var linkedStyle9 = new LinkedStyle() { Val = "Heading1Char" };
    //        var uIPriority13 = new UIPriority() { Val = 9 };
    //        var primaryStyle5 = new PrimaryStyle();
    //        var rsid15 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties6 = new StyleParagraphProperties();
    //        var keepNext2 = new KeepNext();
    //        var spacingBetweenLines6 = new SpacingBetweenLines() { Before = "240", After = "60" };
    //        var outlineLevel2 = new OutlineLevel() { Val = 0 };

    //        styleParagraphProperties6.Append(keepNext2);
    //        styleParagraphProperties6.Append(spacingBetweenLines6);
    //        styleParagraphProperties6.Append(outlineLevel2);

    //        var styleRunProperties10 = new StyleRunProperties();
    //        var runFonts279 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman" };
    //        var bold68 = new Bold();
    //        var boldComplexScript3 = new BoldComplexScript();
    //        var kern3 = new Kern() { Val = (UInt32Value)32U };
    //        var fontSize276 = new FontSize() { Val = "32" };
    //        var fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "32" };

    //        styleRunProperties10.Append(runFonts279);
    //        styleRunProperties10.Append(bold68);
    //        styleRunProperties10.Append(boldComplexScript3);
    //        styleRunProperties10.Append(kern3);
    //        styleRunProperties10.Append(fontSize276);
    //        styleRunProperties10.Append(fontSizeComplexScript7);

    //        style15.Append(styleName15);
    //        style15.Append(basedOn9);
    //        style15.Append(nextParagraphStyle2);
    //        style15.Append(linkedStyle9);
    //        style15.Append(uIPriority13);
    //        style15.Append(primaryStyle5);
    //        style15.Append(rsid15);
    //        style15.Append(styleParagraphProperties6);
    //        style15.Append(styleRunProperties10);

    //        var style16 = new Style() { Type = StyleValues.Character, StyleId = "DefaultParagraphFont", Default = true };
    //        var styleName16 = new StyleName() { Val = "Default Paragraph Font" };
    //        var uIPriority14 = new UIPriority() { Val = 1 };
    //        var semiHidden6 = new SemiHidden();
    //        var unhideWhenUsed7 = new UnhideWhenUsed();

    //        style16.Append(styleName16);
    //        style16.Append(uIPriority14);
    //        style16.Append(semiHidden6);
    //        style16.Append(unhideWhenUsed7);

    //        var style17 = new Style() { Type = StyleValues.Table, StyleId = "TableNormal", Default = true };
    //        var styleName17 = new StyleName() { Val = "Normal Table" };
    //        var uIPriority15 = new UIPriority() { Val = 99 };
    //        var semiHidden7 = new SemiHidden();
    //        var unhideWhenUsed8 = new UnhideWhenUsed();

    //        var styleTableProperties2 = new StyleTableProperties();
    //        var tableIndentation2 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

    //        var tableCellMarginDefault31 = new TableCellMarginDefault();
    //        var topMargin132 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
    //        var bottomMargin132 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
    //        var tableCellRightMargin2 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

    //        tableCellMarginDefault31.Append(topMargin132);
    //        tableCellMarginDefault31.Append(tableCellLeftMargin2);
    //        tableCellMarginDefault31.Append(bottomMargin132);
    //        tableCellMarginDefault31.Append(tableCellRightMargin2);

    //        styleTableProperties2.Append(tableIndentation2);
    //        styleTableProperties2.Append(tableCellMarginDefault31);

    //        style17.Append(styleName17);
    //        style17.Append(uIPriority15);
    //        style17.Append(semiHidden7);
    //        style17.Append(unhideWhenUsed8);
    //        style17.Append(styleTableProperties2);

    //        var style18 = new Style() { Type = StyleValues.Numbering, StyleId = "NoList", Default = true };
    //        var styleName18 = new StyleName() { Val = "No List" };
    //        var uIPriority16 = new UIPriority() { Val = 99 };
    //        var semiHidden8 = new SemiHidden();
    //        var unhideWhenUsed9 = new UnhideWhenUsed();

    //        style18.Append(styleName18);
    //        style18.Append(uIPriority16);
    //        style18.Append(semiHidden8);
    //        style18.Append(unhideWhenUsed9);

    //        var style19 = new Style() { Type = StyleValues.Character, StyleId = "Heading1Char", CustomStyle = true };
    //        var styleName19 = new StyleName() { Val = "Heading 1 Char" };
    //        var basedOn10 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle10 = new LinkedStyle() { Val = "Heading1" };
    //        var uIPriority17 = new UIPriority() { Val = 9 };
    //        var rsid16 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties11 = new StyleRunProperties();
    //        var runFonts280 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
    //        var bold69 = new Bold();
    //        var boldComplexScript4 = new BoldComplexScript();
    //        var kern4 = new Kern() { Val = (UInt32Value)32U };
    //        var fontSize277 = new FontSize() { Val = "32" };
    //        var fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "32" };

    //        styleRunProperties11.Append(runFonts280);
    //        styleRunProperties11.Append(bold69);
    //        styleRunProperties11.Append(boldComplexScript4);
    //        styleRunProperties11.Append(kern4);
    //        styleRunProperties11.Append(fontSize277);
    //        styleRunProperties11.Append(fontSizeComplexScript8);

    //        style19.Append(styleName19);
    //        style19.Append(basedOn10);
    //        style19.Append(linkedStyle10);
    //        style19.Append(uIPriority17);
    //        style19.Append(rsid16);
    //        style19.Append(styleRunProperties11);

    //        var style20 = new Style() { Type = StyleValues.Paragraph, StyleId = "NoSpacing" };
    //        var styleName20 = new StyleName() { Val = "No Spacing" };
    //        var uIPriority18 = new UIPriority() { Val = 1 };
    //        var primaryStyle6 = new PrimaryStyle();
    //        var rsid17 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties7 = new StyleParagraphProperties();
    //        var spacingBetweenLines7 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

    //        styleParagraphProperties7.Append(spacingBetweenLines7);

    //        var styleRunProperties12 = new StyleRunProperties();
    //        var runFonts281 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties12.Append(runFonts281);

    //        style20.Append(styleName20);
    //        style20.Append(uIPriority18);
    //        style20.Append(primaryStyle6);
    //        style20.Append(rsid17);
    //        style20.Append(styleParagraphProperties7);
    //        style20.Append(styleRunProperties12);

    //        var style21 = new Style() { Type = StyleValues.Paragraph, StyleId = "Header" };
    //        var styleName21 = new StyleName() { Val = "header" };
    //        var basedOn11 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle11 = new LinkedStyle() { Val = "HeaderChar" };
    //        var uIPriority19 = new UIPriority() { Val = 99 };
    //        var unhideWhenUsed10 = new UnhideWhenUsed();
    //        var rsid18 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties8 = new StyleParagraphProperties();

    //        var tabs3 = new Tabs();
    //        var tabStop5 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
    //        var tabStop6 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

    //        tabs3.Append(tabStop5);
    //        tabs3.Append(tabStop6);

    //        styleParagraphProperties8.Append(tabs3);

    //        style21.Append(styleName21);
    //        style21.Append(basedOn11);
    //        style21.Append(linkedStyle11);
    //        style21.Append(uIPriority19);
    //        style21.Append(unhideWhenUsed10);
    //        style21.Append(rsid18);
    //        style21.Append(styleParagraphProperties8);

    //        var style22 = new Style() { Type = StyleValues.Character, StyleId = "HeaderChar", CustomStyle = true };
    //        var styleName22 = new StyleName() { Val = "Header Char" };
    //        var basedOn12 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle12 = new LinkedStyle() { Val = "Header" };
    //        var uIPriority20 = new UIPriority() { Val = 99 };
    //        var rsid19 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties13 = new StyleRunProperties();
    //        var runFonts282 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties13.Append(runFonts282);

    //        style22.Append(styleName22);
    //        style22.Append(basedOn12);
    //        style22.Append(linkedStyle12);
    //        style22.Append(uIPriority20);
    //        style22.Append(rsid19);
    //        style22.Append(styleRunProperties13);

    //        var style23 = new Style() { Type = StyleValues.Paragraph, StyleId = "Footer" };
    //        var styleName23 = new StyleName() { Val = "footer" };
    //        var basedOn13 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle13 = new LinkedStyle() { Val = "FooterChar" };
    //        var uIPriority21 = new UIPriority() { Val = 99 };
    //        var unhideWhenUsed11 = new UnhideWhenUsed();
    //        var rsid20 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties9 = new StyleParagraphProperties();

    //        var tabs4 = new Tabs();
    //        var tabStop7 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
    //        var tabStop8 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

    //        tabs4.Append(tabStop7);
    //        tabs4.Append(tabStop8);

    //        styleParagraphProperties9.Append(tabs4);

    //        style23.Append(styleName23);
    //        style23.Append(basedOn13);
    //        style23.Append(linkedStyle13);
    //        style23.Append(uIPriority21);
    //        style23.Append(unhideWhenUsed11);
    //        style23.Append(rsid20);
    //        style23.Append(styleParagraphProperties9);

    //        var style24 = new Style() { Type = StyleValues.Character, StyleId = "FooterChar", CustomStyle = true };
    //        var styleName24 = new StyleName() { Val = "Footer Char" };
    //        var basedOn14 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle14 = new LinkedStyle() { Val = "Footer" };
    //        var uIPriority22 = new UIPriority() { Val = 99 };
    //        var rsid21 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties14 = new StyleRunProperties();
    //        var runFonts283 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };

    //        styleRunProperties14.Append(runFonts283);

    //        style24.Append(styleName24);
    //        style24.Append(basedOn14);
    //        style24.Append(linkedStyle14);
    //        style24.Append(uIPriority22);
    //        style24.Append(rsid21);
    //        style24.Append(styleRunProperties14);

    //        var style25 = new Style() { Type = StyleValues.Paragraph, StyleId = "BalloonText" };
    //        var styleName25 = new StyleName() { Val = "Balloon Text" };
    //        var basedOn15 = new BasedOn() { Val = "Normal" };
    //        var linkedStyle15 = new LinkedStyle() { Val = "BalloonTextChar" };
    //        var uIPriority23 = new UIPriority() { Val = 99 };
    //        var semiHidden9 = new SemiHidden();
    //        var unhideWhenUsed12 = new UnhideWhenUsed();
    //        var rsid22 = new Rsid() { Val = "00602ED1" };

    //        var styleParagraphProperties10 = new StyleParagraphProperties();
    //        var spacingBetweenLines8 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

    //        styleParagraphProperties10.Append(spacingBetweenLines8);

    //        var styleRunProperties15 = new StyleRunProperties();
    //        var runFonts284 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", ComplexScript = "Tahoma" };
    //        var fontSize278 = new FontSize() { Val = "16" };
    //        var fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "16" };

    //        styleRunProperties15.Append(runFonts284);
    //        styleRunProperties15.Append(fontSize278);
    //        styleRunProperties15.Append(fontSizeComplexScript9);

    //        style25.Append(styleName25);
    //        style25.Append(basedOn15);
    //        style25.Append(linkedStyle15);
    //        style25.Append(uIPriority23);
    //        style25.Append(semiHidden9);
    //        style25.Append(unhideWhenUsed12);
    //        style25.Append(rsid22);
    //        style25.Append(styleParagraphProperties10);
    //        style25.Append(styleRunProperties15);

    //        var style26 = new Style() { Type = StyleValues.Character, StyleId = "BalloonTextChar", CustomStyle = true };
    //        var styleName26 = new StyleName() { Val = "Balloon Text Char" };
    //        var basedOn16 = new BasedOn() { Val = "DefaultParagraphFont" };
    //        var linkedStyle16 = new LinkedStyle() { Val = "BalloonText" };
    //        var uIPriority24 = new UIPriority() { Val = 99 };
    //        var semiHidden10 = new SemiHidden();
    //        var rsid23 = new Rsid() { Val = "00602ED1" };

    //        var styleRunProperties16 = new StyleRunProperties();
    //        var runFonts285 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", EastAsia = "Calibri", ComplexScript = "Tahoma" };
    //        var fontSize279 = new FontSize() { Val = "16" };
    //        var fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "16" };

    //        styleRunProperties16.Append(runFonts285);
    //        styleRunProperties16.Append(fontSize279);
    //        styleRunProperties16.Append(fontSizeComplexScript10);

    //        style26.Append(styleName26);
    //        style26.Append(basedOn16);
    //        style26.Append(linkedStyle16);
    //        style26.Append(uIPriority24);
    //        style26.Append(semiHidden10);
    //        style26.Append(rsid23);
    //        style26.Append(styleRunProperties16);

    //        styles2.Append(docDefaults2);
    //        styles2.Append(latentStyles2);
    //        styles2.Append(style14);
    //        styles2.Append(style15);
    //        styles2.Append(style16);
    //        styles2.Append(style17);
    //        styles2.Append(style18);
    //        styles2.Append(style19);
    //        styles2.Append(style20);
    //        styles2.Append(style21);
    //        styles2.Append(style22);
    //        styles2.Append(style23);
    //        styles2.Append(style24);
    //        styles2.Append(style25);
    //        styles2.Append(style26);

    //        styleDefinitionsPart1.Styles = styles2;
    //    }

    //    // Generates content of headerPart1.
    //    private void GenerateHeaderPart1Content(HeaderPart headerPart1)
    //    {
    //        var header1 = new Header() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        header1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        header1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        header1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        header1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        header1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        header1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        header1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        header1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        header1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        header1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        header1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        header1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        header1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        header1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        header1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var paragraph150 = new Paragraph() { RsidParagraphMarkRevision = "004E4E45", RsidParagraphAddition = "00DB5540", RsidParagraphProperties = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties149 = new ParagraphProperties();
    //        var paragraphStyleId149 = new ParagraphStyleId() { Val = "Header" };

    //        paragraphProperties149.Append(paragraphStyleId149);

    //        paragraph150.Append(paragraphProperties149);

    //        header1.Append(paragraph150);

    //        headerPart1.Header = header1;
    //    }

    //    // Generates content of fontTablePart1.
    //    private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
    //    {
    //        var fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
    //        fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

    //        var font1 = new Font() { Name = "Calibri" };
    //        var panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
    //        var fontCharSet1 = new FontCharSet() { Val = "00" };
    //        var fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
    //        var pitch1 = new Pitch() { Val = FontPitchValues.Variable };
    //        var fontSignature1 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

    //        font1.Append(panose1Number1);
    //        font1.Append(fontCharSet1);
    //        font1.Append(fontFamily1);
    //        font1.Append(pitch1);
    //        font1.Append(fontSignature1);

    //        var font2 = new Font() { Name = "Times New Roman" };
    //        var panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
    //        var fontCharSet2 = new FontCharSet() { Val = "00" };
    //        var fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
    //        var pitch2 = new Pitch() { Val = FontPitchValues.Variable };
    //        var fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002EFF", UnicodeSignature1 = "C0007843", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

    //        font2.Append(panose1Number2);
    //        font2.Append(fontCharSet2);
    //        font2.Append(fontFamily2);
    //        font2.Append(pitch2);
    //        font2.Append(fontSignature2);

    //        var font3 = new Font() { Name = "Cambria" };
    //        var panose1Number3 = new Panose1Number() { Val = "02040503050406030204" };
    //        var fontCharSet3 = new FontCharSet() { Val = "00" };
    //        var fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
    //        var pitch3 = new Pitch() { Val = FontPitchValues.Variable };
    //        var fontSignature3 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "400004FF", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

    //        font3.Append(panose1Number3);
    //        font3.Append(fontCharSet3);
    //        font3.Append(fontFamily3);
    //        font3.Append(pitch3);
    //        font3.Append(fontSignature3);

    //        var font4 = new Font() { Name = "Tahoma" };
    //        var panose1Number4 = new Panose1Number() { Val = "020B0604030504040204" };
    //        var fontCharSet4 = new FontCharSet() { Val = "00" };
    //        var fontFamily4 = new FontFamily() { Val = FontFamilyValues.Swiss };
    //        var pitch4 = new Pitch() { Val = FontPitchValues.Variable };
    //        var fontSignature4 = new FontSignature() { UnicodeSignature0 = "E1002EFF", UnicodeSignature1 = "C000605B", UnicodeSignature2 = "00000029", UnicodeSignature3 = "00000000", CodePageSignature0 = "000101FF", CodePageSignature1 = "00000000" };

    //        font4.Append(panose1Number4);
    //        font4.Append(fontCharSet4);
    //        font4.Append(fontFamily4);
    //        font4.Append(pitch4);
    //        font4.Append(fontSignature4);

    //        var font5 = new Font() { Name = "Ariel" };
    //        var altName1 = new AltName() { Val = "Times New Roman" };
    //        var panose1Number5 = new Panose1Number() { Val = "00000000000000000000" };
    //        var fontCharSet5 = new FontCharSet() { Val = "00" };
    //        var fontFamily5 = new FontFamily() { Val = FontFamilyValues.Roman };
    //        var notTrueType1 = new NotTrueType();
    //        var pitch5 = new Pitch() { Val = FontPitchValues.Default };

    //        font5.Append(altName1);
    //        font5.Append(panose1Number5);
    //        font5.Append(fontCharSet5);
    //        font5.Append(fontFamily5);
    //        font5.Append(notTrueType1);
    //        font5.Append(pitch5);

    //        var font6 = new Font() { Name = "Arial" };
    //        var panose1Number6 = new Panose1Number() { Val = "020B0604020202020204" };
    //        var fontCharSet6 = new FontCharSet() { Val = "00" };
    //        var fontFamily6 = new FontFamily() { Val = FontFamilyValues.Swiss };
    //        var pitch6 = new Pitch() { Val = FontPitchValues.Variable };
    //        var fontSignature5 = new FontSignature() { UnicodeSignature0 = "E0002EFF", UnicodeSignature1 = "C0007843", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

    //        font6.Append(panose1Number6);
    //        font6.Append(fontCharSet6);
    //        font6.Append(fontFamily6);
    //        font6.Append(pitch6);
    //        font6.Append(fontSignature5);

    //        fonts1.Append(font1);
    //        fonts1.Append(font2);
    //        fonts1.Append(font3);
    //        fonts1.Append(font4);
    //        fonts1.Append(font5);
    //        fonts1.Append(font6);

    //        fontTablePart1.Fonts = fonts1;
    //    }

    //    // Generates content of headerPart2.
    //    private void GenerateHeaderPart2Content(HeaderPart headerPart2)
    //    {
    //        var header2 = new Header() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        header2.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        header2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        header2.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        header2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        header2.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        header2.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        header2.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        header2.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        header2.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        header2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        header2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        header2.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        header2.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        header2.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        header2.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var paragraph151 = new Paragraph() { RsidParagraphAddition = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties150 = new ParagraphProperties();
    //        var paragraphStyleId150 = new ParagraphStyleId() { Val = "Header" };

    //        paragraphProperties150.Append(paragraphStyleId150);

    //        paragraph151.Append(paragraphProperties150);

    //        header2.Append(paragraph151);

    //        headerPart2.Header = header2;
    //    }

    //    // Generates content of footerPart3.
    //    private void GenerateFooterPart3Content(FooterPart footerPart3)
    //    {
    //        var footer3 = new Footer() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        footer3.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        footer3.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        footer3.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        footer3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        footer3.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        footer3.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        footer3.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        footer3.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        footer3.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        footer3.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        footer3.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        footer3.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        footer3.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        footer3.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        footer3.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var paragraph152 = new Paragraph() { RsidParagraphAddition = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties151 = new ParagraphProperties();
    //        var paragraphStyleId151 = new ParagraphStyleId() { Val = "Footer" };

    //        paragraphProperties151.Append(paragraphStyleId151);

    //        paragraph152.Append(paragraphProperties151);

    //        footer3.Append(paragraph152);

    //        footerPart3.Footer = footer3;
    //    }

    //    // Generates content of webSettingsPart1.
    //    private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
    //    {
    //        var webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
    //        webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        var optimizeForBrowser1 = new OptimizeForBrowser();
    //        var allowPNG1 = new AllowPNG();

    //        webSettings1.Append(optimizeForBrowser1);
    //        webSettings1.Append(allowPNG1);

    //        webSettingsPart1.WebSettings = webSettings1;
    //    }

    //    // Generates content of headerPart3.
    //    private void GenerateHeaderPart3Content(HeaderPart headerPart3)
    //    {
    //        var header3 = new Header() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
    //        header3.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
    //        header3.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
    //        header3.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
    //        header3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
    //        header3.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
    //        header3.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
    //        header3.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
    //        header3.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
    //        header3.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
    //        header3.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        header3.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
    //        header3.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
    //        header3.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
    //        header3.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
    //        header3.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

    //        var table9 = new Table();

    //        var tableProperties9 = new TableProperties();
    //        var tableWidth9 = new TableWidth() { Width = "10758", Type = TableWidthUnitValues.Dxa };
    //        var tableLook9 = new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

    //        tableProperties9.Append(tableWidth9);
    //        tableProperties9.Append(tableLook9);

    //        var tableGrid9 = new TableGrid();
    //        var gridColumn30 = new GridColumn() { Width = "3882" };
    //        var gridColumn31 = new GridColumn() { Width = "1329" };
    //        var gridColumn32 = new GridColumn() { Width = "2977" };
    //        var gridColumn33 = new GridColumn() { Width = "236" };
    //        var gridColumn34 = new GridColumn() { Width = "2334" };

    //        tableGrid9.Append(gridColumn30);
    //        tableGrid9.Append(gridColumn31);
    //        tableGrid9.Append(gridColumn32);
    //        tableGrid9.Append(gridColumn33);
    //        tableGrid9.Append(gridColumn34);

    //        var tableRow30 = new TableRow() { RsidTableRowMarkRevision = "00000EA8", RsidTableRowAddition = "00876E56", RsidTableRowProperties = "002110C8" };

    //        var tableRowProperties1 = new TableRowProperties();
    //        var gridAfter1 = new GridAfter() { Val = 1 };
    //        var widthAfterTableRow1 = new WidthAfterTableRow() { Width = "2334", Type = TableWidthUnitValues.Dxa };
    //        var tableRowHeight1 = new TableRowHeight() { Val = (UInt32Value)436U };

    //        tableRowProperties1.Append(gridAfter1);
    //        tableRowProperties1.Append(widthAfterTableRow1);
    //        tableRowProperties1.Append(tableRowHeight1);

    //        var tableCell102 = new TableCell();

    //        var tableCellProperties102 = new TableCellProperties();
    //        var tableCellWidth102 = new TableCellWidth() { Width = "3882", Type = TableWidthUnitValues.Dxa };
    //        var verticalMerge1 = new VerticalMerge() { Val = MergedCellValues.Restart };
    //        var shading102 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties102.Append(tableCellWidth102);
    //        tableCellProperties102.Append(verticalMerge1);
    //        tableCellProperties102.Append(shading102);

    //        var paragraph153 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00000EA8", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties152 = new ParagraphProperties();
    //        var paragraphStyleId152 = new ParagraphStyleId() { Val = "Heading1" };

    //        var paragraphMarkRunProperties147 = new ParagraphMarkRunProperties();
    //        var runFonts286 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var boldComplexScript5 = new BoldComplexScript() { Val = false };
    //        var fontSize280 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties147.Append(runFonts286);
    //        paragraphMarkRunProperties147.Append(boldComplexScript5);
    //        paragraphMarkRunProperties147.Append(fontSize280);
    //        paragraphMarkRunProperties147.Append(fontSizeComplexScript11);

    //        paragraphProperties152.Append(paragraphStyleId152);
    //        paragraphProperties152.Append(paragraphMarkRunProperties147);

    //        var run124 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties124 = new RunProperties();
    //        var runFonts287 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var boldComplexScript6 = new BoldComplexScript() { Val = false };
    //        var fontSize281 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties124.Append(runFonts287);
    //        runProperties124.Append(boldComplexScript6);
    //        runProperties124.Append(fontSize281);
    //        runProperties124.Append(fontSizeComplexScript12);
    //        var text124 = new Text();
    //        text124.Text = "Values Based Lettings";

    //        run124.Append(runProperties124);
    //        run124.Append(text124);

    //        paragraph153.Append(paragraphProperties152);
    //        paragraph153.Append(run124);

    //        var paragraph154 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties153 = new ParagraphProperties();
    //        var paragraphStyleId153 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties148 = new ParagraphMarkRunProperties();
    //        var fontSize282 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties148.Append(fontSize282);
    //        paragraphMarkRunProperties148.Append(fontSizeComplexScript13);

    //        paragraphProperties153.Append(paragraphStyleId153);
    //        paragraphProperties153.Append(paragraphMarkRunProperties148);

    //        var run125 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties125 = new RunProperties();
    //        var fontSize283 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties125.Append(fontSize283);
    //        runProperties125.Append(fontSizeComplexScript14);
    //        var text125 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text125.Text = " ";

    //        run125.Append(runProperties125);
    //        run125.Append(text125);

    //        var run126 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties126 = new RunProperties();
    //        var fontSize284 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties126.Append(fontSize284);
    //        runProperties126.Append(fontSizeComplexScript15);
    //        var text126 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text126.Text = "           ";

    //        run126.Append(runProperties126);
    //        run126.Append(text126);

    //        paragraph154.Append(paragraphProperties153);
    //        paragraph154.Append(run125);
    //        paragraph154.Append(run126);

    //        var paragraph155 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties154 = new ParagraphProperties();
    //        var paragraphStyleId154 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties149 = new ParagraphMarkRunProperties();
    //        var fontSize285 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties149.Append(fontSize285);
    //        paragraphMarkRunProperties149.Append(fontSizeComplexScript16);

    //        paragraphProperties154.Append(paragraphStyleId154);
    //        paragraphProperties154.Append(paragraphMarkRunProperties149);

    //        paragraph155.Append(paragraphProperties154);

    //        var paragraph156 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties155 = new ParagraphProperties();
    //        var paragraphStyleId155 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties150 = new ParagraphMarkRunProperties();
    //        var fontSize286 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties150.Append(fontSize286);
    //        paragraphMarkRunProperties150.Append(fontSizeComplexScript17);

    //        paragraphProperties155.Append(paragraphStyleId155);
    //        paragraphProperties155.Append(paragraphMarkRunProperties150);

    //        paragraph156.Append(paragraphProperties155);

    //        var paragraph157 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties156 = new ParagraphProperties();
    //        var paragraphStyleId156 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties151 = new ParagraphMarkRunProperties();
    //        var fontSize287 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties151.Append(fontSize287);
    //        paragraphMarkRunProperties151.Append(fontSizeComplexScript18);

    //        paragraphProperties156.Append(paragraphStyleId156);
    //        paragraphProperties156.Append(paragraphMarkRunProperties151);

    //        paragraph157.Append(paragraphProperties156);

    //        var paragraph158 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties157 = new ParagraphProperties();
    //        var paragraphStyleId157 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties152 = new ParagraphMarkRunProperties();
    //        var fontSize288 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties152.Append(fontSize288);
    //        paragraphMarkRunProperties152.Append(fontSizeComplexScript19);

    //        paragraphProperties157.Append(paragraphStyleId157);
    //        paragraphProperties157.Append(paragraphMarkRunProperties152);

    //        paragraph158.Append(paragraphProperties157);

    //        var paragraph159 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00115C0B", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties158 = new ParagraphProperties();
    //        var spacingBetweenLines9 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties153 = new ParagraphMarkRunProperties();
    //        var bold70 = new Bold();
    //        var fontSize289 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties153.Append(bold70);
    //        paragraphMarkRunProperties153.Append(fontSize289);
    //        paragraphMarkRunProperties153.Append(fontSizeComplexScript20);

    //        paragraphProperties158.Append(spacingBetweenLines9);
    //        paragraphProperties158.Append(paragraphMarkRunProperties153);

    //        paragraph159.Append(paragraphProperties158);

    //        var paragraph160 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties159 = new ParagraphProperties();
    //        var spacingBetweenLines10 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties154 = new ParagraphMarkRunProperties();
    //        var runFonts288 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var bold71 = new Bold();
    //        var fontSize290 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties154.Append(runFonts288);
    //        paragraphMarkRunProperties154.Append(bold71);
    //        paragraphMarkRunProperties154.Append(fontSize290);
    //        paragraphMarkRunProperties154.Append(fontSizeComplexScript21);

    //        paragraphProperties159.Append(spacingBetweenLines10);
    //        paragraphProperties159.Append(paragraphMarkRunProperties154);

    //        var run127 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties127 = new RunProperties();
    //        var runFonts289 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var bold72 = new Bold();
    //        var fontSize291 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties127.Append(runFonts289);
    //        runProperties127.Append(bold72);
    //        runProperties127.Append(fontSize291);
    //        runProperties127.Append(fontSizeComplexScript22);
    //        var text127 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text127.Text = "Customers Address:  ";

    //        run127.Append(runProperties127);
    //        run127.Append(text127);

    //        paragraph160.Append(paragraphProperties159);
    //        paragraph160.Append(run127);

    //        var paragraph161 = new Paragraph() { RsidParagraphAddition = "00B46F26", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties160 = new ParagraphProperties();
    //        var spacingBetweenLines11 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties155 = new ParagraphMarkRunProperties();
    //        var fontSize292 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties155.Append(fontSize292);
    //        paragraphMarkRunProperties155.Append(fontSizeComplexScript23);

    //        paragraphProperties160.Append(spacingBetweenLines11);
    //        paragraphProperties160.Append(paragraphMarkRunProperties155);
    //        var bookmarkStart2 = new BookmarkStart() { Name = "bkAddress", Id = "1" };
    //        var bookmarkEnd2 = new BookmarkEnd() { Id = "1" };

    //        var run128 = new Run();

    //        var runProperties128 = new RunProperties();
    //        var fontSize293 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties128.Append(fontSize293);
    //        runProperties128.Append(fontSizeComplexScript24);
    //        var text128 = new Text();
    //        text128.Text = _mainApplicant.Forename + " " + _mainApplicant.Surname;

    //        run128.Append(runProperties128);
    //        run128.Append(text128);

    //        paragraph161.Append(paragraphProperties160);
    //        paragraph161.Append(bookmarkStart2);
    //        paragraph161.Append(bookmarkEnd2);
    //        paragraph161.Append(run128);

    //        var paragraph162 = new Paragraph() { RsidParagraphAddition = "00B46F26", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties161 = new ParagraphProperties();
    //        var spacingBetweenLines12 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties156 = new ParagraphMarkRunProperties();
    //        var fontSize294 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties156.Append(fontSize294);
    //        paragraphMarkRunProperties156.Append(fontSizeComplexScript25);

    //        paragraphProperties161.Append(spacingBetweenLines12);
    //        paragraphProperties161.Append(paragraphMarkRunProperties156);

    //        var run129 = new Run();

    //        var runProperties129 = new RunProperties();
    //        var fontSize295 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties129.Append(fontSize295);
    //        runProperties129.Append(fontSizeComplexScript26);
    //        var text129 = new Text();
    //        text129.Text = _addressLine1;

    //        run129.Append(runProperties129);
    //        run129.Append(text129);

    //        paragraph162.Append(paragraphProperties161);
    //        paragraph162.Append(run129);

    //        var paragraph163 = new Paragraph() { RsidParagraphAddition = "00B46F26", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties162 = new ParagraphProperties();
    //        var spacingBetweenLines13 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties157 = new ParagraphMarkRunProperties();
    //        var fontSize296 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties157.Append(fontSize296);
    //        paragraphMarkRunProperties157.Append(fontSizeComplexScript27);

    //        paragraphProperties162.Append(spacingBetweenLines13);
    //        paragraphProperties162.Append(paragraphMarkRunProperties157);

    //        var run130 = new Run();

    //        var runProperties130 = new RunProperties();
    //        var fontSize297 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties130.Append(fontSize297);
    //        runProperties130.Append(fontSizeComplexScript28);
    //        var text130 = new Text();
    //        text130.Text = _addressLine2;

    //        run130.Append(runProperties130);
    //        run130.Append(text130);

    //        paragraph163.Append(paragraphProperties162);
    //        paragraph163.Append(run130);

    //        var paragraph164 = new Paragraph() { RsidParagraphAddition = "00B46F26", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties163 = new ParagraphProperties();
    //        var spacingBetweenLines14 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties158 = new ParagraphMarkRunProperties();
    //        var fontSize298 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript29 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties158.Append(fontSize298);
    //        paragraphMarkRunProperties158.Append(fontSizeComplexScript29);

    //        paragraphProperties163.Append(spacingBetweenLines14);
    //        paragraphProperties163.Append(paragraphMarkRunProperties158);

    //        var run131 = new Run();

    //        var runProperties131 = new RunProperties();
    //        var fontSize299 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript30 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties131.Append(fontSize299);
    //        runProperties131.Append(fontSizeComplexScript30);
    //        var text131 = new Text();
    //        text131.Text = _addressCity;

    //        run131.Append(runProperties131);
    //        run131.Append(text131);

    //        paragraph164.Append(paragraphProperties163);
    //        paragraph164.Append(run131);

    //        var paragraph165 = new Paragraph() { RsidParagraphAddition = "00B46F26", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties164 = new ParagraphProperties();
    //        var spacingBetweenLines15 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties159 = new ParagraphMarkRunProperties();
    //        var fontSize300 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript31 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties159.Append(fontSize300);
    //        paragraphMarkRunProperties159.Append(fontSizeComplexScript31);

    //        paragraphProperties164.Append(spacingBetweenLines15);
    //        paragraphProperties164.Append(paragraphMarkRunProperties159);

    //        var run132 = new Run();

    //        var runProperties132 = new RunProperties();
    //        var fontSize301 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript32 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties132.Append(fontSize301);
    //        runProperties132.Append(fontSizeComplexScript32);
    //        var text132 = new Text();
    //        text132.Text = _addressPostcode;

    //        run132.Append(runProperties132);
    //        run132.Append(text132);

    //        paragraph165.Append(paragraphProperties164);
    //        paragraph165.Append(run132);

    //        var paragraph166 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00115C0B", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties165 = new ParagraphProperties();
    //        var spacingBetweenLines16 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties160 = new ParagraphMarkRunProperties();
    //        var fontSize302 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript33 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties160.Append(fontSize302);
    //        paragraphMarkRunProperties160.Append(fontSizeComplexScript33);

    //        paragraphProperties165.Append(spacingBetweenLines16);
    //        paragraphProperties165.Append(paragraphMarkRunProperties160);

    //        paragraph166.Append(paragraphProperties165);

    //        var paragraph167 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties166 = new ParagraphProperties();
    //        var paragraphStyleId158 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties161 = new ParagraphMarkRunProperties();
    //        var fontSize303 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript34 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties161.Append(fontSize303);
    //        paragraphMarkRunProperties161.Append(fontSizeComplexScript34);

    //        paragraphProperties166.Append(paragraphStyleId158);
    //        paragraphProperties166.Append(paragraphMarkRunProperties161);

    //        paragraph167.Append(paragraphProperties166);

    //        var paragraph168 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties167 = new ParagraphProperties();
    //        var paragraphStyleId159 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties162 = new ParagraphMarkRunProperties();
    //        var fontSize304 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript35 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties162.Append(fontSize304);
    //        paragraphMarkRunProperties162.Append(fontSizeComplexScript35);

    //        paragraphProperties167.Append(paragraphStyleId159);
    //        paragraphProperties167.Append(paragraphMarkRunProperties162);

    //        paragraph168.Append(paragraphProperties167);

    //        tableCell102.Append(tableCellProperties102);
    //        tableCell102.Append(paragraph153);
    //        tableCell102.Append(paragraph154);
    //        tableCell102.Append(paragraph155);
    //        tableCell102.Append(paragraph156);
    //        tableCell102.Append(paragraph157);
    //        tableCell102.Append(paragraph158);
    //        tableCell102.Append(paragraph159);
    //        tableCell102.Append(paragraph160);
    //        tableCell102.Append(paragraph161);
    //        tableCell102.Append(paragraph162);
    //        tableCell102.Append(paragraph163);
    //        tableCell102.Append(paragraph164);
    //        tableCell102.Append(paragraph165);
    //        tableCell102.Append(paragraph166);
    //        tableCell102.Append(paragraph167);
    //        tableCell102.Append(paragraph168);

    //        var tableCell103 = new TableCell();

    //        var tableCellProperties103 = new TableCellProperties();
    //        var tableCellWidth103 = new TableCellWidth() { Width = "4306", Type = TableWidthUnitValues.Dxa };
    //        var gridSpan1 = new GridSpan() { Val = 2 };
    //        var verticalMerge2 = new VerticalMerge() { Val = MergedCellValues.Restart };
    //        var shading103 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties103.Append(tableCellWidth103);
    //        tableCellProperties103.Append(gridSpan1);
    //        tableCellProperties103.Append(verticalMerge2);
    //        tableCellProperties103.Append(shading103);

    //        var paragraph169 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties168 = new ParagraphProperties();
    //        var spacingBetweenLines17 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties163 = new ParagraphMarkRunProperties();
    //        var fontSize305 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript36 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties163.Append(fontSize305);
    //        paragraphMarkRunProperties163.Append(fontSizeComplexScript36);

    //        paragraphProperties168.Append(spacingBetweenLines17);
    //        paragraphProperties168.Append(paragraphMarkRunProperties163);

    //        paragraph169.Append(paragraphProperties168);

    //        var paragraph170 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties169 = new ParagraphProperties();
    //        var spacingBetweenLines18 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties164 = new ParagraphMarkRunProperties();
    //        var fontSize306 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript37 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties164.Append(fontSize306);
    //        paragraphMarkRunProperties164.Append(fontSizeComplexScript37);

    //        paragraphProperties169.Append(spacingBetweenLines18);
    //        paragraphProperties169.Append(paragraphMarkRunProperties164);

    //        var run133 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties133 = new RunProperties();
    //        var fontSize307 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript38 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties133.Append(fontSize307);
    //        runProperties133.Append(fontSizeComplexScript38);
    //        var text133 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text133.Text = "           ";

    //        run133.Append(runProperties133);
    //        run133.Append(text133);

    //        var run134 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties134 = new RunProperties();
    //        var fontSize308 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties134.Append(fontSize308);
    //        runProperties134.Append(fontSizeComplexScript39);
    //        var text134 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text134.Text = "                                   ";

    //        run134.Append(runProperties134);
    //        run134.Append(text134);

    //        var run135 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties135 = new RunProperties();
    //        var fontSize309 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties135.Append(fontSize309);
    //        runProperties135.Append(fontSizeComplexScript40);
    //        var text135 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text135.Text = "        ";

    //        run135.Append(runProperties135);
    //        run135.Append(text135);

    //        var run136 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties136 = new RunProperties();
    //        var fontSize310 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties136.Append(fontSize310);
    //        runProperties136.Append(fontSizeComplexScript41);
    //        var text136 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text136.Text = "           ";

    //        run136.Append(runProperties136);
    //        run136.Append(text136);

    //        var run137 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties137 = new RunProperties();
    //        var fontSize311 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript42 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties137.Append(fontSize311);
    //        runProperties137.Append(fontSizeComplexScript42);
    //        var text137 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text137.Text = " ";

    //        run137.Append(runProperties137);
    //        run137.Append(text137);

    //        paragraph170.Append(paragraphProperties169);
    //        paragraph170.Append(run133);
    //        paragraph170.Append(run134);
    //        paragraph170.Append(run135);
    //        paragraph170.Append(run136);
    //        paragraph170.Append(run137);

    //        tableCell103.Append(tableCellProperties103);
    //        tableCell103.Append(paragraph169);
    //        tableCell103.Append(paragraph170);

    //        var tableCell104 = new TableCell();

    //        var tableCellProperties104 = new TableCellProperties();
    //        var tableCellWidth104 = new TableCellWidth() { Width = "236", Type = TableWidthUnitValues.Dxa };
    //        var shading104 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties104.Append(tableCellWidth104);
    //        tableCellProperties104.Append(shading104);

    //        var paragraph171 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties170 = new ParagraphProperties();
    //        var spacingBetweenLines19 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties165 = new ParagraphMarkRunProperties();
    //        var fontSize312 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript43 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties165.Append(fontSize312);
    //        paragraphMarkRunProperties165.Append(fontSizeComplexScript43);

    //        paragraphProperties170.Append(spacingBetweenLines19);
    //        paragraphProperties170.Append(paragraphMarkRunProperties165);

    //        paragraph171.Append(paragraphProperties170);

    //        tableCell104.Append(tableCellProperties104);
    //        tableCell104.Append(paragraph171);

    //        tableRow30.Append(tableRowProperties1);
    //        tableRow30.Append(tableCell102);
    //        tableRow30.Append(tableCell103);
    //        tableRow30.Append(tableCell104);

    //        var tableRow31 = new TableRow() { RsidTableRowMarkRevision = "00000EA8", RsidTableRowAddition = "004E4E45", RsidTableRowProperties = "002110C8" };

    //        var tableRowProperties2 = new TableRowProperties();
    //        var tableRowHeight2 = new TableRowHeight() { Val = (UInt32Value)131U };

    //        tableRowProperties2.Append(tableRowHeight2);

    //        var tableCell105 = new TableCell();

    //        var tableCellProperties105 = new TableCellProperties();
    //        var tableCellWidth105 = new TableCellWidth() { Width = "3882", Type = TableWidthUnitValues.Dxa };
    //        var verticalMerge3 = new VerticalMerge();
    //        var shading105 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties105.Append(tableCellWidth105);
    //        tableCellProperties105.Append(verticalMerge3);
    //        tableCellProperties105.Append(shading105);

    //        var paragraph172 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties171 = new ParagraphProperties();
    //        var spacingBetweenLines20 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties166 = new ParagraphMarkRunProperties();
    //        var runFonts290 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize313 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript44 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties166.Append(runFonts290);
    //        paragraphMarkRunProperties166.Append(fontSize313);
    //        paragraphMarkRunProperties166.Append(fontSizeComplexScript44);

    //        paragraphProperties171.Append(spacingBetweenLines20);
    //        paragraphProperties171.Append(paragraphMarkRunProperties166);

    //        paragraph172.Append(paragraphProperties171);

    //        tableCell105.Append(tableCellProperties105);
    //        tableCell105.Append(paragraph172);

    //        var tableCell106 = new TableCell();

    //        var tableCellProperties106 = new TableCellProperties();
    //        var tableCellWidth106 = new TableCellWidth() { Width = "4306", Type = TableWidthUnitValues.Dxa };
    //        var gridSpan2 = new GridSpan() { Val = 2 };
    //        var verticalMerge4 = new VerticalMerge();
    //        var shading106 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties106.Append(tableCellWidth106);
    //        tableCellProperties106.Append(gridSpan2);
    //        tableCellProperties106.Append(verticalMerge4);
    //        tableCellProperties106.Append(shading106);

    //        var paragraph173 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties172 = new ParagraphProperties();
    //        var spacingBetweenLines21 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties167 = new ParagraphMarkRunProperties();
    //        var runFonts291 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize314 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript45 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties167.Append(runFonts291);
    //        paragraphMarkRunProperties167.Append(fontSize314);
    //        paragraphMarkRunProperties167.Append(fontSizeComplexScript45);

    //        paragraphProperties172.Append(spacingBetweenLines21);
    //        paragraphProperties172.Append(paragraphMarkRunProperties167);

    //        paragraph173.Append(paragraphProperties172);

    //        tableCell106.Append(tableCellProperties106);
    //        tableCell106.Append(paragraph173);

    //        var tableCell107 = new TableCell();

    //        var tableCellProperties107 = new TableCellProperties();
    //        var tableCellWidth107 = new TableCellWidth() { Width = "2570", Type = TableWidthUnitValues.Dxa };
    //        var gridSpan3 = new GridSpan() { Val = 2 };
    //        var shading107 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties107.Append(tableCellWidth107);
    //        tableCellProperties107.Append(gridSpan3);
    //        tableCellProperties107.Append(shading107);

    //        var paragraph174 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "009F0F7D", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties173 = new ParagraphProperties();
    //        var spacingBetweenLines22 = new SpacingBetweenLines() { After = "0" };

    //        var paragraphMarkRunProperties168 = new ParagraphMarkRunProperties();
    //        var runFonts292 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize315 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript46 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties168.Append(runFonts292);
    //        paragraphMarkRunProperties168.Append(fontSize315);
    //        paragraphMarkRunProperties168.Append(fontSizeComplexScript46);

    //        paragraphProperties173.Append(spacingBetweenLines22);
    //        paragraphProperties173.Append(paragraphMarkRunProperties168);

    //        var run138 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties138 = new RunProperties();
    //        var runFonts293 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize316 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript47 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties138.Append(runFonts293);
    //        runProperties138.Append(fontSize316);
    //        runProperties138.Append(fontSizeComplexScript47);
    //        var text138 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text138.Text = "                                              ";

    //        run138.Append(runProperties138);
    //        run138.Append(text138);

    //        var run139 = new Run();

    //        var runProperties139 = new RunProperties();
    //        var runFonts294 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize317 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript48 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties139.Append(runFonts294);
    //        runProperties139.Append(fontSize317);
    //        runProperties139.Append(fontSizeComplexScript48);
    //        var text139 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text139.Text = "                             ";

    //        run139.Append(runProperties139);
    //        run139.Append(text139);

    //        var run140 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties140 = new RunProperties();
    //        var runFonts295 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize318 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript49 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties140.Append(runFonts295);
    //        runProperties140.Append(fontSize318);
    //        runProperties140.Append(fontSizeComplexScript49);
    //        var text140 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text140.Text = " ";

    //        run140.Append(runProperties140);
    //        run140.Append(text140);
    //        var bookmarkStart3 = new BookmarkStart() { Name = "bkLogo", Id = "2" };
    //        var bookmarkEnd3 = new BookmarkEnd() { Id = "2" };

    //        var run141 = new Run();

    //        var runProperties141 = new RunProperties();
    //        var runFonts296 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var noProof1 = new NoProof();
    //        var fontSize319 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript50 = new FontSizeComplexScript() { Val = "24" };
    //        var languages3 = new Languages() { EastAsia = "en-GB" };

    //        runProperties141.Append(runFonts296);
    //        runProperties141.Append(noProof1);
    //        runProperties141.Append(fontSize319);
    //        runProperties141.Append(fontSizeComplexScript50);
    //        runProperties141.Append(languages3);

    //        var drawing1 = new Drawing();

    //        var inline1 = new Wp.Inline() { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U };
    //        var extent1 = new Wp.Extent() { Cx = 1143000L, Cy = 952500L };
    //        var effectExtent1 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L };
    //        var docProperties1 = new Wp.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1", Description = "incommunitiesLogo" };

    //        var nonVisualGraphicFrameDrawingProperties1 = new Wp.NonVisualGraphicFrameDrawingProperties();

    //        var graphicFrameLocks1 = new A.GraphicFrameLocks() { NoChangeAspect = true };
    //        graphicFrameLocks1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

    //        nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

    //        var graphic1 = new A.Graphic();
    //        graphic1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

    //        var graphicData1 = new A.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" };

    //        var picture1 = new Pic.Picture();
    //        picture1.AddNamespaceDeclaration("pic", "http://schemas.openxmlformats.org/drawingml/2006/picture");

    //        var nonVisualPictureProperties1 = new Pic.NonVisualPictureProperties();
    //        var nonVisualDrawingProperties1 = new Pic.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "Picture 1", Description = "incommunitiesLogo" };

    //        var nonVisualPictureDrawingProperties1 = new Pic.NonVisualPictureDrawingProperties();
    //        var pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true, NoChangeArrowheads = true };

    //        nonVisualPictureDrawingProperties1.Append(pictureLocks1);

    //        nonVisualPictureProperties1.Append(nonVisualDrawingProperties1);
    //        nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);

    //        var blipFill1 = new Pic.BlipFill();

    //        var blip1 = new A.Blip() { Embed = "rId1" };

    //        var blipExtensionList1 = new A.BlipExtensionList();

    //        var blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };

    //        var useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
    //        useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

    //        blipExtension1.Append(useLocalDpi1);

    //        blipExtensionList1.Append(blipExtension1);

    //        blip1.Append(blipExtensionList1);
    //        var sourceRectangle1 = new A.SourceRectangle();

    //        var stretch1 = new A.Stretch();
    //        var fillRectangle1 = new A.FillRectangle();

    //        stretch1.Append(fillRectangle1);

    //        blipFill1.Append(blip1);
    //        blipFill1.Append(sourceRectangle1);
    //        blipFill1.Append(stretch1);

    //        var shapeProperties1 = new Pic.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

    //        var transform2D1 = new A.Transform2D();
    //        var offset1 = new A.Offset() { X = 0L, Y = 0L };
    //        var extents1 = new A.Extents() { Cx = 1143000L, Cy = 952500L };

    //        transform2D1.Append(offset1);
    //        transform2D1.Append(extents1);

    //        var presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
    //        var adjustValueList1 = new A.AdjustValueList();

    //        presetGeometry1.Append(adjustValueList1);
    //        var noFill1 = new A.NoFill();

    //        var outline4 = new A.Outline();
    //        var noFill2 = new A.NoFill();

    //        outline4.Append(noFill2);

    //        shapeProperties1.Append(transform2D1);
    //        shapeProperties1.Append(presetGeometry1);
    //        shapeProperties1.Append(noFill1);
    //        shapeProperties1.Append(outline4);

    //        picture1.Append(nonVisualPictureProperties1);
    //        picture1.Append(blipFill1);
    //        picture1.Append(shapeProperties1);

    //        graphicData1.Append(picture1);

    //        graphic1.Append(graphicData1);

    //        inline1.Append(extent1);
    //        inline1.Append(effectExtent1);
    //        inline1.Append(docProperties1);
    //        inline1.Append(nonVisualGraphicFrameDrawingProperties1);
    //        inline1.Append(graphic1);

    //        drawing1.Append(inline1);

    //        run141.Append(runProperties141);
    //        run141.Append(drawing1);

    //        paragraph174.Append(paragraphProperties173);
    //        paragraph174.Append(run138);
    //        paragraph174.Append(run139);
    //        paragraph174.Append(run140);
    //        paragraph174.Append(bookmarkStart3);
    //        paragraph174.Append(bookmarkEnd3);
    //        paragraph174.Append(run141);

    //        var paragraph175 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "009F0F7D", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties174 = new ParagraphProperties();
    //        var spacingBetweenLines23 = new SpacingBetweenLines() { After = "0" };
    //        var justification80 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties169 = new ParagraphMarkRunProperties();
    //        var runFonts297 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize320 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript51 = new FontSizeComplexScript() { Val = "24" };
    //        var shading108 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        paragraphMarkRunProperties169.Append(runFonts297);
    //        paragraphMarkRunProperties169.Append(fontSize320);
    //        paragraphMarkRunProperties169.Append(fontSizeComplexScript51);
    //        paragraphMarkRunProperties169.Append(shading108);

    //        paragraphProperties174.Append(spacingBetweenLines23);
    //        paragraphProperties174.Append(justification80);
    //        paragraphProperties174.Append(paragraphMarkRunProperties169);

    //        paragraph175.Append(paragraphProperties174);

    //        var paragraph176 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "002F713A", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties175 = new ParagraphProperties();
    //        var spacingBetweenLines24 = new SpacingBetweenLines() { After = "0" };
    //        var justification81 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties170 = new ParagraphMarkRunProperties();
    //        var runFonts298 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize321 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript52 = new FontSizeComplexScript() { Val = "24" };
    //        var shading109 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        paragraphMarkRunProperties170.Append(runFonts298);
    //        paragraphMarkRunProperties170.Append(fontSize321);
    //        paragraphMarkRunProperties170.Append(fontSizeComplexScript52);
    //        paragraphMarkRunProperties170.Append(shading109);

    //        paragraphProperties175.Append(spacingBetweenLines24);
    //        paragraphProperties175.Append(justification81);
    //        paragraphProperties175.Append(paragraphMarkRunProperties170);
    //        var bookmarkStart4 = new BookmarkStart() { Name = "bkAddressHeader", Id = "3" };
    //        var bookmarkEnd4 = new BookmarkEnd() { Id = "3" };

    //        var run142 = new Run();

    //        var runProperties142 = new RunProperties();
    //        var runFonts299 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize322 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript53 = new FontSizeComplexScript() { Val = "24" };
    //        var shading110 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties142.Append(runFonts299);
    //        runProperties142.Append(fontSize322);
    //        runProperties142.Append(fontSizeComplexScript53);
    //        runProperties142.Append(shading110);
    //        var text141 = new Text();
    //        text141.Text = "Incomm";

    //        run142.Append(runProperties142);
    //        run142.Append(text141);

    //        var run143 = new Run();

    //        var runProperties143 = new RunProperties();
    //        var runFonts300 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize323 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript54 = new FontSizeComplexScript() { Val = "24" };
    //        var shading111 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties143.Append(runFonts300);
    //        runProperties143.Append(fontSize323);
    //        runProperties143.Append(fontSizeComplexScript54);
    //        runProperties143.Append(shading111);
    //        var text142 = new Text();
    //        text142.Text = "unities Group Ltd";

    //        run143.Append(runProperties143);
    //        run143.Append(text142);

    //        paragraph176.Append(paragraphProperties175);
    //        paragraph176.Append(bookmarkStart4);
    //        paragraph176.Append(bookmarkEnd4);
    //        paragraph176.Append(run142);
    //        paragraph176.Append(run143);

    //        var paragraph177 = new Paragraph() { RsidParagraphAddition = "00515C7D", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties176 = new ParagraphProperties();
    //        var spacingBetweenLines25 = new SpacingBetweenLines() { After = "0" };
    //        var justification82 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties171 = new ParagraphMarkRunProperties();
    //        var runFonts301 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize324 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript55 = new FontSizeComplexScript() { Val = "24" };
    //        var shading112 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        paragraphMarkRunProperties171.Append(runFonts301);
    //        paragraphMarkRunProperties171.Append(fontSize324);
    //        paragraphMarkRunProperties171.Append(fontSizeComplexScript55);
    //        paragraphMarkRunProperties171.Append(shading112);

    //        paragraphProperties176.Append(spacingBetweenLines25);
    //        paragraphProperties176.Append(justification82);
    //        paragraphProperties176.Append(paragraphMarkRunProperties171);
    //        var bookmarkStart5 = new BookmarkStart() { Name = "bkAddress1", Id = "4" };
    //        var bookmarkEnd5 = new BookmarkEnd() { Id = "4" };

    //        var run144 = new Run();

    //        var runProperties144 = new RunProperties();
    //        var runFonts302 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize325 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript56 = new FontSizeComplexScript() { Val = "24" };
    //        var shading113 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties144.Append(runFonts302);
    //        runProperties144.Append(fontSize325);
    //        runProperties144.Append(fontSizeComplexScript56);
    //        runProperties144.Append(shading113);
    //        var text143 = new Text();
    //        text143.Text = "The Quays";

    //        run144.Append(runProperties144);
    //        run144.Append(text143);

    //        paragraph177.Append(paragraphProperties176);
    //        paragraph177.Append(bookmarkStart5);
    //        paragraph177.Append(bookmarkEnd5);
    //        paragraph177.Append(run144);

    //        var paragraph178 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "001063D7", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties177 = new ParagraphProperties();
    //        var spacingBetweenLines26 = new SpacingBetweenLines() { After = "0" };
    //        var justification83 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties172 = new ParagraphMarkRunProperties();
    //        var runFonts303 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize326 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript57 = new FontSizeComplexScript() { Val = "24" };
    //        var shading114 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        paragraphMarkRunProperties172.Append(runFonts303);
    //        paragraphMarkRunProperties172.Append(fontSize326);
    //        paragraphMarkRunProperties172.Append(fontSizeComplexScript57);
    //        paragraphMarkRunProperties172.Append(shading114);

    //        paragraphProperties177.Append(spacingBetweenLines26);
    //        paragraphProperties177.Append(justification83);
    //        paragraphProperties177.Append(paragraphMarkRunProperties172);
    //        var bookmarkStart6 = new BookmarkStart() { Name = "bkAddress2", Id = "5" };
    //        var bookmarkEnd6 = new BookmarkEnd() { Id = "5" };

    //        var run145 = new Run();

    //        var runProperties145 = new RunProperties();
    //        var runFonts304 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize327 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript58 = new FontSizeComplexScript() { Val = "24" };
    //        var shading115 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties145.Append(runFonts304);
    //        runProperties145.Append(fontSize327);
    //        runProperties145.Append(fontSizeComplexScript58);
    //        runProperties145.Append(shading115);
    //        var text144 = new Text();
    //        text144.Text = "Victoria Street";

    //        run145.Append(runProperties145);
    //        run145.Append(text144);

    //        var run146 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties146 = new RunProperties();
    //        var runFonts305 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize328 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript59 = new FontSizeComplexScript() { Val = "24" };
    //        var shading116 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties146.Append(runFonts305);
    //        runProperties146.Append(fontSize328);
    //        runProperties146.Append(fontSizeComplexScript59);
    //        runProperties146.Append(shading116);
    //        var text145 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text145.Text = " ";

    //        run146.Append(runProperties146);
    //        run146.Append(text145);

    //        paragraph178.Append(paragraphProperties177);
    //        paragraph178.Append(bookmarkStart6);
    //        paragraph178.Append(bookmarkEnd6);
    //        paragraph178.Append(run145);
    //        paragraph178.Append(run146);

    //        var paragraph179 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "001063D7", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties178 = new ParagraphProperties();
    //        var spacingBetweenLines27 = new SpacingBetweenLines() { After = "0" };
    //        var justification84 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties173 = new ParagraphMarkRunProperties();
    //        var runFonts306 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize329 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript60 = new FontSizeComplexScript() { Val = "24" };
    //        var shading117 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        paragraphMarkRunProperties173.Append(runFonts306);
    //        paragraphMarkRunProperties173.Append(fontSize329);
    //        paragraphMarkRunProperties173.Append(fontSizeComplexScript60);
    //        paragraphMarkRunProperties173.Append(shading117);

    //        paragraphProperties178.Append(spacingBetweenLines27);
    //        paragraphProperties178.Append(justification84);
    //        paragraphProperties178.Append(paragraphMarkRunProperties173);
    //        var bookmarkStart7 = new BookmarkStart() { Name = "bkAddress3", Id = "6" };
    //        var bookmarkEnd7 = new BookmarkEnd() { Id = "6" };

    //        var run147 = new Run();

    //        var runProperties147 = new RunProperties();
    //        var runFonts307 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize330 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript61 = new FontSizeComplexScript() { Val = "24" };
    //        var shading118 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties147.Append(runFonts307);
    //        runProperties147.Append(fontSize330);
    //        runProperties147.Append(fontSizeComplexScript61);
    //        runProperties147.Append(shading118);
    //        var text146 = new Text();
    //        text146.Text = "Shipley";

    //        run147.Append(runProperties147);
    //        run147.Append(text146);

    //        var run148 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties148 = new RunProperties();
    //        var runFonts308 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize331 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript62 = new FontSizeComplexScript() { Val = "24" };
    //        var shading119 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "FFFFFF" };

    //        runProperties148.Append(runFonts308);
    //        runProperties148.Append(fontSize331);
    //        runProperties148.Append(fontSizeComplexScript62);
    //        runProperties148.Append(shading119);
    //        var text147 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text147.Text = " ";

    //        run148.Append(runProperties148);
    //        run148.Append(text147);

    //        paragraph179.Append(paragraphProperties178);
    //        paragraph179.Append(bookmarkStart7);
    //        paragraph179.Append(bookmarkEnd7);
    //        paragraph179.Append(run147);
    //        paragraph179.Append(run148);

    //        var paragraph180 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "001063D7", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties179 = new ParagraphProperties();
    //        var spacingBetweenLines28 = new SpacingBetweenLines() { After = "0" };
    //        var justification85 = new Justification() { Val = JustificationValues.Right };

    //        var paragraphMarkRunProperties174 = new ParagraphMarkRunProperties();
    //        var runFonts309 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize332 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript63 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties174.Append(runFonts309);
    //        paragraphMarkRunProperties174.Append(fontSize332);
    //        paragraphMarkRunProperties174.Append(fontSizeComplexScript63);

    //        paragraphProperties179.Append(spacingBetweenLines28);
    //        paragraphProperties179.Append(justification85);
    //        paragraphProperties179.Append(paragraphMarkRunProperties174);
    //        var bookmarkStart8 = new BookmarkStart() { Name = "bkAddressPostcode", Id = "7" };
    //        var bookmarkEnd8 = new BookmarkEnd() { Id = "7" };

    //        var run149 = new Run();

    //        var runProperties149 = new RunProperties();
    //        var runFonts310 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize333 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript64 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties149.Append(runFonts310);
    //        runProperties149.Append(fontSize333);
    //        runProperties149.Append(fontSizeComplexScript64);
    //        var text148 = new Text();
    //        text148.Text = "BD17 7BN";

    //        run149.Append(runProperties149);
    //        run149.Append(text148);

    //        paragraph180.Append(paragraphProperties179);
    //        paragraph180.Append(bookmarkStart8);
    //        paragraph180.Append(bookmarkEnd8);
    //        paragraph180.Append(run149);

    //        tableCell107.Append(tableCellProperties107);
    //        tableCell107.Append(paragraph174);
    //        tableCell107.Append(paragraph175);
    //        tableCell107.Append(paragraph176);
    //        tableCell107.Append(paragraph177);
    //        tableCell107.Append(paragraph178);
    //        tableCell107.Append(paragraph179);
    //        tableCell107.Append(paragraph180);

    //        tableRow31.Append(tableRowProperties2);
    //        tableRow31.Append(tableCell105);
    //        tableRow31.Append(tableCell106);
    //        tableRow31.Append(tableCell107);

    //        var tableRow32 = new TableRow() { RsidTableRowMarkRevision = "00000EA8", RsidTableRowAddition = "004E4E45", RsidTableRowProperties = "002110C8" };

    //        var tableRowProperties3 = new TableRowProperties();
    //        var tableRowHeight3 = new TableRowHeight() { Val = (UInt32Value)122U };

    //        tableRowProperties3.Append(tableRowHeight3);

    //        var tableCell108 = new TableCell();

    //        var tableCellProperties108 = new TableCellProperties();
    //        var tableCellWidth108 = new TableCellWidth() { Width = "3882", Type = TableWidthUnitValues.Dxa };
    //        var shading120 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties108.Append(tableCellWidth108);
    //        tableCellProperties108.Append(shading120);

    //        var paragraph181 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties180 = new ParagraphProperties();
    //        var paragraphStyleId160 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties175 = new ParagraphMarkRunProperties();
    //        var runFonts311 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize334 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript65 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties175.Append(runFonts311);
    //        paragraphMarkRunProperties175.Append(fontSize334);
    //        paragraphMarkRunProperties175.Append(fontSizeComplexScript65);

    //        paragraphProperties180.Append(paragraphStyleId160);
    //        paragraphProperties180.Append(paragraphMarkRunProperties175);

    //        paragraph181.Append(paragraphProperties180);

    //        var paragraph182 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties181 = new ParagraphProperties();
    //        var paragraphStyleId161 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties176 = new ParagraphMarkRunProperties();
    //        var runFonts312 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize335 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript66 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties176.Append(runFonts312);
    //        paragraphMarkRunProperties176.Append(fontSize335);
    //        paragraphMarkRunProperties176.Append(fontSizeComplexScript66);

    //        paragraphProperties181.Append(paragraphStyleId161);
    //        paragraphProperties181.Append(paragraphMarkRunProperties176);

    //        paragraph182.Append(paragraphProperties181);

    //        var paragraph183 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties182 = new ParagraphProperties();
    //        var paragraphStyleId162 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties177 = new ParagraphMarkRunProperties();
    //        var runFonts313 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize336 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript67 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties177.Append(runFonts313);
    //        paragraphMarkRunProperties177.Append(fontSize336);
    //        paragraphMarkRunProperties177.Append(fontSizeComplexScript67);

    //        paragraphProperties182.Append(paragraphStyleId162);
    //        paragraphProperties182.Append(paragraphMarkRunProperties177);
    //        var bookmarkStart9 = new BookmarkStart() { Name = "bkDate", Id = "8" };
    //        var bookmarkEnd9 = new BookmarkEnd() { Id = "8" };

    //        var run150 = new Run();

    //        var runProperties150 = new RunProperties();
    //        var runFonts314 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize337 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript68 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties150.Append(runFonts314);
    //        runProperties150.Append(fontSize337);
    //        runProperties150.Append(fontSizeComplexScript68);
    //        var text149 = new Text();
    //        text149.Text = System.DateTime.Now.ToShortDateString();//Edited "22/06/2016";

    //        run150.Append(runProperties150);
    //        run150.Append(text149);

    //        paragraph183.Append(paragraphProperties182);
    //        paragraph183.Append(bookmarkStart9);
    //        paragraph183.Append(bookmarkEnd9);
    //        paragraph183.Append(run150);

    //        tableCell108.Append(tableCellProperties108);
    //        tableCell108.Append(paragraph181);
    //        tableCell108.Append(paragraph182);
    //        tableCell108.Append(paragraph183);

    //        var tableCell109 = new TableCell();

    //        var tableCellProperties109 = new TableCellProperties();
    //        var tableCellWidth109 = new TableCellWidth() { Width = "1329", Type = TableWidthUnitValues.Dxa };
    //        var shading121 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties109.Append(tableCellWidth109);
    //        tableCellProperties109.Append(shading121);

    //        var paragraph184 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties183 = new ParagraphProperties();
    //        var paragraphStyleId163 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties178 = new ParagraphMarkRunProperties();
    //        var runFonts315 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize338 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript69 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties178.Append(runFonts315);
    //        paragraphMarkRunProperties178.Append(fontSize338);
    //        paragraphMarkRunProperties178.Append(fontSizeComplexScript69);

    //        paragraphProperties183.Append(paragraphStyleId163);
    //        paragraphProperties183.Append(paragraphMarkRunProperties178);

    //        paragraph184.Append(paragraphProperties183);

    //        tableCell109.Append(tableCellProperties109);
    //        tableCell109.Append(paragraph184);

    //        var tableCell110 = new TableCell();

    //        var tableCellProperties110 = new TableCellProperties();
    //        var tableCellWidth110 = new TableCellWidth() { Width = "5547", Type = TableWidthUnitValues.Dxa };
    //        var gridSpan4 = new GridSpan() { Val = 3 };
    //        var shading122 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties110.Append(tableCellWidth110);
    //        tableCellProperties110.Append(gridSpan4);
    //        tableCellProperties110.Append(shading122);

    //        var paragraph185 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties184 = new ParagraphProperties();
    //        var paragraphStyleId164 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties179 = new ParagraphMarkRunProperties();
    //        var runFonts316 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize339 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript70 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties179.Append(runFonts316);
    //        paragraphMarkRunProperties179.Append(fontSize339);
    //        paragraphMarkRunProperties179.Append(fontSizeComplexScript70);

    //        paragraphProperties184.Append(paragraphStyleId164);
    //        paragraphProperties184.Append(paragraphMarkRunProperties179);

    //        var run151 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties151 = new RunProperties();
    //        var runFonts317 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var bold73 = new Bold();
    //        var fontSize340 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript71 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties151.Append(runFonts317);
    //        runProperties151.Append(bold73);
    //        runProperties151.Append(fontSize340);
    //        runProperties151.Append(fontSizeComplexScript71);
    //        var text150 = new Text();
    //        text150.Text = "Tel";

    //        run151.Append(runProperties151);
    //        run151.Append(text150);

    //        var run152 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties152 = new RunProperties();
    //        var runFonts318 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize341 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript72 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties152.Append(runFonts318);
    //        runProperties152.Append(fontSize341);
    //        runProperties152.Append(fontSizeComplexScript72);
    //        var text151 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text151.Text = ":  ";

    //        run152.Append(runProperties152);
    //        run152.Append(text151);
    //        var bookmarkStart10 = new BookmarkStart() { Name = "bkTelephone", Id = "9" };
    //        var bookmarkEnd10 = new BookmarkEnd() { Id = "9" };

    //        var run153 = new Run();

    //        var runProperties153 = new RunProperties();
    //        var runFonts319 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize342 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript73 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties153.Append(runFonts319);
    //        runProperties153.Append(fontSize342);
    //        runProperties153.Append(fontSizeComplexScript73);
    //        var text152 = new Text();
    //        text152.Text = "01274 257777";

    //        run153.Append(runProperties153);
    //        run153.Append(text152);

    //        paragraph185.Append(paragraphProperties184);
    //        paragraph185.Append(run151);
    //        paragraph185.Append(run152);
    //        paragraph185.Append(bookmarkStart10);
    //        paragraph185.Append(bookmarkEnd10);
    //        paragraph185.Append(run153);

    //        var paragraph186 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidParagraphProperties = "00433F1A", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties185 = new ParagraphProperties();
    //        var paragraphStyleId165 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties180 = new ParagraphMarkRunProperties();
    //        var runFonts320 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize343 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript74 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties180.Append(runFonts320);
    //        paragraphMarkRunProperties180.Append(fontSize343);
    //        paragraphMarkRunProperties180.Append(fontSizeComplexScript74);

    //        paragraphProperties185.Append(paragraphStyleId165);
    //        paragraphProperties185.Append(paragraphMarkRunProperties180);

    //        var run154 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties154 = new RunProperties();
    //        var runFonts321 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var bold74 = new Bold();
    //        var fontSize344 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript75 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties154.Append(runFonts321);
    //        runProperties154.Append(bold74);
    //        runProperties154.Append(fontSize344);
    //        runProperties154.Append(fontSizeComplexScript75);
    //        var text153 = new Text();
    //        text153.Text = "Email";

    //        run154.Append(runProperties154);
    //        run154.Append(text153);

    //        var run155 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties155 = new RunProperties();
    //        var runFonts322 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize345 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript76 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties155.Append(runFonts322);
    //        runProperties155.Append(fontSize345);
    //        runProperties155.Append(fontSizeComplexScript76);
    //        var text154 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text154.Text = ": ";

    //        run155.Append(runProperties155);
    //        run155.Append(text154);
    //        var bookmarkStart11 = new BookmarkStart() { Name = "bkEmail", Id = "10" };
    //        var bookmarkEnd11 = new BookmarkEnd() { Id = "10" };

    //        var run156 = new Run();

    //        var runProperties156 = new RunProperties();
    //        var runFonts323 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize346 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript77 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties156.Append(runFonts323);
    //        runProperties156.Append(fontSize346);
    //        runProperties156.Append(fontSizeComplexScript77);
    //        var text155 = new Text();
    //        text155.Text = "enquiry@incommunities.co.uk";

    //        run156.Append(runProperties156);
    //        run156.Append(text155);

    //        var run157 = new Run();

    //        var runProperties157 = new RunProperties();
    //        var runFonts324 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize347 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript78 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties157.Append(runFonts324);
    //        runProperties157.Append(fontSize347);
    //        runProperties157.Append(fontSizeComplexScript78);
    //        var text156 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text156.Text = "   ";

    //        run157.Append(runProperties157);
    //        run157.Append(text156);

    //        paragraph186.Append(paragraphProperties185);
    //        paragraph186.Append(run154);
    //        paragraph186.Append(run155);
    //        paragraph186.Append(bookmarkStart11);
    //        paragraph186.Append(bookmarkEnd11);
    //        paragraph186.Append(run156);
    //        paragraph186.Append(run157);

    //        var paragraph187 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00876E56", RsidParagraphProperties = "002110C8", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties186 = new ParagraphProperties();
    //        var paragraphStyleId166 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties181 = new ParagraphMarkRunProperties();
    //        var runFonts325 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize348 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript79 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties181.Append(runFonts325);
    //        paragraphMarkRunProperties181.Append(fontSize348);
    //        paragraphMarkRunProperties181.Append(fontSizeComplexScript79);

    //        paragraphProperties186.Append(paragraphStyleId166);
    //        paragraphProperties186.Append(paragraphMarkRunProperties181);

    //        var run158 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties158 = new RunProperties();
    //        var runFonts326 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var bold75 = new Bold();
    //        var fontSize349 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript80 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties158.Append(runFonts326);
    //        runProperties158.Append(bold75);
    //        runProperties158.Append(fontSize349);
    //        runProperties158.Append(fontSizeComplexScript80);
    //        var text157 = new Text();
    //        text157.Text = "Application Ref";

    //        run158.Append(runProperties158);
    //        run158.Append(text157);

    //        var run159 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties159 = new RunProperties();
    //        var runFonts327 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize350 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript81 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties159.Append(runFonts327);
    //        runProperties159.Append(fontSize350);
    //        runProperties159.Append(fontSizeComplexScript81);
    //        var text158 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text158.Text = ": ";

    //        run159.Append(runProperties159);
    //        run159.Append(text158);
    //        var bookmarkStart12 = new BookmarkStart() { Name = "bkCustomerApplicationID", Id = "11" };
    //        var bookmarkEnd12 = new BookmarkEnd() { Id = "11" };

    //        var run160 = new Run();

    //        var runProperties160 = new RunProperties();
    //        var runFonts328 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize351 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript82 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties160.Append(runFonts328);
    //        runProperties160.Append(fontSize351);
    //        runProperties160.Append(fontSizeComplexScript82);
    //        var text159 = new Text();
    //        text159.Text = _vblApplication.ApplicationId.ToString();//"16910";

    //        run160.Append(runProperties160);
    //        run160.Append(text159);

    //        var run161 = new Run() { RsidRunProperties = "00000EA8" };

    //        var runProperties161 = new RunProperties();
    //        var runFonts329 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize352 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript83 = new FontSizeComplexScript() { Val = "24" };

    //        runProperties161.Append(runFonts329);
    //        runProperties161.Append(fontSize352);
    //        runProperties161.Append(fontSizeComplexScript83);
    //        var text160 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    //        text160.Text = " ";

    //        run161.Append(runProperties161);
    //        run161.Append(text160);

    //        paragraph187.Append(paragraphProperties186);
    //        paragraph187.Append(run158);
    //        paragraph187.Append(run159);
    //        paragraph187.Append(bookmarkStart12);
    //        paragraph187.Append(bookmarkEnd12);
    //        paragraph187.Append(run160);
    //        paragraph187.Append(run161);

    //        tableCell110.Append(tableCellProperties110);
    //        tableCell110.Append(paragraph185);
    //        tableCell110.Append(paragraph186);
    //        tableCell110.Append(paragraph187);

    //        tableRow32.Append(tableRowProperties3);
    //        tableRow32.Append(tableCell108);
    //        tableRow32.Append(tableCell109);
    //        tableRow32.Append(tableCell110);

    //        var tableRow33 = new TableRow() { RsidTableRowMarkRevision = "00000EA8", RsidTableRowAddition = "00433F1A", RsidTableRowProperties = "002110C8" };

    //        var tableRowProperties4 = new TableRowProperties();
    //        var tableRowHeight4 = new TableRowHeight() { Val = (UInt32Value)122U };

    //        tableRowProperties4.Append(tableRowHeight4);

    //        var tableCell111 = new TableCell();

    //        var tableCellProperties111 = new TableCellProperties();
    //        var tableCellWidth111 = new TableCellWidth() { Width = "3882", Type = TableWidthUnitValues.Dxa };
    //        var shading123 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties111.Append(tableCellWidth111);
    //        tableCellProperties111.Append(shading123);

    //        var paragraph188 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00433F1A", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties187 = new ParagraphProperties();
    //        var paragraphStyleId167 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties182 = new ParagraphMarkRunProperties();
    //        var runFonts330 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize353 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript84 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties182.Append(runFonts330);
    //        paragraphMarkRunProperties182.Append(fontSize353);
    //        paragraphMarkRunProperties182.Append(fontSizeComplexScript84);

    //        paragraphProperties187.Append(paragraphStyleId167);
    //        paragraphProperties187.Append(paragraphMarkRunProperties182);

    //        paragraph188.Append(paragraphProperties187);

    //        tableCell111.Append(tableCellProperties111);
    //        tableCell111.Append(paragraph188);

    //        var tableCell112 = new TableCell();

    //        var tableCellProperties112 = new TableCellProperties();
    //        var tableCellWidth112 = new TableCellWidth() { Width = "1329", Type = TableWidthUnitValues.Dxa };
    //        var shading124 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties112.Append(tableCellWidth112);
    //        tableCellProperties112.Append(shading124);

    //        var paragraph189 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00433F1A", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties188 = new ParagraphProperties();
    //        var paragraphStyleId168 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties183 = new ParagraphMarkRunProperties();
    //        var runFonts331 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize354 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript85 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties183.Append(runFonts331);
    //        paragraphMarkRunProperties183.Append(fontSize354);
    //        paragraphMarkRunProperties183.Append(fontSizeComplexScript85);

    //        paragraphProperties188.Append(paragraphStyleId168);
    //        paragraphProperties188.Append(paragraphMarkRunProperties183);

    //        paragraph189.Append(paragraphProperties188);

    //        tableCell112.Append(tableCellProperties112);
    //        tableCell112.Append(paragraph189);

    //        var tableCell113 = new TableCell();

    //        var tableCellProperties113 = new TableCellProperties();
    //        var tableCellWidth113 = new TableCellWidth() { Width = "5547", Type = TableWidthUnitValues.Dxa };
    //        var gridSpan5 = new GridSpan() { Val = 3 };
    //        var shading125 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

    //        tableCellProperties113.Append(tableCellWidth113);
    //        tableCellProperties113.Append(gridSpan5);
    //        tableCellProperties113.Append(shading125);

    //        var paragraph190 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "00433F1A", RsidParagraphProperties = "00B166DD", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties189 = new ParagraphProperties();
    //        var paragraphStyleId169 = new ParagraphStyleId() { Val = "NoSpacing" };

    //        var paragraphMarkRunProperties184 = new ParagraphMarkRunProperties();
    //        var runFonts332 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize355 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript86 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties184.Append(runFonts332);
    //        paragraphMarkRunProperties184.Append(fontSize355);
    //        paragraphMarkRunProperties184.Append(fontSizeComplexScript86);

    //        paragraphProperties189.Append(paragraphStyleId169);
    //        paragraphProperties189.Append(paragraphMarkRunProperties184);

    //        paragraph190.Append(paragraphProperties189);

    //        tableCell113.Append(tableCellProperties113);
    //        tableCell113.Append(paragraph190);

    //        tableRow33.Append(tableRowProperties4);
    //        tableRow33.Append(tableCell111);
    //        tableRow33.Append(tableCell112);
    //        tableRow33.Append(tableCell113);

    //        table9.Append(tableProperties9);
    //        table9.Append(tableGrid9);
    //        table9.Append(tableRow30);
    //        table9.Append(tableRow31);
    //        table9.Append(tableRow32);
    //        table9.Append(tableRow33);

    //        var paragraph191 = new Paragraph() { RsidParagraphMarkRevision = "00000EA8", RsidParagraphAddition = "004E4E45", RsidRunAdditionDefault = "00602ED1" };

    //        var paragraphProperties190 = new ParagraphProperties();
    //        var paragraphStyleId170 = new ParagraphStyleId() { Val = "Header" };

    //        var paragraphMarkRunProperties185 = new ParagraphMarkRunProperties();
    //        var runFonts333 = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", ComplexScript = "Arial" };
    //        var fontSize356 = new FontSize() { Val = "24" };
    //        var fontSizeComplexScript87 = new FontSizeComplexScript() { Val = "24" };

    //        paragraphMarkRunProperties185.Append(runFonts333);
    //        paragraphMarkRunProperties185.Append(fontSize356);
    //        paragraphMarkRunProperties185.Append(fontSizeComplexScript87);

    //        paragraphProperties190.Append(paragraphStyleId170);
    //        paragraphProperties190.Append(paragraphMarkRunProperties185);

    //        paragraph191.Append(paragraphProperties190);

    //        header3.Append(table9);
    //        header3.Append(paragraph191);

    //        headerPart3.Header = header3;
    //    }

    //    // Generates content of imagePart1.
    //    private void GenerateImagePart1Content(ImagePart imagePart1)
    //    {
    //        var data = GetBinaryDataStream(imagePart1Data);
    //        imagePart1.FeedData(data);
    //        data.Close();
    //    }

    //    private void SetPackageProperties(OpenXmlPackage document)
    //    {
    //        document.PackageProperties.Creator = "Nabin Kumar";
    //        document.PackageProperties.Title = "";
    //        document.PackageProperties.Subject = "";
    //        document.PackageProperties.Keywords = "";
    //        document.PackageProperties.Description = "";
    //        document.PackageProperties.Revision = "2";
    //        document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2016-07-22T08:16:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
    //        document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2016-07-22T08:16:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
    //        document.PackageProperties.LastModifiedBy = "Nabin Kumar";
    //    }

    //    #region Binary Data
    //    private string imagePart1Data = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wgARCABLAFoDAREAAhEBAxEB/8QAHAAAAgIDAQEAAAAAAAAAAAAABQcABgEDBAgC/8QAGwEAAgMBAQEAAAAAAAAAAAAAAAQDBQYBAgf/2gAMAwEAAhADEAAAAfVIU2bQefbL6qy1cc5Ufnuw8wF2zrETYfTXKj89aimIyCzZ2Kge3/wdgWyGieaHzVXNbVYt7KBAvy2XcKeA84W/y7X3zA6fMvP2NqJaZVO5nPTPCBkC/htfNUWnsbeQ1hLxOj7LGOyt2SSssdk5AgQD0T4eRTT2O0QWgWVLh9QOyt2SSssddlrjo5JQmqOHD0T4eRSzwWXoOr3XlS7+ZfHeOyt2NHZp/QVVuVa7nGEreebbf57bIbOuSo31W8tMFjV567Bw3E5VJ6xrpadftUQj2q0UtIrHsyR8NCJEysbTKU0KifyrGTv1y3QttHUKN/LQ5gCfhhk1m2HhpDsDWHQGkOcCABQ7QtwKoNIHg7AIhRA7wKBADgMBgB//xAAnEAABBAMAAQIGAwAAAAAAAAAFAgMEBgABFjMQMQcRExQVNiAkJf/aAAgBAQABBQLDloiBEkrNPJygF90vELS6j0P3OKJx2xkXp4C8sTs9/Q9ONv4qpGFq5AvnIF8CRbGDXFkrfjHpFgJZyBfOQL5yBfAPRBsTK2pLlpK6c6stnWFtY5ZDbKesLZXSsqbX9Wwt8usLZ1hbOtLZ1xbG7OT2h3y5Ta2zMa+IUhvUbKl+ra9v4NeJ3y4Ksk0O3NmvEJOVL9W17V+sPG1W0JHCv+jXid8ter7hyT+Cg6guI+m4lO1qqqdorFYrqjLoyXFlRyQ5y1WNNaGoiEx6xpBmuEttDxbpcmUsjQiPSzrhOPKocp4gTXDqbFISl4DYLK2qPWoW4QE7YkiG6xaXYks1NGjs6ok5iKsaYZ4MngurGRM0k4Wdjro5ZxQEHJHBE0MnrCySb0PgyecGTzhCmIphFKBs+YSxs1M+2lG57SFlpkTaCBRcmEaekJkHJLbEsjJTFZflrsDRzcce8dlaGsSkuMIlvQrjBVtdolo1+JLJ1uU1r/VJOKh1iO2nQ0qnW3J7y4tomf1KpPOz2q7ADQ9wf//EADcRAAAFAgEICAUEAwAAAAAAAAABAgMEBREVEBIhIkFRUrETFDEyU2GB0QYjNJGhIEBicZLB8P/aAAgBAwEBPwEUyiyakd0lZG/23iHRocNo2iRe/aZ7RVPhc03dg/4+wUlSDzVFY8tL+Hn51nHdVH5P+gikQm4/Vib1fz9xVPhp2Nd2LrJ3bS98tLjUpqzs14jPh029d4Ku0xJWJ0hj9N8XmMfpvi8xUnqJUi13LK32/wCuH2UtO5iFkot4pbVGh2ckOktfrYvcY/TfF5jH6b4vMY/TfF5ip4JUNdLpJXvsf5CmLHbPIKqcslHrjFJfGMUmcYVUJ6CI1K7fIYpM4xAkuvRHHFnpK/IYpL4xikzjGKTOMYpM4xiszj5AqlKt3wvvHkpFPQ6nrDuncK8tOYhvbkpf0Lvry/UnsC+8eSLUH4ic1HYHnlyF9I4enJS/oXfXlkg01cw849CRVIbcRSSb25U9gX3jECCqYv8AiQ6kx0fRZugLLNUZAiMzsQphGUJ0j8+Qp9POUvOX3CEdxpxHyewtAkR1VKYZF3U6AVPjE30eYJMdUd42jCYEqxagYjKlP9GkSagiIjq0PZtFImqkoNDh6xB2iOLeMyVqiSpimJ6JjS5v3CjkS4qyXv8A9CfUEmnq0bQkU9nooqU7RNnlFT1aN6mKbU1NuZj6rpMS3ozHz1kRq2DEpStOcCps1CVIQZFcYJK8hGps2K4TiLfcSFS1IsykiP8AsHRpajudvuIUN1iMtpfafsMFk3voEkpSm8xgreowSV5DBJXkMFleX3BUmTbZ+5//xAAnEQABAwMDBAIDAQAAAAAAAAABAAIDERNREiExBBAUIiAzQEFhcf/aAAgBAgEBPwFMic9Nia0UUnT03b8I4S/lWmU0qSAt3b3jbGN3FXo8q8zKvMypDE/9oihUYibu4q8zKvMyrzMqS0/cFUQgjwrEeFYjwhDEeArEeFKxrZAArEeFYjwrEeFYjwrEeFZZhDjt1ExHoF0oNSe0/wBo+Y47PhbJuU1oYKDtP9o7SzCP/VBIZAa/AcKWURhXHV1VQ3Hab7WqaW2KDlPDgfZMfZj/AKVefWtUx+tupGVmU54Y2pTITIdci6iPQahDqQGpmqc6ncLqNpBRRQmut/KmdqeSo4rnu9TQAirVG17vUKwzCvREgleSxPmjeKFMtg+y8mMKSRrnhwXksTNANXLyY15LF5Ma8hn5P//EAD4QAAIBAgIFCQQIBQUAAAAAAAECAwAEERIFEyExQRAUMjRRYXGRkiIjUsEVJDNCQ3J00SBigbLCNVOCoeH/2gAIAQEABj8Coqx1txwiX59lLM0xiyHFEjOAWlh0l7LcJxu/rQZGDKdxHK0UOFzc/COivjQvDcsJhuw3DuwpYb3C3n+P7jftytDo6yeJN2uJGY+HZRZrRyTvJYV1NvMV1NvMV7u1aSDjC7DD/wAoSPA8D8Y2300VrZSW1v25hnb9q6m3mK6m3mK6m3mKEb2b3Nr/ALbMMR4UCYJVx4YU4542/sFdcbyFdcbyFK0k8iBuiWjAx/6rrjekVeXE0peZC2VsN2yuuN6RXXG9Irrh9Irrh9IrrZ9IpTzo7vhFP+Y8nPrkawZsI4+GziatbfZrc2fDsHJpDxf+3+JPCn/MeRo4GUxk45XGOBpp53zyNx5NIeL/ANvJnJ1NqN8nb4Vbrb5sHU45jjyp4U/5jXFLdOm/yFG1FugiIw3badPhOFBVGLHcBWkVYYEM+IP5a1kuKWadJvi7q+p4amI6sZRs2dlSKpyWlt7tpO/iBRt+apkI6R6XnUtq20q2zvHCk+qPu7q5vFs9olm+EdtDR2iMAE2NP391SQXD554tuY72WpWSaNYHYsCd4o21l7zSLj2p23oPlV2sp9hpGzHHuFDR2jfd2aDKXX73cO6rePouy5z4mvo7RhwZftJu/j/WtVeTNJbyfekOOQ0t9Okctyo91htY1n1+XNtwC7qnhheCNJmxchvaI7Ma/B9dR3MWoxXeufpDsrJZwxwyEbXeTHDwosxiZjtJMm+ru1mya2QtlwOzaKH2B/50IbFI4WK4M7P0fCt8Prr8H11+D66Ue63fFRugYo7LOyhMpLkDZjjVtfusXNJ5AuqGOdQTgDjV5OiQam2uNVlOOZ93lvrSCTiFngg16ZAcOOw+VW8OFqrXEOtB2+7ww899aMzIgNw8iSYfyg7vKrho442dLwW6g8Rs/etLQXSQzNBEHGTEKQeFPEJU5sIEfVlfGrCOJFhafWHHIzhQGPDfVtPqtRmcpLK0bEIB97LvwNRtr4nxUHMp2GuYQSGO0eTOYhuxI219Gkk2MEheOHgDWlf1vzWtLfoR/lWjf0jf41aXELGOaO5bK44Ylsabf/qEbbTjtxFad77ZPnWitU2XXx5JP5gN1W11CclxA7atxwxY41YXK3LCaSRwzdtW/uB9mvE9lf/EACYQAQACAQIFBQEBAQAAAAAAAAEAESExUUFhccHwEIGRodGxIOH/2gAIAQEAAT8hmPD5efdGaDCv0vNmGWkPLp4dSGMe12J19cAzi3JzdicYBvRbNFTOu4NCQIBGx4+nG872wX8tYkBrQK/M867zzrvAA4buXpnKVJ5o0PtrBVnhwHm3hyJ413nnXeeVd4qMGxPPf1pHMQFeZy1hsEGHW6Tw/tPBf8hyfsAPKPIe0KWqoMCmhFDyfaeQ9p5L2ni/aeN9ovLEPmTzm/oNMKRxfIzwhScmjURPtfr08dsml0/z9D/J5zf002pkbhF1a5cDYOB6eO2TS6S7ZFUZe37if343rHWX6fQ/yec3lXyWPwubQ8X3XrfOc7H4sQAygWrGEGQUjSC+kdba/wBYxLG4j8kW+MH7uYhlSghfVxXL3q51ravciHRZ1Q6dYy1CPS/Kla50s83M84hd1NUfj2l7uokluqlcdRnO23bEW2FPTDc3CB4QlfBfGccYm2X8lP1njt+B421Yff8AWa3beEPrI4tjXLnwmjA6Eq3CWuAGOiNOUp/7fktJYkdcRYhLDl3sq+2If+zKt3Ez1Ey8ELmRtFWW/Jqz9FG2P3LeK9X5Ob835PKvyNDMB5qMkZmh2y1DZpUwVdjxOSl0sqPVcJzY105mYEprEy4pzzYluQqTNZedraa/VFocjqeKOJf9BEWu8UujoauWbxWtwpK0Bq0Yb1x8R7HILOlBsvWU1ZdblaGAdLiBVtANTOk3GKMQ9FuaMS2MOuNk5oLgcRo1hu5naJqL8wNtZBJuzGTNF8iCmVsVSlVWXmaF+JAELCbpHzGplyWaocx2ZQCIxhnhVRJVXJyHOf/aAAwDAQACAAMAAAAQnJ8hksY/oX/YJq8cW5Hh+v8A/h9frwvh65KomRPL3CvZsL1oZ5JIIIBBJIJBIP/EACgRAAECBQMEAwEBAQAAAAAAAAEAESExQVFhcZHREKGxwYHh8PEgQP/aAAgBAwEBPxBBF5HL4VdrlAZNsACeAwPMVPkKlMaq6GOSjsoECCGI1HWJi+RsPZhZ0aCEpvEjczPkSoo+Z/5QaRwiCCx6VImADGptghd0ODAJAAsOyw9uCw9uCd46Yk/zCDB+CESUgBwDq4cZRQOKM6wGiyYWFVh7cFh7cFg7cELtuzB0NHUR1QDgUAzeeZIQA52HCy9hwhc7DhHAASOEeyzdhwn4cIYQYD5Rdn2HCzdhws3YcLN2HC/EcEaBPYOF3x6MQY8FIVPCDvD/AAzd/XTuvAjM/wCZOi749CA4JRYh44R44Lp3XgRmVKi1vgc0T3rBF8dZOi74qOITD6GUyYi4NKOrzfKwiSEFAclAYYg+BStTDfA9mibE3JKFsIiTRxzUDL7eSwQY1rq83QBnIMMih+UcZ8hblU8OXNhdDGAcqtc3OycHRXuDwfSBOBEl4vHDe0RxARKYejbc0RDIEnOGPFSSsCRXAxe/kkuIP8mKdzEZC9dTc/ATmFQS7G7ml90LAwFhJ0xmiJjWvFmEEKkHEgxIs7Swj/R9KOUFKhaSc0EyZNId+yNjkTM/wm2orMYRAID9j6QEMZESZMCHdEhcnd9L8D9J/wDHpBgPL6/6f//EACgRAQACAAUEAQMFAAAAAAAAAAEAERAhMUFRYXGRsSBAwfCBodHh8f/aAAgBAgEBPxCM5ZHMy8u43oxEacc2yECyspuwY0FrpACjFsHbR5hUDcRzD8NtsAxq6kQDiJSQMuuEMbJr38AZ+a5+e43/ANpoYI6PM4l0w9P38nVmhg1uwQdGHp+8DqM4eNuLqzQnWTpNezRUMUC2MUOnuDqCnKjnANeSor/mgAJbcG7mHtBA8n3DgjZBpE7cxqNQfeE1McCH2jrwkqbSfvLN0N5TlCQFqd/xH93iCwlO0AUX4mmwfzMvfxHd1/Sd7xO/O94irv8AU//EACUQAQEAAgICAgEFAQEAAAAAAAERACExQVFhEHHwIIGhwdHhkf/aAAgBAQABPxDLt6j0vTxD734M2nvw3SRsNNLvgZk/6En06eX7How43D73CDSfIKKSp9L7Ps8zFMggs7XsvYje65BkS/ouXk+HXvDIAoGifClUo2PdtHt9Jzj6fN5cqtr8nj1s2CPIvf2GvI5QkzJboUldI7ywZTnwNG59nl6yyqq9/HPVzyUsD9zzr9v/ABzhtCh1SqkU41g5zThBB8QJQ6fbZ9qm1oJ2P9+G72QkQmABirsxJaofoLffDAJf7zoaPHkUM/nPP43rVjsiX2AtardYxgiw2V9AA814+Q/8N+n8j4Z+c8/hn+t2hHYJYU4ZjL1IAA4BoOg+Q/8ADZvOuLNyTpfK0e3WcTk1BEPVvHGsgZS+Pj8j4Z+c88YNHJt+TzP+DfjBbePZSd5V72tx31V5e6H9YUnTZbgA2uPZ8oFcR4Txgwqi/CL+ID242yUbaBPLbk5wms+Uj0C1nglehn3hlWd+najgYyXV3DO6HHdMCoFwxpyND6cCSCFSv+gHamPc6KL7Vw7y9dHGEcNOoaWcuhfDi8WI4VCRSy3eDzCwENvRTg4tbq1oq+FqfGlbh4hQNTXkF2t/W03N6GtBZ6HT1lJWOs0XyFKvCw41vbgRrjcb4Tg09OIYRzK2HuU29UznfhOLYbQpYWb8Ywt1CJj2G6olu7jECz0WQAXQRuvAp30g5LPZYs2Ehf2PWL+GsI1R2XIFbpSokJsesUQDUSzrJpVcAUSFvq+DgvCpVRqqK5cUqSqhC6jOwqiPkJhkupmNJU6U13cNC7ity9kqIBYsyLv3ZUxdSdgPgmzS9mumFITpsPBiUkVEU9Vsiat2hu/RwLF3ugLKgzA+WU7lWtmzXrHfQiiU+4yBRNGIGdMAx0L5NNCXeHkvMOJZVOQFXiGI4C2qGRoIK67WY4iSIdDNSK026cN2HytUWo2kK6xs5lPL95AVIZAhjB4Orb/xxKo707P++HPshXRf8YKJ1qZIumibHDaVzrMBVVXbm/TlDsy2WPsCKDZEtI75x7nS0vHANII61oypT08yBfBCQ11i1Q1Mrk//2Q==";

    //    private System.IO.Stream GetBinaryDataStream(string base64String)
    //    {
    //        return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
    //    }

    //    #endregion

    //}
}
