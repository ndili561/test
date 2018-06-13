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
    public static class StyleDefinitions
    {
        // Generates content of styleDefinitionsPart1.
        public static void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles2 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            styles2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            DocDefaults docDefaults2 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault2 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
            RunFonts runFonts319 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", EastAsia = "Calibri", ComplexScript = "Times New Roman" };
            Languages languages9 = new Languages() { Val = "en-GB", EastAsia = "en-GB", Bidi = "ar-SA" };

            runPropertiesBaseStyle2.Append(runFonts319);
            runPropertiesBaseStyle2.Append(languages9);

            runPropertiesDefault2.Append(runPropertiesBaseStyle2);
            ParagraphPropertiesDefault paragraphPropertiesDefault2 = new ParagraphPropertiesDefault();

            docDefaults2.Append(runPropertiesDefault2);
            docDefaults2.Append(paragraphPropertiesDefault2);

            LatentStyles latentStyles2 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles2.Append(latentStyleExceptionInfo138);
            latentStyles2.Append(latentStyleExceptionInfo139);
            latentStyles2.Append(latentStyleExceptionInfo140);
            latentStyles2.Append(latentStyleExceptionInfo141);
            latentStyles2.Append(latentStyleExceptionInfo142);
            latentStyles2.Append(latentStyleExceptionInfo143);
            latentStyles2.Append(latentStyleExceptionInfo144);
            latentStyles2.Append(latentStyleExceptionInfo145);
            latentStyles2.Append(latentStyleExceptionInfo146);
            latentStyles2.Append(latentStyleExceptionInfo147);
            latentStyles2.Append(latentStyleExceptionInfo148);
            latentStyles2.Append(latentStyleExceptionInfo149);
            latentStyles2.Append(latentStyleExceptionInfo150);
            latentStyles2.Append(latentStyleExceptionInfo151);
            latentStyles2.Append(latentStyleExceptionInfo152);
            latentStyles2.Append(latentStyleExceptionInfo153);
            latentStyles2.Append(latentStyleExceptionInfo154);
            latentStyles2.Append(latentStyleExceptionInfo155);
            latentStyles2.Append(latentStyleExceptionInfo156);
            latentStyles2.Append(latentStyleExceptionInfo157);
            latentStyles2.Append(latentStyleExceptionInfo158);
            latentStyles2.Append(latentStyleExceptionInfo159);
            latentStyles2.Append(latentStyleExceptionInfo160);
            latentStyles2.Append(latentStyleExceptionInfo161);
            latentStyles2.Append(latentStyleExceptionInfo162);
            latentStyles2.Append(latentStyleExceptionInfo163);
            latentStyles2.Append(latentStyleExceptionInfo164);
            latentStyles2.Append(latentStyleExceptionInfo165);
            latentStyles2.Append(latentStyleExceptionInfo166);
            latentStyles2.Append(latentStyleExceptionInfo167);
            latentStyles2.Append(latentStyleExceptionInfo168);
            latentStyles2.Append(latentStyleExceptionInfo169);
            latentStyles2.Append(latentStyleExceptionInfo170);
            latentStyles2.Append(latentStyleExceptionInfo171);
            latentStyles2.Append(latentStyleExceptionInfo172);
            latentStyles2.Append(latentStyleExceptionInfo173);
            latentStyles2.Append(latentStyleExceptionInfo174);
            latentStyles2.Append(latentStyleExceptionInfo175);
            latentStyles2.Append(latentStyleExceptionInfo176);
            latentStyles2.Append(latentStyleExceptionInfo177);
            latentStyles2.Append(latentStyleExceptionInfo178);
            latentStyles2.Append(latentStyleExceptionInfo179);
            latentStyles2.Append(latentStyleExceptionInfo180);
            latentStyles2.Append(latentStyleExceptionInfo181);
            latentStyles2.Append(latentStyleExceptionInfo182);
            latentStyles2.Append(latentStyleExceptionInfo183);
            latentStyles2.Append(latentStyleExceptionInfo184);
            latentStyles2.Append(latentStyleExceptionInfo185);
            latentStyles2.Append(latentStyleExceptionInfo186);
            latentStyles2.Append(latentStyleExceptionInfo187);
            latentStyles2.Append(latentStyleExceptionInfo188);
            latentStyles2.Append(latentStyleExceptionInfo189);
            latentStyles2.Append(latentStyleExceptionInfo190);
            latentStyles2.Append(latentStyleExceptionInfo191);
            latentStyles2.Append(latentStyleExceptionInfo192);
            latentStyles2.Append(latentStyleExceptionInfo193);
            latentStyles2.Append(latentStyleExceptionInfo194);
            latentStyles2.Append(latentStyleExceptionInfo195);
            latentStyles2.Append(latentStyleExceptionInfo196);
            latentStyles2.Append(latentStyleExceptionInfo197);
            latentStyles2.Append(latentStyleExceptionInfo198);
            latentStyles2.Append(latentStyleExceptionInfo199);
            latentStyles2.Append(latentStyleExceptionInfo200);
            latentStyles2.Append(latentStyleExceptionInfo201);
            latentStyles2.Append(latentStyleExceptionInfo202);
            latentStyles2.Append(latentStyleExceptionInfo203);
            latentStyles2.Append(latentStyleExceptionInfo204);
            latentStyles2.Append(latentStyleExceptionInfo205);
            latentStyles2.Append(latentStyleExceptionInfo206);
            latentStyles2.Append(latentStyleExceptionInfo207);
            latentStyles2.Append(latentStyleExceptionInfo208);
            latentStyles2.Append(latentStyleExceptionInfo209);
            latentStyles2.Append(latentStyleExceptionInfo210);
            latentStyles2.Append(latentStyleExceptionInfo211);
            latentStyles2.Append(latentStyleExceptionInfo212);
            latentStyles2.Append(latentStyleExceptionInfo213);
            latentStyles2.Append(latentStyleExceptionInfo214);
            latentStyles2.Append(latentStyleExceptionInfo215);
            latentStyles2.Append(latentStyleExceptionInfo216);
            latentStyles2.Append(latentStyleExceptionInfo217);
            latentStyles2.Append(latentStyleExceptionInfo218);
            latentStyles2.Append(latentStyleExceptionInfo219);
            latentStyles2.Append(latentStyleExceptionInfo220);
            latentStyles2.Append(latentStyleExceptionInfo221);
            latentStyles2.Append(latentStyleExceptionInfo222);
            latentStyles2.Append(latentStyleExceptionInfo223);
            latentStyles2.Append(latentStyleExceptionInfo224);
            latentStyles2.Append(latentStyleExceptionInfo225);
            latentStyles2.Append(latentStyleExceptionInfo226);
            latentStyles2.Append(latentStyleExceptionInfo227);
            latentStyles2.Append(latentStyleExceptionInfo228);
            latentStyles2.Append(latentStyleExceptionInfo229);
            latentStyles2.Append(latentStyleExceptionInfo230);
            latentStyles2.Append(latentStyleExceptionInfo231);
            latentStyles2.Append(latentStyleExceptionInfo232);
            latentStyles2.Append(latentStyleExceptionInfo233);
            latentStyles2.Append(latentStyleExceptionInfo234);
            latentStyles2.Append(latentStyleExceptionInfo235);
            latentStyles2.Append(latentStyleExceptionInfo236);
            latentStyles2.Append(latentStyleExceptionInfo237);
            latentStyles2.Append(latentStyleExceptionInfo238);
            latentStyles2.Append(latentStyleExceptionInfo239);
            latentStyles2.Append(latentStyleExceptionInfo240);
            latentStyles2.Append(latentStyleExceptionInfo241);
            latentStyles2.Append(latentStyleExceptionInfo242);
            latentStyles2.Append(latentStyleExceptionInfo243);
            latentStyles2.Append(latentStyleExceptionInfo244);
            latentStyles2.Append(latentStyleExceptionInfo245);
            latentStyles2.Append(latentStyleExceptionInfo246);
            latentStyles2.Append(latentStyleExceptionInfo247);
            latentStyles2.Append(latentStyleExceptionInfo248);
            latentStyles2.Append(latentStyleExceptionInfo249);
            latentStyles2.Append(latentStyleExceptionInfo250);
            latentStyles2.Append(latentStyleExceptionInfo251);
            latentStyles2.Append(latentStyleExceptionInfo252);
            latentStyles2.Append(latentStyleExceptionInfo253);
            latentStyles2.Append(latentStyleExceptionInfo254);
            latentStyles2.Append(latentStyleExceptionInfo255);
            latentStyles2.Append(latentStyleExceptionInfo256);
            latentStyles2.Append(latentStyleExceptionInfo257);
            latentStyles2.Append(latentStyleExceptionInfo258);
            latentStyles2.Append(latentStyleExceptionInfo259);
            latentStyles2.Append(latentStyleExceptionInfo260);
            latentStyles2.Append(latentStyleExceptionInfo261);
            latentStyles2.Append(latentStyleExceptionInfo262);
            latentStyles2.Append(latentStyleExceptionInfo263);
            latentStyles2.Append(latentStyleExceptionInfo264);
            latentStyles2.Append(latentStyleExceptionInfo265);
            latentStyles2.Append(latentStyleExceptionInfo266);
            latentStyles2.Append(latentStyleExceptionInfo267);
            latentStyles2.Append(latentStyleExceptionInfo268);
            latentStyles2.Append(latentStyleExceptionInfo269);
            latentStyles2.Append(latentStyleExceptionInfo270);
            latentStyles2.Append(latentStyleExceptionInfo271);
            latentStyles2.Append(latentStyleExceptionInfo272);
            latentStyles2.Append(latentStyleExceptionInfo273);
            latentStyles2.Append(latentStyleExceptionInfo274);

            Style style15 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normal", Default = true };
            StyleName styleName15 = new StyleName() { Val = "Normal" };

            StyleParagraphProperties styleParagraphProperties7 = new StyleParagraphProperties();
            SuppressAutoHyphens suppressAutoHyphens8 = new SuppressAutoHyphens();
            AutoSpaceDN autoSpaceDN8 = new AutoSpaceDN() { Val = false };
            SpacingBetweenLines spacingBetweenLines27 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };
            TextAlignment textAlignment8 = new TextAlignment() { Val = VerticalTextAlignmentValues.Baseline };

            styleParagraphProperties7.Append(suppressAutoHyphens8);
            styleParagraphProperties7.Append(autoSpaceDN8);
            styleParagraphProperties7.Append(spacingBetweenLines27);
            styleParagraphProperties7.Append(textAlignment8);

            StyleRunProperties styleRunProperties10 = new StyleRunProperties();
            FontSize fontSize338 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript70 = new FontSizeComplexScript() { Val = "22" };
            Languages languages10 = new Languages() { EastAsia = "en-US" };

            styleRunProperties10.Append(fontSize338);
            styleRunProperties10.Append(fontSizeComplexScript70);
            styleRunProperties10.Append(languages10);

            style15.Append(styleName15);
            style15.Append(styleParagraphProperties7);
            style15.Append(styleRunProperties10);

            Style style16 = new Style() { Type = StyleValues.Paragraph, StyleId = "Heading1" };
            StyleName styleName16 = new StyleName() { Val = "heading 1" };
            BasedOn basedOn5 = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle2 = new NextParagraphStyle() { Val = "Normal" };

            StyleParagraphProperties styleParagraphProperties8 = new StyleParagraphProperties();
            KeepNext keepNext2 = new KeepNext();
            SpacingBetweenLines spacingBetweenLines28 = new SpacingBetweenLines() { Before = "240", After = "60" };
            OutlineLevel outlineLevel2 = new OutlineLevel() { Val = 0 };

            styleParagraphProperties8.Append(keepNext2);
            styleParagraphProperties8.Append(spacingBetweenLines28);
            styleParagraphProperties8.Append(outlineLevel2);

            StyleRunProperties styleRunProperties11 = new StyleRunProperties();
            RunFonts runFonts320 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman" };
            Bold bold74 = new Bold();
            BoldComplexScript boldComplexScript5 = new BoldComplexScript();
            Kern kern3 = new Kern() { Val = (UInt32Value)3U };
            FontSize fontSize339 = new FontSize() { Val = "32" };
            FontSizeComplexScript fontSizeComplexScript71 = new FontSizeComplexScript() { Val = "32" };

            styleRunProperties11.Append(runFonts320);
            styleRunProperties11.Append(bold74);
            styleRunProperties11.Append(boldComplexScript5);
            styleRunProperties11.Append(kern3);
            styleRunProperties11.Append(fontSize339);
            styleRunProperties11.Append(fontSizeComplexScript71);

            style16.Append(styleName16);
            style16.Append(basedOn5);
            style16.Append(nextParagraphStyle2);
            style16.Append(styleParagraphProperties8);
            style16.Append(styleRunProperties11);

            Style style17 = new Style() { Type = StyleValues.Character, StyleId = "DefaultParagraphFont", Default = true };
            StyleName styleName17 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority6 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden6 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed5 = new UnhideWhenUsed();

            style17.Append(styleName17);
            style17.Append(uIPriority6);
            style17.Append(semiHidden6);
            style17.Append(unhideWhenUsed5);

            Style style18 = new Style() { Type = StyleValues.Table, StyleId = "TableNormal", Default = true };
            StyleName styleName18 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority7 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden7 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed6 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault44 = new TableCellMarginDefault();
            TopMargin topMargin148 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin11 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin148 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin11 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault44.Append(topMargin148);
            tableCellMarginDefault44.Append(tableCellLeftMargin11);
            tableCellMarginDefault44.Append(bottomMargin148);
            tableCellMarginDefault44.Append(tableCellRightMargin11);

            styleTableProperties2.Append(tableIndentation2);
            styleTableProperties2.Append(tableCellMarginDefault44);

            style18.Append(styleName18);
            style18.Append(uIPriority7);
            style18.Append(semiHidden7);
            style18.Append(unhideWhenUsed6);
            style18.Append(styleTableProperties2);

            Style style19 = new Style() { Type = StyleValues.Numbering, StyleId = "NoList", Default = true };
            StyleName styleName19 = new StyleName() { Val = "No List" };
            UIPriority uIPriority8 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden8 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed7 = new UnhideWhenUsed();

            style19.Append(styleName19);
            style19.Append(uIPriority8);
            style19.Append(semiHidden8);
            style19.Append(unhideWhenUsed7);

            Style style20 = new Style() { Type = StyleValues.Paragraph, StyleId = "NoSpacing" };
            StyleName styleName20 = new StyleName() { Val = "No Spacing" };

            StyleParagraphProperties styleParagraphProperties9 = new StyleParagraphProperties();
            SuppressAutoHyphens suppressAutoHyphens9 = new SuppressAutoHyphens();
            AutoSpaceDN autoSpaceDN9 = new AutoSpaceDN() { Val = false };
            TextAlignment textAlignment9 = new TextAlignment() { Val = VerticalTextAlignmentValues.Baseline };

            styleParagraphProperties9.Append(suppressAutoHyphens9);
            styleParagraphProperties9.Append(autoSpaceDN9);
            styleParagraphProperties9.Append(textAlignment9);

            StyleRunProperties styleRunProperties12 = new StyleRunProperties();
            FontSize fontSize340 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript72 = new FontSizeComplexScript() { Val = "22" };
            Languages languages11 = new Languages() { EastAsia = "en-US" };

            styleRunProperties12.Append(fontSize340);
            styleRunProperties12.Append(fontSizeComplexScript72);
            styleRunProperties12.Append(languages11);

            style20.Append(styleName20);
            style20.Append(styleParagraphProperties9);
            style20.Append(styleRunProperties12);

            Style style21 = new Style() { Type = StyleValues.Paragraph, StyleId = "Header" };
            StyleName styleName21 = new StyleName() { Val = "header" };
            BasedOn basedOn6 = new BasedOn() { Val = "Normal" };

            StyleParagraphProperties styleParagraphProperties10 = new StyleParagraphProperties();

            Tabs tabs3 = new Tabs();
            TabStop tabStop5 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
            TabStop tabStop6 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

            tabs3.Append(tabStop5);
            tabs3.Append(tabStop6);

            styleParagraphProperties10.Append(tabs3);

            style21.Append(styleName21);
            style21.Append(basedOn6);
            style21.Append(styleParagraphProperties10);

            Style style22 = new Style() { Type = StyleValues.Character, StyleId = "HeaderChar", CustomStyle = true };
            StyleName styleName22 = new StyleName() { Val = "Header Char" };

            StyleRunProperties styleRunProperties13 = new StyleRunProperties();
            FontSize fontSize341 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript73 = new FontSizeComplexScript() { Val = "22" };
            Languages languages12 = new Languages() { EastAsia = "en-US" };

            styleRunProperties13.Append(fontSize341);
            styleRunProperties13.Append(fontSizeComplexScript73);
            styleRunProperties13.Append(languages12);

            style22.Append(styleName22);
            style22.Append(styleRunProperties13);

            Style style23 = new Style() { Type = StyleValues.Paragraph, StyleId = "Footer" };
            StyleName styleName23 = new StyleName() { Val = "footer" };
            BasedOn basedOn7 = new BasedOn() { Val = "Normal" };

            StyleParagraphProperties styleParagraphProperties11 = new StyleParagraphProperties();

            Tabs tabs4 = new Tabs();
            TabStop tabStop7 = new TabStop() { Val = TabStopValues.Center, Position = 4513 };
            TabStop tabStop8 = new TabStop() { Val = TabStopValues.Right, Position = 9026 };

            tabs4.Append(tabStop7);
            tabs4.Append(tabStop8);

            styleParagraphProperties11.Append(tabs4);

            style23.Append(styleName23);
            style23.Append(basedOn7);
            style23.Append(styleParagraphProperties11);

            Style style24 = new Style() { Type = StyleValues.Character, StyleId = "FooterChar", CustomStyle = true };
            StyleName styleName24 = new StyleName() { Val = "Footer Char" };

            StyleRunProperties styleRunProperties14 = new StyleRunProperties();
            FontSize fontSize342 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript74 = new FontSizeComplexScript() { Val = "22" };
            Languages languages13 = new Languages() { EastAsia = "en-US" };

            styleRunProperties14.Append(fontSize342);
            styleRunProperties14.Append(fontSizeComplexScript74);
            styleRunProperties14.Append(languages13);

            style24.Append(styleName24);
            style24.Append(styleRunProperties14);

            Style style25 = new Style() { Type = StyleValues.Character, StyleId = "Heading1Char", CustomStyle = true };
            StyleName styleName25 = new StyleName() { Val = "Heading 1 Char" };

            StyleRunProperties styleRunProperties15 = new StyleRunProperties();
            RunFonts runFonts321 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold75 = new Bold();
            BoldComplexScript boldComplexScript6 = new BoldComplexScript();
            Kern kern4 = new Kern() { Val = (UInt32Value)3U };
            FontSize fontSize343 = new FontSize() { Val = "32" };
            FontSizeComplexScript fontSizeComplexScript75 = new FontSizeComplexScript() { Val = "32" };
            Languages languages14 = new Languages() { EastAsia = "en-US" };

            styleRunProperties15.Append(runFonts321);
            styleRunProperties15.Append(bold75);
            styleRunProperties15.Append(boldComplexScript6);
            styleRunProperties15.Append(kern4);
            styleRunProperties15.Append(fontSize343);
            styleRunProperties15.Append(fontSizeComplexScript75);
            styleRunProperties15.Append(languages14);

            style25.Append(styleName25);
            style25.Append(styleRunProperties15);

            Style style26 = new Style() { Type = StyleValues.Character, StyleId = "Hyperlink" };
            StyleName styleName26 = new StyleName() { Val = "Hyperlink" };

            StyleRunProperties styleRunProperties16 = new StyleRunProperties();
            Color color2 = new Color() { Val = "0000FF" };
            Underline underline7 = new Underline() { Val = UnderlineValues.Single };

            styleRunProperties16.Append(color2);
            styleRunProperties16.Append(underline7);

            style26.Append(styleName26);
            style26.Append(styleRunProperties16);

            Style style27 = new Style() { Type = StyleValues.Paragraph, StyleId = "BalloonText" };
            StyleName styleName27 = new StyleName() { Val = "Balloon Text" };
            BasedOn basedOn8 = new BasedOn() { Val = "Normal" };
            LinkedStyle linkedStyle3 = new LinkedStyle() { Val = "BalloonTextChar" };
            UIPriority uIPriority9 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden9 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed8 = new UnhideWhenUsed();
            Rsid rsid3 = new Rsid() { Val = "0002564B" };

            StyleParagraphProperties styleParagraphProperties12 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines29 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties12.Append(spacingBetweenLines29);

            StyleRunProperties styleRunProperties17 = new StyleRunProperties();
            RunFonts runFonts322 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", ComplexScript = "Tahoma" };
            FontSize fontSize344 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript76 = new FontSizeComplexScript() { Val = "16" };

            styleRunProperties17.Append(runFonts322);
            styleRunProperties17.Append(fontSize344);
            styleRunProperties17.Append(fontSizeComplexScript76);

            style27.Append(styleName27);
            style27.Append(basedOn8);
            style27.Append(linkedStyle3);
            style27.Append(uIPriority9);
            style27.Append(semiHidden9);
            style27.Append(unhideWhenUsed8);
            style27.Append(rsid3);
            style27.Append(styleParagraphProperties12);
            style27.Append(styleRunProperties17);

            Style style28 = new Style() { Type = StyleValues.Character, StyleId = "BalloonTextChar", CustomStyle = true };
            StyleName styleName28 = new StyleName() { Val = "Balloon Text Char" };
            LinkedStyle linkedStyle4 = new LinkedStyle() { Val = "BalloonText" };
            UIPriority uIPriority10 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden10 = new SemiHidden();
            Rsid rsid4 = new Rsid() { Val = "0002564B" };

            StyleRunProperties styleRunProperties18 = new StyleRunProperties();
            RunFonts runFonts323 = new RunFonts() { Ascii = "Tahoma", HighAnsi = "Tahoma", ComplexScript = "Tahoma" };
            FontSize fontSize345 = new FontSize() { Val = "16" };
            FontSizeComplexScript fontSizeComplexScript77 = new FontSizeComplexScript() { Val = "16" };
            Languages languages15 = new Languages() { EastAsia = "en-US" };

            styleRunProperties18.Append(runFonts323);
            styleRunProperties18.Append(fontSize345);
            styleRunProperties18.Append(fontSizeComplexScript77);
            styleRunProperties18.Append(languages15);

            style28.Append(styleName28);
            style28.Append(linkedStyle4);
            style28.Append(uIPriority10);
            style28.Append(semiHidden10);
            style28.Append(rsid4);
            style28.Append(styleRunProperties18);

            styles2.Append(docDefaults2);
            styles2.Append(latentStyles2);
            styles2.Append(style15);
            styles2.Append(style16);
            styles2.Append(style17);
            styles2.Append(style18);
            styles2.Append(style19);
            styles2.Append(style20);
            styles2.Append(style21);
            styles2.Append(style22);
            styles2.Append(style23);
            styles2.Append(style24);
            styles2.Append(style25);
            styles2.Append(style26);
            styles2.Append(style27);
            styles2.Append(style28);

            styleDefinitionsPart1.Styles = styles2;
        }
    }
}
