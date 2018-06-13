using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Incomm.Allocations.BLL.Common
{
   public class FileTypeConverter
    {
        public void ConvertWord2PDF(string inputFile, string outputPath)
        {
            try
            {
                if (outputPath.Equals("") || !File.Exists(inputFile))
                {
                    throw new Exception("Either file does not exist or invalid output path");
                }

                // app to open the document belower
                var wordApp = new Application();

                // input variables
                object objInputFile = inputFile;
                var missParam = Type.Missing;

                var wordDocument = wordApp.Documents.Open(ref objInputFile, ref missParam, ref missParam, ref missParam,
                    ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam,
                    ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam);

                if (wordDocument != null)
                {
                    // make the convertion
                    wordDocument.ExportAsFixedFormat(outputPath, WdExportFormat.wdExportFormatPDF, false,
                        WdExportOptimizeFor.wdExportOptimizeForOnScreen, WdExportRange.wdExportAllDocument,
                        0, 0, WdExportItem.wdExportDocumentContent, true, true,
                        WdExportCreateBookmarks.wdExportCreateWordBookmarks, true, true, false, ref missParam);
                }

                // close document and quit application
                wordDocument.Close();
                wordApp.Quit();
                Debug.WriteLine("File successfully converted");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
