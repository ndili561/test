using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Service.Api.DTOs;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using DocumentType = InCoreLib.Domain.Allocations.Enumerations.DocumentType;
using InCoreLib.DAL.Migrations;

namespace Incomm.Allocations.BLL.Common
{
    //public class DocumentHelper
    //{
    //    private static readonly Regex instructionRegEx =
    //   new Regex(
    //               @"^[\s]*MERGEFIELD[\s]+(?<name>[#\w]*){1}               # This retrieves the field's name (Named Capture Group -> name)
    //                        [\s]*(\\\*[\s]+(?<Format>[\w]*){1})?                # Retrieves field's format flag (Named Capture Group -> Format)
    //                        [\s]*(\\b[\s]+[""]?(?<PreText>[^\\]*){1})?         # Retrieves text to display before field data (Named Capture Group -> PreText)
    //                                                                            # Retrieves text to display after field data (Named Capture Group -> PostText)
    //                        [\s]*(\\f[\s]+[""]?(?<PostText>[^\\]*){1})?",
    //               RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
    //    public string GenerateVBLApplication(VBLApplication vblApplication, VBLDocumentDTO documentDto)
    //    {

    //        var caseRef = vblApplication.HOACaseRef == 0 ? string.Empty : vblApplication.HOACaseRef.ToString();
    //        var maintenent = vblApplication.Contacts.First(x => x.ContactTypeId == 1);
    //        //Create a new document
    //        dynamic templatePath = HostingEnvironment.MapPath("~/App_Data/Template/VBL/ClosureTemplate.dotx");
    //        switch (documentDto.DocumentType)
    //        {
    //            case DocumentType.ClosureApplication:
    //                templatePath = HostingEnvironment.MapPath("~/App_Data/Template/VBL/ClosureTemplate.dotx");
    //                break;
    //            case DocumentType.RefusalApplication:
    //                templatePath = HostingEnvironment.MapPath("~/App_Data/Template/VBL/RefusalTemplate.dotx");
    //                break;
    //            case DocumentType.ExpireApplication:
    //                templatePath = HostingEnvironment.MapPath("~/App_Data/Template/VBL/ExpireTemplate.dotx");
    //                break;
    //        }
    //        var filePath = documentDto.DocumentPath + "\\" + documentDto.DocumentType + "_" + DateTime.Now.ToFileTimeUtc() + "_" + vblApplication.ApplicationId + ".doc";
    //        File.Copy(templatePath, filePath);


    //        WordprocessingDocument objWordDocx;
    //        objWordDocx = WordprocessingDocument.Open(filePath, true);
    //        //get the main document section of the document
    //        OpenXmlElement objMainDoc;
    //        objMainDoc = objWordDocx.MainDocumentPart.Document;

    //        //fill a dummy dictionary of values to fill the template
    //        Dictionary<string, string> values = new Dictionary<string, string>();
    //        values["YourReference"] = "Help";
    //        values["OurReference"] = "Me";
    //        values["Address1"] = "Address1 Test";
    //        values["Address2"] = "Address2 Test";
    //        values["City"] = "City Test";
    //        values["PostCode"] = "PostCode Test";
    //        values["ApplicantName"] = maintenent.Forename + " " + maintenent.Surname;
    //        values["CurrentDate"] = DateTime.Now.ToShortDateString();
    //        values["ApplicationNumber"] = vblApplication.ApplicationId.ToString();
    //        values["TelephoneNumber"] = "01274 257777";
    //        values["FaxNumber"] = "01274 257777";
    //        values["EmailAddress"] = "help@incommunities.co.uk";
    //        values["ServiceName"] = "Home Service";
    //        values["OfficerName"] = "Karl Smith";
    //        values["OrganisationName"] = "Bradford";
    //        values["Expirydate"] = DateTime.Now.ToShortDateString();
    //        values["RefusalReason"] = "Unknown";
    //        values["ContactNumber"] = "01274 257777";
    //        values["ContactOrganisation"] = "Incommunities";
    //        //Loop through merge fields
    //        foreach (var objField in objMainDoc.Descendants<SimpleField>())
    //        {
    //            //Clean the field name
    //            string strFieldName = GetFieldName(objField);

