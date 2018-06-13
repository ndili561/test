using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Hosting;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using GeneratedCode;
using Incomm.Allocations.BLL.Common;
using Incomm.Allocations.BLL.Documents.Template;
using InCoreLib.Domain.Allocations.Database.VBL;
using InCoreLib.Service.Api.DTOs;
using DocumentType = InCoreLib.Domain.Allocations.Enumerations.DocumentType;

namespace Incomm.Allocations.BLL.Documents
{
    //public class OOXMLWordProcessor
    //{

    //    public string GenerateNewVBLApplication(VBLApplication vblApplication, VBLDocumentDTO documentDto)
    //    {
         
    //        try
    //        {
    //            dynamic templatePath = HostingEnvironment.MapPath("~/App_Data/Document");
    //            var filePath = templatePath + "\\" + documentDto.DocumentType + "_" + DateTime.Now.ToFileTimeUtc() + "_" + vblApplication.ApplicationId + "_Decrypt.docx";
    //            new NewApplication(vblApplication, documentDto).CreatePackage(filePath);
    //            using (var doc = WordprocessingDocument.Open(filePath, true))
    //            {
    //                var docSett = doc.MainDocumentPart.DocumentSettingsPart;
    //                docSett.RootElement.Append(new DocumentProtection { Edit = DocumentProtectionValues.ReadOnly });
    //                docSett.RootElement.Save();
    //            }
    //            return filePath;
    //        }

    //        catch (Exception ex)
    //        {
    //            //Logger.Info("Exception occurs in GenerateNewVBLApplication " + ex.ToString());
    //            //string message = string.Empty;
    //            //while (ex != null)
    //            //{
    //            //    message = message + Environment.NewLine + ex.Message;
    //            //    ex = ex.InnerException;
    //            //}
    //            //Logger.Info("Exception Message for GenerateVBLApplication" + message);
    //            throw;
    //        }
    //    }

    //    public string GenerateVBLApplication(VBLApplication vblApplication, VBLDocumentDTO documentDto)
    //    {
    //        dynamic templatePath = HostingEnvironment.MapPath("~/App_Data/Document");
    //        var maintenant = vblApplication.Contacts.First(x => x.ContactTypeId == 1);
    //        try
    //        {
    //            var filePath = templatePath + "\\" + documentDto.DocumentType + "_" + DateTime.Now.ToFileTimeUtc() + "_" + vblApplication.ApplicationId + "_Decrypt.docx";
    //            switch (documentDto.DocumentType)
    //            {
    //                case DocumentType.ClosureApplication:
    //                    new Closure().CreatePackage(filePath);
    //                    break;
    //                case DocumentType.RefusalApplication:
    //                    new Refusal().CreatePackage(filePath);
    //                    break;
    //                case DocumentType.ExpireApplication:
    //                    new Expiry().CreatePackage(filePath);
    //                    break;
    //            }
    //            using (var doc = WordprocessingDocument.Open(filePath, true))
    //            {
    //                foreach (var text in doc.MainDocumentPart.Document.Descendants<Text>()) 
    //                {
    //                    ReplaceText(text, "ApplicantNamePlaceHolder", maintenant.Forename + " " + maintenant.Surname);
    //                    ReplaceText(text, "ApplicationNumberPlaceHolder", vblApplication.ApplicationId.ToString());
    //                    ReplaceText(text, "Address1PlaceHolder", vblApplication.Address != null ? vblApplication.Address.AddressLine1 : "");
    //                    ReplaceText(text, "Address2PlaceHolder", vblApplication.Address != null ? vblApplication.Address.AddressLine2 : "");
    //                    ReplaceText(text, "CityPlaceHolder", vblApplication.Address != null ? vblApplication.Address.AddressLine3 : "");
    //                    ReplaceText(text, "PostcodePlaceHolder", vblApplication.Address != null ? vblApplication.Address.PostCode : "");
    //                    ReplaceText(text, "OurReferencePlaceHolder", "");
    //                    ReplaceText(text, "YourReferencePlaceHolder", "");
    //                    ReplaceText(text, "CurrentDatePlaceHolder", DateTime.Now.ToShortDateString());
    //                    ReplaceText(text, "ExpiryDatePlaceHolder", vblApplication.ApplicationClosedDate?.ToShortDateString() ?? string.Empty);
    //                    ReplaceText(text, "PropertyAddressPlaceHolder", "Address of property");
    //                    ReplaceText(text, "LandlordNamePlaceHolder", "Landlord Name");
    //                    ReplaceText(text, "RefusalReasonPlaceHolder", "Refusal Reason");
    //                    ReplaceText(text, "OrganisationNamePlaceHolder", "Organisation Name");
    //                    ReplaceText(text, "OfficerNamePlaceHolder", "Officer Name");
    //                    ReplaceText(text, "RefusedByPlaceHolder", "Refused By");

    //                    ReplaceText(text, "TelephoneNumberPlaceHolder", "01274 257777");
    //                    ReplaceText(text, "FaxNumberPlaceHolder", "01274 257777");
    //                    ReplaceText(text, "EmailAddressPlaceHolder", "help@help.com");
    //                    ReplaceText(text, "ServiceNamePlaceHolder", "Service Name");
    //                }
    //                var docSett = doc.MainDocumentPart.DocumentSettingsPart;
    //                docSett.RootElement.Append(new DocumentProtection { Edit = DocumentProtectionValues.ReadOnly });
    //                docSett.RootElement.Save();
    //            }
    //            return filePath;
    //        }
             
    //        catch (Exception ex)
    //        {
    //            //Logger.Info("Exception occurs in GenerateVBLApplication " + ex.ToString());
    //            //string message = string.Empty;
    //            //while (ex != null)
    //            //{
    //            //    message = message + Environment.NewLine + ex.Message;
    //            //    ex = ex.InnerException;
    //            //}
    //            //Logger.Info("Exception Message for GenerateVBLApplication" + message);
    //            throw;
    //        }
    //    }

    //    private static void ReplaceText(Text text,string placeHolderName, string placeHolderValue)
    //    {
    //        if (text.Text.Contains(placeHolderName))
    //        {
    //            text.Text = text.Text.Replace(placeHolderName, placeHolderValue);
    //        }
    //    }

    //}


}