    //            if (!string.IsNullOrEmpty(strFieldName))
    //            {
    //                //check if we have a value for this merge field
    //                if (values.ContainsKey(strFieldName) && !string.IsNullOrEmpty(values[strFieldName]))
    //                {
    //                    //Find the XML placeholder
    //                    var strRunProp = new List<string>();
    //                    if (objField != null)
    //                    {
    //                        foreach (var objRP in objField.Descendants<RunProperties>())
    //                        {
    //                            strRunProp.Add(objRP.OuterXml);
    //                        }
    //                    }
    //                    foreach (var strProp in strRunProp)
    //                    {
    //                        Run objRun = new Run();
    //                        objRun.Append(new RunProperties(strProp));
    //                        //add the text to the place holder
    //                        objRun.Append(new Text(values[strFieldName]));
    //                        //replace the merge field with the value
    //                        objField.Parent.ReplaceChild<SimpleField>(objRun, objField);
    //                    }
    //                }
    //            }

    //        }
    //        //foreach (var objField in objMainDoc.Descendants<FieldCode>())
    //        //{
    //        //    //Clean the field name
    //        //    string strFieldName = GetFieldName(objField);

    //        //    if (!string.IsNullOrEmpty(strFieldName))
    //        //    {
    //        //        //check if we have a value for this merge field
    //        //        if (values.ContainsKey(strFieldName) && !string.IsNullOrEmpty(values[strFieldName]))
    //        //        {
    //        //            //Find the XML placeholder
    //        //            var strRunProp = new List<string>();
    //        //            if (objField != null)
    //        //            {
    //        //                foreach (var objRP in objField.Descendants<RunProperties>())
    //        //                {
    //        //                    strRunProp.Add(objRP.OuterXml);
    //        //                }
    //        //            }
    //        //            foreach (var strProp in strRunProp)
    //        //            {
    //        //                Run objRun = new Run();
    //        //                objRun.Append(new RunProperties(strProp));
    //        //                //add the text to the place holder
    //        //                objRun.Append(new Text(values[strFieldName]));
    //        //                //replace the merge field with the value
    //        //                objField.Parent.ReplaceChild<FieldCode>(objRun, objField);
    //        //            }
    //        //        }
    //        //    }

    //        //}
    //        //save this part
    //        objWordDocx.MainDocumentPart.Document.Save();
    //        //save and close the document
    //        objWordDocx.Close();
    //        //    foreach (Field myMergeField in document.Fields)
    //        //    {
    //        //        var rngFieldCode = myMergeField.Code;
    //        //        var fieldText = rngFieldCode.Text;
    //        //        if (fieldText.StartsWith(" MERGEFIELD"))   // ONLY GETTING THE MAILMERGE FIELDS
    //        //        {

    //        //            var endMerge = fieldText.IndexOf("\\");
    //        //            var fieldName = fieldText.Substring(11, endMerge - 11);
    //        //            fieldName = fieldName.Trim();// GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE
    //        //            if (fieldName == "ApplicantName")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(maintenent.Forename + " " + maintenent.Surname);
    //        //            }
    //        //            else if (fieldName == "YourReference")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(caseRef);
    //        //            }
    //        //            else if (fieldName == "OurReference")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(caseRef);
    //        //            }
    //        //            else if (fieldName == "Address1")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.Address != null
    //        //                    ? vblApplication.Address.AddressLine1
    //        //                    : "");
    //        //            }
    //        //            else if (fieldName == "Address2")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.Address != null
    //        //                    ? vblApplication.Address.AddressLine2 + " " + vblApplication.Address.AddressLine3
    //        //                    : "");

    //        //            }
    //        //            else if (fieldName == "City")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.Address != null
    //        //                     ? vblApplication.Address.AddressLine4
    //        //                     : "");
    //        //            }
    //        //            else if (fieldName == "Postcode")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.Address != null
    //        //                    ? vblApplication.Address.PostCode
    //        //                    : "");
    //        //            }
    //        //            else if (fieldName == "CurrentDate")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(DateTime.Now.ToShortDateString());
    //        //            }
    //        //            else if (fieldName == "ApplicationNumber")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.ApplicationId.ToString());
    //        //            }
    //        //            else if (fieldName == "TelephoneNumber")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("01274 777777");
    //        //            }
    //        //            else if (fieldName == "FaxNumber")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("01274 66666");
    //        //            }
    //        //            else if (fieldName == "EmailAddress")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("help@incommunities.co.uk ");
    //        //            }
    //        //            else if (fieldName == "ServiceName")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("Neighbourhood Services");
    //        //            }
    //        //            else if (fieldName == "OfficerName")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(documentDto.CreatedBy);
    //        //            }
    //        //            else if (fieldName == "OrganisationName")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("Incommunities");
    //        //            }
    //        //            else if (fieldName == "ExpiryDate")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText(vblApplication.ApplicationClosedDate.HasValue ? vblApplication.ApplicationClosedDate.Value.ToShortDateString() : string.Empty);
    //        //            }
    //        //            else if (fieldName == "RefusalReason")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("");
    //        //            }
    //        //            else if (fieldName == "ContactName")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("");
    //        //            }
    //        //            else if (fieldName == "ContactOrganisation")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("");
    //        //            }
    //        //            else if (fieldName == "ContactNumber")
    //        //            {
    //        //                myMergeField.Select();
    //        //                winword.Selection.TypeText("");
    //        //            }
    //        //        }

    //        //    }
    //        //    //Save the document
    //        //    document.Protect(Type: WdProtectionType.wdAllowOnlyReading);
    //        //    var filePath = documentDto.DocumentPath + "\\" + documentDto.DocumentType + "_" + DateTime.Now.ToFileTimeUtc() + "_" + vblApplication.ApplicationId + ".doc";
    //        //    object filename = filePath;
    //        //    document.SaveAs2(ref filename);
    //        //    document.Close(false);
    //        //    document = null;
    //        //    return filePath;
    //        //}
    //        //finally
    //        //{
    //        //    winword.Quit(ref missing, ref missing, ref missing);
    //        //    winword = null;
    //        //}
    //        // }
    //        //catch (Exception ex)
    //        //{
    //        //    Debug.WriteLine(ex.Message);
    //        //}
    //        return string.Empty;
    //    }
    //    internal static string GetFieldName(SimpleField pField)
    //    {
    //        var attr = pField.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    //        string strFieldname = string.Empty;
    //        string instruction = attr.Value;
    //        if (!string.IsNullOrEmpty(instruction))
    //        {
    //            Match m = instructionRegEx.Match(instruction);
    //            if (m.Success)
    //            {
    //                strFieldname = m.Groups["name"].ToString().Trim();
    //            }
    //        }
    //        return strFieldname;
    //    }
    //    internal static string GetFieldName(FieldCode pField)
    //    {
    //       return pField.Text.Replace("MERGEFIELD","").Replace("MERGEFORMAT", "").Replace(@"\*", "").Trim();
    //    }
    //    public string GenerateNewVBLApplication(VBLApplication vblApplication, VBLDocumentDTO documentDto)
    //    {
    //        var householdMembers = vblApplication.Contacts.Where(x => x.ContactTypeId != 1).ToList();
    //        var winword = new Application
    //        {
    //            Visible = false
    //        };
    //        object missing = Missing.Value;
    //        var maintenent = vblApplication.Contacts.First(x => x.ContactTypeId == 1);
    //        //Create a new document
    //        var document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
    //        try
    //        {
    //            document.PageSetup.TopMargin = winword.InchesToPoints(0.5f); //half an inch in points
    //            document.PageSetup.BottomMargin = winword.InchesToPoints(0.5f);
    //            document.PageSetup.LeftMargin = winword.InchesToPoints(0.5f);
    //            document.PageSetup.RightMargin = winword.InchesToPoints(0.5f);
    //            //Add header into the document
    //            ApplicationHeaderContent.AddContent(document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddAddress(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddDateAndApplicationReference(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddApplicationDetails(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddHouseholdMembersDetails(vblApplication.Contacts.ToList(), document);
    //            InsertBlankLine(document, 1, ref missing);
    //            var contactByDetails = new List<VBLContactByDetails>();
    //            foreach (var contact in vblApplication.Contacts)
    //            {
    //                var contactDetails = contactByDetails.Select(x => x.ContactValue).ToArray();
    //                contactByDetails.AddRange(contact.ContactByDetails.Where(x => !contactDetails.Contains(x.ContactValue)));
    //            }
    //            if (contactByDetails.Any())
    //            {
    //                AddContactByDetails(contactByDetails, document);
    //            }
    //            AddCustomerCircumstancesOfApplicant(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddRequiredSupportDetailsOfApplicant(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddReceivedSupportDetailsOfApplicant(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddMonthlyIncomeDetailsOfApplicant(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            AddIncomeDetailsOfHouseholdMembers(vblApplication, document);
    //            InsertBlankLine(document, 1, ref missing);
    //            DataProtectionApplicationContent.AddContent(document, ref missing);
    //            InsertBlankLine(document, 1, ref missing);
    //            DeclarationContent.AddContent(document, maintenent.Forename + " " + maintenent.Surname, ref missing);
    //            InsertBlankLine(document, 1, ref missing);
    //            ParticipatingLandlordsContent.AddContent(document, ref missing);

    //            document.Protect(Type: WdProtectionType.wdAllowOnlyReading);
    //            var filePath = documentDto.DocumentPath + "\\New_" + DateTime.Now.ToFileTimeUtc() + "_" + vblApplication.ApplicationId + ".doc";
    //            object filename = filePath;
    //            document.SaveAs2(ref filename);
    //            document.Close(ref missing, ref missing, ref missing);
    //            return filePath;
    //        }
    //        finally
    //        {
    //            document = null;
    //            winword.Quit(ref missing, ref missing, ref missing);
    //            winword = null;

    //        }
    //    }

    //    private static void AddAddress(VBLApplication vblApplication, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para = document.Content.Paragraphs.Add(ref missing);
    //        var firstTable = document.Tables.Add(para.Range, 6, 2, ref missing, ref missing);
    //        firstTable.Borders.Enable = 0;
    //        firstTable.Rows.HeightRule = WdRowHeightRule.wdRowHeightExactly;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            foreach (Cell cell in row.Cells)
    //            {
    //                //Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    continue;
    //                }
    //                //Data row
    //                if (cell.RowIndex == 2)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.Contacts.First(x => x.ContactTypeId == 1).Forename + " " + vblApplication.Contacts.First(x => x.ContactTypeId == 1).Surname;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Incommunities Group Ltd";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //                else if (cell.RowIndex == 3)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.Address.AddressLine1;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "The Quays";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //                else if (cell.RowIndex == 4)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.Address.AddressLine2;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Victoria Street";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //                else if (cell.RowIndex == 5)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.Address.AddressLine3;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Shipley";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //                else if (cell.RowIndex == 6)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.Address.PostCode;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "BD17 7BN";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private static void AddDateAndApplicationReference(VBLApplication vblApplication, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para = document.Content.Paragraphs.Add(ref missing);
    //        var firstTable = document.Tables.Add(para.Range, 4, 3, ref missing, ref missing);
    //        firstTable.Borders.Enable = 0;
    //        firstTable.Rows.HeightRule = WdRowHeightRule.wdRowHeightExactly;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            foreach (Cell cell in row.Cells)
    //            {
    //                //Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    continue;
    //                }
    //                //Data row
    //                if (cell.RowIndex == 2)
    //                {
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Tel:";
    //                        cell.Range.Font.Bold = -1;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                    else if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = "1274 257777";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                }
    //                else if (cell.RowIndex == 3)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = DateTime.Now.ToShortDateString();
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Email:";
    //                        cell.Range.Font.Bold = -1;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                    else if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = "enquiry@incommunities.co.uk";
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                }
    //                else if (cell.RowIndex == 4)
    //                {
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Application Ref: ";
    //                        cell.Range.Font.Bold = -1;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                    else if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = vblApplication.ApplicationId.ToString();
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private static void AddApplicationDetails(VBLApplication vblApplication, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para1 = document.Content.Paragraphs.Add(ref missing);
    //        para1.Range.Text = "Application Details";
    //        para1.Range.InsertParagraphAfter();
    //        para1.Range.Paragraphs.SpaceAfter = 0;
    //        var para2 = document.Content.Paragraphs.Add(ref missing);

    //        var firstTable = document.Tables.Add(para2.Range, 2, 6, ref missing, ref missing);

    //        firstTable.Borders.Enable = 1;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            foreach (Cell cell in row.Cells)
    //            {
    //                //Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = "Application Status ";
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Application Date";
    //                    }
    //                    if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = "Banding";
    //                    }
    //                    if (cell.ColumnIndex == 4)
    //                    {
    //                        cell.Range.Text = "Eligibility";
    //                    }
    //                    if (cell.ColumnIndex == 5)
    //                    {
    //                        cell.Range.Text = "HOA Case";
    //                    }
    //                    if (cell.ColumnIndex == 6)
    //                    {
    //                        cell.Range.Text = "Appointment ";
    //                    }

    //                    cell.Range.Font.Bold = -1;
    //                    //other format properties goes here
    //                    cell.Range.Font.Name = "Ariel";
    //                    cell.Range.Font.Size = 12;
    //                    //Center alignment for the Header cells
    //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                }
    //                //Data row
    //                else
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = vblApplication.ApplicationStatusReason;
    //                    }
    //                    if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = vblApplication.ApplicationDate.ToString();
    //                    }
    //                    if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = vblApplication.LevelOfNeeds == null ? string.Empty : vblApplication.LevelOfNeeds.Name;
    //                    }
    //                    if (cell.ColumnIndex == 4)
    //                    {
    //                        cell.Range.Text = vblApplication.ApplicationEligible.HasValue &&
    //                                          vblApplication.ApplicationEligible.Value
    //                            ? "Applicant(s) Eligible"
    //                            : "Applicant(s) Not Eligible";
    //                    }
    //                    if (cell.ColumnIndex == 5)
    //                    {
    //                        cell.Range.Text = vblApplication.HOACaseIsOpen.HasValue && vblApplication.HOACaseIsOpen.Value
    //                            ? "HOA Case Open"
    //                            : "No HOA Case";
    //                    }
    //                    if (cell.ColumnIndex == 6)
    //                    {
    //                        cell.Range.Text = "  ";
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    private static void AddHouseholdMembersDetails(List<VBLContact> householdMembers, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para1 = document.Content.Paragraphs.Add(ref missing);
    //        para1.Range.Text = "Summary Of Household Details";
    //        para1.Range.InsertParagraphAfter();
    //        para1.Range.Paragraphs.SpaceAfter = 0;
    //        var para2 = document.Content.Paragraphs.Add(ref missing);

    //        var firstTable = document.Tables.Add(para2.Range, householdMembers.Count + 1, 9, ref missing, ref missing);
    //        int ctr = 0;
    //        firstTable.Borders.Enable = 1;
    //        bool isHeader = false;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            if (householdMembers.Count == ctr) break;
    //            var householdMember = householdMembers[ctr];
    //            foreach (Cell cell in row.Cells)
    //            {
    //                #region Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    isHeader = true;
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = "Name";
    //                    }
    //                    else if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Type";
    //                    }
    //                    else if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = "Gender";
    //                    }
    //                    else if (cell.ColumnIndex == 4)
    //                    {
    //                        cell.Range.Text = "DOB";
    //                    }
    //                    else if (cell.ColumnIndex == 5)
    //                    {
    //                        cell.Range.Text = "Nationality";
    //                    }
    //                    else if (cell.ColumnIndex == 6)
    //                    {
    //                        cell.Range.Text = "Eligible";
    //                    }
    //                    else if (cell.ColumnIndex == 7)
    //                    {
    //                        cell.Range.Text = "Relationship To Applicant";
    //                    }
    //                    else if (cell.ColumnIndex == 8)
    //                    {
    //                        cell.Range.Text = "Disabled";
    //                    }
    //                    else if (cell.ColumnIndex == 9)
    //                    {
    //                        cell.Range.Text = "Pregnant";
    //                    }
    //                    cell.Range.Font.Bold = -1;
    //                    //other format properties goes here
    //                    cell.Range.Font.Name = "Ariel";
    //                    cell.Range.Font.Size = 12;
    //                    //Center alignment for the Header cells
    //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                }
    //                #endregion

    //                #region Data row
    //                else
    //                {
    //                    isHeader = false;
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = householdMember.Forename + " " + householdMember.Surname;
    //                    }
    //                    else if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = householdMember.ContactType.Name;
    //                    }
    //                    else if (cell.ColumnIndex == 3)
    //                    {
    //                        cell.Range.Text = householdMember.Gender.Name;
    //                    }
    //                    else if (cell.ColumnIndex == 4)
    //                    {
    //                        cell.Range.Text = householdMember.DateOfBirth.ToShortDateString();
    //                    }
    //                    else if (cell.ColumnIndex == 5)
    //                    {
    //                        cell.Range.Text = householdMember.NationalityType.Name;
    //                    }
    //                    else if (cell.ColumnIndex == 6)
    //                    {
    //                        cell.Range.Text = householdMember.PublicFunds && !householdMember.ImmigrationControl && householdMember.LivedInUKForFiveYears ? "Yes" : "No";
    //                    }
    //                    else if (cell.ColumnIndex == 7)
    //                    {
    //                        cell.Range.Text = householdMember.Relationship != null ? householdMember.Relationship.Name : string.Empty;
    //                    }
    //                    else if (cell.ColumnIndex == 8)
    //                    {
    //                        cell.Range.Text = householdMember.DisabilityDetails.Any() ? "Yes" : "No";
    //                    }
    //                    else if (cell.ColumnIndex == 9)
    //                    {
    //                        cell.Range.Text = householdMember.IsPregnant ? "Yes" : "No";
    //                    }
    //                }
    //                #endregion
    //            }
    //            if (isHeader)
    //            {
    //                ctr = 0;
    //            }
    //            else
    //            {
    //                ctr = ctr + 1;
    //            }
    //        }
    //    }

    //    private void AddContactByDetails(List<VBLContactByDetails> contactByDetails, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para1 = document.Content.Paragraphs.Add(ref missing);
    //        para1.Range.Text = "Contact Information";
    //        para1.Range.InsertParagraphAfter();
    //        para1.Range.Paragraphs.SpaceAfter = 0;
    //        var para2 = document.Content.Paragraphs.Add(ref missing);

    //        var firstTable = document.Tables.Add(para2.Range, contactByDetails.Count + 1, 2, ref missing, ref missing);

    //        firstTable.Borders.Enable = 1;
    //        int ctr = 0;
    //        bool isHeader = false;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            if (contactByDetails.Count == ctr) break;
    //            var contactByDetail = contactByDetails[ctr];
    //            foreach (Cell cell in row.Cells)
    //            {
    //                #region Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    isHeader = true;
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = "Item";
    //                    }
    //                    else if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Selected Value";
    //                    }

    //                    cell.Range.Font.Bold = -1;
    //                    //other format properties goes here
    //                    cell.Range.Font.Name = "Ariel";
    //                    cell.Range.Font.Size = 12;
    //                    //Center alignment for the Header cells
    //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                }
    //                #endregion

    //                #region Data row
    //                else
    //                {
    //                    isHeader = false;
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = contactByDetail.ContactBy == null ? string.Empty : contactByDetail.ContactBy.Description;
    //                    }
    //                    else if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = contactByDetail.ContactValue;
    //                    }
    //                }
    //                #endregion
    //            }
    //            if (isHeader)
    //            {
    //                ctr = 0;
    //            }
    //            else
    //            {
    //                ctr = ctr + 1;
    //            }
    //        }
    //    }
    //    private void AddCustomerCircumstancesOfApplicant(VBLApplication vblApplication, Document document)
    //    {
    //        object missing = Missing.Value;
    //        var para1 = document.Content.Paragraphs.Add(ref missing);
    //        para1.Range.Text = "Customer Circumstances";
    //        para1.Range.InsertParagraphAfter();
    //        para1.Range.Paragraphs.SpaceAfter = 0;
    //        var para2 = document.Content.Paragraphs.Add(ref missing);

    //        var firstTable = document.Tables.Add(para2.Range, 5, 2, ref missing, ref missing);

    //        firstTable.Borders.Enable = 1;
    //        bool isHeader = false;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            foreach (Cell cell in row.Cells)
    //            {
    //                #region Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = "Item";
    //                    }
    //                    else if (cell.ColumnIndex == 2)
    //                    {
    //                        cell.Range.Text = "Selected value";
    //                    }
    //                    cell.Range.Font.Bold = -1;
    //                    //other format properties goes here
    //                    cell.Range.Font.Name = "Ariel";
    //                    cell.Range.Font.Size = 12;
    //                    //Center alignment for the Header cells
    //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                }
    //                #endregion

    //                #region Data row
    //                else
    //                {
    //                    if (cell.RowIndex == 2)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Residency Type";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = vblApplication.ResidencyType.Name;
    //                        }
    //                    }
    //                    else if (cell.RowIndex == 3)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Current Address";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            string livingAddress = vblApplication.Address.AddressLine1 + " " + vblApplication.Address.AddressLine2 + " " + vblApplication.Address.AddressLine3 + " " + vblApplication.Address.AddressLine4 + " " + vblApplication.Address.PostCode;
    //                            cell.Range.Text = livingAddress;
    //                        }
    //                    }
    //                    else if (cell.RowIndex == 4)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Duration";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = "Has lived at address for " + new DateDifference(vblApplication.ApplicationDate, vblApplication.DateMovedIn.HasValue ? vblApplication.DateMovedIn.Value : vblApplication.ApplicationDate).ToString();
    //                        }
    //                    }
    //                    else if (cell.RowIndex == 5)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Reason for Moving";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = vblApplication.MoveReason.Name;
    //                        }
    //                    }
    //                }
    //                #endregion

    //            }
    //        }
    //    }
    //    private void AddReceivedSupportDetailsOfApplicant(VBLApplication vblApplication, Document document)
    //    {
    //        var receivingSupportDetails = new List<VBLReceivingSupportDetails>();
    //        foreach (var contact in vblApplication.Contacts)
    //        {
    //            receivingSupportDetails.AddRange(contact.ReceivingSupportDetails);
    //        }
    //        if (receivingSupportDetails.Any())
    //        {
    //            object missing = Missing.Value;
    //            var para1 = document.Content.Paragraphs.Add(ref missing);
    //            para1.Range.Text = "Received Support Details";
    //            para1.Range.InsertParagraphAfter();
    //            para1.Range.Paragraphs.SpaceAfter = 0;
    //            var para2 = document.Content.Paragraphs.Add(ref missing);

    //            var firstTable = document.Tables.Add(para2.Range, receivingSupportDetails.Count + 1, 3, ref missing, ref missing);

    //            firstTable.Borders.Enable = 1;
    //            int ctr = 0;
    //            foreach (Row row in firstTable.Rows)
    //            {
    //                if (receivingSupportDetails.Count == ctr) break;
    //                var receivingSupportDetail = receivingSupportDetails[ctr];
    //                foreach (Cell cell in row.Cells)
    //                {
    //                    //Header row
    //                    if (cell.RowIndex == 1)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Support Worker Reason";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = "Support Worker Name";
    //                        }
    //                        else if (cell.ColumnIndex == 3)
    //                        {
    //                            cell.Range.Text = "Support Worker Contact";
    //                        }
    //                        cell.Range.Font.Bold = -1;
    //                        //other format properties goes here
    //                        cell.Range.Font.Name = "Ariel";
    //                        cell.Range.Font.Size = 12;
    //                        //Center alignment for the Header cells
    //                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                    }
    //                    //Data row
    //                    else
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = receivingSupportDetail.SupportType.Name;
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = receivingSupportDetail.Name;
    //                        }
    //                        else if (cell.ColumnIndex == 3)
    //                        {
    //                            cell.Range.Text = receivingSupportDetail.ContactByDetails.First().ContactValue;
    //                        }
    //                        ctr++;
    //                    }
    //                }
    //            }
    //        }

    //    }
    //    private void AddRequiredSupportDetailsOfApplicant(VBLApplication vblApplication, Document document)
    //    {
    //        var requestedSupportDetails = new List<VBLRequestedSupportDetails>();
    //        foreach (var contact in vblApplication.Contacts)
    //        {
    //            requestedSupportDetails.AddRange(contact.RequestedSupportDetails);
    //        }
    //        if (requestedSupportDetails.Any())
    //        {
    //            object missing = Missing.Value;
    //            var para1 = document.Content.Paragraphs.Add(ref missing);
    //            para1.Range.Text = "Required Support Details";
    //            para1.Range.InsertParagraphAfter();
    //            para1.Range.Paragraphs.SpaceAfter = 0;
    //            var para2 = document.Content.Paragraphs.Add(ref missing);

    //            var firstTable = document.Tables.Add(para2.Range, requestedSupportDetails.Count + 1, 2, ref missing, ref missing);

    //            firstTable.Borders.Enable = 1;
    //            int ctr = 0;
    //            foreach (Row row in firstTable.Rows)
    //            {
    //                if (requestedSupportDetails.Count == ctr) break;
    //                var requestedSupportDetail = requestedSupportDetails[ctr];
    //                foreach (Cell cell in row.Cells)
    //                {
    //                    //Header row
    //                    if (cell.RowIndex == 1)
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Support Requested";
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = "Support Reason";
    //                        }

    //                        cell.Range.Font.Bold = -1;
    //                        //other format properties goes here
    //                        cell.Range.Font.Name = "Ariel";
    //                        cell.Range.Font.Size = 12;
    //                        //Center alignment for the Header cells
    //                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
    //                    }
    //                    //Data row
    //                    else
    //                    {
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = requestedSupportDetail.SupportType.Name;
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = requestedSupportDetail.SupportType.Name;
    //                        }
    //                        ctr++;
    //                    }

    //                }
    //            }
    //        }

    //    }
    //    private void AddMonthlyIncomeDetailsOfApplicant(VBLApplication vblApplication, Document document)
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
    //                    incomePerMonth = incomeDetail.Amount + incomePerMonth;
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

    //        object missing = Missing.Value;
    //        var para1 = document.Content.Paragraphs.Add(ref missing);
    //        para1.Range.Text = "Income Details of Applicant";
    //        para1.Range.InsertParagraphAfter();
    //        para1.Range.Paragraphs.SpaceAfter = 0;
    //        var para2 = document.Content.Paragraphs.Add(ref missing);

    //        var firstTable = document.Tables.Add(para2.Range, 2, 1, ref missing, ref missing);

    //        firstTable.Borders.Enable = 1;
    //        int ctr = 0;
    //        foreach (Row row in firstTable.Rows)
    //        {
    //            foreach (Cell cell in row.Cells)
    //            {
    //                //Header row
    //                if (cell.RowIndex == 1)
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = "Total Income / Month";
    //                    }
    //                    cell.Range.Font.Bold = -1;
    //                    cell.Range.Font.Name = "Ariel";
    //                    cell.Range.Font.Size = 12;
    //                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                }
    //                //Data row
    //                else
    //                {
    //                    if (cell.ColumnIndex == 1)
    //                    {
    //                        cell.Range.Text = incomePerMonth.ToString("F");
    //                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                    }
    //                }
    //            }
    //            ctr++;
    //        }
    //    }
    //    private void AddIncomeDetailsOfHouseholdMembers(VBLApplication vblApplication, Document document)
    //    {
    //        var incomeDetails = new List<VBLIncomeDetail>();
    //        object missing = Missing.Value;
    //        bool isHeader = false;
    //        foreach (var vblContact in vblApplication.Contacts)
    //        {
    //            var para1 = document.Content.Paragraphs.Add(ref missing);
    //            para1.Range.Text = $"Income Details Of {vblContact.Forename + " " + vblContact.Surname}";
    //            para1.Range.InsertParagraphAfter();
    //            para1.Range.Paragraphs.SpaceAfter = 0;
    //            var para2 = document.Content.Paragraphs.Add(ref missing);
    //            incomeDetails.Clear();
    //            incomeDetails.AddRange(vblContact.IncomeDetails);
    //            var firstTable = document.Tables.Add(para2.Range, incomeDetails.Count + 1, 3, ref missing, ref missing);
    //            firstTable.Borders.Enable = 1;
    //            int ctr = 0;
    //            foreach (Row row in firstTable.Rows)
    //            {
    //                var incomeDetail = incomeDetails[ctr];
    //                if (incomeDetails.Count == ctr) break;
    //                foreach (Cell cell in row.Cells)
    //                {
    //                    #region Header row
    //                    if (cell.RowIndex == 1)
    //                    {
    //                        isHeader = true;
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = "Income Source";
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {
    //                            cell.Range.Text = "Amount";
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                        }
    //                        else if (cell.ColumnIndex == 3)
    //                        {
    //                            cell.Range.Text = "Frequency";
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                        }
    //                        cell.Range.Font.Bold = -1;
    //                        cell.Range.Font.Name = "Ariel";
    //                        cell.Range.Font.Size = 12;
    //                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

    //                    }
    //                    #endregion

    //                    #region Data row
    //                    else
    //                    {
    //                        isHeader = false;
    //                        if (cell.ColumnIndex == 1)
    //                        {
    //                            cell.Range.Text = incomeDetail.IncomeType.Name;
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    //                        }
    //                        else if (cell.ColumnIndex == 2)
    //                        {

    //                            cell.Range.Text = incomeDetail.Amount.ToString();
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                        }
    //                        else if (cell.ColumnIndex == 3)
    //                        {
    //                            cell.Range.Text = incomeDetail.IncomeFrequency.Name;
    //                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    //                        }
    //                    }
    //                    #endregion
    //                }
    //                if (isHeader)
    //                {
    //                    ctr = 0;
    //                }
    //                else
    //                {
    //                    ctr = ctr + 1;
    //                }

    //            }
    //        }
    //    }
    //    private void InsertBlankLine(Document document, int count, ref object missing)
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            var para = document.Content.Paragraphs.Add(ref missing);
    //            para.Range.InsertParagraphAfter();
    //        }

    //    }
    //    private void InsertParagraph(Document document, string text, bool isBold, ref object missing)
    //    {

    //        var para = document.Content.Paragraphs.Add(ref missing);
    //        para.Range.Text = text;
    //        if (isBold)
    //        {
    //            para.Range.Font.Bold = -1;
    //        }
    //        else
    //        {
    //            para.Range.Font.Bold = 0;
    //        }
    //        para.Range.InsertParagraphAfter();
    //        para.Range.Paragraphs.SpaceAfter = 0;
    //        return;
    //    }
    //}
}
